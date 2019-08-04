using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
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
        
        [NotMapped]
        public IList<QuestionGroupTree> Children { get; set; } = new List<QuestionGroupTree>();
        [NotMapped]
        public string NodeIndex { get; set; }
        [NotMapped]
        public IList<IvrsselectionQuestion> SelectionQuestions { get; set; }
    }
}
