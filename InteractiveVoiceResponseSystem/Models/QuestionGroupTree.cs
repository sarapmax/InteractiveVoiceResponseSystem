using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Models
{
    public partial class QuestionGroupTree
    {
        public int ISerialNum { get; set; }
        public string CNodeId { get; set; }
        public string CParentId { get; set; }
        public string CNodeName { get; set; }
        public string CNodeType { get; set; }
        public string CAuthor { get; set; }
        public int? QId { get; set; }
    }
}
