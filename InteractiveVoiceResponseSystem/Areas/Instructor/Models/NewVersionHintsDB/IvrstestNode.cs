using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class IvrstestNode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        
        public IList<IvrstestNode> Children { get; set; } = new List<IvrstestNode>();
    }
}
