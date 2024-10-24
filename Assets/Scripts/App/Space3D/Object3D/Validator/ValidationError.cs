namespace App.Space3D.Object3D.Validator
{
    public class ValidationError
    {
        public ValidationErrorType ErrorType { get; private set; }
        public string Message {get; private set;}

        public ValidationError(ValidationErrorType errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }
    }
}