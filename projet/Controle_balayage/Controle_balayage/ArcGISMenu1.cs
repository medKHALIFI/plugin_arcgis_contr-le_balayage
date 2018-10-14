using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace Controle_balayage
{
    /// <summary>
    /// Summary description for ArcGISMenu1.
    /// </summary>
    [Guid("d372e7be-77d4-40ac-8fcc-2ef9155f1718")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Controle_balayage.ArcGISMenu1")]
    public sealed class ArcGISMenu1 : BaseMenu
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        public ArcGISMenu1()
        {
            AddItem("Controle_balayage.cmdloaddata");
          //  AddItem("Controle_balayage.cmdControleViewer");
            //
            // TODO: Define your menu here by adding items
            //
            //AddItem("esriArcMapUI.ZoomInFixedCommand");
            //BeginGroup(); //Separator
            //AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1); //undo command
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "My C# Menu";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "ArcGISMenu1";
            }
        }
    }
}