Public Class Triangle

    Public Points As New List(Of Vec3D)
    Private ZMidPoint As Double
    Private LightLevel As Double
    Private Colour As Color
    Public Sub SetColour(inColour As Color)
        Colour = inColour
    End Sub
    Public Function GetColour()
        Return Colour
    End Function
    Public Function GetZMidPoint()
        Return ZMidPoint
    End Function
    Public Sub SetZMidPoint(z As Double)
        ZMidPoint = z
    End Sub
    Public Sub CalculateLightLevel(ParallelLight As ParallelLightSource)
        Dim cross As Vec3D = Vec3D.CrossProduct(Points(1) - Points(0), Points(2) - Points(1))
        cross.Normalise()
        Dim dot As Double = Vec3D.DotProduct(cross, ParallelLight.GetDirection)
        If dot < 0 Then
            LightLevel = -dot
        End If
        If dot > 0 Then
            LightLevel = 0
        End If
    End Sub
    Public Function GetLightLevel()
        Return LightLevel
    End Function
    Public Sub New()

    End Sub
    Public Sub SetLightLevel(inLightLevel As Double)
        LightLevel = inLightLevel
    End Sub
    Public Sub New(p1 As Vec3D, p2 As Vec3D, p3 As Vec3D, inLightLevel As Double)
        Points.Add(p1)
        Points.Add(p2)
        Points.Add(p3)
        LightLevel = inLightLevel
    End Sub
    Public Sub New(p1 As Vec3D, p2 As Vec3D, p3 As Vec3D)
        Points.Add(p1)
        Points.Add(p2)
        Points.Add(p3)
    End Sub
    Public Sub New(ps As List(Of Vec3D))
        For looper = 0 To ps.Count - 1
            Points.Add(ps(looper))
        Next


    End Sub
    Public Function ProjectTri()
        Dim NewPoints As New List(Of Vec3D)
        For looper = 0 To Points.Count - 1
            NewPoints.Add(Project(Points(looper)))

        Next

        Return NewPoints
    End Function
    Public Function cPoints()
        Dim NPoints As New List(Of PointF)
        Dim TempPoint As PointF
        Dim counter As Integer
        Do Until Points.Count = counter
            TempPoint.X = Points(counter).x
            TempPoint.Y = Points(counter).y
            counter += 1
            NPoints.Add(TempPoint)
            If counter > 3 Then
                '   If 1 <> 1 Then Dim a As String
            End If
        Loop
        Dim PointsArray(NPoints.Count - 1) As PointF

        PointsArray = NPoints.ToArray()
        For looper = 0 To NPoints.Count - 1
            PointsArray(looper).X += 1
            PointsArray(looper).X /= 2
            PointsArray(looper).X *= Form1.ClientSize.Width
            PointsArray(looper).Y += 1
            PointsArray(looper).Y /= 2
            PointsArray(looper).Y *= Form1.ClientSize.Height
            PointsArray(looper).Y = Form1.ClientSize.Height - PointsArray(looper).Y
            '  NPoints(looper).Y = Form1.ClientSize.Height - NPoints(looper).Y
            ' NPoints(looper).Y = Form1.ClientSize.Height - Points(looper).y
        Next

        Return PointsArray
    End Function
    Public Function DoesFaceCamera(Camera1 As Camera)
        Dim Vector1 As New Vec3D
        Dim Vector2 As New Vec3D
        Dim PerpendicularVector As New Vec3D
        Dim Dot As Double
        Dim VecToTriangle As Vec3D = (Points(0) - Camera1.GetPosition)
        VecToTriangle.Normalise()
        Vector1 = Points(0) - Points(1)
        Vector2 = Points(1) - Points(2)
        PerpendicularVector = Vec3D.CrossProduct(Vector1, Vector2)
        PerpendicularVector.Normalise()
        Dot = Vec3D.DotProduct(VecToTriangle, PerpendicularVector)
        If Dot <= 0 Then
            Return True
        End If
        Return False
    End Function
End Class
