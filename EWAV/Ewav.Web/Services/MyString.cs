﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWAV.Web.Services
{
    public class MyString
    {
        private string varName;

        public MyString()
        {
        }

        public MyString(string s)
        {
            varName = s;
        }

        public string VarName
        {
            get { return varName; }
            set { varName = value; }
        }

        public string ToString(MyString s)
        {
            return s.VarName;

        }

        internal List<MyString> ToListOfMyString(List<string> columnNames)
        {
            List<MyString> lms = new List<MyString>();

            foreach (var item in columnNames)
            {
                lms.Add(new MyString(item));
            }

            return lms;
        }


        public string GetSafeVarName(MyString myString)
        {

            if (myString == null)
                return "null";
            else
                return myString.VarName;

        }    


        public List<string> ToListOfString(List<MyString> s)
        {
            List<String> ls = new List<string>();
            foreach (var item in s)
            {
                ls.Add(item.VarName);
            }
            return ls;
        }
    }
}