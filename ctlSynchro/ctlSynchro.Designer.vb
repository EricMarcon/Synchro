<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctlSynchro
    Inherits System.Windows.Forms.UserControl

    ''' <summary>
    ''' Control disposing.
    ''' </summary>
    ''' <param name="disposing">Indicates whether your code initiated the object's disposal.</param>
    ''' <remarks>Form overrides dispose to clean up the component list.</remarks>
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pgbSynchro = New System.Windows.Forms.ProgressBar
        Me.CgAnimation1 = New CG.Animation.CGAnimation
        Me.SuspendLayout()
        '
        'pgbSynchro
        '
        Me.pgbSynchro.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbSynchro.Location = New System.Drawing.Point(0, 64)
        Me.pgbSynchro.Name = "pgbSynchro"
        Me.pgbSynchro.Size = New System.Drawing.Size(344, 32)
        Me.pgbSynchro.TabIndex = 0
        '
        'CgAnimation1
        '
        Me.CgAnimation1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CgAnimation1.FileName = Nothing
        Me.CgAnimation1.Location = New System.Drawing.Point(0, 0)
        Me.CgAnimation1.Name = "CgAnimation1"
        Me.CgAnimation1.Size = New System.Drawing.Size(344, 60)
        Me.CgAnimation1.TabIndex = 1
        Me.CgAnimation1.TabStop = False
        Me.CgAnimation1.Text = "CgAnimation1"
        Me.CgAnimation1.Visible = False
        '
        'ctlSynchro
        '
        Me.Controls.Add(Me.pgbSynchro)
        Me.Controls.Add(Me.CgAnimation1)
        Me.Name = "ctlSynchro"
        Me.Size = New System.Drawing.Size(344, 96)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CgAnimation1 As CG.Animation.CGAnimation
    Public WithEvents pgbSynchro As System.Windows.Forms.ProgressBar

End Class
