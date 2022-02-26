Public Class ParallelLightSource
    Inherits LightSource
    Private Direction As Vec3D
    Sub New(inColour As Color, inIntensity As Double, inDirection As Vec3D)
        MyBase.New(inColour, inIntensity)
        SetDirection(inDirection)
    End Sub
    Public Sub SetDirection(inDirection As Vec3D)
        Direction = inDirection
        Direction.Normalise()
    End Sub
    Public Function GetDirection()
        Return Direction
    End Function

End Class
