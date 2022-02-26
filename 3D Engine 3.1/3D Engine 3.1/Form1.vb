
Public Class Form1
    Public MouseCentred As Boolean
    Private FilePath As String
    Public CtrlKey As Boolean
    Private RotationVector As New Vec3D
    Private TranslationVector As New Vec3D
    Private WithEvents ChooseFileButton As New Button
    Private WithEvents Menu1 As New MainMenu
    Private WithEvents MenuItemFile As New MenuItem
    Private WithEvents MenuItemEdit As New MenuItem
    Private WithEvents MenuItemOpen As New MenuItem("&Open")
    Private WithEvents MenuItemAdd As New MenuItem("&Add")
    Private WithEvents MenuItemTranslate As New MenuItem("&Translate")
    Private WithEvents MenuItemTransform As New MenuItem("&Transform")
    Private WithEvents MenuItemRotate As New MenuItem("&Set Object Rotation")
    Private MenuItemsObjects() As MenuItem
    '  Private Meshes As New List(Of Mesh)
    Private World1 As World
    ' Public a As String
    Public InputController1 As New InputController
    Public Sub TurnChooseFileButtonOff()
        ChooseFileButton.Enabled = False
        ChooseFileButton.Visible = False
    End Sub

    Public Function GetInputController()
        Return InputController1
    End Function
    Public Sub SetTranslationVector(ByVal vec As Vec3D, ByVal index As Integer)
        World1.SetMeshTranslate(vec, index)
    End Sub
    'Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = "Esc" Then

    '    End If
    'End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                If MouseCentred = True Then
                    MouseCentred = False
                    Cursor.Show()
                Else
                    MouseCentred = True
                    Cursor.Hide()
                End If
            Case Keys.A
                InputController1.AKey = False
            Case Keys.W
                InputController1.WKey = False
            Case Keys.S
                InputController1.SKey = False
            Case Keys.D
                InputController1.DKey = False
            Case Keys.Q
                InputController1.qKey = False
            Case Keys.E
                InputController1.eKey = False
            Case Keys.Space
                InputController1.SpaceKey = False
            Case Keys.C
                InputController1.CKey = False
            Case Keys.D1
                InputController1.OneKey = False
            Case Keys.ControlKey
                CtrlKey = False
        End Select
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            'Case Keys.Escape
            '    InputController1.EscKey = False
            Case Keys.A
                InputController1.AKey = True
            Case Keys.W
                InputController1.WKey = True
            Case Keys.S
                InputController1.SKey = True
            Case Keys.D
                InputController1.DKey = True
            Case Keys.Q
                InputController1.qKey = True
            Case Keys.E
                InputController1.eKey = True
            Case Keys.Space
                InputController1.SpaceKey = True
            Case Keys.C
                InputController1.CKey = True
            Case Keys.D1
                InputController1.OneKey = True
            Case Keys.ControlKey
                CtrlKey = True
        End Select
    End Sub
    Public Sub SetRotationVector(ByVal inVec As Vec3D, ByVal Index As Integer)
        World1.SetMeshRotation(inVec, Index)
    End Sub
    Private Sub MenuItemRotateClick(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItemRotate.Click
        Dim RotationForm1 As New RotationForm
        ' MenuItemRotate.MenuItems
        'sender.menuitems()

        ' MsgBox(sender.ToString)
        RotationForm1.SetMeshIndex(sender.index)
        RotationForm.ShowDialog()
    End Sub
    Private Sub ChooseFileButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChooseFileButton.Click

        Dim Fd As New OpenFileDialog
        Fd.InitialDirectory() = "\3D Engine 3.1\3D Engine 3.1\bin\Debug\Meshes"

        If Fd.ShowDialog() = DialogResult.OK Then
            FilePath = (Fd.FileName)
            Cursor.Position = New Point(Me.Left + Me.Width / 2, Me.Top + Me.Height / 2)
        End If
        ' FilePath = ("S:\3D Engine 3\3D Engine 3\bin\Debug\Meshes\Icosphere.obj")
        '  World1 = New World(FilePath)

        ' MouseCentred = True
        ' Dim F As New List(Of String)
        ' F.Add(FilePath)
        ' ChangeRotationMenu(F)
        '  Cursor.Hide()
        ' World1.StartWorld()
        If FilePath <> Nothing Then
            MouseCentred = True
            World1 = New World(FilePath)
            World1.StartWorld()

            Cursor.Hide()
        End If

    End Sub


    Public Sub ChangeRotationMenu(ByVal Captions As List(Of String))
        Dim counter As Integer
        For Each Caption In Captions
            Dim i As Integer
            For looper = Caption.Length - 1 To 0 Step -1
                If Caption(looper) = "\" Then
                    i = (looper)
                    Exit For
                End If
            Next
            Dim s As String = Caption
            s = s.Substring(i + 1)
            MenuItemRotate.MenuItems.Add(s)
            'MenuItemRotate.MenuItems.

            AddHandler MenuItemRotate.MenuItems(counter).Click, AddressOf MenuItemRotateClick
            counter += 1
        Next
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Button1.Dispose()
        MouseCentred = False
        ChooseFileButton.Text = "Choose a File"
        ChooseFileButton.AutoSize = True
        ChooseFileButton.Location = New Point(Me.Width / 2 - ChooseFileButton.Width / 2, Me.Height / 2 - ChooseFileButton.Height / 2)
        MenuItemFile.Text = "File"
        MenuItemEdit.Text = "Edit"
        MenuItemTransform.MenuItems.Add(MenuItemTranslate)
        MenuItemFile.MenuItems.Add(MenuItemOpen)
        Menu1.MenuItems.Add(MenuItemFile)
        '  Menu1.MenuItems.Add(MenuItemEdit)
        Menu1.MenuItems.Add(MenuItemTransform)
        MenuItemTransform.MenuItems.Add(MenuItemRotate)
        ' MenuItemFile.MenuItems.Add(MenuItemAdd)
        Me.Controls.Add(ChooseFileButton)
        Me.Menu = Menu1
        ' Menu1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
        'Dim FilePaths As New List(Of String)
        'Me.WindowState = FormWindowState.Maximized
        ''Me.TransparencyKey = Color.Black
        '  Me.FormBorderStyle = FormBorderStyle.None

        'FilePaths.Add("meshes\teapot.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")
        'FilePaths.Add("Meshes\cube.obj")

        'World1 = New World(FilePaths)
        'World1.StartWorld()
        'Button1.Visible = False
        'Button1.Enabled = False
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If MouseCentred = True Then
            InputController1.TheMousePosition.X = Cursor.Position.X
            InputController1.TheMousePosition.Y = Cursor.Position.Y
            Cursor.Position = New Point(Me.Left + Me.Width / 2, Me.Top + Me.Height / 2)
        End If

    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Not IsNothing(World1) Then
            World1.ChangeBitmapSize()
        End If

    End Sub

    Private Sub MenuItemAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemAdd.Click
        'Dim Fd As New OpenFileDialog
        'Fd.InitialDirectory() = "\\lpbs-file-02\2013$\torrir07893\3D Engine 3\3D Engine 3\bin\Debug\Meshes"

        'If Fd.ShowDialog() = DialogResult.OK Then
        '    World1.AddMesh(Fd.FileName)
        'End If

    End Sub

    Private Sub MenuItemOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemOpen.Click
        ' World1.ChangeMesh()
        Dim Fd As New OpenFileDialog
        Fd.InitialDirectory() = "3D Engine 3.1\3D Engine 3.1\bin\Debug\Meshes"

        If Fd.ShowDialog() = DialogResult.OK Then
            FilePath = (Fd.FileName)
            Cursor.Position = New Point(Me.Left + Me.Width / 2, Me.Top + Me.Height / 2)
        End If
        'FilePaths.Add("S:\3D Engine 3\3D Engine 3\bin\Debug\Meshes\Icosphere.obj")
        World1.ChangeMesh(FilePath)

        MouseCentred = True
        Dim F As New List(Of String)
        F.Add(FilePath)
        ' ChangeRotationMenu(F)
        Cursor.Hide()
        ' World1.StartWorld()
    End Sub

    Private Sub MenuItemTranslate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemTranslate.Click
        Dim TranslateForm1 As New TranslateForm
        TranslateForm1.SetIndex(0)
        TranslateForm1.Show()
    End Sub
End Class

