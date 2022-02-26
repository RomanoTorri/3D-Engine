Public Class TranslateForm
    Private X As Double
    Private Y As Double
    Private Z As Double
    Private Index As Integer
    Public Sub SetIndex(ByVal Ind As Integer)
        Index = Ind
    End Sub

    Private Sub ConfirmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmButton.Click
        Form1.SetTranslationVector(New Vec3D(X, Y, Z), Index)
        Close()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XTextBox.TextChanged
        If IsNumeric(XTextBox.Text) Then
            X = XTextBox.Text
        End If
    End Sub
    Private Sub ZTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZTextBox.TextChanged
        If IsNumeric(ZTextBox.Text) Then
            Z = ZTextBox.Text
        End If
    End Sub
    Private Sub YTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YTextBox.TextChanged
        If IsNumeric(YTextBox.Text) Then
            Y = YTextBox.Text
        End If
    End Sub

    Private Sub RandomButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RandomButton.Click
        XTextBox.Text = Int(Rnd() * 20 - 10)
        YTextBox.Text = Int(Rnd() * 20 - 10)
        ZTextBox.Text = Int(Rnd() * 20 - 10)
    End Sub
End Class