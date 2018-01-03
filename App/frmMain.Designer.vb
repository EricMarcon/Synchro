<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.mnuOpen = New System.Windows.Forms.MenuItem
        Me.mnuClose = New System.Windows.Forms.MenuItem
        Me.mnuSepAfterClose = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem
        Me.mnuSepBeforeMRU = New System.Windows.Forms.MenuItem
        Me.mnuSepAfterMRU = New System.Windows.Forms.MenuItem
        Me.mnuQuit = New System.Windows.Forms.MenuItem
        Me.mnuTools = New System.Windows.Forms.MenuItem
        Me.mnuOptions = New System.Windows.Forms.MenuItem
        Me.mnuWindow = New System.Windows.Forms.MenuItem
        Me.mnuCascade = New System.Windows.Forms.MenuItem
        Me.mnuTile = New System.Windows.Forms.MenuItem
        Me.mnuH = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuWindow, Me.mnuH})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.mnuClose, Me.mnuSepAfterClose, Me.mnuSave, Me.mnuSaveAs, Me.mnuSepBeforeMRU, Me.mnuSepAfterMRU, Me.mnuQuit})
        Me.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        resources.ApplyResources(Me.mnuNew, "mnuNew")
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 1
        resources.ApplyResources(Me.mnuOpen, "mnuOpen")
        '
        'mnuClose
        '
        resources.ApplyResources(Me.mnuClose, "mnuClose")
        Me.mnuClose.Index = 2
        '
        'mnuSepAfterClose
        '
        Me.mnuSepAfterClose.Index = 3
        resources.ApplyResources(Me.mnuSepAfterClose, "mnuSepAfterClose")
        '
        'mnuSave
        '
        resources.ApplyResources(Me.mnuSave, "mnuSave")
        Me.mnuSave.Index = 4
        '
        'mnuSaveAs
        '
        resources.ApplyResources(Me.mnuSaveAs, "mnuSaveAs")
        Me.mnuSaveAs.Index = 5
        '
        'mnuSepBeforeMRU
        '
        Me.mnuSepBeforeMRU.Index = 6
        Me.mnuSepBeforeMRU.MergeOrder = 10
        resources.ApplyResources(Me.mnuSepBeforeMRU, "mnuSepBeforeMRU")
        '
        'mnuSepAfterMRU
        '
        Me.mnuSepAfterMRU.Index = 7
        resources.ApplyResources(Me.mnuSepAfterMRU, "mnuSepAfterMRU")
        '
        'mnuQuit
        '
        Me.mnuQuit.Index = 8
        Me.mnuQuit.MergeOrder = 11
        resources.ApplyResources(Me.mnuQuit, "mnuQuit")
        '
        'mnuTools
        '
        Me.mnuTools.Index = 1
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOptions})
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        '
        'mnuOptions
        '
        Me.mnuOptions.Index = 0
        resources.ApplyResources(Me.mnuOptions, "mnuOptions")
        '
        'mnuWindow
        '
        Me.mnuWindow.Index = 2
        Me.mnuWindow.MdiList = True
        Me.mnuWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCascade, Me.mnuTile})
        resources.ApplyResources(Me.mnuWindow, "mnuWindow")
        '
        'mnuCascade
        '
        Me.mnuCascade.Index = 0
        resources.ApplyResources(Me.mnuCascade, "mnuCascade")
        '
        'mnuTile
        '
        Me.mnuTile.Index = 1
        resources.ApplyResources(Me.mnuTile, "mnuTile")
        '
        'mnuH
        '
        Me.mnuH.Index = 3
        Me.mnuH.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelp, Me.mnuAbout})
        resources.ApplyResources(Me.mnuH, "mnuH")
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 0
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 1
        resources.ApplyResources(Me.mnuAbout, "mnuAbout")
        '
        'OpenFileDialog1
        '
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'HelpProvider1
        '
        resources.ApplyResources(Me.HelpProvider1, "HelpProvider1")
        '
        'frmMain
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMain"
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuQuit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuWindow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuCascade As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSepAfterClose As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSepBeforeMRU As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSepAfterMRU As System.Windows.Forms.MenuItem
    Friend WithEvents mnuH As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOptions As System.Windows.Forms.MenuItem

End Class
