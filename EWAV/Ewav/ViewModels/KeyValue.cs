using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWAV.Common;

namespace EWAV.ViewModels
{
    public class KeyValue
    {
        public int Key { get; set; }
        public EWAVContextMenuItem Value { get; set; }

        public KeyValue()
        {

        }

        public KeyValue(int index, EWAVContextMenuItem item)
        {
            Key = index;
            Value = item;
        }
    }

    public class ControlMetaInfo
    {
        private string controlName;

        public string ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }

        private string controlUIName;

        public string ControlUIName
        {
            get { return controlUIName; }
            set { controlUIName = value; }
        }

        private string type;

        public string Type
        {   
            get { return type; }
            set { type = value; }
        }

        private int contextMenuIndex;

        public int ContextMenuIndex
        {
            get { return contextMenuIndex; }
            set { contextMenuIndex = value; }
        } 
    }
}