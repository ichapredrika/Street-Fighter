﻿Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    'sprites
    Private bg, Ryu, hdk, obsR, obsL, intro(9), standR(4), standL(4), crouchL(5), crouchR(5), jumpL(7), jumpR(7),
        JumpFR(9), jumpFL(9), hdkL(6), hdkR(6), deadR(7), deadL(7), beeL(6), beeR(6), punchL(3), punchR(3),
        punchCR(3), punchCL(3), kickR(8), kickL(8), beeDL(7), beeDR(7), win(3), hdR(4), hdL(4) As Bitmap

    'index of activity
    Private indexIntro, indexStandR, indexStandL, indexCrouch, indexJumpL, indexJumpR, indexJumpFR, indexJumpFL,
        indexDeadL, indexDeadR, indexBeeR, indexBeeL, indexHdkL, indexHdkR, indexPunchL, indexPunchR,
        indexpunchCL, indexPunchCR, indexKickL, indexKickR, indexBeeDL, indexBeeDR, indexWin,
        indexHdR, indexHdL As Integer

    'what Ryu is doing
    Private doing As String

    'Determine whether Ryu attacks or not
    Private attack As Boolean
    Private hadouken As String

    'Determine whether Bee is attacked
    Private attacked As Boolean
    Private count As Integer = 0

    'where Ryu is facing
    Private facing As String

    'direction of bee
    Private BeeDir As String

    'phase
    Private phase As String

    'not used-----
    Private DLEFT As String = "LEFT"
    Private DRIGHT As String = "RIGHT"
    Private Direction As String = "DRIGHT"

    'location of Ryu
    Dim Rx As Integer = 280
    Dim Ry As Integer = 130

    'location of hadouken ball
    Dim hx As Integer = Rx
    Dim hy As Integer

    'ryu box
    Public RyuBox As List(Of Point) = New List(Of Point)

    'ryu attack box
    Public RyuAttack As List(Of Point) = New List(Of Point)
    Public RyuFireball As List(Of Point) = New List(Of Point)

    'not used-----Enemies
    Public EnemiesR As List(Of Bitmap) = New List(Of Bitmap)
    Public EnemiesL As List(Of Bitmap) = New List(Of Bitmap)

    'Enemies box
    Public EnemiesBoxFromRight As List(Of List(Of Point)) = New List(Of List(Of Point))
    Public EnemiesBoxFromLeft As List(Of List(Of Point)) = New List(Of List(Of Point))

    'diff
    Public DIFF As Integer = 1
    Public MaxEnemies As Integer = 1
    Public TempMaxEnemies As Integer

    'init sprite
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
    Sub SetCrouchR()
        crouchR(0) = My.Resources.crouchR0
        crouchR(1) = My.Resources.crouchR1
        crouchR(2) = My.Resources.crouchR2
        crouchR(3) = My.Resources.crouchR3
        crouchR(4) = My.Resources.crouchR3
    End Sub
    Sub SetCrouchL()
        crouchL(0) = My.Resources.crouchL0
        crouchL(1) = My.Resources.crouchL1
        crouchL(2) = My.Resources.crouchL2
        crouchL(3) = My.Resources.crouchL3
        crouchL(4) = My.Resources.crouchL3
    End Sub
    Sub SetJumpL()
        jumpL(0) = My.Resources.jumpL0
        jumpL(1) = My.Resources.jumpL1
        jumpL(2) = My.Resources.jumpL2
        jumpL(3) = My.Resources.jumpL3
        jumpL(4) = My.Resources.jumpL4
        jumpL(5) = My.Resources.jumpL5
        jumpL(6) = My.Resources.jumpL6
    End Sub
    Sub SetJumpR()
        jumpR(0) = My.Resources.jumpR0
        jumpR(1) = My.Resources.jumpR1
        jumpR(2) = My.Resources.jumpR1
        jumpR(3) = My.Resources.jumpR2
        jumpR(4) = My.Resources.jumpR4
        jumpR(5) = My.Resources.jumpR5
        jumpR(6) = My.Resources.jumpR6
    End Sub
    Sub SetJumpFR()
        JumpFR(0) = My.Resources.jumpF0
        JumpFR(1) = My.Resources.jumpF1
        JumpFR(2) = My.Resources.jumpF2
        JumpFR(3) = My.Resources.jumpF3
        JumpFR(4) = My.Resources.jumpF4
        JumpFR(5) = My.Resources.jumpF5
        JumpFR(6) = My.Resources.jumpF6
        JumpFR(7) = My.Resources.jumpF7
        JumpFR(8) = My.Resources.jumpF8
    End Sub
    Sub SetJumpFL()
        jumpFL(0) = My.Resources.jumpFL0
        jumpFL(1) = My.Resources.jumpFL1
        jumpFL(2) = My.Resources.jumpFL2
        jumpFL(3) = My.Resources.jumpFL3
        jumpFL(4) = My.Resources.jumpFL4
        jumpFL(5) = My.Resources.jumpFL5
        jumpFL(6) = My.Resources.jumpFL6
        jumpFL(7) = My.Resources.jumpFL7
        jumpFL(8) = My.Resources.jumpFL8
    End Sub
    Sub SethdkL()
        hdkL(0) = My.Resources.hdkL0
        hdkL(1) = My.Resources.hdkL1
        hdkL(2) = My.Resources.hdkL2
        hdkL(3) = My.Resources.hdkL3
        hdkL(4) = My.Resources.hdkL4
        hdkL(5) = My.Resources.hdkL4
    End Sub
    Sub SethdkR()
        hdkR(0) = My.Resources.hdkR0
        hdkR(1) = My.Resources.hdkR1
        hdkR(2) = My.Resources.hdkR2
        hdkR(3) = My.Resources.hdkR3
        hdkR(4) = My.Resources.hdkR4
        hdkR(5) = My.Resources.hdkR4
    End Sub
    Sub SethdL()
        hdL(0) = My.Resources.hdL0
        hdL(1) = My.Resources.hdL1
        hdL(2) = My.Resources.hdL2
        hdL(3) = My.Resources.hdL3
    End Sub
    Sub SethdR()
        hdR(0) = My.Resources.hd0
        hdR(1) = My.Resources.hd1
        hdR(2) = My.Resources.hd2
        hdR(3) = My.Resources.hd3
    End Sub

    Sub SetPunchL()
        punchL(0) = My.Resources.punchL0
        punchL(1) = My.Resources.punchL1
        punchL(2) = My.Resources.punchL2
    End Sub

    Sub SetPunchR()
        punchR(0) = My.Resources.punchR2
        punchR(1) = My.Resources.punchR1
        punchR(2) = My.Resources.punchR0
    End Sub

    Sub SetPunchCL()
        punchCL(0) = My.Resources.punchCL0
        punchCL(1) = My.Resources.punchCL1
        punchCL(2) = My.Resources.punchCL2
    End Sub

    Sub SetPunchCR()
        punchCR(0) = My.Resources.punchCR2
        punchCR(1) = My.Resources.punchCR1
        punchCR(2) = My.Resources.punchCR0
    End Sub

    Sub SetKickL()
        kickL(0) = My.Resources.kickL0
        kickL(1) = My.Resources.kickL1
        kickL(2) = My.Resources.kickL2
        kickL(3) = My.Resources.kickL3
        kickL(4) = My.Resources.kickL4
        kickL(5) = My.Resources.kickL5
        kickL(6) = My.Resources.kickL6
        kickL(7) = My.Resources.kickL7
    End Sub

    Sub SetKickR()
        kickR(0) = My.Resources.kick0
        kickR(1) = My.Resources.kick1
        kickR(2) = My.Resources.kick2
        kickR(3) = My.Resources.kick3
        kickR(4) = My.Resources.kick4
        kickR(5) = My.Resources.kick5
        kickR(6) = My.Resources.kick6
        kickR(7) = My.Resources.kick7
    End Sub

    Sub SetDeadR()
        deadR(0) = My.Resources.dead0
        deadR(1) = My.Resources.dead1
        deadR(2) = My.Resources.dead2
        deadR(3) = My.Resources.dead3
        deadR(4) = My.Resources.dead4
        deadR(5) = My.Resources.dead5
        deadR(6) = My.Resources.dead5
    End Sub
    Sub SetDeadL()
        deadL(0) = My.Resources.deadL0
        deadL(1) = My.Resources.deadL1
        deadL(2) = My.Resources.deadL2
        deadL(3) = My.Resources.deadL3
        deadL(4) = My.Resources.deadL4
        deadL(5) = My.Resources.deadL5
        deadL(6) = My.Resources.deadL5
    End Sub
    Sub SetWin()
        win(0) = My.Resources.win0
        win(1) = My.Resources.win1
        win(2) = My.Resources.win2
    End Sub
    Sub SetBeeL()
        beeL(0) = My.Resources.bee0
        beeL(1) = My.Resources.bee1
        beeL(2) = My.Resources.bee2
        beeL(3) = My.Resources.bee3
        beeL(4) = My.Resources.bee4
        beeL(5) = My.Resources.bee5
    End Sub

    Sub SetBeeR()
        beeR(0) = My.Resources.beeR0
        beeR(1) = My.Resources.beeR1
        beeR(2) = My.Resources.beeR2
        beeR(3) = My.Resources.beeR3
        beeR(4) = My.Resources.beeR4
        beeR(5) = My.Resources.beeR5
    End Sub

    Sub SetBeeDL()
        beeDL(0) = My.Resources.beedl0
        beeDL(1) = My.Resources.beedl1
        beeDL(2) = My.Resources.beedl2
        beeDL(3) = My.Resources.beedl3
        beeDL(4) = My.Resources.beedl4
        beeDL(5) = My.Resources.beedl5
        beeDL(6) = My.Resources.beedl6
    End Sub

    Sub SetBeeDR()
        beeDR(0) = My.Resources.bee0
        beeDR(1) = My.Resources.bee1
        beeDR(2) = My.Resources.bee2
        beeDR(3) = My.Resources.bee3
        beeDR(4) = My.Resources.bee4
        beeDR(5) = My.Resources.beeR5
        beeDR(5) = My.Resources.bee5
    End Sub

    Sub PutSprite(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim mask, sprite As Bitmap
        mask = MaskOf(d)
        sprite = SpriteOf(d)
        Spriteand(bg, mask, x, y)
        Spriteor(bg, sprite, x, y)

    End Sub

    Function MaskOf(b As Bitmap) As Bitmap
        'Bg = white, sprite = black
        Dim a As Bitmap
        Dim c As Color
        Dim i, j As Integer

        'convert by cloning
        a = CType(b.Clone, Bitmap)
        c = a.GetPixel(0, 0) ' color of bg of sprite
        'scan down
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

        a = CType(b.Clone, Bitmap)
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
        'bg, mask
        'set sprite on the bg to be black using and operation 
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                If i + x < bg.Width And i + x > 0 And j + y < bg.Height And j + y > 0 Then
                    a = c.GetPixel(i + x, j + y).A And d.GetPixel(i, j).A
                    r = c.GetPixel(i + x, j + y).R And d.GetPixel(i, j).R
                    g = c.GetPixel(i + x, j + y).G And d.GetPixel(i, j).G
                    b = c.GetPixel(i + x, j + y).B And d.GetPixel(i, j).B
                    c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
                End If
            Next
        Next

    End Sub

    Sub Spriteor(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        'bg, sprite
        'give color to the black sprite using or operation bcs d is sprite
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                If i + x < bg.Width And i + x > 0 And j + y < bg.Height And j + y > 0 Then
                    a = c.GetPixel(i + x, j + y).A Or d.GetPixel(i, j).A
                    r = c.GetPixel(i + x, j + y).R Or d.GetPixel(i, j).R
                    g = c.GetPixel(i + x, j + y).G Or d.GetPixel(i, j).G
                    b = c.GetPixel(i + x, j + y).B Or d.GetPixel(i, j).B
                    c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
                End If
            Next
        Next
    End Sub

    'Init while the program start
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayLoopingBackgroundSoundFile()
        indexIntro = 0
        indexStandR = 0
        indexStandR = 0
        indexCrouch = 0
        indexJumpL = 0
        indexJumpR = 0
        indexBeeL = 0
        indexBeeR = 0
        indexHdkR = 0
        indexHdkL = 0
        indexHdL = 0
        indexHdR = 0
        indexDeadL = 0
        indexDeadR = 0
        indexJumpL = 0
        indexJumpR = 0
        indexPunchL = 0
        indexPunchR = 0
        indexPunchCR = 0
        indexpunchCL = 0
        indexKickL = 0
        indexKickR = 0
        indexBeeDL = 0
        indexBeeDR = 0
        indexWin = 0

        SetIntro()
        SetStandR()
        SetStandL()
        SetCrouchL()
        SetCrouchR()
        SetJumpL()
        SetJumpR()
        SetJumpFR()
        SetJumpFL()
        SetBeeL()
        SetBeeR()
        SethdkR()
        SethdkL()
        SethdL()
        SethdR()
        SetPunchL()
        SetPunchR()
        SetPunchCL()
        SetPunchCR()
        SetKickR()
        SetKickL()
        SetDeadL()
        SetDeadR()
        SetBeeDL()
        SetBeeDR()
        SetWin()

        Timer1.Interval = 75

        'test
        'init new enemy

        bg = My.Resources.background
        pbcanvas.Image = bg

        If doing = "walkR" Then facing = "right"
        If doing = "walkL" Then facing = "left"

    End Sub

    'audio
    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play(My.Resources.sfmusic, AudioPlayMode.BackgroundLoop)
    End Sub

    'exception condition
    Function Conditions() As Boolean
        If doing IsNot "jumpL" Xor doing IsNot "jumpR" Xor doing IsNot "jumpFL" Xor doing IsNot "jumpFR" Xor doing IsNot "crouch" Then
            Return True
        End If
        Return False
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            If Conditions() Then
                doing = "walkL"
                facing = "left"
            End If
            If doing = "crouch" Then
                doing = "crouch"
                facing = "left"
            End If
            If (Rx >= 20) Then
                'MoveRyuSpriteAndBox(-10, 0)
                Rx = Rx - 10
            End If

        ElseIf e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            If Conditions() Then
                doing = "walkR"
                facing = "right"
            End If
            If doing = "crouch" Then
                doing = "crouch"
                facing = "right"
            End If
            If (Rx <= 490) Then
                'MoveRyuSpriteAndBox(10, 0)
                Rx = Rx + 10
            End If
        End If

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            If Conditions() Then doing = "crouch"
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            If Conditions() Then
                doing = "jump"
            End If
            If doing = "crouch" Then
                If facing = "left" Then
                    Ry = 130
                    doing = "walkL"
                ElseIf facing = "right" Then
                    Ry = 130
                    doing = "walkR"
                End If
            End If
        End If
        '20 550
        If e.KeyCode = Keys.End Or e.KeyCode = Keys.E Then
            If Conditions() Then
                If Rx >= 470 Then
                    doing = "jump"
                Else
                    doing = "jumpFR"
                End If
            End If
        End If

        If e.KeyCode = Keys.Q Or e.KeyCode = Keys.ShiftKey Then
            If Conditions() Then
                If Rx <= 40 Then
                    doing = "jump"
                Else
                    doing = "jumpFL"
                End If
            End If
        End If

        If e.KeyCode = Keys.CapsLock Then
            If doing = "walkR" Or doing = "walkL" Then doing = "hadouken"
        End If

        If e.KeyCode = Keys.Tab Then
            attack = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If phase = "intro" Then
            Ryu = intro(indexIntro)
            indexIntro = indexIntro + 1
            If indexIntro > 8 Then
                phase = "play"
                doing = "walkR"
                facing = "right"
            End If

        ElseIf phase = "play" Then
            MoveAllEnemies()
            'walks to left side
            If doing = "walkL" Then
                Ryu = standL(indexStandL)
                indexStandL = indexStandL + 1
                If attack = True Then
                    Ryu = punchL(indexPunchL)
                    indexPunchL = indexPunchL + 1
                    If indexPunchL > 2 Then
                        doing = "walkL"
                        indexPunchL = 0
                        attack = False
                    End If
                End If

                'walks to right side
            ElseIf doing = "walkR" Then
                Ryu = standR(indexStandR)
                indexStandR = indexStandR + 1
                If attack = True Then
                    Ryu = punchR(indexPunchR)
                    indexPunchR = indexPunchR + 1
                    If indexPunchR > 2 Then
                        doing = "walkR"
                        indexPunchR = 0
                        attack = False
                    End If
                End If
                'crouchs
            ElseIf doing = "crouch" Then
                'crouchs facing right
                If facing = "right" Then
                    Ryu = crouchR(indexCrouch)
                    indexCrouch = indexCrouch + 1
                    If attack = True Then
                        Ryu = punchCR(indexPunchCR)
                        indexPunchCR = indexPunchCR + 1
                        If indexPunchCR > 2 Then
                            doing = "crouch"
                            indexPunchCR = 0
                            attack = False
                        End If
                    End If
                    'crouchs facing right
                ElseIf facing = "left" Then
                    Ryu = crouchL(indexCrouch)
                    indexCrouch = indexCrouch + 1
                    If attack = True Then
                        Ryu = punchCL(indexpunchCL)
                        indexpunchCL = indexpunchCL + 1
                        If indexpunchCL = 2 Then Rx = Rx - 20
                        If indexpunchCL > 2 Then
                            doing = "crouch"
                            indexpunchCL = 0
                            attack = False
                            Rx = Rx + 20
                        End If

                    End If
                End If
                If indexCrouch > 4 Then
                    Ry = 158
                    indexCrouch = 3
                End If

                'jumps 
            ElseIf doing = "jump" Then
                'jumps facing right
                If facing = "right" Then
                    Ryu = jumpR(indexJumpR)
                    indexJumpR = indexJumpR + 1
                    If attack = True Then
                        Ryu = kickR(indexKickR)
                        indexKickR = indexKickR + 1
                        Rx = Rx + 5

                        If indexKickR > 7 Then
                            doing = "walkR"
                            indexKickR = 0
                            indexJumpR = 0
                            attack = False
                        End If
                    End If
                    If indexJumpR = 0 Or indexJumpR = 6 Then Ry = 130
                    If indexJumpR = 1 Or indexJumpR = 5 Then Ry = Ry - 13
                    If indexJumpR = 2 Or indexJumpR = 4 Then Ry = Ry - 26
                    If indexJumpR = 3 Then Ry = Ry - 39
                    If indexJumpR > 6 Then
                        doing = "walkR"
                        indexJumpR = 0
                    End If

                    'jumps facing left
                ElseIf facing = "left" Then
                    Ryu = jumpL(indexJumpL)
                    indexJumpL = indexJumpL + 1
                    If attack = True Then
                        Ryu = kickL(indexKickL)
                        indexKickL = indexKickL + 1
                        Rx = Rx - 5
                        If indexKickL > 7 Then
                            doing = "walkL"
                            indexKickL = 0
                            indexJumpL = 0
                            attack = False
                        End If
                    End If
                    If indexJumpL = 0 Or indexJumpL = 6 Then Ry = 130
                    If indexJumpL = 1 Or indexJumpL = 5 Then Ry = Ry - 13
                    If indexJumpL = 2 Or indexJumpL = 4 Then Ry = Ry - 26
                    If indexJumpL = 3 Then Ry = Ry - 39
                    If indexJumpL > 6 Then
                        doing = "walkL"
                        indexJumpL = 0
                    End If
                End If

                'jumps forward to right side
            ElseIf doing = "jumpFR" Then
                Ryu = JumpFR(indexJumpFR)
                indexJumpFR = indexJumpFR + 1
                If indexJumpFR = 2 Or indexJumpFR = 3 Then
                    Rx = Rx + 10
                    Ry = Ry - 10
                End If
                If indexJumpFR = 4 Or indexJumpFR = 5 Then
                    Rx = Rx + 20
                    Ry = Ry - 15
                End If
                If indexJumpFR = 6 Then
                    Rx = Rx + 25
                    Ry = Ry - 20
                End If
                If indexJumpFR = 7 Then
                    Rx = Rx + 30
                    Ry = 130
                End If
                If indexJumpFR = 8 Then
                    Rx = Rx + 32
                    Ry = 130
                End If
                If indexJumpFR > 8 Then
                    doing = "walkR"
                    indexJumpFR = 0
                End If

                'jumps forward to left side
            ElseIf doing = "jumpFL" Then
                Ryu = jumpFL(indexJumpFL)
                indexJumpFL = indexJumpFL + 1
                If indexJumpFL = 2 Or indexJumpFL = 3 Then
                    Rx = Rx - 10
                    Ry = Ry - 10
                End If
                If indexJumpFL = 4 Or indexJumpFL = 5 Then
                    Rx = Rx - 20
                    Ry = Ry - 15
                End If
                If indexJumpFL = 6 Then
                    Rx = Rx - 25
                    Ry = Ry - 20
                End If
                If indexJumpFL = 7 Then
                    Rx = Rx - 30
                    Ry = 130
                End If
                If indexJumpFL = 7 Then
                    Rx = Rx - 32
                    Ry = 130
                End If
                If indexJumpFL > 8 Then
                    doing = "walkL"
                    indexJumpFL = 0
                End If

                'hadouken
            ElseIf doing = "hadouken" Then
                'hadouken left
                If facing = "left" Then
                    Ryu = hdkL(indexHdkL)
                    indexHdkL = indexHdkL + 1
                    If indexHdkL > 5 Then
                        hadouken = "hadouken left"
                        indexHdkL = 0
                        doing = "walkL"
                    End If
                End If
                'hadouken right
                If facing = "right" Then
                    Ryu = hdkR(indexHdkR)
                    indexHdkR = indexHdkR + 1
                    If indexHdkR > 5 Then
                        hadouken = "hadouken right"
                        indexHdkR = 0
                        doing = "walkR"
                    End If
                End If


                obsL = beeL(indexBeeL)

                If indexBeeL >= 5 Then
                    indexBeeL = 0
                Else
                    indexBeeL = indexBeeL + 1
                End If

                obsR = beeR(indexBeeL)
                If indexBeeR >= 5 Then
                    indexBeeR = 0
                Else
                    indexBeeR = indexBeeR + 1
                End If
            End If

        End If

        If hadouken = "hadouken left" Then
            If indexHdL = 0 Then hx = hx - 10
            hdk = hdL(indexHdL)
            indexHdL = indexHdL + 1
            hy = Ry
            hx = hx - 20

            If indexHdL > 3 Then indexHdL = 2
            If hx <= 20 Then
                hadouken = "nothing"
                RyuFireball = New List(Of Point)
                hx = Rx
                indexHdL = 0
            End If
        ElseIf hadouken = "hadouken right" Then
            If indexHdR = 0 Then hx = hx + 60
            hdk = hdR(indexHdR)
            indexHdR = indexHdR + 1

            hy = Ry
            hx = hx + 20

            If indexHdR > 3 Then indexHdR = 2
            If hx >= 550 Then
                hadouken = "nothing"
                RyuFireball = New List(Of Point)
                hx = Rx
                indexHdR = 0
            End If

        ElseIf phase = "end" Then
            'dead
            If doing = "dead" Then
                'facing left
                If facing = "left" Then
                    Ryu = deadL(indexDeadL)
                    indexDeadL = indexDeadL + 1
                    If indexDeadL > 5 Then

                        Rx = 200
                        Ry = 30
                        Ryu = My.Resources.game_over
                        Timer1.Enabled = False
                        restart.Show()
                    End If

                ElseIf facing = "right" Then
                    'facing right
                    Ryu = deadR(indexDeadR)
                    indexDeadR = indexDeadR + 1
                    If indexDeadR > 5 Then
                        'Rx = 200
                        'Ry = 100
                        Ryu = My.Resources.game_over
                        Timer1.Enabled = False
                        restart.Show()
                    End If
                End If
            End If
            'win
        ElseIf phase = "win" Then
            Ryu = win(indexWin)
            indexWin = indexWin + 1
            If indexWin > 2 Then
                'Rx = 200
                'Ry = 100
                Ryu = My.Resources.win
                Timer1.Enabled = False
                restart.Show()
            End If
        End If

        ReDraw()
        pbcanvas.Image = bg
        pbcanvas.Invalidate()
        BoxsCheck()

        If indexStandR > 3 Then
            indexStandR = 0
        ElseIf indexStandL > 3 Then
            indexStandL = 0
        End If
    End Sub

    Private Sub PbPlay_Click(sender As Object, e As EventArgs) Handles PbPlay.Click
        PbPlay.Hide()
        Timer1.Start()
        phase = "intro"
        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.standR0
        obsL = My.Resources.bee0
        obsR = My.Resources.beeR0
    End Sub

    Private Sub PbExit_Click(sender As Object, e As EventArgs) Handles Pbexit.Click
        My.Computer.Audio.Stop()
        Close()
    End Sub

    Sub ReDraw()
        bg = New Bitmap(My.Resources.background)

        If Ryu IsNot Nothing Then
            PutSprite(bg, Ryu, Rx, Ry)
            RyuBox = CreateBox(Rx + 10, Ry + 10, Ryu.Width - 20, Ryu.Height - 20)

        End If

        If hadouken = "hadouken left" Or hadouken = "hadouken right" Then
            If hdk IsNot Nothing Then
                PutSprite(bg, hdk, hx, hy)
                RyuFireball = CreateBox(hx, hy, hdk.Width, hdk.Height)
            End If
        End If

        If attack Then
            RyuAttack = New List(Of Point)
            If facing Is "left" Then
                RyuAttack = CreateBox(Rx - 20, Ry + 10, Ryu.Width, 20)
            ElseIf facing Is "right" Then
                RyuAttack = CreateBox(Rx, Ry + 10, Ryu.Width + 20, 20)
            End If
        Else
            RyuAttack = New List(Of Point)
        End If

        If phase = "play" Then
            'set level
            If MaxEnemies > 0 Then
                TempMaxEnemies = MaxEnemies
                If count Mod 5 = 0 And count > 0 Then
                    MaxEnemies = MaxEnemies * (count / 5)
                End If
                For i As Integer = 0 To MaxEnemies - 1
                    Dim X As Integer

                    If RandomEnemyY() Mod 2 = 0 Then
                        X = bg.Width - 20
                        EnemiesBoxFromRight.Add(CreateBox(X, RandomEnemyY(), beeDL(0).Width, beeDL(0).Height))
                    Else
                        X = -20
                        EnemiesBoxFromLeft.Add(CreateBox(X, RandomEnemyY(), beeDL(0).Width, beeDL(0).Height))
                    End If
                Next
                MaxEnemies = 0
            End If
            'draw enemy

            If EnemiesBoxFromRight.Count > 0 Then
                For Each enemy As List(Of Point) In EnemiesBoxFromRight
                    PutSprite(bg, obsL, enemy.First.X, enemy.First.Y)
                Next
            End If

            If EnemiesBoxFromLeft.Count > 0 Then
                For Each enemy As List(Of Point) In EnemiesBoxFromLeft
                    PutSprite(bg, obsR, enemy.First.X, enemy.First.Y)
                Next
            End If
        End If


    End Sub

    Private Sub restart_Click(sender As Object, e As EventArgs) Handles restart.Click
        EnemiesBoxFromLeft = New List(Of List(Of Point))
        EnemiesBoxFromRight = New List(Of List(Of Point))
        Rx = 280
        Ry = 130
        restart.Hide()
        phase = "play"
        doing = "walkR"
        facing = "right"
        MaxEnemies = 1
        Ryu = My.Resources.standR0
        obsL = My.Resources.bee0
        obsR = My.Resources.beeR0
        bg = My.Resources.background
        pbcanvas.Image = bg
        Timer1.Enabled = True

    End Sub

    'Creating box by single point
    Function CreateBox(X As Integer, Y As Integer, NX As Integer, NY As Integer) As List(Of Point)
        Dim TempPoint As Point
        Dim box As List(Of Point) = New List(Of Point)

        NX = X + NX
        NY = Y + NY

        TempPoint.X = X
        TempPoint.Y = Y
        box.Add(TempPoint)
        TempPoint.X = NX
        TempPoint.Y = Y
        box.Add(TempPoint)
        TempPoint.X = NX
        TempPoint.Y = NY
        box.Add(TempPoint)
        TempPoint.X = X
        TempPoint.Y = NY
        box.Add(TempPoint)
        Return box
    End Function

    'just for checking position with click the picture box
    Private Sub Pbcanvas_MouseClick(sender As Object, e As MouseEventArgs) Handles pbcanvas.MouseClick
        Console.WriteLine(e.Location)
    End Sub

    Private Sub Pbcanvas_Paint(sender As Object, e As PaintEventArgs) Handles pbcanvas.Paint
        If RyuBox.Count > 0 Then e.Graphics.DrawPolygon(Pens.Red, RyuBox.ToArray)

        If RyuAttack.Count > 0 Then e.Graphics.DrawPolygon(Pens.Yellow, RyuAttack.ToArray)

        If RyuFireball.Count > 0 Then e.Graphics.DrawPolygon(Pens.Yellow, RyuFireball.ToArray)

        For Each enemy As List(Of Point) In EnemiesBoxFromRight
            e.Graphics.DrawPolygon(Pens.Blue, enemy.ToArray)
        Next

        For Each enemy As List(Of Point) In EnemiesBoxFromLeft
            e.Graphics.DrawPolygon(Pens.Blue, enemy.ToArray)
        Next
    End Sub

    'box sprite move
    Function MoveBox(P As List(Of Point), x As Integer, y As Integer) As List(Of Point)
        Dim TempPoint As Point
        For index As Integer = 0 To P.Count - 1
            TempPoint = P(index)
            TempPoint.X = P(index).X + x
            TempPoint.Y = P(index).Y + y
            P(index) = TempPoint
        Next
        Return P
    End Function

    Function MoveEnemiesFrom(Enemies As List(Of List(Of Point)), X As Integer) As List(Of List(Of Point))
        For i As Integer = 0 To Enemies.Count - 1
            Enemies(i) = MoveBox(Enemies(i), X, 0)

            'if overlap
            Dim Temp = Enemies(i)
            If Temp(1).X >= bg.Width + 150 Then
                Enemies(i).RemoveAt(i)
                MaxEnemies = MaxEnemies + 1
                If i = 0 Then
                    Enemies = New List(Of List(Of Point))
                    Exit For
                End If
            End If

            If Temp(0).X < -150 Then
                Enemies(i).RemoveAt(i)
                MaxEnemies = MaxEnemies + 1
                If i = 0 Then
                    Enemies = New List(Of List(Of Point))
                    Exit For
                End If
            End If
        Next
        Return Enemies
    End Function

    Sub MoveAllEnemies()
        If EnemiesBoxFromLeft.Count > 0 Then EnemiesBoxFromLeft = MoveEnemiesFrom(EnemiesBoxFromLeft, 10)
        If EnemiesBoxFromRight.Count > 0 Then EnemiesBoxFromRight = MoveEnemiesFrom(EnemiesBoxFromRight, -10)
    End Sub

    'init random enemy coordinate
    Function RandomEnemyY() As Integer
        Return CInt(Math.Ceiling(Rnd() * 130)) + 50
    End Function

    'check box
    Function BoxsCheck() As Integer

        For i As Integer = 0 To EnemiesBoxFromLeft.Count - 1
            If i < EnemiesBoxFromLeft.Count Then
                If IsBoxClip(EnemiesBoxFromLeft(i), RyuBox) Then
                    Console.WriteLine("hit")
                    phase = "end"
                    doing = "dead"
                ElseIf IsBoxClip(EnemiesBoxFromLeft(i), RyuAttack) Or IsBoxClip(EnemiesBoxFromLeft(i), RyuFireball) Then
                    count = count + 1
                    If count = 20 Then phase = "win"
                    Console.WriteLine(count)
                    EnemiesBoxFromLeft.RemoveAt(i)
                    MaxEnemies = MaxEnemies + 1
                    i = i - 1
                    If EnemiesBoxFromLeft.Count - 1 < 0 Or i >= EnemiesBoxFromLeft.Count Then Exit For
                End If
            End If
        Next

        For i As Integer = 0 To EnemiesBoxFromRight.Count - 1
            If i < EnemiesBoxFromRight.Count Then
                If IsBoxClip(EnemiesBoxFromRight(i), RyuBox) Then
                    Console.WriteLine("hit")
                    phase = "end"
                    doing = "dead"
                ElseIf IsBoxClip(EnemiesBoxFromRight(i), RyuAttack) Or IsBoxClip(EnemiesBoxFromRight(i), RyuFireball) Then
                    count = count + 1
                    If count = 20 Then phase = "win"
                    Console.WriteLine(count)
                    EnemiesBoxFromRight.RemoveAt(i)
                    MaxEnemies = MaxEnemies + 1
                    i = i - 1
                    If EnemiesBoxFromRight.Count - 1 < 0 Or i >= EnemiesBoxFromRight.Count Then Exit For
                End If
            End If
        Next

    End Function

    Function IsBoxClip(Enemy As List(Of Point), Box As List(Of Point)) As Boolean
        Dim B, T As Integer
        Dim NP, NW As Point
        Dim IsAInside, IsBInside, TAisAcc, TBisAcc As Boolean

        'NewPolygon = New List(Of Point)()
        For A As Integer = 0 To Box.Count - 1
            B = NextPoint(A, Box.Count)

            For S As Integer = 0 To Enemy.Count - 1
                T = NextPoint(S, Enemy.Count)
                NW = Normal(Enemy(S), Enemy(T))
                NP = Normal(Box(A), Box(B))

                'Declare In Out
                IsAInside = InsidePoint(Enemy(S), Enemy(T), Box(B))
                IsBInside = InsidePoint(Enemy(S), Enemy(T), Box(A))

                If IsAInside = Not IsBInside Then
                    'Than In Out Validation
                    TAisAcc = TisAcc(Tis(Box(A), Box(B), Enemy(S), NW))
                    TBisAcc = TisAcc(Tis(Enemy(S), Enemy(T), Box(A), NP))
                    If TAisAcc And TBisAcc Then Return True
                End If
            Next
        Next
        Return False
    End Function

    Function NextPoint(Point As Integer, Total As Integer) As Integer
        If Point + 1 = Total Then Return 0
        Return Point + 1
    End Function

    Function Normal(WA As Point, WB As Point) As Point
        Dim N As Point
        N.X = WB.Y - WA.Y
        N.Y = WB.X - WA.X
        N.Y = N.Y * -1 'Clockwise
        Return N
    End Function

    Function InsidePoint(WA As Point, WB As Point, S As Point) As Boolean
        Dim N As Point
        Dim D As Point

        N = Normal(WA, WB)

        D.X = (S.X - WA.X) * N.X
        D.Y = (S.Y - WA.Y) * N.Y

        Dim result As Integer = D.Y + D.X
        If result >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Tis(A As Point, B As Point, P As Point, N As Point) As Double
        Return ((((P.X - A.X) * N.X) + ((P.Y - A.Y) * N.Y)) / (((B.X - A.X) * N.X) + ((B.Y - A.Y) * N.Y))) * 1.0
    End Function

    Function TisAcc(X As Double) As Boolean
        If X >= 0 And X <= 1 Then Return True
        Return False
    End Function
End Class