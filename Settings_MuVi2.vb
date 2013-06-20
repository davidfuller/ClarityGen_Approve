Public Class Settings_MuVi2
    Private ds As TheSettings
    Private dt As TheSettings.SettingsDataTable
    Public Sub New()

        ds = New TheSettings
        dt = ds.Settings

    End Sub

    Friend Sub Save_Settings(ByVal f As frmSettings, ByVal sFilename As String)


        Dim dr As TheSettings.SettingsRow
        Dim iResult As Integer

        ds.Clear()

        dr = dt.NewSettingsRow

        dr.Host_Name = f.txtHostName.Text
        dr.Command_Port = f.txtCommandPort.Text
        dr.Use_Feedback = f.chkFeedback.Checked
        dr.Feedback_Port = f.txtFeedbackPort.Text
        dr.Clarity_Job_Filename = f.txtClarityJob.Text
        dr.Page_Number = Integer.Parse(f.udPage_Number.Value)
        dr.Channel_Number = Integer.Parse(f.udChannel.Value)
        dr.Field_Number = Integer.Parse(f.udField_Number.Value)
        dr.Job_Load_Timeout = Integer.Parse(f.udJob_Load_Timeout.Value)
        dr.HD = f.chkHD.Checked
        dr.HD_Folder_Suffix = f.txtHD_Folder_Suffix.Text
        dr.Clip_Page_Delay = f.txtClip_Delay.Text
        dr.Still_Page_Delay = f.txtStill_Delay.Text
        dr.Package_Start_Page = Integer.Parse(f.udStart_Page.Value)
        dr.Package_Folder = f.txtPackage_Path.Text
        dr.Package_Prefix = f.txtPackage_Prefix.Text
        dr.Package_Data_Format = f.txtDate_Format.Text
        dr.Package_Suffix = f.txtPackage_Suffix.Text
        dr.Data_Connection_String = f.txtData_Connection.Text
        dr.ftp_server_address = f.txtServer_Address.Text
        dr.ftp_user_name = f.txtUser_Name.Text
        dr.ftp_password = f.txtPassword.Text
        dr.Clipstore_Name = f.txtClipstore_Name.Text
        If Integer.TryParse(f.txtTimeout.Text, iResult) Then
            dr.ftp_timeout = iResult
        Else
            dr.ftp_timeout = 10000
        End If
        If Integer.TryParse(f.txtFTP_Port.Text, iResult) Then
            dr.ftp_port_no = iResult
        Else
            dr.ftp_port_no = 21
        End If
        dr.Delete_Temporary_Files = f.chkDelete_Temporary.Checked
        dr.Unpackage_Root_Folder = f.txtUn_Package_Folder.Text
        dr.Overwrite = f.cmbOverwrite.SelectedItem
        dr.Delete_Temporary_Clarity_Clips = f.chkDelete_Temp_Clips.Checked
        dr.Emulated_Clips_Folder = Un_Fix_Folder_End(f.txtEmulated_Clip_Path.Text, Media_Type.Still)
        dr.Job_Clip_Subfolder = f.txtJob_Clips.Text
        dr.Unpackage_Host_Name = f.txtUnPack_HostName.Text
        dr.Unpackage_Command_Port = f.txtUnpack_CommandPort.Text
        dr.Unpackage_Feedback_Port = f.txtUnpack_FeedbackPort.Text
        dr.Unpackage_Use_Feedback = f.chkUnpack_UseFeedback.Checked
        dr.Open_Job_After_Unpackage = f.chkOpen_After_Unpackage.Checked
        dr.Unpackage_Job_Load_Timeout = Integer.Parse(f.udPackage_Timeout.Value)
        dr.Un_Package_Package_Path = f.txtUnpackage_Package_Path.Text
        dr.Use_V7_Commands = f.chkUse_V7.Checked
        dr.Log_Clarity_Events = f.chkLog_Clarity_Events.Checked
        dr.Start_Unpackaging = f.chkStart_Unpackaging.Checked
        dr.Use_Temp_Folder_For_Unpackaged_Job = f.chkJob_Temp_Folder.Checked
        dr.V7_Empty_Job = f.txtEmptyJob.Text
        dr.Generate_Receipt = f.chkGenerate_Receipt.Checked
        dr.Receipt_Folder = f.txtReceipt_Path.Text
        dr.Use_Alpha_Enabled_Job = f.chkAlpha.Checked
        dr.Still_Field_Number = Integer.Parse(f.udStill_Field_Number.Value)
        dr.Empty_Clip = f.txtEmptyClip.Text
        dr.Empty_Still = f.txtEmptyStill.Text
        dr.Archive_HD = f.txtHD_Archived_Clips.Text
        dr.Archive_SD = f.txtSD_Archived_Clips.Text
        dr.Delete_Spreadsheet_Folder = f.txtSpreadsheet_Folder.Text
        dr.Show_Clarity_Transfer = f.chkShow_Clarity_Transfer.Checked
        dr.Package_From_Clipstore = f.chkPackage_From_Clipstore.Checked
        dr.Move_Package_Job = f.chkMove_Packaged_Job.Checked
        dr.Packaged_Job_Archived_Folder = f.txtPackaged_Jobs_Archive_Folder.Text
        dr.Local_Job_Path = f.txtLocal_Job_Folder.Text
        dr.Network_Job_Path = f.txtNetwork_Job_Folder.Text
        dr.Clipstore_Scan = f.chkClipstore_Scan.Checked
        dr.Clarity_Packaging_View = f.chkClarity_Packaging_View.Checked
        Try
            dr.Transfer_Buffer_Size = Integer.Parse(f.txtTransfer_Buffer_Size.Text)
        Catch
            dr.Transfer_Buffer_Size = 65535
        End Try

        dt.AddSettingsRow(dr)
        ds.WriteXml(sFilename)

    End Sub

    Friend Function drZero(ByVal sFilename As String) As TheSettings.SettingsRow

        ds.Clear()
        ds.ReadXml(sFilename)
        Return ds.Settings.Rows(0)

    End Function

    Friend Property Host_Name(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Host_Name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Command_Port(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Command_Port
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Feedback_Port(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Feedback_Port
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Use_Feedback(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).Use_Feedback
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Clarity_Job_Filename(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Clarity_Job_Filename
            Catch ex As Exception
                Return 1
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Page_Number(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Page_Number
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property Field_Number(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Field_Number
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property Channel_Number(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Channel_Number
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property Job_Load_Timeout(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Job_Load_Timeout
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property HD(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).HD
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property HD_Folder_Suffix(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).HD_Folder_Suffix
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Clip_Delay(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Clip_Page_Delay
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Still_Delay(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Still_Page_Delay
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Package_Start_Page(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Package_Start_Page
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property Package_Folder(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Package_Folder
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Package_Prefix(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Package_Prefix
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Package_Data_Format(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Package_Data_Format
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Package_Suffix(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Package_Suffix
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Overloads Function Package_Base() As String

        Return Package_Base(Package_Prefix(sSettings_File_Name), Package_Data_Format(sSettings_File_Name), Package_Suffix(sSettings_File_Name))

    End Function

    Friend Overloads Function Package_Base(ByVal sPrefix As String, ByVal sDate_Format As String, ByVal sSuffix As String) As String

        Dim sDate As String

        sDate = Date.Now.ToString(sDate_Format)
        Return String.Concat(sPrefix, sDate, sSuffix).Trim

    End Function

    Public Overloads Function Package_Job_Filename(ByVal sBasename As String)

        Dim fi As New System.IO.FileInfo(Clarity_Job_Filename(sSettings_File_Name))

        Return Package_Job_Filename(sBasename, Fix_Folder_End(fi.DirectoryName, Media_Type.Still))

    End Function

    Public Overloads Function Package_Job_Filename(ByVal sBasename As String, ByVal sFolder As String)

        Dim fi As New System.IO.FileInfo(Clarity_Job_Filename(sSettings_File_Name))

        Return String.Concat(sFolder, sBasename, fi.Extension)

    End Function
    Public Function Zip_File_Name(ByVal sBasename As String) As String

        Dim sHD As String

        If HD(sSettings_File_Name) Then
            sHD = "_HD"
        Else
            sHD = "_SD"
        End If

        Return String.Concat(Package_Folder(sSettings_File_Name), sBasename, sHD, ".zip")

    End Function

    Public Function Folder_To_Zip(ByVal sBasename) As String

        Return String.Concat(Package_Folder(sSettings_File_Name), sBaseName)

    End Function

    Friend Property Data_Connection_String(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Data_Connection_String
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property FTP_Server_Address(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).ftp_server_address
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property FTP_Username(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).ftp_user_name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property FTP_Password(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).ftp_password
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Clipstore_Name(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Clipstore_Name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property FTP_Port_Number(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).ftp_port_no
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property FTP_Timeout_ms(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).ftp_timeout
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Friend Property Delete_Temporary_Files(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).Delete_Temporary_Files
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Friend Property Un_Package_Root_Folder(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Unpackage_Root_Folder
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Overwrite_Mode(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Overwrite
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Delete_Temporary_Clarity_Clips(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).Delete_Temporary_Clarity_Clips
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Friend Property Emulated_Clips_Folder(ByVal sFilename As String) As String
        Get
            Return Un_Fix_Folder_End(drZero(sFilename).Emulated_Clips_Folder, Media_Type.Still)
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property HD_Archived_Clips_Folder(ByVal sFilename As String) As String
        Get
            Return Un_Fix_Folder_End(drZero(sFilename).Archive_HD, Media_Type.Still)
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property SD_Archived_Clips_Folder(ByVal sFilename As String) As String
        Get
            Return Un_Fix_Folder_End(drZero(sFilename).Archive_SD, Media_Type.Still)
        End Get
        Set(ByVal value As String)

        End Set
    End Property


    Friend Property Job_Clips_Subfolder(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Job_Clip_Subfolder
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Unpackage_Host_Name(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Unpackage_Host_Name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Unpackage_Command_Port(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Unpackage_Command_Port
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Unpackage_Feedback_Port(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Unpackage_Feedback_Port
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Unpackage_Use_Feedback(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).Unpackage_Use_Feedback
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Friend Property Unpackage_Job_Load_Timeout(ByVal sFilename As String) As Integer
        Get
            Return drZero(sFilename).Unpackage_Job_Load_Timeout
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Friend Property Open_Job_After_Unpackage(ByVal sFilename As String) As Boolean
        Get
            Return drZero(sFilename).Open_Job_After_Unpackage
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Unpackage_Package_Folder(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).Un_Package_Package_Path
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Use_V7_Commands(ByVal sFilename As String) As Boolean
        Get
            If drZero(sFilename).IsUse_V7_CommandsNull Then
                Return False
            Else
                Return drZero(sFilename).Use_V7_Commands
            End If
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Log_Clarity_Events(ByVal sFilename As String) As Boolean
        Get
            If drZero(sFilename).IsLog_Clarity_EventsNull Then
                Return False
            Else
                Return drZero(sFilename).Log_Clarity_Events
            End If

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Friend Property Start_Unpackaging(ByVal sFilename As String) As Boolean
        Get
            If drZero(sFilename).IsStart_UnpackagingNull Then
                Return False
            Else
                Return drZero(sFilename).Start_Unpackaging
            End If

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Put_Unpackaged_Job_In_Temp_Folder(ByVal sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Use_Temp_Folder_For_Unpackaged_Job
            Catch ex As Exception
                Return True
            End Try
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Empty_V7_Job(ByVal sFilename As String) As String
        Get
            Return drZero(sFilename).V7_Empty_Job
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Generate_Receipt(ByVal sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Generate_Receipt
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Receipt_Folder(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Receipt_Folder
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Alpha_Enabled_Job(ByVal sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Use_Alpha_Enabled_Job
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Show_Clarity_Transfer(sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Show_Clarity_Transfer
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)

        End Set
    End Property
    Friend Property Package_From_Clipstore(sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Package_From_Clipstore
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)

        End Set
    End Property
    Friend Property Still_Field_Number(ByVal sFilename As String) As Integer
        Get
            Try
                Return drZero(sFilename).Still_Field_Number
            Catch ex As Exception
                Return 2
            End Try

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Friend Property Empty_Clip(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Empty_Clip
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Empty_Still(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Empty_Still
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Archive_HD(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Archive_HD
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Archive_SD(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Archive_SD
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Spreadsheet_Folder(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Delete_Spreadsheet_Folder
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Archived_Pacakged_Jobs_Folder(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Packaged_Job_Archived_Folder
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Property Move_Packaged_Job(sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Move_Package_Job
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)

        End Set
    End Property
    Friend Property Local_Job_Folder(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Local_Job_Path
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Friend Property Network_Job_Folder(ByVal sFilename As String) As String
        Get
            Try
                Return drZero(sFilename).Network_Job_Path
            Catch ex As Exception
                Return ""
            End Try

        End Get
        Set(ByVal value As String)

        End Set

    End Property
    Friend Property Clipstore_Scan(sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Clipstore_Scan
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Friend Property Clarity_Packaging_View(sFilename As String) As Boolean
        Get
            Try
                Return drZero(sFilename).Clarity_Packaging_View
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Friend Property Transfer_Buffer_Size(sFilename As String) As Int32
        Get
            Try
                Return drZero(sFilename).Transfer_Buffer_Size
            Catch ex As Exception
                Return 65535
            End Try
        End Get
        Set(value As Int32)

        End Set

    End Property

End Class
