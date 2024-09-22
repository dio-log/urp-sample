using System.Collections.Generic;
using UnityEngine.Events;


namespace App.Tree
{
    public class Node
    {
        // public string ParentId { get; set; }
        public string Id { get; set; }
        public int Order { get; set; }
        public int Index { get; set; }
        
        public int Depth { get; set; }
        
        public Node Parent { get; set; }

        public int ChildCount => _children.Count;


        private List<Node> _children = new List<Node>(); 
            
        public void AddChild(Node child)
        {
            child.Parent?.RemoveChild(child);
            _children.Add(child);
            child.Parent = this;
            
            child.Depth = Depth + 1;
        }

        public void RemoveChild(Node child)
        {
            _children.Remove(child);
            child.Parent = null;
        }

        public void ActionRecursively(UnityAction<Node> action)
        {
            action(this);

            foreach (var child in _children)
            {
                child.ActionRecursively(action);
            }
        }

        public void Traverse(UnityAction<Node> action)
        {
            foreach (var child in _children)
            {
                child.Traverse(action);
            }
        }
    }
    
}

