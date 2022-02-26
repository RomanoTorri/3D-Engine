Public Class InputController
    Public EscKey As Boolean
    Public AKey As Boolean
    Public SKey As Boolean
    Public DKey As Boolean
    Public WKey As Boolean
    Public qKey As Boolean
    Public eKey As Boolean
    Public SpaceKey As Boolean
    Public CKey As Boolean
    Public OneKey As Boolean
    Public TheMousePosition As PointF

    Public Sub DoKeys(ByVal Camera1 As Camera, ByVal World1 As World)
        Dim NewVec As New Vec3D
        If EscKey Then

           
        End If
        If WKey Then
            NewVec = New Vec3D(Camera1.GetDirection.x * 0.1, 0, Camera1.GetDirection.z * 0.1)
            NewVec.Normalise()
            Camera1.AddPosition(NewVec / 2)
        End If
        If SKey Then
            NewVec = (New Vec3D(Camera1.GetDirection.x * -0.1, 0, Camera1.GetDirection.z * -0.1))
            NewVec.Normalise()
            Camera1.AddPosition(NewVec / 2)
        End If
        If AKey Then
            NewVec = New Vec3D(Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).x * -0.1, Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).y * -0.1, Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).z * -0.1)
            NewVec.y = 0
            NewVec.Normalise()
            Camera1.AddPosition(NewVec / 2)
        End If
        If DKey Then
            NewVec = New Vec3D(Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).x * 0.1, Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).y * 0.1, Vec3D.CrossProduct(New Vec3D(0, 1, 0), Camera1.GetDirection).z * 0.1)
            NewVec.y = 0
            NewVec.Normalise()
            Camera1.AddPosition(NewVec / 2)
        End If
        If CKey Then
            Camera1.AddPosition(New Vec3D(0, -0.5, 0))
        End If

        If SpaceKey Then
            Camera1.AddPosition(New Vec3D(0, 0.5, 0))
        End If
        'If qKey Then
        '    Camera1.SetDirection(RotateAroundZAxis(-Math.PI / 36, Camera1.GetDirection))
        '    Camera1.SetUpDirection(RotateAroundZAxis(-Math.PI / 36, Camera1.GetUpDirection))
        'End If
        'If eKey Then
        '    Camera1.SetDirection(RotateAroundZAxis(Math.PI / 36, Camera1.GetDirection))
        '    Camera1.SetUpDirection(RotateAroundZAxis(Math.PI / 36, Camera1.GetUpDirection))
        'End If
        If Form1.MouseCentred = True Then
            If 1 < Math.Abs((Form1.Left + (Form1.Width / 2)) - TheMousePosition.X) Then
                ' MsgBox((Form1.Width / 2) - TheMousePosition.X)
                Dim mousex As Integer = Form1.Left + (Form1.Width / 2) - TheMousePosition.X
                Camera1.SetDirection(RotateAroundYAxis(-Math.PI * (mousex) / 1000, Camera1.GetDirection))
                Camera1.SetUpDirection(RotateAroundYAxis(-Math.PI * (mousex) / 1000, Camera1.GetUpDirection))
            End If
            If 1 < Math.Abs((Form1.Top + (Form1.Height / 2)) - TheMousePosition.Y) Then
                '  MsgBox(Form1.Height / 2 - TheMousePosition.Y)
                Dim Theta As Double = -Math.Atan(Camera1.GetDirection.x / Camera1.GetDirection.z)
                Dim MouseY As Integer = (Form1.Top + (Form1.Height / 2)) - TheMousePosition.Y
                Dim NewPoint As Vec3D
                Camera1.SetDirection(RotateAroundYAxis(Theta, Camera1.GetDirection))
                Camera1.SetUpDirection(RotateAroundYAxis(Theta, Camera1.GetUpDirection))
                If Camera1.GetDirection.z < 0 Then
                    NewPoint = RotateAroundXAxis(Math.PI * (MouseY) / 1000, Camera1.GetDirection)
                    If NewPoint.z < 0 Then
                        Camera1.SetDirection(NewPoint)
                        Camera1.SetUpDirection(RotateAroundXAxis(Math.PI * (MouseY) / 1000, Camera1.GetUpDirection))
                    End If
                Else
                    NewPoint = RotateAroundXAxis(-Math.PI * (MouseY) / 1000, Camera1.GetDirection)
                    If NewPoint.z > 0 Then
                        Camera1.SetDirection(NewPoint)
                        Camera1.SetUpDirection(RotateAroundXAxis(-Math.PI * (MouseY) / 1000, Camera1.GetUpDirection))
                    End If


                End If
                Camera1.SetUpDirection(RotateAroundYAxis(-Theta, Camera1.GetUpDirection))
                Camera1.SetDirection(RotateAroundYAxis(-Theta, Camera1.GetDirection))


                ' Camera1.SetUpDirection(RotateAroundXAxis(Math.PI * (Form1.Width / 2 - TheMousePosition.Y) / 100000, Camera1.GetUpDirection))
            End If
        End If
        
    End Sub
    Public Sub New()

    End Sub
End Class
