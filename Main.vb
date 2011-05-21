Imports System.IO
Imports Ionic.Zip
Public Class Main

    Private objSettings As Settings_MuVi2
    Dim objClarity As Clarity

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

        Dim f As New frmSettings

        f.Show()
        f = Nothing

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sConnection As String
        Dim dbConnection As OleDb.OleDbConnection


        objSettings = New Settings_MuVi2

        sConnection = objSettings.Data_Connection_String(sSettings_File_Name)
        dbConnection = New OleDb.OleDbConnection(sConnection)

        Me.Gemini_Media_LocationsTableAdapter.Connection = dbConnection
        Me.Gemini_Media_LocationsTableAdapter.Fill(Me.Mm_phase_5DataSet.Gemini_Media_Locations)
        Me.Gemini_MediaTableAdapter.Connection = dbConnection
        Me.Gemini_MediaTableAdapter.Fill(Me.Mm_phase_5DataSet.Gemini_Media)


        mm = New mMessage(Me.lstMessage, True)
        mm.Clear()
        objClarity = New Clarity(mm)

        Me.dtDelivery.Value = Last_Monday()


    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Show_Clip()
       
    End Sub



    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click

        Stop_and_Disconnect()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Not (objClarity Is Nothing) Then
            If objClarity.Is_Status_Idle Then
                Stop_and_Disconnect
            End If
        End If

    End Sub

    Private Sub Stop_and_Disconnect()

        Timer1.Enabled = False
        objClarity.Stop_Playout()
        If objSettings.Use_V7_Commands(sSettings_File_Name) Then
            objClarity.Set_Delay(objSettings.Page_Number(sSettings_File_Name) + 1, False, "00:01")
            objClarity.Cue_Page(objSettings.Page_Number(sSettings_File_Name) + 1)
            objClarity.Take()
            Timer1.Enabled = True
        End If
        objClarity.Take_Offline()
        objClarity.Disconnect()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        mm.Clear()

    End Sub

    Private Sub Gemini_MediaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.Gemini_MediaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mm_phase_5DataSet)

    End Sub

    Private Sub dtDelivery_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDelivery.ValueChanged

        Dim sCriteria As String = String.Concat("Delivery_Date >= '", dtDelivery.Value.Date.ToString("dd/MM/yy"), "'")
        Dim dv As New DataView(Mm_phase_5DataSet.Tables("Gemini_Media"), sCriteria, "Delivery_Date", DataViewRowState.CurrentRows)

        Gemini_MediaDataGridView.DataSource = dv

    End Sub

    
    Private Sub Gemini_MediaDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gemini_MediaDataGridView.SelectionChanged

        Dim iLocation_ID As Integer
        Dim mmdb As New mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sFilename As String
        Dim sClip As String

        If Gemini_MediaDataGridView.SelectedRows.Count > 0 Then
            iLocation_ID = Gemini_MediaDataGridView.SelectedRows(0).Cells("Location_ID").Value
            sClip = Gemini_MediaDataGridView.SelectedRows(0).Cells("Filename").Value
            Folder_Stuff = mmdb.Find(iLocation_ID, Me.Gemini_Media_LocationsTableAdapter)
            sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, Remove_PPV(sClip))
            Me.txtClip_Filename.Text = sFilename
        End If

    End Sub


    Private Sub cndPackage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cndPackage.Click

        Dim dr As DataGridViewRow
        Dim iDestination_Page As Integer
        Dim iLocation_ID As Integer
        Dim mmdb As New mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sFilename As String
        Dim sFilenames() As String
        Dim iNum As Integer
        Dim sClip As String
        Dim sBasename As String

        mm.Add(String.Format("ClarityGen Package. Version: {0}", sVersionString))
        mm.Add("=====================================")

        iDestination_Page = objSettings.Package_Start_Page(sSettings_File_Name)
        objClarity.Connect()
        objClarity.Connect_Feedback()
        iNum = 0
        ReDim Preserve sFilenames(0)
        If Not objClarity.Is_Job_Loaded() Then
            If objClarity.Load_Job() Then
                If objClarity.Job_Load_Wait(Me.ProgressBar1) Then
                    For Each dr In Gemini_MediaDataGridView.Rows
                        If dr.Cells("Package").Value = True Then
                            iLocation_ID = dr.Cells("Location_ID").Value
                            sClip = dr.Cells("Filename").Value
                            Folder_Stuff = mmdb.Find(iLocation_ID, Me.Gemini_Media_LocationsTableAdapter)
                            sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)
                            If objClarity.Create_Page(iDestination_Page) Then
                                objClarity.Update_Page(iDestination_Page, Remove_PPV(sFilename))
                                iDestination_Page += 1
                                ReDim Preserve sFilenames(iNum)
                                sFilenames(iNum) = sFilename
                                iNum += 1
                            End If
                        End If
                    Next
                End If
            End If
        Else
            For Each dr In Gemini_MediaDataGridView.Rows
                If dr.Cells("Package").Value = True Then
                    iLocation_ID = dr.Cells("Location_ID").Value
                    sClip = dr.Cells("Filename").Value
                    Folder_Stuff = mmdb.Find(iLocation_ID, Me.Gemini_Media_LocationsTableAdapter)
                    sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)
                    If objClarity.Create_Page(iDestination_Page) Then
                        objClarity.Update_Page(iDestination_Page, Remove_PPV(sFilename))
                        iDestination_Page += 1
                        ReDim Preserve sFilenames(iNum)
                        sFilenames(iNum) = sFilename
                        iNum += 1
                    End If
                End If
            Next
        End If

        sBasename = objSettings.Package_Base
        objClarity.Save_Job(objSettings.Package_Job_Filename(sBasename))
        objClarity.Disconnect()

        Copy_Files(sBasename, sFilenames)

    End Sub

    Private Sub Copy_Files(ByVal sBaseName As String, ByVal sFilenames() As String)

        Dim sSourceJob As String
        Dim fi As FileInfo
        Dim sFolder As String
        Dim sClip_Folder As String
        Dim sDestination As String
        Dim i As Integer
        Dim sSource As String
        Dim sDest As String


        sSourceJob = objSettings.Package_Job_Filename(sBaseName)
        fi = New FileInfo(sSourceJob)
        sFolder = String.Concat(objSettings.Package_Folder(sSettings_File_Name), sBaseName, Remove_Drive_From_Folder(fi.DirectoryName))
        sDestination = objSettings.Package_Job_Filename(sBaseName, Fix_Folder_End(sFolder, Media_Type.Still))

        Create_Folder_If_Not_Present(sFolder)

        fi.CopyTo(sDestination, True)
        mm.Add(String.Concat("Copying job: ", sSourceJob))

        sClip_Folder = String.Concat(Fix_Folder_End(sFolder, Media_Type.Still), objSettings.Job_Clips_Subfolder(sSettings_File_Name))

        Create_Folder_If_Not_Present(sClip_Folder)

        

        For i = 0 To sFilenames.GetUpperBound(0)
            If File_Type(sFilenames(i)) = Media_Type.Clip Then
                sSource = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sFilenames(i)))
                sDest = String.Concat(sClip_Folder, Clip_Base_Filename(sFilenames(i)))
            Else
                sSource = String.Concat(Remove_PIC(sFilenames(i)))
                sDest = String.Concat(Still_Dest_Filename(sFilenames(i), sBaseName))
            End If

            fi = New FileInfo(sDest)
            Create_Folder_If_Not_Present(fi.DirectoryName)

            fi = New FileInfo(sSource)
            If fi.Exists Then
                fi.CopyTo(sDest, True)
                mm.Add(String.Concat("Copying clip: ", sSource))
            Else
                mm.Add(String.Concat("Unable to find: ", sSource))
            End If
        Next

        Create_Zip(sBaseName)
        If objSettings.Delete_Temporary_Files(sSettings_File_Name) Then
            Delete_Folder(objSettings.Folder_To_Zip(sBaseName))
            mm.Add("Source files deleted")
        End If

        mm.Add("Package Complete")
        MessageBox.Show("Package Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Friend Sub Create_Folder_If_Not_Present(ByVal sFolder As String)

        Dim di = New DirectoryInfo(sFolder)
        If Not di.Exists Then
            di.Create()
        End If

    End Sub

    Friend Sub Delete_Folder(ByVal sFolder As String)

        Dim di = New DirectoryInfo(sFolder)
        If di.Exists Then
            di.Delete(True)
        End If

    End Sub
    Friend Overloads Sub Create_Zip(ByVal sBasename As String)

        Create_Zip(objSettings.Zip_File_Name(sBasename), objSettings.Folder_To_Zip(sBasename))

    End Sub
    Friend Overloads Sub Create_Zip(ByVal sZip_Filename As String, ByVal sFolder_to_Zip As String)

        Using objZip As New ZipFile
            mm.Add("Adding files to zip")
            objZip.AddDirectory(sFolder_to_Zip, "")
            AddHandler objZip.SaveProgress, New EventHandler(Of SaveProgressEventArgs)(AddressOf Me.objZip_SaveProgress)
            mm.Add("Saving zip")
            objZip.Save(sZip_Filename)
        End Using

    End Sub

    Private Sub objZip_SaveProgress(ByVal sender As Object, ByVal e As SaveProgressEventArgs)
        Select Case e.EventType
            Case ZipProgressEventType.Saving_Completed
                mm.Add("Saved complete zip")
                Me.ProgressBar1.Maximum = 1
                Me.ProgressBar1.Value = 0
            Case ZipProgressEventType.Saving_BeforeWriteEntry
                mm.Add(String.Concat("Zipping: ", e.CurrentEntry.FileName))
                Me.ProgressBar1.Maximum = 1
                Me.ProgressBar1.Value = 0
            Case ZipProgressEventType.Saving_EntryBytesRead
                If Me.ProgressBar1.Maximum = 1 Then
                    Me.ProgressBar1.Maximum = e.TotalBytesToTransfer
                End If
                Me.ProgressBar1.Value = e.BytesTransferred
            Case Else

        End Select

    End Sub

    Private Sub Show_Clip()

        Dim Response As DialogResult

        If Not objClarity.Is_Status_Idle Then
            Response = MessageBox.Show("Do you want me to stop the current clip?", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Response = DialogResult.Yes Then
                Stop_and_Disconnect()
            End If
        End If

        objClarity.Connect()
        objClarity.Connect_Feedback()

        If Not objClarity.Is_Job_Loaded() Then
            If objClarity.Load_Job() Then
                If objClarity.Job_Load_Wait(Me.ProgressBar1) Then
                    Update_And_Play_Clip()
                End If
            End If
        Else
            Update_And_Play_Clip()
        End If

    End Sub

    Private Sub Update_And_Play_Clip()

        If objClarity.Update_Page(Me.txtClip_Filename.Text) Then
            If objSettings.Use_V7_Commands(sSettings_File_Name) Then
                Update_Waits_and_Page_2()
            ElseIf objClarity.Update_Field_Wait(Me.ProgressBar1) Then
                Update_Waits_and_Page_2()
            End If
        End If

    End Sub
    Private Sub Update_Waits_and_Page_2()

        System.Threading.Thread.Sleep(2000)
        objClarity.Set_Delay(objSettings.Page_Number(sSettings_File_Name) + 1, False, Page_Delay(Me.txtClip_Filename.Text))
        objClarity.Cue_Page()
        objClarity.Take()
        Timer1.Enabled = True

    End Sub

    Private Sub CustomizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomizeToolStripMenuItem.Click
        Dim f As New Unpackage

        f.Show()
        f = Nothing

    End Sub


    Private Sub cmdUnpackage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnpackage.Click

        Dim f As New Unpackage

        f.Show()
        f = Nothing

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click

        MessageBox.Show(String.Concat("MuVi2 ClarityGen Approval and Packaging", Environment.NewLine, _
                            "Version: ", sVersionString), "MuVi2", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class