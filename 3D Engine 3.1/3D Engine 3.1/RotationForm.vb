Public Class RotationForm
    Dim XRotate As Double
    Dim YRotate As Double
    Dim ZRotate As Double
    Private Index As Integer
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub XText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XText.TextChanged
        If IsNumeric(XText.Text) Then
            If XText.Text < 0.005 And XText.Text > -30 Then
                XBar.Value = XText.Text
                XRotate = XText.Text * 0.0001
            Else
                ' XText.Text = 0
            End If
        Else
            XText.Text = 0
        End If
    End Sub

    Private Sub YText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YText.TextChanged
        If IsNumeric(YText.Text) Then
            If YText.Text < 0.005 And YText.Text > -0.005 Then
                YBar.Value = YText.Text
                YRotate = YText.Text * 0.0001
            Else
                'YText.Text = 0
            End If
        Else
            YText.Text = 0
        End If
    End Sub

    Private Sub ZText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZText.TextChanged
        If IsNumeric(ZText.Text) Then
            If ZText.Text < 0.005 And ZText.Text > -0.005 Then
                ZBar.Value = ZText.Text
                ZRotate = ZText.Text * 0.0001
            Else
                ' ZText.Text = 0
            End If
        Else
            ZText.Text = 0
        End If
    End Sub

    Private Sub XBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XBar.Scroll
        XText.Text = XBar.Value
        XRotate = XBar.Value * 0.0001
    End Sub

    Private Sub YBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YBar.Scroll
        YText.Text = YBar.Value
        YRotate = YBar.Value * 0.0001
    End Sub

    Private Sub ZBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZBar.Scroll
        ZText.Text = ZBar.Value
        ZRotate = ZBar.Value * 0.0001
    End Sub
    Public Sub SetMeshIndex(ByVal inMeshIndex As Integer)
        Index = inMeshIndex
    End Sub
    Private Sub ConfirmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmButton.Click
        Form1.SetRotationVector(New Vec3D(XRotate, YRotate, ZRotate), Index)
        Me.Close()
    End Sub

    Private Sub ResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetButton.Click
        XBar.Value = 0
        YBar.Value = 0
        ZBar.Value = 0
        XText.Text = 0
        YText.Text = 0
        ZText.Text = 0
        XRotate = 0
        YRotate = 0
        ZRotate = 0
    End Sub
End Class