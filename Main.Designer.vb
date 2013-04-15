<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstMessage = New System.Windows.Forms.ListBox()
        Me.cmdShow = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtClip_Filename = New System.Windows.Forms.TextBox()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.Gemini_MediaDataGridView = New System.Windows.Forms.DataGridView()
        Me.Package = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Packaged = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Package_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Package_Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Packaged_SD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Package_Date_SD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Package_Filename_SD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Archive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Restore_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Missing = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Archive_SD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Archived_SD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Archived_Date_SD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Restore_Date_SD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Missing_SD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Use_USA_Menu_BG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dtDelivery = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPackage = New System.Windows.Forms.Button()
        Me.FtpConnection1 = New EnterpriseDT.Net.Ftp.FTPConnection(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdUnpackage = New System.Windows.Forms.Button()
        Me.tmClarityEventMessage = New System.Windows.Forms.Timer(Me.components)
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.cmbView = New System.Windows.Forms.ComboBox()
        Me.cmdArchive = New System.Windows.Forms.Button()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cmdRestore = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmbHD = New System.Windows.Forms.ComboBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.First_Use = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delivery_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Archived = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Archived_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gemini_MediaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Mm_phase_5DataSet = New CGA.mm_phase_5DataSet()
        Me.Gemini_MediaTableAdapter = New CGA.mm_phase_5DataSetTableAdapters.Gemini_MediaTableAdapter()
        Me.TableAdapterManager = New CGA.mm_phase_5DataSetTableAdapters.TableAdapterManager()
        Me.Gemini_Media_LocationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Gemini_Media_LocationsTableAdapter = New CGA.mm_phase_5DataSetTableAdapters.Gemini_Media_LocationsTableAdapter()
        Me.BindingSource_Clip_History = New System.Windows.Forms.BindingSource(Me.components)
        Me.Clip_HistoryTableAdapter = New CGA.mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Gemini_MediaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gemini_MediaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mm_phase_5DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gemini_Media_LocationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_Clip_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1132, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToExcelToolStripMenuItem, Me.SaveDataToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveToExcelToolStripMenuItem
        '
        Me.SaveToExcelToolStripMenuItem.Name = "SaveToExcelToolStripMenuItem"
        Me.SaveToExcelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToExcelToolStripMenuItem.Text = "Save to Excel"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ArchivingToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'CustomizeToolStripMenuItem
        '
        Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
        Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.CustomizeToolStripMenuItem.Text = "&Unpackage"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.OptionsToolStripMenuItem.Text = "&Settings"
        '
        'ArchivingToolStripMenuItem
        '
        Me.ArchivingToolStripMenuItem.Name = "ArchivingToolStripMenuItem"
        Me.ArchivingToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ArchivingToolStripMenuItem.Text = "Archiving"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'lstMessage
        '
        Me.lstMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMessage.FormattingEnabled = True
        Me.lstMessage.Location = New System.Drawing.Point(12, 419)
        Me.lstMessage.Name = "lstMessage"
        Me.lstMessage.Size = New System.Drawing.Size(1100, 121)
        Me.lstMessage.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShow.Location = New System.Drawing.Point(956, 352)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 23)
        Me.cmdShow.TabIndex = 2
        Me.cmdShow.Text = "Show"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 380)
        Me.ProgressBar1.Maximum = 1
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(857, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'txtClip_Filename
        '
        Me.txtClip_Filename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClip_Filename.Location = New System.Drawing.Point(12, 354)
        Me.txtClip_Filename.Name = "txtClip_Filename"
        Me.txtClip_Filename.Size = New System.Drawing.Size(938, 20)
        Me.txtClip_Filename.TabIndex = 4
        Me.txtClip_Filename.Text = "VID:Clip/Auto/Five/Promo_HD/1113_FIVE_CSI_CRIME_SCE"
        '
        'cmdStop
        '
        Me.cmdStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdStop.Location = New System.Drawing.Point(1037, 352)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop.TabIndex = 2
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(12, 546)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Gemini_MediaDataGridView
        '
        Me.Gemini_MediaDataGridView.AllowUserToAddRows = False
        Me.Gemini_MediaDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Gemini_MediaDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Gemini_MediaDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gemini_MediaDataGridView.AutoGenerateColumns = False
        Me.Gemini_MediaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gemini_MediaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DataGridViewTextBoxColumn2, Me.Title, Me.Filename, Me.Location_ID, Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewCheckBoxColumn6, Me.First_Use, Me.DataGridViewTextBoxColumn8, Me.DataGridViewCheckBoxColumn7, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.Delivery_Date, Me.Package, Me.Packaged, Me.Package_Date, Me.Package_Filename, Me.Packaged_SD, Me.Package_Date_SD, Me.Package_Filename_SD, Me.Archive, Me.Archived, Me.Archived_Date, Me.Restore_Date, Me.Missing, Me.Archive_SD, Me.Archived_SD, Me.Archived_Date_SD, Me.Restore_Date_SD, Me.Missing_SD, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewCheckBoxColumn8, Me.DataGridViewTextBoxColumn28, Me.Use_USA_Menu_BG})
        Me.Gemini_MediaDataGridView.DataSource = Me.Gemini_MediaBindingSource
        Me.Gemini_MediaDataGridView.Location = New System.Drawing.Point(12, 83)
        Me.Gemini_MediaDataGridView.MultiSelect = False
        Me.Gemini_MediaDataGridView.Name = "Gemini_MediaDataGridView"
        Me.Gemini_MediaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Gemini_MediaDataGridView.Size = New System.Drawing.Size(1100, 255)
        Me.Gemini_MediaDataGridView.TabIndex = 8
        '
        'Package
        '
        Me.Package.HeaderText = "Package"
        Me.Package.Name = "Package"
        Me.Package.Width = 60
        '
        'Packaged
        '
        Me.Packaged.DataPropertyName = "Packaged"
        Me.Packaged.HeaderText = "Packaged HD"
        Me.Packaged.Name = "Packaged"
        Me.Packaged.Width = 60
        '
        'Package_Date
        '
        Me.Package_Date.DataPropertyName = "Package_Date"
        Me.Package_Date.HeaderText = "Package Date HD"
        Me.Package_Date.Name = "Package_Date"
        '
        'Package_Filename
        '
        Me.Package_Filename.DataPropertyName = "Package_Filename"
        Me.Package_Filename.HeaderText = "Package Filename HD"
        Me.Package_Filename.Name = "Package_Filename"
        Me.Package_Filename.Width = 250
        '
        'Packaged_SD
        '
        Me.Packaged_SD.DataPropertyName = "Packaged_SD"
        Me.Packaged_SD.HeaderText = "Packaged SD"
        Me.Packaged_SD.Name = "Packaged_SD"
        Me.Packaged_SD.Width = 60
        '
        'Package_Date_SD
        '
        Me.Package_Date_SD.DataPropertyName = "Package_Date_SD"
        Me.Package_Date_SD.HeaderText = "Package Date SD"
        Me.Package_Date_SD.Name = "Package_Date_SD"
        '
        'Package_Filename_SD
        '
        Me.Package_Filename_SD.DataPropertyName = "Package_Filename_SD"
        Me.Package_Filename_SD.HeaderText = "Package Filename SD"
        Me.Package_Filename_SD.Name = "Package_Filename_SD"
        Me.Package_Filename_SD.Width = 250
        '
        'Archive
        '
        Me.Archive.HeaderText = "Do Archive / Restore HD"
        Me.Archive.Name = "Archive"
        Me.Archive.Width = 80
        '
        'Restore_Date
        '
        Me.Restore_Date.DataPropertyName = "Unarchived Date"
        Me.Restore_Date.HeaderText = "Restore Date HD"
        Me.Restore_Date.Name = "Restore_Date"
        '
        'Missing
        '
        Me.Missing.DataPropertyName = "Missing"
        Me.Missing.HeaderText = "Missing HD"
        Me.Missing.Name = "Missing"
        Me.Missing.Width = 80
        '
        'Archive_SD
        '
        Me.Archive_SD.HeaderText = "Do Archive / Restore SD"
        Me.Archive_SD.Name = "Archive_SD"
        Me.Archive_SD.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Archive_SD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Archive_SD.Width = 95
        '
        'Archived_SD
        '
        Me.Archived_SD.DataPropertyName = "Archived_SD"
        Me.Archived_SD.HeaderText = "Archived SD"
        Me.Archived_SD.Name = "Archived_SD"
        Me.Archived_SD.Width = 70
        '
        'Archived_Date_SD
        '
        Me.Archived_Date_SD.DataPropertyName = "Archived_Date_SD"
        Me.Archived_Date_SD.HeaderText = "Archived Date SD"
        Me.Archived_Date_SD.Name = "Archived_Date_SD"
        Me.Archived_Date_SD.Width = 120
        '
        'Restore_Date_SD
        '
        Me.Restore_Date_SD.DataPropertyName = "Unarchived_Date_SD"
        Me.Restore_Date_SD.HeaderText = "Restore Date SD"
        Me.Restore_Date_SD.Name = "Restore_Date_SD"
        '
        'Missing_SD
        '
        Me.Missing_SD.DataPropertyName = "Missing_SD"
        Me.Missing_SD.HeaderText = "Missing SD"
        Me.Missing_SD.Name = "Missing_SD"
        Me.Missing_SD.Width = 70
        '
        'Use_USA_Menu_BG
        '
        Me.Use_USA_Menu_BG.DataPropertyName = "Use_USA_Menu_BG"
        Me.Use_USA_Menu_BG.HeaderText = "Use_USA_Menu_BG"
        Me.Use_USA_Menu_BG.Name = "Use_USA_Menu_BG"
        Me.Use_USA_Menu_BG.Visible = False
        '
        'dtDelivery
        '
        Me.dtDelivery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtDelivery.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDelivery.Location = New System.Drawing.Point(924, 53)
        Me.dtDelivery.Name = "dtDelivery"
        Me.dtDelivery.Size = New System.Drawing.Size(84, 20)
        Me.dtDelivery.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(847, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Delivery Date"
        '
        'cmdPackage
        '
        Me.cmdPackage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPackage.Location = New System.Drawing.Point(1037, 381)
        Me.cmdPackage.Name = "cmdPackage"
        Me.cmdPackage.Size = New System.Drawing.Size(75, 23)
        Me.cmdPackage.TabIndex = 11
        Me.cmdPackage.Text = "Package"
        Me.cmdPackage.UseVisualStyleBackColor = True
        '
        'FtpConnection1
        '
        Me.FtpConnection1.ParentControl = Me
        Me.FtpConnection1.TransferNotifyInterval = CType(4096, Long)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(118, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(307, 31)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Approval and Packaging"
        '
        'cmdUnpackage
        '
        Me.cmdUnpackage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUnpackage.Location = New System.Drawing.Point(995, 27)
        Me.cmdUnpackage.Name = "cmdUnpackage"
        Me.cmdUnpackage.Size = New System.Drawing.Size(117, 23)
        Me.cmdUnpackage.TabIndex = 11
        Me.cmdUnpackage.Text = "Un Package Screen"
        Me.cmdUnpackage.UseVisualStyleBackColor = True
        '
        'tmClarityEventMessage
        '
        '
        'cmdScan
        '
        Me.cmdScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScan.Location = New System.Drawing.Point(875, 380)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(75, 23)
        Me.cmdScan.TabIndex = 14
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'cmbView
        '
        Me.cmbView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbView.FormattingEnabled = True
        Me.cmbView.Items.AddRange(New Object() {"Packaging View", "Archiving View"})
        Me.cmbView.Location = New System.Drawing.Point(850, 29)
        Me.cmbView.Name = "cmbView"
        Me.cmbView.Size = New System.Drawing.Size(139, 21)
        Me.cmbView.TabIndex = 15
        '
        'cmdArchive
        '
        Me.cmdArchive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdArchive.Location = New System.Drawing.Point(956, 380)
        Me.cmdArchive.Name = "cmdArchive"
        Me.cmdArchive.Size = New System.Drawing.Size(75, 23)
        Me.cmdArchive.TabIndex = 16
        Me.cmdArchive.Text = "Archive"
        Me.cmdArchive.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(1014, 56)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(98, 17)
        Me.chkAll.TabIndex = 17
        Me.chkAll.Text = "Show All Dates"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cmdRestore
        '
        Me.cmdRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRestore.Location = New System.Drawing.Point(1037, 380)
        Me.cmdRestore.Name = "cmdRestore"
        Me.cmdRestore.Size = New System.Drawing.Size(75, 23)
        Me.cmdRestore.TabIndex = 18
        Me.cmdRestore.Text = "Restore"
        Me.cmdRestore.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(549, 54)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(211, 20)
        Me.txtSearch.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(479, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Search Title"
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(766, 52)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 21
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmbHD
        '
        Me.cmbHD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbHD.FormattingEnabled = True
        Me.cmbHD.Items.AddRange(New Object() {"HD Only", "SD Only", "HD + SD"})
        Me.cmbHD.Location = New System.Drawing.Point(766, 29)
        Me.cmbHD.Name = "cmbHD"
        Me.cmbHD.Size = New System.Drawing.Size(75, 21)
        Me.cmbHD.TabIndex = 22
        '
        'cmbFilter
        '
        Me.cmbFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Items.AddRange(New Object() {"All", "Missing but current", "Archived but current", "Current but past last use", "Valid use date but not packaged"})
        Me.cmbFilter.Location = New System.Drawing.Point(549, 27)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(211, 21)
        Me.cmbFilter.TabIndex = 23
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "UID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "UID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'Title
        '
        Me.Title.DataPropertyName = "Title"
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.Width = 200
        '
        'Filename
        '
        Me.Filename.DataPropertyName = "Filename"
        Me.Filename.HeaderText = "Filename"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        Me.Filename.Width = 200
        '
        'Location_ID
        '
        Me.Location_ID.DataPropertyName = "Location_ID"
        Me.Location_ID.HeaderText = "Location_ID"
        Me.Location_ID.Name = "Location_ID"
        Me.Location_ID.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Type_ID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Type_ID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Promote_Five"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Promote_Five"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Visible = False
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Promote_Five_Star"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Promote_Five_Star"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Visible = False
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Promote_Five_US"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Promote_Five_US"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Visible = False
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "Promote_Demand_Five"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Promote_Demand_Five"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.Visible = False
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "Use_DVE"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "Use_DVE"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.Visible = False
        '
        'DataGridViewCheckBoxColumn6
        '
        Me.DataGridViewCheckBoxColumn6.DataPropertyName = "Use_Menu"
        Me.DataGridViewCheckBoxColumn6.HeaderText = "Use_Menu"
        Me.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6"
        Me.DataGridViewCheckBoxColumn6.Visible = False
        '
        'First_Use
        '
        Me.First_Use.DataPropertyName = "First_Use"
        Me.First_Use.HeaderText = "First Use"
        Me.First_Use.Name = "First_Use"
        Me.First_Use.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Last_Use"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Last Use"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn7
        '
        Me.DataGridViewCheckBoxColumn7.DataPropertyName = "Generic"
        Me.DataGridViewCheckBoxColumn7.HeaderText = "Generic"
        Me.DataGridViewCheckBoxColumn7.Name = "DataGridViewCheckBoxColumn7"
        Me.DataGridViewCheckBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Created"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Created"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Modified"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Modified"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Producer"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Producer"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Prog_TX_Start"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Prog_TX_Start"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Prog_TX_End"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Prog_TX_End"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'Delivery_Date
        '
        Me.Delivery_Date.DataPropertyName = "Delivery_Date"
        Me.Delivery_Date.HeaderText = "Delivery_Date"
        Me.Delivery_Date.Name = "Delivery_Date"
        '
        'Archived
        '
        Me.Archived.DataPropertyName = "Archived"
        Me.Archived.HeaderText = "Archived HD"
        Me.Archived.Name = "Archived"
        Me.Archived.Width = 80
        '
        'Archived_Date
        '
        Me.Archived_Date.DataPropertyName = "Archived Date"
        Me.Archived_Date.HeaderText = "Archived Date HD"
        Me.Archived_Date.Name = "Archived_Date"
        Me.Archived_Date.Width = 120
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Notes"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Notes"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Duration"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Duration"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Delivery_1"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Delivery_1"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Delivery_2"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Delivery_2"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Delivery_3"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Delivery_3"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Format_1"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Format_1"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Format_2"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Format_2"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Format_3"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Format_3"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Location_1"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Location_1"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Location_2"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Location_2"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Location_3"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Location_3"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Delivery_Notes"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Delivery_Notes"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "Spreadsheet"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Spreadsheet"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'DataGridViewCheckBoxColumn8
        '
        Me.DataGridViewCheckBoxColumn8.DataPropertyName = "Use_USA_Menu_BG"
        Me.DataGridViewCheckBoxColumn8.HeaderText = "Use_USA_Menu_BG"
        Me.DataGridViewCheckBoxColumn8.Name = "DataGridViewCheckBoxColumn8"
        Me.DataGridViewCheckBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "Circle_Treatment_ID"
        Me.DataGridViewTextBoxColumn28.HeaderText = "Circle_Treatment_ID"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Visible = False
        '
        'Gemini_MediaBindingSource
        '
        Me.Gemini_MediaBindingSource.DataMember = "Gemini_Media"
        Me.Gemini_MediaBindingSource.DataSource = Me.Mm_phase_5DataSet
        '
        'Mm_phase_5DataSet
        '
        Me.Mm_phase_5DataSet.DataSetName = "mm_phase_5DataSet"
        Me.Mm_phase_5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Gemini_MediaTableAdapter
        '
        Me.Gemini_MediaTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Clip_HistoryTableAdapter = Nothing
        Me.TableAdapterManager.Gemini_Media_LocationsTableAdapter = Nothing
        Me.TableAdapterManager.Gemini_MediaTableAdapter = Me.Gemini_MediaTableAdapter
        Me.TableAdapterManager.UpdateOrder = CGA.mm_phase_5DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Gemini_Media_LocationsBindingSource
        '
        Me.Gemini_Media_LocationsBindingSource.DataMember = "Gemini_Media_Locations"
        Me.Gemini_Media_LocationsBindingSource.DataSource = Me.Mm_phase_5DataSet
        '
        'Gemini_Media_LocationsTableAdapter
        '
        Me.Gemini_Media_LocationsTableAdapter.ClearBeforeFill = True
        '
        'BindingSource_Clip_History
        '
        Me.BindingSource_Clip_History.DataMember = "Clip_History"
        Me.BindingSource_Clip_History.DataSource = Me.Mm_phase_5DataSet
        '
        'Clip_HistoryTableAdapter
        '
        Me.Clip_HistoryTableAdapter.ClearBeforeFill = True
        '
        'Main
        '
        Me.AcceptButton = Me.cmdSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 581)
        Me.Controls.Add(Me.cmbFilter)
        Me.Controls.Add(Me.cmbHD)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdRestore)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.cmdArchive)
        Me.Controls.Add(Me.cmbView)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdUnpackage)
        Me.Controls.Add(Me.cmdPackage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtDelivery)
        Me.Controls.Add(Me.Gemini_MediaDataGridView)
        Me.Controls.Add(Me.txtClip_Filename)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.lstMessage)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "ClarityGen Approval"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Gemini_MediaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gemini_MediaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mm_phase_5DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gemini_Media_LocationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_Clip_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstMessage As System.Windows.Forms.ListBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtClip_Filename As System.Windows.Forms.TextBox
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Mm_phase_5DataSet As CGA.mm_phase_5DataSet
    Friend WithEvents Gemini_MediaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Gemini_MediaTableAdapter As CGA.mm_phase_5DataSetTableAdapters.Gemini_MediaTableAdapter
    Friend WithEvents TableAdapterManager As CGA.mm_phase_5DataSetTableAdapters.TableAdapterManager
    Friend WithEvents Gemini_MediaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents dtDelivery As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Gemini_Media_LocationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Gemini_Media_LocationsTableAdapter As CGA.mm_phase_5DataSetTableAdapters.Gemini_Media_LocationsTableAdapter
    Friend WithEvents cmdPackage As System.Windows.Forms.Button
    Friend WithEvents FtpConnection1 As EnterpriseDT.Net.Ftp.FTPConnection
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdUnpackage As System.Windows.Forms.Button
    Friend WithEvents tmClarityEventMessage As System.Windows.Forms.Timer
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchivingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents cmbView As System.Windows.Forms.ComboBox
    Friend WithEvents cmdArchive As System.Windows.Forms.Button
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRestore As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbHD As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents BindingSource_Clip_History As System.Windows.Forms.BindingSource
    Friend WithEvents Clip_HistoryTableAdapter As CGA.mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter
    Friend WithEvents SaveToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents First_Use As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delivery_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Package As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Packaged As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Package_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Package_Filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Packaged_SD As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Package_Date_SD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Package_Filename_SD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Archive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Archived As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Archived_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Restore_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Missing As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Archive_SD As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Archived_SD As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Archived_Date_SD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Restore_Date_SD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Missing_SD As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Use_USA_Menu_BG As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
