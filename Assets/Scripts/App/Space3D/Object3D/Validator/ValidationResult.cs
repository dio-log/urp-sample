using System.Collections.Generic;

namespace App.Space3D.Object3D.Validator
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; } = true;
        public List<ValidationError> Error { get; private set; } = new();

        public void AddError(ValidationError error)
        {
            Error.Add(error);
        }
    }
}