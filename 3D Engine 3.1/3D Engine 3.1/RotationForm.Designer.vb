<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RotationForm
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
        Me.XBar = New System.Windows.Forms.TrackBar()
        Me.XText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.YText = New System.Windows.Forms.TextBox()
        Me.YBar = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ZText = New System.Windows.Forms.TextBox()
        Me.ZBar = New System.Windows.Forms.TrackBar()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ConfirmButton = New System.Windows.Forms.Button()
        CType(Me.XBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.YBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XBar
        '
        Me.XBar.Location = New System.Drawing.Point(110, 45)
        Me.XBar.Maximum = 5
        Me.XBar.Minimum = -5
        Me.XBar.Name = "XBar"
        Me.XBar.Size = New System.Drawing.Size(226, 45)
        Me.XBar.TabIndex = 0
        '
        'XText
        '
        Me.XText.Location = New System.Drawing.Point(13, 45)
        Me.XText.Name = "XText"
        Me.XText.Size = New System.Drawing.Size(76, 20)
        Me.XText.TabIndex = 1
        Me.XText.Text = "0"
        Me.XText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X Rotation (Degrees per refresh)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Y Rotation (Degrees per refresh)"
        '
        'YText
        '
        Me.YText.Location = New System.Drawing.Point(13, 108)
        Me.YText.Name = "YText"
        Me.YText.Size = New System.Drawing.Size(76, 20)
        Me.YText.TabIndex = 4
        Me.YText.Text = "0"
        Me.YText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'YBar
        '
        Me.YBar.Location = New System.Drawing.Point(110, 108)
        Me.YBar.Maximum = 5
        Me.YBar.Minimum = -5
        Me.YBar.Name = "YBar"
        Me.YBar.Size = New System.Drawing.Size(226, 45)
        Me.YBar.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(138, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Z Rotation (Degrees per refresh)"
        '
        'ZText
        '
        Me.ZText.Location = New System.Drawing.Point(13, 173)
        Me.ZText.Name = "ZText"
        Me.ZText.Size = New System.Drawing.Size(76, 20)
        Me.ZText.TabIndex = 7
        Me.ZText.Text = "0"
        Me.ZText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ZBar
        '
        Me.ZBar.Location = New System.Drawing.Point(110, 173)
        Me.ZBar.Maximum = 5
        Me.ZBar.Minimum = -5
        Me.ZBar.Name = "ZBar"
        Me.ZBar.Size = New System.Drawing.Size(226, 45)
        Me.ZBar.TabIndex = 6
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(211, 245)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 23)
        Me.ResetButton.TabIndex = 9
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(88, 245)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(75, 23)
        Me.ConfirmButton.TabIndex = 10
        Me.ConfirmButton.Text = "Confirm"
        Me.ConfirmButton.UseVisualStyleBackColor = True
        '
        'RotationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 302)
        Me.Controls.Add(Me.ConfirmButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ZText)
        Me.Controls.Add(Me.ZBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.YText)
        Me.Controls.Add(Me.YBar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.XText)
        Me.Controls.Add(Me.XBar)
        Me.Name = "RotationForm"
        Me.Text = "RotationForm"
        CType(Me.XBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.YBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XBar As System.Windows.Forms.TrackBar
    Friend WithEvents XText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YText As System.Windows.Forms.TextBox
    Friend WithEvents YBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ZText As System.Windows.Forms.TextBox
    Friend WithEvents ZBar As System.Windows.Forms.TrackBar
    Friend WithEvents ResetButton As System.Windows.Forms.Button
    Friend WithEvents ConfirmButton As System.Windows.Forms.Button
End Class
