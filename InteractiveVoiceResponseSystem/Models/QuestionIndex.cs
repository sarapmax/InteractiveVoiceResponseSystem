using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Models
{
    public partial class QuestionIndex
    {
        public string CQid { get; set; }
        public string CQuestion { get; set; }
        public short SLevel { get; set; }
        public string CAnswer { get; set; }
        public string CKeyWords { get; set; }
    }
}
