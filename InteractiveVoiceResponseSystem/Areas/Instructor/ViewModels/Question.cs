using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.ViewModels
{
    public class Question
    {
        public string NodeId { get; set; }
        public string QuestionType { get; set; }
        public string QuestionTitle { get; set; }
        public string FillOutAnswer { get; set; }
        public List<SelectionChoice> SelectionChoices { get; set; }
        public int CSelectionQuestionID { get; set; }
        public string Answer { get; set; }
        public bool Selected { get; set; }
    }
}