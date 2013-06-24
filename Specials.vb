Public Class Specials


    Public Sub New()

    End Sub

    Friend Function Scan_Job(dt As Date, mMess As mMessage) As Boolean

        Dim objClarity As Clarity
        Dim sJob_Filename As String
        Dim iReturn As Int32

        objClarity = New Clarity(mMess)
        sJob_Filename = objClarity.Currently_Loaded_Job(iReturn)
        If iReturn = 0 Then
            Return True
        Else
            Return False
        End If


    End Function

End Class
