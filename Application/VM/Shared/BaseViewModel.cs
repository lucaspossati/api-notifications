using System.Collections.Generic;

namespace api.Domain.VM.Shared
{
    public abstract class BaseViewModel
    {
        public dynamic Errors { get; private set; }

        public void SetErrors(dynamic errors)
        {
            Errors = errors;
        }
    }

    public class Error
    {
        public string PropertyName { get; set;}
        public string ErrorMessage { get; set; }
    }
}
