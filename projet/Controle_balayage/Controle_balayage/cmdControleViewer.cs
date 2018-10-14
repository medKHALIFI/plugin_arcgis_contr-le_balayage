using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using Controle_balayage;
using System.Windows.Forms;
namespace Controle_balayage
{
    /// <summary>
    /// Summary description for cmdControleViewer.
    /// </summary>
    [Guid("48c9fddf-d597-4bcc-8aac-fbbc4088897e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Controle_balayage.cmdControleViewer")]
    public sealed class cmdControleViewer : BaseCommand
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
            MxCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IApplication m_application;
        public cmdControleViewer()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Controle_tools"; //localizable text
            base.m_caption = "Controle Viewer";  //localizable text
            base.m_message = "Controle Viewer into arcmap";  //localizable text 
            base.m_toolTip = "Controle Viewer";  //localizable text 
            base.m_name = "Controle_tools_ControleViewer";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            m_application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
                base.m_enabled = true;
            else
                base.m_enabled = false;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
           //  frmControleViewer pControleviewer = New frmControleViewer() ;
            FormControle_balayage pControleviewer = new FormControle_balayage() ;
              MessageBox.Show(" show controle de balayage ");
           //pControleviewer.ArcMapApplication = m_application
            
         //  Dim pArcMapApplication As New ArcMapwrapper
           //pArcMapApplication.ArcMapapplication = m_application
            // TODO: Add cmdControleViewer.OnClick implementation
         /*   FormControle_balayage pControle_balayage ;

            pControle_balayage.Show() ;
            IMxDocument pMxDoc = m_application.Document;
            IMap pmap = pMxDoc.FocusMap;
            ILayer player = pmap.Layer(0);
            pControle_balayage.cmbLayers.Items.Add(player.name);
            /*
             *  'TODO: Add cmdControleViewer.OnClick implementation
        Dim pControleviewer As New frmControleViewer

        pControleviewer.ArcMapApplication = m_application

        Dim pArcMapApplication As New ArcMapwrapper
        pArcMapApplication.ArcMapapplication = m_application


        pControleviewer.Show(pArcMapApplication)
        Dim pMxdoc As IMxDocument = m_application.Document
        Dim pmap As IMap = pMxdoc.FocusMap
        ' Dim pLayrs As ILayer = pmap.Layer(0)
        'pControleviewer.cmbLayers.Items.Add(pLayrs.Name)
        For i As Integer = 0 To pmap.LayerCount - 1
            Dim pLayer As ILayer = pmap.Layer(i)
            pControleviewer.cmbLayers.Items.Add(pLayer.Name)
        Next
*/
        }

        #endregion
    }
}
