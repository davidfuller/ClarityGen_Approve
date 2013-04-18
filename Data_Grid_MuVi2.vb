Public Class Data_Grid_MuVi2

    Private dg As DataGridView

    Public Sub New(dgView As DataGridView)

        dg = dgView

    End Sub

    Friend Sub Set_Colour(bHD As Boolean, bClipstore_Scan As Boolean)

        Dim dr As DataGridViewRow
        Dim bUnavailable As Boolean
        Dim bHidden As Boolean


        For Each dr In dg.Rows
            If bClipstore_Scan Then
                bUnavailable = Not (dr.Cells("On_Clarity_Clipstore").Value)
                bHidden = dr.Cells("Ignore_HD").Value
            ElseIf bHD Then
                bUnavailable = dr.Cells("Missing").Value Or dr.Cells("Archived").Value
                bHidden = dr.Cells("Ignore_HD").Value
            Else
                bUnavailable = dr.Cells("Missing_SD").Value Or dr.Cells("Archived_SD").Value
                bHidden = dr.Cells("Ignore_SD").Value
            End If

            If bUnavailable Then
                If (dr.Index Mod 2) = 0 Then
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_MISSING_DARK
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_MISSING_HIGHLIGHT
                Else
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_MISSING_LIGHT
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_MISSING_HIGHLIGHT
                End If
            ElseIf bHidden Then
                If (dr.Index Mod 2) = 0 Then
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_HIDDEN_LIGHT
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_HIDDEN_HIGHLIGHT
                Else
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_HIDDEN_DARK
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_HIDDEN_HIGHLIGHT
                End If
            Else
                If (dr.Index Mod 2) = 0 Then
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_LIGHT
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_HIGHLIGHT
                Else
                    dr.DefaultCellStyle.ForeColor = Color.Black
                    dr.DefaultCellStyle.BackColor = COLOUR_DARK
                    dr.DefaultCellStyle.SelectionForeColor = Color.Black
                    dr.DefaultCellStyle.SelectionBackColor = COLOUR_HIGHLIGHT
                End If

            End If

        Next

    End Sub
End Class
