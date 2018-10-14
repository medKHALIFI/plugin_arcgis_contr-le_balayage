Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Framework

Public Class frmControleSecteur
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

    Private Sub frmControleSecteur_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim debut As Date = CStr(Me.cmddatedebut.Value) ' CStr(Me.cmdDate.SelectionRange.Start)
        date_debut = debut
        MsgBox(debut)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim fine As Date = CStr(Me.cmddatefine.Value) 'CStr(Me.cmdDate.SelectionRange.Start)
        date_fine = fine
        MsgBox(fine)
    End Sub

    Public Function FileGdbWorkspaceFromPropertySet(ByVal database As String) As IWorkspace

        Dim propertySet As IPropertySet = New PropertySetClass()

        propertySet.SetProperty("DATABASE", database)
        Dim workspaceFactory As IWorkspaceFactory = New FileGDBWorkspaceFactoryClass()
        Return workspaceFactory.Open(propertySet, 0)

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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
    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
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

    Private Function getselected(id As Integer) As ILayer
        Dim pflayers As IFeatureLayer = getLayerByName("Secteur")
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim pflayers As IFeatureLayer = getLayerByName("Secteur")
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
        Dim preveiwtable As ITable = pfeatureWorkspace.OpenTable("ControleSecteur")
        Dim pQfilter As IQueryFilter = New QueryFilter
        ' MsgBox("la date selectione " & cmbdate.SelectedItem.ToString())
        ' DateCCorbeille = date '2017-03-30 00:00:00'
        '

        ' la requete qui va chercher le resultat
        pQfilter.WhereClause = "DateSecteur >= date '" & date_debut & "' AND DateSecteur <= date '" & date_fine & " ' AND CouvertureDEBalayage = 'Totale' "   '" position = '1'"  'DateCCorbeille = date '2017-03-02 00:00:00' "
        Dim pCursor As ICursor = preveiwtable.Search(pQfilter, True)
        Dim Prow As IRow = pCursor.NextRow
        Dim pidagent As Integer = 0
        Dim pidsecteur As Integer = 0
        Dim ptable As String = ""
        Dim couvertureDeBalayage As Integer = 0
        Dim pNom As String = ""
        ' pidcorbeille = Prow.Value(Prow.Fields.FindField("IDCorbeille"))
        'pidagent = Prow.Value(Prow.Fields.FindField("IDagent"))
        ptable = "resultat de la recherche " & vbNewLine
        Do Until Prow Is Nothing

            pidsecteur = Prow.Value(Prow.Fields.FindField("IDSecteur"))
            pidagent = Prow.Value(Prow.Fields.FindField("IDAgent"))
            couvertureDeBalayage = Prow.Value(Prow.Fields.FindField("CouvertureDEBalayage"))



            ' Prow.Value(Prow.Fields.FindField("DateCCorbeille")).ToString()
            'cherche le nom de l'agent  de cette corbeille
            ' preveiwtable = pfeatureWorkspace.OpenTable("AgentDeControle")
            'pQfilter = New QueryFilter
            '   MsgBox(" chargement des dates")
            'pQfilter.WhereClause = "OBJECTID  =" & pidagent  'DateCCorbeille = date '2017-03-02 00:00:00' "
            'pCursor = preveiwtable.Search(pQfilter, True)

            ' MsgBox(" resultat 1 jhb")

            ' pNom = Prow.Value(Prow.Fields.FindField("Nom"))
            ptable = ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidsecteur
            ptable = ptable & vbNewLine
            getselected(pidsecteur)
            Prow = pCursor.NextRow
        Loop
        ' MsgBox("erreur")
        MsgBox(ptable)

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

    Private Sub tous_Click(sender As Object, e As EventArgs) Handles tous.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = ""
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

    Private Sub sect2_Click(sender As Object, e As EventArgs) Handles sect2.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 2"
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

    Private Sub sect3_Click(sender As Object, e As EventArgs) Handles sect3.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 3"
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

    Private Sub sect4_Click(sender As Object, e As EventArgs) Handles sect4.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 4"
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

    Private Sub sect5_Click(sender As Object, e As EventArgs) Handles sect5.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 5"
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

    Private Sub sect6_Click(sender As Object, e As EventArgs) Handles sect6.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 6"
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

    Private Sub sect7_Click(sender As Object, e As EventArgs) Handles sect7.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 7"
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

    Private Sub sect8_Click(sender As Object, e As EventArgs) Handles sect8.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer

        pFLayerDef.DefinitionExpression = "OBJECTID = 8"
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

    Private Sub corbeillesect1_Click(sender As Object, e As EventArgs) Handles corbeillesect1.Click
        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = "SECTEUR LIKE 'Sect 01'"
        Dim pMxdoc As IMxDocument = m_application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActivatedView.Refresh()
    End Sub

    Private Sub corbeillesect2_Click(sender As Object, e As EventArgs) Handles corbeillesect2.Click
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
End Class