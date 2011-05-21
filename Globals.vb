Module Globals

    Friend sSettings_File_Name As String = Application.StartupPath & "\Settings.xml"
    Friend mm As mMessage


    Public Const CLE_JOB_LOAD As Integer = 2801
    Public Const CLE_FIELD_UPDATES As Integer = 2802

    Public Enum Media_Type
        Clip = 2901
        Still = 2902
        Not_Known = 2903
    End Enum

End Module
