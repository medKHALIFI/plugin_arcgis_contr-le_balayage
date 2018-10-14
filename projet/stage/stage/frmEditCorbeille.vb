Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Framework

Public Class frmEditCorbeille
    Private m_application As IApplication

    Public Property ArcMapApplication() As IApplication
        Get
            Return m_application
        End Get
        Set(ByVal value As IApplication)
            m_application = value
        End Set
    End Property


    Private m_Corbeillelication As IPoint
    Public Property Corbeillelication() As IPoint
        Get
            Return m_Corbeillelication
        End Get
        Set(ByVal value As IPoint)
            m_Corbeillelication = value
        End Set
    End Property





    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        ' test si les champs bien remplie
        If textscteur.Text = "" Or textdistrict.Text = "" Then

            MsgBox("s'il vous plait entre des valeurs !!", MsgBoxStyle.Information, Title:="ERREUR")
            Return
        End If


        Dim pMXDoc As IMxDocument = m_application.Document
        Dim pPoint As IPoint = Corbeillelication 'pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
        Dim pX As Double
        Dim pY As Double
        Dim ptable As String
        pX = pPoint.X
        pY = pPoint.Y
        ptable = "X =" & pX & " Y = " & pY
        ' ptable = pY
        'ptable & "ID agent | " & pidagent & "| ID corbeille |" & pidcorbeille
        MsgBox(ptable, MsgBoxStyle.Information, Title:="position du point")

        Dim pflayer As IFeatureLayer = getLayerByName("Corbeille")
        Dim pFeatureclass As IFeatureClass = pflayer.FeatureClass
        Dim pdataset As IDataset = pFeatureclass
        Dim pWorkspace As IWorkspace = pdataset.Workspace
        Dim pworcspaceedit As IWorkspaceEdit = pWorkspace
        pworcspaceedit.StartEditing(True)
        pworcspaceedit.StartEditOperation()
        'do ypur editing 
        Dim pnewFeature As IFeature = pFeatureclass.CreateFeature()
        pnewFeature.Shape = pPoint
        pnewFeature.Value(pnewFeature.Fields.FindField("SECTEUR")) = textscteur.Text
        pnewFeature.Value(pnewFeature.Fields.FindField("DISTRICT")) = textdistrict.Text
        ' enregistre 

        pnewFeature.Store()


        'stop editing
        pworcspaceedit.StopEditOperation()
        pworcspaceedit.StopEditing(True)

        pMXDoc.ActiveView.Refresh()
        ' no do anymore thing
        Me.Close()


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

    Private Sub frmEditCorbeille_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        ZoomToDomainExtent()

    End Sub
    Public Sub ZoomToDomainExtent()
        Dim pMxDoc As IMxDocument
        Dim pMap As IMap
        Dim pActiveView As IActiveView
        Dim pContentsView As IContentsView

        pMxDoc = m_application.Document
        pMap = pMxDoc.FocusMap
        pActiveView = pMap
        pContentsView = pMxDoc.CurrentContentsView

        Dim pLayer As ILayer
        Dim pDataSet As IDataset
        Dim pFeatureLayer As IFeatureLayer
        Dim pGeoDataset As IGeoDataset

        If Not TypeOf pContentsView.SelectedItem Is ILayer Then Exit Sub
        pLayer = pContentsView.SelectedItem
        pFeatureLayer = pLayer
        pGeoDataset = pFeatureLayer

        Dim pSpatialReference As ISpatialReference
        Dim pEnvelope As IEnvelope
        pSpatialReference = pGeoDataset.SpatialReference
        pEnvelope = New Envelope

        Dim dXmax As Double
        Dim dYmax As Double
        Dim dXmin As Double
        Dim dYmin As Double

        pSpatialReference.GetDomain(dXmin, dXmax, dYmin, dYmax)
        pEnvelope.XMax = dXmax
        pEnvelope.YMax = dYmax
        pEnvelope.XMin = dXmin
        pEnvelope.YMin = dYmin

        pActiveView.Extent = pEnvelope
        pActiveView.Refresh()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
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
        'D'im pArcMapApplication As New ArcMapwrapper
        'pArcMapApplication.ArcMapapplication = m_application
        'pAddCorbeille.Show(pArcMapApplication)
        ' MsgBox(pX)
        'MsgBox(pY)
        ' Dim pLayrs As ILayer = pmap.Layer(0)
        'pControleviewer.cmbLayers.Items.Add(pLayrs.Name)
        ' pAddCorbeille.cmbLayers.Items.Add()


        'pAddCorbeille.cmbXY.Items.Add(ptable)
        'p'AddCorbeille.xpoint.Text = ptable
        'pAddCorbeille.ypoint.Text = "  " & pY
    End Sub
End Class