Imports System.IO

Public Class frmSettings
    Private ds As New Settings_MuVi2

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Load_Settings(sSettings_File_Name)

    End Sub

    Private Sub Load_Settings(ByVal sFilename As String)

        Me.txtHostName.Text = ds.Host_Name(sFilename)
        Me.txtCommandPort.Text = ds.Command_Port(sFilename)
        Me.txtFeedbackPort.Text = ds.Feedback_Port(sFilename)
        Me.chkFeedback.Checked = ds.Use_Feedback(sFilename)
        Me.txtClarityJob.Text = ds.Clarity_Job_Filename(sFilename)
        Me.udPage_Number.Value = ds.Page_Number(sFilename)
        Me.udChannel.Value = ds.Channel_Number(sFilename)
        Me.udField_Number.Value = ds.Field_Number(sFilename)
        Me.udJob_Load_Timeout.Value = ds.Job_Load_Timeout(sFilename)
        Me.chkHD.Checked = ds.HD(sFilename)
        Me.txtHD_Folder_Suffix.Text = ds.HD_Folder_Suffix(sFilename)
        Me.txtClip_Delay.Text = ds.Clip_Delay(sFilename)
        Me.txtStill_Delay.Text = ds.Still_Delay(sFilename)
        Me.udStart_Page.Value = ds.Package_Start_Page(sFilename)
        Me.txtPackage_Path.Text = ds.Package_Folder(sFilename)
        Me.txtPackage_Prefix.Text = ds.Package_Prefix(sFilename)
        Me.txtDate_Format.Text = ds.Package_Data_Format(sFilename)
        Me.txtPackage_Suffix.Text = ds.Package_Suffix(sFilename)
        Me.txtData_Connection.Text = ds.Data_Connection_String(sFilename)
        Me.txtServer_Address.Text = ds.FTP_Server_Address(sFilename)
        Me.txtUser_Name.Text = ds.FTP_Username(sFilename)
        Me.txtPassword.Text = ds.FTP_Password(sFilename)
        Me.txtClipstore_Name.Text = ds.Clipstore_Name(sFilename)
        Me.txtFTP_Port.Text = ds.FTP_Port_Number(sFilename).ToString
        Me.txtTimeout.Text = ds.FTP_Timeout_ms(sFilename).ToString
        Me.chkDelete_Temporary.Checked = ds.Delete_Temporary_Files(sFilename)
        Me.txtUn_Package_Folder.Text = ds.Un_Package_Root_Folder(sFilename)
        Me.cmbOverwrite.SelectedItem = ds.Overwrite_Mode(sFilename)
        Me.txtEmulated_Clip_Path.Text = ds.Emulated_Clips_Folder(sFilename)
        Me.txtJob_Clips.Text = ds.Job_Clips_Subfolder(sFilename)
        Me.chkDelete_Temp_Clips.Checked = ds.Delete_Temporary_Clarity_Clips(sFilename)
        Me.txtUnPack_HostName.Text = ds.Unpackage_Host_Name(sFilename)
        Me.txtUnpack_CommandPort.Text = ds.Unpackage_Command_Port(sFilename)
        Me.txtUnpack_FeedbackPort.Text = ds.Unpackage_Feedback_Port(sFilename)
        Me.chkUnpack_UseFeedback.Checked = ds.Unpackage_Use_Feedback(sFilename)
        Me.udPackage_Timeout.Value = ds.Unpackage_Job_Load_Timeout(sFilename)
        Me.chkOpen_After_Unpackage.Checked = ds.Open_Job_After_Unpackage(sFilename)
        Me.txtUnpackage_Package_Path.Text = ds.Unpackage_Package_Folder(sFilename)
        Me.chkUse_V7.Checked = ds.Use_V7_Commands(sFilename)
        Me.chkLog_Clarity_Events.Checked = ds.Log_Clarity_Events(sFilename)
        Me.chkStart_Unpackaging.Checked = ds.Start_Unpackaging(sFilename)
        Me.chkJob_Temp_Folder.Checked = ds.Put_Unpackaged_Job_In_Temp_Folder(sFilename)
        Me.txtEmptyJob.Text = ds.Empty_V7_Job(sFilename)
        Me.chkGenerate_Receipt.Checked = ds.Generate_Receipt(sFilename)
        Me.txtReceipt_Path.Text = ds.Receipt_Folder(sFilename)
        Me.chkAlpha.Checked = ds.Alpha_Enabled_Job(sFilename)
        Me.udStill_Field_Number.Value = ds.Still_Field_Number(sFilename)
        Me.txtEmptyClip.Text = ds.Empty_Clip(sFilename)
        Me.txtEmptyStill.Text = ds.Empty_Still(sFilename)
        Me.txtHD_Archived_Clips.Text = ds.Archive_HD(sFilename)
        Me.txtSD_Archived_Clips.Text = ds.Archive_SD(sFilename)
        Me.txtSpreadsheet_Folder.Text = ds.Spreadsheet_Folder(sFilename)
        Me.chkShow_Clarity_Transfer.Checked = ds.Show_Clarity_Transfer(sFilename)

        Me.txtExample.Text = String.Concat(ds.Package_Folder(sFilename), ds.Package_Base, ".zip")

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        ds.Save_Settings(Me, sSettings_File_Name)
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub
    Private Sub cmdClarityJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClarityJob.Click
        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "Pixel Power Files(*.ppj;*.pjz)|*.ppj;*.pjz;|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.InitialDirectory = "C:\"
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtClarityJob.Text = Me.OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub cmdEmptyJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmptyJob.Click

        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "Pixel Power Files(*.ppj;*.pjz)|*.ppj;*.pjz;|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.InitialDirectory = "C:\"
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtEmptyJob.Text = Me.OpenFileDialog1.FileName
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim objClarity As New Clarity(mm)

        If objClarity.Connect Then
            MessageBox.Show("Connected")
            If objClarity.Disconnect Then
                MessageBox.Show("Disconnected")
            End If
        End If

    End Sub

    Private Sub chkFeedback_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFeedback.CheckedChanged, chkUse_V7.CheckedChanged

        Me.txtFeedbackPort.Enabled = Me.chkFeedback.Checked

    End Sub



    Private Sub cmdPackagePath_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackagePath_Browse.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Package Folder")
        If sFolder <> "" Then
            Me.txtPackage_Path.Text = sFolder
        End If

    End Sub

    Private Sub cmdReceiptPath_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceipt_Path.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Receipt Folder")
        If sFolder <> "" Then
            Me.txtReceipt_Path.Text = sFolder
        End If

    End Sub
    Private Sub txtPackage_Prefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPackage_Prefix.TextChanged, txtDate_Format.TextChanged, _
                                                                                                                        txtPackage_Suffix.TextChanged, txtPackage_Path.TextChanged, txtJob_Clips.TextChanged, txtReceipt_Path.TextChanged

        Me.txtExample.Text = String.Concat(Me.txtPackage_Path.Text, ds.Package_Base(Me.txtPackage_Prefix.Text, Me.txtDate_Format.Text, Me.txtPackage_Suffix.Text))

    End Sub


    Private Function Choose_Folder(ByVal sMessage As String) As String

        Me.FolderBrowserDialog1.Description = sMessage
        Me.FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        Me.FolderBrowserDialog1.ShowNewFolderButton = True
        If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Return Fix_Folder_End(Me.FolderBrowserDialog1.SelectedPath, Media_Type.Still)
        Else
            Return ""
        End If

    End Function


    Private Sub cmdBrowse_Unpackage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse_Unpackage.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Un-package folder")
        If sFolder <> "" Then
            Me.txtUn_Package_Folder.Text = sFolder
        End If

    End Sub


    Private Sub cmdBrowse_Emulated_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse_Emulated.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Emulated Clip Folder")
        If sFolder <> "" Then
            Me.txtEmulated_Clip_Path.Text = sFolder
        End If

    End Sub

    Private Sub cmdTest_Unpack_Clarity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest_Unpack_Clarity.Click

        Dim myMessage As New mMessage(Me.ListBox1, False, False)
        Dim objClarity As New Clarity(myMessage)

        Me.ListBox1.Visible = True
        If objClarity.Connect(True) Then
            MessageBox.Show("Connected")
            If objClarity.Disconnect Then
                MessageBox.Show("Disconnected")
            End If
        End If
    End Sub

    Private Sub cmdLoad_Profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad_Profile.Click

        Dim fi As FileInfo

        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "XML Settings file(*.xml)|*.xml|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        fi = New FileInfo(sSettings_File_Name)
        Me.OpenFileDialog1.InitialDirectory = fi.DirectoryName
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Me.OpenFileDialog1.FileName <> "" Then
                Load_Settings(Me.OpenFileDialog1.FileName)
            End If
        End If

    End Sub

    Private Sub cmdSave_Profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave_Profile.Click

        Dim fi As FileInfo

        Me.SaveFileDialog1.CheckFileExists = False
        Me.SaveFileDialog1.CheckPathExists = True
        Me.SaveFileDialog1.Filter = "XML Settings file(*.xml)|*.xml|All files (*.*)|*.*"
        Me.SaveFileDialog1.FilterIndex = 1
        fi = New FileInfo(sSettings_File_Name)
        Me.SaveFileDialog1.InitialDirectory = fi.DirectoryName
        Me.SaveFileDialog1.FileName = ""

        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
            If Me.SaveFileDialog1.FileName <> "" Then
                ds.Save_Settings(Me, Me.SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    
    Private Sub cmdUnpackage_Path_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnpackage_Path.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Unpackaging Package Folder")
        If sFolder <> "" Then
            Me.txtUnpackage_Package_Path.Text = sFolder
        End If

    End Sub

    Private Sub Show_Tabs(ByVal bUnpackage_Only As Boolean)

        If bUnpackage_Only Then
            tabSettings.TabPages.Remove(TabPage1)
            tabSettings.TabPages.Remove(TabPage2)
            tabSettings.TabPages.Remove(TabPage3)
        Else
            If Not tabSettings.TabPages.Contains(TabPage1) Then tabSettings.TabPages.Insert(0, TabPage1)
            If Not tabSettings.TabPages.Contains(TabPage2) Then tabSettings.TabPages.Insert(1, TabPage2)
            If Not tabSettings.TabPages.Contains(TabPage3) Then tabSettings.TabPages.Insert(2, TabPage3)
        End If
        tabSettings.SelectTab(0)

    End Sub

    
    Private Sub chkStart_Unpackaging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStart_Unpackaging.CheckedChanged

        Show_Tabs(chkStart_Unpackaging.Checked)

    End Sub

    Private Sub chkAlpha_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAlpha.CheckedChanged

        If chkAlpha.Checked Then
            Me.lblClipField.Text = "Clip Field Number"
        Else
            Me.lblClipField.Text = "Field Number"
        End If

        Me.lblStillField.Enabled = chkAlpha.Checked
        Me.udStill_Field_Number.Enabled = chkAlpha.Checked
        Me.txtEmptyStill.Enabled = chkAlpha.Checked
        Me.txtEmptyClip.Enabled = chkAlpha.Checked
        Me.cmdBrowseEmptyClip.Enabled = chkAlpha.Checked
        Me.cmdBrowseEmptyStill.Enabled = chkAlpha.Checked

    End Sub

    
    Private Sub cmdBrowseEmptyClip_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowseEmptyClip.Click

        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "Pixel Power Video Files(*.ppv)|*.ppv;|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.InitialDirectory = Me.txtEmulated_Clip_Path.Text
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtEmptyClip.Text = Convert_PC_to_Clip_Filename(Me.OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub cmdBrowseEmptyStill_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowseEmptyStill.Click

        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.Filter = "Targa Files(*.tga)|*.tga;|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.InitialDirectory = "C:\"
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtEmptyStill.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

   
    Private Sub cmdBrowse_HD_Archive_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse_HD_Archive.Click

        Dim sFolder As String
        sFolder = Choose_Folder("HD Archived Clip Folder")
        If sFolder <> "" Then
            Me.txtHD_Archived_Clips.Text = sFolder
        End If

    End Sub

    Private Sub cmdBrowse_SD_Archive_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse_SD_Archive.Click

        Dim sFolder As String
        sFolder = Choose_Folder("SD Archived Clip Folder")
        If sFolder <> "" Then
            Me.txtSD_Archived_Clips.Text = sFolder
        End If

    End Sub

    Private Sub cmdBrowse_Spreadsheet_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse_Spreadsheet.Click

        Dim sFolder As String
        sFolder = Choose_Folder("Spreadsheet Folder")
        If sFolder <> "" Then
            Me.txtSpreadsheet_Folder.Text = sFolder
        End If

    End Sub
End Class
