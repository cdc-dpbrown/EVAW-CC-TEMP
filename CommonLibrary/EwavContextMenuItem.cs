﻿namespace EWAV.Common
{
    public class EWAVContextMenuItem
    {
        private string text;
        private string uCName;
        private string type;
        //private string subtype = "";


        ///// <summary>
        ///// Gets or sets the subtype.
        ///// </summary>
        ///// <value>The subtype.</value>
        //public string Subtype
        //{
        //    get
        //    {
        //        return this.subtype;
        //    }
        //    set
        //    {
        //        this.subtype = value;
        //    }
        //}

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the UC.
        /// </summary>
        /// <value>The name of the UC.</value>
        public string UCName
        {
            get
            {
                return this.uCName;
            }
            set
            {
                this.uCName = value;
            }
        }


    }
}