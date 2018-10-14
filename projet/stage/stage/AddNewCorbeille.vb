Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

<ComClass(AddNewCorbeille.ClassId, AddNewCorbeille.InterfaceId, AddNewCorbeille.EventsId), _
 ProgId("stage.AddNewCorbeille")> _
Public NotInheritable Class AddNewCorbeille
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "cacc0de7-0e4a-4961-b2df-43361bbf50ef"
    Public Const InterfaceId As String = "518571f3-d8a9-437f-b456-dd0b69aa43bd"
    Public Const EventsId As String = "2abb627f-c9e8-4708-be88-66437021590b"
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


    Private m_Corbeillelication As IPoint
    Public Property Corbeillelication() As IPoint
        Get
            Return m_Corbeillelication
        End Get
        Set(ByVal value As IPoint)
            m_Corbeillelication = value
        End Set
    End Property

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "Controle_Tools"  'localizable text 
        MyBase.m_caption = "ajouter nouveau corbeille"   'localizable text 
        MyBase.m_message = "cliquer dans la carte pour ajouter des corbeilles"   'localizable text 
        MyBase.m_toolTip = "ajouter corbeille" 'localizable text 
        MyBase.m_name = "Controle_Tools_Ajouter_Corbeille"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

        Try
            'TODO: change resource name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
            MyBase.m_cursor = New System.Windows.Forms.Cursor(Me.GetType(), Me.GetType().Name + ".cur")
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
        'TODO: Add AddNewCorbeille.OnClick implementation

        'Dim pMXDoc As IMxDocument = m_application.Document
        Dim pPoint As IPoint = Corbeillelication 'pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
        Dim pX As Double
        Dim pY As Double
        Dim ptable As String
        Dim pMxdoc As IMxDocument = m_application.Document
        Dim pmap As IMap = pMxdoc.FocusMap
        
        ' ptable = "X =" & pX & " Y = " & pY
        Dim pAddCorbeille As New frmEditCorbeille
        pAddCorbeille.ArcMapApplication = m_application
        Dim pArcMapApplication As New ArcMapwrapper
        pArcMapApplication.ArcMapapplication = m_application
        '' pAddCorbeille.Show(pArcMapApplication)
        ' MsgBox(pX)
        'MsgBox(pY)
        ' Dim pLayrs As ILayer = pmap.Layer(0)
        'pControleviewer.cmbLayers.Items.Add(pLayrs.Name)
        ' pAddCorbeille.cmbLayers.Items.Add()
        'pX = pPoint.X
        'pY = pPoint.Y
        'pAddCorbeille.xpoint.Text = "  " & pX
        ' pAddCorbeille.ypoint.Text = "  " & pY


    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewCorbeille.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewCorbeille.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewCorbeille.OnMouseUp implementation
        Dim pmxdoc As IMxDocument = m_application.Document
        Dim pCorbeilleLocation As IPoint = pmxdoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
        Dim peditcorbeille As New frmEditCorbeille
        Dim parcmapapplication As New ArcMapwrapper
        parcmapapplication.ArcMapapplication = m_application
        peditcorbeille.ArcMapApplication = m_application
        peditcorbeille.Corbeillelication = pCorbeilleLocation


        peditcorbeille.Show(parcmapapplication)


    End Sub
   
End Class

