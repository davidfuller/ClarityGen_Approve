﻿Imports EnterpriseDT.Net.Ftp
Public Class MuVi2_FTP

    Dim ftp As FTPConnection
    Dim objSettings As Settings_MuVi2
    Dim mm As mMessage
    Dim pbar As ProgressBar
    Dim bMessage_Supress As Boolean

    Public Sub New(ByVal mMess As mMessage, ByVal progress As ProgressBar)


        objSettings = New Settings_MuVi2
        ftp = New FTPConnection
        AddHandler ftp.BytesTransferred, New BytesTransferredHandler(AddressOf Transferring)
        AddHandler ftp.Connected, New FTPConnectionEventHandler(AddressOf Connected)
        AddHandler ftp.Uploading, New FTPFileTransferEventHandler(AddressOf Starting_Upload)

        mm = mMess
        pbar = progress



    End Sub

    Public Function Connect(bSuppress_Message As Boolean) As Boolean

        Dim bSuccess As Boolean

        ftp.ServerAddress = objSettings.FTP_Server_Address(sSettings_File_Name)
        ftp.UserName = objSettings.FTP_Username(sSettings_File_Name)
        ftp.Password = objSettings.FTP_Password(sSettings_File_Name)
        ftp.ConnectMode = FTPConnectMode.ACTIVE
        ftp.Timeout = objSettings.FTP_Timeout_ms(sSettings_File_Name)
        ftp.ServerPort = objSettings.FTP_Port_Number(sSettings_File_Name)
        ftp.TransferType = FTPTransferType.BINARY
        ftp.TransferBufferSize = objSettings.Transfer_Buffer_Size(sSettings_File_Name)
        mm.Add(ftp.TransferBufferSize.ToString)


        bMessage_Supress = bSuppress_Message

        bSuccess = True
        If Not ftp.IsConnected Then
            Try
                ftp.Connect()
            Catch ex As Exception
                mm.Add(ex.Message)
                bSuccess = False
            End Try

        End If

        Return bSuccess

    End Function

    Private Sub Connected(ByVal sender As Object, ByVal e As FTPConnectionEventArgs)

        If Not bMessage_Supress Then mm.Add(String.Format("Connected to server at: {0}", e.ServerAddress))

    End Sub

    Public Overloads Function Download_File(ByVal sSource As String, ByVal sWorking_Directory As String, ByVal sDestination As String) As Boolean


        Dim ftpi() As FTPFile

        If ftp.IsConnected And Not (ftp.IsTransferring) Then
            If ftp.ServerDirectory <> sWorking_Directory Then
                If Not ftp.DirectoryExists(sWorking_Directory) Then
                    mm.Add(String.Format("Could not find Clipostore folder: {0}", sWorking_Directory))
                    Return False
                End If
            End If
            ftp.ChangeWorkingDirectory(sWorking_Directory)
        End If

        ftpi = ftp.GetFileInfos(String.Concat(sWorking_Directory, sSource))
        If ftpi.Length > 0 Then
            pbar.Maximum = ftpi(0).Size
        End If

        mm.Add(String.Format("Transferring fil:e {0}", sSource))

        ftp.DownloadFile(sDestination, sSource)
        Return True

    End Function
    Public Function File_Exists(sFolder As String, sFilename As String) As Boolean

        Dim sFiles() As String

        If ftp.IsConnected And Not (ftp.IsTransferring) Then
            If ftp.ServerDirectory <> sFolder Then
                If Not ftp.DirectoryExists(sFolder) Then
                    Return False
                End If
                ftp.ChangeWorkingDirectory(sFolder)
            End If

            sFiles = ftp.GetFiles()
            For Each sFile In sFiles
                If sFile.Equals(sFilename, StringComparison.CurrentCultureIgnoreCase) Then
                    Return True
                End If
            Next
        End If

        Return False

    End Function

    Public Overloads Function Transfer_File(ByVal sSource As String, ByVal sWorking_Directory As String, ByVal sDestination As String) As Boolean

        Dim Response As DialogResult
        Dim sFiles() As String
        Dim sFile As String
        Dim bExists As Boolean
        Dim bSuccess As Boolean

        If ftp.IsConnected And Not (ftp.IsTransferring) Then
            If ftp.ServerDirectory <> sWorking_Directory Then
                If Not ftp.DirectoryExists(sWorking_Directory) Then
                    If Not Create_Full_Folder(sWorking_Directory) Then
                        mm.Add(String.Format("Could not create folder: {0}", sWorking_Directory))
                        Return False
                    End If
                End If
                ftp.ChangeWorkingDirectory(sWorking_Directory)
            End If

            bSuccess = True
            bExists = False
            sFiles = ftp.GetFiles()
            For Each sFile In sFiles
                If sFile.Equals(sDestination, StringComparison.CurrentCultureIgnoreCase) Then
                    bExists = True
                    Exit For
                End If
            Next

            If bExists Then
                Select Case UCase(objSettings.Overwrite_Mode(sSettings_File_Name))
                    Case "OVERWRITE"
                        ftp.UploadFile(sSource, sDestination)
                    Case "SKIP"
                        mm.Add(String.Format("{0} exists in the clipstore. It has not been re-transferred", sDestination))
                        bSuccess = False
                    Case "ASK"
                        Response = MessageBox.Show(String.Format("{0} exists in the clipstore. Do you wish to overwrite?", sDestination), "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Response = DialogResult.Yes Then
                            Try
                                ftp.UploadFile(sSource, sDestination)
                            Catch ex As Exception
                                mm.Add(ex.Message)
                            End Try
                        Else
                            mm.Add(String.Format("{0} exists in the clipstore. It has not been re-transferred", sDestination))
                            bSuccess = False
                        End If
                    Case Else
                        mm.Add(String.Format("{0} exists in the clipstore. It has not been re-transferred", sDestination))
                        bSuccess = False
                End Select
            Else
                ftp.UploadFile(sSource, sDestination)
            End If

            Return bSuccess
        Else
            Return False
        End If

    End Function

    Private Sub Transferring(ByVal sender As Object, ByVal e As BytesTransferredEventArgs)

        If pbar.Maximum >= e.ByteCount Then
            pbar.Value = e.ByteCount
        End If

    End Sub
  
    Private Sub Starting_Upload(ByVal sender As Object, ByVal e As FTPFileTransferEventArgs)

        mm.Add(String.Format("Transferring file {0} to clipstore folder {1}", e.RemoteFileName, e.RemoteDirectory))
        pbar.Maximum = e.LocalFileSize
        pbar.Parent.Update()

    End Sub

    Public Sub Disconnect()

        If ftp.IsConnected Then
            Try
                ftp.Close()
            Catch ex As Exception
                mm.Add(ex.Message)
            End Try

        End If

    End Sub

    Private Function Create_Full_Folder(ByVal sFolder As String) As Boolean

        Dim iStartSearch As Integer
        Dim iPos As Integer
        Dim sFolder_Part As String

        If sFolder.StartsWith("/") Then
            iStartSearch = 1
        Else
            iStartSearch = 0
        End If

        iPos = sFolder.IndexOf("/", iStartSearch)
        Do Until iPos = -1
            sFolder_Part = sFolder.Substring(0, iPos)
            If Not ftp.DirectoryExists(sFolder_Part) Then
                Try
                    ftp.CreateDirectory(sFolder_Part)
                    mm.Add(String.Format("Folder created: {0}", sFolder_Part))
                Catch
                    Return False
                End Try
            End If
            iStartSearch = iPos + 1
            iPos = sFolder.IndexOf("/", iStartSearch)
        Loop

        Return True

    End Function

End Class
