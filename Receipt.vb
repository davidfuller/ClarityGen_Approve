Imports System.IO
Public Class Receipt
    Private sFilename As String
    Private objSettings As Settings_MuVi2
    Private bValid As Boolean
    Private mml As mMessage


    Public Sub New(ByVal sPackage_Filename As String, ByVal mm As mMessage)

        Dim fi As FileInfo
        Dim sBase As String

        objSettings = New Settings_MuVi2

        bValid = objSettings.Generate_Receipt(sSettings_File_Name)

        If bValid Then
            mml = mm
            fi = New FileInfo(sPackage_Filename)
            sBase = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length)
            
            sFilename = String.Concat(Fix_Folder_End(objSettings.Receipt_Folder(sSettings_File_Name), Media_Type.Still), sBase, "_Receipt.txt")
        End If


    End Sub

    Public Sub Add(ByVal sMessage As String)

        Dim sw As StreamWriter
        Dim fi As FileInfo

        sw = Nothing
        If bValid Then
            fi = New FileInfo(sFilename)

            Try
                If Not fi.Directory.Exists Then fi.Directory.Create()

                If File.Exists(sFilename) Then
                    sw = File.AppendText(sFilename)
                Else
                    sw = File.CreateText(sFilename)
                End If
                sw.WriteLine(sMessage)
                
            Catch ex As Exception
                bValid = False
                mml.Add(String.Format("Issue writing receipt file: {0}", sFilename))
            Finally
                If Not sw Is Nothing Then
                    sw.Flush()
                    sw.Close()
                End If
            End Try
        End If

    End Sub
    Public Property Filename
        Get
            Return sFilename
        End Get
        Set(ByVal value)

        End Set
    End Property
End Class
