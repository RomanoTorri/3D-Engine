Public Class LightSource
    Protected Colour As Color
    Protected Intensity As Double
    Public Function GetColour()
        Return Colour
    End Function
    Public Function GetIntensity()
        Return Intensity
    End Function
    Public Sub SetColour(inColour As Color)
        Colour = inColour
    End Sub
    Public Sub SetIntensity(inIntensity As Double)
        Intensity = inIntensity
    End Sub
    Public Sub New(inColour As Color, inIntensity As Double)
        Colour = inColour
        Intensity = inIntensity
    End Sub
End Class
