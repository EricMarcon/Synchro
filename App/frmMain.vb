''' <summary>
''' MDI form class for Synchro application.
''' </summary>
''' <remarks></remarks>
Public Class frmMain
    Inherits System.Windows.Forms.Form

    ''' <summary>
    ''' Run before the form is displayed for the first time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Display the main window</remarks>
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
          Handles MyBase.Load

        Dim blnArgumentError As Boolean = False

        ' Read the help path 
        Dim strRegHelpPath As String = My.Application.Info.DirectoryPath
        ' Try to find the help file in the current culture
        Dim strLocalizedHelpFile As String = strRegHelpPath & "\" & Threading.Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) & "\" & "Synchro.chm"
        If System.IO.File.Exists(strLocalizedHelpFile) Then
            ' If the help file relative to the current UI culture (2 letters) is found, set it to the help provider. 
            Me.HelpProvider1.HelpNamespace = strLocalizedHelpFile
        Else
            ' Use the default culture help file
            Me.HelpProvider1.HelpNamespace = strRegHelpPath & "\" & "Synchro.chm"
        End If

        ' Recent file list
        ReDim mnuRecentFileList(My.Settings.MRUFileListLength - 1)
        ' Read the registry and update the File menu
        RefreshMRUList()

        ' Read the command line options
        If CommandLineArgs IsNot Nothing Then
            ' If arguments were sent

            Dim strFile As String = cmdArguments(0)
            If (strFile.Chars(0) <> "-") And (strFile.Chars(0) <> "/") Then
                ' The first argument is not an option, so it is a file name
                blnArgumentError = Not OpenTheFile(strFile)
                '   Open it
            Else
                ' The first argument is an option: open a new document
                mnuNew_Click(Me, e)
                '   Run File/new command
            End If

            ' Action
            If blnArgumentError Then
                ' An error happened
                Me.Show()
                MsgBox(My.Resources.strSyntaxTitle & vbCrLf & My.Resources.strSyntaxDetail _
                & vbCrLf & vbCrLf & My.Resources.strSyntaxExample, MsgBoxStyle.Critical)
                ErrorStatus = 1
                ' The application exits with an error
                Application.Exit()
            Else
                ' Eventually change options according to the command line and run
                Dim ActiveDocument As frmDocument = CType(ActiveMdiChild, frmDocument)
                ActiveDocument.SetOptions(CommandLineArgs)
            End If
        End If

    End Sub

#Region "Drag and Drop"

    ''' <summary>
    ''' Run when an object is dropped onto the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>A .syn file (or several files) can be dropped into the form.</remarks>
    Private Sub frmMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles MyBase.DragDrop

        Dim fileList As String() = CType(e.Data.GetData("FileDrop"), String())
        For Each strFileI As String In fileList
            If Not OpenTheFile(strFileI) Then
                ' The file can not be opened. Error message. The user can cancel
                If MsgBox(My.Resources.strErrReadFile & strFileI, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    Exit For
                End If
            End If
        Next

    End Sub

    ''' <summary>
    ''' Run when an object is dragged into the form's bounds
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
            Handles MyBase.DragEnter

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

#End Region

#Region "File menu"

    ''' <summary>
    ''' Number for the default document name.
    ''' </summary>
    ''' <remarks></remarks>
    Private intDocNb As Integer

    ''' <summary>
    ''' Run when File/New menu is called.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Create a new synchronisation configuration.</remarks>
    Private Sub mnuNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuNew.Click

        ' Open a window
        Dim NewMDIChild As New frmDocument

        With NewMDIChild
            ' Give it a name
            intDocNb += 1
            ' And a caption
            .Text = "Synchro" & intDocNb.ToString
            ' Set the Parent Form of the Child window.
            .MdiParent = Me
            ' Set the help file
            .HelpProvider1.HelpNamespace = Me.HelpProvider1.HelpNamespace
            ' Display the new form.
            .Show()
            ' Set it clean
            .IsDirty = False
        End With

    End Sub

    ''' <summary>
    ''' Run when File/Open menu is called.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Open an existing file.</remarks>
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuOpen.Click

        Dim DialogResult As DialogResult = OpenFileDialog1.ShowDialog()

        If DialogResult = DialogResult.OK Then
            ' Open it
            If Not OpenTheFile(OpenFileDialog1.FileName) Then
                ' Error message
                MsgBox(My.Resources.strErrReadFile & OpenFileDialog1.FileName, MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Run when File/Close menu is called.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Close the MDI child.</remarks>
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuClose.Click
        ActiveMdiChild.Close()
    End Sub

    ''' <summary>
    ''' Run when File/Save menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Save the file.</remarks>
    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuSave.Click

        Dim ActiveDocument As frmDocument = CType(ActiveMdiChild, frmDocument)

        If ActiveDocument.strDocName = "" Then
            ' If the file has no name, use Save As...
            mnuSaveAs_Click(sender, e)
        Else
            ' Save
            ActiveDocument.Savefile()
        End If

    End Sub

    ''' <summary>
    ''' Run when File/Save menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Open a dialog to save the file.</remarks>
    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuSaveAs.Click

        Dim ActiveDocument As frmDocument = CType(ActiveMdiChild, frmDocument)
        ' Do not treat the dialog result
        ActiveDocument.ChooseFileNameAndSave()

    End Sub

    ''' <summary>
    ''' Run when File/MRU menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Open one of the last files.</remarks>
    Private Sub mnuMRU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' Identify the menu item
        Dim mnuItem As MenuItem = CType(sender, MenuItem)
        ' Eliminate leading number
        Dim strFile As String = mnuItem.Text.Substring(mnuItem.Text.IndexOf(" ")).Trim
        ' Open the file
        If Not OpenTheFile(strFile) Then
            ' If failed, delete the file from the MRU
            UpdateMRUList(strFile, True)
            MsgBox(My.Resources.strErrReadFile, MsgBoxStyle.Critical)
            ' Update the file menu
            RefreshMRUList()
        End If

    End Sub

    ''' <summary>
    ''' Run when File/Quit menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks></remarks>
    Private Sub mnuQuit_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuQuit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Update the recent file list in File menu when a file is saved.
    ''' </summary>
    ''' <param name="strLastFile">File name.</param>
    ''' <param name="blnDelete">If True, delete the file name from the list instead of adding it.</param>
    ''' <remarks></remarks>
    Public Sub UpdateMRUList(ByVal strLastFile As String, Optional ByVal blnDelete As Boolean = False)

        With My.Settings
            ' Read the MRUfilelist
            If blnDelete Then
                ' Remove the file name from the list
                .MRUFileList = .MRUFileList.Replace(strLastFile, "")
            Else
                ' The file name must be added
                If .MRUFileList.Contains(strLastFile) Then
                    ' Already in the list. Put it in first position| 1. delete it 2. add it at the begining 
                    .MRUFileList = .MRUFileList.Replace(strLastFile, "")
                    .MRUFileList = strLastFile & "|" & .MRUFileList
                Else
                    ' Add file name at the begining
                    .MRUFileList = strLastFile & "|" & .MRUFileList
                End If
            End If
            ' Remove possible double separators
            .MRUFileList = .MRUFileList.Replace("||", "|")
            ' Remove possible initial or final separator
            .MRUFileList = .MRUFileList.Trim("|"c)
            ' Check the list length
            Dim MRUfiles() As String = .MRUFileList.Split("|"c)
            If MRUfiles(0) = "" Then
                ' No file in the list. Split() return a single element array
                ReDim MRUfiles(-1)
            End If
            If MRUfiles.Length > .MRUFileListLength Then
                ' Reduce the array length
                ReDim Preserve MRUfiles(.MRUFileListLength - 1)
                ' Rewrite the list
                .MRUFileList = ""
                For intI As Integer = 0 To MRUfiles.Length - 1
                    .MRUFileList &= MRUfiles(intI) & "|"
                Next
                .MRUFileList = .MRUFileList.Trim("|"c)
            End If

            ' Finally, save the new MRU list
            .Save()
        End With

    End Sub

    ''' <summary>
    ''' Refresh the recent file list in File menu.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshMRUList()

        ' Delete the menu items
        For intI As Integer = 0 To mnuRecentFileList.Length - 1
            ' For each recent file
            If Not mnuRecentFileList(intI) Is Nothing Then
                ' If the menuitem exists, delete it
                mnuFile.MenuItems.Remove(mnuRecentFileList(intI))
            End If
        Next

        Dim MRUfiles() As String = My.Settings.MRUFileList.Split("|"c)
        If MRUfiles(0) = "" Then
            ' No file in the list. Split() return a single element array
            ReDim MRUfiles(-1)
            ' If there is no recent file, hide the separator
            mnuSepAfterMRU.Visible = False
        Else
            ' Show the separator
            mnuSepAfterMRU.Visible = True
        End If

        ' Reinitialize the menu array
        ReDim mnuRecentFileList(MRUfiles.Length - 1)
        For intI As Integer = 0 To MRUfiles.Length - 1
            ' Create each menu item, and declares its click event handler
            mnuRecentFileList(intI) = New MenuItem("&" & (intI + 1).ToString & " " & MRUfiles(intI), AddressOf mnuMRU_Click)
            ' Add the menu item table to the main menu, before the bottom separator
            mnuFile.MenuItems.Add(mnuSepAfterMRU.Index, mnuRecentFileList(intI))
        Next

        Me.Refresh()

    End Sub

    ''' <summary>
    ''' The recent file list in File menu.
    ''' </summary>
    ''' <remarks></remarks>
    Private mnuRecentFileList() As MenuItem

    ''' <summary>
    ''' Open the chosen file. Must be a valid .syn file.
    ''' </summary>
    ''' <param name="strFileName"></param>
    ''' <returns>True if the file has been opened successfully.</returns>
    ''' <remarks></remarks>
    Private Function OpenTheFile(ByRef strFileName As String) As Boolean

        Dim blnFileReadOK As Boolean = True
        Dim txtSource As String = ""
        Dim txtTarget As String = ""
        Dim txtOptions As String = ""
        Dim txtLogFile As String = ""
        Dim txtExclude As String = ""
        Dim syncOptions As Synchro.SyncOptions
        Dim sr As System.IO.StreamReader = Nothing

        ' Check if the file is already open
        For Each frm As frmDocument In Me.MdiChildren
            If frm.strDocName.ToLower = strFileName.ToLower Then
                ' The file is already open. Continue will recall the disk version
                If MsgBox(My.Resources.strFileAlreadyOpen & " ( " & strFileName & ")" & vbCrLf _
                & My.Resources.strAskIgnoreChanges, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ' Set it clean to avoid "Save the file ?" message
                    frm.IsDirty = False
                    ' Close it. All changes are lost.
                    frm.Close()
                Else
                    ' Stop opening the file
                    Exit Function
                End If
            End If
        Next

        Try
            sr = System.IO.File.OpenText(strFileName)
            With sr
                ' Read the source, the target and the options
                txtSource = .ReadLine()
                txtTarget = .ReadLine()
                txtOptions = .ReadLine()
                txtLogFile = .ReadLine()
                txtExclude = .ReadLine()
                .Close()
                syncOptions = CType(txtOptions, SyncOptions)
            End With
        Catch
            blnFileReadOK = False
        Finally
            If Not sr Is Nothing Then
                sr.Close()
            End If
        End Try

        If blnFileReadOK Then
            ' The file was read 
            Dim NewMDIChild As New frmDocument
            '   Open a window
            With NewMDIChild
                ' Give it a name and remember the file name
                .Text = Mid(strFileName, strFileName.LastIndexOf("\") + 2)
                .strDocName = strFileName
                ' Set the Parent Form of the Child window.
                .MdiParent = Me
                ' Set the properties
                .HelpProvider1.HelpNamespace = Me.HelpProvider1.HelpNamespace
                .txtSource.Text = txtSource
                .txtTarget.Text = txtTarget
                .txtLogFile.Text = txtLogFile
                .txtExclude.Text = txtExclude
                .chkS.Checked = (syncOptions And syncOptions.SyncCopySubDirectories) = syncOptions.SyncCopySubDirectories
                .chkE.Checked = (syncOptions And syncOptions.SyncCopyEmptySubDirectories) = syncOptions.SyncCopyEmptySubDirectories
                .chkR.Checked = (syncOptions And syncOptions.SyncOverWriteReadOnly) = syncOptions.SyncOverWriteReadOnly
                .chkD.Checked = (syncOptions And syncOptions.SyncPreserveNewerFiles) = syncOptions.SyncPreserveNewerFiles
                .chkSamba.Checked = (syncOptions And syncOptions.SyncCopySamba) = syncOptions.SyncCopySamba
                .chkU.Checked = (syncOptions And syncOptions.SyncCopyOnlyExistingFiles) = syncOptions.SyncCopyOnlyExistingFiles
                .chkZ.Checked = (syncOptions And syncOptions.SyncSynchronize) = syncOptions.SyncSynchronize
                .chkA.Checked = (syncOptions And syncOptions.SyncCopyAcl) = syncOptions.SyncCopyAcl
                .chkK.Checked = (syncOptions And syncOptions.SyncCopyAttributes) = syncOptions.SyncCopyAttributes
                .chkN.Checked = (syncOptions And syncOptions.SyncDontPromptBeforeCreatingFiles) = syncOptions.SyncDontPromptBeforeCreatingFiles
                .chkY.Checked = (syncOptions And syncOptions.SyncDontPromptBeforeDeletingFiles) = syncOptions.SyncDontPromptBeforeDeletingFiles
                .chkW.Checked = (syncOptions And syncOptions.SyncPromptBeforeClosingWindow) = syncOptions.SyncPromptBeforeClosingWindow
                .chkG.Checked = (syncOptions And syncOptions.SyncDontStopOnErrors) = syncOptions.SyncDontStopOnErrors
                .chkQ.Checked = (syncOptions And syncOptions.SyncQuick) = syncOptions.SyncQuick
                .chkL.Checked = (syncOptions And syncOptions.SyncLog) = syncOptions.SyncLog
                ' Set isDirty to false because changes have made it true
                .IsDirty = False
                'Display the new form.
                .Show()
            End With
        End If

        Return blnFileReadOK
    End Function

#End Region

#Region "Tools menu"

    ''' <summary>
    ''' Run when Tools/Options menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Open the options</remarks>
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuOptions.Click

        Dim frmOptions As New frmOptions
        With frmOptions
            ' Help provider
            .HelpProvider1.HelpNamespace = Me.HelpProvider1.HelpNamespace
            ' Prepare the values
            .numRecentLength.Value = CType(My.Settings.MRUFileListLength, Decimal)
            .tbRefreshFrequency.Value = My.Settings.RefreshFrequency

            If .ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                ' If OK chosen
                My.Settings.MRUFileListLength = CByte(.numRecentLength.Value)
                My.Settings.RefreshFrequency = .tbRefreshFrequency.Value
                My.Settings.Save()
            End If
        End With

    End Sub

#End Region

#Region "Windows menu"

    ''' <summary>
    ''' Run when Windows/Cascade menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Change the windows layout.</remarks>
    Private Sub mnuCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    ''' <summary>
    ''' Run when Windows/Tile menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Change the windows layout.</remarks>
    Private Sub mnuTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuTile.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    ''' <summary>
    ''' Run when a document is activated.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Enables or disables File menus.</remarks>
    Private Sub frmMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.MdiChildActivate

        If ActiveMdiChild Is Nothing Then
            ' No child window
            ' Disable close, save and save as menus
            mnuClose.Enabled = False
            mnuSave.Enabled = False
            mnuSaveAs.Enabled = False
        Else
            ' Enable close, save and save as menus
            mnuClose.Enabled = True
            mnuSave.Enabled = True
            mnuSaveAs.Enabled = True
        End If

    End Sub

#End Region

#Region "Help menu"

    ''' <summary>
    ''' Run when ?/Help menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Show help.</remarks>
    Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuHelp.Click
        Help.ShowHelpIndex(Me, Me.HelpProvider1.HelpNamespace)
    End Sub

    ''' <summary>
    ''' Run when ?/About... menu is called.
    ''' </summary>
    ''' <param name="sender">The object which sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks>Show About box.</remarks>
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
           Handles mnuAbout.Click

        Dim frmAbout As New AboutBox
        With frmAbout
            .ShowDialog(Me)
        End With

    End Sub

#End Region

End Class
