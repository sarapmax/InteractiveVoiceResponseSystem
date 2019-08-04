using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;
using InteractiveVoiceResponseSystem.Areas.Instructor.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Controllers.Apis
{
    [Area("Instructor")]
    [Route("[area]/api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly NewVersionHintsDBContext _newVersionHintsDbContext;
        
        public QuestionController(NewVersionHintsDBContext newVersionHintsDbContext)
        {
            _newVersionHintsDbContext = newVersionHintsDbContext;
        }
        
        [HttpPost("store")]
        public IActionResult Store(Question question)
        {
            var questionId = "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            
            _newVersionHintsDbContext.QuestionMode.Add(new QuestionMode
            {
                CQid = questionId,
                CPaperId = null,
                CDivisionId = null,
                CQuestionGroupId = null,
                CQuestionGroupName = null,
                CQuestionMode = "General",
                CQuestionType = question.QuestionType
            });

            _newVersionHintsDbContext.QuestionIndex.Add(new QuestionIndex
            {
                CQid = questionId,
                CQuestion = question.QuestionTitle,
                SLevel = 1,
                CAnswer = question.FillOutAnswer
            });

            if (question.QuestionType == "1")
            {
                foreach (var choice in question.SelectionChoices)
                {
                    var index = question.SelectionChoices.IndexOf(choice);
                    
                    _newVersionHintsDbContext.QuestionSelectionIndex.Add(new QuestionSelectionIndex
                    {
                        CQid = questionId,
                        CSelectionId = "_Selection_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + index,
                        SSeq = (short) index,
                        CSelection = choice.Answer,
                        CResponse = null,
                        BCaseSelect = choice.Correct
                    });
                }
               
            }

            _newVersionHintsDbContext.IvrsselectionQuestion.Add(new IvrsselectionQuestion
            {
                CQid = questionId,
                CNodeId = question.NodeId,
                Selected = 0
            });

            _newVersionHintsDbContext.SaveChanges();
            
            return Ok(questionId);
        }

        [HttpPost("update")]
        public IActionResult Update(Question question)
        {
            var vpAnswer = _newVersionHintsDbContext.IvrsvpAnswers.SingleOrDefault(iva =>
                iva.CSelectionQuestionID == question.CSelectionQuestionID);

            if (vpAnswer == null)
            {
                _newVersionHintsDbContext.IvrsvpAnswers.Add(new IvrsvpAnswer
                {
                    CSelectionQuestionID = question.CSelectionQuestionID,
                    Answer = question.Answer
                });
            }
            else
            {
                vpAnswer.Answer = question.Answer;
            }

            if (question.Selected)
            {
                // Remove all selected questions.
                var ivrsselectionQuestions = _newVersionHintsDbContext.IvrsselectionQuestion.Where(isq => isq.CNodeId == question.NodeId);

                foreach (var ivrsselectionQuestion in ivrsselectionQuestions)
                {
                    ivrsselectionQuestion.Selected = 0;
                }
                
                // Set selected to the one the user just chose.
                var selectionQuestion =
                    _newVersionHintsDbContext.IvrsselectionQuestion.SingleOrDefault(isq => 
                        isq.CSelectionQuestionId == question.CSelectionQuestionID);

                if (selectionQuestion != null) selectionQuestion.Selected = 1;
            }

            _newVersionHintsDbContext.SaveChanges();
            
            return Ok("updated question");
        }
    }
}