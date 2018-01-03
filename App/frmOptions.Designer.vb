<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptions))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.gpbRestart = New System.Windows.Forms.GroupBox
        Me.numRecentLength = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbRefreshFrequency = New System.Windows.Forms.TrackBar
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbRestart.SuspendLayout()
        CType(Me.numRecentLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbRefreshFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = resources.GetString("btnCancel.AccessibleDescription")
        Me.btnCancel.AccessibleName = resources.GetString("btnCancel.AccessibleName")
        Me.btnCancel.Anchor = CType(resources.GetObject("btnCancel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = CType(resources.GetObject("btnCancel.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCancel.Enabled = CType(resources.GetObject("btnCancel.Enabled"), Boolean)
        Me.btnCancel.FlatStyle = CType(resources.GetObject("btnCancel.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCancel.Font = CType(resources.GetObject("btnCancel.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.btnCancel, resources.GetString("btnCancel.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.btnCancel, CType(resources.GetObject("btnCancel.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnCancel, resources.GetString("btnCancel.HelpString"))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = CType(resources.GetObject("btnCancel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCancel.ImageIndex = CType(resources.GetObject("btnCancel.ImageIndex"), Integer)
        Me.btnCancel.ImeMode = CType(resources.GetObject("btnCancel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCancel.Location = CType(resources.GetObject("btnCancel.Location"), System.Drawing.Point)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = CType(resources.GetObject("btnCancel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.btnCancel, CType(resources.GetObject("btnCancel.ShowHelp"), Boolean))
        Me.btnCancel.Size = CType(resources.GetObject("btnCancel.Size"), System.Drawing.Size)
        Me.btnCancel.TabIndex = CType(resources.GetObject("btnCancel.TabIndex"), Integer)
        Me.btnCancel.Text = resources.GetString("btnCancel.Text")
        Me.btnCancel.TextAlign = CType(resources.GetObject("btnCancel.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.btnCancel, resources.GetString("btnCancel.ToolTip"))
        Me.btnCancel.Visible = CType(resources.GetObject("btnCancel.Visible"), Boolean)
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = resources.GetString("btnOK.AccessibleDescription")
        Me.btnOK.AccessibleName = resources.GetString("btnOK.AccessibleName")
        Me.btnOK.Anchor = CType(resources.GetObject("btnOK.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Dock = CType(resources.GetObject("btnOK.Dock"), System.Windows.Forms.DockStyle)
        Me.btnOK.Enabled = CType(resources.GetObject("btnOK.Enabled"), Boolean)
        Me.btnOK.FlatStyle = CType(resources.GetObject("btnOK.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnOK.Font = CType(resources.GetObject("btnOK.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.btnOK, resources.GetString("btnOK.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.btnOK, CType(resources.GetObject("btnOK.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnOK, resources.GetString("btnOK.HelpString"))
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = CType(resources.GetObject("btnOK.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnOK.ImageIndex = CType(resources.GetObject("btnOK.ImageIndex"), Integer)
        Me.btnOK.ImeMode = CType(resources.GetObject("btnOK.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnOK.Location = CType(resources.GetObject("btnOK.Location"), System.Drawing.Point)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = CType(resources.GetObject("btnOK.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.btnOK, CType(resources.GetObject("btnOK.ShowHelp"), Boolean))
        Me.btnOK.Size = CType(resources.GetObject("btnOK.Size"), System.Drawing.Size)
        Me.btnOK.TabIndex = CType(resources.GetObject("btnOK.TabIndex"), Integer)
        Me.btnOK.Text = resources.GetString("btnOK.Text")
        Me.btnOK.TextAlign = CType(resources.GetObject("btnOK.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.btnOK, resources.GetString("btnOK.ToolTip"))
        Me.btnOK.Visible = CType(resources.GetObject("btnOK.Visible"), Boolean)
        '
        'gpbRestart
        '
        Me.gpbRestart.AccessibleDescription = resources.GetString("gpbRestart.AccessibleDescription")
        Me.gpbRestart.AccessibleName = resources.GetString("gpbRestart.AccessibleName")
        Me.gpbRestart.Anchor = CType(resources.GetObject("gpbRestart.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gpbRestart.BackgroundImage = CType(resources.GetObject("gpbRestart.BackgroundImage"), System.Drawing.Image)
        Me.gpbRestart.Controls.Add(Me.numRecentLength)
        Me.gpbRestart.Controls.Add(Me.Label2)
        Me.gpbRestart.Dock = CType(resources.GetObject("gpbRestart.Dock"), System.Windows.Forms.DockStyle)
        Me.gpbRestart.Enabled = CType(resources.GetObject("gpbRestart.Enabled"), Boolean)
        Me.gpbRestart.Font = CType(resources.GetObject("gpbRestart.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.gpbRestart, resources.GetString("gpbRestart.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.gpbRestart, CType(resources.GetObject("gpbRestart.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.gpbRestart, resources.GetString("gpbRestart.HelpString"))
        Me.gpbRestart.ImeMode = CType(resources.GetObject("gpbRestart.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gpbRestart.Location = CType(resources.GetObject("gpbRestart.Location"), System.Drawing.Point)
        Me.gpbRestart.Name = "gpbRestart"
        Me.gpbRestart.RightToLeft = CType(resources.GetObject("gpbRestart.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.gpbRestart, CType(resources.GetObject("gpbRestart.ShowHelp"), Boolean))
        Me.gpbRestart.Size = CType(resources.GetObject("gpbRestart.Size"), System.Drawing.Size)
        Me.gpbRestart.TabIndex = CType(resources.GetObject("gpbRestart.TabIndex"), Integer)
        Me.gpbRestart.TabStop = False
        Me.gpbRestart.Text = resources.GetString("gpbRestart.Text")
        Me.ToolTip1.SetToolTip(Me.gpbRestart, resources.GetString("gpbRestart.ToolTip"))
        Me.gpbRestart.Visible = CType(resources.GetObject("gpbRestart.Visible"), Boolean)
        '
        'numRecentLength
        '
        Me.numRecentLength.AccessibleDescription = resources.GetString("numRecentLength.AccessibleDescription")
        Me.numRecentLength.AccessibleName = resources.GetString("numRecentLength.AccessibleName")
        Me.numRecentLength.Anchor = CType(resources.GetObject("numRecentLength.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.numRecentLength.Dock = CType(resources.GetObject("numRecentLength.Dock"), System.Windows.Forms.DockStyle)
        Me.numRecentLength.Enabled = CType(resources.GetObject("numRecentLength.Enabled"), Boolean)
        Me.numRecentLength.Font = CType(resources.GetObject("numRecentLength.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.numRecentLength, resources.GetString("numRecentLength.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.numRecentLength, CType(resources.GetObject("numRecentLength.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.numRecentLength, resources.GetString("numRecentLength.HelpString"))
        Me.numRecentLength.ImeMode = CType(resources.GetObject("numRecentLength.ImeMode"), System.Windows.Forms.ImeMode)
        Me.numRecentLength.Location = CType(resources.GetObject("numRecentLength.Location"), System.Drawing.Point)
        Me.numRecentLength.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numRecentLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRecentLength.Name = "numRecentLength"
        Me.numRecentLength.RightToLeft = CType(resources.GetObject("numRecentLength.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.numRecentLength, CType(resources.GetObject("numRecentLength.ShowHelp"), Boolean))
        Me.numRecentLength.Size = CType(resources.GetObject("numRecentLength.Size"), System.Drawing.Size)
        Me.numRecentLength.TabIndex = CType(resources.GetObject("numRecentLength.TabIndex"), Integer)
        Me.numRecentLength.TextAlign = CType(resources.GetObject("numRecentLength.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.numRecentLength.ThousandsSeparator = CType(resources.GetObject("numRecentLength.ThousandsSeparator"), Boolean)
        Me.ToolTip1.SetToolTip(Me.numRecentLength, resources.GetString("numRecentLength.ToolTip"))
        Me.numRecentLength.UpDownAlign = CType(resources.GetObject("numRecentLength.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.numRecentLength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRecentLength.Visible = CType(resources.GetObject("numRecentLength.Visible"), Boolean)
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription")
        Me.Label2.AccessibleName = resources.GetString("Label2.AccessibleName")
        Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
        Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
        Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
        Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.Label2, resources.GetString("Label2.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Label2, CType(resources.GetObject("Label2.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Label2, resources.GetString("Label2.HelpString"))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
        Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.Label2, CType(resources.GetObject("Label2.ShowHelp"), Boolean))
        Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
        Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription")
        Me.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName")
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbRefreshFrequency)
        Me.GroupBox1.Dock = CType(resources.GetObject("GroupBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.GroupBox1.Enabled = CType(resources.GetObject("GroupBox1.Enabled"), Boolean)
        Me.GroupBox1.Font = CType(resources.GetObject("GroupBox1.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.GroupBox1, resources.GetString("GroupBox1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.GroupBox1, CType(resources.GetObject("GroupBox1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.GroupBox1, resources.GetString("GroupBox1.HelpString"))
        Me.GroupBox1.ImeMode = CType(resources.GetObject("GroupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GroupBox1.Location = CType(resources.GetObject("GroupBox1.Location"), System.Drawing.Point)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = CType(resources.GetObject("GroupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.GroupBox1, CType(resources.GetObject("GroupBox1.ShowHelp"), Boolean))
        Me.GroupBox1.Size = CType(resources.GetObject("GroupBox1.Size"), System.Drawing.Size)
        Me.GroupBox1.TabIndex = CType(resources.GetObject("GroupBox1.TabIndex"), Integer)
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = resources.GetString("GroupBox1.Text")
        Me.ToolTip1.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        Me.GroupBox1.Visible = CType(resources.GetObject("GroupBox1.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.Label1, resources.GetString("Label1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Label1, CType(resources.GetObject("Label1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Label1, resources.GetString("Label1.HelpString"))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.Label1, CType(resources.GetObject("Label1.ShowHelp"), Boolean))
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'tbRefreshFrequency
        '
        Me.tbRefreshFrequency.AccessibleDescription = resources.GetString("tbRefreshFrequency.AccessibleDescription")
        Me.tbRefreshFrequency.AccessibleName = resources.GetString("tbRefreshFrequency.AccessibleName")
        Me.tbRefreshFrequency.Anchor = CType(resources.GetObject("tbRefreshFrequency.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbRefreshFrequency.BackgroundImage = CType(resources.GetObject("tbRefreshFrequency.BackgroundImage"), System.Drawing.Image)
        Me.tbRefreshFrequency.Dock = CType(resources.GetObject("tbRefreshFrequency.Dock"), System.Windows.Forms.DockStyle)
        Me.tbRefreshFrequency.Enabled = CType(resources.GetObject("tbRefreshFrequency.Enabled"), Boolean)
        Me.tbRefreshFrequency.Font = CType(resources.GetObject("tbRefreshFrequency.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.tbRefreshFrequency, resources.GetString("tbRefreshFrequency.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.tbRefreshFrequency, CType(resources.GetObject("tbRefreshFrequency.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.tbRefreshFrequency, resources.GetString("tbRefreshFrequency.HelpString"))
        Me.tbRefreshFrequency.ImeMode = CType(resources.GetObject("tbRefreshFrequency.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbRefreshFrequency.LargeChange = 200
        Me.tbRefreshFrequency.Location = CType(resources.GetObject("tbRefreshFrequency.Location"), System.Drawing.Point)
        Me.tbRefreshFrequency.Maximum = 1000
        Me.tbRefreshFrequency.Minimum = 100
        Me.tbRefreshFrequency.Name = "tbRefreshFrequency"
        Me.tbRefreshFrequency.Orientation = CType(resources.GetObject("tbRefreshFrequency.Orientation"), System.Windows.Forms.Orientation)
        Me.tbRefreshFrequency.RightToLeft = CType(resources.GetObject("tbRefreshFrequency.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.tbRefreshFrequency, CType(resources.GetObject("tbRefreshFrequency.ShowHelp"), Boolean))
        Me.tbRefreshFrequency.Size = CType(resources.GetObject("tbRefreshFrequency.Size"), System.Drawing.Size)
        Me.tbRefreshFrequency.SmallChange = 100
        Me.tbRefreshFrequency.TabIndex = CType(resources.GetObject("tbRefreshFrequency.TabIndex"), Integer)
        Me.tbRefreshFrequency.Text = resources.GetString("tbRefreshFrequency.Text")
        Me.tbRefreshFrequency.TickFrequency = 100
        Me.ToolTip1.SetToolTip(Me.tbRefreshFrequency, resources.GetString("tbRefreshFrequency.ToolTip"))
        Me.tbRefreshFrequency.Value = 200
        Me.tbRefreshFrequency.Visible = CType(resources.GetObject("tbRefreshFrequency.Visible"), Boolean)
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = resources.GetString("HelpProvider1.HelpNamespace")
        '
        'frmOptions
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpbRestart)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmOptions"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.gpbRestart.ResumeLayout(False)
        CType(Me.numRecentLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tbRefreshFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents gpbRestart As System.Windows.Forms.GroupBox
    Friend WithEvents numRecentLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbRefreshFrequency As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip


End Class
