Imports System.IO
Public Class mMessage
    Private sLogPath As String = String.Concat(Application.StartupPath, "\logs\")
    Private lb As ListBox
    Private bTime As Boolean
    Private bLog_File As Boolean

    Public Sub New(ByVal l As ListBox, Optional ByVal bOutputTime As Boolean = False, Optional ByVal bLogFile As Boolean = True)

        lb = l
        bTime = bOutputTime
        bLog_File = bLogFile

        If bLogFile Then
            AutoArchiveFolder(sLogPath, "*.txt", 7, Me)
        End If

    End Sub

    Friend Sub Clear()

        lb.Items.Clear()

    End Sub

    Friend Sub Add(ByVal sMessage As String)

        If bLog_File Then
            Log_Message(sMessage)
        End If

        If bTime Then
            sMessage = String.Concat(Date.Now.ToLongTimeString, "   ", sMessage)
        End If

        lb.Items.Add(sMessage)
        MoveScroll()
        lb.Parent.Update()

    End Sub

    Friend Property Output_Time As Boolean
        Get
            Return bTime
        End Get
        Set(ByVal value As Boolean)
            bTime = value
        End Set
    End Property

    Private Sub MoveScroll()

        Dim iTopIndex As Integer
        Dim iNumLines As Int32

        iNumLines = lb.Height \ lb.ItemHeight

        iTopIndex = lb.Items.Count - iNumLines
        If iTopIndex > 0 Then
            lb.TopIndex = iTopIndex
        End If

    End Sub
    Friend Sub AutoArchiveFolder(ByVal sFolderName As String, ByVal sExt As String, _
                                                ByVal iOlderThanDays As Int32, _
                                                Optional ByRef objMessage As mMessage = Nothing)

        Dim dtOldDate As DateTime
        Dim sFiles() As String
        Dim sFile As String
        Dim fiTemp As FileInfo
        Dim sArchiveFolder As String
        Dim sTargetFile As String

        If sFolderName.EndsWith("\") Then
            sFolderName = sFolderName.Substring(0, sFolderName.Length - 1)
        End If

        dtOldDate = Now.AddDays(-iOlderThanDays)
        If sExt.Substring(0, 2) <> "*." Then
            If sExt.Substring(0, 1) <> "." Then
                sExt = String.Concat("*.", sExt)
            Else
                sExt = String.Concat("*", sExt)
            End If
        End If

        If Not (Directory.Exists(sFolderName)) Then
            Directory.CreateDirectory(sFolderName)
        End If

        sFiles = Directory.GetFiles(sFolderName, sExt)
        For Each sFile In sFiles
            fiTemp = New FileInfo(sFile)

            If fiTemp.CreationTime < dtOldDate Then
                sArchiveFolder = String.Concat(sFolderName, "\", _
                                        fiTemp.CreationTime.ToString("MMMM yyyy"), "\")
                If Not Directory.Exists(sArchiveFolder) Then
                    Directory.CreateDirectory(sArchiveFolder)
                End If
                sTargetFile = String.Concat(sArchiveFolder, fiTemp.Name)
                If File.Exists(sTargetFile) Then
                    File.Delete(sTargetFile)
                End If

                fiTemp.MoveTo(String.Concat(sArchiveFolder, fiTemp.Name))
                If Not (objMessage Is Nothing) Then
                    objMessage.Add(String.Concat("Moved: ", fiTemp.Name, _
                                                        " to: ", sArchiveFolder))
                End If
            End If
        Next
    End Sub

    Friend Property WriteLogFile() As Boolean
        Get
            Return bLog_File
        End Get
        Set(ByVal Value As Boolean)
            bLog_File = Value
        End Set

    End Property

    Private Sub Log_Message(ByVal sMessage As String)

        Dim sw As StreamWriter
        Dim sFileName As String



        If Not (Directory.Exists(sLogPath)) Then
            Directory.CreateDirectory(sLogPath)
        End If

        sFileName = sLogFileName()
        If File.Exists(sFileName) Then
            sw = File.AppendText(sFileName)
        Else
            sw = File.CreateText(sFileName)
        End If
        If bTime Then
            sw.WriteLine(String.Concat(Now.ToLongTimeString, ": ", sMessage))
        Else
            sw.WriteLine(sMessage)
        End If
        sw.Flush()
        sw.Close()

    End Sub
    Private Function sLogFileShortName()

        Dim sTemp As String

        sTemp = String.Concat("Log", Now.ToString(" - dd-MM-yyyy"), ".txt")
        Return sTemp

    End Function
    Private Function sLogFileName() As String

        Dim sTemp As String

        sTemp = String.Concat(sLogPath, sLogFileShortName)
        Return sTemp

    End Function

End Class
