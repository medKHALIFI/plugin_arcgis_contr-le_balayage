Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.DataSourcesGDB

<ComClass(cmdLoadDAta.ClassId, cmdLoadDAta.InterfaceId, cmdLoadDAta.EventsId), _
 ProgId("stage.cmdLoadDAta")> _
Public NotInheritable Class cmdLoadDAta
    Inherits BaseCommand

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "5e69f109-b9d6-444b-aed8-ff86ad6c3d2a"
    Public Const InterfaceId As String = "a23b75ce-08ea-402e-857c-593b888d10ed"
    Public Const EventsId As String = "b58a3c01-53d5-4288-996f-a0aaefca114e"
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
        MyBase.m_category = "Controle_Tools"  'localizable text 
        MyBase.m_caption = "load data"   'localizable text 
        MyBase.m_message = "load data into arcmap"   'localizable text 
        MyBase.m_toolTip = "load data" 'localizable text 
        MyBase.m_name = "Controle_Tools_load_data"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

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


    Public Function FileGdbWorkspaceFromPropertySet(ByVal database As String) As IWorkspace

        Dim propertySet As IPropertySet = New PropertySetClass()

        propertySet.SetProperty("DATABASE", database)
        Dim workspaceFactory As IWorkspaceFactory = New FileGDBWorkspaceFactoryClass()
        Return workspaceFactory.Open(propertySet, 0)

    End Function
    Public Overrides Sub OnClick()
        'TODO: Add cmdLoadDAta.OnClick implementation
        MsgBox(" Controle de balayage")

        m_application.Caption = " controle de balayage "
        ' code geodatabase
        ' Dim pselectedlayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        ' Dim pfeaturLayer As IFeatureLayer = pselectedlayer
        ' Dim pFeatureClass As IFeatureClass = pfeaturLayer.FeatureClass
        'Dim pFeaturecursor As IFeatureCursor = pFeatureClass.Search(Nothing, False)
        'Dim pDataset As IDataset = pFeatureClass
        'Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        'Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        ' Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        ' Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        ' Dim pQfilter As IQueryFilter = New QueryFilter
        'MsgBox(" resultat 0 jhb")
        'pQfilter.WhereClause = "DateCCorbeille = date '2017-03-02 00:00:00' "
        'Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        'Dim Prow As IRow = pCursor.NextRow
        'Dim pRaitng As Double = 0
        'Dim ptotalRaiting As Integer = 0
        'MsgBox(" resultat 1 jhb")
        'pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
        'MsgBox("id agent " & pRaitng)
        'pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        ' MsgBox("id corbeille" & pRaitng)
        ' Prow = pCursor.NextRow
        'pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("OBJECTID"))
        'MsgBox(pRaitng)
        'Do Until Prow Is Nothing
        'ptotalRaiting = ptotalRaiting + 1
        'MsgBox(" resultat 2 ")
        'Prow = pCursor.NextRow
        'pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("OBJECTID"))
        'Prow = pCursor.NextRow
        'MsgBox(pRaitng)
        'MsgBox(" resultat 3")

        'Loop
        'MsgBox(" resultat 4")
        'Dim Iavrarraitingas As Double
        'cmbObjets.Items.Clear()
        'If ptotalRaiting > 0 Then

        'Iavrarraitingas = pRaitng / ptotalRaiting
        '   cmbObjets.Items.Add(Iavrarraitingas)

        ' End If




    End Sub
End Class



