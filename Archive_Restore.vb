Imports System.IO
Public Class Archive_Restore

    Private objSettings As Settings_MuVi2
    Private mmdb As mmdb_Data
    Private bTotally_Successful As Boolean

    Public Sub New(dtLocations As mm_phase_5DataSet.Gemini_Media_LocationsDataTable)

        objSettings = New Settings_MuVi2
        mmdb = New mmdb_Data(dtLocations)

    End Sub

    Friend Function Archive_Restore_Filenames(dgv As DataGridView, bHD As Boolean) As File_Details()

        Dim dr As DataGridViewRow

        Dim sFilenames() As File_Details
        Dim iNum As Integer

        iNum = 0

        ReDim Preserve sFilenames(0)

        For Each dr In dgv.Rows
            If (bHD And dr.Cells("Archive").Value = True) Or ((Not bHD) And dr.Cells("Archive_SD").Value = True) Then
                ReDim Preserve sFilenames(iNum)
                sFilenames(iNum) = New File_Details
                sFilenames(iNum).Filename = Get_Filename(dr, bHD)
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
            'Here's Johnny
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
    Private Function Get_Filename(dr As DataGridViewRow, bHD As Boolean) As String

        Dim iLocation_ID As Integer
        Dim sClip As String
        Dim Folder_Stuff = New Folder_Details

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



End Class
Public Class File_Details

    Public Filename As String
    Public ID As Integer
    Public Success As Boolean

End Class
