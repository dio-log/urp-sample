using System.Collections.Generic;
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
            
            result.AddError(new ValidationError(ValidationErrorType.OBJECT_ID_DUPLICATE, "Object ID is already defined"));

            return result; 
        } 
    }
}