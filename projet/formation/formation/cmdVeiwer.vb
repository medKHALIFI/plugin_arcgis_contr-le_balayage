Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

<ComClass(cmdVeiwer.ClassId, cmdVeiwer.InterfaceId, cmdVeiwer.EventsId), _
 ProgId("formation.cmdVeiwer")> _
Public NotInheritable Class cmdVeiwer
    Inherits BaseCommand

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "73a41485-a5a4-4b7a-ae02-8f931c91970d"
    Public Const InterfaceId As String = "a9c60782-adc8-4edb-92c4-a872eba9b312"
    Public Const EventsId As String = "cec1f736-25cb-45e4-9e64-d2af8e9c8ba3"
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

        ' TODO: Define values for the public properties
        MyBase.m_category = "formation_tools"  'localizable text 
        MyBase.m_caption = "formation viewer"   'localizable text 
        MyBase.m_message = "veiw Data into ArcMap"   'localizable text 
        MyBase.m_toolTip = "formaation viewer" 'localizable text 
        MyBase.m_name = "formation_tools_view_data "  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

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
        'TODO: Add cmdVeiwer.OnClick implementation
        Dim pformationViewer As New formationVeiwer
        pformationViewer.Show()
        'Iapplication -> IMxdocument ->IMap ->ILayer
        Dim pMxDoc As IMxDocument = m_application.Document
        Dim pMap As IMap = pMxDoc.FocusMap


        For i As Integer = 0 To pMap.LayerCount - 1
            Dim pLayer As ILayer = pMap.Layer(i)
            pformationViewer.cmbLayers.Items.Add(pLayer.Name)
        Next





    End Sub
End Class



