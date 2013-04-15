Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Public Class Excel_Save

    Private XL As Application
    Private wb As Workbook
    Private Settings As Settings_MuVi2

    Public Sub New()

        XL = New Application
        Settings = New Settings_MuVi2

    End Sub

    Friend Function Create_Sheet() As String

        Dim sFilename As String
        Dim ws As Worksheet

        XL.DisplayAlerts = False

        sFilename = Spreadsheet_Filename()
        If sFilename <> "" Then
            wb = XL.Workbooks.Add

            For Each ws In wb.Worksheets
                If wb.Worksheets.Count > 1 Then
                    ws.Delete()
                End If
            Next

            If XL.Version > 11 Then
                wb.SaveAs(sFilename, XlFileFormat.xlExcel8)
            Else
                wb.SaveAs(Filename:=sFilename)
            End If


        End If


        XL.DisplayAlerts = True
        Return sFilename

    End Function

    Private Function Spreadsheet_Filename() As String

        Dim sFolder As String
        Dim sFilename As String
        Dim iVersion As Int32

        sFolder = Settings.Spreadsheet_Folder(sSettings_File_Name)
        If sFolder <> "" Then
            If Create_Folder_If_Not_Present(sFolder) Then
                sFilename = String.Concat(sFolder, "C5_Promo_Media_Archive_", Now.ToString("yyyy-MM-dd"), ".xls")
                iVersion = 0

                While File.Exists(sFilename)
                    iVersion += 1
                    sFilename = String.Concat(sFolder, "C5_Promo_Media_Archive_", Now.ToString("yyyy-MM-dd"), "_", iVersion.ToString("000"), ".xls")
                End While

                Return sFilename
            Else
                Return ""
            End If
        Else
            Return ""
        End If

    End Function

    Friend Sub Create_Available_Sheet(dr() As mm_phase_5DataSet.Gemini_MediaRow, dt As mm_phase_5DataSet.Gemini_Media_LocationsDataTable, bFirst As Boolean, sSheet_Name As String, bHD As Boolean)

        Dim ws As Worksheet
        Dim r As Range
        Dim i As Int32
        Dim iRow As Int32
        Dim drLocation() As mm_phase_5DataSet.Gemini_Media_LocationsRow

        If bFirst Then
            ws = wb.Worksheets(1)
        Else
            ws = wb.Worksheets.Add(After:=wb.Worksheets(wb.Worksheets.Count))
        End If

        ws.Name = sSheet_Name
        r = ws.Range("A1")
        r(1, 1) = "Folder"
        r(1, 2) = "Filename"
        r(1, 3) = "Title"
        r(1, 4) = "First Use"
        r(1, 5) = "Last Use"
        r(1, 6) = "Package Date"
        r(1, 7) = "Package Filename"

        For i = dr.GetLowerBound(0) To dr.GetUpperBound(0)
            iRow = i - dr.GetLowerBound(0) + 2
            drLocation = dt.Select(String.Concat("ID = ", dr(i).Location_ID.ToString))
            If drLocation.Length > 0 Then
                If dr(i).Type_ID = 2 Or Not bHD Then
                    r(iRow, 1) = drLocation(0).Location
                Else
                    r(iRow, 1) = String.Concat(drLocation(0).Location, "_HD")
                End If
            Else
                r(iRow, 1) = ""
            End If

            r(iRow, 2) = dr(i).Filename
            r(iRow, 3) = dr(i).Title
            r(iRow, 4) = dr(i).First_Use
            r(iRow, 5) = dr(i).Last_Use
            r(iRow, 6) = Package_Date(dr(i), True)
            If bHD Then
                r(iRow, 7) = Path.GetFileName(dr(i).Package_Filename)
            Else
                r(iRow, 7) = Path.GetFileName(dr(i).Package_Filename_SD)
            End If
        Next

        r.CurrentRegion.Sort(Header:=XlYesNoGuess.xlYes, Key1:=r(1, 1), Key2:=r(1, 2), Orientation:=XlSortOrientation.xlSortColumns)
        r.CurrentRegion.Columns.EntireColumn.AutoFit()
        ws.Range("A1:G1").Font.Bold = True

    End Sub
    Friend Sub Create_Archived_Sheet(dr() As mm_phase_5DataSet.Gemini_MediaRow, dt As mm_phase_5DataSet.Gemini_Media_LocationsDataTable, sSheet_Name As String, bHD As Boolean)

        Dim ws As Worksheet
        Dim r As Range
        Dim i As Int32
        Dim iRow As Int32
        Dim drLocation() As mm_phase_5DataSet.Gemini_Media_LocationsRow

        ws = wb.Worksheets.Add(After:=wb.Worksheets(wb.Worksheets.Count))

        ws.Name = sSheet_Name
        r = ws.Range("A1")
        r(1, 1) = "Folder"
        r(1, 2) = "Filename"
        r(1, 3) = "Title"
        r(1, 4) = "Last Use"
        r(1, 5) = "Archive Date"


        For i = dr.GetLowerBound(0) To dr.GetUpperBound(0)
            iRow = i - dr.GetLowerBound(0) + 2
            drLocation = dt.Select(String.Concat("ID = ", dr(i).Location_ID.ToString))
            If drLocation.Length > 0 Then
                If dr(i).Type_ID = 2 Or Not bHD Then
                    r(iRow, 1) = drLocation(0).Location
                Else
                    r(iRow, 1) = String.Concat(drLocation(0).Location, "_HD")
                End If
            Else
                r(iRow, 1) = ""
            End If

                r(iRow, 2) = dr(i).Filename
                r(iRow, 3) = dr(i).Title
                r(iRow, 4) = dr(i).Last_Use
                r(iRow, 5) = Archive_Date(dr(i), bHD)
        Next

        r.CurrentRegion.Sort(Header:=XlYesNoGuess.xlYes, Key1:=r(1, 1), Key2:=r(1, 2), Orientation:=XlSortOrientation.xlSortColumns)
        r.CurrentRegion.Columns.EntireColumn.AutoFit()
        ws.Range("A1:E1").Font.Bold = True

    End Sub
    Friend Function Package_Date(dr As mm_phase_5DataSet.Gemini_MediaRow, bHD As Boolean) As Object

        If bHD Then
            If dr.IsPackage_DateNull Then
                Return ""
            Else
                Return dr.Package_Date
            End If
        Else
            If dr.IsPackage_Date_SDNull Then
                Return ""
            Else
                Return dr.Package_Date_SD
            End If
        End If

    End Function

    Friend Function Archive_Date(dr As mm_phase_5DataSet.Gemini_MediaRow, bHD As Boolean) As Object

        If bHD Then
            If dr.IsArchived_DateNull Then
                Return ""
            Else
                Return dr.Archived_Date
            End If
        Else
            If dr.IsArchived_Date_SDNull Then
                Return ""
            Else
                Return dr.Archived_Date_SD
            End If
        End If
    End Function
    Friend Sub Select_First_Sheet()

        wb.Worksheets("Current Promo Clips HD").Select()

    End Sub
    Friend Sub Save()

        XL.DisplayAlerts = False
        wb.Save()
        XL.DisplayAlerts = True

    End Sub


    Friend Sub Close()

        If wb IsNot Nothing Then
            wb.Close(SaveChanges:=False)
            Marshal.ReleaseComObject(wb)
        End If

    End Sub

    Protected Overrides Sub Finalize()

        Marshal.ReleaseComObject(XL)
        XL = Nothing
        MyBase.Finalize()

    End Sub
End Class
