using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;
using Microsoft.AspNetCore.Mvc;

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
    }
}