using System.Collections.Generic;
using App.Entity;
using UnityEngine;

namespace App.Space3D.Object3D.Validator
{
    public abstract class BaseValidator
    {
        public abstract ValidationResult Validate(IEntityGroup group);

        public abstract ValidationResult Validate<T>(List<T> entity) where T : IEntity;

        public abstract ValidationResult Validate<T>(T object3D) where T : BaseObject3D;
    }
}