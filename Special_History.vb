Public Class Special_History

    Private adptJob_History As mm_phase_5DataSetTableAdapters.cl_JobHistoryTableAdapter

    Public Sub New()

        adptJob_History = New mm_phase_5DataSetTableAdapters.cl_JobHistoryTableAdapter
        adptJob_History.Connection = dbConnection()


    End Sub


    Friend Sub Add_To_Job_History(iJob_ID As Int32, sMessage As String)

        Dim dtHistory As mm_phase_5DataSet.cl_JobHistoryDataTable
        Dim dr As mm_phase_5DataSet.cl_JobHistoryRow

        dtHistory = New mm_phase_5DataSet.cl_JobHistoryDataTable
        adptJob_History.Fill(dtHistory)

        dr = dtHistory.Newcl_JobHistoryRow
        dr.JobID = iJob_ID
        dr.JobDate = Now
        dr.Message = sMessage
        dtHistory.Addcl_JobHistoryRow(dr)

        adptJob_History.Update(dtHistory)

    End Sub
End Class
