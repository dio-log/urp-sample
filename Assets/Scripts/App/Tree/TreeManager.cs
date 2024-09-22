

using App.Hierarchy;
using UnityEngine;

namespace App.Tree
{
    public class TreeManager
    {   
        private Node _root;
        private int _indent = 4;

        public Node AddNode(string id, string parentId)
        {
            var newNode = new Node(){ Id = id };

            if (parentId is null)
            {
                _root = newNode;
                return newNode;
            }
                
            Node found = null;
            _root.ActionRecursively(n =>
            {
                if(n.Id.Equals(parentId))
                {
                    found = n;
                }
            });
            
            if (found is not null)
            {
                found.AddChild(newNode);
            }

            return newNode;
        }

        public void UpdateIndex()
        {
            var _index = 0;
            _root.ActionRecursively(n =>
            {
                n.Index = _index++;
            });
        }

        public void PrintTree()
        {
            _root.ActionRecursively(n =>
            {
                string indent = "";
                for (int i = 0; i < n.Depth; i++)
                {
                    indent += "    ";
                }
                Debug.Log($"{indent}idx : {n.Index} / parent : {n.Parent?.Id} / id : {n.Id} ");
            });
        }
        
        
    }
    
}
