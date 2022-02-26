Public Class Camera
    Private Direction As Vec3D
    Private UpDirection As Vec3D
    Private Position As Vec3D
    Public Sub New()
        Direction = New Vec3D(0, 0, -1)
        UpDirection = New Vec3D(0, 1, 0)
        Direction.Normalise()
        Position = New Vec3D(0, 0, 3)
    End Sub
    Public Sub AddPosition(v As Vec3D)
        Position += v
    End Sub
    Public Sub SetUpDirection(v As Vec3D)
        UpDirection = v
    End Sub
    Function GetUpDirection()
        Return UpDirection
    End Function
    Public Sub SetDirection(v As Vec3D)
        Direction = v
    End Sub
    Function GetDirection()
        Return Direction
    End Function
    Function GetPosition()
        Return Position
    End Function
End Class
