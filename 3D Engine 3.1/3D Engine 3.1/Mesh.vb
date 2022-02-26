Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Threading
Imports System.Threading.Tasks

Public Class Mesh
    Private RotationValues As New Vec3D
    Private Triangles As New List(Of Triangle)
    Private ProjectedTriangles As New List(Of Triangle)
    Private TranslatedTriangles As New List(Of Triangle)
    Private Vectors As New List(Of Vec3D)
    Private Colour As Color
    Private ColourNumber As Integer
    Private ZMidPoint As Double
    Private TranslationVector As New Vec3D
    Public Sub SetRotationValues(ByVal inVec As Vec3D)
        RotationValues = inVec
    End Sub
    Public Sub SetTranslationVector(ByVal invec As Vec3D)
        TranslationVector = invec
    End Sub
    Public Sub AddProjectedTriangle(inTriangle As Triangle)
        ProjectedTriangles.Add(inTriangle)

    End Sub
    Public Sub SetZMidPoint(z)
        ZMidPoint = z
    End Sub
    Public Function GetZMidPoint()
        Return ZMidPoint
    End Function
    Public Sub SetColour(InColour As Color)
        Colour = InColour

    End Sub
    Public Function GetColour()
        Return Colour
    End Function
    Public Sub New(File As String, inColour As Color)
        LoadMesh(File)
        Colour = inColour
    End Sub
    Public Sub New()

    End Sub
    Private Function MeanOfZ(Triangle)
        Dim Z As Double = 0
        For looper = 0 To Triangle.points.count - 1
            Z += Triangle.points(looper).z
        Next
        Return Z / Triangle.points.count
    End Function
    Public Sub SortProjectedTriangles()
        OrderTriangles(ProjectedTriangles)
    End Sub
    Private Sub OrderTriangles(TheTriangles As List(Of Triangle))
        For looper = 0 To TheTriangles.Count - 1
            TheTriangles(looper).SetZMidPoint(MeanOfZ(TheTriangles(looper)))
        Next
        If TheTriangles.Count - 1 > 1 Then
            QuickSortTriangles(TheTriangles, 0, TheTriangles.Count - 1)
        End If

        TheTriangles.Reverse()
    End Sub
    Public Sub RotateTriangles()
        For Each Tri In Triangles
            For looper = 0 To Tri.Points.Count - 1
                Tri.Points(looper) = RotateAroundXAxis(RotationValues.x * 180 / Math.PI, Tri.Points(looper))
                Tri.Points(looper) = RotateAroundYAxis(RotationValues.y * 180 / Math.PI, Tri.Points(looper))
                Tri.Points(looper) = RotateAroundZAxis(RotationValues.z * 180 / Math.PI, Tri.Points(looper))
            Next
        Next
    End Sub
    Private Sub LoadMesh(File As String)

        ' V.Add(New Vec3D(0, 0, 0))
        Dim TempString As String
        Dim SplitString() As String
        FileOpen(1, File, OpenMode.Input)
        Do Until EOF(1)
            TempString = LineInput(1)
            If TempString(0) = "v" Then
                SplitString = Split(TempString)
                Vectors.Add(New Vec3D(Val(SplitString(1)), Val(SplitString(2)), Val(SplitString(3))))

            End If
            If TempString(0) = "f" Then

                SplitString = (Split(TempString))
                Dim TempTriangle As New Triangle(Vectors(CInt(SplitString(1)) - 1), Vectors(CInt(SplitString(2)) - 1), Vectors(CInt(SplitString(3)) - 1))
                Triangles.Add(TempTriangle)
            End If
        Loop
        FileClose(1)

    End Sub
    'Public Sub TranslateTriangle()

    'End Sub
    'Public Sub TranslateTriangles()
    '    For looperout = 0 To Triangles.Count - 1
    '        For looper = 0 To Triangles(looperout).Points.Count - 1
    '            TranslatedTriangles(looperout).Points(looper) = RotateAroundXAxis(RotationValues.x * 180 / Math.PI, Triangles(looperout).Points(looper))
    '            TranslatedTriangles(looperout).Points(looper) = RotateAroundYAxis(RotationValues.y * 180 / Math.PI, Triangles(looperout).Points(looper))
    '            TranslatedTriangles(looperout).Points(looper) = RotateAroundZAxis(RotationValues.z * 180 / Math.PI, Triangles(looperout).Points(looper))
    '        Next

    '    Next
    'End Sub
    Public Function GetProjectedTriangles()
        Return ProjectedTriangles
    End Function


    Public Function DrawOne(ByVal Camera1 As Camera, ByVal ParallelLight As ParallelLightSource, ByVal MyTri As Triangle) As Triangle

        Dim temp1 As New Triangle
        For looper2 = 0 To MyTri.Points.Count - 1
            temp1.Points.Add(MyTri.Points(looper2) + TranslationVector)
        Next
        If temp1.DoesFaceCamera(Camera1) = True Then
            temp1.CalculateLightLevel(ParallelLight)
            temp1 = ViewTriangle(temp1, Camera1)
        End If
        Return temp1
    End Function

    Public Sub threadTest()
        ' ThreadPool.QueueUserWorkItem(
    End Sub
    Public Sub Draw(ByVal Camera1 As Camera, ByVal ParallelLight As ParallelLightSource)
        ProjectedTriangles.RemoveRange(0, ProjectedTriangles.Count)

        Dim TrianglesToProject As New List(Of Triangle)
        Dim ViewedTriangles As New List(Of Triangle)

        ' For looper = Triangles.Count - 1 To 1 Step -1
        ' MsgBox("f")
        For looper3 = Triangles.Count - 1 To 0 Step -1

            ' Triangles(looper3).CalculateLightLevel(ParallelLight)
            Dim temp1 As New Triangle


            For looper2 = 0 To Triangles(looper3).Points.Count - 1

                temp1.Points.Add(Triangles(looper3).Points(looper2) + TranslationVector)

            Next
            If temp1.DoesFaceCamera(Camera1) = True Then
                temp1.CalculateLightLevel(ParallelLight)
                TrianglesToProject.Add(temp1)
                Dim temp2 = TrianglesToProject(TrianglesToProject.Count - 1)
                TrianglesToProject(TrianglesToProject.Count - 1) = ViewTriangle(temp2, Camera1)
                'TrianglesToProject(looper) = ViewTriangle(TrianglesToProject(looper), Camera1)

            End If

        Next
        OrderTriangles(TrianglesToProject)
        ProjectMesh(TrianglesToProject)
        For looper = ProjectedTriangles.Count - 1 To 0 Step -1
            'ProjectedTriangles(looper) = ClipATriangleOnXYPlaneBeforeProjection(ProjectedTriangles(looper))
        Next
        ''divide by w to g to in/out tests
        ''Do in/out tests
        ''Multiply by w
        ' DivideByW(ProjectedTriangles)

        For looper = ProjectedTriangles.Count - 1 To 0 Step -1

            ProjectedTriangles(looper) = ClipATriangleOnNearPlane(ProjectedTriangles(looper))
            ProjectedTriangles(looper) = ClipATriangleOnRightPlane(ProjectedTriangles(looper))
            ProjectedTriangles(looper) = ClipATriangleOnLeftPlane(ProjectedTriangles(looper))

            ProjectedTriangles(looper) = ClipATriangleOnTopPlane(ProjectedTriangles(looper))
            ProjectedTriangles(looper) = ClipATriangleOnBottomPlane(ProjectedTriangles(looper))
            For looper2 = 0 To ProjectedTriangles(looper).Points.Count - 1
                If ProjectedTriangles(looper).Points(looper2).w <> 0 Then
                    ProjectedTriangles(looper).Points(looper2) /= ProjectedTriangles(looper).Points(looper2).w
                End If


            Next

            ProjectedTriangles(looper).SetLightLevel(TrianglesToProject(looper).GetLightLevel)
        Next
        For looper = 0 To ProjectedTriangles.Count - 1
            ProjectedTriangles(looper).SetColour(Colour)
        Next
    End Sub
    Private Function CalculateT(ByVal w1 As Double, ByVal a1 As Double, ByVal w2 As Double, ByVal a2 As Double) As Double
        Dim t As Double
        t = (w1 + a1) / ((w1 + a1) - (w2 + a2))
        Return t
    End Function
    Private Function CalculateT(ByVal w1 As Double, ByVal w2 As Double) As Double
        Dim t As Double
        t = w1 / (w1 - w2)
        Return t
    End Function
    Public Sub DoRainbow()
        If ColourNumber >= 1534 Then
            ColourNumber = 0
        End If
        ColourNumber += 2
        Colour = GetNextColour(ColourNumber)
    End Sub
    Private Function ClipATriangleOnWEqualsZero(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsInFrontOfCamera And Triangle.Points(0).IsInFrontOfCamera Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInFrontOfCamera And Triangle.Points(0).IsInFrontOfCamera = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(0).w))))
                    Else
                        If Triangle.Points(looper).IsInFrontOfCamera = False And Triangle.Points(0).IsInFrontOfCamera = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, Triangle.Points(looper).w))))
                        End If
                    End If
                End If
            Else
                If Triangle.Points(looper).IsInFrontOfCamera And Triangle.Points(looper + 1).IsInFrontOfCamera Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInFrontOfCamera And Triangle.Points(looper + 1).IsInFrontOfCamera = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(looper + 1).w))))
                    Else
                        If Triangle.Points(looper).IsInFrontOfCamera = False And Triangle.Points(looper + 1).IsInFrontOfCamera = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, Triangle.Points(looper).w))))
                        End If
                    End If
                End If
            End If
        Next
        Return NewTriangle
    End Function
    Private Function ClipATriangleOnRightPlane(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube And Triangle.Points(0).IsInsideRightPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube And Triangle.Points(0).IsInsideRightPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, -Triangle.Points(looper).x, Triangle.Points(0).w, -Triangle.Points(0).x))))
                    Else
                        If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube = False And Triangle.Points(0).IsInsideRightPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, -Triangle.Points(0).x, Triangle.Points(looper).w, -Triangle.Points(looper).x))))
                        End If
                    End If
                End If
            Else
                If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsInsideRightPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsInsideRightPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, -Triangle.Points(looper).x, Triangle.Points(looper + 1).w, -Triangle.Points(looper + 1).x))))
                    Else
                        If Triangle.Points(looper).IsInsideRightPlaneOfImageSpaceCube = False And Triangle.Points(looper + 1).IsInsideRightPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, -Triangle.Points(looper + 1).x, Triangle.Points(looper).w, -Triangle.Points(looper).x))))
                        End If
                    End If
                End If
            End If
        Next
        Return NewTriangle
    End Function
    Private Function ClipATriangleOnLeftPlane(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube And Triangle.Points(0).IsInsideLeftPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube And Triangle.Points(0).IsInsideLeftPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        Dim p As Vec3D
                        p = Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).x, Triangle.Points(0).w, Triangle.Points(0).x)))
                        NewTriangle.Points.Add(p)
                        '  NewTriangle.Points.Add(CreateNewPointOnPlane(Triangle.Points(looper), Triangle.Points(0), New Vec3D(1, 0, 0), New Vec3D(-1, 0, 0)))
                    Else
                        If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube = False And Triangle.Points(0).IsInsideLeftPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, Triangle.Points(0).x, Triangle.Points(looper).w, Triangle.Points(looper).x))))
                            ' NewTriangle.Points.Add(CreateNewPointOnPlane(Triangle.Points(0), Triangle.Points(looper), New Vec3D(1, 0, 0), New Vec3D(-1, 0, 0)))
                        Else

                        End If
                    End If

                End If
            Else
                If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsInsideLeftPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsInsideLeftPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).x, Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).x))))
                        ' NewTriangle.Points.Add(CreateNewPointOnPlane(Triangle.Points(looper), Triangle.Points(looper + 1), New Vec3D(1, 0, 0), New Vec3D(-1, 0, 0)))
                    Else
                        If Triangle.Points(looper).IsInsideLeftPlaneOfImageSpaceCube = False And Triangle.Points(looper + 1).IsInsideLeftPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).x, Triangle.Points(looper).w, Triangle.Points(looper).x))))
                            ' NewTriangle.Points.Add(CreateNewPointOnPlane(Triangle.Points(looper + 1), Triangle.Points(looper), New Vec3D(1, 0, 0), New Vec3D(-1, 0, 0)))
                        Else

                        End If



                    End If
                End If
            End If


        Next

        Return NewTriangle
    End Function
    Private Function ClipATriangleOnNearPlane(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsInfrontOfNearPlane And Triangle.Points(0).IsInfrontOfNearPlane Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInfrontOfNearPlane And Triangle.Points(0).IsInfrontOfNearPlane = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))

                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).z, Triangle.Points(0).w, Triangle.Points(0).z)))
                    Else
                        If Triangle.Points(looper).IsInfrontOfNearPlane = False And Triangle.Points(0).IsInfrontOfNearPlane = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, Triangle.Points(0).z, Triangle.Points(looper).w, Triangle.Points(looper).z))))
                        Else
                        End If
                    End If
                End If
            Else
                If Triangle.Points(looper).IsInfrontOfNearPlane And Triangle.Points(looper + 1).IsInfrontOfNearPlane Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsInfrontOfNearPlane And Triangle.Points(looper + 1).IsInfrontOfNearPlane = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).z, Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).z))))
                    Else
                        If Triangle.Points(looper).IsInfrontOfNearPlane = False And Triangle.Points(looper + 1).IsInfrontOfNearPlane = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).z, Triangle.Points(looper).w, Triangle.Points(looper).z))))
                        Else
                        End If
                    End If
                End If
            End If
        Next
        Return NewTriangle
    End Function
    Private Function ClipATriangleOnTopPlane(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube And Triangle.Points(0).IsBelowTopPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube And Triangle.Points(0).IsBelowTopPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))

                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * CalculateT(Triangle.Points(looper).w, -Triangle.Points(looper).y, Triangle.Points(0).w, -Triangle.Points(0).y)))
                    Else
                        If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube = False And Triangle.Points(0).IsBelowTopPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, -Triangle.Points(0).y, Triangle.Points(looper).w, -Triangle.Points(looper).y))))
                        Else
                        End If
                    End If
                End If
            Else
                If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsBelowTopPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsBelowTopPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, -Triangle.Points(looper).y, Triangle.Points(looper + 1).w, -Triangle.Points(looper + 1).y))))
                    Else
                        If Triangle.Points(looper).IsBelowTopPlaneOfImageSpaceCube = False And Triangle.Points(looper + 1).IsBelowTopPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, -Triangle.Points(looper + 1).y, Triangle.Points(looper).w, -Triangle.Points(looper).y))))
                        Else
                        End If
                    End If
                End If
            End If
        Next
        Return NewTriangle
    End Function
    Private Function ClipATriangleOnBottomPlane(ByVal Triangle As Triangle)
        Dim NewTriangle As New Triangle
        For looper = 0 To Triangle.Points.Count - 1
            If looper = Triangle.Points.Count - 1 Then
                If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube And Triangle.Points(0).IsAboveBottomPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube And Triangle.Points(0).IsAboveBottomPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))

                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(0) - Triangle.Points(looper)) * CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).y, Triangle.Points(0).w, Triangle.Points(0).y)))
                    Else
                        If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube = False And Triangle.Points(0).IsAboveBottomPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(0) + ((Triangle.Points(looper) - Triangle.Points(0)) * (CalculateT(Triangle.Points(0).w, Triangle.Points(0).y, Triangle.Points(looper).w, Triangle.Points(looper).y))))
                        Else
                        End If
                    End If
                End If
            Else
                If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsAboveBottomPlaneOfImageSpaceCube Then
                    NewTriangle.Points.Add(Triangle.Points(looper))
                Else
                    If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube And Triangle.Points(looper + 1).IsAboveBottomPlaneOfImageSpaceCube = False Then
                        NewTriangle.Points.Add(Triangle.Points(looper))
                        NewTriangle.Points.Add(Triangle.Points(looper) + ((Triangle.Points(looper + 1) - Triangle.Points(looper)) * (CalculateT(Triangle.Points(looper).w, Triangle.Points(looper).y, Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).y))))
                    Else
                        If Triangle.Points(looper).IsAboveBottomPlaneOfImageSpaceCube = False And Triangle.Points(looper + 1).IsAboveBottomPlaneOfImageSpaceCube = True Then
                            NewTriangle.Points.Add(Triangle.Points(looper + 1) + ((Triangle.Points(looper) - Triangle.Points(looper + 1)) * (CalculateT(Triangle.Points(looper + 1).w, Triangle.Points(looper + 1).y, Triangle.Points(looper).w, Triangle.Points(looper).y))))
                        Else
                        End If
                    End If
                End If
            End If
        Next
        Return NewTriangle
    End Function
    Private Function CreateNewPointOnPlane(ByVal Q1 As Vec3D, ByVal Q2 As Vec3D, ByVal PointOnPlane As Vec3D, ByVal NormalToPlane As Vec3D)
        Dim OutV As Vec3D
        Dim T As Double = Vec3D.DotProduct(Q1 - PointOnPlane, NormalToPlane) / (Vec3D.DotProduct(Q1 - PointOnPlane, NormalToPlane) - Vec3D.DotProduct(Q2 - PointOnPlane, NormalToPlane))
        OutV = Q1 + (Q2 - Q1) * T
        If Double.IsNaN(OutV.x) Then
            '  If 1 <> 1 Then Dim a As Char

        End If
        If Double.IsNaN(OutV.y) Then
            ' If 1 <> 1 Then Dim a As Char

        End If
        If Double.IsNaN(OutV.z) Then
            ' If 1 <> 1 Then Dim a As Char

        End If
        Return OutV
    End Function
    Private Sub DivideByW(ByRef Triangles As List(Of Triangle))

        For looper = 0 To Triangles.Count - 1
            For looper2 = 0 To Triangles(looper).Points.Count - 1
                If Triangles(looper).Points(looper2).w <> 0 Then
                    Triangles(looper).Points(looper2) /= Triangles(looper).Points(looper2).w
                End If


            Next
        Next
    End Sub
    Private Sub ProjectMesh(ByVal TrianglesToProject As List(Of Triangle))
        For looper = 0 To TrianglesToProject.Count - 1
            ProjectedTriangles.Add(New Triangle(TrianglesToProject(looper).ProjectTri))
            ProjectedTriangles(looper).SetLightLevel(TrianglesToProject(looper).GetLightLevel)
        Next
    End Sub
    Private Function ViewTriangle(ByVal Tri As Triangle, ByVal camera1 As Camera)
        Dim ViewedTriangle As New Triangle(ViewTransform(Tri.Points(0), camera1), ViewTransform(Tri.Points(1), camera1), ViewTransform(Tri.Points(2), camera1), Tri.GetLightLevel)

        Return ViewedTriangle
    End Function
    Public Sub Translate(ByVal D As Vec3D)

        For looper = 0 To Vectors.Count - 1
            Vectors(looper).x += D.x
            Vectors(looper).y += D.y
            Vectors(looper).z += D.z

        Next

    End Sub
End Class
