''' <summary>
''' Synchro document class.
''' </summary>
''' <remarks></remarks>
Public Class frmDocument
    Inherits System.Windows.Forms.Form

    Private _IsDirty As Boolean = False
    ''' <summary>
    ''' The document has not been saved.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property IsDirty() As Boolean
        Get
            Return _IsDirty
        End Get
        Set(ByVal value As Boolean)
            _IsDirty = value
        End Set
    End Property

    Private _strDocName As String = ""
    ''' <summary>
    ''' The document's name.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property strDocName() As String
        Get
            Return _strDocName
        End Get
        Set(ByVal value As String)
            _strDocName = value
        End Set
    End Property

    ''' <summary>
    ''' Run before the form is displayed for the first time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmDocument_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load
        ' Set the properties

        ' Show the animations
        Me.CtlSynchro1.AnimationVisible = True

    End Sub

    ''' <summary>
    ''' Set the options sent by the command line.
    ''' </summary>
    ''' <param name="Arguments">The command line arguments processed by <see cref="CommandLine.Utility.Arguments"/></param>
    ''' <remarks></remarks>
    Public Sub SetOptions(ByRef Arguments As CommandLine.Utility.Arguments)

        ' First, check the option is in the command line. If no, leave it unchanged. If yes, set it.
        If Arguments.Item("Source") IsNot Nothing Then
            Me.txtSource.Text = Arguments.Item("Source")
        End If
        If Arguments.Item("Target") IsNot Nothing Then
            Me.txtTarget.Text = Arguments.Item("Target")
        End If
        If Arguments.Item("s") IsNot Nothing Then
            Me.chkS.Checked = True
        End If
        If Arguments.Item("e") IsNot Nothing Then
            Me.chkE.Checked = True
        End If
        If Arguments.Item("r") IsNot Nothing Then
            Me.chkR.Checked = True
        End If
        If Arguments.Item("d") IsNot Nothing Then
            Me.chkD.Checked = True
        End If
        If Arguments.Item("samba") IsNot Nothing Then
            Me.chkSamba.Checked = True
        End If
        If Arguments.Item("u") IsNot Nothing Then
            Me.chkU.Checked = True
        End If
        If Arguments.Item("z") IsNot Nothing Then
            Me.chkZ.Checked = True
        End If
        If Arguments.Item("a") IsNot Nothing Then
            Me.chkA.Checked = True
        End If
        If Arguments.Item("k") IsNot Nothing Then
            Me.chkK.Checked = True
        End If
        If Arguments.Item("n") IsNot Nothing Then
            Me.chkN.Checked = True
        End If
        If Arguments.Item("y") IsNot Nothing Then
            Me.chkY.Checked = True
        End If
        If Arguments.Item("l") IsNot Nothing Then
            Me.chkL.Checked = True
            Me.txtLogFile.Text = Arguments.Item("l")
        End If
        If Arguments.Item("x") IsNot Nothing Then
            Me.txtExclude.Text = Arguments.Item("x")
        End If
        If Arguments.Item("g") IsNot Nothing Then
            Me.chkG.Checked = True
        End If
        If Arguments.Item("q") IsNot Nothing Then
            Me.chkQ.Checked = True
        End If
        If Arguments.Item("w") IsNot Nothing Then
            Me.chkW.Checked = True
        End If

        ' The document is not dirty since the user did not change anything.
        Me._IsDirty = False

    End Sub

    ''' <summary>
    ''' Run when closing the document.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Check if it is saved.</remarks>
    Private Sub frmDocument_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles MyBase.Closing

        If CtlSynchro1.RunningStatus = SyncStatus.SyncStopping Or CtlSynchro1.RunningStatus = SyncStatus.SyncStopped Then
            ' The window cannot be closed if a synchro if running
            If Me.IsDirty Then
                ' If the file was not saved
                Dim MsgBoxResult As MsgBoxResult = MsgBox(My.Resources.strAskSaveFile & Me.Text & My.Resources.strAsk, MsgBoxStyle.YesNoCancel)
                If MsgBoxResult = MsgBoxResult.Cancel Then
                    ' Cancel closing
                    e.Cancel = True
                ElseIf MsgBoxResult = MsgBoxResult.Yes Then
                    ' Save
                    If Me.strDocName = "" Then
                        ' Save as...
                        e.Cancel = (ChooseFileNameAndSave() = System.Windows.Forms.DialogResult.Cancel)
                        ' Cancel if chosen by the user
                    Else
                        ' Save
                        Savefile()
                    End If
                End If
            End If
        Else
            ' Cannot close
            MsgBox(My.Resources.strCantClose, MsgBoxStyle.Information)
            ' Cancel closing
            e.Cancel = True
        End If

    End Sub

    ''' <summary>
    ''' Run when the documet is resized.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Change the controls' position when the form is resized.</remarks>
    Private Sub frmDocument_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Resize

        Const intRightMargin As Integer = 32
        '   The distance between the form's right edge and the controls
        Const intBottomMargin As Integer = 48
        '   The distance between the form's bottom edge and the controls
        Dim intRightEdge As Integer = Me.Width - intRightMargin
        '   The right edge position of the controls

        ' Controls' position
        btnSource.Left = intRightEdge - btnSource.Width
        txtSource.Width = btnSource.Left - txtSource.Left - intRightMargin
        btnTarget.Left = intRightEdge - btnTarget.Width
        txtTarget.Width = btnTarget.Left - txtTarget.Left - intRightMargin
        chkN.Left = intRightEdge - chkN.Width
        chkY.Left = intRightEdge - chkY.Width
        chkG.Left = intRightEdge - chkG.Width
        chkQ.Left = intRightEdge - chkQ.Width
        chkW.Left = intRightEdge - chkW.Width
        chkL.Left = intRightEdge - btnLogFile.Width - chkL.Width - 2
        btnLogFile.Left = intRightEdge - btnLogFile.Width
        txtLogFile.Width = intRightEdge - txtLogFile.Left
        txtExclude.Width = intRightEdge - txtExclude.Left
        txtFileOn.Width = intRightEdge - txtFileOn.Left
        CtlSynchro1.Width = intRightEdge - CtlSynchro1.Left
        lstCopied.Width = intRightEdge - lstCopied.Left
        lstCopied.Height = Me.Height - intBottomMargin - lstCopied.Top

    End Sub

    ''' <summary>
    ''' Calculates the <see cref="SyncOptions"/> value from the check boxes.
    ''' </summary>
    ''' <returns>The options chosen.</returns>
    ''' <remarks></remarks>
    Private Function CalculateOptions() As SyncOptions

        CalculateOptions = 0
        If chkS.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopySubDirectories
        If chkE.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopyEmptySubDirectories
        If chkR.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncOverWriteReadOnly
        If chkD.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncPreserveNewerFiles
        If chkU.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopyOnlyExistingFiles
        If chkZ.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncSynchronize
        If chkN.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncDontPromptBeforeCreatingFiles
        If chkY.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncDontPromptBeforeDeletingFiles
        If chkW.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncPromptBeforeClosingWindow
        If chkG.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncDontStopOnErrors
        If chkL.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncLog
        If chkQ.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncQuick
        If chkA.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopyAcl
        If chkK.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopyAttributes
        If chkSamba.Checked Then CalculateOptions = CalculateOptions Or SyncOptions.SyncCopySamba

    End Function

    ''' <summary>
    ''' Activated by a timer. Displays the synchronization data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RefreshDisplay(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Timer1.Tick

        ' File being copied
        Me.txtFileOn.Text = CompactString(CtlSynchro1.strWhatsOn, Me.txtFileOn.Width, Me.txtFileOn.Font, TextFormatFlags.PathEllipsis)
        ' Length of the array. May increase due to the synchro thread
        If CtlSynchro1.strCopied IsNot Nothing Then
            ' Do not try to update the list if the source array does not exist
            Dim intItemsToList As Integer = CtlSynchro1.strCopied.GetLength(0)
            ' Number of items in the list
            Dim intItemsListed As Integer = lstCopied.Items.Count
            ' Loop to add the new items
            For intI As Integer = intItemsListed To intItemsToList - 1
                If CtlSynchro1.strCopied(intI) IsNot Nothing Then
                    ' The last item may be empty during the time between the array is redimensioned and filled in Synchro.AddToCopiedList
                    Me.lstCopied.Items.Add(CtlSynchro1.strCopied(intI))
                End If
            Next
            ' Focus onto the last item
            Me.lstCopied.SelectedIndex = Me.lstCopied.Items.Count - 1
        End If

    End Sub

#Region "Buttons and handlers"

    ''' <summary>
    ''' Run when <see cref="btnSource"/> is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Display a FolderBrowser dialog and return the selected source folder</remarks>
    Private Sub btnSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles btnSource.Click

        With fbdSource
            ' Set the initial folder
            .SelectedPath = txtSource.Text
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ' If validated, show the result
                txtSource.Text = .SelectedPath
            End If
        End With

    End Sub

    ''' <summary>
    ''' Run when <see cref="btnTarget"/> is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Display a FolderBrowser dialog and return the selected target folder.</remarks>
    Private Sub btnTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnTarget.Click

        With fbdTarget
            ' Set the initial folder
            .SelectedPath = txtTarget.Text
            '   Set the initial folder
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ' If validated, show the result
                txtTarget.Text = .SelectedPath
            End If
        End With

    End Sub

    ''' <summary>
    ''' Run when <see cref="btnLogFile"/> is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Choose a log file.</remarks>
    Private Sub btnLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
           Handles btnLogFile.Click

        SaveFileDialogLog.FileName = txtLogFile.Text
        '   Use the log file name
        If SaveFileDialogLog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            ' If a file is chosen
            Me.txtLogFile.Text = SaveFileDialogLog.FileName
        End If

    End Sub

    ''' <summary>
    ''' Run when <see cref="btnStart"/> is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Start synchronization</remarks>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles btnStart.Click

        ' Change the buttons while copying
        btnStart.Enabled = False
        btnStop.Enabled = True

        ' Clean the copied file list
        lstCopied.Items.Clear()

        ' Set the focus out of the stop button to avoid accidental stop
        Me.ActiveControl = lstCopied

        ' Set the values
        With CtlSynchro1
            .Source = txtSource.Text
            .Target = txtTarget.Text
            .ExcludedStrings = txtExclude.Text
            .Options = CalculateOptions()
            If (.Options And SyncOptions.SyncCopySamba) = SyncOptions.SyncCopySamba Then
                ' Allow one second of time error.
                .SambaTimeError = 1000
            End If
            .LogFile = txtLogFile.Text
            ' Run
            .SyncStart()
        End With

        ' Start the display timer
        Timer1.Interval = My.Settings.RefreshFrequency
        Timer1.Start()

    End Sub

    ''' <summary>
    ''' Run when <see cref="btnStop"/> is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Request cancelling.</remarks>
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnStop.Click
        CtlSynchro1.SyncStop()
    End Sub

    ''' <summary>
    ''' Run when synchronization is done.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SynchroDone(ByVal sender As System.Object, ByVal e As SynchroResults) _
           Handles CtlSynchro1.SyncDone

        ' Stop the display timer
        Timer1.Stop()
        ' Flush the display
        RefreshDisplay(Me, EventArgs.Empty)
        ' Clean the display
        If (e.Options And SyncOptions.SyncPromptBeforeClosingWindow) = SyncOptions.SyncPromptBeforeClosingWindow Then
            ' Nothing is being processed any longer
            Me.txtFileOn.Text = ""
            ' Prompt it is finished
            Select Case e.Status
                Case SyncStatus.SyncSucceeded
                    MsgBox(My.Resources.strCopyFinished, MsgBoxStyle.Information, Me.Text)
                Case SyncStatus.SyncCancelled
                    MsgBox(My.Resources.strCopyCancelled, MsgBoxStyle.Information, Me.Text)
                Case SyncStatus.SyncFailed
                    MsgBox(My.Resources.strCopyFailed, MsgBoxStyle.Information, Me.Text)
                Case SyncStatus.SyncNothingToDo
                    MsgBox(My.Resources.strNothingToDo, MsgBoxStyle.Information, Me.Text)
            End Select
            ' Change the buttons after copy
            btnStart.Enabled = True
            btnStop.Enabled = False
        Else
            Me.Close()
        End If
    End Sub

#End Region

#Region "Save"

    ''' <summary>
    ''' Show the Save-as dialog and return the result
    ''' </summary>
    ''' <returns>A dialog result.</returns>
    ''' <remarks></remarks>
    Friend Function ChooseFileNameAndSave() As DialogResult

        Dim DialogResult As DialogResult = SaveFileDialog1.ShowDialog

        If DialogResult = DialogResult.OK Then
            ' If OK, save
            Me.strDocName = SaveFileDialog1.FileName()
            Me.Text = Me.strDocName.Substring(Me.strDocName.LastIndexOf("\") + 1)
            Savefile()
        End If

        ' Return the dialog result
        Return DialogResult

    End Function

    ''' <summary>
    ''' Write a file to the disk.
    ''' </summary>
    ''' <remarks>The file is a .syn document containing all data of the form.</remarks>
    Friend Sub Savefile()

        Dim frmParent As frmMain = CType(Me.ParentForm, frmMain)
        Dim sr As System.IO.StreamWriter = System.IO.File.CreateText(strDocName)

        With sr
            ' Write the source, the target and the options
            .WriteLine(txtSource.Text)
            .WriteLine(txtTarget.Text)
            ' The options must be converted to integer first to avoid writing a string (eg SyncOverWriteReadOnly) if a single option is checked.
            .WriteLine(CInt(CalculateOptions()).ToString)
            .WriteLine(txtLogFile.Text)
            .WriteLine(txtExclude.Text)
            .Close()
        End With

        ' The file is saved
        Me._IsDirty = False

        ' Treat the MRU list
        frmParent.UpdateMRUList(Me.strDocName)
        ' And show it
        frmParent.RefreshMRUList()

    End Sub

    ''' <summary>
    ''' Run when something has changed on a form's control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Set <see cref="IsDirty"/> to True.</remarks>
    Private Sub SomethingChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtSource.TextChanged, txtTarget.TextChanged, chkS.CheckedChanged, chkE.CheckedChanged, _
                chkR.CheckedChanged, chkD.CheckedChanged, chkSamba.CheckedChanged, chkU.CheckedChanged, chkZ.CheckedChanged, _
                chkN.CheckedChanged, chkA.CheckedChanged, chkK.CheckedChanged, chkY.CheckedChanged, chkG.CheckedChanged, _
                chkQ.CheckedChanged, chkW.CheckedChanged, chkL.CheckedChanged, txtLogFile.TextChanged, txtExclude.TextChanged
        ' Something changed -> IsDirty
        Me.IsDirty = True
    End Sub

#End Region

End Class
