﻿Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PbPlay = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Pbexit = New System.Windows.Forms.PictureBox()
        Me.pbcanvas = New System.Windows.Forms.PictureBox()
        Me.restart = New System.Windows.Forms.PictureBox()
        CType(Me.PbPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbexit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbcanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.restart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 5
        '
        'PbPlay
        '
        Me.PbPlay.Image = Global.Street_Fighter.My.Resources.Resources.btnPlay
        Me.PbPlay.Location = New System.Drawing.Point(179, 205)
        Me.PbPlay.Name = "PbPlay"
        Me.PbPlay.Size = New System.Drawing.Size(293, 103)
        Me.PbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PbPlay.TabIndex = 5
        Me.PbPlay.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Street_Fighter.My.Resources.Resources.SF_logo
        Me.PictureBox2.Location = New System.Drawing.Point(239, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(181, 76)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Pbexit
        '
        Me.Pbexit.Image = Global.Street_Fighter.My.Resources.Resources._exit
        Me.Pbexit.Location = New System.Drawing.Point(649, 1)
        Me.Pbexit.Name = "Pbexit"
        Me.Pbexit.Size = New System.Drawing.Size(45, 39)
        Me.Pbexit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pbexit.TabIndex = 3
        Me.Pbexit.TabStop = False
        '
        'pbcanvas
        '
        Me.pbcanvas.Location = New System.Drawing.Point(35, 83)
        Me.pbcanvas.Name = "pbcanvas"
        Me.pbcanvas.Size = New System.Drawing.Size(620, 339)
        Me.pbcanvas.TabIndex = 0
        Me.pbcanvas.TabStop = False
        '
        'restart
        '
        Me.restart.Image = Global.Street_Fighter.My.Resources.Resources.btnPlay
        Me.restart.Location = New System.Drawing.Point(275, 353)
        Me.restart.Name = "restart"
        Me.restart.Size = New System.Drawing.Size(112, 56)
        Me.restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.restart.TabIndex = 6
        Me.restart.TabStop = False
        Me.restart.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(696, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.restart)
        Me.Controls.Add(Me.PbPlay)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Pbexit)
        Me.Controls.Add(Me.pbcanvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Street Fighter"
        CType(Me.PbPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbexit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbcanvas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.restart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbcanvas As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Pbexit As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PbPlay As PictureBox
    Friend WithEvents restart As PictureBox
End Class
