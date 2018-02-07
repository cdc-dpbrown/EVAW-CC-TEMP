using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWAV.Web.Services
{
    /// <summary>
    /// A class created to help mimic the dataTable used in LogisticRegression Control.
    /// </summary>
    public class ListOfStringClass
    {
        private List<string> ls;

        public List<string> Ls
        {
            get { return ls; }
            set { ls = value; }
        }

    }
}