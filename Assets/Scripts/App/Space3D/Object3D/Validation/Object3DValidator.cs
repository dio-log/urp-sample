using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Entity;

namespace App.Space3D.Object3D.Validator
{
    public class Object3DValidator : BaseValidator
    {
        public override ValidationResult Validate(IEntityGroup group)
        {
            return null;
        }

        public override ValidationResult Validate<T>(T entity)
        {
            return null;
        }
        
        public override ValidationResult Validate<T>(List<T> entity)
        {
            var result = new ValidationResult();
            

            return result; 
        }

        public void Validate(Expression<Func<string, bool>> expression)
        {
            
        }
    }
}