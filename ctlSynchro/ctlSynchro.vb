''' <summary>
''' User control to copy folders and synchronize them.
''' </summary>
''' <remarks>(c) Eric Marcon, http://e.marcon.free.fr/Synchro</remarks>
Public Class ctlSynchro
    Inherits System.Windows.Forms.UserControl

#Region "Properties"

    Private _Source As String
    ''' <summary>
    ''' Source directory.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The path to the source directory.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Action")> Public Property Source() As String
        Get
            Return _Source
        End Get
        Set(ByVal value As String)
            _Source = value
        End Set
    End Property

    Private _Target As String
    ''' <summary>
    ''' Target directory.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The path to the target directory.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Action")> Public Property Target() As String
        Get
            Return _Target
        End Get
        Set(ByVal value As String)
            _Target = value
        End Set
    End Property

    Private _ExcludedStrings As String = ""
    ''' <summary>
    ''' File and folder name patterns excluded from the copy.
    ''' </summary>
    ''' <value></value>
    ''' <returns>A string containing excluded patterns separated by ;</returns>
    ''' <remarks>Default value is <c>Empty String</c> to avoid <c>Nothing</c> when used in console mode.</remarks>
    <System.ComponentModel.Category("Action")> Public Property ExcludedStrings() As String
        Get
            Return _ExcludedStrings
        End Get
        Set(ByVal value As String)
            _ExcludedStrings = value
        End Set
    End Property

    Private _Options As SyncOptions
    ''' <summary>
    ''' Synchronization options.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The options.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Action")> Public Property Options() As SyncOptions
        Get
            Return _Options
        End Get
        Set(ByVal value As SyncOptions)
            _Options = value
        End Set
    End Property

    Private _SambaTimeError As Double = 0.0
    ''' <summary>
    ''' Time difference (milliseconds) allowed without considering file dates are different
    ''' </summary>
    ''' <value></value>
    ''' <returns>A duration in milliseconds</returns>
    ''' <remarks>
    ''' Synchronisation NTFS folders with Samba Folders does not work well because many files that did not change are copied every time.
    ''' The reason is that time is stored differently on both systems. If time difference is smaller than <c>SambaTimeError</c>, file is considered unchanged. 
    ''' </remarks>
    <System.ComponentModel.Category("Action")> Public Property SambaTimeError() As Double
        Get
            Return _SambaTimeError
        End Get
        Set(ByVal value As Double)
            _SambaTimeError = value
        End Set
    End Property

    Private _LogFile As String
    ''' <summary>
    ''' Log file name.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The path to the log file.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Action")> Public Property LogFile() As String
        Get
            Return _LogFile
        End Get
        Set(ByVal value As String)
            _LogFile = value
        End Set
    End Property

    Private _ConsoleMode As Boolean = False
    ''' <summary>
    ''' Chose between form/multithread or console/single thread mode.
    ''' </summary>
    ''' <value></value>
    ''' <returns>True if run in console mode.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Appearance")> <System.ComponentModel.DefaultValue(False)> Public Property ConsoleMode() As Boolean
        Get
            Return _ConsoleMode
        End Get
        Set(ByVal value As Boolean)
            _ConsoleMode = value
        End Set
    End Property

    Private _AnimationVisible As Boolean
    ''' <summary>
    ''' Status of the animation.
    ''' </summary>
    ''' <value></value>
    ''' <returns>True if the animation is visible.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Appearance")> Public Property AnimationVisible() As Boolean
        Get
            Return _AnimationVisible
        End Get
        Set(ByVal value As Boolean)
            _AnimationVisible = value
        End Set
    End Property

    ''' <summary>
    ''' Height of the progress bar in the control.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The height of the progress bar.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Appearance")> Public Property ProgressBarHeight() As Integer
        Get
            Return Me.pgbSynchro.Height
        End Get
        Set(ByVal value As Integer)
            Me.pgbSynchro.Height = value
        End Set
    End Property

    ''' <summary>
    ''' Style of the progress bar in the control.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The style of the progress bar.</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Appearance")> Public Property ProgressBarStyle() As ProgressBarStyle
        Get
            Return Me.pgbSynchro.Style
        End Get
        Set(ByVal value As ProgressBarStyle)
            Me.pgbSynchro.Style = value
        End Set
    End Property

    Private _WhatsOn As String
    ''' <summary>
    ''' Describe what the synchro thread is doing.
    ''' </summary>
    ''' <returns>A string describing what the control is doing.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property strWhatsOn() As String
        Get
            Return _WhatsOn
        End Get
    End Property

    Private _SyncCopySize As Long
    ''' <summary>
    ''' Number of bytes to copy.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property lngSyncCopySize() As Long
        Get
            Return _SyncCopySize
        End Get
    End Property

    Private _SyncCopyDone As Long
    ''' <summary>
    ''' Number of bytes already copied.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property lngSyncCopyDone() As Long
        Get
            Return _SyncCopyDone
        End Get
    End Property

    Private _Copied As String()
    ''' <summary>
    ''' List of completed actions
    ''' </summary>
    ''' <value></value>
    ''' <returns>A string array containing the list of actions.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property strCopied() As String()
        Get
            Return _Copied
        End Get
    End Property

    Private _RunningStatus As SyncStatus
    ''' <summary>
    ''' Status of the copy
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property RunningStatus() As SyncStatus
        Get
            Return _RunningStatus
        End Get
    End Property

    Private _thrSynchro As Threading.Thread
    ''' <summary>
    ''' The background thread running the synchronization.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property thrSynchro() As Threading.Thread
        Get
            Return _thrSynchro
        End Get
    End Property

    Private _ExitStatus As SyncStatus
    ''' <summary>
    ''' Status returned. 
    ''' </summary>
    ''' <remarks>Useless in multithread mode (use the status returned by <see cref="SyncDone"/>)</remarks>
    Public ReadOnly Property ExitStatus() As SyncStatus
        Get
            Return _ExitStatus
        End Get
    End Property


#End Region

#Region " Private variables"

    ''' <summary>
    ''' Source directory
    ''' </summary>
    ''' <remarks></remarks>
    Private fldSource As System.IO.DirectoryInfo

    ''' <summary>
    ''' Target folder
    ''' </summary>
    ''' <remarks></remarks>
    Private fldTarget As System.IO.DirectoryInfo

    ''' <summary>
    ''' Array of excluded strings.
    ''' </summary>
    ''' <remarks></remarks>
    Private strExcludedStringList As String()

    ''' <summary>
    ''' Thread to wait for the synchronization to stop during cancelling.
    ''' </summary>
    ''' <remarks></remarks>
    Private thrStopSynchro As Threading.Thread

    ''' <summary>
    ''' File to copy.
    ''' </summary>
    ''' <remarks></remarks>
    Private strSourceFile As String

    ''' <summary>
    ''' Copied file.
    ''' </summary>
    ''' <remarks></remarks>
    Private strTargetFile As String

    ''' <summary>
    ''' Last action, to log.
    ''' </summary>
    ''' <remarks></remarks>
    Private strAction As String

    ''' <summary>
    ''' Handle the end of the synchronization.
    ''' </summary>
    ''' <remarks></remarks>
    Private onSynchroDone As SynchroDoneHandler

    ''' <summary>
    ''' Source Folder ACL.
    ''' </summary>
    ''' <remarks></remarks>
    Private aclSourceFolder As System.Security.AccessControl.DirectorySecurity

    ''' <summary>
    ''' Target Folder ACL.
    ''' </summary>
    ''' <remarks></remarks>
    Private aclTargetFolder As System.Security.AccessControl.DirectorySecurity

    ''' <summary>
    ''' Source File ACL.
    ''' </summary>
    ''' <remarks></remarks>
    Private aclSourceFile As System.Security.AccessControl.FileSecurity

    ''' <summary>
    ''' Target File ACL.
    ''' </summary>
    ''' <remarks></remarks>
    Private aclTargetFile As System.Security.AccessControl.FileSecurity

    ''' <summary>
    ''' Source File Attributes.
    ''' </summary>
    ''' <remarks></remarks>
    Private attrSourceFolder As System.IO.FileAttributes

    ''' <summary>
    ''' Target File Attributes.
    ''' </summary>
    ''' <remarks></remarks>
    Private attrTargetFolder As System.IO.FileAttributes

    ''' <summary>
    ''' Difference between source and target file time.
    ''' </summary>
    ''' <remarks></remarks>
    Private TimeDifference As TimeSpan

#End Region

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Do not allow direct access to children controls by the copy thread.
        CheckForIllegalCrossThreadCalls = True
        ' Create a handler for Synchro Done that will be marshaled.
        onSynchroDone = New SynchroDoneHandler(AddressOf OnSyncDone)
    End Sub

#Region "Start / Stop methods"

    ''' <summary>
    ''' Show the control, and activate the waiting animation.
    ''' </summary>
    ''' <param name="cgAnimation">The animation to show.</param>
    ''' <param name="strFileName">The file name of the an animation, if cgAnimation is <see cref="CG.Animation.CGAVIFileType.ExternalFile"/></param>
    ''' <remarks><see cref="AVIFileType.ExternalFile"/> is the only working option under Vista.</remarks>
    Public Shadows Sub Show(ByVal cgAnimation As AVIFileType, Optional ByVal strFileName As String = "")

        If (Me.RunningStatus = SyncStatus.SyncStopped) Then
            ' Change the animation only if stopped
            If cgAnimation = AVIFileType.NoAnimation Then
                Me.AnimationVisible = False
                SetCgAnimation1Visible(False)
            Else
                ' Run the animation and set AnimationVisible
                Me.AnimationVisible = True
                ' Me.AnimationVisible is to choose whether to show the animation or not. Public property.
                ' CgAnimation1.Visible must be set to false when no animation is run or the screen will not be refreshed. Private.
                SetCgAnimationToShowMode(strFileName)
            End If
        End If

        ' Call the base class method
        MyBase.Show()

    End Sub

    ''' <summary>
    ''' Start synchronization.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SyncStart()

        ' Can start only if stopped or ready. If running or cancelling, do not start a second thread.
        If (Me.RunningStatus = SyncStatus.SyncStopped) Or (Me.RunningStatus = SyncStatus.SyncReady) Then
            ' Synchronize if the handle has been created or in console mode (no handle).
            ' Otherwise, defer it until the handle has been created.
            If IsHandleCreated Or _ConsoleMode Then
                ' Running status
                _RunningStatus = SyncStatus.SyncRunning
                ' Exit status: success until changed
                _ExitStatus = SyncStatus.SyncSucceeded
                ' Create the thread and run it
                If _ConsoleMode Then
                    ' Console mode: single thread
                    Synchronize()
                Else
                    ' Windows mode. Initialize
                    _WhatsOn = My.Resources.strSyncPreparing
                    ' Animation
                    With Me.CgAnimation1
                        If _AnimationVisible Then
                            SetCgAnimationToSearchMode()
                            SetCgAnimation1Visible(True)
                        Else
                            ' No animation: hide the control
                            SetCgAnimation1Visible(False)
                        End If
                    End With

                    _thrSynchro = New Threading.Thread(New Threading.ThreadStart(AddressOf Synchronize))
                    With thrSynchro
                        .Name = "Synchronize"
                        .Start()
                    End With
                End If
            Else
                ' If the handle has not been created, set the status to deferred.
                ' Typically, this happens if a background thread is created in the constructor of the primary form for the application 
                ' (as in Application.Run(new MainForm()), before the form has been shown or Application.Run has been called.
                ' This also happens if the control is not visible: CtlSynchro must be visible or it will not run.
                ' In this case, the calling code should check the status in order to try again.
                _RunningStatus = SyncStatus.SyncDeferred
            End If
        End If

    End Sub

    ''' <summary>
    ''' Stop synchronization.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SyncStop()

        ' Check whether the thread is actually alive.
        If Not (thrSynchro Is Nothing) AndAlso thrSynchro.IsAlive Then
            Select Case Me.RunningStatus
                Case SyncStatus.SyncDeferred
                    ' If deferred, simply stop, and return a cancelled status
                    StopTheTread(SyncStatus.SyncCancelled)
                    _RunningStatus = SyncStatus.SyncStopped
                Case SyncStatus.SyncReady, SyncStatus.SyncRunning
                    ' Set the exit status
                    _ExitStatus = SyncStatus.SyncCancelled
                    ' Ask the thread to stop: set the status to SyncCancelling
                    ' Wait for the thread to reach the next checkpoint (= a test of the status)
                    ' Checkpoints are before each long task (file accesses) to stop as soon as possible
                    _RunningStatus = SyncStatus.SyncCancelling
                    ' Start a new thread to wait for the thread to stop
                    thrStopSynchro = New Threading.Thread(New Threading.ThreadStart(AddressOf StoppingSynchronize))
                    With thrStopSynchro
                        .Name = "StoppingSynchronize"
                        .Start()
                    End With
            End Select
        Else
            ' The thread is dead and the status has not been updated. Should not happen but...
            ' Or it has not started (Stop called before start)
            ' Running status: almost stopped
            _RunningStatus = SyncStatus.SyncStopping
            ' Nothing on any longer
            _WhatsOn = ""
            ' Done. Raise the SyncDone event if the window is still open. If used in console mode, do nothing
            If IsHandleCreated Then
                BeginInvoke(onSynchroDone, New Object() {Me, New SynchroResults(SyncStatus.SyncFailed, _Options)})
            End If
            ' Set the running status. Another synchronization can be launched.
            _RunningStatus = SyncStatus.SyncStopped
        End If

    End Sub

#End Region

#Region "Event raised when done"

    ''' <summary>
    ''' Delegate for <see cref="OnSyncDone"/>
    ''' </summary>
    ''' <param name="sender">The object that sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks></remarks>
    Delegate Sub SynchroDoneHandler(ByVal sender As Object, ByVal e As SynchroResults)

    ''' <summary>
    ''' Event raised when synchronization is done.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SyncDone As SynchroDoneHandler

    ''' <summary>
    ''' Called when the synchronization is done.
    ''' </summary>
    ''' <param name="sender">The object that sent the event.</param>
    ''' <param name="e">Arguments.</param>
    ''' <remarks></remarks>
    Protected Sub OnSyncDone(ByVal sender As Object, ByVal e As SynchroResults)

        ' Reset the progressbar if a marquee is used (SyncQuick)
        Me.pgbSynchro.Value = 100
        Me.pgbSynchro.Style = Windows.Forms.ProgressBarStyle.Blocks
        ' Raise the actual event.
        RaiseEvent SyncDone(sender, e)

    End Sub

#End Region

#Region "Private methods"

    ''' <summary>
    ''' Do the job as a thread.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Synchronize()

        ' Clean the results of a possible previous synchronization
        _SyncCopySize = 0
        _SyncCopyDone = 0
        ReDim _Copied(-1)

        Try
            ' Manipulating the file system may cause exceptions
            ' Check the folders
            If Not System.IO.Directory.Exists(_Source) Then
                ' The root could not be created: abort
                ErrorMessage(My.Resources.strSourceDirFailed)
                StopTheTread(SyncStatus.SyncFailed)
                Exit Try
            End If
            ' Bytes to copy. Ignore if SyncQuick
            If (_Options And SyncOptions.SyncQuick) = SyncOptions.SyncQuick Then
                _SyncCopySize = -1
            Else
                _SyncCopySize = FolderSize(_Source)
            End If
            ' Checkpoint: FolderSize may be long and have been cancelled
            If Me.RunningStatus = SyncStatus.SyncCancelling Then
                Exit Try
            End If
            If lngSyncCopySize = -1 Then
                ' Force quick copy option if folder size = -1: original option or FolderSize failed
                _Options = _Options Or SyncOptions.SyncQuick
                ' Marquee for the progress bar
                SetpgbSynchroStyle(Windows.Forms.ProgressBarStyle.Marquee)
            End If
            ' Nothing is done yet
            _SyncCopyDone = 0

            ' Create the excluded files table
            strExcludedStringList = _ExcludedStrings.Split(New [Char]() {";"c})

            ' Log the options
            RecordAction(My.Resources.strSyncStart)
            RecordAction(My.Resources.strSource & _Source)
            RecordAction(My.Resources.strTarget & _Target)
            If (_Options And SyncOptions.SyncCopySubDirectories) = SyncOptions.SyncCopySubDirectories Then
                RecordAction(My.Resources.strOptionS)
            End If
            If (_Options And SyncOptions.SyncCopyEmptySubDirectories) = SyncOptions.SyncCopyEmptySubDirectories Then
                RecordAction(My.Resources.strOptionE)
            End If
            If (_Options And SyncOptions.SyncOverWriteReadOnly) = SyncOptions.SyncOverWriteReadOnly Then
                RecordAction(My.Resources.strOptionR)
            End If
            If (_Options And SyncOptions.SyncPreserveNewerFiles) = SyncOptions.SyncPreserveNewerFiles Then
                RecordAction(My.Resources.strOptionD)
            End If
            If (_Options And SyncOptions.SyncCopySamba) = SyncOptions.SyncCopySamba Then
                ' Check consistency between /Samba and .SambaTimeError. The user should set both. If /Samba is used without more precision, the default accepted time error is 1 second.
                If _SambaTimeError = 0 Then _SambaTimeError = 1000
                RecordAction(My.Resources.strOptionSamba & " (" & My.Resources.strTimeDifferenceAllowed & _SambaTimeError & My.Resources.strMilliseconds & ")")
            End If
            If (_Options And SyncOptions.SyncCopyOnlyExistingFiles) = SyncOptions.SyncCopyOnlyExistingFiles Then
                RecordAction(My.Resources.strOptionU)
            End If
            If (_Options And SyncOptions.SyncSynchronize) = SyncOptions.SyncSynchronize Then
                RecordAction(My.Resources.strOptionZ)
            End If
            If (_Options And SyncOptions.SyncCopyAcl) = SyncOptions.SyncCopyAcl Then
                RecordAction(My.Resources.strOptionA)
            End If
            If (_Options And SyncOptions.SyncCopyAttributes) = SyncOptions.SyncCopyAttributes Then
                RecordAction(My.Resources.strOptionK)
            End If

            ' Delete eventual \ at the end of the folder names
            If _Source.EndsWith("\") Then
                _Source.Remove(_Source.Length - 2)
            End If
            If _Target.EndsWith("\") Then
                _Target.Remove(_Target.Length - 2)
            End If

            ' Check that there is no loop
            If (_Target & "\").IndexOf(_Source & "\") > 0 Then
                ' If the target is inside the source, quit
                ' Final \ added to allow copying C:\temp into C:\Temp2
                ErrorMessage(My.Resources.strTargetInSource)
                StopTheTread(SyncStatus.SyncFailed)
                Exit Try
            End If

            ' Everything has been checked: launch the recursive synchronization of the root folder
            If _AnimationVisible Then
                Me.SetCgAnimationToCopyMode()
            End If
            SyncFolder(_Source, _Target)
        Catch ex As Exception
            ' An exception occured but has not been handled
            _ExitStatus = SyncStatus.SyncFailed
            ErrorMessage(ex.Message)
        Finally
            ' Running status: almost stopped
            _RunningStatus = SyncStatus.SyncStopping
            ' Nothing on any longer
            _WhatsOn = ""
            ' Stop animation
            Me.StopCgAnimation()
            ' Done. Raise the SyncDone event if the window is still open. If used in console mode, do nothing
            If IsHandleCreated Then
                BeginInvoke(onSynchroDone, New Object() {Me, New SynchroResults(ExitStatus, _Options)})
            End If
            ' Set the running status. Another synchronization can be launched.
            _RunningStatus = SyncStatus.SyncStopped
        End Try

    End Sub

    ''' <summary>
    ''' Synchronize a folder
    ''' </summary>
    ''' <param name="strSource">The source path.</param>
    ''' <param name="strTarget">The target path.</param>
    ''' <remarks></remarks>
    Private Sub SyncFolder(ByVal strSource As String, ByVal strTarget As String)

        ' Checkpoint
        If Me.RunningStatus = SyncStatus.SyncCancelling Then
            Return
        End If

        Dim blnCreate As Boolean ' Validate folder creation
        Dim blnCopy As Boolean ' Validate file copy
        Dim blnDelete As Boolean ' Validate file copy
        Dim msgConfirmation As MsgBoxResult  ' Confirm
        Dim filSource As System.IO.FileInfo  ' Source file
        Dim filTarget As System.IO.FileInfo ' Target file
        Dim fldSubFolders As System.IO.DirectoryInfo() ' Source subfolders
        Dim fldFolderI As System.IO.DirectoryInfo ' Generic folder for loops
        Dim fldDeleted As System.IO.DirectoryInfo ' Subfolders of the source directory that may have been deleted
        Dim strJustDeleted As String ' File or Folder Name deleted just before logging

        ' Check whether the folder is excluded
        If IsExcluded(strSource & "\") Then
            ' If the folder is excluded, quit. \ is added to allow excluding folder names specifically
            ' (ex.: /x "\temp\" should exclude the folder c:\temp\ while strSource is "c:\temp")
            RecordAction(My.Resources.strExcludedFolder, "x " & strSource & "\")
            Return
        End If

        ' Create the folder objects
        fldSource = New System.IO.DirectoryInfo(strSource)
        fldTarget = New System.IO.DirectoryInfo(strTarget)

        ' First, the folder
        If Not fldTarget.Exists Then
            ' If the target folder does not exist, create it or not?
            blnCreate = False
            If (_Options And SyncOptions.SyncCopyEmptySubDirectories) = SyncOptions.SyncCopyEmptySubDirectories Then
                ' /e : create anyway
                blnCreate = True
            Else
                If FileFound(fldSource) Then
                    ' There is at least a file in the source, taking the /s option into account
                    blnCreate = True
                End If
            End If

            If blnCreate And Not ((_Options And SyncOptions.SyncDontPromptBeforeCreatingFiles) = SyncOptions.SyncDontPromptBeforeCreatingFiles) Then
                ' Create requested, but prompt before
                msgConfirmation = MsgBox(My.Resources.strAskCreateFolder & strTarget & My.Resources.strQuestionMark, MsgBoxStyle.YesNoCancel, "Synchro")
                If msgConfirmation = MsgBoxResult.Cancel Then
                    ' Cancel requested. Raise the SyncDone event
                    StopTheTread(SyncStatus.SyncCancelled)
                    Return
                End If
                blnCreate = (msgConfirmation = MsgBoxResult.Yes)
            End If

            If blnCreate Then
                Try
                    ' The target root may not be correct
                    fldTarget.Create()
                    RecordAction(My.Resources.strCreateFolder & strTarget & "\", "+ " & strTarget & "\")
                Catch ex As Exception
                    ' The root could not be created, ask to continue
                    If ErrorMessage(My.Resources.strTargetDirFailed & " (" & fldTarget.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                        StopTheTread(SyncStatus.SyncFailed)
                        Return
                    End If
                    Return
                End Try
            End If
        End If

        ' Refresh the target folder to take into account its recent creation
        fldTarget.Refresh()

        ' Folder ACLs and attributes
        If fldTarget.Exists Then
            ' The folder exists, copy ACLs
            Try
                ' May fail...
                If (_Options And SyncOptions.SyncCopyAcl) = SyncOptions.SyncCopyAcl Then
                    ' /a : copy ACL
                    aclSourceFolder = fldSource.GetAccessControl
                    aclTargetFolder = fldTarget.GetAccessControl
                    If aclSourceFolder IsNot aclTargetFolder Then
                        ' Do nothing if target ACL is the same as source's
                        aclTargetFolder.SetSecurityDescriptorBinaryForm(aclSourceFolder.GetSecurityDescriptorBinaryForm)
                        fldTarget.SetAccessControl(aclTargetFolder)
                    End If
                    RecordAction(My.Resources.strChangeACLs & strTarget & "\", "~ " & strTarget & "\")
                End If
            Catch ex As Exception
                ' In case of problem, ask to continue
                If ErrorMessage(My.Resources.strAclFailed & " (" & fldTarget.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                    StopTheTread(SyncStatus.SyncFailed)
                    Return
                End If
            End Try
            ' The folder exists, copy attributes
            Try
                ' May fail...
                If (_Options And SyncOptions.SyncCopyAttributes) = SyncOptions.SyncCopyAttributes Then
                    ' /k : copy ACL
                    attrSourceFolder = fldSource.Attributes
                    attrTargetFolder = fldTarget.Attributes
                    If attrSourceFolder <> attrTargetFolder Then
                        ' Do nothing if target attributes are the same as source's
                        fldTarget.Attributes = attrSourceFolder
                    End If
                    RecordAction(My.Resources.strChangeAttributes & strTarget & "\", "# " & strTarget & "\")
                End If
            Catch ex As Exception
                ' In case of problem, ask to continue
                If ErrorMessage(My.Resources.strAttributesFailed & " (" & fldTarget.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                    StopTheTread(SyncStatus.SyncFailed)
                    Return
                End If
            End Try
        End If

        ' Second, the files. If there is something to copy, if the folder already exists. It does not if folder options said not to create it.
        ' Refresh the status or the creation of the target folder will not be detected
        fldTarget.Refresh()
        If fldTarget.Exists Then
            ' If the target folder exists

            For Each filSource In fldSource.GetFiles
                ' Conditional copy of the files
                RecordAction(, , filSource.FullName)
                blnCopy = True

                If IsExcluded(filSource.FullName) Then
                    ' Check whether the file is excluded
                    RecordAction(My.Resources.strExcludedFile & filSource.FullName, "x " & filSource.FullName)
                Else
                    ' If the file is not excluded, create the target file object
                    filTarget = New System.IO.FileInfo(strTarget & "\" & filSource.Name)
                    If filTarget.Exists Then
                        ' If the target exists
                        If (_Options And SyncOptions.SyncPreserveNewerFiles) = SyncOptions.SyncPreserveNewerFiles Then
                            ' First check : is the file newer ?
                            Me.TimeDifference = filSource.LastWriteTimeUtc - filTarget.LastWriteTimeUtc
                            ' Copy if the file is more recent, including a little difference accepted for Samba
                            blnCopy = (Me.TimeDifference > TimeSpan.FromMilliseconds(_SambaTimeError))
                            If Not blnCopy Then
                                ' Double check: if the file size if different, copy it anyway
                                If filTarget.Length <> filSource.Length Then blnCopy = True
                            End If
                        End If
                        If blnCopy Then
                            ' Second check: read only
                            If (filTarget.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                                ' if the file is read only
                                If (_Options And SyncOptions.SyncOverWriteReadOnly) = SyncOptions.SyncOverWriteReadOnly Then
                                    ' If read-only files can be overwritten, remove Read-Only attribute
                                    filTarget.Attributes = filTarget.Attributes Xor System.IO.FileAttributes.ReadOnly
                                Else
                                    ' It can not be overwritten
                                    blnCopy = False
                                End If
                            End If
                        End If
                    Else
                        ' The target does not exist
                        If (_Options And SyncOptions.SyncCopyOnlyExistingFiles) = SyncOptions.SyncCopyOnlyExistingFiles Then
                            ' Files cannot be created
                            blnCopy = False
                        Else
                            If (_Options And SyncOptions.SyncDontPromptBeforeCreatingFiles) = SyncOptions.SyncDontPromptBeforeCreatingFiles Then
                                ' No prompt
                                blnCopy = True
                            Else
                                ' Ask before creating
                                msgConfirmation = MsgBox(My.Resources.strAskCreateFile & strTarget & "\" & filSource.Name & My.Resources.strQuestionMark, MsgBoxStyle.YesNoCancel, "Synchro")
                                If msgConfirmation = MsgBoxResult.Cancel Then
                                    ' Cancel requested. Raise the SyncDone event
                                    StopTheTread(SyncStatus.SyncCancelled)
                                    Return
                                End If
                                blnCopy = (msgConfirmation = MsgBoxResult.Yes)
                            End If
                        End If
                    End If

                    ' Checkpoint
                    If Me.RunningStatus = SyncStatus.SyncCancelling Then
                        Return
                    End If

                    ' Actual copy
                    If blnCopy Then
                        ' File copy
                        Try
                            ' Refresh before action
                            filSource.Refresh()
                            ' The file may be locked
                            filSource.CopyTo(strTarget & "\" & filSource.Name, True)
                            RecordAction(My.Resources.strCopyfile & filSource.FullName & " -> " & strTarget & "\" & filSource.Name, "+ " & strTarget & "\" & filSource.Name)
                            If (_Options And SyncOptions.SyncCopyAcl) = SyncOptions.SyncCopyAcl Then
                                ' /a : copy ACL
                                aclSourceFile = filSource.GetAccessControl
                                aclTargetFile = New System.Security.AccessControl.FileSecurity
                                aclTargetFile.SetSecurityDescriptorBinaryForm(aclSourceFile.GetSecurityDescriptorBinaryForm)
                                filTarget.SetAccessControl(aclTargetFile)
                            End If
                            If (_Options And SyncOptions.SyncCopyAttributes) = SyncOptions.SyncCopyAttributes Then
                                ' /k : copy Attributes
                                filTarget.Attributes = filSource.Attributes
                            End If
                        Catch ex As Exception
                            ' In case of problem, ask to continue
                            If ErrorMessage(My.Resources.strCopyFailed & " (" & filSource.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                                StopTheTread(SyncStatus.SyncFailed)
                                Return
                            End If
                        End Try
                    End If
                End If

                ' Increment the progress bar. The file size is added, copied or not. Type long allows files >4GB
                If (_Options And SyncOptions.SyncQuick) = SyncOptions.SyncDefault Then
                    BarAdd(filSource.Length)
                End If

            Next filSource
        End If


        ' Synchronization
        If (_Options And SyncOptions.SyncSynchronize) = SyncOptions.SyncSynchronize Then
            ' If synchronization is requested
            If fldTarget.Exists Then
                ' The destination folder may not exist if the user refused everything
                If IsExcluded(fldTarget.FullName) Then
                    ' Check whether the folder is excluded
                    RecordAction(My.Resources.strExcludedFolder & fldTarget.FullName, "x " & fldTarget.FullName)
                Else
                    ' Delete the files
                    For Each filTarget In fldTarget.GetFiles
                        ' Check whether every file in the target directory exists in the source
                        filSource = New System.IO.FileInfo(strSource & "\" & filTarget.Name)
                        If Not filSource.Exists Then
                            If IsExcluded(filTarget.FullName) Then
                                ' Check whether the file is excluded
                                RecordAction(My.Resources.strExcludedFile & filTarget.FullName, "x " & filTarget.FullName)
                            Else

                                RecordAction(, , filTarget.FullName)
                                blnDelete = True
                                ' First check: read only
                                If (filTarget.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                                    ' if the file is read only
                                    If (_Options And SyncOptions.SyncOverWriteReadOnly) = SyncOptions.SyncOverWriteReadOnly Then
                                        ' If read-only files can be overwritten, remove Read-Only attribute
                                        filTarget.Attributes = filTarget.Attributes Xor System.IO.FileAttributes.ReadOnly
                                    Else
                                        ' It can not be overwritten
                                        blnDelete = False
                                    End If
                                End If
                                ' Second check: confirmation
                                If blnDelete Then
                                    If Not (_Options And SyncOptions.SyncDontPromptBeforeDeletingFiles) = SyncOptions.SyncDontPromptBeforeDeletingFiles Then
                                        ' If files cannot be deleted without confirmation, ask for confirmation
                                        msgConfirmation = MsgBox(My.Resources.strAskDeleteFile & filTarget.FullName & My.Resources.strQuestionMark, MsgBoxStyle.YesNoCancel, "Synchro")
                                        If msgConfirmation = MsgBoxResult.Cancel Then
                                            ' Cancel requested. Raise the SyncDone event
                                            StopTheTread(SyncStatus.SyncCancelled)
                                            Return
                                        End If
                                        blnDelete = (msgConfirmation = MsgBoxResult.Yes)
                                    End If
                                End If

                                ' Checkpoint
                                If Me.RunningStatus = SyncStatus.SyncCancelling Then
                                    Return
                                End If

                                If blnDelete Then
                                    Try
                                        ' The file may be locked
                                        ' Remember the name to be able to log after the file is deleted
                                        strJustDeleted = filTarget.FullName
                                        ' Refresh before deleting
                                        filTarget.Refresh()
                                        ' Try to delete
                                        filTarget.Delete()
                                        RecordAction(My.Resources.strDeleteFile & strJustDeleted, "- " & strJustDeleted)
                                    Catch ex As Exception
                                        ' In case of problem, ask to continue 
                                        If ErrorMessage(My.Resources.strDeleteFailed & " (" & filTarget.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                                            StopTheTread(SyncStatus.SyncFailed)
                                            Return
                                        End If
                                    End Try
                                End If
                            End If
                        End If
                    Next filTarget

                    ' Delete the subfolders
                    For Each fldFolderI In fldTarget.GetDirectories
                        ' Check whether every subfolder exists
                        fldDeleted = New System.IO.DirectoryInfo(strSource & "\" & fldFolderI.Name)
                        If Not fldDeleted.Exists Then
                            If IsExcluded(fldDeleted.FullName) Then
                                ' Check whether the folder is excluded
                                RecordAction(My.Resources.strExcludedFolder & fldDeleted.FullName, "x " & fldDeleted.FullName)
                            Else
                                RecordAction(, , fldFolderI.FullName)
                                ' Readonly cannot be checked or changed since it is a file attribute.
                                ' If some files are read only, deleting the folder will fail.
                                ' Solution: if the option SyncOverWriteReadOnly is selected, recursively delete all read-only attributes
                                If (_Options And SyncOptions.SyncOverWriteReadOnly) = SyncOptions.SyncOverWriteReadOnly Then
                                    EraseReadOnlyAttribute(fldFolderI)
                                End If

                                If (_Options And SyncOptions.SyncDontPromptBeforeDeletingFiles) = SyncOptions.SyncDontPromptBeforeDeletingFiles Then
                                    ' If folders can be deleted without confirmation
                                    blnDelete = True
                                Else
                                    ' Ask for confirmation
                                    msgConfirmation = MsgBox(My.Resources.strAskDeleteFolder & fldFolderI.FullName & My.Resources.strQuestionMark, MsgBoxStyle.YesNoCancel, "Synchro")
                                    If msgConfirmation = MsgBoxResult.Cancel Then
                                        ' Cancel requested. Raise the SyncDone event
                                        StopTheTread(SyncStatus.SyncCancelled)
                                        Return
                                    End If
                                    blnDelete = (msgConfirmation = MsgBoxResult.Yes)
                                End If

                                ' Checkpoint
                                If Me.RunningStatus = SyncStatus.SyncCancelling Then
                                    Return
                                End If

                                If blnDelete Then
                                    Try
                                        ' The file may be locked
                                        ' Remember the name to be able to log after the folder has been deleted
                                        strJustDeleted = fldFolderI.FullName
                                        ' Refresh the folder object before deleting it or the RO attribute may be incorrect
                                        fldFolderI.Refresh()
                                        ' Try to delete the folder and its content
                                        fldFolderI.Delete(True)
                                        RecordAction(My.Resources.strDeleteFolder & strJustDeleted & "\", "- " & strJustDeleted & "\")
                                    Catch ex As Exception
                                        ' In case of problem, ask to continue (don't ask in console mode or not /w)
                                        If ErrorMessage(My.Resources.strDeleteFailed & " (" & fldFolderI.FullName & ")", ex.Message, True) = MsgBoxResult.No Then
                                            ' Cancel requested. Raise the SyncDone event
                                            StopTheTread(SyncStatus.SyncCancelled)
                                            Return
                                        End If
                                    End Try
                                End If
                            End If
                        End If
                    Next fldFolderI
                End If
            End If
        End If

        ' Subfolders
        If (_Options And SyncOptions.SyncCopySubDirectories) = SyncOptions.SyncCopySubDirectories Then
            ' If subfolders are to be copied
            Try
                fldSubFolders = fldSource.GetDirectories
                For Each fldFolderI In fldSubFolders
                    ' Recursive call of the process for each subdirectory
                    If Me.RunningStatus = SyncStatus.SyncRunning Then
                        ' Check the status
                        If (fldFolderI.Attributes And IO.FileAttributes.ReparsePoint) <> IO.FileAttributes.ReparsePoint Then
                            ' Avoid symbolic links
                            SyncFolder(fldFolderI.FullName, strTarget & "\" & fldFolderI.Name)
                        End If
                    Else
                        ' If the status is not running, the thread is finishing. Leave the recursion.
                        Return
                    End If
                Next fldFolderI
            Catch ex As Exception
                ' In case of problem, ask to continue
                If ErrorMessage(ex.Message & " (" & fldSource.FullName & ")", , True) = MsgBoxResult.No Then
                    ' Cancel requested. Raise the SyncDone event
                    StopTheTread(SyncStatus.SyncCancelled)
                    Return
                End If
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Require the synchronization thread to stop.
    ''' </summary>
    ''' <param name="ExitStatus">The reason to stop.</param>
    ''' <remarks></remarks>
    Private Sub StopTheTread(ByVal ExitStatus As SyncStatus)
        ' Set the exit status
        _ExitStatus = ExitStatus
        ' Stop the synchro thread
        _RunningStatus = SyncStatus.SyncCancelling
    End Sub

    ''' <summary>
    ''' Wait for the synchro thread to stop
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StoppingSynchronize()

        ' Show an animation
        If _AnimationVisible Then
            Me.SetCgAnimationToSearchMode()
        End If
        Dim blnThreadFinished As Boolean
        Do While Not blnThreadFinished
            ' Reduce the progress bar value every 50 ms
            Me.SetpgbSynchroValue(CInt(0.9 * Me.pgbSynchro.Value))
            blnThreadFinished = thrSynchro.Join(50)
        Loop
        ' Finish the animation
        Do While Me.pgbSynchro.Value > 0
            Me.SetpgbSynchroValue(Me.pgbSynchro.Value - 1)
            Threading.Thread.Sleep(50)
        Loop
        ' Stop Animation      
        Me.StopCgAnimation()

    End Sub

    ''' <summary>
    ''' Get a DirectoryInfo object by its path and call the regular FolderSize.
    ''' </summary>
    ''' <param name="strPath">The path of the folder.</param>
    ''' <returns>The folder's size.</returns>
    ''' <remarks></remarks>
    Private Overloads Function FolderSize(ByVal strPath As String) As Long

        ' Set the root folder
        Dim fldRoot As New System.IO.DirectoryInfo(strPath)
        FolderSize = FolderSize(fldRoot)

    End Function
    ''' <summary>
    ''' Return the size of a folder according to <see cref="SyncOptions"/>.
    ''' </summary>
    ''' <param name="fldRoot">The root folder.</param>
    ''' <returns>The folder's size.</returns>
    ''' <remarks></remarks>
    Private Overloads Function FolderSize(ByRef fldRoot As System.IO.DirectoryInfo) As Long

        Dim lngSubFolderSize As Long
        FolderSize = 0

        ' Checkpoint
        If Me.RunningStatus = SyncStatus.SyncCancelling Then
            Return 0
        End If

        Try
            ' Possible exceptions if a folder or a file cannot be read (permission denied)
            Dim fldSubI As System.IO.DirectoryInfo() = fldRoot.GetDirectories()
            ' Declare an array for the folder's files
            Dim filSubI As System.IO.FileInfo() = fldRoot.GetFiles()
            ' Read the files size
            For Each filI As System.IO.FileInfo In filSubI
                ' Add each file size only
                FolderSize += filI.Length
            Next filI
            ' Recursively get the size of subfolders
            If (_Options And SyncOptions.SyncCopySubDirectories) = SyncOptions.SyncCopySubDirectories Then
                ' If subfolders are included
                For Each fldI As System.IO.DirectoryInfo In fldSubI
                    If Me.RunningStatus = SyncStatus.SyncRunning Then
                        ' If the status is not runnning, do not continue
                        If True Or (fldI.Attributes And IO.FileAttributes.ReparsePoint) <> IO.FileAttributes.ReparsePoint Then
                            ' Avoid Symbolic links
                            lngSubFolderSize = FolderSize(fldI)
                            If lngSubFolderSize = -1 Then
                                ' Failed.
                                Return -1
                            Else
                                FolderSize += FolderSize(fldI)
                            End If
                        End If
                    Else
                        Return 0
                    End If
                Next fldI
            End If
        Catch ex As Exception
            If _ConsoleMode Then
                Console.WriteLine(My.Resources.strSizeFailed & ex.Message)
            Else
                RecordAction(My.Resources.strSizeFailed & ex.Message, My.Resources.strSizeFailed & ex.Message)
            End If
            ' Return -1 means FolderSize failed
            Return -1
        End Try

    End Function

    ''' <summary>
    ''' Return true if at least one file is found in the folder or its subfolders.
    ''' </summary>
    ''' <param name="fldRoot">The folder to search.</param>
    ''' <returns>True if at least one file is found in the folder or its subfolders.</returns>
    ''' <remarks></remarks>
    Private Function FileFound(ByRef fldRoot As System.IO.DirectoryInfo) As Boolean

        ' Declare an array for subfolders
        Dim fldSubI As System.IO.DirectoryInfo() = fldRoot.GetDirectories()
        ' An array for files
        Dim filSubI As System.IO.FileInfo() = fldRoot.GetFiles()

        ' Success if there is at least a file
        FileFound = (filSubI.Length <> 0)

        If Not FileFound Then
            ' Recursively get the the number of files in subfolders if none has been found yet
            If (_Options And SyncOptions.SyncCopySubDirectories) = SyncOptions.SyncCopySubDirectories Then
                ' If subfolders are included
                For Each fldI As System.IO.DirectoryInfo In fldSubI
                    FileFound = FileFound(fldI)
                    ' Exit as soon as possible
                    If FileFound Then Exit For
                Next fldI
            End If
        End If

    End Function

    ''' <summary>
    ''' Remove read-only attribute from files recursively.
    ''' </summary>
    ''' <param name="fldRoot">The root folder.</param>
    ''' <remarks></remarks>
    Private Sub EraseReadOnlyAttribute(ByRef fldRoot As System.IO.DirectoryInfo)

        ' Declare an array for subfolders
        Dim fldSubI As System.IO.DirectoryInfo() = fldRoot.GetDirectories()
        ' An array for files
        Dim filSubI As System.IO.FileInfo() = fldRoot.GetFiles()

        ' Treat the files
        For Each filI As System.IO.FileInfo In filSubI
            ' Erase the read-only attribute
            filI.Attributes = filI.Attributes And Not IO.FileAttributes.ReadOnly
        Next filI

        ' Recursively treat subfolders
        If (_Options And SyncOptions.SyncCopySubDirectories) = SyncOptions.SyncCopySubDirectories Then
            ' If subfolders are included
            For Each fldI As System.IO.DirectoryInfo In fldSubI
                EraseReadOnlyAttribute(fldI)
            Next fldI
        End If

    End Sub

    ''' <summary>
    ''' Check whether the file or folder name must be excluded form the copy according to parameters initialized in <see cref="ExcludedStrings" />
    ''' </summary>
    ''' <param name="strFileName">The file or folder name.</param>
    ''' <returns>True if the file or folder is excluded from the synchronization.</returns>
    ''' <remarks></remarks>
    Private Function IsExcluded(ByVal strFileName As String) As Boolean

        Dim strExclude As String

        IsExcluded = False

        If Not (strExcludedStringList Is Nothing) Then
            ' No test if there is nothing to exclude
            For Each strExclude In strExcludedStringList
                ' Check each option
                If strFileName Like strExclude Then
                    ' If match, leave
                    IsExcluded = True
                    Exit For
                End If
            Next
        End If

    End Function

    ''' <summary>
    ''' Record an action.
    ''' </summary>
    ''' <param name="strLog">The text to add at the end of the log file.</param>
    ''' <param name="strList">The text to add at the end of <see cref="strCopied"/></param>
    ''' <param name="strFileOn">The text to put into <see cref="strWhatsOn"/></param>
    ''' <remarks></remarks>
    Private Sub RecordAction(Optional ByVal strLog As String = "", Optional ByVal strList As String = "", Optional ByVal strFileOn As String = "")
        ' Call AddToCopiedList and update strWhatsOn (screen) and LogAction (log file)

        ' List
        If strList <> "" Then
            ' If there is something to list
            AddToCopiedList(strList)
        End If
        If strFileOn <> "" Then
            ' If there is a file concerned
            _WhatsOn = strFileOn
        End If

        ' Log
        If (_Options And SyncOptions.SyncLog) = SyncOptions.SyncLog Or _ConsoleMode Then
            ' If the options allow logging
            If strLog <> "" Then
                ' If there is something to log
                strAction = strLog
                If (_Options And SyncOptions.SyncLog) = SyncOptions.SyncLog Then
                    ' To log file
                    LogAction()
                End If
                If _ConsoleMode Then
                    ' To console
                    Console.WriteLine(strAction)
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Add an item to the list of copied files.
    ''' </summary>
    ''' <param name="strNewItem">The text to add.</param>
    ''' <remarks></remarks>
    Private Sub AddToCopiedList(ByVal strNewItem As String)

        ' Redim adding a new item (array is 0 based, length is 1 based)
        ReDim Preserve _Copied(strCopied.Length)
        ' Length has changed...
        strCopied(strCopied.Length - 1) = strNewItem

    End Sub

    ''' <summary>
    ''' Log activity.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LogAction()
        
        Dim sr As System.IO.StreamWriter = Nothing

        Try
            sr = System.IO.File.AppendText(_LogFile)
            sr.WriteLine(CStr(Now) & " : " & strAction)

        Catch ex As Exception
            If _ConsoleMode Then
                Console.WriteLine(My.Resources.strErrorLog & ex.Message)
            Else
                MsgBox(My.Resources.strErrorLog & ex.Message, MsgBoxStyle.Critical)
            End If
            ' Stop logging
            _Options = _Options Xor SyncOptions.SyncLog

        Finally
            If Not sr Is Nothing Then
                sr.Close()
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Make the progress bar progress
    ''' </summary>
    ''' <param name="lngDone">The number of copied bytes to add</param>
    ''' <remarks></remarks>
    Private Sub BarAdd(ByVal lngDone As Long)
       
        Dim sngBarValue As Single ' The progress bar value

        ' Number of copied bytes
        _SyncCopyDone += lngDone
        Try
            ' Calculate the progress bar value. Since it is Int32, can't use the Int64 value lngSyncCopyDone directly
            sngBarValue = CSng(100 * lngSyncCopyDone / lngSyncCopySize)
            ' Set the bar value
            Me.SetpgbSynchroValue(CInt(sngBarValue))
        Catch ex As Exception
            ' May fail if /0 or >100 due to rounding
            Me.SetpgbSynchroValue(100)
        End Try

    End Sub

    ''' <summary>
    ''' Show an error message (according to the mode). Eventually ask to continue.
    ''' </summary>
    ''' <param name="strMessage">The message to show.</param>
    ''' <param name="strException">The exception message.</param>
    ''' <param name="blnAskToContinue">Ask the user whether to continue.</param>
    ''' <returns>A <see cref="MsgBoxResult"/> containing the user's choice.</returns>
    ''' <remarks></remarks>
    Private Function ErrorMessage(ByVal strMessage As String, Optional ByVal strException As String = "", Optional ByVal blnAskToContinue As Boolean = False) As MsgBoxResult

        ' Add the exception message
        If strException <> "" Then
            strMessage &= ". " & vbCrLf & strException
        End If

        ' Return yes by default
        ErrorMessage = MsgBoxResult.Yes

        ' Show the message
        If _ConsoleMode Then
            ' Console mode: just a message
            Console.WriteLine(strMessage)
        Else
            If (_Options And SyncOptions.SyncDontStopOnErrors) = SyncOptions.SyncDefault Then
                ' Message if options allow it
                If blnAskToContinue Then
                    ' Yes/No message
                    ErrorMessage = MsgBox(strMessage & vbCrLf & My.Resources.strAskContinue, MsgBoxStyle.YesNo)
                Else
                    MsgBox(strMessage, MsgBoxStyle.Critical)
                End If
            End If
        End If

        ' Log
        RecordAction(strMessage, strMessage)

    End Function

#End Region

#Region "Safe cross-thread access to controls"

    ''' <summary>
    ''' Delegate for <see cref="SetCgAnimation1Visible"/>.
    ''' </summary>
    ''' <param name="blnVisible">Indicates whether the animation is visible or not.</param>
    ''' <remarks></remarks>
    Delegate Sub SetCgAnimation1VisibleCallback(ByVal blnVisible As Boolean)
    ''' <summary>
    ''' Safe cross-thread method to toggle the animation visibility.
    ''' </summary>
    ''' <param name="blnVisible">Indicates whether the animation is visible or not.</param>
    ''' <remarks></remarks>
    Private Sub SetCgAnimation1Visible(ByVal blnVisible As Boolean)

        If Me.CgAnimation1.InvokeRequired Then
            Dim d As New SetCgAnimation1VisibleCallback(AddressOf SetCgAnimation1Visible)
            Me.BeginInvoke(d, New Object() {blnVisible})
        Else
            Me.CgAnimation1.Visible = blnVisible
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="SetpgbSynchroValue"/>.
    ''' </summary>
    ''' <param name="intDone">The value of the progress bar.</param>
    ''' <remarks></remarks>
    Delegate Sub SetpgbSynchroValueCallback(ByVal intDone As Integer)
    ''' <summary>
    ''' Safe cross-thread method to set the progressbar value.
    ''' </summary>
    ''' <param name="intDone">The value of the progress bar.</param>
    ''' <remarks></remarks>
    Private Sub SetpgbSynchroValue(ByVal intDone As Integer)

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New SetpgbSynchroValueCallback(AddressOf SetpgbSynchroValue)
            Me.BeginInvoke(d, New Object() {intDone})
        Else
            Me.pgbSynchro.Value = intDone
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="SetpgbSynchroStyle"/>.
    ''' </summary>
    ''' <remarks></remarks>
    Delegate Sub SetpgbSynchroStyleCallback(ByVal pgbStyle As ProgressBarStyle)
    ''' <summary>
    ''' Safe cross-thread method to change the progress bar style.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetpgbSynchroStyle(ByVal pgbStyle As ProgressBarStyle)

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New SetpgbSynchroStyleCallback(AddressOf SetpgbSynchroStyle)
            Me.BeginInvoke(d, New Object() {pgbStyle})
        Else
            Me.pgbSynchro.Style = pgbStyle
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="SetCgAnimationToShowMode"/>.
    ''' </summary>
    ''' <param name="strFileName">Path to the AVI file to show.</param>
    ''' <remarks></remarks>
    Delegate Sub SetCgAnimationToShowModeCallback(ByVal strFileName As String)
    ''' <summary>
    ''' Safe cross-thread method to set the animation to show mode.
    ''' </summary>
    ''' <param name="strFileName">Path to the AVI file to show.</param>
    ''' <remarks></remarks>
    Private Sub SetCgAnimationToShowMode(ByVal strFileName As String)

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New SetCgAnimationToShowModeCallback(AddressOf SetCgAnimationToShowMode)
            Me.BeginInvoke(d)
        Else
            With Me.CgAnimation1
                .Visible = True
                .FileName = strFileName
                .AVIFileType = CG.Animation.CGAVIFileType.ExternalFile
                .Play()
            End With
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="SetCgAnimationToCopyMode"/>.
    ''' </summary>
    ''' <remarks></remarks>
    Delegate Sub SetCgAnimationToCopyModeCallback()
    ''' <summary>
    ''' Safe cross-thread method to set the animation to copy mode.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCgAnimationToCopyMode()

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New SetCgAnimationToCopyModeCallback(AddressOf SetCgAnimationToCopyMode)
            Me.BeginInvoke(d)
        Else
            With Me.CgAnimation1
                .FileName = My.Application.Info.DirectoryPath & "\Resources\filecopy.avi"
                .AVIFileType = CG.Animation.CGAVIFileType.ExternalFile
                .Play()
            End With
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="SetCgAnimationToSearchMode"/>.
    ''' </summary>
    ''' <remarks></remarks>
    Delegate Sub SetCgAnimationToSearchModeCallback()
    ''' <summary>
    ''' Safe cross-thread method to set the animation to search mode.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCgAnimationToSearchMode()

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New SetCgAnimationToSearchModeCallback(AddressOf SetCgAnimationToSearchMode)
            Me.BeginInvoke(d)
        Else
            With Me.CgAnimation1
                .FileName = My.Application.Info.DirectoryPath & "\Resources\search.avi"
                .AVIFileType = CG.Animation.CGAVIFileType.ExternalFile
                .Play()
            End With
        End If

    End Sub

    ''' <summary>
    ''' Delegate for <see cref="StopCgAnimation"/>.
    ''' </summary>
    ''' <remarks></remarks>
    Delegate Sub StopCgAnimationCallback()
    ''' <summary>
    ''' Safe cross-thread method to stop the animation.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StopCgAnimation()

        If Me.pgbSynchro.InvokeRequired Then
            Dim d As New StopCgAnimationCallback(AddressOf StopCgAnimation)
            Me.BeginInvoke(d)
        Else
            With Me.CgAnimation1
                .Stop()
                .FileName = ""
                .Visible = False
            End With
        End If

    End Sub

#End Region

End Class

''' <summary>
''' Results of the synchronization passed as arguments to the SyncDone event.
''' </summary>
''' <remarks></remarks>
Public Class SynchroResults
    Inherits EventArgs

    ''' <summary>
    ''' Status.
    ''' </summary>
    ''' <remarks></remarks>
    Public Status As SyncStatus
    ''' <summary>
    ''' Options.
    ''' </summary>
    ''' <remarks></remarks>
    Public Options As SyncOptions

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="SyncStatus">Status.</param>
    ''' <param name="SyncOptions">Options.</param>
    ''' <remarks>Wrap the data.</remarks>
    Public Sub New(ByVal SyncStatus As SyncStatus, ByVal SyncOptions As SyncOptions)
        Status = SyncStatus
        Options = SyncOptions
    End Sub

End Class

''' <summary>
''' Synchronization options.
''' </summary>
''' <remarks>0 by default.</remarks>
Public Enum SyncOptions
    ''' <summary>
    ''' Default value.
    ''' </summary>
    ''' <remarks></remarks>
    SyncDefault = 0
    ''' <summary>
    ''' /s
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopySubDirectories = 1
    ''' <summary>
    ''' /e
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopyEmptySubDirectories = 2
    ''' <summary>
    ''' /r
    ''' </summary>
    ''' <remarks></remarks>
    SyncOverWriteReadOnly = 4
    ''' <summary>
    ''' /d
    ''' </summary>
    ''' <remarks></remarks>
    SyncPreserveNewerFiles = 8
    ''' <summary>
    ''' /u
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopyOnlyExistingFiles = 16
    ''' <summary>
    ''' /z
    ''' </summary>
    ''' <remarks></remarks>
    SyncSynchronize = 32
    ''' <summary>
    ''' /n 
    ''' </summary>
    ''' <remarks></remarks>
    SyncDontPromptBeforeCreatingFiles = 64
    ''' <summary>
    ''' /y
    ''' </summary>
    ''' <remarks></remarks>
    SyncDontPromptBeforeDeletingFiles = 128
    ''' <summary>
    ''' /w
    ''' </summary>
    ''' <remarks></remarks>
    SyncPromptBeforeClosingWindow = 256
    ''' <summary>
    ''' /g
    ''' </summary>
    ''' <remarks></remarks>
    SyncDontStopOnErrors = 512
    ''' <summary>
    ''' /l
    ''' </summary>
    ''' <remarks></remarks>
    SyncLog = 1024
    ''' <summary>
    ''' /q
    ''' </summary>
    ''' <remarks></remarks>
    SyncQuick = 2048
    ''' <summary>
    ''' /a
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopyAcl = 4096
    ''' <summary>
    ''' /k
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopyAttributes = 8192
    ''' <summary>
    ''' /samba
    ''' </summary>
    ''' <remarks></remarks>
    SyncCopySamba = 16834

End Enum

''' <summary>
''' Status of the synchronization.
''' </summary>
''' <remarks></remarks>
Public Enum SyncStatus
    ''' <summary>
    ''' Not started or finished. The parent window cannot be closed if the status is different.
    ''' </summary>
    ''' <remarks></remarks>
    SyncStopped = 0
    ''' <summary>
    ''' Deferred until the handle is created.
    ''' </summary>
    ''' <remarks></remarks>
    SyncDeferred = 1
    ''' <summary>
    ''' Ready: the handle has been created.
    ''' </summary>
    ''' <remarks></remarks>
    SyncReady = 2
    ''' <summary>
    ''' Running
    ''' </summary>
    ''' <remarks></remarks>
    SyncRunning = 4
    ''' <summary>
    ''' Cancel required, waiting for the synchro thread to stop.
    ''' </summary>
    ''' <remarks></remarks>
    SyncCancelling = 8
    ''' <summary>
    ''' Almost stopped. The program can exit but no new thread can be launched yet.
    ''' </summary>
    ''' <remarks></remarks>
    SyncStopping = 16
    ''' <summary>
    ''' Finished successfully.
    ''' </summary>
    ''' <remarks></remarks>
    SyncSucceeded = 32
    ''' <summary>
    '''  There was nothing to copy (e.g. the root folder was excluded by the options).
    ''' </summary>
    ''' <remarks></remarks>
    SyncNothingToDo = 64
    ''' <summary>
    ''' Failed.
    ''' </summary>
    ''' <remarks></remarks>
    SyncFailed = 128
    ''' <summary>
    ''' Cancelled by the user.
    ''' </summary>
    ''' <remarks></remarks>
    SyncCancelled = 256
End Enum

''' <summary>
''' Animation AVI 
''' </summary>
''' <remarks>Same as in CG.Animation but necessary for using .Show. NoAnimation added.</remarks>
Public Enum AVIFileType
    ''' <summary>
    ''' No animation.
    ''' </summary>
    ''' <remarks></remarks>
    NoAnimation = -1
    ''' <summary>
    ''' External file (path is necessary).
    ''' </summary>
    ''' <remarks></remarks>
    ExternalFile = 0
    ''' <summary>
    ''' Search for folder.
    ''' </summary>
    ''' <remarks></remarks>
    Search4Folder = 150
    ''' <summary>
    ''' Search for computer.
    ''' </summary>
    ''' <remarks></remarks>
    Search4Computer = 152
    ''' <summary>
    ''' Search for file.
    ''' </summary>
    ''' <remarks></remarks>
    Search4File = 151
    ''' <summary>
    ''' Search the web.
    ''' </summary>
    ''' <remarks></remarks>
    SearchWeb = 166
    ''' <summary>
    ''' Copy settings
    ''' </summary>
    ''' <remarks></remarks>
    CopySettings = 165
    ''' <summary>
    '''  Copy file.
    ''' </summary>
    ''' <remarks></remarks>
    CopyFile = 161
    ''' <summary>
    ''' Delete file.
    ''' </summary>
    ''' <remarks></remarks>
    DeleteFile = 164
    ''' <summary>
    '''  Move file.
    ''' </summary>
    ''' <remarks></remarks>
    MoveFile = 160
    ''' <summary>
    ''' Delete to recycle bin.
    ''' </summary>
    ''' <remarks></remarks>
    Delete2RecycleBin = 162
    ''' <summary>
    ''' Clean recycle bin.
    ''' </summary>
    ''' <remarks></remarks>
    CleanRecycleBin = 163
End Enum