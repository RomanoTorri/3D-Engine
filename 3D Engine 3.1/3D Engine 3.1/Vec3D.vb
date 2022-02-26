Public Class Vec3D
    Public x As Double
    Public y As Double
    Public z As Double
    Public w As Double

    Public Sub New(x1, y1, z1)
        x = x1
        y = y1
        z = z1
    End Sub
    Public Sub New()
        x = 0
        y = 0
        z = 0
    End Sub
    Public Shared Operator +(ByVal A As Vec3D, ByVal B As Vec3D) As Vec3D
        Dim C As New Vec3D
        C.x = A.x + B.x
        C.y = A.y + B.y
        C.z = A.z + B.z
        C.w = A.w + B.w
        Return C
    End Operator
    Public Shared Operator *(ByVal A As Vec3D, M As Double) As Vec3D
        Dim C As New Vec3D
        C.x = A.x * M
        C.y = A.y * M
        C.z = A.z * M
        C.w = A.w * M
        Return C
    End Operator
    Public Shared Operator /(ByVal A As Vec3D, ByVal M As Double) As Vec3D
        Dim C As New Vec3D
        C.x = A.x / M
        C.y = A.y / M
        C.z = A.z / M
        C.w = A.w / M
        Return C
    End Operator
    Public Shared Operator -(ByVal A As Vec3D, ByVal B As Vec3D) As Vec3D
        Dim C As New Vec3D
        C.x = A.x - B.x
        C.y = A.y - B.y
        C.z = A.z - B.z
        C.w = A.w - B.w
        Return C
    End Operator
    Public Shared Function DotProduct(VecA As Vec3D, VecB As Vec3D)
        Dim P As Double
        P = VecA.x * VecB.x + VecA.y * VecB.y + VecA.z * VecB.z
        Return P
    End Function
    Public Shared Function CrossProduct(VecA As Vec3D, VecB As Vec3D) As Vec3D
        Dim vecC As New Vec3D
        vecC.x = (VecA.y * VecB.z) - (VecA.z * VecB.y)
        vecC.y = (VecA.z * VecB.x) - (VecA.x * VecB.z)
        vecC.z = (VecA.x * VecB.y) - (VecA.y * VecB.x)
        Return vecC
    End Function
    Public Function IsInFrontOfCamera()
        If w > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsInsideLeftPlaneOfImageSpaceCube()
        If w + x > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsInsideRightPlaneOfImageSpaceCube()
        If w - x > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsBelowTopPlaneOfImageSpaceCube()
        If w - y > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsAboveBottomPlaneOfImageSpaceCube()
        If w + y > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsInfrontOfNearPlane()
        If w + z > 0 Then
            Return True
        End If
        Return False
    End Function
    'Public Function IsInFrontOnCamera()
    '    If z > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Public Function IsInTopPlane()
    '    If y - 1 < 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Public Function IsInBottomPlane()
    '    If y + 1 > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Public Function IsInNearPlane()
    '    If z + 1 > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Public Function IsInLeftPlane()
    '    If x + 1 > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Public Function IsInRightPlane()
    '    If x - 1 < 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    Sub Normalise()
        Dim Mag As Double
        Mag = Math.Sqrt(x * x + y * y + z * z)
        x = x / Mag
        y = y / Mag
        z = z / Mag
    End Sub
End Class
