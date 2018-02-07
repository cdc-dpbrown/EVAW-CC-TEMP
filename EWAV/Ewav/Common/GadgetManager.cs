﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using EWAV.ViewModels;

namespace EWAV.Common
{
    public class GadgetManager
    {
        private ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;

        private DragCanvas gadgetParent;

        //  MEF integration  
        //[ImportMany]
        //public IEnumerable<UserControl> Gadgets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GadgetManager" /> class.
        /// </summary>
        public GadgetManager()
        {
            //     CompositionInitializer.SatisfyImports(this);    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GadgetManager" /> class.
        /// </summary>
        public GadgetManager(DragCanvas dragCanvas)
        {
            //    CompositionInitializer.SatisfyImports(this);    
            this.gadgetParent = dragCanvas;
        }

        public void Remove(UserControl gadget)
        {
            foreach (UIElement element in gadgetParent.Children)
            {
                if (element is UserControl)
                {
                    if (((UserControl)element).Name == gadget.Name)
                    {
                        // remove gadget  
                        // update gadget list    
                    }
                }
            }
        }

        public UserControl LoadGadget(string GadgetName)
        {
            const string gNamespace = "EWAV";
            try
            {
                Add(GadgetName);

                //foreach (UserControl gadget in applicationViewModel.MefGetGadgets())
                //{
                //    IEWAVGadget uc = gadget as IEWAVGadget;
                //    if (uc.MyControlName == GadgetName)
                //    {
                //        gadget.Name = uc.MyControlName;
                //        return gadget;
                //    }
                //}

                if (GadgetName.ToLower().Contains("ewav."))
                {
                    Type gadgetType = Type.GetType(GadgetName);
                    return (UserControl)Activator.CreateInstance(gadgetType);
                }

                foreach (var item in applicationViewModel.ControlListWithMetaInfo)
                {
                    if (GadgetName.ToLower() == item.ControlName.ToString().ToLower())
                    {
                        string ctrlName = gNamespace + "." + item.ControlName.Replace(" ", "");
                        Type gadgetType = Type.GetType(ctrlName);
                        return (UserControl)Activator.CreateInstance(gadgetType);
                    }

                }


                //foreach (Lazy<UserControl, IMapMetaData> gadget in applicationViewModel.MefGetGadgets())
                //{
                //    UserControl gadgetU = (UserControl)gadget.Value;
                //    IEWAVGadget uc = gadgetU as IEWAVGadget;
                //    if (uc.MyControlName == GadgetName)
                //    {
                //        gadgetU.Name = uc.MyControlName;
                //        return gadgetU;
                //    }


                //}

                throw new Exception("Could not create gadget ");
            }
            catch (Exception e)
            {
                throw new Exception("Could not create gadget " + e.Message);
            }
            finally
            {
                //applicationViewModel.MefCleanup();

            }
        }

        //public List<string> GadgetListForMenu
        //{
        //    get
        //    {
        //        foreach (string mefGadget in applicationViewModel.MefEWAVContextMenuItems)
        //        {
        //            switch (mefGadget)
        //            {
        //                case "XYControl":
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        return new List<string>();
        //    }
        //}
        private void Add(string GadgetName)
        {
            //    string addGadget = GadgetName;

            try
            {
                //foreach (string gadgetName in applicationViewModel.MefAvailableGadgets)
                //{
                //    if (gadgetName == addGadget)
                //    {
                //        applicationViewModel.LoadedGadgets.Add(addGadget);
                //    }
                //}

                applicationViewModel.LoadedGadgets.Add(GadgetName);

            }
            catch (Exception e)
            {
                throw new Exception("Could not add gadget " + GadgetName + " -  " + e.Message);
            }
        }
    }
}