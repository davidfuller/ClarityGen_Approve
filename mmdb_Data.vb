Public Class mmdb_Data
    Private objSettings As Settings_MuVi2
    Private dt As mm_phase_5DataSet.Gemini_Media_LocationsDataTable
    Public Sub New(dtLocation As mm_phase_5DataSet.Gemini_Media_LocationsDataTable)

        objSettings = New Settings_MuVi2
        dt = dtLocation

    End Sub



    Public Function Find(ByVal iFolder_ID As Integer, bHD As Boolean) As Folder_Details

        Dim fd As New Folder_Details

        Dim dr() As mm_phase_5DataSet.Gemini_Media_LocationsRow
        Dim sFolder As String


        dr = dt.Select(String.Concat("ID = '", iFolder_ID, "'"))

        If dr.Count > 0 Then
            If dr(0).Clip Then
                If bHD Then
                    sFolder = String.Concat(dr(0).Location, objSettings.HD_Folder_Suffix(sSettings_File_Name))
                Else
                    sFolder = dr(0).Location
                End If
                fd.Folder_Name = Fix_Folder_End(sFolder, Media_Type.Clip)
            Else
                fd.Folder_Name = Fix_Folder_End(dr(0).Location, Media_Type.Still)
            End If

            fd.Clarity_Prefix = dr(0).Background_Prefix
        End If

        Return fd

    End Function

    

    
End Class
Public Class Folder_Details

    Public Folder_Name
    Public Clarity_Prefix
End Class
