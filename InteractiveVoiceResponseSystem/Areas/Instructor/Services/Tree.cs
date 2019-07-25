using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Services
{
    public class Tree
    {
        private TreeNode _rootNode;
        public TreeNode RootNode
        {
            get { return _rootNode; }
            set
            {
                if (RootNode != null)
                    Nodes.Remove(RootNode.Id);

                Nodes.Add(value.Id, value);
                _rootNode = value;
            }
        }

        public Dictionary<int, TreeNode> Nodes { get; set; }

        public Tree()
        {
        }

        public void BuildTree()
        {
            TreeNode parent;
            foreach (var node in Nodes.Values)
            {
                if (Nodes.TryGetValue(node.ParentId, out parent) && node.Id != node.ParentId)
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }
        }
    }
    
    public class TreeNode
    {
        public int Id;
        public int ParentId;
        public TreeNode Parent;
        public string Name;
        public List<TreeNode> Children = new List<TreeNode>();
    }
}