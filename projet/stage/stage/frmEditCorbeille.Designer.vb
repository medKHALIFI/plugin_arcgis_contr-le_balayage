<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCorbeille
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.textscteur = New System.Windows.Forms.TextBox()
        Me.Secteur = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textdistrict = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(248, 130)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 22)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Sauvegarder"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'textscteur
        '
        Me.textscteur.BackColor = System.Drawing.SystemColors.MenuBar
        Me.textscteur.Location = New System.Drawing.Point(125, 52)
        Me.textscteur.Name = "textscteur"
        Me.textscteur.Size = New System.Drawing.Size(132, 20)
        Me.textscteur.TabIndex = 1
        '
        'Secteur
        '
        Me.Secteur.AutoSize = True
        Me.Secteur.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Secteur.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Secteur.Location = New System.Drawing.Point(54, 52)
        Me.Secteur.Name = "Secteur"
        Me.Secteur.Size = New System.Drawing.Size(44, 13)
        Me.Secteur.TabIndex = 2
        Me.Secteur.Text = "Secteur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label1.Location = New System.Drawing.Point(54, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "District"
        '
        'textdistrict
        '
        Me.textdistrict.BackColor = System.Drawing.SystemColors.MenuBar
        Me.textdistrict.Location = New System.Drawing.Point(125, 78)
        Me.textdistrict.Name = "textdistrict"
        Me.textdistrict.Size = New System.Drawing.Size(132, 20)
        Me.textdistrict.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label2.Location = New System.Drawing.Point(113, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Entrez les informations"
        '
        'frmEditCorbeille
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = Global.stage.My.Resources.Resources._31776586_blanc_image_de_fond_gris_afflig_ponge_grunge_vintage_texture_sch_ma_de_configuration_Banque_d_images
        Me.ClientSize = New System.Drawing.Size(346, 164)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textdistrict)
        Me.Controls.Add(Me.Secteur)
        Me.Controls.Add(Me.textscteur)
        Me.Controls.Add(Me.cmdSave)
        Me.Name = "frmEditCorbeille"
        Me.Text = "Ajouter une corbeille"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents textscteur As System.Windows.Forms.TextBox
    Friend WithEvents Secteur As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textdistrict As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
