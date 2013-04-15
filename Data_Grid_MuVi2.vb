Public Class Data_Grid_MuVi2

    Private dg As DataGridView

    Public Sub New(dgView As DataGridView)

        dg = dgView

    End Sub

    Friend Sub Set_Colour(bHD As Boolean)

        Dim dr As DataGridViewRow
        Dim dc As DataGridViewCell
        Dim bUnavailable As Boolean

        For Each dr In dg.Rows
            If bHD Then
                bUnavailable = dr.Cells("Missing").Value Or dr.Cells("Archived").Value
            Else
                bUnavailable = dr.Cells("Missing_SD").Value Or dr.Cells("Archived_SD").Value
            End If

            If bUnavailable Then
                For Each dc In dr.Cells
                    dc.Style.BackColor = Color.Tomato
                Next
            End If
        Next

    End Sub
End Class
