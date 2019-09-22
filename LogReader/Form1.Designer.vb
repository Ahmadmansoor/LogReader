<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RTB_Cmd = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGV_Stack = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StringValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_Reg = New System.Windows.Forms.DataGridView()
        Me.Register = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.La_ResultsCount = New System.Windows.Forms.Label()
        Me.Bu_Forward = New System.Windows.Forms.Button()
        Me.Bu_SearchAll = New System.Windows.Forms.Button()
        Me.Bu_back = New System.Windows.Forms.Button()
        Me.Bu_Stack = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Stack = New System.Windows.Forms.TextBox()
        Me.Bu_FindRisgeter = New System.Windows.Forms.Button()
        Me.Bu_FindCmd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_RegisterValue = New System.Windows.Forms.TextBox()
        Me.CB_registers = New System.Windows.Forms.ComboBox()
        Me.TB_FillterByAddrCmd = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.PB = New System.Windows.Forms.ToolStripProgressBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TB_LineNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_Stack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Reg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RTB_Cmd
        '
        Me.RTB_Cmd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RTB_Cmd.BackColor = System.Drawing.Color.Black
        Me.RTB_Cmd.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_Cmd.ForeColor = System.Drawing.Color.ForestGreen
        Me.RTB_Cmd.Location = New System.Drawing.Point(8, 23)
        Me.RTB_Cmd.Margin = New System.Windows.Forms.Padding(4)
        Me.RTB_Cmd.Name = "RTB_Cmd"
        Me.RTB_Cmd.ReadOnly = True
        Me.RTB_Cmd.Size = New System.Drawing.Size(607, 688)
        Me.RTB_Cmd.TabIndex = 0
        Me.RTB_Cmd.Text = ""
        Me.RTB_Cmd.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TB_LineNum)
        Me.GroupBox1.Controls.Add(Me.DGV_Stack)
        Me.GroupBox1.Controls.Add(Me.DGV_Reg)
        Me.GroupBox1.Controls.Add(Me.RTB_Cmd)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(205, 29)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1008, 719)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Result"
        '
        'DGV_Stack
        '
        Me.DGV_Stack.AllowUserToAddRows = False
        Me.DGV_Stack.AllowUserToDeleteRows = False
        Me.DGV_Stack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Stack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_Stack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Stack.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.StringValue})
        Me.DGV_Stack.Location = New System.Drawing.Point(622, 412)
        Me.DGV_Stack.Name = "DGV_Stack"
        Me.DGV_Stack.ReadOnly = True
        Me.DGV_Stack.Size = New System.Drawing.Size(379, 300)
        Me.DGV_Stack.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Addr"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'StringValue
        '
        Me.StringValue.HeaderText = "StringValue"
        Me.StringValue.Name = "StringValue"
        Me.StringValue.ReadOnly = True
        '
        'DGV_Reg
        '
        Me.DGV_Reg.AllowUserToAddRows = False
        Me.DGV_Reg.AllowUserToDeleteRows = False
        Me.DGV_Reg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_Reg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Reg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Register, Me.Value})
        Me.DGV_Reg.Location = New System.Drawing.Point(622, 23)
        Me.DGV_Reg.Name = "DGV_Reg"
        Me.DGV_Reg.ReadOnly = True
        Me.DGV_Reg.Size = New System.Drawing.Size(292, 383)
        Me.DGV_Reg.TabIndex = 1
        '
        'Register
        '
        Me.Register.FillWeight = 45.0!
        Me.Register.HeaderText = "Register"
        Me.Register.Name = "Register"
        Me.Register.ReadOnly = True
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.La_ResultsCount)
        Me.GroupBox2.Controls.Add(Me.Bu_Forward)
        Me.GroupBox2.Controls.Add(Me.Bu_SearchAll)
        Me.GroupBox2.Controls.Add(Me.Bu_back)
        Me.GroupBox2.Controls.Add(Me.Bu_Stack)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TB_Stack)
        Me.GroupBox2.Controls.Add(Me.Bu_FindRisgeter)
        Me.GroupBox2.Controls.Add(Me.Bu_FindCmd)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TB_RegisterValue)
        Me.GroupBox2.Controls.Add(Me.CB_registers)
        Me.GroupBox2.Controls.Add(Me.TB_FillterByAddrCmd)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 29)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(197, 679)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fillter"
        '
        'La_ResultsCount
        '
        Me.La_ResultsCount.AutoSize = True
        Me.La_ResultsCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_ResultsCount.Location = New System.Drawing.Point(68, 481)
        Me.La_ResultsCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.La_ResultsCount.Name = "La_ResultsCount"
        Me.La_ResultsCount.Size = New System.Drawing.Size(61, 20)
        Me.La_ResultsCount.TabIndex = 12
        Me.La_ResultsCount.Text = "Result"
        '
        'Bu_Forward
        '
        Me.Bu_Forward.Location = New System.Drawing.Point(107, 566)
        Me.Bu_Forward.Name = "Bu_Forward"
        Me.Bu_Forward.Size = New System.Drawing.Size(66, 29)
        Me.Bu_Forward.TabIndex = 11
        Me.Bu_Forward.Text = ">>"
        Me.Bu_Forward.UseVisualStyleBackColor = True
        '
        'Bu_SearchAll
        '
        Me.Bu_SearchAll.Location = New System.Drawing.Point(47, 504)
        Me.Bu_SearchAll.Name = "Bu_SearchAll"
        Me.Bu_SearchAll.Size = New System.Drawing.Size(103, 56)
        Me.Bu_SearchAll.TabIndex = 9
        Me.Bu_SearchAll.Text = "Find All"
        Me.Bu_SearchAll.UseVisualStyleBackColor = True
        '
        'Bu_back
        '
        Me.Bu_back.Location = New System.Drawing.Point(26, 566)
        Me.Bu_back.Name = "Bu_back"
        Me.Bu_back.Size = New System.Drawing.Size(66, 29)
        Me.Bu_back.TabIndex = 10
        Me.Bu_back.Text = "<<"
        Me.Bu_back.UseVisualStyleBackColor = True
        '
        'Bu_Stack
        '
        Me.Bu_Stack.Location = New System.Drawing.Point(65, 361)
        Me.Bu_Stack.Name = "Bu_Stack"
        Me.Bu_Stack.Size = New System.Drawing.Size(66, 29)
        Me.Bu_Stack.TabIndex = 8
        Me.Bu_Stack.Text = "Find"
        Me.Bu_Stack.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 304)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "By Stack"
        '
        'TB_Stack
        '
        Me.TB_Stack.Location = New System.Drawing.Point(11, 328)
        Me.TB_Stack.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Stack.Name = "TB_Stack"
        Me.TB_Stack.Size = New System.Drawing.Size(174, 26)
        Me.TB_Stack.TabIndex = 6
        Me.TB_Stack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Bu_FindRisgeter
        '
        Me.Bu_FindRisgeter.Location = New System.Drawing.Point(65, 233)
        Me.Bu_FindRisgeter.Name = "Bu_FindRisgeter"
        Me.Bu_FindRisgeter.Size = New System.Drawing.Size(66, 29)
        Me.Bu_FindRisgeter.TabIndex = 5
        Me.Bu_FindRisgeter.Text = "Find"
        Me.Bu_FindRisgeter.UseVisualStyleBackColor = True
        '
        'Bu_FindCmd
        '
        Me.Bu_FindCmd.Location = New System.Drawing.Point(65, 89)
        Me.Bu_FindCmd.Name = "Bu_FindCmd"
        Me.Bu_FindCmd.Size = New System.Drawing.Size(66, 29)
        Me.Bu_FindCmd.TabIndex = 4
        Me.Bu_FindCmd.Text = "Find"
        Me.Bu_FindCmd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Addr_ Cmd"
        '
        'TB_RegisterValue
        '
        Me.TB_RegisterValue.Location = New System.Drawing.Point(9, 200)
        Me.TB_RegisterValue.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_RegisterValue.Name = "TB_RegisterValue"
        Me.TB_RegisterValue.Size = New System.Drawing.Size(174, 26)
        Me.TB_RegisterValue.TabIndex = 2
        Me.TB_RegisterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CB_registers
        '
        Me.CB_registers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_registers.FormattingEnabled = True
        Me.CB_registers.Location = New System.Drawing.Point(57, 170)
        Me.CB_registers.Margin = New System.Windows.Forms.Padding(4)
        Me.CB_registers.Name = "CB_registers"
        Me.CB_registers.Size = New System.Drawing.Size(83, 28)
        Me.CB_registers.TabIndex = 1
        '
        'TB_FillterByAddrCmd
        '
        Me.TB_FillterByAddrCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_FillterByAddrCmd.Location = New System.Drawing.Point(11, 56)
        Me.TB_FillterByAddrCmd.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_FillterByAddrCmd.Name = "TB_FillterByAddrCmd"
        Me.TB_FillterByAddrCmd.Size = New System.Drawing.Size(174, 22)
        Me.TB_FillterByAddrCmd.TabIndex = 0
        Me.TB_FillterByAddrCmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.PB, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1213, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripLabel1.Text = "LoadFile"
        '
        'PB
        '
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(200, 22)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Export Command to file"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        '
        'TB_LineNum
        '
        Me.TB_LineNum.Location = New System.Drawing.Point(925, 56)
        Me.TB_LineNum.Name = "TB_LineNum"
        Me.TB_LineNum.ReadOnly = True
        Me.TB_LineNum.Size = New System.Drawing.Size(76, 22)
        Me.TB_LineNum.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(930, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "LineNu"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1213, 753)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "LoggerReader/by Ahmadmansoor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_Stack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Reg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RTB_Cmd As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_RegisterValue As TextBox
    Friend WithEvents CB_registers As ComboBox
    Friend WithEvents TB_FillterByAddrCmd As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents PB As ToolStripProgressBar
    Friend WithEvents Bu_FindRisgeter As Button
    Friend WithEvents Bu_FindCmd As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Bu_Stack As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_Stack As TextBox
    Friend WithEvents DGV_Reg As DataGridView
    Friend WithEvents Bu_SearchAll As Button
    Friend WithEvents DGV_Stack As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents StringValue As DataGridViewTextBoxColumn
    Friend WithEvents Bu_Forward As Button
    Friend WithEvents Bu_back As Button
    Friend WithEvents Register As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents La_ResultsCount As Label
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_LineNum As TextBox
End Class
