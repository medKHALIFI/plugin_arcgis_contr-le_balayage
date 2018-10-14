Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.DataSourcesGDB

Public Class frmControleViewer
    Dim date_debut As Date
    Dim date_fine As Date

    Private m_application As IApplication
    Public Property ArcMapApplication() As IApplication
        Get
            Return m_application
        End Get
        Set(ByVal value As IApplication)
            m_application = value

        End Set
    End Property



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayers.SelectedIndexChanged
        Dim pselectedlayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pfeaturLayer As IFeatureLayer = pselectedlayer
        Dim pFeatureClass As IFeatureClass = pfeaturLayer.FeatureClass
        Dim pFeaturecursor As IFeatureCursor = pFeatureClass.Search(Nothing, False)
        Dim pDataset As IDataset = pFeatureClass
        Dim pWorkspace As IWorkspace = pDataset.Workspace

        ' Dim pfeature As IFeature
        '   pfeature = pFeaturecursor.NextFeature
        '  cmbObjets.Items.Clear()
        ' Do Until pfeature Is Nothing

        '        cmbObjets.Items.Add(pfeature.OID)
        '       pfeature = pFeaturecursor.NextFeature
        '       Loop

        If cmbLayers.SelectedItem.ToString = "Corbeille" Or cmbLayers.SelectedItem.ToString = "Secteur" Then
            populatObjet(pFeaturecursor)

        End If
       
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdHide.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        pSelectedLayer.Visible = False

        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        pSelectedLayer.Visible = True

        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Function getLayerByName(sLayerName As String) As ILayer
        Try
            Dim pMxdoc As IMxDocument = m_application.Document
            Dim pMap As IMap = pMxdoc.FocusMap
            For i As Integer = 0 To pMap.LayerCount - 1
                Dim pLayer As ILayer = pMap.Layer(i)
                If pLayer.Name = sLayerName Then
                    Return pLayer
                End If

            Next
            Return Nothing
        Catch ec As Exception
            MsgBox(ec.ToString)
        End Try

    End Function

    Private Function getselected(id As Integer) As ILayer
        Dim pflayers As IFeatureLayer = getLayerByName("Corbeille")
        Dim pfeaturclass As IFeatureClass = pflayers.FeatureClass
        Dim pfeatur As IFeature = pfeaturclass.GetFeature(id)
        Dim pMxDoc As IMxDocument = m_application.Document
        Dim pmap As IMap = pMxDoc.FocusMap
        ' supprimer les objets deja selectionner
        ' pmap.ClearSelection()
        pmap.SelectFeature(pflayers, pfeatur)
        ' rfreche
        pMxDoc.ActivatedView.Refresh()

    End Function

    Private Sub frmControleViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles sect4.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 4"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub
    Private Sub setdefinitionQuery(Categorycode As Integer)
        MsgBox(Categorycode)
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID =" & Categorycode
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
        ' MsgBox("erreuur slected")
    End Sub


    Private Sub sect1_Click(sender As Object, e As EventArgs) Handles sect1.Click

        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 1"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

        'setdefinitionQuery(1)
        ' Dim pselectedlayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        'Dim pfeaturLayer As IFeatureLayer = pselectedlayer
        'Dim pFeatureClass As IFeatureClass = pfeaturLayer.FeatureClass
        'Dim pQfilter As IQueryFilter = New QueryFilter
        'pQfilter.WhereClause = "[OBJECTID] = 1"
        'Dim pFeaturecursor As IFeatureCursor = pFeatureClass.Search(pQfilter, False)
        'populatObjet(pFeaturecursor)
    End Sub
    Private Sub populatObjet(pfcursor As IFeatureCursor)
        Dim pname As String
        Dim pfeature As IFeature
        Dim index As Integer

        pfeature = pfcursor.NextFeature
        cmbObjets.Items.Clear()
        Do Until pfeature Is Nothing

            index = pfeature.Fields.FindField("OBJECTID")
            pname = pfeature.Value(index)
            cmbObjets.Items.Add(pname)
            pfeature = pfcursor.NextFeature
        Loop

    End Sub



    Private Sub sect2_Click(sender As Object, e As EventArgs) Handles sect2.Click
        '  setdefinitionQuery(2)
        ' Dim pselectedlayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        ' Dim pfeaturLayer As IFeatureLayer = pselectedlayer
        ' Dim pFeatureClass As IFeatureClass = pfeaturLayer.FeatureClass
        ' Dim pQfilter As IQueryFilter = New QueryFilter
        ' pQfilter.WhereClause = "[OBJECTID] = 2"
        'Dim pFeaturecursor As IFeatureCursor = pFeatureClass.Search(pQfilter, False)
        'populatObjet(pFeaturecursor)
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 2"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub sect3_Click(sender As Object, e As EventArgs) Handles sect3.Click
        'setdefinitionQuery(3)
        ' Dim pselectedlayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        'Dim pfeaturLayer As IFeatureLayer = pselectedlayer
        'Dim pFeatureClass As IFeatureClass = pfeaturLayer.FeatureClass
        'Dim pQfilter As IQueryFilter = New QueryFilter
        'pQfilter.WhereClause = "OBJECTID = 3"
        'Dim pFeaturecursor As IFeatureCursor = pFeatureClass.Search(pQfilter, False)
        'populatObjet(pFeaturecursor)
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 3"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub sect5_Click(sender As Object, e As EventArgs) Handles sect5.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 5"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub sect6_Click(sender As Object, e As EventArgs) Handles sect6.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 6"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub sect7_Click(sender As Object, e As EventArgs) Handles sect7.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 7"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub sect8_Click(sender As Object, e As EventArgs) Handles sect8.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 8"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles tous.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = ""
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles corbeillesect1.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 01'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles corbeillesect2.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 02'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect3_Click(sender As Object, e As EventArgs) Handles corbeillesect3.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 03'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect4_Click(sender As Object, e As EventArgs) Handles corbeillesect4.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 04'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect5_Click(sender As Object, e As EventArgs) Handles corbeillesect5.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 05'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect6_Click(sender As Object, e As EventArgs) Handles corbeillesect6.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 06'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect7_Click(sender As Object, e As EventArgs) Handles corbeillesect7.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 07'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect8_Click(sender As Object, e As EventArgs) Handles corbeillesect8.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 08'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub touscorbeille_Click(sender As Object, e As EventArgs) Handles touscorbeille.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = ""
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub cmbObjets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbObjets.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "[lavage] =1"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub Button2_Click_3(sender As Object, e As EventArgs)
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "[position_] =0"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub
    Public Function FileGdbWorkspaceFromPropertySet(ByVal database As String) As IWorkspace

        Dim propertySet As IPropertySet = New PropertySetClass()

        propertySet.SetProperty("DATABASE", database)
        Dim workspaceFactory As IWorkspaceFactory = New FileGDBWorkspaceFactoryClass()
        Return workspaceFactory.Open(propertySet, 0)

    End Function
    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        MsgBox(" resultat 0 jhb")
        pQfilter.WhereClause = " " 'DateCCorbeille = date '2017-03-02 00:00:00'
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pRaitng As Double = 0
        Dim ptotalRaiting As Integer = 0
        MsgBox(" resultat 1 jhb")
        pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
        MsgBox("id agent " & pRaitng)
        pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        MsgBox("id corbeille" & pRaitng)
        ' Prow = pCursor.NextRow
        'pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("OBJECTID"))
        'MsgBox(pRaitng)
        Do Until Prow Is Nothing
            ptotalRaiting = ptotalRaiting + 1
            MsgBox(" resultat 2 ")
            Prow = pCursor.NextRow
            pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("IDagent"))
            Prow = pCursor.NextRow
            MsgBox(pRaitng)
            MsgBox(" resultat 3")

        Loop
        MsgBox(" resultat 4")
        Dim Iavrarraitingas As Double
        'cmbObjets.Items.Clear()
        If ptotalRaiting > 0 Then

            Iavrarraitingas = pRaitng / ptotalRaiting
            '   cmbObjets.Items.Add(Iavrarraitingas)

        End If




    End Sub
    ' For example, database = "C:\myData\myfGDB.gdb".


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cmbdate.Items.Clear()
        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        MsgBox(" chargement des dates", MsgBoxStyle.Information, Title:="date ")
        pQfilter.WhereClause = "" 'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        ' Dim pdate As String

        ' MsgBox(" resultat 1 jhb")
        ' pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
        ' MsgBox("id agent " & pRaitng)

        ' MsgBox("date " & Prow.Value(Prow.Fields.FindField("DateCCorbeille")))

        'pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        '  MsgBox("id corbeille" & pRaitng)

        ' cmbdate.Items.Add(Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString)
        ' Prow = pCursor.NextRow
        'pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("OBJECTID"))
        'MsgBox(pRaitng)
        Do Until Prow Is Nothing
            ' ptotalRaiting = ptotalRaiting + 1
            'MsgBox(" resultat 2 ")
            'Prow = pCursor.NextRow
            'pRaitng = pRaitng + Prow.Value(Prow.Fields.FindField("OBJECTID"))
            'pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
            'MsgBox("id agent " & pRaitng)

            'MsgBox("date " &)

            ' pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            ' MsgBox("id corbeille" & pRaitng)




            'MsgBox(" next step")
            cmbdate.Items.Add(Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString)
            Prow = pCursor.NextRow
        Loop



        '' MsgBox(" en fin ")
        ' pControleviewer.ComboBox1.Items.Add(pLayer.Name) 
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbdate.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        '  Dim pidagent As Integer = 0
        '    Dim pidcorbeille As Integer = 0
        '   Dim pNom As String = ""
        '     Dim pposition As Integer = 0
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        ' pQfilter.WhereClause = "DateCCorbeille = date '2016-11-10 00:00:00'" '& cmbdate.SelectedItem.ToString() & " ' AND position = '1'" '& cmbdate.SelectedItem.ToString() &= date '2017-03-02 00:00:00' "
        ' Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        '      ' Dim Prow As IRow = pCursor.NextRow
        '       Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        '        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        'Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        'Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        ' Dim pQfilter As IQueryFilter = New QueryFilter
        'DateCCorbeille >= date '2014-03-02 00:00:00' AND DateCCorbeille <= date '2017-03-21 00:00:00'
        'pQfilter.WhereClause = "DateCCorbeille >= date '" & date_debut & "' AND DateCCorbeille <= date '" & date_fine & " ' AND position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        'Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)

        ' MsgBox("test " & pCursor.FindField("IDagent"))

        '        Dim Prow As IRow = pCursor.NextRow

        'MsgBox("date test  " & Prow.Fields.FindField("DateCCorbeille").ToString)
        'pidagent = Val(Prow.Value(Prow.Fields.FindField("IDagent")))
        '  MsgBox("l'identifiant " & Prow.Fields.FindField("IDagent"))
        'pidcorbeille = Val(Prow.Value(Prow.Fields.FindField("IDCorbeille")))

        'cherche le nom de l'agent  de cette corbeille
        'preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
        'pQfilter = New QueryFilter
        '   MsgBox(" chargement des dates")
        'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
        'pCursor = preveiwtable.Search(pQfilter, True)
        'Prow = pCursor.NextRow
        ' MsgBox(" resultat 1 jhb")
        'pNom = Prow.Value(Prow.Fields.FindField("Nom"))
        '" & cmbdate.SelectedItem.ToString() & vbNewLine &

        ' MsgBox(" resultat de recherche :" & vbNewLine & " id agent | " & pidagent & " | le nom | " & pNom & " | id corbeille  | " & pidcorbeille)

        '  MsgBox("la date selectionne  resultat de recherche  id agent  " & pidagent & " le nom " & pNom & "  id corbeille   " & pidcorbeille)
        '  pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
        ' MsgBox("id agent " & pRaitng)
        'MsgBox("date " & Prow.Value(Prow.Fields.FindField("DateCCorbeille")))
        'pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'MsgBox("id corbeille" & pRaitng)

        'MsgBox(" en fin ")

        'affichage de la corbeille selectionne dans la carte



        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = "DateCCorbeille >= date '" & date_debut & "' AND DateCCorbeille <= date '" & date_fine & " ' AND position = '1'" '" position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        ' pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            'getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        MsgBox(ptable)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
        '    'Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        '   Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        'Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        'Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        'Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        'pQfilter.WhereClause = "DateCCorbeille =date '" & cmbdate.SelectedItem.ToString() & "' AND lavage = 1 " '& cmbdate.SelectedItem.ToString() &= date '2017-03-02 00:00:00' "
        'Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        'Dim Prow As IRow = pCursor.NextRow
        'Dim pidagent As Integer = 0
        'Dim pidcorbeille As Integer = 0
        'Dim pNom As String = ""
        'Dim pposition As Integer = 0
        ' MsgBox("la position " & Prow.Fields.FindField("position"))
        'pidagent = Val(Prow.Fields.FindField("IDagent"))
        '  MsgBox("l'identifiant " & Prow.Fields.FindField("IDagent"))
        'pidcorbeille = Val(Prow.Fields.FindField("IDCorbeille"))


        ' MsgBox(" resultat de recherche  id agent  " & Prow.Fields.FindField("IDagent") & "  id corbeille   " & pidcorbeille)



        'cherche le nom de l'agent  de cette corbeille
        'preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
        'pQfilter = New QueryFilter
        '   MsgBox(" chargement des dates")
        'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
        'pCursor = preveiwtable.Search(pQfilter, True)
        'Prow = pCursor.NextRow
        ' MsgBox(" resultat 1 jhb")
        'pNom = Prow.Value(Prow.Fields.FindField("Nom"))



        'MsgBox("la date selectionne" & cmbdate.SelectedItem.ToString() & vbNewLine & " resultat de recherche  id agent  " & pidagent & " le nom " & pNom & "  id corbeille   " & pidcorbeille)
        '  pRaitng = Prow.Value(Prow.Fields.FindField("IDagent"))
        ' MsgBox("id agent " & pRaitng)
        'MsgBox("date " & Prow.Value(Prow.Fields.FindField("DateCCorbeille")))
        'pRaitng = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'MsgBox("id corbeille" & pRaitng)

        'MsgBox(" en fin ")



        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = "DateCCorbeille >= date '" & date_debut & "' AND DateCCorbeille <= date '" & date_fine & " ' AND lavage = 1" '" position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        ' pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            ' getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        MsgBox(ptable)

    End Sub

    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
        'pour recuper id de corbeille
        'Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        'Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        'Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        'Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        'Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '


        ' la requete qui va chercher le resultat
        'pQfilter.WhereClause = "DateCCorbeille = date '" & cmbdate.SelectedItem.ToString() & " ' AND position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        'Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        'Dim Prow As IRow = pCursor.NextRow
        'Dim pidagent As Integer = 0
        'Dim pidcorbeille As Integer = 0
        'Dim pNom As String = ""
        'Dim pposition As Integer = 0
        ' MsgBox("la position " & Prow.Fields.FindField("position"))
        'pidagent = Val(Prow.Value(Prow.Fields.FindField("IDagent")))
        '  MsgBox("l'identifiant " & Prow.Fields.FindField("IDagent"))
        'pidcorbeille = Val(Prow.Value(Prow.Fields.FindField("IDCorbeille")))
        ' Dim simo As sage
        'selectionne dans la carte 
        Dim pflayers As IFeatureLayer = getLayerByName("Corbeille")
        Dim pfeaturclass As IFeatureClass = pflayers.FeatureClass
        ' Dim pfeatur As IFeature = pfeaturclass.GetFeature(pidcorbeille)
        Dim pMxDoc As IMxDocument = m_application.Document
        Dim pmap As IMap = pMxDoc.FocusMap
        '' supprimer les objets deja selectionner
        pmap.ClearSelection()
        ' pmap.SelectFeature(pflayers, pfeatur)
        'rfreche()
        pMxDoc.ActivatedView.Refresh()

        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = "DateCCorbeille >= date '" & date_debut & "' AND DateCCorbeille <= date '" & date_fine & " ' AND position = '1'" '" position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        ' pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        ' MsgBox(ptable)

    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        'pour recuper id de corbeille
        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = " position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        MsgBox(ptable)

    End Sub

    Private Sub Button2_Click_4(sender As Object, e As EventArgs) Handles Button2.Click
        'pour recuper id de corbeille
        '  Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        ' Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        'Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        'Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        'Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        'pQfilter.WhereClause = "DateCCorbeille = date '" & cmbdate.SelectedItem.ToString() & " ' AND lavage= 1 "  'DateCCorbeille = date '2017-03-02 00:00:00' "
        'Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        'Dim Prow As IRow = pCursor.NextRow
        'Dim pidagent As Integer = 0
        'Dim pidcorbeille As Integer = 0
        'Dim pNom As String = ""
        'Dim pposition As Integer = 0
        ' MsgBox("la position " & Prow.Fields.FindField("position"))
        'pidagent = Val(Prow.Fields.FindField("IDagent"))
        '  MsgBox("l'identifiant " & Prow.Fields.FindField("IDagent"))
        'pidcorbeille = Val(Prow.Fields.FindField("IDCorbeille"))
        ' Dim simo As sage
        'selectionne dans la carte 
        Dim pflayers As IFeatureLayer = getLayerByName("Corbeille")
        Dim pfeaturclass As IFeatureClass = pflayers.FeatureClass
        ' Dim pfeatur As IFeature = pfeaturclass.GetFeature(pidcorbeille)
        Dim pMxDoc As IMxDocument = m_application.Document
        Dim pmap As IMap = pMxDoc.FocusMap
        ' supprimer les objets deja selectionner
        pmap.ClearSelection()
        'pmap.SelectFeature(pflayers, pfeatur)
        ' rfreche
        pMxDoc.ActivatedView.Refresh()


        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)



        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = "DateCCorbeille >= date '" & date_debut & "' AND DateCCorbeille <= date '" & date_fine & " ' AND lavage = 1" '" position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        ' pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        'MsgBox(ptable)



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'pour recuper id de corbeille
        Dim database As String = "C:\reussite\stage\amendis\base de donnee\VersionVB.gdb"
        Dim pWorkspace As IWorkspace = FileGdbWorkspaceFromPropertySet(database)


        Dim pfeatureWorkspace As IFeatureWorkspace = pWorkspace
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleCorbeille")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = " lavage = 1"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidcorbeille As Integer = 0
        Dim ptable As String = ""
        Dim pposition As Integer = 0
        Dim pNom As String = ""
        pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))

            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
            ptable = ptable & vbNewLine
            getselected(pidcorbeille)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        MsgBox(ptable)
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Dim debut As Date = CStr(Me.cmddatedebut.Value) 'CStr(Me.cmdDate.SelectionRange.Start)
        date_debut = debut
        MsgBox(debut, MsgBoxStyle.Information, Title:="date")

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim fine As Date = CStr(Me.cmddatefine.Value) 'CStr(Me.cmdDate.SelectionRange.Start)
        date_fine = fine
        MsgBox(fine, MsgBoxStyle.Information, Title:="date")
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class