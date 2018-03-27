using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDC.ISB.EIDEV.Web.Services;

namespace CDC.ISB.EIDEV.Web          
{
    public class Class1
    {
        List<EWAVDataFilterCondition> dfc = new List<EWAVDataFilterCondition>();    

        /// <summary>
        /// Gets or sets the DFC.
        /// </summary>
        /// <value>The DFC.</value>
        public List<EWAVDataFilterCondition> Dfc
        {
            get
            {
                return this.dfc;
            }
            set
            {
                this.dfc = value;
            }
        }
    }
}