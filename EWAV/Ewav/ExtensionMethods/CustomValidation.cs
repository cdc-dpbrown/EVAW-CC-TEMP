using System.ComponentModel.DataAnnotations;


namespace EWAV.ExtensionMethods
{
    public class CustomValidation
    {
        #region Private Members
        private readonly string message;
        #endregion

        #region Properties
        public bool ShowErrorMessage { get; set; }

        public object ValidationError
        {
            get
            {
                return null;
            }
            set
            {
                if (ShowErrorMessage)
                {
                    throw new ValidationException(message);
                }
            }
        }
        #endregion

        #region Constructor
        public CustomValidation(string message)
        {
            this.message = message;
        }
        #endregion
    }
}