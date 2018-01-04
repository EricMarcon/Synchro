# Synchro
**Synchronize folders for Windows.**

The Synchro control is a Visual Studio multithreaded user control allowing folder copy and synchronization. 
The control is visually a progress bar that can be added to a form. 
After its properties have been set, it can be launched by its method `SyncStart`. 
A separate thread is run so the program interface remains reactive. 
When it is done, it raises an event `SyncDone`. 
It may also be used in a console application, as a single thread.

The example application uses all the control properties and shows how to get information about the control status and treat the final event. 
It allows synchronizing several folders at the same time and saving parameters as documents. 
It runs both interactively or as a command line (see Help for the syntax). 
It was not written to replace Robocopy (from Windows Resource Kit) as a tool typically used in a scheduled task. 
_Synchro_ (the application) is, however, much easier to use by common people.

## Download binaries

- [x64](Synchro.x64.exe): For any x64 version of Windows > XP SP3. Recommended.

- [x86](Synchro.exe): for any version of Windows > XP SP3.

The installers will download .NET Framework 4.7 if needed.


## Using the code

The control is in the _ctlSynchro_ folder. The folder can be added to your project. It is currently localized in French and English.

Put the control (say `ctlSynchro1`) onto your form and set its properties:

- Public `strSource` As String: Source directory.

- Public `strTarget` As String: Target folder.

- Public `strExcludedStrings` As String: File and folder name patterns excluded from the copy.

- Public `synOptions` As SyncOptions: Synchronization options, a combination of option values.

- Public `strLogFile` As String: Log file name.

- Public `blnConsoleMode` As Boolean: Choose between form/multithread or console/single thread mode.

Option values are:

- `SyncCopySubDirectories` = 1. Copy subdirectories.

- `SyncCopyEmptySubDirectories` = 2 . Copy empty subdirectories too.

- `SyncOverWriteReadOnly` = 4. Overwrite read-only files and folders, if necessary.

- `SyncPreserveNewerFiles` = 8. This option uses the UTC time of the last file modification. It works on an NTFS file system only. Tested on a Netware file server, it always rewrites the files. Not tested on Windows 98.

- `SyncCopyOnlyExistingFiles` = 16. Do not copy a file if it does not already exist (in other words, just update, never create files).

- `SyncSynchronize` = 32. Delete target files or folders if they do not exist in the source.

- `SyncDontPromptBeforeCreatingFiles` = 64. Do not ask for confirmation when a new file must be created.

- `SyncDontPromptBeforeDeletingFiles` = 128. Do not ask for confirmation when a file or a folder must be deleted.

- `SyncPromptBeforeClosingWindow` = 256. Display a message box at the end of the process (else, close the current window).

- `SyncDontStopOnErrors` = 512. Continue when an error occurs.

- `SyncLog` = 1024. Log actions to a file.

- `SyncQuick` = 2048. Do not evaluate the size and number of files to copy to save time, start copying immediately (the progress bar will not be able to show progression).

- `SyncCopyAcl` = 4096. Copy files and folders ACL's.

- `SyncCopyAttributes` = 8192. Copy file and folder attributes.

- `SyncCopySamba` = 16834. Consider file timestamps are equal even when they are a bit different. Tolerance is given by `SambaTimeError` (in ms, 1000 by default). This option is necessary if the target is a Samba NAS for example, or many files that have not been modified will be copied every time despite the `SyncPreserveNewerFiles` option because timestamps are rounded by Samba.
The example application (`frmDocument` form) uses checkboxes to set the options and the `CalculateOptions` Sub to set `syncOptions` according to them.

Start the job with `ctlSynchro1.SyncStart`.

At any time, the following public properties are used to follow what the control is doing:

- Public `strWhatsOn` As String: Describe what the synchro thread is doing. Displayed in the "File being processed" box of the application.

- Public `lngSyncCopySize` As Long: Bytes to copy.

- Public `lngSyncCopyDone` As Long: Bytes already copied. Not used in the example: the progress bar is enough.

- Public `strCopied` As String(): List of completed actions. Displayed in the form list.

- Public `RunningStatus` As SyncStatus: Status of the copy. See below.

- Public `thrSynchro` As Threading.Thread: The thread run for actual synchronization itself, for special purposes.

- Public `ExitStatus` As SyncStatus: Status returned in console mode. Useless in multithread mode (use the status returned by SyncDone).


Running status may be:


- `SyncStopped` = 0: Not started or finished. The parent window should not be closed if the status is not stopped or stopping.

- `SyncDeferred` = 1: Deferred until the handle of the parent window is created. Never a problem if you use the .NET GDI to put the control into the form.

- `SyncReady` = 2: Ready: The handle has been created.

- `SyncRunning` = 4: Running.

- `SyncCancelling` = 8: Cancel requested, waiting for the synchro thread to stop. Cancel may be requested by the user (the Stop button of the example) or by the control itself if an error has occurred.

- `SyncStopping` = 16: Almost finished. The parent window can be closed but no other synchronization can be launched.
The frmDocument_closing Sub shows how to check that the status is actually SyncStopping or SyncStopped before closing the form.

During the process, it may be useful to show detailed information about what is going on. 
By default, the progress bar is the only thing visible. 
A way to do this is to use a timer. 
In the example, a timer is activated just after `SyncStart` and regularly (the frequency is chosen as an option) runs `RefreshDisplay`. See the code for details.

The process can be aborted by the `SyncStop` method (called by the Stop button on the form).

When the synchronization is done, a `SyncDone` event is raised by the control. 
A handler must be added to the form code. 
It may use a message box to confirm the results. 
See the code for the `CtlSynchro1.SyncDone` handler in _frmDocument.vb_.

Finally, the thread `thrSynchro` can be accessed directly for advanced purposes: you may want to suspend it or wait for it to complete (_join_).

## Other people's work

The `Arguments` class, a command line parser, is a straight Basic adaptation of the C# version available on CodeProject.

_.NET Animation Control_ is a control to show animations, available on CodeProject.

## License

This article, along with any associated source code and files, is licensed under The GNU General Public License (GPLv3).
