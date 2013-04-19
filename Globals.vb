Module Globals

    Friend sSettings_File_Name As String = Application.StartupPath & "\Settings.xml"
    Friend mm As mMessage

    Public bPackaging_Only As Boolean
    Public bHistory As Boolean

    Public Const CLE_JOB_LOAD As Integer = 2801
    Public Const CLE_FIELD_UPDATES As Integer = 2802

    Public Enum Media_Type
        Clip = 2901
        Still = 2902
        Not_Known = 2903
    End Enum

    Friend COLOUR_MISSING_LIGHT As Color = Color.FromArgb(255, 213, 213)
    Friend COLOUR_MISSING_DARK As Color = Color.FromArgb(255, 193, 193)
    Friend COLOUR_MISSING_HIGHLIGHT As Color = Color.FromArgb(255, 173, 173)

    Friend COLOUR_LIGHT As Color = Color.FromArgb(255, 255, 255)
    Friend COLOUR_DARK As Color = Color.FromArgb(240, 240, 240)
    Friend COLOUR_HIGHLIGHT As Color = Color.FromArgb(200, 200, 200)

    Friend COLOUR_HIDDEN_LIGHT As Color = Color.FromArgb(255, 255, 185)
    Friend COLOUR_HIDDEN_DARK As Color = Color.FromArgb(255, 255, 165)
    Friend COLOUR_HIDDEN_HIGHLIGHT As Color = Color.FromArgb(255, 255, 145)

End Module
