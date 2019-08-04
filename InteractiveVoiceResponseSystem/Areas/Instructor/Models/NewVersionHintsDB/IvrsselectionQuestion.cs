using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class IvrsselectionQuestion
    {
        public int CSelectionQuestionId { get; set; }
        public string CNodeId { get; set; }
        public string CQid { get; set; }
        public byte? Selected { get; set; }
        [NotMapped]
        public QuestionIndex QuestionIndex { get; set; }
        [NotMapped]
        public QuestionMode QuestionMode { get; set; }
        [NotMapped]
        public IvrsvpAnswer VPAnswer { get; set; }
    }
}
