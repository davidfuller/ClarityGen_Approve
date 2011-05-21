Public Class mmdb_Data
    Private objSettings As Settings_MuVi2

    Public Sub New()

        objSettings = New Settings_MuVi2

    End Sub



    Public Function Find(ByVal iFolder_ID As Integer, ByVal da As mm_phase_5DataSetTableAdapters.Gemini_Media_LocationsTableAdapter) As Folder_Details

        Dim fd As New Folder_Details
        Dim dt As New mm_phase_5DataSet.Gemini_Media_LocationsDataTable
        Dim dr() As mm_phase_5DataSet.Gemini_Media_LocationsRow
        Dim sFolder As String

        da.Fill(dt)
        dr = dt.Select(String.Concat("ID = '", iFolder_ID, "'"))

        
        If dr(0).Clip Then
            If objSettings.HD(sSettings_File_Name) Then
                sFolder = String.Concat(dr(0).Location, objSettings.HD_Folder_Suffix(sSettings_File_Name))
            Else
                sFolder = dr(0).Location
            End If
            fd.Folder_Name = Fix_Folder_End(sFolder, Media_Type.Clip)
        Else
            fd.Folder_Name = Fix_Folder_End(dr(0).Location, Media_Type.Still)
        End If

        fd.Clarity_Prefix = dr(0).Background_Prefix

        Find = fd

    End Function

    

    
End Class
Public Class Folder_Details

    Public Folder_Name
    Public Clarity_Prefix
End Class
