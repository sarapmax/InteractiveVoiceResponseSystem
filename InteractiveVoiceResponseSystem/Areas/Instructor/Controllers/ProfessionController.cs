using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;
using InteractiveVoiceResponseSystem.Services;
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

        public IActionResult Show(int id, string nodeId)
        {
            var profession = _newVersionHintsDbContext.Ivrsprofession.SingleOrDefault(ia => ia.CProfessionId == id);
            if (profession == null) return NotFound();

            var node = _newVersionHintsDbContext.QuestionGroupTree.SingleOrDefault(qgt => qgt.CNodeId == nodeId);

            if (node != null)
            {
                node.SelectionQuestions = 
                    _newVersionHintsDbContext.IvrsselectionQuestion.Where(isq => isq.CNodeId == nodeId).ToList();

                foreach (var selectionQuestion in node.SelectionQuestions)
                {
                    var question = selectionQuestion.QuestionIndex =
                        _newVersionHintsDbContext.QuestionIndex.SingleOrDefault(qi =>qi.CQid == selectionQuestion.CQid);

                    selectionQuestion.QuestionMode =
                        _newVersionHintsDbContext.QuestionMode.SingleOrDefault(qm => qm.CQid == selectionQuestion.CQid);

                    selectionQuestion.VPAnswer = _newVersionHintsDbContext.IvrsvpAnswers.SingleOrDefault(iva =>
                        iva.CSelectionQuestionID == selectionQuestion.CSelectionQuestionId);

                    if (question != null)
                    {
                        question.QuestionSelectionIndexes =
                            _newVersionHintsDbContext.QuestionSelectionIndex.Where(qsi => qsi.CQid == question.CQid).ToList();
                    }
                }
            }
            
            ViewBag.treeData = JsonConvert.SerializeObject(ExerciseTree.BuildQuestionTree(_newVersionHintsDbContext, profession.NodeId));
            ViewBag.professionId = profession.CProfessionId;

            if (node != null)
            {
                ViewBag.selectedNodeId = JsonConvert.SerializeObject(node.CNodeId);
            }

            return View(node);
        }
    }
}
