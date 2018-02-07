using System;
using EWAV.ViewModels;
using System.Collections.Generic;
using EWAV.Web.Services;

namespace EWAV
{
    public interface IEWAVGadget
    {
        /// <summary>
        /// The value for the frameworkelement.Name property 
        /// </summary>  
        string MyControlName { get;   }
        /// <summary>
        /// The value for the UI menus    
        /// </summary>
        string MyUIName { get; }

        /// <summary>
        /// Container that holds gadget level filters.
        /// </summary>
        List<EWAVDataFilterCondition> GadgetFilters { get; set; }

        void Reload();


    }
}