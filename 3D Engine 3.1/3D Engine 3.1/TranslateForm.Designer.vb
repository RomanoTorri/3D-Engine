<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TranslateForm
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
        Me.XTextBox = New System.Windows.Forms.TextBox()
        Me.YTextBox = New System.Windows.Forms.TextBox()
        Me.ZTextBox = New System.Windows.Forms.TextBox()
        Me.XLabel = New System.Windows.Forms.Label()
        Me.YLabel = New System.Windows.Forms.Label()
        Me.ZLabel = New System.Windows.Forms.Label()
        Me.ConfirmButton = New System.Windows.Forms.Button()
        Me.RandomButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'XTextBox
        '
        Me.XTextBox.Location = New System.Drawing.Point(137, 49)
        Me.XTextBox.Name = "XTextBox"
        Me.XTextBox.Size = New System.Drawing.Size(100, 20)
        Me.XTextBox.TabIndex = 0
        '
        'YTextBox
        '
        Me.YTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.YTextBox.Location = New System.Drawing.Point(137, 103)
        Me.YTextBox.Name = "YTextBox"
        Me.YTextBox.Size = New System.Drawing.Size(100, 20)
        Me.YTextBox.TabIndex = 1
        '
        'ZTextBox
        '
        Me.ZTextBox.Location = New System.Drawing.Point(137, 161)
        Me.ZTextBox.Name = "ZTextBox"
        Me.ZTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ZTextBox.TabIndex = 2
        '
        'XLabel
        '
        Me.XLabel.AutoSize = True
        Me.XLabel.Location = New System.Drawing.Point(165, 33)
        Me.XLabel.Name = "XLabel"
        Me.XLabel.Size = New System.Drawing.Size(45, 13)
        Me.XLabel.TabIndex = 3
        Me.XLabel.Text = "X Coord"
        '
        'YLabel
        '
        Me.YLabel.AutoSize = True
        Me.YLabel.Location = New System.Drawing.Point(165, 87)
        Me.YLabel.Name = "YLabel"
        Me.YLabel.Size = New System.Drawing.Size(45, 13)
        Me.YLabel.TabIndex = 4
        Me.YLabel.Text = "Y Coord"
        '
        'ZLabel
        '
        Me.ZLabel.AutoSize = True
        Me.ZLabel.Location = New System.Drawing.Point(165, 145)
        Me.ZLabel.Name = "ZLabel"
        Me.ZLabel.Size = New System.Drawing.Size(45, 13)
        Me.ZLabel.TabIndex = 5
        Me.ZLabel.Text = "Z Coord"
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(94, 233)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(75, 23)
        Me.ConfirmButton.TabIndex = 12
        Me.ConfirmButton.Text = "Confirm"
        Me.ConfirmButton.UseVisualStyleBackColor = True
        '
        'RandomButton
        '
        Me.RandomButton.Location = New System.Drawing.Point(217, 233)
        Me.RandomButton.Name = "RandomButton"
        Me.RandomButton.Size = New System.Drawing.Size(75, 23)
        Me.RandomButton.TabIndex = 11
        Me.RandomButton.Text = "Randomise"
        Me.RandomButton.UseVisualStyleBackColor = True
        '
        'TranslateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 302)
        Me.Controls.Add(Me.ConfirmButton)
        Me.Controls.Add(Me.RandomButton)
        Me.Controls.Add(Me.ZLabel)
        Me.Controls.Add(Me.YLabel)
        Me.Controls.Add(Me.XLabel)
        Me.Controls.Add(Me.ZTextBox)
        Me.Controls.Add(Me.YTextBox)
        Me.Controls.Add(Me.XTextBox)
        Me.Name = "TranslateForm"
        Me.Text = "TranslateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ZTextBox As System.Windows.Forms.TextBox
    Friend WithEvents XLabel As System.Windows.Forms.Label
    Friend WithEvents YLabel As System.Windows.Forms.Label
    Friend WithEvents ZLabel As System.Windows.Forms.Label
    Friend WithEvents ConfirmButton As System.Windows.Forms.Button
    Friend WithEvents RandomButton As System.Windows.Forms.Button
End Class
