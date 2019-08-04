using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class QuestionIndex
    {
        public string CQid { get; set; }
        public string CQuestion { get; set; }
        public short SLevel { get; set; }
        public string CAnswer { get; set; }
        public string CKeyWords { get; set; }
        [NotMapped]
        public IList<QuestionSelectionIndex> QuestionSelectionIndexes { get; set; }
    }
}
