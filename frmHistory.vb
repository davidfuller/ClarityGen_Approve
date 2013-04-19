Public Class frmHistory

    Private objSettings As Settings_MuVi2

    Private Sub frmHistory_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate

        bHistory = False

    End Sub

    Private Sub frmHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sConnection As String
        Dim dbConnection As OleDb.OleDbConnection

        objSettings = New Settings_MuVi2

        sConnection = objSettings.Data_Connection_String(sSettings_File_Name)
        dbConnection = New OleDb.OleDbConnection(sConnection)

        Try
            Me.Clip_HistoryTableAdapter.Connection = dbConnection
            Me.Clip_HistoryTableAdapter.Fill(Me.Mm_phase_5DataSet.Clip_History)
        Catch ex As Exception
            mm.Add("Problem connecting to media database")
            MessageBox.Show("Problem connecting to media database", "Issue")
        End Try

    End Sub


    Friend Sub Show_Clip(sFilename As File_Details)

        Dim sCriteria As String
        Dim dv As DataView

        lblClip.Text = sFilename.Filename

        sCriteria = String.Concat("Media_ID = '", sFilename.ID, "'")

        Try
            Me.Clip_HistoryTableAdapter.Fill(Me.Mm_phase_5DataSet.Clip_History)
            dv = New DataView(Mm_phase_5DataSet.Tables("Clip_History"), sCriteria, "Added", DataViewRowState.CurrentRows)
            dgHistory.DataSource = dv
        Catch ex As Exception
            mm.Add("Problem connecting to media database")
        End Try

    End Sub

End Class