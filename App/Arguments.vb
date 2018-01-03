Imports System
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Namespace CommandLine.Utility
    ''' <summary>
    ''' Arguments class.
    ''' </summary>
    Public Class Arguments

        ''' <summary>
        ''' Parameters.
        ''' </summary>
        ''' <remarks></remarks>
        Private Parameters As StringDictionary

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="Args">Command line arguments.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Args As String())

            Parameters = New StringDictionary()
            Dim Spliter As New Regex("^-{1,2}|^/|=|:", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
            Dim Remover As New Regex("^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase Or RegexOptions.Compiled)

            Dim Parameter As String = Nothing
            Dim Parts As String()

            ' Valid parameters forms: {-,/,--}param{ ,=,:}((",')value(",'))
            ' Examples: -param1 value1 --param2 /param3:"Test-:-work" /param4=happy -param5 '--=nice=--'
            For Each Txt As String In Args
                ' Look for new parameters (-,/ or --) and a possible enclosed value (=,:)
                Parts = Spliter.Split(Txt, 3)

                Select Case Parts.Length
                    Case 1
                        ' Found a value (for the last parameter found (space separator))
                        If Parameter IsNot Nothing Then
                            If Not Parameters.ContainsKey(Parameter) Then
                                Parts(0) = Remover.Replace(Parts(0), "$1")
                                Parameters.Add(Parameter, Parts(0))
                            End If
                            Parameter = Nothing
                        End If
                        ' else Error: no parameter waiting for a value (skipped)
                        Exit Select
                    Case 2
                        ' Found just a parameter
                        ' The last parameter is still waiting. 
                        ' With no value, set it to true.
                        If Parameter IsNot Nothing Then
                            If Not Parameters.ContainsKey(Parameter) Then
                                Parameters.Add(Parameter, "true")
                            End If
                        End If
                        Parameter = Parts(1)
                        Exit Select
                    Case 3
                        ' Parameter with enclosed value
                        ' The last parameter is still waiting. 
                        ' With no value, set it to true.
                        If Parameter IsNot Nothing Then
                            If Not Parameters.ContainsKey(Parameter) Then
                                Parameters.Add(Parameter, "true")
                            End If
                        End If
                        Parameter = Parts(1)
                        ' Remove possible enclosing characters (",')
                        If Not Parameters.ContainsKey(Parameter) Then
                            Parts(2) = Remover.Replace(Parts(2), "$1")
                            Parameters.Add(Parameter, Parts(2))
                        End If

                        Parameter = Nothing
                        Exit Select
                End Select
            Next
            ' In case a parameter is still waiting
            If Parameter IsNot Nothing Then
                If Not Parameters.ContainsKey(Parameter) Then
                    Parameters.Add(Parameter, "true")
                End If
            End If
        End Sub

        ''' <summary>
        ''' Retrieve a parameter value if it exists 
        ''' </summary>
        ''' <param name="Param">The parameter's name.</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Overrides indexer property</remarks>
        Default Public ReadOnly Property Item(ByVal Param As String) As String
            Get
                Return Parameters(Param)
            End Get
        End Property

    End Class
End Namespace
