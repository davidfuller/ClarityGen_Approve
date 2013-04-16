Public Class History

    Private Clip_HistoryTableAdapter As mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter
    Public Sub New(ta As mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter)

        Clip_HistoryTableAdapter = ta

    End Sub

    Public Sub Add_To_History(sFilename As File_Details, sMessage As String)

        Add_To_History(sFilename.ID, sMessage)

    End Sub

    Public Sub Add_To_History(iFile_ID As Int32, sMessage As String)

        Dim dtHistory As mm_phase_5DataSet.Clip_HistoryDataTable
        Dim dr As mm_phase_5DataSet.Clip_HistoryRow

        dtHistory = New mm_phase_5DataSet.Clip_HistoryDataTable
        Clip_HistoryTableAdapter.Fill(dtHistory)

        dr = dtHistory.NewClip_HistoryRow
        dr.Media_ID = iFile_ID
        dr.Added = Now
        dr.Message = sMessage
        dtHistory.AddClip_HistoryRow(dr)

        Clip_HistoryTableAdapter.Update(dtHistory)

    End Sub

   
End Class
