Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI

<ComClass(cmdControleSecteur.ClassId, cmdControleSecteur.InterfaceId, cmdControleSecteur.EventsId), _
 ProgId("stage.cmdControleSecteur")> _
Public NotInheritable Class cmdControleSecteur
    Inherits BaseCommand

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "5c605008-c6b9-414a-91d6-f577cb67397f"
    Public Const InterfaceId As String = "4b5a59af-79e8-4290-b4b2-1e30d570a1b3"
    Public Const EventsId As String = "a3b8a721-a972-4a27-9661-9aa345a3446b"
#End Region

#Region "COM Registration Function(s)"
    <ComRegisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub RegisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryRegistration(registerType)

        'Add any COM registration code after the ArcGISCategoryRegistration() call

    End Sub

    <ComUnregisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub UnregisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryUnregistration(registerType)

        'Add any COM unregistration code after the ArcGISCategoryUnregistration() call

    End Sub

#Region "ArcGIS Component Category Registrar generated code"
    Private Shared Sub ArcGISCategoryRegistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Register(regKey)

    End Sub
    Private Shared Sub ArcGISCategoryUnregistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Unregister(regKey)

    End Sub

#End Region
#End Region


    Private m_application As IApplication

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

     MyBase.m_category = "Controle_Tools"  'localizable text 
        MyBase.m_caption = "Controle secteur"   'localizable text 
        MyBase.m_message = "view layers  into arcmap"   'localizable text 
        MyBase.m_toolTip = "Controle " 'localizable text 
        MyBase.m_name = "Controle_Tools_ControleSecteur"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

        Try
            'TODO: change bitmap name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap")
        End Try


    End Sub


    Public Overrides Sub OnCreate(ByVal hook As Object)
        If Not hook Is Nothing Then
            m_application = CType(hook, IApplication)

            'Disable if it is not ArcMap
            If TypeOf hook Is IMxApplication Then
                MyBase.m_enabled = True
            Else
                MyBase.m_enabled = False
            End If
        End If

        ' TODO:  Add other initialization code
    End Sub

    Public Overrides Sub OnClick()
        'TODO: Add cmdControleSecteur.OnClick implementation
        Dim pControleSecteur As New frmControleSecteur
        pControleSecteur.ArcMapApplication = m_application
        Dim pArcMapApplication As New ArcMapwrapper
        pArcMapApplication.ArcMapapplication = m_application
        pControleSecteur.Show(pArcMapApplication)
        '  Dim pMxdoc As IMxDocument = m_application.Document
        ' Dim pmap As IMap = pMxdoc.FocusMap
        ' Dim pLayrs As ILayer = pmap.Layer(0)
        'pControleviewer.cmbLayers.Items.Add(pLayrs.Name)
        ' For i As Integer = 0 To pmap.LayerCount - 1
        'Dim pLayer As ILayer = pmap.Layer(i)
        'pControleviewer.cmbLayers.Items.Add(pLayer.Name)
        'Next


    End Sub
End Class



