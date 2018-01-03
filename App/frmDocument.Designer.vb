<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocument))
        Me.lblSource = New System.Windows.Forms.Label
        Me.lblTarget = New System.Windows.Forms.Label
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.btnSource = New System.Windows.Forms.Button
        Me.txtTarget = New System.Windows.Forms.TextBox
        Me.btnTarget = New System.Windows.Forms.Button
        Me.txtFileOn = New System.Windows.Forms.TextBox
        Me.lstCopied = New System.Windows.Forms.ListBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.lblList = New System.Windows.Forms.Label
        Me.lblFileOn = New System.Windows.Forms.Label
        Me.chkR = New System.Windows.Forms.CheckBox
        Me.chkW = New System.Windows.Forms.CheckBox
        Me.chkD = New System.Windows.Forms.CheckBox
        Me.chkS = New System.Windows.Forms.CheckBox
        Me.chkL = New System.Windows.Forms.CheckBox
        Me.btnLogFile = New System.Windows.Forms.Button
        Me.chkE = New System.Windows.Forms.CheckBox
        Me.chkU = New System.Windows.Forms.CheckBox
        Me.chkN = New System.Windows.Forms.CheckBox
        Me.chkY = New System.Windows.Forms.CheckBox
        Me.chkZ = New System.Windows.Forms.CheckBox
        Me.txtLogFile = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SaveFileDialogLog = New System.Windows.Forms.SaveFileDialog
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.txtExclude = New System.Windows.Forms.TextBox
        Me.lblExclude = New System.Windows.Forms.Label
        Me.chkG = New System.Windows.Forms.CheckBox
        Me.chkQ = New System.Windows.Forms.CheckBox
        Me.CtlSynchro1 = New Synchro.ctlSynchro
        Me.chkA = New System.Windows.Forms.CheckBox
        Me.chkK = New System.Windows.Forms.CheckBox
        Me.chkSamba = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.fbdSource = New System.Windows.Forms.FolderBrowserDialog
        Me.fbdTarget = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'lblSource
        '
        Me.lblSource.AccessibleDescription = Nothing
        Me.lblSource.AccessibleName = Nothing
        resources.ApplyResources(Me.lblSource, "lblSource")
        Me.lblSource.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lblSource, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lblSource, CType(resources.GetObject("lblSource.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lblSource, Nothing)
        Me.lblSource.Name = "lblSource"
        Me.HelpProvider1.SetShowHelp(Me.lblSource, CType(resources.GetObject("lblSource.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.lblSource, resources.GetString("lblSource.ToolTip"))
        '
        'lblTarget
        '
        Me.lblTarget.AccessibleDescription = Nothing
        Me.lblTarget.AccessibleName = Nothing
        resources.ApplyResources(Me.lblTarget, "lblTarget")
        Me.lblTarget.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lblTarget, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lblTarget, CType(resources.GetObject("lblTarget.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lblTarget, Nothing)
        Me.lblTarget.Name = "lblTarget"
        Me.HelpProvider1.SetShowHelp(Me.lblTarget, CType(resources.GetObject("lblTarget.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.lblTarget, resources.GetString("lblTarget.ToolTip"))
        '
        'txtSource
        '
        Me.txtSource.AccessibleDescription = Nothing
        Me.txtSource.AccessibleName = Nothing
        resources.ApplyResources(Me.txtSource, "txtSource")
        Me.txtSource.BackgroundImage = Nothing
        Me.txtSource.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.txtSource, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.txtSource, CType(resources.GetObject("txtSource.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.txtSource, Nothing)
        Me.txtSource.Name = "txtSource"
        Me.HelpProvider1.SetShowHelp(Me.txtSource, CType(resources.GetObject("txtSource.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.txtSource, resources.GetString("txtSource.ToolTip"))
        '
        'btnSource
        '
        Me.btnSource.AccessibleDescription = Nothing
        Me.btnSource.AccessibleName = Nothing
        resources.ApplyResources(Me.btnSource, "btnSource")
        Me.btnSource.BackgroundImage = Nothing
        Me.btnSource.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.btnSource, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.btnSource, CType(resources.GetObject("btnSource.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnSource, Nothing)
        Me.btnSource.Name = "btnSource"
        Me.HelpProvider1.SetShowHelp(Me.btnSource, CType(resources.GetObject("btnSource.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.btnSource, resources.GetString("btnSource.ToolTip"))
        '
        'txtTarget
        '
        Me.txtTarget.AccessibleDescription = Nothing
        Me.txtTarget.AccessibleName = Nothing
        resources.ApplyResources(Me.txtTarget, "txtTarget")
        Me.txtTarget.BackgroundImage = Nothing
        Me.txtTarget.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.txtTarget, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.txtTarget, CType(resources.GetObject("txtTarget.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.txtTarget, Nothing)
        Me.txtTarget.Name = "txtTarget"
        Me.HelpProvider1.SetShowHelp(Me.txtTarget, CType(resources.GetObject("txtTarget.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.txtTarget, resources.GetString("txtTarget.ToolTip"))
        '
        'btnTarget
        '
        Me.btnTarget.AccessibleDescription = Nothing
        Me.btnTarget.AccessibleName = Nothing
        resources.ApplyResources(Me.btnTarget, "btnTarget")
        Me.btnTarget.BackgroundImage = Nothing
        Me.btnTarget.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.btnTarget, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.btnTarget, CType(resources.GetObject("btnTarget.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnTarget, Nothing)
        Me.btnTarget.Name = "btnTarget"
        Me.HelpProvider1.SetShowHelp(Me.btnTarget, CType(resources.GetObject("btnTarget.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.btnTarget, resources.GetString("btnTarget.ToolTip"))
        '
        'txtFileOn
        '
        Me.txtFileOn.AccessibleDescription = Nothing
        Me.txtFileOn.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFileOn, "txtFileOn")
        Me.txtFileOn.BackgroundImage = Nothing
        Me.txtFileOn.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.txtFileOn, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.txtFileOn, CType(resources.GetObject("txtFileOn.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.txtFileOn, Nothing)
        Me.txtFileOn.Name = "txtFileOn"
        Me.txtFileOn.ReadOnly = True
        Me.HelpProvider1.SetShowHelp(Me.txtFileOn, CType(resources.GetObject("txtFileOn.ShowHelp"), Boolean))
        Me.txtFileOn.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtFileOn, resources.GetString("txtFileOn.ToolTip"))
        '
        'lstCopied
        '
        Me.lstCopied.AccessibleDescription = Nothing
        Me.lstCopied.AccessibleName = Nothing
        resources.ApplyResources(Me.lstCopied, "lstCopied")
        Me.lstCopied.BackgroundImage = Nothing
        Me.lstCopied.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lstCopied, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lstCopied, CType(resources.GetObject("lstCopied.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lstCopied, Nothing)
        Me.lstCopied.Name = "lstCopied"
        Me.HelpProvider1.SetShowHelp(Me.lstCopied, CType(resources.GetObject("lstCopied.ShowHelp"), Boolean))
        Me.lstCopied.TabStop = False
        Me.ToolTip1.SetToolTip(Me.lstCopied, resources.GetString("lstCopied.ToolTip"))
        '
        'btnStart
        '
        Me.btnStart.AccessibleDescription = Nothing
        Me.btnStart.AccessibleName = Nothing
        resources.ApplyResources(Me.btnStart, "btnStart")
        Me.btnStart.BackgroundImage = Nothing
        Me.btnStart.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.btnStart, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.btnStart, CType(resources.GetObject("btnStart.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnStart, Nothing)
        Me.btnStart.Name = "btnStart"
        Me.HelpProvider1.SetShowHelp(Me.btnStart, CType(resources.GetObject("btnStart.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.btnStart, resources.GetString("btnStart.ToolTip"))
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = Nothing
        Me.btnStop.AccessibleName = Nothing
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.BackgroundImage = Nothing
        Me.btnStop.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.btnStop, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.btnStop, CType(resources.GetObject("btnStop.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnStop, Nothing)
        Me.btnStop.Name = "btnStop"
        Me.HelpProvider1.SetShowHelp(Me.btnStop, CType(resources.GetObject("btnStop.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.btnStop, resources.GetString("btnStop.ToolTip"))
        '
        'lblList
        '
        Me.lblList.AccessibleDescription = Nothing
        Me.lblList.AccessibleName = Nothing
        resources.ApplyResources(Me.lblList, "lblList")
        Me.lblList.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lblList, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lblList, CType(resources.GetObject("lblList.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lblList, Nothing)
        Me.lblList.Name = "lblList"
        Me.HelpProvider1.SetShowHelp(Me.lblList, CType(resources.GetObject("lblList.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.lblList, resources.GetString("lblList.ToolTip"))
        '
        'lblFileOn
        '
        Me.lblFileOn.AccessibleDescription = Nothing
        Me.lblFileOn.AccessibleName = Nothing
        resources.ApplyResources(Me.lblFileOn, "lblFileOn")
        Me.lblFileOn.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lblFileOn, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lblFileOn, CType(resources.GetObject("lblFileOn.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lblFileOn, Nothing)
        Me.lblFileOn.Name = "lblFileOn"
        Me.HelpProvider1.SetShowHelp(Me.lblFileOn, CType(resources.GetObject("lblFileOn.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.lblFileOn, resources.GetString("lblFileOn.ToolTip"))
        '
        'chkR
        '
        Me.chkR.AccessibleDescription = Nothing
        Me.chkR.AccessibleName = Nothing
        resources.ApplyResources(Me.chkR, "chkR")
        Me.chkR.BackgroundImage = Nothing
        Me.chkR.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkR, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkR, CType(resources.GetObject("chkR.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkR, Nothing)
        Me.chkR.Name = "chkR"
        Me.HelpProvider1.SetShowHelp(Me.chkR, CType(resources.GetObject("chkR.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkR, resources.GetString("chkR.ToolTip"))
        '
        'chkW
        '
        Me.chkW.AccessibleDescription = Nothing
        Me.chkW.AccessibleName = Nothing
        resources.ApplyResources(Me.chkW, "chkW")
        Me.chkW.BackgroundImage = Nothing
        Me.chkW.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkW, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkW, CType(resources.GetObject("chkW.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkW, Nothing)
        Me.chkW.Name = "chkW"
        Me.HelpProvider1.SetShowHelp(Me.chkW, CType(resources.GetObject("chkW.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkW, resources.GetString("chkW.ToolTip"))
        '
        'chkD
        '
        Me.chkD.AccessibleDescription = Nothing
        Me.chkD.AccessibleName = Nothing
        resources.ApplyResources(Me.chkD, "chkD")
        Me.chkD.BackgroundImage = Nothing
        Me.chkD.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkD, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkD, CType(resources.GetObject("chkD.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkD, Nothing)
        Me.chkD.Name = "chkD"
        Me.HelpProvider1.SetShowHelp(Me.chkD, CType(resources.GetObject("chkD.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkD, resources.GetString("chkD.ToolTip"))
        '
        'chkS
        '
        Me.chkS.AccessibleDescription = Nothing
        Me.chkS.AccessibleName = Nothing
        resources.ApplyResources(Me.chkS, "chkS")
        Me.chkS.BackgroundImage = Nothing
        Me.chkS.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkS, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkS, CType(resources.GetObject("chkS.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkS, Nothing)
        Me.chkS.Name = "chkS"
        Me.HelpProvider1.SetShowHelp(Me.chkS, CType(resources.GetObject("chkS.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkS, resources.GetString("chkS.ToolTip"))
        '
        'chkL
        '
        Me.chkL.AccessibleDescription = Nothing
        Me.chkL.AccessibleName = Nothing
        resources.ApplyResources(Me.chkL, "chkL")
        Me.chkL.BackgroundImage = Nothing
        Me.chkL.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkL, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkL, CType(resources.GetObject("chkL.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkL, Nothing)
        Me.chkL.Name = "chkL"
        Me.HelpProvider1.SetShowHelp(Me.chkL, CType(resources.GetObject("chkL.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkL, resources.GetString("chkL.ToolTip"))
        '
        'btnLogFile
        '
        Me.btnLogFile.AccessibleDescription = Nothing
        Me.btnLogFile.AccessibleName = Nothing
        resources.ApplyResources(Me.btnLogFile, "btnLogFile")
        Me.btnLogFile.BackgroundImage = Nothing
        Me.btnLogFile.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.btnLogFile, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.btnLogFile, CType(resources.GetObject("btnLogFile.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.btnLogFile, Nothing)
        Me.btnLogFile.Name = "btnLogFile"
        Me.HelpProvider1.SetShowHelp(Me.btnLogFile, CType(resources.GetObject("btnLogFile.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.btnLogFile, resources.GetString("btnLogFile.ToolTip"))
        '
        'chkE
        '
        Me.chkE.AccessibleDescription = Nothing
        Me.chkE.AccessibleName = Nothing
        resources.ApplyResources(Me.chkE, "chkE")
        Me.chkE.BackgroundImage = Nothing
        Me.chkE.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkE, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkE, CType(resources.GetObject("chkE.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkE, Nothing)
        Me.chkE.Name = "chkE"
        Me.HelpProvider1.SetShowHelp(Me.chkE, CType(resources.GetObject("chkE.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkE, resources.GetString("chkE.ToolTip"))
        '
        'chkU
        '
        Me.chkU.AccessibleDescription = Nothing
        Me.chkU.AccessibleName = Nothing
        resources.ApplyResources(Me.chkU, "chkU")
        Me.chkU.BackgroundImage = Nothing
        Me.chkU.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkU, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkU, CType(resources.GetObject("chkU.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkU, Nothing)
        Me.chkU.Name = "chkU"
        Me.HelpProvider1.SetShowHelp(Me.chkU, CType(resources.GetObject("chkU.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkU, resources.GetString("chkU.ToolTip"))
        '
        'chkN
        '
        Me.chkN.AccessibleDescription = Nothing
        Me.chkN.AccessibleName = Nothing
        resources.ApplyResources(Me.chkN, "chkN")
        Me.chkN.BackgroundImage = Nothing
        Me.chkN.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkN, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkN, CType(resources.GetObject("chkN.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkN, Nothing)
        Me.chkN.Name = "chkN"
        Me.HelpProvider1.SetShowHelp(Me.chkN, CType(resources.GetObject("chkN.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkN, resources.GetString("chkN.ToolTip"))
        '
        'chkY
        '
        Me.chkY.AccessibleDescription = Nothing
        Me.chkY.AccessibleName = Nothing
        resources.ApplyResources(Me.chkY, "chkY")
        Me.chkY.BackgroundImage = Nothing
        Me.chkY.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkY, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkY, CType(resources.GetObject("chkY.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkY, Nothing)
        Me.chkY.Name = "chkY"
        Me.HelpProvider1.SetShowHelp(Me.chkY, CType(resources.GetObject("chkY.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkY, resources.GetString("chkY.ToolTip"))
        '
        'chkZ
        '
        Me.chkZ.AccessibleDescription = Nothing
        Me.chkZ.AccessibleName = Nothing
        resources.ApplyResources(Me.chkZ, "chkZ")
        Me.chkZ.BackgroundImage = Nothing
        Me.chkZ.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkZ, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkZ, CType(resources.GetObject("chkZ.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkZ, Nothing)
        Me.chkZ.Name = "chkZ"
        Me.HelpProvider1.SetShowHelp(Me.chkZ, CType(resources.GetObject("chkZ.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkZ, resources.GetString("chkZ.ToolTip"))
        '
        'txtLogFile
        '
        Me.txtLogFile.AccessibleDescription = Nothing
        Me.txtLogFile.AccessibleName = Nothing
        resources.ApplyResources(Me.txtLogFile, "txtLogFile")
        Me.txtLogFile.BackgroundImage = Nothing
        Me.txtLogFile.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.txtLogFile, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.txtLogFile, CType(resources.GetObject("txtLogFile.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.txtLogFile, Nothing)
        Me.txtLogFile.Name = "txtLogFile"
        Me.HelpProvider1.SetShowHelp(Me.txtLogFile, CType(resources.GetObject("txtLogFile.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.txtLogFile, resources.GetString("txtLogFile.ToolTip"))
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "syn"
        Me.SaveFileDialog1.DereferenceLinks = False
        resources.ApplyResources(Me.SaveFileDialog1, "SaveFileDialog1")
        '
        'SaveFileDialogLog
        '
        resources.ApplyResources(Me.SaveFileDialogLog, "SaveFileDialogLog")
        Me.SaveFileDialogLog.OverwritePrompt = False
        '
        'HelpProvider1
        '
        resources.ApplyResources(Me.HelpProvider1, "HelpProvider1")
        '
        'txtExclude
        '
        Me.txtExclude.AccessibleDescription = Nothing
        Me.txtExclude.AccessibleName = Nothing
        resources.ApplyResources(Me.txtExclude, "txtExclude")
        Me.txtExclude.BackgroundImage = Nothing
        Me.txtExclude.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.txtExclude, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.txtExclude, CType(resources.GetObject("txtExclude.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.txtExclude, Nothing)
        Me.txtExclude.Name = "txtExclude"
        Me.HelpProvider1.SetShowHelp(Me.txtExclude, CType(resources.GetObject("txtExclude.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.txtExclude, resources.GetString("txtExclude.ToolTip"))
        '
        'lblExclude
        '
        Me.lblExclude.AccessibleDescription = Nothing
        Me.lblExclude.AccessibleName = Nothing
        resources.ApplyResources(Me.lblExclude, "lblExclude")
        Me.lblExclude.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.lblExclude, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.lblExclude, CType(resources.GetObject("lblExclude.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.lblExclude, Nothing)
        Me.lblExclude.Name = "lblExclude"
        Me.HelpProvider1.SetShowHelp(Me.lblExclude, CType(resources.GetObject("lblExclude.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.lblExclude, resources.GetString("lblExclude.ToolTip"))
        '
        'chkG
        '
        Me.chkG.AccessibleDescription = Nothing
        Me.chkG.AccessibleName = Nothing
        resources.ApplyResources(Me.chkG, "chkG")
        Me.chkG.BackgroundImage = Nothing
        Me.chkG.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkG, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkG, CType(resources.GetObject("chkG.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkG, Nothing)
        Me.chkG.Name = "chkG"
        Me.HelpProvider1.SetShowHelp(Me.chkG, CType(resources.GetObject("chkG.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkG, resources.GetString("chkG.ToolTip"))
        '
        'chkQ
        '
        Me.chkQ.AccessibleDescription = Nothing
        Me.chkQ.AccessibleName = Nothing
        resources.ApplyResources(Me.chkQ, "chkQ")
        Me.chkQ.BackgroundImage = Nothing
        Me.chkQ.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkQ, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkQ, CType(resources.GetObject("chkQ.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkQ, Nothing)
        Me.chkQ.Name = "chkQ"
        Me.HelpProvider1.SetShowHelp(Me.chkQ, CType(resources.GetObject("chkQ.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkQ, resources.GetString("chkQ.ToolTip"))
        '
        'CtlSynchro1
        '
        Me.CtlSynchro1.AccessibleDescription = Nothing
        Me.CtlSynchro1.AccessibleName = Nothing
        resources.ApplyResources(Me.CtlSynchro1, "CtlSynchro1")
        Me.CtlSynchro1.AnimationVisible = True
        Me.CtlSynchro1.BackgroundImage = Nothing
        Me.CtlSynchro1.ExcludedStrings = Nothing
        Me.CtlSynchro1.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.CtlSynchro1, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.CtlSynchro1, CType(resources.GetObject("CtlSynchro1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.CtlSynchro1, Nothing)
        Me.CtlSynchro1.LogFile = Nothing
        Me.CtlSynchro1.Name = "CtlSynchro1"
        Me.CtlSynchro1.Options = Synchro.SyncOptions.SyncDefault
        Me.CtlSynchro1.ProgressBarHeight = 25
        Me.CtlSynchro1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks
        Me.CtlSynchro1.SambaTimeError = 0
        Me.HelpProvider1.SetShowHelp(Me.CtlSynchro1, CType(resources.GetObject("CtlSynchro1.ShowHelp"), Boolean))
        Me.CtlSynchro1.Source = ""
        Me.CtlSynchro1.TabStop = False
        Me.CtlSynchro1.Target = Nothing
        Me.ToolTip1.SetToolTip(Me.CtlSynchro1, resources.GetString("CtlSynchro1.ToolTip"))
        '
        'chkA
        '
        Me.chkA.AccessibleDescription = Nothing
        Me.chkA.AccessibleName = Nothing
        resources.ApplyResources(Me.chkA, "chkA")
        Me.chkA.BackgroundImage = Nothing
        Me.chkA.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkA, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkA, CType(resources.GetObject("chkA.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkA, Nothing)
        Me.chkA.Name = "chkA"
        Me.HelpProvider1.SetShowHelp(Me.chkA, CType(resources.GetObject("chkA.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkA, resources.GetString("chkA.ToolTip"))
        '
        'chkK
        '
        Me.chkK.AccessibleDescription = Nothing
        Me.chkK.AccessibleName = Nothing
        resources.ApplyResources(Me.chkK, "chkK")
        Me.chkK.BackgroundImage = Nothing
        Me.chkK.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkK, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkK, CType(resources.GetObject("chkK.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkK, Nothing)
        Me.chkK.Name = "chkK"
        Me.HelpProvider1.SetShowHelp(Me.chkK, CType(resources.GetObject("chkK.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkK, resources.GetString("chkK.ToolTip"))
        '
        'chkSamba
        '
        Me.chkSamba.AccessibleDescription = Nothing
        Me.chkSamba.AccessibleName = Nothing
        resources.ApplyResources(Me.chkSamba, "chkSamba")
        Me.chkSamba.BackgroundImage = Nothing
        Me.chkSamba.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me.chkSamba, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me.chkSamba, CType(resources.GetObject("chkSamba.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.chkSamba, Nothing)
        Me.chkSamba.Name = "chkSamba"
        Me.HelpProvider1.SetShowHelp(Me.chkSamba, CType(resources.GetObject("chkSamba.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me.chkSamba, resources.GetString("chkSamba.ToolTip"))
        '
        'Timer1
        '
        '
        'fbdSource
        '
        resources.ApplyResources(Me.fbdSource, "fbdSource")
        Me.fbdSource.ShowNewFolderButton = False
        '
        'fbdTarget
        '
        resources.ApplyResources(Me.fbdTarget, "fbdTarget")
        '
        'frmDocument
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.lblExclude)
        Me.Controls.Add(Me.chkSamba)
        Me.Controls.Add(Me.chkK)
        Me.Controls.Add(Me.chkQ)
        Me.Controls.Add(Me.chkG)
        Me.Controls.Add(Me.txtFileOn)
        Me.Controls.Add(Me.txtExclude)
        Me.Controls.Add(Me.txtLogFile)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.chkW)
        Me.Controls.Add(Me.chkA)
        Me.Controls.Add(Me.chkZ)
        Me.Controls.Add(Me.chkY)
        Me.Controls.Add(Me.chkN)
        Me.Controls.Add(Me.chkU)
        Me.Controls.Add(Me.chkE)
        Me.Controls.Add(Me.btnLogFile)
        Me.Controls.Add(Me.chkL)
        Me.Controls.Add(Me.chkS)
        Me.Controls.Add(Me.chkD)
        Me.Controls.Add(Me.chkR)
        Me.Controls.Add(Me.lblFileOn)
        Me.Controls.Add(Me.lblList)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lstCopied)
        Me.Controls.Add(Me.btnTarget)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.lblTarget)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.CtlSynchro1)
        Me.Font = Nothing
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, Nothing)
        Me.Name = "frmDocument"
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lblTarget As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents btnTarget As System.Windows.Forms.Button
    Friend WithEvents txtFileOn As System.Windows.Forms.TextBox
    Friend WithEvents lstCopied As System.Windows.Forms.ListBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblList As System.Windows.Forms.Label
    Friend WithEvents chkR As System.Windows.Forms.CheckBox
    Friend WithEvents chkW As System.Windows.Forms.CheckBox
    Friend WithEvents chkD As System.Windows.Forms.CheckBox
    Friend WithEvents chkS As System.Windows.Forms.CheckBox
    Friend WithEvents chkL As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogFile As System.Windows.Forms.Button
    Friend WithEvents chkE As System.Windows.Forms.CheckBox
    Friend WithEvents chkU As System.Windows.Forms.CheckBox
    Friend WithEvents chkN As System.Windows.Forms.CheckBox
    Friend WithEvents chkY As System.Windows.Forms.CheckBox
    Friend WithEvents chkZ As System.Windows.Forms.CheckBox
    Friend WithEvents txtLogFile As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveFileDialogLog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtExclude As System.Windows.Forms.TextBox
    Friend WithEvents lblExclude As System.Windows.Forms.Label
    Friend WithEvents lblFileOn As System.Windows.Forms.Label
    Friend WithEvents CtlSynchro1 As Synchro.ctlSynchro
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chkG As System.Windows.Forms.CheckBox
    Friend WithEvents chkQ As System.Windows.Forms.CheckBox
    Friend WithEvents fbdSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbdTarget As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkA As System.Windows.Forms.CheckBox
    Friend WithEvents chkK As System.Windows.Forms.CheckBox
    Friend WithEvents chkSamba As System.Windows.Forms.CheckBox

End Class
