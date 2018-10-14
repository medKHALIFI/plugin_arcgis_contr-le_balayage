<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formationVeiwer
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
        Me.cmbLayers = New System.Windows.Forms.ComboBox()
        Me.cmdagenda = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'cmbLayers
        '
        Me.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbLayers.FormattingEnabled = True
        Me.cmbLayers.Location = New System.Drawing.Point(113, 36)
        Me.cmbLayers.Name = "cmbLayers"
        Me.cmbLayers.Size = New System.Drawing.Size(121, 21)
        Me.cmbLayers.TabIndex = 0
        '
        'cmdagenda
        '
        Me.cmdagenda.Location = New System.Drawing.Point(246, 36)
        Me.cmdagenda.Name = "cmdagenda"
        Me.cmdagenda.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Layers"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(283, 211)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "date celected"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(34, 108)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'formationVeiwer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 261)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdagenda)
        Me.Controls.Add(Me.cmbLayers)
        Me.Name = "formationVeiwer"
        Me.Text = "formationVeiwer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbLayers As System.Windows.Forms.ComboBox
    Friend WithEvents cmdagenda As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
