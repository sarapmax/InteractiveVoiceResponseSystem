using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;
using InteractiveVoiceResponseSystem.Areas.Instructor.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    public class ProfessionController : Controller
    {
        private readonly NewVersionHintsDBContext _newVersionHintsDbContext;

        public ProfessionController(NewVersionHintsDBContext newVersionHintsDbContext)
        {
            _newVersionHintsDbContext = newVersionHintsDbContext;
        }

        public IActionResult Create(string courseId)
        {
            ViewBag.CourseId = courseId;
            
            return View();
        }

        public IActionResult Store(Ivrsprofession profession)
        {
            var professionNodeId = profession.Name + '_' + DateTime.Now.ToString("yyyyMMddHHmmss");
            
            _newVersionHintsDbContext.Ivrsprofession.Add(new Ivrsprofession
            {
                CCourseId = profession.CCourseId,
                NodeId = professionNodeId,
                Name = profession.Name
            });
            
            _newVersionHintsDbContext.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Show(int id)
        {
            var profession = _newVersionHintsDbContext.Ivrsprofession.SingleOrDefault(ia => ia.CProfessionId == id);

            if (profession == null)
            {
                return NotFound();
            }

            var model = BuildQuestionTree(profession.NodeId);

            return View(model);
        }
        
        private IList<QuestionGroupTree> BuildQuestionTree(string topParent)
        {
//            var tree = new Tree
//            {
//                Nodes = _newVersionHintsDbContext.QuestionGroupTree
//                    .Where(qgt => qgt.CNodeType == topParent)
//                    .Select(qgt => new QuestionGroupTree
//                    {
//                        CNodeId = qgt.CNodeId,
//                        CParentId = qgt.CParentId,
//                        CNodeName = qgt.CNodeName,
//                        Children = FlatToHierarchy()
//                    })
//                    .ToDictionary(qgt => qgt.Id),
//                RootNode = new TreeNode { Id = 0, Name = "Root" }
//            };
//
//            tree.BuildTree();
////
//            return tree;

            var list = _newVersionHintsDbContext.QuestionGroupTree.Where(qgt => qgt.CNodeType == topParent).ToList();

            return FlatToHierarchy(list, topParent);
        }
        
        public IList<QuestionGroupTree> FlatToHierarchy(IEnumerable<QuestionGroupTree> list, string parentId) {
            return (from i in list 
                where i.CParentId == parentId 
                select new QuestionGroupTree {
                    CNodeId = i.CNodeId, 
                    CParentId = i.CParentId,
                    CNodeName = i.CNodeName,
                    Children = FlatToHierarchy(list, i.CNodeId)
                }).ToList();
        }
        
//        public IEnumerable<QuestionGroupTree> FlatToHierarchy(List<QuestionGroupTree> list)
//        {
//            // hashtable lookup that allows us to grab references to containers based on id
//            var lookup = new Dictionary<string, QuestionGroupTree>();
//            // actual nested collection to return
//            var nested = new List<QuestionGroupTree>();
//
//            foreach (var item in list)
//            {
//                if (lookup.ContainsKey(item.CParentId))
//                {
//                    // add to the parent's child list 
//                    lookup[item.CParentId].Children.Add(item);
//                }
//                else
//                {
//                    // no parent added yet (or this is the first time)
//                    nested.Add(item);
//                }
//                lookup.Add(item.CNodeId, item);
//            }
//
//            return nested;
//        }
    }
}