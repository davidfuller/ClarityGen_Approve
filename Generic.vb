Imports System.IO
Imports System.Text

Module Generic


    Public Function Fix_Folder_End(ByVal sFolder As String, ByVal mt As Media_Type) As String

        If sFolder = "" Then
            Return ""
        Else
            Select Case mt
                Case Media_Type.Clip
                    If Not sFolder.Trim.EndsWith("/") Then
                        Return String.Concat(sFolder.Trim, "/")
                    Else
                        Return sFolder.Trim
                    End If
                Case Media_Type.Still
                    If Not sFolder.Trim.EndsWith("\") Then
                        Return String.Concat(sFolder.Trim, "\")
                    Else
                        Return sFolder.Trim
                    End If
                Case Else
                    Return sFolder.Trim
            End Select
        End If

    End Function
    Public Function Un_Fix_Folder_End(ByVal sFolder As String, ByVal mt As Media_Type) As String

        If sFolder = "" Then
            Return ""
        Else
            Select Case mt
                Case Media_Type.Clip
                    If sFolder.Trim.EndsWith("/") Then
                        Return sFolder.Trim.Substring(0, sFolder.Trim.Length - 1)
                    Else
                        Return sFolder.Trim
                    End If
                Case Media_Type.Still
                    If sFolder.Trim.EndsWith("\") Then
                        Return sFolder.Trim.Substring(0, sFolder.Trim.Length - 1)
                    Else
                        Return sFolder.Trim
                    End If
                Case Else
                    Return sFolder.Trim
            End Select
        End If

    End Function
    Public Function Remove_PPV(ByVal sFilename As String) As String

        sFilename = sFilename.Trim
        If sFilename.Length < 4 Then
            Return sFilename
        ElseIf sFilename.ToUpper.EndsWith(".PPV") Then
            Return sFilename.Substring(0, sFilename.Length - 4)
        Else
            Return sFilename
        End If

    End Function
    Public Function File_Type(ByVal sFilename As String) As Media_Type

        If sFilename.StartsWith("PIC:") Then
            Return Media_Type.Still
        ElseIf sFilename.StartsWith("VID:") Then
            Return Media_Type.Clip
        Else
            Return Media_Type.Not_Known
        End If

    End Function
    Public Function Page_Delay(ByVal sFilename As String) As String

        Dim objSettings As New Settings_MuVi2
        Dim mType As Media_Type

        mType = File_Type(sFilename)

        Select mType
            Case Media_Type.Still
                Return objSettings.Still_Delay(sSettings_File_Name)
            Case Media_Type.Clip
                Return objSettings.Clip_Delay(sSettings_File_Name)
            Case Else
                Return ("00:00")
        End Select


    End Function
    
    Public Function Remove_Drive_From_Folder(ByVal sFolder As String) As String

        ' If C:\Five Clarity returns \Five Clarity\
        ' If \\Clarity3000\Five Clarity returns \Five Clarity\

        Return Fix_Folder_End(Remove_Drive(sFolder), Media_Type.Still)

    End Function
    Public Function Remove_Drive_From_Filename(ByVal sFilename As String) As String

        ' If C:\Five Clarity\Fred.tga returns \Five Clarity\Fred.tga
        ' If \\Clarity3000\Five Clarity\Fred.tga returns \Five Clarity\Fred.tga

        Return Remove_Drive(sFilename)

    End Function

    Public Function Remove_Drive(ByVal sName As String) As String

        ' If C:\Five Clarity\Fred.tga returns \Five Clarity\Fred.tga
        ' If \\Clarity3000\Five Clarity\Fred.tga returns \Five Clarity\Fred.tga
        Dim iFirstSlash As Integer

        If sName.StartsWith("\\") Then
            sName = sName.Substring(2)
        End If
        iFirstSlash = sName.IndexOfAny("\")

        Return sName.Substring(iFirstSlash)

    End Function

    Public Function Clip_Base_Filename(ByVal sFilename As String) As String

        'If VID:Clip/Auto/Five USA/Generic_HD/0904_US_01_PURPLE_CAR.ppv
        'Returns \Auto\Five USA\Generic_HD\0904_US_01_PURPLE_CAR.ppv

        Dim iFirst_Slash As Integer

        iFirst_Slash = sFilename.IndexOfAny("/")
        Return sFilename.Substring(iFirst_Slash).Replace("/", "\")

    End Function

    Public Function Remove_PIC(ByVal sFilename As String) As String

        'If PIC:C:\Five Clarity\Auto\Still\Five 2008\Five_Star_Promo\1116_STAR_DAVID_TEST_5ST.tga
        'Returns C:\Five Clarity\Auto\Still\Five 2008\Five_Star_Promo\1116_STAR_DAVID_TEST_5ST.tga

        If sFilename.StartsWith("PIC:") Then
            Return sFilename.Substring(4)
        Else
            Return sFilename
        End If

    End Function

    Public Function Still_Dest_Filename(ByVal sFilename As String, ByVal sBasename As String) As String

        Dim objSetting As New Settings_MuVi2

        Return String.Concat(objSetting.Package_Folder(sSettings_File_Name), sBasename, Remove_Drive_From_Filename(Remove_PIC(sFilename)))

    End Function

    Public Function Last_Monday() As Date

        Dim iDay_No As Integer

        iDay_No = CType(Now.DayOfWeek, Integer)

        Return Now.AddDays(-6 - iDay_No)

    End Function

    Public Function Zip_To_Job_Clips_Filename(ByVal sFilename As String) As String

        Dim objSettings As New Settings_MuVi2

        Return String.Concat(Fix_Folder_End(objSettings.Un_Package_Root_Folder(sSettings_File_Name), Media_Type.Still), sFilename.Replace("/", "\"))

    End Function

    Public Function Zip_To_Clarity_FTP_Folder(ByVal sFilename As String) As String

        Dim objSettings As New Settings_MuVi2
        Dim sJust_Folder As String
        Dim iLast_Slash As Integer
        Dim iClips_Position As Integer
        Dim sClip_Search As String


        iLast_Slash = sFilename.LastIndexOf("/")
        If iLast_Slash > -1 Then
            sJust_Folder = sFilename.Substring(0, iLast_Slash)
            sClip_Search = String.Concat("/", objSettings.Job_Clips_Subfolder(sSettings_File_Name), "/")
            iClips_Position = sJust_Folder.IndexOf(sClip_Search, StringComparison.CurrentCultureIgnoreCase)
            If iClips_Position > -1 Then
                sJust_Folder = sJust_Folder.Substring(iClips_Position + sClip_Search.Length)
                Return Fix_Folder_End(String.Concat("/", Fix_Folder_End(objSettings.Clipstore_Name(sSettings_File_Name), Media_Type.Clip), sJust_Folder), Media_Type.Clip)
            Else
                Return ""
            End If
        Else
            Return ""
        End If

    End Function

    Public Function Zip_To_Clarity_Clip_Filename(ByVal sFilename As String) As String

        Dim fi As FileInfo
        Dim sWindows_Filename As String

        sWindows_Filename = Zip_To_Job_Clips_Filename(sFilename)
        fi = New FileInfo(sWindows_Filename)

        Return fi.Name

    End Function

    Public Function Zip_To_Job_Filename(ByVal sFilename As String) As String

        Dim objSettings As New Settings_MuVi2

        Return String.Concat(Fix_Folder_End(objSettings.Un_Package_Root_Folder(sSettings_File_Name), Media_Type.Still), sFilename.Replace("/", "\"))

        
    End Function

    Friend Function sVersionString() As String

        Return System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString

    End Function

    Friend Function Convert_PC_to_Clip_Filename(sFilename As String) As String

        Dim sResult As String

        sResult = Remove_PPV(Remove_Drive(sFilename).Replace("\", "/"))
        If sResult.Substring(0, 1) = "/" Then
            sResult = sResult.Substring(1)
        End If
        Return sResult

    End Function

    Friend Function Create_Folder_If_Not_Present(ByVal sFolder As String) As Boolean

        Try
            Dim di = New DirectoryInfo(sFolder)
            If Not di.Exists Then
                di.Create()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        

    End Function

    Friend Function Escape_Like_Value(sWithoutWildcards As String) As String

        Dim sb As StringBuilder
        Dim c As Char

        sb = New StringBuilder
        For i = 0 To sWithoutWildcards.Length - 1
            c = sWithoutWildcards(i)
            Select Case c
                Case "*", "%", "[", "]"
                    sb.Append("[").Append(c).Append("]")
                Case "'"
                    sb.Append("''")
                Case Else
                    sb.Append(c)
            End Select
        Next

        Return (sb.ToString)

    End Function

End Module
Public Class Format_Details

    Friend HD As Boolean
    Friend SD As Boolean

End Class