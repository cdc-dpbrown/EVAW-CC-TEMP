using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWAV.Services
{
    class GadgetException : Exception
    {
        private string p;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public GadgetException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
            Message = p;
        }
    }
}