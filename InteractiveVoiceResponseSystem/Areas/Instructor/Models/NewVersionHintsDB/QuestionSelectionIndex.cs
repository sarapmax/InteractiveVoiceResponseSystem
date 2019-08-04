using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class QuestionSelectionIndex
    {
        public string CQid { get; set; }
        public string CSelectionId { get; set; }
        public short SSeq { get; set; }
        public string CSelection { get; set; }
        public string CResponse { get; set; }
        public bool? BCaseSelect { get; set; }
    }
}
