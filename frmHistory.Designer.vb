<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
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
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.BindingSource_Clip_History = New System.Windows.Forms.BindingSource(Me.components)
        Me.Mm_phase_5DataSet = New CGA.mm_phase_5DataSet()
        Me.Clip_HistoryTableAdapter = New CGA.mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter()
        Me.lblClip = New System.Windows.Forms.Label()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MediaIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_Clip_History, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mm_phase_5DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgHistory
        '
        Me.dgHistory.AllowUserToAddRows = False
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistory.AutoGenerateColumns = False
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.MediaIDDataGridViewTextBoxColumn, Me.AddedDataGridViewTextBoxColumn, Me.MessageDataGridViewTextBoxColumn})
        Me.dgHistory.DataSource = Me.BindingSource_Clip_History
        Me.dgHistory.Location = New System.Drawing.Point(12, 37)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.Size = New System.Drawing.Size(754, 554)
        Me.dgHistory.TabIndex = 0
        '
        'BindingSource_Clip_History
        '
        Me.BindingSource_Clip_History.DataMember = "Clip_History"
        Me.BindingSource_Clip_History.DataSource = Me.Mm_phase_5DataSet
        '
        'Mm_phase_5DataSet
        '
        Me.Mm_phase_5DataSet.DataSetName = "mm_phase_5DataSet"
        Me.Mm_phase_5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Clip_HistoryTableAdapter
        '
        Me.Clip_HistoryTableAdapter.ClearBeforeFill = True
        '
        'lblClip
        '
        Me.lblClip.AutoSize = True
        Me.lblClip.Location = New System.Drawing.Point(12, 9)
        Me.lblClip.Name = "lblClip"
        Me.lblClip.Size = New System.Drawing.Size(39, 13)
        Me.lblClip.TabIndex = 1
        Me.lblClip.Text = "Label1"
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'MediaIDDataGridViewTextBoxColumn
        '
        Me.MediaIDDataGridViewTextBoxColumn.DataPropertyName = "Media_ID"
        Me.MediaIDDataGridViewTextBoxColumn.HeaderText = "Media_ID"
        Me.MediaIDDataGridViewTextBoxColumn.Name = "MediaIDDataGridViewTextBoxColumn"
        Me.MediaIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MediaIDDataGridViewTextBoxColumn.Visible = False
        '
        'AddedDataGridViewTextBoxColumn
        '
        Me.AddedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AddedDataGridViewTextBoxColumn.DataPropertyName = "Added"
        Me.AddedDataGridViewTextBoxColumn.FillWeight = 20.0!
        Me.AddedDataGridViewTextBoxColumn.HeaderText = "Added"
        Me.AddedDataGridViewTextBoxColumn.Name = "AddedDataGridViewTextBoxColumn"
        Me.AddedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MessageDataGridViewTextBoxColumn
        '
        Me.MessageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MessageDataGridViewTextBoxColumn.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn.HeaderText = "Message"
        Me.MessageDataGridViewTextBoxColumn.Name = "MessageDataGridViewTextBoxColumn"
        Me.MessageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 603)
        Me.Controls.Add(Me.lblClip)
        Me.Controls.Add(Me.dgHistory)
        Me.Name = "frmHistory"
        Me.Text = "Clip History"
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_Clip_History, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mm_phase_5DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource_Clip_History As System.Windows.Forms.BindingSource
    Friend WithEvents Clip_HistoryTableAdapter As CGA.mm_phase_5DataSetTableAdapters.Clip_HistoryTableAdapter
    Friend WithEvents Mm_phase_5DataSet As CGA.mm_phase_5DataSet
    Friend WithEvents lblClip As System.Windows.Forms.Label
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MediaIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
