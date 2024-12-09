using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using App.Core.Entities.Object3D;

namespace App.Core.Entities.Context
{
    public class Object3DContext
    {
        public IEnumerable<ResourceData> Object3DCollection { get; set; }
        
    }
}