Imports Ionic.Zip
Imports System.IO

Public Class Unpackage
    Private objSettings As Settings_MuVi2
    Private mm As mMessage


    Private Sub Unpackage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mm = New mMessage(Me.ListBox1, True)
        objSettings = New Settings_MuVi2

    End Sub


    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "Zip Files(*.zip)|*.zip|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.InitialDirectory = objSettings.Unpackage_Package_Folder(sSettings_File_Name)
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtPackaged_Zip.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub


    Private Sub cmdUn_Package_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUn_Package.Click

        UnZip()

    End Sub



    Private Sub UnZip()
        Dim Overwrite As ExtractExistingFileAction
        Dim ZipToUnpack As String
        Dim UnpackDirectory As String
        Dim fi As FileInfo
        Dim di As DirectoryInfo
        Dim sClipFiles() As String
        Dim lNum_Clips As Long
        Dim objClarity As Clarity
        Dim bClarity_Success As Boolean
        Dim sJob_Filename As String
        Dim Response As DialogResult
        Dim bDo_FTP As Boolean

        Select Case UCase(objSettings.Overwrite_Mode(sSettings_File_Name))
            Case "OVERWRITE"
                Overwrite = ExtractExistingFileAction.OverwriteSilently
            Case "SKIP"
                Overwrite = ExtractExistingFileAction.DoNotOverwrite
            Case "ASK"
                Overwrite = ExtractExistingFileAction.InvokeExtractProgressEvent
            Case Else
                Overwrite = ExtractExistingFileAction.InvokeExtractProgressEvent
        End Select

        lNum_Clips = 0
        ReDim sClipFiles(lNum_Clips)
        sJob_Filename = ""

        mm.Output_Time = False
        mm.Add(String.Format("ClarityGen Unpackage. Version: {0}", sVersionString))
        mm.Add("======================================")
        mm.Output_Time = True
        MyBase.Update()

        ZipToUnpack = Me.txtPackaged_Zip.Text
        fi = New FileInfo(ZipToUnpack)
        If fi.Exists And fi.Extension.Equals(".zip", StringComparison.CurrentCultureIgnoreCase) Then
            UnpackDirectory = objSettings.Un_Package_Root_Folder(sSettings_File_Name)
            di = New DirectoryInfo(UnpackDirectory)
            If Not di.Exists Then
                di.Create()
            End If
            mm.Add(String.Format("Extracting file {0} to {1}", ZipToUnpack, UnpackDirectory))
            MyBase.Update()
            Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                AddHandler zip1.ExtractProgress, AddressOf MyExtractProgress
                Dim e As ZipEntry
                ' here, we extract every entry, but we could extract conditionally,
                ' based on entry name, size, date, checkbox status, etc.   
                For Each e In zip1
                    e.Extract(UnpackDirectory, Overwrite)
                    If e.FileName.Contains("Clip") And e.FileName.EndsWith(".ppv", StringComparison.CurrentCultureIgnoreCase) Then
                        ReDim Preserve sClipFiles(lNum_Clips)
                        sClipFiles(lNum_Clips) = e.FileName
                        lNum_Clips += 1
                    ElseIf e.FileName.EndsWith(".ppj") Or e.FileName.EndsWith(".pjz") Then
                        sJob_Filename = Zip_To_Job_Filename(e.FileName)
                    End If
                Next
            End Using
            mm.Add("Unzip complete")
            MyBase.Update()
            Me.ProgressBar1.Value = 0

            objClarity = New Clarity(mm)
            If objClarity.Connect(True) Then
                If objClarity.Connect_Feedback(True) Then
                    bClarity_Success = objClarity.Send_Heartbeat(objSettings.Unpackage_Job_Load_Timeout(sSettings_File_Name))
                Else
                    bClarity_Success = False
                End If
            Else
                bClarity_Success = False
            End If
            bDo_FTP = True
            If Not bClarity_Success Then
                Response = MessageBox.Show("Clarity not connected. Continue anyway?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                bDo_FTP = Response = Windows.Forms.DialogResult.Yes
            End If

            If bDo_FTP Then
                FTP_Clips(sClipFiles)
                If sJob_Filename <> "" And objSettings.Open_Job_After_Unpackage(sSettings_File_Name) Then
                    objClarity.Load_Job(sJob_Filename)
                    objClarity.Job_Load_Wait(Me.ProgressBar1, sJob_Filename, objSettings.Unpackage_Job_Load_Timeout(sSettings_File_Name))
                End If
            End If

            objClarity.Disconnect()
        Else
            mm.Add(String.Format("Invalid zip file: {0}", ZipToUnpack))
            MessageBox.Show(String.Format("Invalid zip file: {0}", ZipToUnpack), "Invalid Zip", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MyExtractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)

        Dim Response As DialogResult

        Select Case e.EventType
            Case ZipProgressEventType.Extracting_BeforeExtractEntry
                mm.Add(String.Format("Extracting: {0}", e.CurrentEntry.FileName))
                Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Maximum = e.TotalBytesToTransfer
                MyBase.Update()
            Case ZipProgressEventType.Extracting_EntryBytesWritten
                If Me.ProgressBar1.Maximum < e.BytesTransferred Then
                    Me.ProgressBar1.Maximum = e.TotalBytesToTransfer
                End If
                Me.ProgressBar1.Value = e.BytesTransferred
                MyBase.Update()
            Case ZipProgressEventType.Extracting_AfterExtractAll
                mm.Add("Unzip complete")
                MyBase.Update()
            Case ZipProgressEventType.Extracting_ExtractEntryWouldOverwrite
                Response = MessageBox.Show(String.Format("The file: {0} already exists. Do you wish to overwrite?", e.CurrentEntry.FileName), "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Response = DialogResult.Yes Then
                    e.CurrentEntry.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently
                Else
                    e.CurrentEntry.ExtractExistingFile = ExtractExistingFileAction.DoNotOverwrite
                End If

        End Select

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        mm.Clear()

    End Sub

    Private Sub FTP_Clips(ByVal sFiles() As String)

        Dim objFTP As MuVi2_FTP
        Dim sFile As String
        Dim sSource As String
        Dim sDestination As String
        Dim sWorking As String
        Dim fi As FileInfo

        objFTP = New MuVi2_FTP(mm, ProgressBar1)
        objFTP.Connect()

        For Each sFile In sFiles
            sSource = Zip_To_Job_Clips_Filename(sFile)
            sDestination = Zip_To_Clarity_Clip_Filename(sFile)
            sWorking = Zip_To_Clarity_FTP_Folder(sFile)
            Try

                objFTP.Transfer_File(sSource, sWorking, sDestination)
                If objSettings.Delete_Temporary_Clarity_Clips(sSettings_File_Name) Then
                    fi = New FileInfo(sSource)
                    fi.Delete()
                    mm.Add(String.Format("Temporary clip file deleted: {0}", sSource))
                End If
            Catch ex As Exception
                mm.Add(ex.Message)
            End Try

        Next

        mm.Add("Transfer Complete")
        ProgressBar1.Value = 0

        objFTP.Disconnect()

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

        Dim f As New frmSettings

        f.Show()
        f = Nothing

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click

        MessageBox.Show(String.Concat("MuVi2 ClarityGen Approval and Packaging", Environment.NewLine, _
                               "Version: ", sVersionString), "MuVi2", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class