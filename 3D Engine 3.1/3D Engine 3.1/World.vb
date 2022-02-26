Public Class World
    Private WithEvents Timer1 As New Timer
    Private Meshes As New List(Of Mesh)
    Private Camera1 As New Camera
    Private ParallelLight As New ParallelLightSource(Color.White, 1, New Vec3D(1, -1, 0))
    Private ShowLines As Boolean
    Dim counter As Integer = 0
    Dim G As Graphics
    Dim backbuffer As Bitmap
    Public Sub ChangeMesh(ByVal Mesh)
        ' Timer1.Stop()
        Meshes(0) = New Mesh(Mesh, Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255))
    End Sub
    Public Sub SetShowLines(F As Boolean)
        ShowLines = F
    End Sub
    Public Sub SetMeshRotation(ByVal Vec As Vec3D, ByVal index As Integer)
        Meshes(index).SetRotationValues(Vec)
    End Sub
    Public Sub AddMesh(ByVal Mesh As String)
        Meshes.Add(New Mesh(Mesh, Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)))
        Dim TransForm As New TranslateForm
        TransForm.SetIndex(Meshes.Count - 1)
        TransForm.Show()
    End Sub
    Public Sub SetMeshTranslate(ByVal vec As Vec3D, ByVal index As Integer)
        Meshes(index).SetTranslationVector(vec)
    End Sub
    Public Sub New(ByVal FileLocation As String)
        Timer1.Enabled = True
        Timer1.Interval = 1
        Randomize()

        Meshes.Add(New Mesh(FileLocation, Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)))

        Form1.TurnChooseFileButtonOff()
        ' Meshes(0)
        'Meshes(0).Translate(New Vec3D(0, 0, 0))

        'Meshes(1).Translate(New Vec3D(0, 2, 0))
        'Meshes(2).Translate(New Vec3D(0, 4, 0))
        'Meshes(3).Translate(New Vec3D(0, 6, 0))
        'Meshes(4).Translate(New Vec3D(0, 8, 0))
        'Meshes(5).Translate(New Vec3D(-2, 8, 0))
        'Meshes(6).Translate(New Vec3D(-4, 8, 0))
        'Meshes(7).Translate(New Vec3D(-2, 4, 0))
        'Meshes(8).Translate(New Vec3D(-4, 4, 0))

    End Sub
    Public Sub StartWorld()
        Dim tBackbuffer As New Bitmap(Form1.ClientSize.Width, Form1.ClientSize.Height)
        backbuffer = tBackbuffer
        Me.Timer1.Interval = 1
        Timer1.Enabled = True


    End Sub
    Public Sub ChangeBitmapSize()
        Dim tBackbuffer As New Bitmap(Form1.ClientSize.Width, Form1.ClientSize.Height)
        backbuffer = tBackbuffer
    End Sub
    Public Function GetMeshes()
        Return Meshes
    End Function
    Private Sub RotateMeshes()
        For Each Mesh In Meshes
            Mesh.RotateTriangles()
        Next
    End Sub
    Private Sub Timer1_Tick() Handles Timer1.Tick
        G = Graphics.FromImage(backbuffer)
        RotateMeshes()

        ' G.dpi
        ' Dim colour1 As Color
        ' colour1 = Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)
        G.Clear(Color.White)
        Dim MyBrush As Brush
        Dim BigMesh As Mesh
        counter += 1
        ' Dim colour As Color
        ' colour = Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)
        For looper = 0 To Meshes.Count - 1

            If counter Mod 1 = 0 Then

                Meshes(looper).DoRainbow()
            End If

            Meshes(looper).Draw(Camera1, ParallelLight)
        Next
        '  OrderMeshes(Meshes)
        'Meshes.Reverse()
        BigMesh = ConglomerateMeshes(Meshes)
        ' BigMesh.SortProjectedTriangles()

        For looper2 = 0 To BigMesh.GetProjectedTriangles.count - 1
            If BigMesh.GetProjectedTriangles(looper2).getlightlevel < 0.2 Then
                MyBrush = New SolidBrush(Color.FromArgb(255, BigMesh.GetProjectedTriangles(looper2).GetColour.r * 0.2, BigMesh.GetProjectedTriangles(looper2).GetColour.g * 0.2, BigMesh.GetProjectedTriangles(looper2).GetColour.b * 0.2))
            Else
                MyBrush = New SolidBrush(Color.FromArgb(255, BigMesh.GetProjectedTriangles(looper2).GetColour.r * BigMesh.GetProjectedTriangles(looper2).getlightlevel, BigMesh.GetProjectedTriangles(looper2).GetColour.g * BigMesh.GetProjectedTriangles(looper2).getlightlevel, BigMesh.GetProjectedTriangles(looper2).GetColour.b * BigMesh.GetProjectedTriangles(looper2).getlightlevel))
            End If

            If BigMesh.GetProjectedTriangles(looper2).points.count > 1 Then

                G.FillPolygon(MyBrush, BigMesh.GetProjectedTriangles(looper2).cpoints)
                If Form1.GetInputController.OneKey = True Then
                    G.DrawPolygon(Pens.Red, BigMesh.GetProjectedTriangles(looper2).cpoints)
                End If

                End If
            Next


        Form1.CreateGraphics.DrawImage(backbuffer, 0, 0)
        Form1.GetInputController.dokeys(Camera1, Me)
    End Sub
    Public Function ConglomerateMeshes(inMeshes As List(Of Mesh))
        Dim EndMesh As New Mesh
        For looper = 0 To inMeshes.Count - 1
            For looper2 = 0 To inMeshes(looper).GetProjectedTriangles.count - 1
                EndMesh.AddProjectedTriangle(inMeshes(looper).GetProjectedTriangles(looper2))
            Next
        Next
        Return EndMesh
    End Function
    Private Function MeanOfZ(Mesh)
        Dim Z As Double = 0
        For looper = 0 To Mesh.getprojectedtriangles.count - 1
            Z += Mesh.getprojectedtriangles(looper).getzmidpoint
        Next
        Return Z / Mesh.getprojectedtriangles.count
    End Function
    Private Sub OrderMeshes(TheMeshes As List(Of Mesh))
        For looper = 0 To TheMeshes.Count - 1
            TheMeshes(looper).SetZMidPoint(MeanOfZ(TheMeshes(looper)))
        Next
        QuickSortMeshes(TheMeshes, 0, TheMeshes.Count - 1)
    End Sub
End Class
