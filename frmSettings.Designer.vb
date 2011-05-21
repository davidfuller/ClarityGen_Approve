<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.udJob_Load_Timeout = New System.Windows.Forms.NumericUpDown()
        Me.udField_Number = New System.Windows.Forms.NumericUpDown()
        Me.udChannel = New System.Windows.Forms.NumericUpDown()
        Me.udPage_Number = New System.Windows.Forms.NumericUpDown()
        Me.cmdBrowse_Emulated = New System.Windows.Forms.Button()
        Me.cmdClarityJob = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkHD = New System.Windows.Forms.CheckBox()
        Me.chkFeedback = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStill_Delay = New System.Windows.Forms.TextBox()
        Me.txtClip_Delay = New System.Windows.Forms.TextBox()
        Me.txtHD_Folder_Suffix = New System.Windows.Forms.TextBox()
        Me.txtHostName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClarityJob = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmulated_Clip_Path = New System.Windows.Forms.TextBox()
        Me.txtFeedbackPort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCommandPort = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkDelete_Temporary = New System.Windows.Forms.CheckBox()
        Me.cmdPackagePath_Browse = New System.Windows.Forms.Button()
        Me.txtExample = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtJob_Clips = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPackage_Suffix = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDate_Format = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPackage_Prefix = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPackage_Path = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.udStart_Page = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtData_Connection = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.txtFTP_Port = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtClipstore_Name = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtServer_Address = New System.Windows.Forms.TextBox()
        Me.txtUser_Name = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.cmdUnpackage_Path = New System.Windows.Forms.Button()
        Me.txtUnpackage_Package_Path = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.udPackage_Timeout = New System.Windows.Forms.NumericUpDown()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmdTest_Unpack_Clarity = New System.Windows.Forms.Button()
        Me.chkOpen_After_Unpackage = New System.Windows.Forms.CheckBox()
        Me.chkUnpack_UseFeedback = New System.Windows.Forms.CheckBox()
        Me.txtUnPack_HostName = New System.Windows.Forms.TextBox()
        Me.txtUnpack_FeedbackPort = New System.Windows.Forms.TextBox()
        Me.txtUnpack_CommandPort = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chkDelete_Temp_Clips = New System.Windows.Forms.CheckBox()
        Me.cmbOverwrite = New System.Windows.Forms.ComboBox()
        Me.cmdBrowse_Unpackage = New System.Windows.Forms.Button()
        Me.txtUn_Package_Folder = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdSave_Profile = New System.Windows.Forms.Button()
        Me.cmdLoad_Profile = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.chkUse_V7 = New System.Windows.Forms.CheckBox()
        Me.tabSettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.udJob_Load_Timeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udField_Number, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udPage_Number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.udStart_Page, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.udPackage_Timeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Connection"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(371, 355)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(452, 355)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Command Port"
        '
        'tabSettings
        '
        Me.tabSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSettings.Controls.Add(Me.TabPage1)
        Me.tabSettings.Controls.Add(Me.TabPage2)
        Me.tabSettings.Controls.Add(Me.TabPage3)
        Me.tabSettings.Controls.Add(Me.TabPage4)
        Me.tabSettings.Controls.Add(Me.TabPage5)
        Me.tabSettings.Location = New System.Drawing.Point(12, 12)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(519, 337)
        Me.tabSettings.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.udJob_Load_Timeout)
        Me.TabPage1.Controls.Add(Me.udField_Number)
        Me.TabPage1.Controls.Add(Me.udChannel)
        Me.TabPage1.Controls.Add(Me.udPage_Number)
        Me.TabPage1.Controls.Add(Me.cmdBrowse_Emulated)
        Me.TabPage1.Controls.Add(Me.cmdClarityJob)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.chkHD)
        Me.TabPage1.Controls.Add(Me.chkUse_V7)
        Me.TabPage1.Controls.Add(Me.chkFeedback)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtStill_Delay)
        Me.TabPage1.Controls.Add(Me.txtClip_Delay)
        Me.TabPage1.Controls.Add(Me.txtHD_Folder_Suffix)
        Me.TabPage1.Controls.Add(Me.txtHostName)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtClarityJob)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtEmulated_Clip_Path)
        Me.TabPage1.Controls.Add(Me.txtFeedbackPort)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtCommandPort)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(511, 311)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clarity Control"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'udJob_Load_Timeout
        '
        Me.udJob_Load_Timeout.Location = New System.Drawing.Point(117, 255)
        Me.udJob_Load_Timeout.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udJob_Load_Timeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udJob_Load_Timeout.Name = "udJob_Load_Timeout"
        Me.udJob_Load_Timeout.Size = New System.Drawing.Size(68, 20)
        Me.udJob_Load_Timeout.TabIndex = 8
        Me.udJob_Load_Timeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udField_Number
        '
        Me.udField_Number.Location = New System.Drawing.Point(117, 229)
        Me.udField_Number.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.udField_Number.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udField_Number.Name = "udField_Number"
        Me.udField_Number.Size = New System.Drawing.Size(68, 20)
        Me.udField_Number.TabIndex = 7
        Me.udField_Number.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udChannel
        '
        Me.udChannel.Location = New System.Drawing.Point(117, 203)
        Me.udChannel.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.udChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udChannel.Name = "udChannel"
        Me.udChannel.Size = New System.Drawing.Size(68, 20)
        Me.udChannel.TabIndex = 6
        Me.udChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udPage_Number
        '
        Me.udPage_Number.Location = New System.Drawing.Point(117, 177)
        Me.udPage_Number.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.udPage_Number.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udPage_Number.Name = "udPage_Number"
        Me.udPage_Number.Size = New System.Drawing.Size(68, 20)
        Me.udPage_Number.TabIndex = 5
        Me.udPage_Number.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmdBrowse_Emulated
        '
        Me.cmdBrowse_Emulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBrowse_Emulated.Location = New System.Drawing.Point(430, 149)
        Me.cmdBrowse_Emulated.Name = "cmdBrowse_Emulated"
        Me.cmdBrowse_Emulated.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse_Emulated.TabIndex = 4
        Me.cmdBrowse_Emulated.Text = "Browse..."
        Me.cmdBrowse_Emulated.UseVisualStyleBackColor = True
        '
        'cmdClarityJob
        '
        Me.cmdClarityJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClarityJob.Location = New System.Drawing.Point(430, 123)
        Me.cmdClarityJob.Name = "cmdClarityJob"
        Me.cmdClarityJob.Size = New System.Drawing.Size(75, 23)
        Me.cmdClarityJob.TabIndex = 4
        Me.cmdClarityJob.Text = "Browse..."
        Me.cmdClarityJob.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(430, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Test Clarity Connection"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkHD
        '
        Me.chkHD.AutoSize = True
        Me.chkHD.Checked = True
        Me.chkHD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHD.Location = New System.Drawing.Point(204, 178)
        Me.chkHD.Name = "chkHD"
        Me.chkHD.Size = New System.Drawing.Size(42, 17)
        Me.chkHD.TabIndex = 3
        Me.chkHD.Text = "HD"
        Me.chkHD.UseVisualStyleBackColor = True
        '
        'chkFeedback
        '
        Me.chkFeedback.AutoSize = True
        Me.chkFeedback.Checked = True
        Me.chkFeedback.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFeedback.Location = New System.Drawing.Point(22, 76)
        Me.chkFeedback.Name = "chkFeedback"
        Me.chkFeedback.Size = New System.Drawing.Size(96, 17)
        Me.chkFeedback.TabIndex = 3
        Me.chkFeedback.Text = "Use Feedback"
        Me.chkFeedback.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Job Load Timeout"
        '
        'txtStill_Delay
        '
        Me.txtStill_Delay.Location = New System.Drawing.Point(291, 252)
        Me.txtStill_Delay.Name = "txtStill_Delay"
        Me.txtStill_Delay.Size = New System.Drawing.Size(133, 20)
        Me.txtStill_Delay.TabIndex = 11
        Me.txtStill_Delay.Text = "05:00"
        '
        'txtClip_Delay
        '
        Me.txtClip_Delay.Location = New System.Drawing.Point(291, 226)
        Me.txtClip_Delay.Name = "txtClip_Delay"
        Me.txtClip_Delay.Size = New System.Drawing.Size(133, 20)
        Me.txtClip_Delay.TabIndex = 10
        Me.txtClip_Delay.Text = "00:01"
        '
        'txtHD_Folder_Suffix
        '
        Me.txtHD_Folder_Suffix.Location = New System.Drawing.Point(291, 200)
        Me.txtHD_Folder_Suffix.Name = "txtHD_Folder_Suffix"
        Me.txtHD_Folder_Suffix.Size = New System.Drawing.Size(133, 20)
        Me.txtHD_Folder_Suffix.TabIndex = 9
        Me.txtHD_Folder_Suffix.Text = "_HD"
        '
        'txtHostName
        '
        Me.txtHostName.Location = New System.Drawing.Point(117, 24)
        Me.txtHostName.Name = "txtHostName"
        Me.txtHostName.Size = New System.Drawing.Size(162, 20)
        Me.txtHostName.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Field Number"
        '
        'txtClarityJob
        '
        Me.txtClarityJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClarityJob.Location = New System.Drawing.Point(117, 125)
        Me.txtClarityJob.Name = "txtClarityJob"
        Me.txtClarityJob.Size = New System.Drawing.Size(307, 20)
        Me.txtClarityJob.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Channel"
        '
        'txtEmulated_Clip_Path
        '
        Me.txtEmulated_Clip_Path.Location = New System.Drawing.Point(117, 151)
        Me.txtEmulated_Clip_Path.Name = "txtEmulated_Clip_Path"
        Me.txtEmulated_Clip_Path.Size = New System.Drawing.Size(307, 20)
        Me.txtEmulated_Clip_Path.TabIndex = 2
        '
        'txtFeedbackPort
        '
        Me.txtFeedbackPort.Location = New System.Drawing.Point(117, 99)
        Me.txtFeedbackPort.Name = "txtFeedbackPort"
        Me.txtFeedbackPort.Size = New System.Drawing.Size(161, 20)
        Me.txtFeedbackPort.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Page Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Clarity Job"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(201, 255)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Still Page Delay"
        '
        'txtCommandPort
        '
        Me.txtCommandPort.Location = New System.Drawing.Point(117, 50)
        Me.txtCommandPort.Name = "txtCommandPort"
        Me.txtCommandPort.Size = New System.Drawing.Size(160, 20)
        Me.txtCommandPort.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(201, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Clip Page Delay"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(19, 154)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(96, 13)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "Emulated Clip Path"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Feedback Port"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(201, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "HD Folder Suffix"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkDelete_Temporary)
        Me.TabPage2.Controls.Add(Me.cmdPackagePath_Browse)
        Me.TabPage2.Controls.Add(Me.txtExample)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtJob_Clips)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.txtPackage_Suffix)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtDate_Format)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtPackage_Prefix)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtPackage_Path)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.udStart_Page)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(511, 311)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Packaging"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkDelete_Temporary
        '
        Me.chkDelete_Temporary.AutoSize = True
        Me.chkDelete_Temporary.Checked = True
        Me.chkDelete_Temporary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDelete_Temporary.Location = New System.Drawing.Point(9, 200)
        Me.chkDelete_Temporary.Name = "chkDelete_Temporary"
        Me.chkDelete_Temporary.Size = New System.Drawing.Size(174, 17)
        Me.chkDelete_Temporary.TabIndex = 11
        Me.chkDelete_Temporary.Text = "Delete Temporary Files after zip"
        Me.chkDelete_Temporary.UseVisualStyleBackColor = True
        '
        'cmdPackagePath_Browse
        '
        Me.cmdPackagePath_Browse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPackagePath_Browse.Location = New System.Drawing.Point(430, 44)
        Me.cmdPackagePath_Browse.Name = "cmdPackagePath_Browse"
        Me.cmdPackagePath_Browse.Size = New System.Drawing.Size(75, 23)
        Me.cmdPackagePath_Browse.TabIndex = 2
        Me.cmdPackagePath_Browse.Text = "Browse..."
        Me.cmdPackagePath_Browse.UseVisualStyleBackColor = True
        '
        'txtExample
        '
        Me.txtExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExample.Location = New System.Drawing.Point(109, 150)
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.Size = New System.Drawing.Size(335, 20)
        Me.txtExample.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 153)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Example"
        '
        'txtJob_Clips
        '
        Me.txtJob_Clips.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJob_Clips.Location = New System.Drawing.Point(109, 176)
        Me.txtJob_Clips.Name = "txtJob_Clips"
        Me.txtJob_Clips.Size = New System.Drawing.Size(128, 20)
        Me.txtJob_Clips.TabIndex = 5
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 179)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 10
        Me.Label27.Text = "Job Clips Subfolder"
        '
        'txtPackage_Suffix
        '
        Me.txtPackage_Suffix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPackage_Suffix.Location = New System.Drawing.Point(109, 124)
        Me.txtPackage_Suffix.Name = "txtPackage_Suffix"
        Me.txtPackage_Suffix.Size = New System.Drawing.Size(128, 20)
        Me.txtPackage_Suffix.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Package Suffix"
        '
        'txtDate_Format
        '
        Me.txtDate_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDate_Format.Location = New System.Drawing.Point(109, 98)
        Me.txtDate_Format.Name = "txtDate_Format"
        Me.txtDate_Format.Size = New System.Drawing.Size(128, 20)
        Me.txtDate_Format.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Date Format"
        '
        'txtPackage_Prefix
        '
        Me.txtPackage_Prefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPackage_Prefix.Location = New System.Drawing.Point(109, 72)
        Me.txtPackage_Prefix.Name = "txtPackage_Prefix"
        Me.txtPackage_Prefix.Size = New System.Drawing.Size(128, 20)
        Me.txtPackage_Prefix.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Package Prefix"
        '
        'txtPackage_Path
        '
        Me.txtPackage_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPackage_Path.Location = New System.Drawing.Point(109, 46)
        Me.txtPackage_Path.Name = "txtPackage_Path"
        Me.txtPackage_Path.Size = New System.Drawing.Size(308, 20)
        Me.txtPackage_Path.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Package Path"
        '
        'udStart_Page
        '
        Me.udStart_Page.Location = New System.Drawing.Point(109, 20)
        Me.udStart_Page.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.udStart_Page.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udStart_Page.Name = "udStart_Page"
        Me.udStart_Page.Size = New System.Drawing.Size(68, 20)
        Me.udStart_Page.TabIndex = 0
        Me.udStart_Page.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Start Page"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtData_Connection)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(511, 311)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtData_Connection
        '
        Me.txtData_Connection.Location = New System.Drawing.Point(129, 18)
        Me.txtData_Connection.Multiline = True
        Me.txtData_Connection.Name = "txtData_Connection"
        Me.txtData_Connection.Size = New System.Drawing.Size(376, 52)
        Me.txtData_Connection.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Data Connection String"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtPassword)
        Me.TabPage4.Controls.Add(Me.txtTimeout)
        Me.TabPage4.Controls.Add(Me.txtFTP_Port)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.txtClipstore_Name)
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.Label22)
        Me.TabPage4.Controls.Add(Me.txtServer_Address)
        Me.TabPage4.Controls.Add(Me.txtUser_Name)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(511, 311)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Clipstore FTP"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(98, 119)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(178, 20)
        Me.txtPassword.TabIndex = 5
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(98, 67)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(177, 20)
        Me.txtTimeout.TabIndex = 3
        '
        'txtFTP_Port
        '
        Me.txtFTP_Port.Location = New System.Drawing.Point(98, 41)
        Me.txtFTP_Port.Name = "txtFTP_Port"
        Me.txtFTP_Port.Size = New System.Drawing.Size(177, 20)
        Me.txtFTP_Port.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Timeout (ms)"
        '
        'txtClipstore_Name
        '
        Me.txtClipstore_Name.Location = New System.Drawing.Point(98, 145)
        Me.txtClipstore_Name.Name = "txtClipstore_Name"
        Me.txtClipstore_Name.Size = New System.Drawing.Size(177, 20)
        Me.txtClipstore_Name.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(7, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "FTP port"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 122)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Password"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 148)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Clipstore Name"
        '
        'txtServer_Address
        '
        Me.txtServer_Address.Location = New System.Drawing.Point(98, 15)
        Me.txtServer_Address.Name = "txtServer_Address"
        Me.txtServer_Address.Size = New System.Drawing.Size(178, 20)
        Me.txtServer_Address.TabIndex = 1
        '
        'txtUser_Name
        '
        Me.txtUser_Name.Location = New System.Drawing.Point(98, 93)
        Me.txtUser_Name.Name = "txtUser_Name"
        Me.txtUser_Name.Size = New System.Drawing.Size(177, 20)
        Me.txtUser_Name.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Server Address"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Username"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.cmdUnpackage_Path)
        Me.TabPage5.Controls.Add(Me.txtUnpackage_Package_Path)
        Me.TabPage5.Controls.Add(Me.Label34)
        Me.TabPage5.Controls.Add(Me.udPackage_Timeout)
        Me.TabPage5.Controls.Add(Me.Label32)
        Me.TabPage5.Controls.Add(Me.cmdTest_Unpack_Clarity)
        Me.TabPage5.Controls.Add(Me.chkOpen_After_Unpackage)
        Me.TabPage5.Controls.Add(Me.chkUnpack_UseFeedback)
        Me.TabPage5.Controls.Add(Me.txtUnPack_HostName)
        Me.TabPage5.Controls.Add(Me.txtUnpack_FeedbackPort)
        Me.TabPage5.Controls.Add(Me.txtUnpack_CommandPort)
        Me.TabPage5.Controls.Add(Me.Label29)
        Me.TabPage5.Controls.Add(Me.Label30)
        Me.TabPage5.Controls.Add(Me.Label31)
        Me.TabPage5.Controls.Add(Me.chkDelete_Temp_Clips)
        Me.TabPage5.Controls.Add(Me.cmbOverwrite)
        Me.TabPage5.Controls.Add(Me.cmdBrowse_Unpackage)
        Me.TabPage5.Controls.Add(Me.txtUn_Package_Folder)
        Me.TabPage5.Controls.Add(Me.Label33)
        Me.TabPage5.Controls.Add(Me.Label26)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(511, 311)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Un Packaging"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'cmdUnpackage_Path
        '
        Me.cmdUnpackage_Path.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUnpackage_Path.Location = New System.Drawing.Point(430, 229)
        Me.cmdUnpackage_Path.Name = "cmdUnpackage_Path"
        Me.cmdUnpackage_Path.Size = New System.Drawing.Size(75, 23)
        Me.cmdUnpackage_Path.TabIndex = 27
        Me.cmdUnpackage_Path.Text = "Browse..."
        Me.cmdUnpackage_Path.UseVisualStyleBackColor = True
        '
        'txtUnpackage_Package_Path
        '
        Me.txtUnpackage_Package_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnpackage_Package_Path.Location = New System.Drawing.Point(116, 231)
        Me.txtUnpackage_Package_Path.Name = "txtUnpackage_Package_Path"
        Me.txtUnpackage_Package_Path.Size = New System.Drawing.Size(308, 20)
        Me.txtUnpackage_Package_Path.TabIndex = 26
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(18, 234)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(75, 13)
        Me.Label34.TabIndex = 28
        Me.Label34.Text = "Package Path"
        '
        'udPackage_Timeout
        '
        Me.udPackage_Timeout.Location = New System.Drawing.Point(117, 202)
        Me.udPackage_Timeout.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udPackage_Timeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udPackage_Timeout.Name = "udPackage_Timeout"
        Me.udPackage_Timeout.Size = New System.Drawing.Size(68, 20)
        Me.udPackage_Timeout.TabIndex = 25
        Me.udPackage_Timeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(18, 204)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(92, 13)
        Me.Label32.TabIndex = 24
        Me.Label32.Text = "Job Load Timeout"
        '
        'cmdTest_Unpack_Clarity
        '
        Me.cmdTest_Unpack_Clarity.Location = New System.Drawing.Point(430, 104)
        Me.cmdTest_Unpack_Clarity.Name = "cmdTest_Unpack_Clarity"
        Me.cmdTest_Unpack_Clarity.Size = New System.Drawing.Size(75, 23)
        Me.cmdTest_Unpack_Clarity.TabIndex = 23
        Me.cmdTest_Unpack_Clarity.Text = "Test Clarity Connection"
        Me.cmdTest_Unpack_Clarity.UseVisualStyleBackColor = True
        '
        'chkOpen_After_Unpackage
        '
        Me.chkOpen_After_Unpackage.AutoSize = True
        Me.chkOpen_After_Unpackage.Checked = True
        Me.chkOpen_After_Unpackage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpen_After_Unpackage.Location = New System.Drawing.Point(22, 265)
        Me.chkOpen_After_Unpackage.Name = "chkOpen_After_Unpackage"
        Me.chkOpen_After_Unpackage.Size = New System.Drawing.Size(164, 17)
        Me.chkOpen_After_Unpackage.TabIndex = 22
        Me.chkOpen_After_Unpackage.Text = "Open Job After Unpackaging"
        Me.chkOpen_After_Unpackage.UseVisualStyleBackColor = True
        '
        'chkUnpack_UseFeedback
        '
        Me.chkUnpack_UseFeedback.AutoSize = True
        Me.chkUnpack_UseFeedback.Checked = True
        Me.chkUnpack_UseFeedback.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnpack_UseFeedback.Location = New System.Drawing.Point(22, 153)
        Me.chkUnpack_UseFeedback.Name = "chkUnpack_UseFeedback"
        Me.chkUnpack_UseFeedback.Size = New System.Drawing.Size(96, 17)
        Me.chkUnpack_UseFeedback.TabIndex = 22
        Me.chkUnpack_UseFeedback.Text = "Use Feedback"
        Me.chkUnpack_UseFeedback.UseVisualStyleBackColor = True
        '
        'txtUnPack_HostName
        '
        Me.txtUnPack_HostName.Location = New System.Drawing.Point(117, 101)
        Me.txtUnPack_HostName.Name = "txtUnPack_HostName"
        Me.txtUnPack_HostName.Size = New System.Drawing.Size(162, 20)
        Me.txtUnPack_HostName.TabIndex = 16
        '
        'txtUnpack_FeedbackPort
        '
        Me.txtUnpack_FeedbackPort.Location = New System.Drawing.Point(117, 176)
        Me.txtUnpack_FeedbackPort.Name = "txtUnpack_FeedbackPort"
        Me.txtUnpack_FeedbackPort.Size = New System.Drawing.Size(161, 20)
        Me.txtUnpack_FeedbackPort.TabIndex = 20
        '
        'txtUnpack_CommandPort
        '
        Me.txtUnpack_CommandPort.Location = New System.Drawing.Point(117, 127)
        Me.txtUnpack_CommandPort.Name = "txtUnpack_CommandPort"
        Me.txtUnpack_CommandPort.Size = New System.Drawing.Size(160, 20)
        Me.txtUnpack_CommandPort.TabIndex = 17
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(19, 179)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(77, 13)
        Me.Label29.TabIndex = 19
        Me.Label29.Text = "Feedback Port"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(18, 104)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 13)
        Me.Label30.TabIndex = 18
        Me.Label30.Text = "Connection"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(18, 130)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(76, 13)
        Me.Label31.TabIndex = 21
        Me.Label31.Text = "Command Port"
        '
        'chkDelete_Temp_Clips
        '
        Me.chkDelete_Temp_Clips.AutoSize = True
        Me.chkDelete_Temp_Clips.Checked = True
        Me.chkDelete_Temp_Clips.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDelete_Temp_Clips.Location = New System.Drawing.Point(21, 59)
        Me.chkDelete_Temp_Clips.Name = "chkDelete_Temp_Clips"
        Me.chkDelete_Temp_Clips.Size = New System.Drawing.Size(228, 17)
        Me.chkDelete_Temp_Clips.TabIndex = 15
        Me.chkDelete_Temp_Clips.Text = "Delete Temporary Clarity Clips after transfer"
        Me.chkDelete_Temp_Clips.UseVisualStyleBackColor = True
        '
        'cmbOverwrite
        '
        Me.cmbOverwrite.FormattingEnabled = True
        Me.cmbOverwrite.Items.AddRange(New Object() {"Overwrite", "Ask", "Skip"})
        Me.cmbOverwrite.Location = New System.Drawing.Point(116, 32)
        Me.cmbOverwrite.Name = "cmbOverwrite"
        Me.cmbOverwrite.Size = New System.Drawing.Size(121, 21)
        Me.cmbOverwrite.TabIndex = 14
        '
        'cmdBrowse_Unpackage
        '
        Me.cmdBrowse_Unpackage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBrowse_Unpackage.Location = New System.Drawing.Point(430, 4)
        Me.cmdBrowse_Unpackage.Name = "cmdBrowse_Unpackage"
        Me.cmdBrowse_Unpackage.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse_Unpackage.TabIndex = 12
        Me.cmdBrowse_Unpackage.Text = "Browse..."
        Me.cmdBrowse_Unpackage.UseVisualStyleBackColor = True
        '
        'txtUn_Package_Folder
        '
        Me.txtUn_Package_Folder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUn_Package_Folder.Location = New System.Drawing.Point(116, 6)
        Me.txtUn_Package_Folder.Name = "txtUn_Package_Folder"
        Me.txtUn_Package_Folder.Size = New System.Drawing.Size(308, 20)
        Me.txtUn_Package_Folder.TabIndex = 11
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(18, 79)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(94, 13)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "Unpackage Clarity"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(18, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 13)
        Me.Label26.TabIndex = 13
        Me.Label26.Text = "Overwrite Mode"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(18, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(92, 13)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "Un Package Path"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cmdSave_Profile
        '
        Me.cmdSave_Profile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave_Profile.Location = New System.Drawing.Point(93, 355)
        Me.cmdSave_Profile.Name = "cmdSave_Profile"
        Me.cmdSave_Profile.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave_Profile.TabIndex = 3
        Me.cmdSave_Profile.Text = "Save Profile"
        Me.cmdSave_Profile.UseVisualStyleBackColor = True
        '
        'cmdLoad_Profile
        '
        Me.cmdLoad_Profile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad_Profile.Location = New System.Drawing.Point(12, 355)
        Me.cmdLoad_Profile.Name = "cmdLoad_Profile"
        Me.cmdLoad_Profile.Size = New System.Drawing.Size(75, 23)
        Me.cmdLoad_Profile.TabIndex = 2
        Me.cmdLoad_Profile.Text = "Load Profile"
        Me.cmdLoad_Profile.UseVisualStyleBackColor = True
        '
        'chkUse_V7
        '
        Me.chkUse_V7.AutoSize = True
        Me.chkUse_V7.Checked = True
        Me.chkUse_V7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUse_V7.Location = New System.Drawing.Point(22, 281)
        Me.chkUse_V7.Name = "chkUse_V7"
        Me.chkUse_V7.Size = New System.Drawing.Size(116, 17)
        Me.chkUse_V7.TabIndex = 3
        Me.chkUse_V7.Text = "Use V7 Commands"
        Me.chkUse_V7.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 390)
        Me.Controls.Add(Me.cmdSave_Profile)
        Me.Controls.Add(Me.cmdLoad_Profile)
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.tabSettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.udJob_Load_Timeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udField_Number, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udPage_Number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.udStart_Page, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.udPackage_Timeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtHostName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtCommandPort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkFeedback As System.Windows.Forms.CheckBox
    Friend WithEvents txtFeedbackPort As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdClarityJob As System.Windows.Forms.Button
    Friend WithEvents txtClarityJob As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents udPage_Number As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents udField_Number As System.Windows.Forms.NumericUpDown
    Friend WithEvents udChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents udJob_Load_Timeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkHD As System.Windows.Forms.CheckBox
    Friend WithEvents txtHD_Folder_Suffix As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtClip_Delay As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStill_Delay As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtData_Connection As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtServer_Address As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtClipstore_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtFTP_Port As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTimeout As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkDelete_Temporary As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPackagePath_Browse As System.Windows.Forms.Button
    Friend WithEvents txtExample As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPackage_Suffix As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDate_Format As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPackage_Prefix As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPackage_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents udStart_Page As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdBrowse_Unpackage As System.Windows.Forms.Button
    Friend WithEvents txtUn_Package_Folder As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbOverwrite As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtEmulated_Clip_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtJob_Clips As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkDelete_Temp_Clips As System.Windows.Forms.CheckBox
    Friend WithEvents cmdBrowse_Emulated As System.Windows.Forms.Button
    Friend WithEvents cmdTest_Unpack_Clarity As System.Windows.Forms.Button
    Friend WithEvents chkUnpack_UseFeedback As System.Windows.Forms.CheckBox
    Friend WithEvents txtUnPack_HostName As System.Windows.Forms.TextBox
    Friend WithEvents txtUnpack_FeedbackPort As System.Windows.Forms.TextBox
    Friend WithEvents txtUnpack_CommandPort As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents udPackage_Timeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkOpen_After_Unpackage As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSave_Profile As System.Windows.Forms.Button
    Friend WithEvents cmdLoad_Profile As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdUnpackage_Path As System.Windows.Forms.Button
    Friend WithEvents txtUnpackage_Package_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents chkUse_V7 As System.Windows.Forms.CheckBox

End Class
