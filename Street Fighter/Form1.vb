﻿Imports System.Drawing
Imports System.Math
Public Class Form1
    'sprites
    Private bg, Ryu, intro(9), standR(4), standL(4), crouch(7), jump(9), jumpL(9) As Bitmap
    'index of activity
    Private indexIntro, indexStandR, indexStandL, indexCrouch, indexJump, indexJumpL As Integer
    'what Ryu is doing
    Private doing As String
    'location of Ryu
    Dim x As Integer = 280
    Dim y As Integer = 130
    Sub SetIntro()
        intro(0) = My.Resources.intro0
        intro(1) = My.Resources.intro1
        intro(2) = My.Resources.intro2
        intro(3) = My.Resources.intro3
        intro(4) = My.Resources.intro4
        intro(5) = My.Resources.intro5
        intro(6) = My.Resources.intro6
        intro(7) = My.Resources.intro7
        intro(8) = My.Resources.intro8
    End Sub
    Sub SetStandR()
        standR(0) = My.Resources.standR0
        standR(1) = My.Resources.standR1
        standR(2) = My.Resources.standR2
        standR(3) = My.Resources.standR3
    End Sub
    Sub SetStandL()
        standL(0) = My.Resources.standL0
        standL(1) = My.Resources.standL1
        standL(2) = My.Resources.standL2
        standL(3) = My.Resources.standL3
    End Sub
    Sub SetCrouch()
        crouch(0) = My.Resources.crouchR0
        crouch(1) = My.Resources.crouchR1
        crouch(2) = My.Resources.crouchR2
        crouch(3) = My.Resources.crouchR3
        crouch(4) = My.Resources.crouchR3
        crouch(5) = My.Resources.crouchL3
        crouch(6) = My.Resources.crouchL3
    End Sub
    Sub SetJump()
        jump(0) = My.Resources.jump0
        jump(1) = My.Resources.jump1
        jump(2) = My.Resources.jump2
        jump(3) = My.Resources.jump3
        jump(4) = My.Resources.jump4
        jump(5) = My.Resources.jump5
        jump(6) = My.Resources.jump6
        jump(7) = My.Resources.jump7
        jump(8) = My.Resources.jump8
    End Sub
    Sub SetJumpL()
        jumpL(0) = My.Resources.jumpL0
        jumpL(1) = My.Resources.jumpL1
        jumpL(2) = My.Resources.jumpL2
        jumpL(3) = My.Resources.jumpL3
        jumpL(4) = My.Resources.jumpL4
        jumpL(5) = My.Resources.jumpL5
        jumpL(6) = My.Resources.jumpL6
        jumpL(7) = My.Resources.jumpL7
        jumpL(8) = My.Resources.jumpL8
    End Sub
    Sub PutSprite(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim mask, sprite As Bitmap
        mask = MaskOf(d)
        sprite = SpriteOf(d)
        Spriteand(bg, mask, x, y)
        spriteor(bg, sprite, x, y)
    End Sub
    Function MaskOf(b As Bitmap) As Bitmap
        'Bg = white, sprite = black
        Dim a As Bitmap
        Dim c As Color
        Dim i, j As Integer

        a = b.Clone
        c = a.GetPixel(0, 0) ' color of bg of sprite
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                If a.GetPixel(i, j) = c Then
                    a.SetPixel(i, j, Color.White)
                Else
                    a.SetPixel(i, j, Color.Black)
                End If
            Next
        Next
        Return a
    End Function
    Function SpriteOf(b As Bitmap) As Bitmap
        'Bg = black
        Dim a As Bitmap
        Dim c As Color
        Dim i, j As Integer

        a = b.Clone
        c = a.GetPixel(0, 0) ' color of bg of sprite
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                If a.GetPixel(i, j) = c Then
                    a.SetPixel(i, j, Color.Black)
                End If
            Next
        Next
        Return a
    End Function
    Sub Spriteand(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        'set sprite on the bg to be black using and operation bcs d is mask
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                a = c.GetPixel(i + x, j + y).A And d.GetPixel(i, j).A
                r = c.GetPixel(i + x, j + y).R And d.GetPixel(i, j).R
                g = c.GetPixel(i + x, j + y).G And d.GetPixel(i, j).G
                b = c.GetPixel(i + x, j + y).B And d.GetPixel(i, j).B
                c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
            Next
        Next
    End Sub
    Sub Spriteor(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        'give color to the black sprite using or operation bcs d is sprite(white)
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                a = c.GetPixel(i + x, j + y).A Or d.GetPixel(i, j).A
                r = c.GetPixel(i + x, j + y).R Or d.GetPixel(i, j).R
                g = c.GetPixel(i + x, j + y).G Or d.GetPixel(i, j).G
                b = c.GetPixel(i + x, j + y).B Or d.GetPixel(i, j).B
                c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
            Next
        Next
    End Sub
    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play(My.Resources.sfmusic, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayLoopingBackgroundSoundFile()

        indexIntro = 0
        indexStandR = 0
        indexStandR = 0
        indexCrouch = 0
        indexJump = 0
        indexJumpL = 0
        SetIntro()
        SetStandR()
        SetStandL()
        SetCrouch()
        SetJump()
        SetJumpL()

        Timer1.Interval = 100
        Timer2.Interval = 100

        bg = My.Resources.background
        pbcanvas.Image = bg
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            doing = "walkL"
            If x = 20 Then
                x = 20
            Else
                x = x - 10
            End If

        ElseIf e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            doing = "walkR"
            If x = 550 Then
                x = 550
            Else
                x = x + 10
            End If
        End If

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            doing = "crouch"
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            doing = "jump"
        End If
        '20 550
        If e.KeyCode = Keys.End Or e.KeyCode = Keys.E Then
            If x >= 530 Then
                doing = "jump"
            Else
                doing = "jumpR"
            End If
        End If


        If e.KeyCode = Keys.Q Then
            If x <= 40 Then
                doing = "jump"
            Else
                doing = "jumpR"
            End If
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.W Then
            doing = "walkR"
            y = 130
        End If
    End Sub
    Sub ReDraw()
        bg = New Bitmap(My.Resources.background)
        PutSprite(bg, Ryu, x, y)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Ryu = intro(indexIntro)

        If indexIntro > 7 Then
            Timer1.Enabled = False
            Timer2.Enabled = True
            doing = "walkR"
        End If

        indexIntro = indexIntro + 1

        ReDraw()
        pbcanvas.Image = bg
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If doing = "walkL" Then
            Ryu = standL(indexStandL)
            indexStandL = indexStandL + 1

        ElseIf doing = "walkR" Then
            Ryu = standR(indexStandR)
            indexStandR = indexStandR + 1

        ElseIf doing = "crouch" Then
            Ryu = crouch(indexCrouch)
            indexCrouch = indexCrouch + 1
            If indexCrouch > 3 Then y = 158

        ElseIf doing = "jump" Then
            Ryu = jump(indexJump)
            indexJump = indexJump + 1
            If indexJump = 2 Then y = y - 10
            If indexJump = 3 Or indexJump = 4 Or indexJump = 6 Then y = y - 15
            If indexJump = 5 Then y = y - 20
            If indexJump = 7 Then y = 130
            If indexJump > 7 Then
                doing = "walkR"
                indexJump = 0
            End If

        ElseIf doing = "jumpR" Then
            Ryu = jump(indexJump)
            indexJump = indexJump + 1
            If indexJump = 2 Or indexJump = 3 Then
                x = x + 5
                y = y - 10
            End If
            If indexJump = 4 Or indexJump = 5 Then
                x = x + 10
                y = y - 15
            End If
            If indexJump = 6 Then
                x = x + 15
                y = y - 20
            End If
            If indexJump = 7 Then
                x = x + 20
                y = 130
            End If
            If indexJump > 7 Then
                doing = "walkR"
                indexJump = 0
            End If

        ElseIf doing = "jumpL" Then
            Ryu = jumpL(indexJumpL)
            indexJumpL = indexJumpL + 1
            If indexJumpL = 2 Or indexJumpL = 3 Then
                x = x - 5
                y = y - 10
            End If
            If indexJumpL = 4 Or indexJumpL = 5 Then
                x = x - 10
                y = y - 15
            End If
            If indexJumpL = 6 Then
                x = x - 15
                y = y - 20
            End If
            If indexJumpL = 7 Then
                x = x - 20
                y = 130
            End If
            If indexJumpL > 7 Then
                doing = "walkL"
                indexJumpL = 0
            End If
        End If

        ReDraw()
        pbcanvas.Image = bg

        If indexStandR > 3 Then
            indexStandR = 0
        ElseIf indexStandL > 3 Then
            indexStandL = 0
        End If

        If indexCrouch > 6 Then
            indexCrouch = 4
        End If

    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub
    Private Sub PbPlay_Click(sender As Object, e As EventArgs) Handles PbPlay.Click
        PbPlay.Hide()
        Timer1.Start()
        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.standR0

        PutSprite(bg, Ryu, x, y)
    End Sub
    Private Sub PbExit_Click(sender As Object, e As EventArgs) Handles Pbexit.Click
        My.Computer.Audio.Stop()
        Timer2.Stop()
        Close()
    End Sub
End Class