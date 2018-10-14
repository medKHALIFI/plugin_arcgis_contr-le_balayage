Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports System.Runtime.InteropServices

<ComClass(ArcGISMenu1.ClassId, ArcGISMenu1.InterfaceId, ArcGISMenu1.EventsId), _
 ProgId("stage.ArcGISMenu1")> _
Public NotInheritable Class ArcGISMenu1
    Inherits BaseMenu

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
    ''' <summary>
    ''' Required method for ArcGIS Component Category registration -
    ''' Do not modify the contents of this method with the code editor.
    ''' </summary>
    Private Shared Sub ArcGISCategoryRegistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommandBars.Register(regKey)

    End Sub
    ''' <summary>
    ''' Required method for ArcGIS Component Category unregistration -
    ''' Do not modify the contents of this method with the code editor.
    ''' </summary>
    Private Shared Sub ArcGISCategoryUnregistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommandBars.Unregister(regKey)

    End Sub

#End Region
#End Region

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b1a93619-98c6-4d91-9306-6ef5eae28846"
    Public Const InterfaceId As String = "c7f6ddab-3a6d-4566-a18a-ab61a94cd00a"
    Public Const EventsId As String = "a474d377-6052-442d-a8ce-a7e1c63ad0f9"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        '
        'TODO: Define your menu here by adding items
        '
        'AddItem("esriArcMapUI.ZoomInFixedCommand")
        'BeginGroup() 'Separator
        'AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1) 'undo command
        'AddItem(New Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2) 'redo command
    End Sub

    Public Overrides ReadOnly Property Caption() As String
        Get
            'TODO: Replace bar caption
            Return "My VB.Net Menu"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            'TODO: Replace bar ID
            Return "ArcGISMenu1"
        End Get
    End Property
End Class


