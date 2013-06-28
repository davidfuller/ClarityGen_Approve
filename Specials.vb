Public Class Specials

    Private objSettings As Settings_MuVi2
    Private adptJob As mm_phase_5DataSetTableAdapters.cl_JobTableAdapter


    Public Sub New()
       
        adptJob = New mm_phase_5DataSetTableAdapters.cl_JobTableAdapter
        adptJob.Connection = dbConnection

    End Sub

    Friend Function Scan_Job(dt As Date, bCurrent As Boolean, mMess As mMessage) As Boolean

        Dim objClarity As Clarity
        Dim sJob_Filename As String
        Dim iReturn As Int32
        Dim dtJob As mm_phase_5DataSet.cl_JobDataTable
        Dim drs() As mm_phase_5DataSet.cl_JobRow
        Dim objHistory As Special_History

        objClarity = New Clarity(mMess)
        objHistory = New Special_History

        sJob_Filename = objClarity.Currently_Loaded_Job(iReturn)
        If iReturn = 0 Then
            dtJob = New mm_phase_5DataSet.cl_JobDataTable
            drs = Find_Job(sJob_Filename, dtJob)
        
            If drs.Length = 0 Then
                Create_New_Job(sJob_Filename, bCurrent, dtJob)
                drs = Find_Job(sJob_Filename,dtJob)
                objHistory.Add_To_Job_History(drs(0).ID, String.Concat("Job added to database, with current set to: ", bCurrent.ToString))
            Else
                If drs(0).Current <> bCurrent Then
                    drs(0).Current = bCurrent
                    adptJob.Update(dtJob)
                    drs = Find_Job(sJob_Filename,dtJob)
                    objHistory.Add_To_Job_History(drs(0).ID, String.Concat("Job updated, with current set to: ", bCurrent.ToString))
                Else
                    objHistory.Add_To_Job_History(drs(0).ID, String.Concat("Job scanned"))
                End If
            End If
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub Create_New_Job(sJob_filename As String, bCurrent As Boolean, ByRef dtJob As mm_phase_5DataSet.cl_JobDataTable)

        Dim dr As mm_phase_5DataSet.cl_JobRow

        dr = dtJob.Newcl_JobRow
        dr.JobName = sJob_Filename
        dr.Current = bCurrent
        dtJob.Addcl_JobRow(dr)
        adptJob.Update(dtJob)

    End Sub

    Private Function Find_Job(sJob_Filename As String, dtJob As mm_phase_5DataSet.cl_JobDataTable) As mm_phase_5DataSet.cl_JobRow()

        adptJob.Fill(dtJob)
        Return dtJob.Select("JobName = '" & sJob_Filename & "'")

    End Function


End Class
