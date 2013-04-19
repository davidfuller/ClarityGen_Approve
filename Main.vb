Option Explicit On
Imports System.IO
Imports Ionic.Zip
Public Class Main

    Private objSettings As Settings_MuVi2
    Dim objClarity As Clarity
    Private dt As New mm_phase_5DataSet.Gemini_Media_LocationsDataTable
    Private objHistory As History
    Private fHistory As frmHistory


    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

        Dim f As New frmSettings

        f.Show()
        f = Nothing

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        If bPackaging_Only Then
            Me.Visible = False
        End If

    End Sub

   

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Dim sConnection As String
        Dim dbConnection As OleDb.OleDbConnection
        Dim f As Unpackage
        Dim Picture_Format As Format_Details


        objSettings = New Settings_MuVi2
        objHistory = New History(Clip_HistoryTableAdapter)

        bPackaging_Only = objSettings.Start_Unpackaging(sSettings_File_Name)
        If bPackaging_Only Then
            f = New Unpackage
            f.Show()
            Me.Visible = False
            Exit Sub
        End If


        sConnection = objSettings.Data_Connection_String(sSettings_File_Name)
        dbConnection = New OleDb.OleDbConnection(sConnection)
        mm = New mMessage(Me.lstMessage, True)
        mm.Clear()
        Try
            Me.Gemini_Media_LocationsTableAdapter.Connection = dbConnection
            Me.Gemini_Media_LocationsTableAdapter.Fill(Me.Mm_phase_5DataSet.Gemini_Media_Locations)
            Me.Gemini_MediaTableAdapter.Connection = dbConnection
            Me.Gemini_MediaTableAdapter.Fill(Me.Mm_phase_5DataSet.Gemini_Media)
            Me.Gemini_Media_LocationsTableAdapter.Fill(dt)
            Me.Clip_HistoryTableAdapter.Connection = dbConnection
            Me.Clip_HistoryTableAdapter.Fill(Me.Mm_phase_5DataSet.Clip_History)
        Catch ex As Exception
            mm.Add("Problem connecting to media database")
            MessageBox.Show("Problem connecting to media database", "Issue")
        End Try

        
        objClarity = New Clarity(mm)

        chkAll.Checked = False
        Me.dtDelivery.Value = Last_Monday()
        Me.cmbView.SelectedIndex = 0
        Me.cmbFilter.SelectedIndex = 0

        Picture_Format = New Format_Details
        Picture_Format.HD = objSettings.HD(sSettings_File_Name)
        Picture_Format.SD = Not Picture_Format.HD

        Set_Columns(Picture_Format, Me.cmbView.SelectedIndex = 0)

    End Sub

    Private Sub Set_Columns(Picture_Format As Format_Details, bPackaging As Boolean)



        Gemini_MediaDataGridView.Columns("First_Use").Visible = bPackaging
        Gemini_MediaDataGridView.Columns("Delivery_Date").Visible = bPackaging
        Gemini_MediaDataGridView.Columns("Package").Visible = bPackaging

        Gemini_MediaDataGridView.Columns("Packaged").Visible = Picture_Format.HD And bPackaging
        Gemini_MediaDataGridView.Columns("Package_Date").Visible = Picture_Format.HD And bPackaging
        Gemini_MediaDataGridView.Columns("Package_Filename").Visible = Picture_Format.HD And bPackaging

        Gemini_MediaDataGridView.Columns("Packaged_SD").Visible = Picture_Format.SD And bPackaging
        Gemini_MediaDataGridView.Columns("Package_Date_SD").Visible = Picture_Format.SD And bPackaging
        Gemini_MediaDataGridView.Columns("Package_Filename_SD").Visible = Picture_Format.SD And bPackaging

        Gemini_MediaDataGridView.Columns("Missing").Visible = Picture_Format.HD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archive").Visible = Picture_Format.HD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archived").Visible = Picture_Format.HD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archived_Date").Visible = Picture_Format.HD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Restore_Date").Visible = Picture_Format.HD And Not bPackaging

        Gemini_MediaDataGridView.Columns("Missing_SD").Visible = Picture_Format.SD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archive_SD").Visible = Picture_Format.SD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archived_SD").Visible = Picture_Format.SD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Archived_Date_SD").Visible = Picture_Format.SD And Not bPackaging
        Gemini_MediaDataGridView.Columns("Restore_Date_SD").Visible = Picture_Format.SD And Not bPackaging

        Gemini_MediaDataGridView.Columns("Ignore_HD").Visible = Picture_Format.HD
        Gemini_MediaDataGridView.Columns("Ignore_SD").Visible = Picture_Format.SD

        Gemini_MediaDataGridView.Columns("Clarity").Visible = bPackaging And objSettings.Show_Clarity_Transfer(sSettings_File_Name)
        Gemini_MediaDataGridView.Columns("On_Clarity_Clipstore").Visible = False

    End Sub

    Private Sub Set_Controls(bPackaging As Boolean, bHD As Boolean)

        Dim bClarity_View As Boolean
        Dim iWidth As Int32
        Dim iLeft As Int32

        bClarity_View = objSettings.Clarity_Packaging_View(sSettings_File_Name)

        cmdScan.Visible = True
        cmdSend_Clarity.Visible = bPackaging And Not bClarity_View
        cmdSend_Clarity.Enabled = objSettings.Show_Clarity_Transfer(sSettings_File_Name)

        cmdArchive.Visible = Not bPackaging
        cmdRestore.Visible = Not bPackaging
        cmdPackage.Visible = bPackaging
        cmbHD.Visible = Not bPackaging
        cmbFilter.Visible = cmbHD.SelectedIndex <= 1

        cmbView.Enabled = Not bClarity_View

        If bPackaging Then
            If bHD Then
                cmbHD.SelectedIndex = 0
            Else
                cmbHD.SelectedIndex = 1
            End If
        ElseIf cmbHD.SelectedIndex > 1 Then
            cmbFilter.SelectedIndex = 0
        End If

        If bClarity_View Then
            ProgressBar1.Width = txtClip_Filename.Width
            cmdScan.Left = cmdShow.Left
        Else
            iWidth = txtClip_Filename.Width - 81
            If iWidth > 0 Then
                ProgressBar1.Width = iWidth
            End If
            iLeft = cmdShow.Left - 81
            If iLeft > 0 Then
                cmdScan.Left = iLeft
            End If
        End If


    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Show_Clip()
       
    End Sub
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click

        If objSettings.Use_V7_Commands(sSettings_File_Name) Then
            objClarity.Stop_Playout()
            objClarity.Cue_Page(3)
            objClarity.Take()
        End If
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
        objClarity.Take_Offline()

        If objSettings.Use_V7_Commands(sSettings_File_Name) Then
            objClarity.Load_Job(objSettings.Empty_V7_Job(sSettings_File_Name))
            System.Threading.Thread.Sleep(2000)
            objClarity.Load_Job()
        Else
            System.Threading.Thread.Sleep(2000)
        End If
        objClarity.Disconnect()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        mm.Clear()

    End Sub

    Private Sub Save_Data()

        Me.Refresh()
        Application.DoEvents()
        Me.Validate()
        Me.Gemini_MediaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mm_phase_5DataSet)

    End Sub



    Private Sub ReQuery()

        Dim sCriteria As String
        Dim sSearch As String
        Dim dv As DataView
        Dim sFilter As String
        Dim dg As Data_Grid_MuVi2

        sFilter = Filter_Query_String()

        sSearch = txtSearch.Text
        If chkAll.Checked And sSearch = "" And sFilter = "" Then
            sCriteria = ""
        ElseIf chkAll.Checked And sSearch = "" Then
            sCriteria = sFilter
        ElseIf chkAll.Checked And sFilter = "" Then
            sCriteria = String.Concat("Title LIKE '%", Escape_Like_Value(sSearch), "%'")
        ElseIf chkAll.Checked Then
            sCriteria = String.Concat("Title LIKE '%", Escape_Like_Value(sSearch), "%' AND ", sFilter)
        ElseIf sSearch = "" And sFilter = "" Then
            sCriteria = String.Concat("Delivery_Date >= '", dtDelivery.Value.Date.ToString("dd/MM/yy"), "'")
        ElseIf sSearch = "" Then
            sCriteria = String.Concat("Delivery_Date >= '", dtDelivery.Value.Date.ToString("dd/MM/yy"), "' AND ", sFilter)
        ElseIf sFilter = "" Then
            sCriteria = String.Concat("Delivery_Date >= '", dtDelivery.Value.Date.ToString("dd/MM/yy"), "' AND Title LIKE '%", Escape_Like_Value(sSearch), "%'")
        Else
            sCriteria = String.Concat("Delivery_Date >= '", dtDelivery.Value.Date.ToString("dd/MM/yy"), "' AND Title LIKE '%", Escape_Like_Value(sSearch), "%' AND ", sFilter)
        End If

        Try
            Me.Gemini_MediaTableAdapter.Fill(Me.Mm_phase_5DataSet.Gemini_Media)

            dv = New DataView(Mm_phase_5DataSet.Tables("Gemini_Media"), sCriteria, "Delivery_Date", DataViewRowState.CurrentRows)

            Gemini_MediaDataGridView.DataSource = dv

            dg = New Data_Grid_MuVi2(Gemini_MediaDataGridView)
            dg.Set_Colour(Not (cmbHD.SelectedIndex = 1), objSettings.Clipstore_Scan(sSettings_File_Name))
        Catch ex As Exception
            mm.Add("Problem connecting to media database")
        End Try
        


    End Sub

    Private Function Filter_Query_String() As String

        Dim sFormatted_Now As String

        sFormatted_Now = String.Concat("'", Now.ToString("dd/MM/yy"), "'")
        Select Case cmbFilter.SelectedIndex
            Case 0
                Return ""
            Case 1 'Missing but Current
                If cmbHD.SelectedIndex = 0 Then
                    Return String.Concat("Missing = 'True' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                Else
                    Return String.Concat("Missing_SD = 'True' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                End If
            Case 2 ' Archived but current
                If cmbHD.SelectedIndex = 0 Then
                    Return String.Concat("Archived = 'True' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                Else
                    Return String.Concat("Archived_SD = 'True' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                End If
            Case 3 ' Current but past last use
                If cmbHD.SelectedIndex = 0 Then
                    Return String.Concat("Missing = 'False' AND Archived = 'False' AND Last_Use < ", sFormatted_Now)
                Else
                    Return String.Concat("Missing_SD = 'False' AND Archived_SD = 'False' AND Last_Use < ", sFormatted_Now)
                End If
            Case 4 ' In use date but not pacakged
                If cmbHD.SelectedIndex = 0 Then
                    Return String.Concat("Packaged = 'False' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                Else
                    Return String.Concat("Packaged_SD = 'False' AND First_Use <= ", sFormatted_Now, " AND Last_Use >= ", sFormatted_Now)
                End If
            Case Else
                Return ""
        End Select


    End Function
    Private Sub dtDelivery_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDelivery.ValueChanged

        ReQuery()

    End Sub

    Private Sub Gemini_MediaDataGridView_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Gemini_MediaDataGridView.CellClick

        Dim c As DataGridViewCell
        Dim iScroll As Int32
        Dim iID As Int32
        Dim sMessage As String

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            c = Gemini_MediaDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Select Case c.OwningColumn.Name
                Case "Ignore_HD", "Ignore_SD"
                    iID = Gemini_MediaDataGridView.Rows(e.RowIndex).Cells("ID").Value
                    c.Value = Not c.Value
                    If c.OwningColumn.Name = "Ignore_HD" Then
                        If c.Value Then
                            sMessage = "Media ignored for HD"
                        Else
                            sMessage = "Media un-ignored for HD"
                        End If
                    Else
                        If c.Value Then
                            sMessage = "Media ignored for SD"
                        Else
                            sMessage = "Media un-ignored for SD"
                        End If
                    End If

                    iScroll = Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex
                    Save_Data()
                    ReQuery()
                    c = Gemini_MediaDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    c.OwningRow.Selected = True
                    Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex = iScroll
                    objHistory.Add_To_History(iID, sMessage)
            End Select
        End If



    End Sub

    Private Sub Gemini_MediaDataGridView_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Gemini_MediaDataGridView.RowHeaderMouseDoubleClick

        If Gemini_MediaDataGridView.Rows(e.RowIndex).Cells("Package").Value = True Then
            Gemini_MediaDataGridView.Rows(e.RowIndex).Cells("Package").Value = False
        Else
            Gemini_MediaDataGridView.Rows(e.RowIndex).Cells("Package").Value = True
        End If

    End Sub

    
    Private Sub Gemini_MediaDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gemini_MediaDataGridView.SelectionChanged

        Dim iLocation_ID As Integer
        Dim mmdb As mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sFilename As String
        Dim sClip As String
        Dim bHD As Boolean

        If Gemini_MediaDataGridView.SelectedRows.Count > 0 Then
            mmdb = New mmdb_Data(dt)
            iLocation_ID = Gemini_MediaDataGridView.SelectedRows(0).Cells("Location_ID").Value
            sClip = Gemini_MediaDataGridView.SelectedRows(0).Cells("Filename").Value
            bHD = objSettings.HD(sSettings_File_Name)
            Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
            sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, Remove_PPV(sClip))
            Me.txtClip_Filename.Text = sFilename
            Show_History()
        End If

    End Sub
    Private Sub Deselect_All_Rows()

        Dim dr As DataGridViewRow


        For Each dr In Gemini_MediaDataGridView.SelectedRows
            dr.Selected = False
        Next

        Me.Refresh()
        Application.DoEvents()

    End Sub

    Private Sub cndPackage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackage.Click

        Dim dr As DataGridViewRow
        Dim iDestination_Page As Integer
        Dim iLocation_ID As Integer
        Dim mmdb As mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sFilename As String
        Dim sFilenames() As File_Details
        Dim iNum As Integer
        Dim sClip As String
        Dim sBasename As String
        Dim bHD As Boolean

        mm.Add(String.Format("ClarityGen Package. Version: {0}", sVersionString))
        mm.Add("=====================================")

        iDestination_Page = objSettings.Package_Start_Page(sSettings_File_Name)
        objClarity.Connect()
        objClarity.Connect_Feedback()

        iNum = 0
        bHD = objSettings.HD(sSettings_File_Name)
        mmdb = New mmdb_Data(dt)

        ReDim Preserve sFilenames(0)

        If Not objClarity.Is_Job_Loaded() Then
            If objClarity.Load_Job() Then
                If objClarity.Job_Load_Wait(Me.ProgressBar1) Then
                    For Each dr In Gemini_MediaDataGridView.Rows
                        If dr.Cells("Package").Value = True Then
                            iLocation_ID = dr.Cells("Location_ID").Value
                            sClip = dr.Cells("Filename").Value
                            Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
                            sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)
                            If objClarity.Create_Page(iDestination_Page) Then
                                objClarity.Update_Page(iDestination_Page, Remove_PPV(sFilename))
                                iDestination_Page += 1
                                ReDim Preserve sFilenames(iNum)
                                sFilenames(iNum) = New File_Details
                                sFilenames(iNum).Filename = sFilename
                                sFilenames(iNum).ID = dr.Cells("ID").Value
                                sFilenames(iNum).Success = False
                                sFilenames(iNum).First_Use = dr.Cells("First_Use").Value
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
                    Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
                    sFilename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)
                    If objClarity.Create_Page(iDestination_Page) Then
                        objClarity.Update_Page(iDestination_Page, Remove_PPV(sFilename))
                        iDestination_Page += 1

                        ReDim Preserve sFilenames(iNum)
                        sFilenames(iNum) = New File_Details
                        sFilenames(iNum).Filename = sFilename
                        sFilenames(iNum).ID = dr.Cells("ID").Value
                        sFilenames(iNum).Success = False
                        sFilenames(iNum).First_Use = dr.Cells("First_Use").Value
                        iNum += 1
                    End If
                End If
            Next
        End If

        sBasename = objSettings.Package_Base
        objClarity.Save_Job(objSettings.Package_Job_Filename(sBasename))
        objClarity.Disconnect()

        Copy_Files(sBasename, sFilenames, bHD)

    End Sub

    Private Sub Copy_Files(ByVal sBaseName As String, ByVal sFilenames() As File_Details, bHD As Boolean)

        Dim sSourceJob As String
        Dim fi As FileInfo
        Dim sFolder As String
        Dim sDestination As String
        Dim objReceipt As Receipt
        Dim objCopy As Archive_Restore
        Dim sMessage As String
        Dim bSuccess As Boolean

        objReceipt = New Receipt(objSettings.Zip_File_Name(sBaseName), mm)

        If objSettings.HD(sSettings_File_Name) Then
            objReceipt.Add("HD Clips")
        Else
            objReceipt.Add("SD Clips")
        End If

        objReceipt.Add(String.Format("Zip filename: {0}", objSettings.Zip_File_Name(sBaseName)))

        sSourceJob = objSettings.Package_Job_Filename(sBaseName)

        fi = New FileInfo(sSourceJob)
        If Not fi.Exists Then
            MessageBox.Show(String.Format("The Clarity file does not exist: {0}", sSourceJob), "Missing Job")
            mm.Add(String.Format("The Clarity file does not exist: {0}", sSourceJob))
            Exit Sub
        End If
        objReceipt.Add(String.Format("Job filename: {0}", sSourceJob))
        sFolder = String.Concat(objSettings.Package_Folder(sSettings_File_Name), sBaseName, Remove_Drive_From_Folder(fi.DirectoryName))
        sDestination = objSettings.Package_Job_Filename(sBaseName, Fix_Folder_End(sFolder, Media_Type.Still))

        If Create_Folder_If_Not_Present(sFolder) Then
            fi.CopyTo(sDestination, True)
            mm.Add(String.Concat("Copying job: ", sSourceJob))
            objCopy = New Archive_Restore()
            If objSettings.Package_From_Clipstore(sSettings_File_Name) Then
                bSuccess = objCopy.Copy_Clipstore_Clips_To_Package(sFilenames, sFolder, sBaseName, objReceipt, ProgressBar1)
            Else
                bSuccess = objCopy.Copy_Emulated_Clips_To_Package(sFilenames, sFolder, sBaseName, objReceipt)
            End If

            If bSuccess Then
                Create_Zip(sBaseName)
                If objSettings.Delete_Temporary_Files(sSettings_File_Name) Then
                    Delete_Folder(objSettings.Folder_To_Zip(sBaseName))
                    mm.Add("Source files deleted")
                End If


                mm.Add("Package Complete")
                mm.Add(String.Concat("Zip filename: ", objSettings.Zip_File_Name(sBaseName)))
                mm.Add(String.Concat("Receipt filename: ", objReceipt.Filename))

                sMessage = String.Concat("Package Complete", Environment.NewLine, Environment.NewLine, "Zip filename: ", _
                                            objSettings.Zip_File_Name(sBaseName), Environment.NewLine, "Receipt filename: ", _
                                            objReceipt.Filename, Environment.NewLine, Environment.NewLine, "Do you want to store this in the media database. Answer YES unless this is a test package.")
                If MessageBox.Show(sMessage, "Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Update_Packaged_Files(sFilenames, objSettings.Zip_File_Name(sBaseName), bHD)
                End If
                objCopy.Archive_Packaged_Job(sSourceJob)
            End If
        Else
            mm.Add(String.Concat("Failed to create folder: ", sFolder))
            MessageBox.Show(String.Concat("Failed to create folder: ", sFolder), "Folder Issue", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Friend Sub Update_Packaged_Files(sFilenames() As File_Details, sPackage_Filename As String, bHD As Boolean)

        Dim dtMedia As mm_phase_5DataSet.Gemini_MediaDataTable
        Dim drMedia() As mm_phase_5DataSet.Gemini_MediaRow
        Dim i As Int32
        Dim iScroll As Int32

        dtMedia = New mm_phase_5DataSet.Gemini_MediaDataTable
        Gemini_MediaTableAdapter.Fill(dtMedia)

        For i = 0 To sFilenames.GetUpperBound(0)
            drMedia = dtMedia.Select(String.Concat("ID = ", sFilenames(i).ID.ToString))
            If drMedia.Length > 0 Then
                If sFilenames(i).Success Then
                    If bHD Then
                        drMedia(0).BeginEdit()
                        drMedia(0).Packaged = True
                        drMedia(0).Package_Date = Now
                        drMedia(0).Package_Filename = sPackage_Filename
                        drMedia(0).EndEdit()
                        objHistory.Add_To_History(sFilenames(i), String.Concat("Packaged HD Clip/Still in file: ", sPackage_Filename))
                    Else
                        drMedia(0).BeginEdit()
                        drMedia(0).Packaged_SD = True
                        drMedia(0).Package_Date_SD = Now
                        drMedia(0).Package_Filename_SD = sPackage_Filename
                        drMedia(0).EndEdit()
                        objHistory.Add_To_History(sFilenames(i), String.Concat("Packaged HD Clip/Still in file: ", sPackage_Filename))
                    End If
                End If
            End If
        Next

        Gemini_MediaTableAdapter.Update(dtMedia)

        iScroll = Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex
        ReQuery()
        Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex = iScroll

    End Sub
    Friend Sub Update_Packaged_Files_Old(sFilenames() As File_Details, sPackage_Filename As String, bHD As Boolean)

        Dim dr As DataGridViewRow
        Dim iID As Int32
        Dim iIDs(sFilenames.GetUpperBound(0)) As Int32
        Dim iItem As Int32
        Dim i As Int32

        For i = 0 To sFilenames.GetUpperBound(0)
            iIDs(i) = sFilenames(i).ID
        Next

        For Each dr In Gemini_MediaDataGridView.Rows
            iID = dr.Cells("ID").Value
            iItem = Array.IndexOf(iIDs, iID)
            If iItem >= iIDs.GetLowerBound(0) Then
                If sFilenames(iItem).Success Then
                    If bHD Then
                        dr.Cells("Packaged").Value = True
                        dr.Cells("Package_Date").Value = Now
                        dr.Cells("Package_Filename").Value = sPackage_Filename
                        objHistory.Add_To_History(sFilenames(iItem), String.Concat("Packaged HD Clip/Still in file: ", sPackage_Filename))
                    Else
                        dr.Cells("Packaged_SD").Value = True
                        dr.Cells("Package_Date_SD").Value = Now
                        dr.Cells("Package_Filename_SD").Value = sPackage_Filename
                        objHistory.Add_To_History(sFilenames(iItem), String.Concat("Packaged SD Clip/Still in file: ", sPackage_Filename))
                    End If
                End If
            End If
        Next

        Save_Data()

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

        If Not (objClarity.Is_Status_Idle Or objClarity.Is_Status_Offline) Then
            Response = MessageBox.Show("Do you want me to stop the current clip?", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Response = DialogResult.Yes Then
                If objSettings.Use_V7_Commands(sSettings_File_Name) Then
                    objClarity.Stop_Playout()
                    objClarity.Cue_Page(3)
                    objClarity.Take()
                End If
                Stop_and_Disconnect()
            End If
        End If

        Me.tmClarityEventMessage.Enabled = objSettings.Log_Clarity_Events(sSettings_File_Name)

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
        System.Threading.Thread.Sleep(2000)
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

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmClarityEventMessage.Tick

        Dim sMessages() As String
        Dim sMessage As String

        If Not objClarity Is Nothing Then
            sMessages = objClarity.Messages
            If Not sMessages Is Nothing Then
                If sMessages.Length > 0 Then
                    For Each sMessage In sMessages
                        mm.Add(sMessage)
                    Next
                End If
            End If
        End If

    End Sub

    
    Private Sub SaveDataToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveDataToolStripMenuItem.Click

        Save_Data()

    End Sub
    Private Function Get_Formats() As Boolean()

        Dim Formats() As Boolean
        Select Case cmbHD.SelectedIndex
            Case 0 'HD
                ReDim Formats(0)
                Formats(0) = True
            Case 1 'SD
                ReDim Formats(0)
                Formats(0) = False
            Case Else 'both
                ReDim Formats(1)
                Formats(0) = True
                Formats(1) = False
        End Select

        Return Formats

    End Function
    Private Sub Scan()

        Dim dr As DataGridViewRow
        Dim lProgress As Long
        Dim iLocation_ID As Int32
        Dim sClip As String
        Dim mmdb As mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sClarity_Filename As String
        Dim sReal_Filename As String
        Dim sArchive_Filename As String
        Dim bHD As Boolean
        Dim Formats() As Boolean
        Dim i As Int32
        Dim iID As Int32
        Dim bClarity_Scan As Boolean
        Dim sClipstore_Filename As String
        Dim sFTP_Folder As String
        Dim bExists As Boolean
        Dim objFTP As MuVi2_FTP
        Dim iScroll As Int32

        Dim dtMedia As mm_phase_5DataSet.Gemini_MediaDataTable
        Dim drMedia() As mm_phase_5DataSet.Gemini_MediaRow

        dtMedia = New mm_phase_5DataSet.Gemini_MediaDataTable
        Gemini_MediaTableAdapter.Fill(dtMedia)
        bClarity_Scan = objSettings.Clipstore_Scan(sSettings_File_Name)
        objFTP = New MuVi2_FTP(mm, ProgressBar1)

        Deselect_All_Rows()
        lProgress = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = Gemini_MediaDataGridView.Rows.Count
        mmdb = New mmdb_Data(dt)

        Formats = Get_Formats()

        For Each dr In Gemini_MediaDataGridView.Rows
            lProgress += 1
            ProgressBar1.Value = lProgress

            iLocation_ID = dr.Cells("Location_ID").Value
            sClip = dr.Cells("Filename").Value
            iID = dr.Cells("ID").Value
            drMedia = dtMedia.Select(String.Concat("ID = ", iID.ToString))

            If drMedia.Length > 0 Then
                For i = 0 To Formats.GetUpperBound(0)
                    bHD = Formats(i)

                    Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
                    sClarity_Filename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)

                    If File_Type(sClarity_Filename) = Media_Type.Clip Then
                        sReal_Filename = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                        If bClarity_Scan Then
                            sClipstore_Filename = Path.GetFileName(sReal_Filename)
                            sFTP_Folder = Clipstore_Folder_From_PC_Filename(sReal_Filename)
                            objFTP.Connect(True)
                            bExists = objFTP.File_Exists(sFTP_Folder, sClipstore_Filename)
                            objFTP.Disconnect()
                        Else
                            bExists = File.Exists(sReal_Filename)
                        End If
                    Else
                        sReal_Filename = String.Concat(Remove_PIC(sClarity_Filename))
                        If bClarity_Scan Then
                            sReal_Filename = sReal_Filename.Replace(objSettings.Local_Job_Folder(sSettings_File_Name), objSettings.Network_Job_Folder(sSettings_File_Name))
                        End If
                        bExists = File.Exists(sReal_Filename)
                    End If

                    If Not bExists Then
                        If bHD And File_Type(sClarity_Filename) = Media_Type.Clip And Not bClarity_Scan Then
                            sArchive_Filename = String.Concat(objSettings.HD_Archived_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                            Update_Scan(drMedia(0), False, File.Exists(sArchive_Filename), bHD, bClarity_Scan)
                        ElseIf Not bHD And File_Type(sClarity_Filename) = Media_Type.Clip And Not bClarity_Scan Then
                            sArchive_Filename = String.Concat(objSettings.SD_Archived_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                            Update_Scan(drMedia(0), False, File.Exists(sArchive_Filename), bHD, bClarity_Scan)
                        Else
                            Update_Scan(drMedia(0), False, False, bHD, bClarity_Scan)
                        End If
                    Else
                        Update_Scan(drMedia(0), True, False, bHD, bClarity_Scan)
                    End If
                Next
            End If
        Next

        ProgressBar1.Value = 0
        Gemini_MediaTableAdapter.Update(dtMedia)

        iScroll = Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex
        ReQuery()
        Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex = iScroll

    End Sub
    Private Sub Scan_Old()

        Dim dr As DataGridViewRow
        Dim lProgress As Long
        Dim iLocation_ID As Int32
        Dim sClip As String
        Dim mmdb As mmdb_Data
        Dim Folder_Stuff = New Folder_Details
        Dim sClarity_Filename As String
        Dim sReal_Filename As String
        Dim sArchive_Filename As String
        Dim bHD As Boolean
        Dim Formats() As Boolean
        Dim i As Int32

        Deselect_All_Rows()
        lProgress = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = Gemini_MediaDataGridView.Rows.Count
        mmdb = New mmdb_Data(dt)

        Formats = Get_Formats()

        For Each dr In Gemini_MediaDataGridView.Rows
            lProgress += 1
            ProgressBar1.Value = lProgress

            iLocation_ID = dr.Cells("Location_ID").Value
            sClip = dr.Cells("Filename").Value

            For i = 0 To Formats.GetUpperBound(0)
                bHD = Formats(i)

                Folder_Stuff = mmdb.Find(iLocation_ID, bHD)
                sClarity_Filename = String.Concat(Folder_Stuff.Clarity_Prefix, Folder_Stuff.Folder_Name, sClip)

                If File_Type(sClarity_Filename) = Media_Type.Clip Then
                    sReal_Filename = String.Concat(objSettings.Emulated_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                Else
                    sReal_Filename = String.Concat(Remove_PIC(sClarity_Filename))
                End If

                If Not File.Exists(sReal_Filename) Then
                    If bHD And File_Type(sClarity_Filename) = Media_Type.Clip Then
                        sArchive_Filename = String.Concat(objSettings.HD_Archived_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                        Update_Scan_Old(False, File.Exists(sArchive_Filename), bHD, dr)
                    ElseIf Not bHD And File_Type(sClarity_Filename) = Media_Type.Clip Then
                        sArchive_Filename = String.Concat(objSettings.SD_Archived_Clips_Folder(sSettings_File_Name), Clip_Base_Filename(sClarity_Filename))
                        Update_Scan_Old(False, File.Exists(sArchive_Filename), bHD, dr)
                    Else
                        Update_Scan_Old(False, False, bHD, dr)
                    End If
                Else
                    Update_Scan_Old(True, False, bHD, dr)
                End If
                Save_Data()
            Next
        Next

        ProgressBar1.Value = 0
        Save_Data()
    End Sub
    Private Sub cmdScan_Click(sender As System.Object, e As System.EventArgs) Handles cmdScan.Click

        Scan()

    End Sub
    Private Sub Update_Scan(ByRef drMedia As mm_phase_5DataSet.Gemini_MediaRow, bFound As Boolean, bArchived As Boolean, bHD As Boolean, bClarity_Scan As Boolean)

        Dim bPrevious_Archived As Boolean
        Dim bPrevious_Missing As Boolean
        Dim sArchive_Column As String
        Dim sMissing_Column As String

        If bHD Then
            sArchive_Column = "Archived"
            sMissing_Column = "Missing"
        Else
            sArchive_Column = "Archived_SD"
            sMissing_Column = "Missing_SD"
        End If

        bPrevious_Archived = drMedia(sArchive_Column)
        bPrevious_Missing = drMedia(sMissing_Column)

        drMedia.BeginEdit()
        If bClarity_Scan Then
            drMedia("On_Clarity_Clipstore") = bFound
        Else
            If bFound Then
                drMedia(sArchive_Column) = False
                drMedia(sMissing_Column) = False
                If bPrevious_Archived Or bPrevious_Missing Then
                    objHistory.Add_To_History(drMedia.ID, "File in current folder")
                End If
            ElseIf bArchived Then
                drMedia(sArchive_Column) = True
                drMedia(sMissing_Column) = False
                If Not bPrevious_Archived Then
                    objHistory.Add_To_History(drMedia.ID, "File moved to archive")
                End If
            Else
                drMedia(sArchive_Column) = False
                drMedia(sMissing_Column) = True
                If Not bPrevious_Missing Then
                    objHistory.Add_To_History(drMedia.ID, "File detected as missing")
                End If
            End If
        End If
        drMedia.EndEdit()

    End Sub
    Private Sub Update_Scan_Old(bFound As Boolean, bArchived As Boolean, bHD As Boolean, dr As DataGridViewRow)

        Dim bPrevious_Archived As Boolean
        Dim bPrevious_Missing As Boolean
        Dim sArchive_Column As String
        Dim sMissing_Column As String

        If bHD Then
            sArchive_Column = "Archived"
            sMissing_Column = "Missing"
        Else
            sArchive_Column = "Archived_SD"
            sMissing_Column = "Missing_SD"
        End If

        bPrevious_Archived = dr.Cells(sArchive_Column).Value
        bPrevious_Missing = dr.Cells(sMissing_Column).Value

        If bFound Then
            dr.Cells(sArchive_Column).Value = False
            dr.Cells(sMissing_Column).Value = False
            If bPrevious_Archived Or bPrevious_Missing Then
                objHistory.Add_To_History(dr.Cells("ID").Value, "File in current folder")
            End If
        ElseIf bArchived Then
            dr.Cells(sArchive_Column).Value = True
            dr.Cells(sMissing_Column).Value = False
            If Not bPrevious_Archived Then
                objHistory.Add_To_History(dr.Cells("ID").Value, "File moved to archive")
            End If
        Else
            dr.Cells(sArchive_Column).Value = False
            dr.Cells(sMissing_Column).Value = True
            If Not bPrevious_Missing Then
                objHistory.Add_To_History(dr.Cells("ID").Value, "File detected as missing")
            End If
        End If


    End Sub

    Private Sub cmbView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbView.SelectedIndexChanged

        View_Change()

    End Sub

    Private Sub View_Change()

        Dim bPackaging As Boolean
        Dim Picture_Format As Format_Details

        bPackaging = cmbView.SelectedIndex = 0
        Picture_Format = New Format_Details
        Picture_Format.HD = cmbHD.SelectedIndex = 0 Or cmbHD.SelectedIndex = 2
        Picture_Format.SD = cmbHD.SelectedIndex = 1 Or cmbHD.SelectedIndex = 2

        Set_Columns(Picture_Format, bPackaging)
        Set_Controls(bPackaging, objSettings.HD(sSettings_File_Name))

    End Sub

    Friend Sub Update_Archived_Restored_Files_Old(sFilenames() As File_Details, bArchived As Boolean, bHD As Boolean)

        Dim dr As DataGridViewRow
        Dim iIDs(sFilenames.GetUpperBound(0)) As Int32
        Dim iID As Int32
        Dim iItem As Int32
        Dim i As Int32


        For i = 0 To sFilenames.GetUpperBound(0)
            iIDs(i) = sFilenames(i).ID
        Next

        For Each dr In Gemini_MediaDataGridView.Rows

            iID = dr.Cells("ID").Value
            iItem = Array.IndexOf(iIDs, iID)
            If iItem >= iIDs.GetLowerBound(0) Then
                If sFilenames(iItem).Success Then
                    If bArchived Then
                        If bHD Then
                            dr.Cells("Archive").Value = False
                            dr.Cells("Archived_Date").Value = Now
                            dr.Cells("Archived").Value = True
                            objHistory.Add_To_History(sFilenames(iItem), "Archived HD Clip")
                        Else
                            dr.Cells("Archive_SD").Value = False
                            dr.Cells("Archived_Date_SD").Value = Now
                            dr.Cells("Archived_SD").Value = True
                            objHistory.Add_To_History(sFilenames(iItem), "Archived SD Clip")
                        End If
                    Else
                        If bHD Then
                            dr.Cells("Archive").Value = False
                            dr.Cells("Archived").Value = False
                            dr.Cells("Restore_Date").Value = Now
                        Else
                            dr.Cells("Archive_SD").Value = False
                            dr.Cells("Archived_SD").Value = False
                            dr.Cells("Restore_Date_SD").Value = Now
                        End If
                    End If
                End If
            End If
        Next

        Save_Data()

    End Sub

    Friend Sub Update_Archived_Restored_Files(sFilenames() As File_Details, bArchived As Boolean, bHD As Boolean)

        Dim dtMedia As mm_phase_5DataSet.Gemini_MediaDataTable
        Dim drMedia() As mm_phase_5DataSet.Gemini_MediaRow
        Dim i As Int32
        Dim iScroll As Int32


        dtMedia = New mm_phase_5DataSet.Gemini_MediaDataTable
        Gemini_MediaTableAdapter.Fill(dtMedia)

        For i = 0 To sFilenames.GetUpperBound(0)
            drMedia = dtMedia.Select(String.Concat("ID = ", sFilenames(i).ID.ToString))
            If drMedia.Length > 0 Then
                If sFilenames(i).Success Then
                    If bArchived Then
                        If bHD Then
                            drMedia(0).BeginEdit()
                            drMedia(0).Archived_Date = Now
                            drMedia(0).Archived = True
                            drMedia(0).EndEdit()
                            objHistory.Add_To_History(sFilenames(i), "Archived HD Clip")
                        Else
                            drMedia(0).BeginEdit()
                            drMedia(0).Archived_Date_SD = Now
                            drMedia(0).Archived_SD = True
                            drMedia(0).EndEdit()
                            objHistory.Add_To_History(sFilenames(i), "Archived SD Clip")
                        End If
                    Else
                        If bHD Then
                            drMedia(0).BeginEdit()
                            drMedia(0).Unarchived_Date = Now
                            drMedia(0).Archived = False
                            drMedia(0).EndEdit()
                            objHistory.Add_To_History(sFilenames(i), "Restored HD Clip")
                        Else
                            drMedia(0).BeginEdit()
                            drMedia(0).Unarchived_Date_SD = Now
                            drMedia(0).Archived_SD = False
                            drMedia(0).EndEdit()
                            objHistory.Add_To_History(sFilenames(i), "Restored SD Clip")
                        End If
                    End If
                End If
            End If

        Next

        Gemini_MediaTableAdapter.Update(dtMedia)

        iScroll = Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex
        ReQuery()
        Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex = iScroll


    End Sub



    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged

        ReQuery()
        dtDelivery.Enabled = Not chkAll.Checked

    End Sub

    Private Sub cmdArchive_Click(sender As System.Object, e As System.EventArgs) Handles cmdArchive.Click

        Archive_Restore(True)

    End Sub

    Private Sub cmdRestore_Click(sender As System.Object, e As System.EventArgs) Handles cmdRestore.Click

        Archive_Restore(False)

    End Sub

    Private Sub Archive_Restore(bArchive As Boolean)

        Dim objArchive As Archive_Restore
        Dim bHD As Boolean
        Dim sFilenames() As File_Details
        Dim sMessage As String
        Dim Formats() As Boolean
        Dim i As Long

        mm.Add(String.Format("ClarityGen Archive/Restore. Version: {0}", sVersionString))
        mm.Add("=====================================")

        Formats = Get_Formats()

        Deselect_All_Rows()
        objArchive = New Archive_Restore()

        For i = 0 To Formats.GetUpperBound(0)
            bHD = Formats(i)
            mm.Add(String.Concat("Starting ", Archive_Restore_Display(bArchive, bHD)))

            sFilenames = objArchive.Archive_Restore_Filenames(Gemini_MediaDataGridView, dt, bHD)

            If objArchive.Archive_Restore_Files(sFilenames, bArchive, bHD) Then
                If objArchive.Totally_Successful Then
                    sMessage = String.Concat(Archive_Restore_Display(bArchive, bHD), " Complete")
                Else
                    sMessage = String.Concat(Archive_Restore_Display(bArchive, bHD), " complete with some issues")
                End If
                mm.Add(sMessage)
                sMessage = String.Concat(sMessage, Environment.NewLine, Environment.NewLine, "Do you want to store this in the media database. Answer YES unless this is a test run.")
                If MessageBox.Show(sMessage, "Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Update_Archived_Restored_Files(sFilenames, bArchive, bHD)
                End If
            Else
                mm.Add(String.Concat(Archive_Restore_Display(bArchive, bHD), " Folder not specified"))
                MessageBox.Show(String.Concat(Archive_Restore_Display(bArchive, bHD), " Folder not specified. Please adjust settings"), "No Folder", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next

    End Sub

    Private Function Archive_Restore_Display(bArchive As Boolean, bHD As Boolean) As String

        If bArchive And bHD Then
            Return "HD Archive"
        ElseIf bArchive And Not bHD Then
            Return "SD Archive"
        ElseIf Not bArchive And bHD Then
            Return "HD Restore"
        Else
            Return "SD Restore"
        End If

    End Function

    Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click

        ReQuery()

    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged

        ReQuery()

    End Sub

    Private Sub cmbHD_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbHD.SelectedIndexChanged

        View_Change()
        ReQuery()

    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged

        ReQuery()

    End Sub

 
    Private Sub SaveToExcelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToExcelToolStripMenuItem.Click

        Dim Excel As Excel_Save
        Dim dr() As mm_phase_5DataSet.Gemini_MediaRow

        Dim sFormatted_Date As String
        Dim sFilter As String

        Dim sFilename As String
        Dim Response As DialogResult



        sFormatted_Date = String.Concat("'", Now.ToString("dd/MM/yy"), "'")
        sFilter = String.Concat("Ignore_HD = 'False' AND Packaged = 'True' AND Last_Use >= ", sFormatted_Date, " AND First_Use <= ", sFormatted_Date)
        dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)

        Excel = New Excel_Save
        sFilename = Excel.Create_Sheet()
        If sFilename <> "" Then
            Excel.Create_Available_Sheet(dr, dt, True, "Current Promo Clips HD", True)

            dr = Nothing
            sFilter = String.Concat("Ignore_HD = 'False' AND Archived = True OR Missing = True")
            dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)
            Excel.Create_Archived_Sheet(dr, dt, "Archived Promo Clips HD", True)

            dr = Nothing
            sFormatted_Date = String.Concat("'", Now.AddMonths(-1).ToString("dd/MM/yy"), "'")
            sFilter = String.Concat("Ignore_HD = 'False' AND Archived = True AND [Archived Date] >= ", sFormatted_Date)
            'sFilter = String.Concat("Archived = True AND 'Archived Date' is NULL")
            dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)
            Excel.Create_Archived_Sheet(dr, dt, "Archived HD last month", True)

            sFormatted_Date = String.Concat("'", Now.ToString("dd/MM/yy"), "'")
            sFilter = String.Concat("Ignore_SD = 'False' AND Packaged_SD = 'True' AND Last_Use >= ", sFormatted_Date, " AND First_Use <= ", sFormatted_Date)
            dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)
            Excel.Create_Available_Sheet(dr, dt, False, "Current Promo Clips SD", False)


            dr = Nothing
            sFilter = String.Concat("Ignore_SD = 'False' AND Archived_SD = True OR Missing_SD = True")
            dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)
            Excel.Create_Archived_Sheet(dr, dt, "Archived Promo Clips SD", False)

            dr = Nothing
            sFormatted_Date = String.Concat("'", Now.AddMonths(-1).ToString("dd/MM/yy"), "'")
            sFilter = String.Concat("Ignore_SD = 'False' AND Archived_SD = True AND Archived_Date_SD >= ", sFormatted_Date)
            dr = Mm_phase_5DataSet.Tables("Gemini_Media").Select(sFilter)
            Excel.Create_Archived_Sheet(dr, dt, "Archived SD last month", False)
            Excel.Select_First_Sheet()
            Excel.Save()
            Excel.Close()
        End If

        Excel = Nothing

        If sFilename <> "" Then
            Response = MessageBox.Show(String.Concat("Spreadsheet created with filename: ", sFilename, "Would you like to open it?"), "Spreadsheet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Response = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(sFilename)
            End If
        Else
            MessageBox.Show("No spreadsheet created", "No spreadsheet", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub

    Private Sub cmdSend_Clarity_Click(sender As System.Object, e As System.EventArgs) Handles cmdSend_Clarity.Click

        Send_To_Clarity()

    End Sub

    Private Sub Send_To_Clarity()

        Dim objArchive As Archive_Restore
        Dim bHD As Boolean
        Dim sFilenames() As File_Details
        Dim sMessage As String
        Dim Formats() As Boolean
        Dim i As Long

        mm.Add(String.Format("ClarityGen Send to Clarity. Version: {0}", sVersionString))
        mm.Add("=====================================")

        Formats = Get_Formats()

        Deselect_All_Rows()
        objArchive = New Archive_Restore()

        For i = 0 To Formats.GetUpperBound(0)
            bHD = Formats(i)
            mm.Add(String.Concat("Starting Clarity Transfer"))

            sFilenames = objArchive.Clarity_Transfer_Filenames(Gemini_MediaDataGridView, dt, bHD)

            If objArchive.Transfer_Files_To_Clarity(sFilenames, ProgressBar1) Then
                If objArchive.Totally_Successful Then
                    sMessage = "Clarity transfer complete"
                Else
                    sMessage = "Clarity transfer complete with some issues"
                    MessageBox.Show("There were some issues with the transfer to the Clarity", "Issues", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                mm.Add(sMessage)
                Update_Clarity_Transferred_Files(sFilenames)
            Else
                mm.Add("Could not connect to the FTP Server/Clipstore on the Clarity.")
                MessageBox.Show("Could not connect to the FTP Server/Clipstore on the Clarity. Is the Clarity switched on with the Clarity application running?", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next

    End Sub

    Friend Sub Update_Clarity_Transferred_Files(sFilenames() As File_Details)

        Dim i As Int32
        Dim iScroll As Int32

        For i = 0 To sFilenames.GetUpperBound(0)
            If sFilenames(i).Success Then
                objHistory.Add_To_History(sFilenames(i), "Transferred to Clarity")
            End If
        Next

        iScroll = Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex
        ReQuery()
        Gemini_MediaDataGridView.FirstDisplayedScrollingRowIndex = iScroll
    End Sub

    Friend Sub Show_History()

        Dim sFile As File_Details

        If chkHistory.Checked And bHistory Then
            If Gemini_MediaDataGridView.SelectedRows.Count > 0 Then
                sFile = New File_Details
                sFile.ID = Gemini_MediaDataGridView.SelectedRows(0).Cells("ID").Value
                sFile.Filename = Gemini_MediaDataGridView.SelectedRows(0).Cells("Filename").Value
                If fHistory Is Nothing Then
                    fHistory = New frmHistory
                ElseIf fHistory.IsDisposed Then
                    fHistory = New frmHistory
                End If
                fHistory.Show()
                fHistory.Show_Clip(sFile)
            Else
                fHistory.Hide()
                fHistory = Nothing
            End If
        Else
            chkHistory.Checked = False
            If Not fHistory Is Nothing Then
                fHistory.Hide()
                fHistory = Nothing
            End If
        End If



    End Sub

    Private Sub chkHistory_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHistory.CheckedChanged

        bHistory = chkHistory.Checked
        Show_History()

    End Sub
End Class