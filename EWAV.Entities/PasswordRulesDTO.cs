using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EWAV.DTO
{
    public class PasswordRulesDTO
    {
        public bool UseSymbols { 
            get 
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseSymbols"]);
            }
        }
        public bool UseNumeric
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseNumbers"]);
            }
        }
        public bool UseUpperCase
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseUpperCase"]);
            }
        }
        public bool UseLowerCase
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseLowerCase"]);
            }
        }

        public string Symbols
        {
            get
            {
                return ConfigurationManager.AppSettings["Symbols"].ToString();
            }
        }

        public bool RepeatCharacters
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["RepeatCharacters"].ToString());
            }
        }

        public bool ConsecutiveCharacters
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["ConsecutiveCharacters"].ToString());
            }
        }

        public int MinimumLength
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PasswordMinimumLength"].ToString());
            }
        }

        public int MaximumLength
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PasswordMaximumLength"].ToString());
            }
        }

        public bool UseUserIdInPassword
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseUserIdInPassword"].ToString());
            }
        }

        public bool UseUserNameInPassword
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseUserNameInPassword"].ToString());
            }
        }


        public int NumberOfTypesRequiredInPassword
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfTypesRequiredInPassword"].ToString());
            }
        }

    }
}