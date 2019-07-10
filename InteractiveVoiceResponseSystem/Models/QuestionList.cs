using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Models
{
    public partial class QuestionList
    {
        public int QId { get; set; }
        public string QName { get; set; }
        public string QRootName { get; set; }
        public int IFeatureSetId { get; set; }
    }
}
