using System;
using UnityEngine;

namespace App.Tree
{
    public class TreeTest : MonoBehaviour
    {
        private void Awake()
        {
            TreeManager tm = new TreeManager();
            
            tm.AddNode("a", null);
            var nodeB = tm.AddNode("b", "a");
            tm.AddNode("c", "a");
            tm.AddNode("d", "b");
            tm.AddNode("e", "b");
            tm.AddNode("f", "b");
            tm.AddNode("g", "c");
            var nodeH = tm.AddNode("h", "d");
            
            tm.UpdateIndex();
            tm.PrintTree();

            nodeB.AddChild(nodeH);
            tm.UpdateIndex();
            tm.PrintTree();
            
            tm.AddNode("i", "a");
            tm.UpdateIndex();
            tm.PrintTree();

        }
    }
}