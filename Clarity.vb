Imports CLARITYCOMLib
Public Class Clarity

    Private objClarity As ClarityXML10
    Private WithEvents objFeedback As ClarityXMLFeedback10
    Private bFeedback_Connected As Boolean
    Private objSettings As Settings_MuVi2
    Private iReturn As Integer
    Private bJob_loaded As Boolean
    Private sJob_Name As String
    Private bFields_Updated As Boolean
    Private iUpdated_Page_Number As Integer
    Private cStatus As ChannelStatus
    Private mml As mMessage
    Private sMessages() As String


    Public Sub New(ByVal mMess As mMessage)

        objClarity = New ClarityXML10
        objFeedback = New ClarityXMLFeedback10
        objSettings = New Settings_MuVi2


        Reset_Event_Fields()
        cStatus = CLARITYCOMLib.ChannelStatus.Idle

        If mMess Is Nothing Then
            mml = mm
        Else
            mml = mMess
        End If

    End Sub


    Friend Overloads Function Connect() As Boolean

        Return Connect(objSettings.Host_Name(sSettings_File_Name), objSettings.Command_Port(sSettings_File_Name))
        
    End Function

    Friend Overloads Function Connect(ByVal bUn_Package_Machine As Boolean)

        If bUn_Package_Machine Then
            Return Connect(objSettings.Unpackage_Host_Name(sSettings_File_Name), objSettings.Unpackage_Command_Port(sSettings_File_Name))
        Else
            Return Connect()
        End If

    End Function
    Friend Overloads Function Connect(ByVal sHostName As String, ByVal sPortNumber As String) As Boolean

        objClarity.Hostname() = sHostName
        objClarity.PortNumber = sPortNumber
        iReturn = objClarity.Connect()

        If iReturn = 0 Then
            Message_Add(String.Concat("Clarity Connected at hostname: ", objClarity.Hostname.ToString, " - Port: ", objClarity.PortNumber.ToString))
        Else
            Message_Add(String.Concat("Cannot connect to Clarity at hostname: ", objClarity.Hostname.ToString, " - Port: ", objClarity.PortNumber.ToString))
        End If

        Return iReturn = 0

    End Function



    Friend Overloads Function Connect_Feedback() As Boolean


        Return Connect_Feedback(objSettings.Host_Name(sSettings_File_Name), objSettings.Feedback_Port(sSettings_File_Name), objSettings.Use_Feedback(sSettings_File_Name))


    End Function


    Friend Overloads Function Connect_Feedback(ByVal bUn_Package_Machine As Boolean) As Boolean

        If bUn_Package_Machine Then
            Return Connect_Feedback(objSettings.Unpackage_Host_Name(sSettings_File_Name), objSettings.Unpackage_Feedback_Port(sSettings_File_Name), objSettings.Unpackage_Use_Feedback(sSettings_File_Name))
        Else
            Return Connect_Feedback()
        End If

    End Function

    Friend Overloads Function Connect_Feedback(ByVal sHostName As String, ByVal sPortNumber As String, ByVal bUseFeedback As Boolean) As Boolean

        If bUseFeedback Then
            objFeedback.Hostname() = sHostName
            objFeedback.PortNumber = sPortNumber
            iReturn = objFeedback.Connect()

            If iReturn = 0 Then
                sMessages = Nothing
                bFeedback_Connected = objFeedback.Connected
                If bFeedback_Connected Then
                    objFeedback.AddAllFeedbackTypeSelection(0)
                    mml.Add(String.Concat("Feedback connected. Port Number: ", objFeedback.PortNumber.ToString))
                Else
                    mml.Add("Feedback not connected")
                    mml.Add("Operation will continue without feedback.")
                    mml.Add("If you wish to use feedback make sure it is enabled in the XML Socket Server options")
                End If
            Else
                bFeedback_Connected = False
            End If
        Else
            bFeedback_Connected = False
        End If

        Return iReturn = 0

    End Function
    Friend Function Disconnect() As Boolean

        Dim iReturn_Feedback As Integer

        Message_Add("Disconnecting")
        If objClarity.Connected Then
            iReturn = objClarity.Disconnect()
        End If

        If objFeedback.Connected Then
            iReturn_Feedback = objFeedback.Disconnect
        End If

        If iReturn = 0 And iReturn_Feedback = 0 Then
            Message_Add("Clarity Disconnected")
            Reset_Event_Fields()
        End If

        Return iReturn = 0 And iReturn_Feedback = 0

    End Function

    Friend Overloads Function Is_Job_Loaded(ByVal sFilename As String) As Boolean

        Dim sPath As String
        Dim sName As String
        Dim iNum As Integer
        Dim cMode As JobPageMode
        Dim bConnected As Boolean
        Dim sCurrent As String


        sPath = ""
        sName = ""
        iNum = 0
        cMode = JobPageMode.JobModeInternalTimecode

        iReturn = objClarity.AskJobInfo(sPath, sName, iNum, cMode)
        If iReturn = 0 Then
            If sPath <> "" And sName <> "" Then
                sCurrent = String.Concat(sPath, "\", sName)
            Else
                sCurrent = String.Concat(sPath, sName)
            End If

            bConnected = sCurrent = sFilename

            If bConnected Then
                mml.Add(String.Concat("Job already loaded: ", sFilename))
            Else
                mml.Add(String.Concat("Job currently loaded: ", sCurrent))
            End If

            Return bConnected
        ElseIf iReturn = 1006 Then
            mml.Add("No job currently loaded")
            Return False
        Else
            mml.Add(String.Concat("Issue getting job information from Clarity. Error number: ", iReturn))
            Return False
        End If

    End Function

    Friend Overloads Function Is_Job_Loaded() As Boolean
        Dim sFilename As String

        sFilename = objSettings.Clarity_Job_Filename(sSettings_File_Name)

        Return Is_Job_Loaded(sFilename)

    End Function

    Friend Overloads Function Load_Job() As Boolean

        Return Load_Job(objSettings.Clarity_Job_Filename(sSettings_File_Name))
        
    End Function

    Friend Overloads Function Load_Job(ByVal sJobName As String) As Boolean


        bJob_loaded = False

        iReturn = objClarity.LoadJob(sJobName, "")

        If iReturn = 0 Then
            mml.Add(String.Concat("Job loading: ", sJobName))
        Else
            mml.Add(String.Concat("Issue loading job. Error number: ", iReturn))
        End If

        Return iReturn = 0

    End Function

    Friend Property Feedback As Boolean
        Get
            Return bFeedback_Connected
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Private Sub objFeedback_ChannelStatusChanged(ByVal ChannelNum As Integer, ByVal ChannelStatus As CLARITYCOMLib.ChannelStatus) Handles objFeedback.ChannelStatusChanged

        If ChannelNum = Integer.Parse(objSettings.Channel_Number(sSettings_File_Name)) Then
            cStatus = ChannelStatus
            Debug.Print(String.Format("Clarity Event: {0}", cStatus.ToString))
            Add_Message(String.Format("Clarity Event: {0}", cStatus.ToString))
        End If

    End Sub
    Private Sub Add_Message(ByVal sText As String)

        Dim lNum As Long

        If sMessages Is Nothing Then
            lNum = 0
        Else
            lNum = sMessages.Length
        End If


        ReDim Preserve sMessages(lNum)
        sMessages(lNum) = sText

    End Sub


    Private Sub objFeedback_FieldUpdates(ByVal PageNum As Integer, ByRef FieldIDs As System.Array, ByRef FieldStatusInfo As System.Array) Handles objFeedback.FieldUpdates

        bFields_Updated = True
        iUpdated_Page_Number = PageNum

    End Sub

    Private Sub objFeedback_JobLoaded(ByVal JobPath As String, ByVal JobName As String) Handles objFeedback.JobLoaded

        bJob_Loaded = True
        sJob_Name = String.Concat(JobPath, "\", JobName)

    End Sub
    Friend Property Fields_Updated As Boolean
        Get
            Return bFields_Updated
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
   
    Friend Property Loaded As Boolean
        Get
            Return bJob_loaded
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Friend Property Loaded_Job As String
        Get
            Return sJob_Name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Friend Overloads Function Update_Page(ByVal sContent As String) As Boolean

        Dim iPageNo As Integer
        

        iPageNo = objSettings.Page_Number(sSettings_File_Name)
        
        Return Update_Page(iPageNo, sContent)


    End Function




    Friend Overloads Function Update_Page(iPageNo As Integer, ByVal sContent As String) As Boolean

        Dim iFieldNo() As Integer
        Dim sField_Data() As String
        Dim iNum As Integer



        If objSettings.Alpha_Enabled_Job(sSettings_File_Name) Then
            iNum = 2
            ReDim iFieldNo(1)
            ReDim sField_Data(1)
            iFieldNo(0) = objSettings.Field_Number(sSettings_File_Name)
            iFieldNo(1) = objSettings.Still_Field_Number(sSettings_File_Name)
            Select Case File_Type(sContent)
                Case Media_Type.Still
                    sField_Data(0) = objSettings.Empty_Clip(sSettings_File_Name)
                    sField_Data(1) = Clip_Filename(sContent)
                Case Else
                    sField_Data(0) = Clip_Filename(sContent)
                    sField_Data(1) = objSettings.Empty_Still(sSettings_File_Name)
            End Select
        Else
            ReDim iFieldNo(0)
            ReDim sField_Data(0)
            iNum = 1
            iFieldNo(0) = objSettings.Field_Number(sSettings_File_Name)
            sField_Data(0) = sContent

        End If

        Return Update_Page(iPageNo, sField_Data, iFieldNo, iNum)


    End Function
    Private Function Clip_Filename(sFilename As String) As String

        If objSettings.Alpha_Enabled_Job(sSettings_File_Name) Then
            Return sFilename.Replace("VID:", "").Replace("PIC:", "")
        Else
            Return sFilename
        End If

    End Function
    Friend Overloads Function Update_Page(ByVal iPageNo As Integer, ByVal sContent() As String, iFieldNo() As Integer, iNum As Integer) As Boolean

        Dim objFields As New ClarityFields10
        Dim i As Integer
        Dim sMessage As String
        Dim bDo_Message As Boolean

        bFields_Updated = False
        objFields.DeleteAllFields()
        For i = 0 To iNum - 1
            objFields.Add(iFieldNo(i), Replace_Clipstore_with_Emul(sContent(i)))
        Next

        iReturn = objClarity.UpdateField(iPageNo, objFields, True)

        bDo_Message = False
        sMessage = String.Concat("Possible issue with:", Environment.NewLine)
        For i = 0 To iNum - 1
            If iReturn = 0 Then
                mml.Add(String.Concat("Page: ", iPageNo, " Field: ", iFieldNo(i), " updated with: ", sContent(i)))
            Else
                bDo_Message = True
                mml.Add(String.Concat("Issue updating page: ", iPageNo, " Field: ", iFieldNo(i), " with: ", sContent(i)))
                sMessage = String.Concat(sMessage, "Page: ", iPageNo, " Field: ", iFieldNo(i), " with: ", sContent(i), Environment.NewLine)
            End If
        Next
        If bDo_Message Then
            MessageBox.Show(sMessage)
        End If
        Return iReturn = 0

    End Function

    Friend Overloads Function Cue_Page() As Boolean

        Return Cue_Page(objSettings.Page_Number(sSettings_File_Name))

    End Function

    Friend Overloads Function Cue_Page(ByVal iPageNo As Integer) As Boolean

        iReturn = objClarity.SelectPage(objSettings.Channel_Number(sSettings_File_Name), iPageNo)

        If iReturn = 0 Then
            mml.Add(String.Concat("Page: ", iPageNo, " is cued"))
        Else
            mml.Add(String.Concat("Issue cueing page: ", iPageNo))
        End If

        Return iReturn = 0
    End Function
    Friend Function Take() As Boolean

        iReturn = objClarity.TransferPage(objSettings.Channel_Number(sSettings_File_Name))

        If iReturn = 0 Then
            mml.Add(String.Concat("TAKE Channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        Else
            mml.Add(String.Concat("Issue taking channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        End If

        Return iReturn = 0

    End Function

    Friend Function Output_Black() As Boolean


        iReturn = objClarity.OutputBlack(objSettings.Channel_Number(sSettings_File_Name))

        If iReturn = 0 Then
            mml.Add(String.Concat("Black output on channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        Else
            mml.Add(String.Concat("Issue with black output on channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        End If

        Return iReturn = 0

    End Function
    Friend Function Stop_Playout() As Boolean

        iReturn = objClarity.StopPage(objSettings.Channel_Number(sSettings_File_Name))
       
        If iReturn = 0 Then
            mml.Add(String.Concat("Playout stopped on channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        Else
            mml.Add(String.Concat("Issue stopping playout channel: ", objSettings.Channel_Number(sSettings_File_Name)))
        End If

        Return iReturn = 0

    End Function

    Friend Function Take_Offline() As Boolean

        iReturn = objClarity.SaveJob
       
        Return iReturn = 0

    End Function

    Friend Function Save_Job(Optional ByVal sFilename As String = "") As Boolean

        iReturn = objClarity.SaveJob(sFilename)

        If iReturn = 0 Then
            mml.Add(String.Concat("Job Saved"))
        Else
            mml.Add(String.Concat("Issue saving job"))
        End If

        Return iReturn = 0
    End Function

    Friend Overloads Function Job_Load_Wait(ByVal pbar As ProgressBar) As Boolean

        Return Job_Load_Wait(pbar, objSettings.Clarity_Job_Filename(sSettings_File_Name), objSettings.Job_Load_Timeout(sSettings_File_Name))

    End Function


    Friend Overloads Function Job_Load_Wait(ByVal pbar As ProgressBar, ByVal sJobName As String, ByVal iTimeout As Integer) As Boolean

        Dim objEvent As New Clarity_Event_Vars

        objEvent.ID = CLE_JOB_LOAD
        objEvent.iTimeout = iTimeout
        objEvent.sPre_Message = "Waiting for job to load"
        objEvent.sSuccess_Message = "Job loaded in "
        objEvent.sFailure_Message = "Job not loaded in timeout period: "

        objEvent.sTest = sJobName

        Return Generic_Wait(pbar, objEvent)

    End Function

    Friend Function Update_Field_Wait(ByVal pbar As ProgressBar) As Boolean


        Dim objEvent As New Clarity_Event_Vars

        objEvent.ID = CLE_FIELD_UPDATES
        objEvent.iTimeout = objSettings.Job_Load_Timeout(sSettings_File_Name)
        objEvent.sPre_Message = "Waiting for fields to update"
        objEvent.sSuccess_Message = "Fields updated in "
        objEvent.sFailure_Message = "Fields not updated in timeout period: "

        objEvent.sTest = objSettings.Page_Number(sSettings_File_Name).ToString

        Return Generic_Wait(pbar, objEvent)

    End Function


    Private Function Generic_Wait(ByVal pbar As ProgressBar, ByVal objEvent As Clarity_Event_Vars) As Boolean

        Dim bTimeout As Boolean
        Dim dtStart_Pause As Date
        Dim dtEnd_Pause As Date
        Dim bTest As Boolean

        If objEvent.iTimeout > 0 Then
            pbar.Minimum = 0
            pbar.Maximum = objEvent.iTimeout
            mml.Add(objEvent.sPre_Message)
            bTimeout = True

            dtStart_Pause = Now()
            dtEnd_Pause = dtStart_Pause.AddSeconds(objEvent.iTimeout)
            Do While Now < dtEnd_Pause
                System.Threading.Thread.Sleep(100)
                pbar.Value = Now.Subtract(dtStart_Pause).Seconds
                Application.DoEvents()
                Select Case objEvent.ID
                    Case CLE_JOB_LOAD
                        bTest = Loaded And (Loaded_Job = objEvent.sTest)
                    Case CLE_FIELD_UPDATES
                        bTest = Fields_Updated And (iUpdated_Page_Number = Integer.Parse(objEvent.sTest))
                End Select
                If bTest Then
                    bTimeout = False
                    mml.Add(String.Concat(objEvent.sSuccess_Message, Now.Subtract(dtStart_Pause).Seconds.ToString, " seconds"))
                    Exit Do
                End If
            Loop
        End If
        pbar.Value = 0
        pbar.Maximum = 1

        If bTimeout Then
            mml.Add(String.Concat(objEvent.sFailure_Message, objEvent.iTimeout.ToString, " seconds"))
        End If

        Return Not bTimeout

    End Function

    Friend Function Is_Status_Idle() As Boolean

        Return cStatus = ChannelStatus.Idle

    End Function
    Friend Function Is_Status_Offline() As Boolean

        Return cStatus = ChannelStatus.Offline

    End Function

    Private Sub Reset_Event_Fields()

        bJob_loaded = False
        sJob_Name = ""
        bFields_Updated = False
        iUpdated_Page_Number = 0

    End Sub

    Friend Function Set_Delay(ByVal iPage_Number As Integer, ByVal bPageWait As Boolean, ByVal sDelay As String) As Boolean

        Dim Wait_Mode As PageWaitMode
        Dim sMessage As String

        If bPageWait Then
            Wait_Mode = PageWaitMode.PageWait
            sMessage = String.Concat("Page No: ", iPage_Number.ToString, " set to wait")
        Else
            Wait_Mode = PageWaitMode.PageNoWait
            sMessage = String.Concat("Page No: ", iPage_Number.ToString, " set to delay of ", sDelay)
        End If

        iReturn = objClarity.SetPageTrigger(iPage_Number, Wait_Mode, sDelay)

        If iReturn = 0 Then
            mml.Add(sMessage)
        Else
            mml.Add(String.Concat("Issue setting page trigger for page: ", iPage_Number.ToString))
        End If

        Return iReturn = 0

    End Function

    Public Function Create_Page(ByVal iDestination_Page_No As Integer) As Boolean

        Dim objFields As New ClarityFields10

        iReturn = objClarity.CreatePageFromTemplate(iDestination_Page_No, objSettings.Page_Number(sSettings_File_Name), objFields, True)

        If iReturn = 0 Then
            mml.Add(String.Concat("Page: ", iDestination_Page_No.ToString, " created"))
        Else
            mml.Add(String.Concat("Page: ", iDestination_Page_No.ToString, " not created"))
        End If

        Return iReturn = 0

    End Function

    Public Function Send_Heartbeat(ByVal iTimeout As Integer) As Boolean


        Dim dtStart As Date
        Dim iSeconds_Taken As Integer


        iReturn = -1
        dtStart = Date.Now

        Do Until iSeconds_Taken > iTimeout Or iReturn = 0
            iReturn = objClarity.Heartbeat()
            iSeconds_Taken = CInt(Date.Now.Subtract(dtStart).TotalSeconds)
            System.Threading.Thread.Sleep(1000)
        Loop

        If iReturn = 0 Then
            mml.Add("Clarity Heartbeat OK")
        Else
            mml.Add("Issue with Clarity Heartbeat")
        End If

        Return iReturn = 0

    End Function

    Private Function Replace_Clipstore_with_Emul(ByVal sFilename As String) As String

        Dim iPos As Integer
        If sFilename.StartsWith("VID:", StringComparison.CurrentCultureIgnoreCase) Then
            iPos = sFilename.IndexOf("/")
            If iPos > -1 Then
                Return String.Concat("VID:Emul", sFilename.Substring(iPos))
            Else
                Return sFilename
            End If
        Else
            Return sFilename
        End If

    End Function

    Friend Function Complete_Connect() As Boolean

        If Connect(True) Then
            If Connect_Feedback(True) Then
                Return Send_Heartbeat(objSettings.Unpackage_Job_Load_Timeout(sSettings_File_Name))
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Friend Function Messages() As String()

        Dim sTemp() As String

        sTemp = sMessages
        sMessages = Nothing

        Return sTemp

    End Function

    Friend Sub Message_Add(sMessage As String)

        If IsNothing(mml) Then
            MessageBox.Show(sMessage)
        Else
            mml.Add(sMessage)
        End If
    End Sub

End Class
Public Class Clarity_Event_Vars
    Public sPre_Message As String
    Public sSuccess_Message As String
    Public sFailure_Message As String
    Public ID As Integer
    Public sTest As String
    Public iTimeout As Integer
End Class
