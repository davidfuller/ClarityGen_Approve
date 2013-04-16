Imports System.IO
Public Class Archive_Restore

    Private objSettings As Settings_MuVi2
    'Private mmdb As mmdb_Data
    Private bTotally_Successful As Boolean

    Public Sub New()

        objSettings = New Settings_MuVi2

    End Sub

    Friend Function Archive_Restore_Filenames(dgv As DataGridView, dtLocations As mm_phase_5DataSet.Gemini_Media_LocationsDataTable, bHD As Boolean) As File_Details()

        Dim dr As DataGridViewRow

        Dim sFilenames() As File_Details
        Dim iNum As Integer

        iNum = 0

        ReDim Preserve sFilenames(0)

        For Each dr In dgv.Rows
            If (bHD And dr.Cells("Archive").Value = True) Or ((Not bHD) And dr.Cells("Archive_SD").Value = True) Then
                ReDim Preserve sFilenames(iNum)
                sFilenames(iNum) = New File_Details
                sFilenames(iNum).Filename = Get_Filename(dr, dtLocations, bHD)
                sFilenames(iNum).ID = dr.Cells("ID").Value
                sFilenames(iNum).Success = False
                iNum += 1
            End If
        Next

        Return sFilenames

    End Function
    Friend Function Clarity_Transfer_Filenames(dgv As DataGridView, dtLocations As mm_phase_5DataSet.Gemini_Media_LocationsDataTable, bHD As Boolean) As File_Details()

        Dim dr As DataGridViewRow

        Dim sFilenames() As File_Details
        Dim iNum As Integer

        iNum = 0

        ReDim Preserve sFilenames(0)

        For Each dr In dgv.Rows
            If (dr.Cells("Clarity").Value = True) Then
                ReDim Preserve sFilenames(iNum)
                sFilenames(iNum) = New File_Details
                sFilenames(iNum).Filename = Get_Filename(dr, dtLocations, bHD)
                sFilenames(iNum).ID = dr.Cells("ID").Value
                sFilenames(iNum).Success = False
                iNum += 1
            End If
        Next

        Return sFilenames

    End Function
    Friend Function Archive_Restore_Files(ByRef sFilenames() As File_Details, ByVal bArchive As Boolean, ByVal bHD As Boolean) As Boolean


        Dim fi As FileInfo
        Dim sArchive_Folder As String
        Dim i As Integer
        Dim sSource As String
        Dim sDest As String

        If bHD Then
            sArchive_Folder = objSettings.HD_Archived_Clips_Folder(sSettings_File_Name)
        Else
            sArchive_Folder = objSettings.SD_Archived_Clips_Folder(sSettings_File_Name)
        End If

        If sArchive_Folder <> "" Then
            bTotally_Successful = True
            For i = 0 To sFilenames.GetUpperBound(0)
                If Not sFilenames(i) Is Nothing Then
                    If File_Type(sFilenames(i).Filename) = Media_Type.Clip Then
                        If bArchive Then
                            sSource = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sFilenames(i).Filename))
                            sDest = String.Concat(sArchive_Folder, Clip_Base_Filename(sFilenames(i).Filename))
                        Else
                            sDest = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sFilenames(i).Filename))
                            sSource = String.Concat(sArchive_Folder, Clip_Base_Filename(sFilenames(i).Filename))
                        End If

                        fi = New FileInfo(sDest)
                        If Create_Folder_If_Not_Present(fi.DirectoryName) Then
                            fi = New FileInfo(sSource)
                            If fi.Exists Then
                                Try
                                    fi.CopyTo(sDest, True)
                                    mm.Add(String.Concat("Copying clip: ", sSource))
                                    fi.Delete()
                                    mm.Add(String.Concat("Source clip deleted: ", sSource))
                                    sFilenames(i).Success = True
                                Catch ex As Exception
                                    mm.Add(ex.Message)
                                    sFilenames(i).Success = False
                                    bTotally_Successful = False
                                End Try
                            Else
                                mm.Add(String.Concat("Unable to find: ", sSource))
                                sFilenames(i).Success = False
                                bTotally_Successful = False
                            End If
                        Else
                            mm.Add(String.Concat("Failed to create folder for: ", sDest))
                            sFilenames(i).Success = False
                            bTotally_Successful = False
                        End If
                    Else
                        mm.Add(String.Concat("Unable to archive stills: ", sFilenames(i)))
                        sFilenames(i).Success = False
                        bTotally_Successful = False
                    End If
                Else
                    bTotally_Successful = False
                End If
            Next
            Return True
        Else
            Return False
        End If


    End Function
    Private Function Get_Filename(dr As DataGridViewRow, dtLocations As mm_phase_5DataSet.Gemini_Media_LocationsDataTable, bHD As Boolean) As String

        Dim iLocation_ID As Integer
        Dim sClip As String
        Dim Folder_Stuff = New Folder_Details
        Dim mmdb As mmdb_Data

        mmdb = New mmdb_Data(dtLocations)
        iLocation_ID = dr.Cells("Location_ID").Value
        sClip = dr.Cells("Filename").Value
        Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
        Return String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)

    End Function

    Friend Property Totally_Successful As Boolean
        Get
            Return bTotally_Successful
        End Get
        Set(value As Boolean)
            bTotally_Successful = value
        End Set
    End Property

    Friend Function Transfer_Files_To_Clarity(ByRef sFilenames() As File_Details, ProgressBar1 As ProgressBar) As Boolean

        Dim sFTP_Folder As String
        Dim i As Integer
        Dim sSource As String
        Dim sDestination As String
        Dim objFTP As MuVi2_FTP
        Dim bConnected As Boolean

        objFTP = New MuVi2_FTP(mm, ProgressBar1)
        bConnected = objFTP.Connect()

        bTotally_Successful = True

        If bConnected Then
            For i = 0 To sFilenames.GetUpperBound(0)
                If Not sFilenames(i) Is Nothing Then
                    If File_Type(sFilenames(i).Filename) = Media_Type.Clip Then
                        sSource = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sFilenames(i).Filename))
                        sDestination = Path.GetFileName(sSource)
                        sFTP_Folder = Clipstore_Folder_From_PC_Filename(sSource)
                        Try
                            sFilenames(i).Success = objFTP.Transfer_File(sSource, sFTP_Folder, sDestination)
                            If Not sFilenames(i).Success Then bTotally_Successful = False
                        Catch ex As Exception
                            bTotally_Successful = False
                            mm.Add(ex.Message)
                        End Try
                    Else
                        sFilenames(i).Success = Copy_Still_File_To_Clarity(sFilenames(i))
                        If Not sFilenames(i).Success Then bTotally_Successful = False
                    End If
                Else
                    bTotally_Successful = False
                End If
            Next

            objFTP.Disconnect()
            ProgressBar1.Value = ProgressBar1.Minimum

            Return True
        Else
            Return False
        End If


    End Function

    Private Function Copy_Still_File_To_Clarity(sFilename As File_Details) As Boolean
        Dim Response As DialogResult
        Dim bSuccess As Boolean
        Dim sSource As String
        Dim sDestination As String
        Dim fiSource As FileInfo
        Dim fiDest As FileInfo


        sSource = Remove_PIC(sFilename.Filename)
        sDestination = sSource.Replace(objSettings.Local_Job_Folder(sSettings_File_Name), objSettings.Network_Job_Folder(sSettings_File_Name))
        fiDest = New FileInfo(sDestination)
        bSuccess = True

        If Create_Folder_If_Not_Present(fiDest.DirectoryName) Then
            fiSource = New FileInfo(sSource)
            If fiSource.Exists Then
                If fiDest.Exists Then
                    Select Case UCase(objSettings.Overwrite_Mode(sSettings_File_Name))
                        Case "OVERWRITE"
                            bSuccess = Do_The_Copy(fiSource, fiDest)
                        Case "SKIP"
                            mm.Add(String.Format("{0} exists on the Clarity. It has not been re-transferred", fiDest.Name))
                            bSuccess = False
                        Case "ASK"
                            Response = MessageBox.Show(String.Format("{0} exists on the Clarity. Do you wish to overwrite?", fiDest.Name), "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If Response = DialogResult.Yes Then
                                bSuccess = Do_The_Copy(fiSource, fiDest)
                            Else
                                mm.Add(String.Format("{0} exists on the Clarity. It has not been re-transferred", fiDest.Name))
                                bSuccess = False
                            End If
                        Case Else
                            mm.Add(String.Format("{0} exists on the Clarity. It has not been re-transferred", fiDest.Name))
                            bSuccess = False
                    End Select
                Else
                    bSuccess = Do_The_Copy(fiSource, fiDest)
                End If
            Else
                mm.Add(String.Format("Source file could not be found: {0}", sSource))
                bSuccess = False
            End If
        Else
            mm.Add(String.Concat("Could not create Clarity folder: ", fiDest.DirectoryName))
            bSuccess = False
        End If

        Return bSuccess

    End Function

    Private Function Do_The_Copy(fiSource As FileInfo, fiDest As FileInfo) As Boolean

        mm.Add(String.Format("Copying file {0} to {1}", fiSource.Name, fiDest.DirectoryName))
        Try
            fiSource.CopyTo(fiDest.FullName, True)
            Return True
        Catch ex As Exception
            mm.Add(String.Format("Failed to copy {0}. Error: {1)", fiSource.Name, ex.Message))
            Return False
        End Try

    End Function


    Friend Function Transfer_Files_From_Clarity(sFilenames() As File_Details, sLocalFolder As String, ProgressBar1 As ProgressBar) As Boolean

        bTotally_Successful = True

        For i = 0 To sFilenames.GetUpperBound(0)
            If Not Transfer_File_From_Clarity(sFilenames(i), sLocalFolder, ProgressBar1) Then
                bTotally_Successful = False
            End If
        Next

        Return True

    End Function

    Friend Function Transfer_File_From_Clarity(sFilename As File_Details, sLocal_Folder As String, ProgressBar1 As ProgressBar) As Boolean
        Dim objFTP As MuVi2_FTP
        Dim bConnected As Boolean
        Dim sSource As String
        Dim sDestination As String
        Dim sFTP_Folder As String
        Dim fi As FileInfo
        Dim bSuccess As Boolean

        objFTP = New MuVi2_FTP(mm, ProgressBar1)
        bConnected = objFTP.Connect()

        bSuccess = True

        If bConnected Then
            If Not sFilename Is Nothing Then
                If File_Type(sFilename.Filename) = Media_Type.Clip Then
                    sDestination = String.Concat(sLocal_Folder, Clip_Base_Filename(sFilename.Filename))
                    sSource = Path.GetFileName(sDestination)
                    sFTP_Folder = Clipstore_Folder_From_PC_Filename(sDestination)
                    fi = New FileInfo(sDestination)
                    If Create_Folder_If_Not_Present(fi.DirectoryName) Then
                        Try
                            sFilename.Success = objFTP.Download_File(sSource, sFTP_Folder, sDestination)
                        Catch ex As Exception
                            bSuccess = False
                            mm.Add(ex.Message)
                        End Try
                    Else
                        mm.Add(String.Concat("Failed to create folder for: ", sDestination))
                        bSuccess = False
                    End If
                Else
                    mm.Add(String.Concat("Unable to package stills: ", sFilename.Filename))
                    bSuccess = False
                End If
                Else
                    bSuccess = False
                End If

            objFTP.Disconnect()
            ProgressBar1.Value = ProgressBar1.Minimum

            Return bSuccess
        Else
            Return False
        End If

    End Function




    Friend Function Copy_Emulated_Clips_To_Package(sFilenames() As File_Details, sPackage_Folder As String, sBasename As String, objReceipt As Receipt) As Boolean

        Dim sClip_Folder As String
        
        sClip_Folder = String.Concat(Fix_Folder_End(sPackage_Folder, Media_Type.Still), objSettings.Job_Clips_Subfolder(sSettings_File_Name))

        If Create_Folder_If_Not_Present(sClip_Folder) Then
            For i = 0 To sFilenames.GetUpperBound(0)
                Copy_Windows_Files(sFilenames(i), sClip_Folder, sBasename, objReceipt)
            Next
            Return True
        Else
            mm.Add(String.Concat("Failed to create folder: ", sClip_Folder))
            MessageBox.Show(String.Concat("Failed to create folder: ", sClip_Folder), "Folder Issue", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

    End Function

    Friend Function Copy_Clipstore_Clips_To_Package(sFilenames() As File_Details, sPackage_Folder As String, sBasename As String, objReceipt As Receipt, ProgressBar1 As ProgressBar) As Boolean

        Dim sClip_Folder As String

        sClip_Folder = String.Concat(Fix_Folder_End(sPackage_Folder, Media_Type.Still), objSettings.Job_Clips_Subfolder(sSettings_File_Name))

        If Create_Folder_If_Not_Present(sClip_Folder) Then
            For i = 0 To sFilenames.GetUpperBound(0)
                If File_Type(sFilenames(i).Filename) = Media_Type.Clip Then
                    If Transfer_File_From_Clarity(sFilenames(i), sPackage_Folder, ProgressBar1) Then
                        mm.Add(String.Concat("Copied clip: ", sFilenames(i).Filename))
                        objReceipt.Add(String.Format("Media filename: {0} First Use: {1}", sFilenames(i).Filename, sFilenames(i).First_Use.ToShortDateString))
                        sFilenames(i).Success = True
                    End If
                Else
                    Copy_Windows_Files(sFilenames(i), sClip_Folder, sBasename, objReceipt)
                End If
            Next
            Return True
        Else
            mm.Add(String.Concat("Failed to create folder: ", sClip_Folder))
            MessageBox.Show(String.Concat("Failed to create folder: ", sClip_Folder), "Folder Issue", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If


    End Function

    Private Sub Copy_Windows_Files(sFilename As File_Details, sClip_Folder As String, sBaseName As String, objReceipt As Receipt)

        Dim sSource As String
        Dim sDest As String
        Dim fi As FileInfo

        If Not sFilename Is Nothing Then
            If File_Type(sFilename.Filename) = Media_Type.Clip Then
                sSource = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sFilename.Filename))
                sDest = String.Concat(sClip_Folder, Clip_Base_Filename(sFilename.Filename))
            Else
                sSource = String.Concat(Remove_PIC(sFilename.Filename))
                sDest = String.Concat(Still_Dest_Filename(sFilename.Filename, sBaseName))
            End If

            fi = New FileInfo(sDest)
            If Create_Folder_If_Not_Present(fi.DirectoryName) Then
                fi = New FileInfo(sSource)
                If fi.Exists Then
                    Try
                        fi.CopyTo(sDest, True)
                        mm.Add(String.Concat("Copying clip: ", sSource))
                        objReceipt.Add(String.Format("Media filename: {0} First Use: {1}", sFilename.Filename, sFilename.First_Use.ToShortDateString))
                        sFilename.Success = True
                    Catch ex As Exception
                        mm.Add(String.Concat("Could not copy clip: ", sSource, " Error: ", ex.ToString))
                        sFilename.Success = False
                    End Try
                Else
                    mm.Add(String.Concat("Unable to find: ", sSource))
                    sFilename.Success = False
                End If
            Else
                mm.Add(String.Concat("Failed to create folder for: ", sDest))
                sFilename.Success = False
            End If
        End If

    End Sub

    Friend Sub Archive_Packaged_Job(sJob_File_Name As String)

        Dim fi As FileInfo
        Dim sDestination_Folder As String

        sDestination_Folder = Fix_Folder_End(objSettings.Archived_Pacakged_Jobs_Folder(sSettings_File_Name), Media_Type.Still)
        If Create_Folder_If_Not_Present(sDestination_Folder) Then
            fi = New FileInfo(sJob_File_Name)
            Try
                fi.MoveTo(String.Concat(sDestination_Folder, fi.Name))
                mm.Add(String.Format("Packaged job: {0} moved to folder: {1}", fi.Name, sDestination_Folder))
            Catch ex As Exception
                mm.Add(String.Format("Could not copy packaged job: {0}. Error: {1}", fi.Name, ex.Message))
            End Try
        Else
            mm.Add(String.Format("Could not create folder: {0}", sDestination_Folder))
        End If


    End Sub

    
End Class


Public Class File_Details

    Public Filename As String
    Public ID As Integer
    Public Success As Boolean
    Public First_Use As Date

End Class


