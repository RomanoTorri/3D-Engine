Module Utils
    Public Function vecxmat4x4(v As Vec3D, m(,) As Double)
        Dim nv As New Vec3D
        Dim w As Double = 0
        nv.x = v.x * m(0, 0) + v.y * m(0, 1) + v.z * m(0, 2) + 1 * m(0, 3)
        nv.y = v.x * m(1, 0) + v.y * m(1, 1) + v.z * m(1, 2) + 1 * m(1, 3)
        nv.z = v.x * m(2, 0) + v.y * m(2, 1) + v.z * m(2, 2) + 1 * m(2, 3)

        'If div = True Then
        '    If w <> 0 Then
        '        nv.x /= w
        '        nv.y /= w
        '        '     nv.z /= w
        '    End If
        'End If

        Return nv
    End Function

    Public Function RotateAroundYAxis(Angle As Double, Vector As Vec3D)
        Dim M(,) As Double = CreateYRotationMatrix(Angle)
        Return vecxmat4x4(Vector, M)
    End Function
    Public Function RotateAroundZAxis(Angle As Double, Vector As Vec3D)
        Dim M(,) As Double = CreateZRotationMatrix(Angle)
        Return vecxmat4x4(Vector, M)
    End Function
    Public Function RotateAroundXAxis(Angle As Double, Vector As Vec3D)
        Dim M(,) As Double = CreateXRotationMatrix(Angle)
        Return vecxmat4x4(Vector, M)
    End Function
    Public Function CreateZRotationMatrix(T As Double)
        Dim M(3, 3) As Double
        M(0, 0) = Math.Cos(T)
        M(0, 1) = Math.Sin(T)
        M(1, 0) = -Math.Sin(T)
        M(1, 1) = Math.Cos(T)
        M(2, 2) = 1
        Return M
    End Function
    Public Function CreateYRotationMatrix(T As Double)
        Dim M(3, 3) As Double
        M(0, 0) = Math.Cos(T)
        M(2, 0) = -Math.Sin(T)
        M(1, 1) = 1
        M(0, 2) = Math.Sin(T)
        M(2, 2) = Math.Cos(T)
        Return M
    End Function
    Public Function CreateXRotationMatrix(T As Double)
        Dim M(3, 3) As Double
        M(0, 0) = 1
        M(1, 1) = Math.Cos(T)
        M(1, 2) = -Math.Sin(T)
        M(2, 1) = Math.Sin(T)
        M(2, 2) = Math.Cos(T)
        Return M
    End Function
    Public Function ViewTransform(v As Vec3D, camera1 As Camera)
        Dim m(,) As Double = MakeViewMatrix(camera1, New Vec3D(0, 1, 0))
        Dim nv As New Vec3D
        Dim w As Double = 0
        ' w = v.x * m(3, 0) + v.y * m(3, 1) + v.z * m(3, 2) + 1 * m(3, 3)
        nv = vecxmat4x4(v, m)
        If w <> 0 Then
            nv.x /= w
            nv.y /= w
            ' nv.z /= w
        End If
        Return nv
    End Function
    Public Function Project(v As Vec3D)
        Dim m(,) As Double
        If Form1.CtrlKey = True Then
            m = MakeProjectionMatrix(Math.PI / 5)
        Else
            m = MakeProjectionMatrix(Math.PI / 2)
        End If

        Dim nv As New Vec3D
        Dim w As Double = 0

        nv = vecxmat4x4(v, m)
        nv.w = (v.x * m(3, 0) + v.y * m(3, 1) + v.z * m(3, 2) + 1 * m(3, 3))
        '  w = (v.x * m(3, 0) + v.y * m(3, 1) + v.z * m(3, 2) + 1 * m(3, 3))
        If w <> 0 Then
            'nv.x /= w
            '  nv.y /= w
            ' nv.z /= w
        End If
        Return nv
    End Function
    Public Function MakeViewMatrix(Camera1 As Camera, TempUp As Vec3D)
        Dim View(3, 3) As Double
        Dim Right As Vec3D
        Dim Up As Vec3D
        Right = Vec3D.CrossProduct(Camera1.GetUpDirection, Camera1.GetDirection)
        View = ZeroMatrix(View)
        Up = Camera1.GetUpDirection
        View(0, 0) = Right.x
        View(0, 1) = Right.y
        View(0, 2) = Right.z
        View(0, 3) = -Vec3D.DotProduct(Right, Camera1.GetPosition)
        View(1, 0) = Up.x
        View(1, 1) = Up.y
        View(1, 2) = Up.z
        View(1, 3) = -Vec3D.DotProduct(Up, Camera1.GetPosition)
        View(2, 0) = Camera1.GetDirection.x
        View(2, 1) = Camera1.GetDirection.y
        View(2, 2) = Camera1.GetDirection.z
        View(2, 3) = -Vec3D.DotProduct(Camera1.GetDirection, Camera1.GetPosition)
        View(3, 3) = 1
        Return View
    End Function
    Public Function MakeProjectionMatrix(inFOV As Double)
        Dim FOV As Double = inFOV
        Dim fNear As Double = 0.1
        Dim fFar As Double = 1000
        Dim Proj(3, 3) As Double
        Proj = ZeroMatrix(Proj)
        Proj(0, 0) = (Form1.ClientSize.Height / Form1.ClientSize.Width) * (1 / Math.Tan(FOV / 2))
        Proj(1, 1) = 1 / Math.Tan(FOV / 2)
        Proj(2, 2) = fFar / (fFar - fNear)
        Proj(2, 3) = -(fFar * fNear) / (fFar - fNear)
        Proj(3, 2) = 1
        Return Proj
    End Function
    Public Function ZeroMatrix(m(,) As Double)
        For looper = 0 To m.GetLength(0) - 1
            For looper2 = 0 To m.GetLength(1) - 1
                m(looper, looper2) = 0
            Next
        Next
        Return m
    End Function
    Public Sub QuickSortMeshes(C As List(Of Mesh), ByVal First As Long, ByVal Last As Long)
        '
        '  Made by Michael Ciurescu (CVMichael from vbforums.com)
        '  Original thread: [url]http://www.vbforums.com/showthread.php?t=231925[/url]
        '
        Dim Low As Long, High As Long
        Dim MidValue As Mesh

        Low = First
        High = Last
        MidValue = C((First + Last) \ 2)

        Do
            While C(Low).GetZMidPoint < MidValue.GetZMidPoint
                Low = Low + 1
            End While

            While C(High).GetZMidPoint > MidValue.GetZMidPoint
                High = High - 1
            End While

            If Low <= High Then
                SwapMeshes(C(Low), C(High))
                Low = Low + 1
                High = High - 1
            End If
        Loop While Low <= High

        If First < High Then QuickSortMeshes(C, First, High)
        If Low < Last Then QuickSortMeshes(C, Low, Last)
    End Sub

    Private Sub SwapMeshes(ByRef A As Mesh, ByRef B As Mesh)
        Dim T As Mesh

        T = A
        A = B
        B = T
    End Sub
    Public Sub QuickSortTriangles(C As List(Of Triangle), ByVal First As Long, ByVal Last As Long)
        '
        '  Made by Michael Ciurescu (CVMichael from vbforums.com)
        '  Original thread: [url]http://www.vbforums.com/showthread.php?t=231925[/url]
        '
        Dim Low As Long, High As Long
        Dim MidValue As Triangle

        Low = First
        High = Last
        MidValue = C((First + Last) \ 2)

        Do
            While C(Low).GetZMidPoint < MidValue.GetZMidPoint
                Low = Low + 1
            End While

            While C(High).GetZMidPoint > MidValue.GetZMidPoint
                High = High - 1
            End While

            If Low <= High Then
                SwapTriangles(C(Low), C(High))
                Low = Low + 1
                High = High - 1
            End If
        Loop While Low <= High

        If First < High Then QuickSortTriangles(C, First, High)
        If Low < Last Then QuickSortTriangles(C, Low, Last)
    End Sub
    Private Sub SwapTriangles(ByRef A As Triangle, ByRef B As Triangle)
        Dim T As Triangle
        T = A
        A = B
        B = T
    End Sub
    Public Function GetNextColour(ByVal inInt As Integer)
        Dim C As Color
        Select Case inInt
            Case 0 To 255
                C = C.FromArgb(255, inInt, 0)
            Case 256 To 511
                C = C.FromArgb(256 + 255 - inInt, 255, 0)
            Case 512 To 767
                C = C.FromArgb(0, 255, inInt - 512)
            Case 767 To 1022
                C = C.FromArgb(0, 255 + 767 - inInt, 255)
            Case 1023 To 1278
                C = C.FromArgb(inInt - 1023, 0, 255)
            Case 1279 To 1534
                C = C.FromArgb(255, 0, 255 + 1279 - inInt)

        End Select
        Return C
    End Function
End Module
