Imports System.Resources

''' <summary>
''' Start module.
''' </summary>
''' <remarks></remarks>
Module Start

    ' Global declarations
    ''' <summary>
    ''' The main form.
    ''' </summary>
    ''' <remarks></remarks>
    Friend frmSynchro As frmMain

    ''' <summary>
    ''' Array of the command line arguments.
    ''' </summary>
    ''' <remarks></remarks>
    Friend cmdArguments() As String

    ''' <summary>
    ''' Declare the command line options object
    ''' </summary>
    ''' <remarks></remarks>
    Friend CommandLineArgs As CommandLine.Utility.Arguments

    ''' <summary>
    ''' The status the application returns when it leaves.
    ''' </summary>
    ''' <remarks></remarks>
    Friend ErrorStatus As Byte


    ''' <summary>
    ''' Start the application, read the command line arguments.
    ''' </summary>
    ''' <param name="CmdArgs">Command line arguments.</param>
    ''' <returns>The exit code.</returns>
    ''' <remarks></remarks>
    Friend Function Main(ByVal CmdArgs() As String) As Integer

        ' Debug purpose only: set the culture to invariant
        'System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture
        'System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture

        Dim blnOptionsOK As Boolean = True
        Dim blnConsoleMode As Boolean

        ' Initialize variables
        ErrorStatus = 0

        ' Read the command line arguments
        cmdArguments = CmdArgs
        ' And interpret it
        If cmdArguments.GetLength(0) > 0 Then
            ' If arguments were sent
            CommandLineArgs = New CommandLine.Utility.Arguments(cmdArguments)
        End If

        ' Choose between form and console application
        If CommandLineArgs IsNot Nothing Then
            If CommandLineArgs.Item("go") IsNot Nothing Or CommandLineArgs.Item("help") IsNot Nothing Then
                ' Console mode if option /go or /help
                blnConsoleMode = True
            End If
        End If

        ' Run the application
        If blnConsoleMode Then
            ' No form will be opened. Create a standalone synchro control.
            Dim CtlSynchro1 As New ctlSynchro
            CtlSynchro1.ConsoleMode = True

            ' Eventually read the file
            If CommandLineArgs.Item("help") Is Nothing Then
                ' No /? in the options
                Dim strFile As String = cmdArguments(0)
                If (strFile.Chars(0) <> "-") And (strFile.Chars(0) <> "/") Then
                    ' The first argument is not an option, so it is a file name. Open it.
                    Dim sr As System.IO.StreamReader = Nothing
                    Try
                        ' Open the file
                        sr = System.IO.File.OpenText(strFile)
                        ' Read the source, the target and the options
                        CtlSynchro1.Source = sr.ReadLine()
                        CtlSynchro1.Target = sr.ReadLine()
                        CtlSynchro1.Options = CType(sr.ReadLine(), SyncOptions)
                        CtlSynchro1.LogFile = sr.ReadLine()
                        CtlSynchro1.ExcludedStrings = sr.ReadLine()
                        sr.Close()
                    Catch
                        blnOptionsOK = False
                    Finally
                        ' Close the file
                        If Not sr Is Nothing Then
                            sr.Close()
                        End If
                    End Try
                End If
            Else
                ' Help requested /help
                blnOptionsOK = False
            End If

            ' Continue with the options. They may change those from the file
            If blnOptionsOK Then
                ' Read options
                If CommandLineArgs.Item("Source") IsNot Nothing Then
                    CtlSynchro1.Source = CommandLineArgs.Item("Source")
                End If
                If CommandLineArgs.Item("Target") IsNot Nothing Then
                    CtlSynchro1.Target = CommandLineArgs.Item("Target")
                End If
                If CommandLineArgs.Item("s") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopySubDirectories
                End If
                If CommandLineArgs.Item("e") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopyEmptySubDirectories
                End If
                If CommandLineArgs.Item("r") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncOverWriteReadOnly
                End If
                If CommandLineArgs.Item("d") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncPreserveNewerFiles
                End If
                If CommandLineArgs.Item("samba") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopySamba
                End If
                If CommandLineArgs.Item("u") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopyOnlyExistingFiles
                End If
                If CommandLineArgs.Item("z") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncSynchronize
                End If
                If CommandLineArgs.Item("a") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopyAcl
                End If
                If CommandLineArgs.Item("k") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncCopyAttributes
                End If
                If CommandLineArgs.Item("n") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncDontPromptBeforeCreatingFiles
                End If
                If CommandLineArgs.Item("y") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncDontPromptBeforeDeletingFiles
                End If
                If CommandLineArgs.Item("l") IsNot Nothing Then
                    CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncLog
                    CtlSynchro1.LogFile = CommandLineArgs.Item("l")
                End If
                If CommandLineArgs.Item("x") IsNot Nothing Then
                    CtlSynchro1.ExcludedStrings = CommandLineArgs.Item("x")
                End If
                ' /g /q  are mandatory
                CtlSynchro1.Options = CtlSynchro1.Options Or SyncOptions.SyncDontStopOnErrors Or SyncOptions.SyncQuick

                ' Run. Single thread.
                CtlSynchro1.SyncStart()
                ' Get the exit status
                Select Case CtlSynchro1.ExitStatus
                    Case SyncStatus.SyncSucceeded
                        ErrorStatus = 0
                    Case SyncStatus.SyncNothingToDo
                        ErrorStatus = 1
                    Case SyncStatus.SyncFailed
                        ErrorStatus = 2
                End Select

            Else
                ' Show the syntax
                Console.WriteLine(My.Resources.strSyntaxTitle & vbCrLf & My.Resources.strSyntaxDetail _
                    & vbCrLf & vbCrLf & My.Resources.strSyntaxExample)
                ErrorStatus = 3
            End If


        Else
            ' Windows form mode. Open the main window
            frmSynchro = New frmMain
            Application.EnableVisualStyles()
            Application.Run(frmSynchro)

        End If

        ' Return the error status. May not be 0 if run in console mode.
        Return ErrorStatus

    End Function

    ''' <summary>
    ''' Replace a part of string by ... to make it fit the available space.
    ''' </summary>
    ''' <param name="MyString">Original string.</param>
    ''' <param name="Width">Available width.</param>
    ''' <param name="Font">Font</param>
    ''' <param name="FormatFlags">Format flags.</param>
    ''' <returns>A string which fits.</returns>
    ''' <remarks>http://www.codeproject.com/useritems/NewPathCompactPath.asp</remarks>
    Function CompactString(ByVal MyString As String, ByVal Width As Integer, ByVal Font As Drawing.Font, ByVal FormatFlags As Windows.Forms.TextFormatFlags) As String
        
        If MyString Is Nothing Then
            Return Nothing
        Else
            Dim Result As String = String.Copy(MyString)
            TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0), FormatFlags Or TextFormatFlags.ModifyString)
            Return Result
        End If

    End Function

End Module
