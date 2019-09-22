Public Class Form1
    'template
    '{pcip} : {i:rip}
    'rax:{rax} ,rbx:{rbx} ,rcx:{rcx} ,rdx:{rdx} ,rbp:{rbp} ,rsp:{rsp} ,rsi:{rsi} ,rdi:{rdi} ,
    'r8:{r8} ,r9:{r9} ,r10:{r10} ,r11:{r11} ,r12:{r12} ,r13:{r13} ,r14:{r14} ,r15:{r15} ,
    '{rsp} : {[rsp]} : {s:[rsp]}
    '{rsp+8} : {[rsp+8]} : {s:[rsp+8]}
    '{rsp+10} : {[rsp+10]} : {s:[rsp+10]}
    '{rsp+18} : {[rsp+18]} : {s:[rsp+18]}
    '{rsp+20} : {[rsp+20]} : {s:[rsp+20]}
    '{rsp+28} : {[rsp+28]} : {s:[rsp+28]}
    '{rsp+30} : {[rsp+30]} : {s:[rsp+30]}
    '{rsp+38} : {[rsp+38]} : {s:[rsp+38]}
    '{rsp+40} : {[rsp+40]} : {s:[rsp+40]}
    '{rsp+48} : {[rsp+48]} : {s:[rsp+48]}
    '{rsp+50} : {[rsp+50]} : {s:[rsp+50]}
    '{rsp+58} : {[rsp+58]} : {s:[rsp+58]}
    '///////////////////////////////////////////////////////////////////////////////////////////
    Enum RegisterInt
        rax
        rbx
        rcx
        rdx
        rbp
        rsp
        rsi
        rdi
        r8
        r9
        r10
        r11
        r12
        r13
        r14
        r15
        AllReg
    End Enum
    Public Structure _register_
        Dim RAX As String
        Dim RBX As String
        Dim RCX As String
        Dim RDX As String
        Dim RBP As String
        Dim RSP As String
        Dim RSI As String
        Dim RDI As String
        Dim R8 As String
        Dim R9 As String
        Dim R10 As String
        Dim R11 As String
        Dim R12 As String
        Dim R13 As String
        Dim R14 As String
        Dim R15 As String
    End Structure
    Public Structure _cmd
        Dim addr As String
        Dim cmd As String
    End Structure
    Public Structure _Stuck
        Dim st1 As String
        Dim st2 As String
        Dim st3 As String
        Dim st4 As String
        Dim st5 As String
        Dim st6 As String
        Dim st7 As String
        Dim st8 As String
        Dim st9 As String
        Dim st10 As String
        Dim st11 As String
        Dim st12 As String
    End Structure
    Public Class dataStr_
        Sub dataStr_(ByVal cmd As _cmd, ByVal register As _register_, ByVal Stuck As _Stuck)
            register_ = register
            cmd_ = cmd
            Stuck_ = Stuck
        End Sub
        Function GetCmd() As _cmd
            Return cmd_
        End Function
        Function GetRegister() As _register_
            Return register_
        End Function
        Function GetStuck() As _Stuck
            Return Stuck_
        End Function
        Dim register_ As New _register_
        Dim cmd_ As New _cmd
        Public Stuck_ As New _Stuck
    End Class
    Dim dataStrList As New List(Of dataStr_)
    Dim SearchList As New List(Of Integer)  ' holde the lines index result of searching
    Dim CurrentSearchList As Integer = 0  ' current index in Search list

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 15
            DGV_Reg.Rows.Add()
        Next
        DGV_Reg.Rows(0).Cells(0).Value = "RAX"
        DGV_Reg.Rows(1).Cells(0).Value = "RBX"
        DGV_Reg.Rows(2).Cells(0).Value = "RCX"
        DGV_Reg.Rows(3).Cells(0).Value = "RDX"
        DGV_Reg.Rows(4).Cells(0).Value = "RBP"
        DGV_Reg.Rows(5).Cells(0).Value = "RSP"
        DGV_Reg.Rows(6).Cells(0).Value = "RSI"
        DGV_Reg.Rows(7).Cells(0).Value = "RDI"
        DGV_Reg.Rows(8).Cells(0).Value = "R8"
        DGV_Reg.Rows(9).Cells(0).Value = "R9"
        DGV_Reg.Rows(10).Cells(0).Value = "R10"
        DGV_Reg.Rows(11).Cells(0).Value = "R11"
        DGV_Reg.Rows(12).Cells(0).Value = "R12"
        DGV_Reg.Rows(13).Cells(0).Value = "R13"
        DGV_Reg.Rows(14).Cells(0).Value = "R14"
        DGV_Reg.Rows(15).Cells(0).Value = "R15"

        CB_registers.Items.AddRange({"AllReg", "rax", "rbx", "rcx", "rdx", "rbp", "rsp", "rsi", "rdi", "r8", "r9", "r10", "r11", "r12", "r13", "r14", "r15"})
        CB_registers.SelectedIndex = 0

    End Sub

    Private Function LoadFile(ByRef filePath As String) As Boolean
        Dim TextLines As New List(Of String)
        If System.IO.File.Exists(filePath) = True Then
            Dim objReader As New System.IO.StreamReader(filePath)
            Do While objReader.Peek() <> -1
                TextLines.Add(objReader.ReadLine())
            Loop
            If (TextLines.Any) Then
                FillDate(TextLines)
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Function FillDate(ByVal TextLines As List(Of String)) As Boolean
        PB.Value = 0
        PB.Minimum = 0
        PB.Maximum = (TextLines.Count - 1) / 16
        For i = 0 To TextLines.Count - 1 Step 16
            PB.Increment(1)
            Application.DoEvents()
            Dim cmd As New _cmd
            Dim register As New _register_
            Dim Stuck As New _Stuck
            If (TextLines(i).IndexOf(":") < 0) Then
                MsgBox(TextLines(i) + "<< not in same the structure not countain : , First line should be addr:command", MsgBoxStyle.DefaultButton1, "Error")
                Return False
            End If
            cmd.cmd = TextLines(i).Substring(TextLines(i).IndexOf(":") + 1, TextLines(i).Length - (TextLines(i).IndexOf(":") + 1))
            cmd.addr = TextLines(i).Substring(0, TextLines(i).IndexOf(":"))

            If Not (FillReg(register, TextLines(i + 1), TextLines(i + 2))) Then
                MsgBox(TextLines(i + 1) + "<< not in same the structure not countain : , register line should be register:value;", MsgBoxStyle.DefaultButton1, "Error")
                Return False
            End If
            Dim st() As String = {TextLines(i + 3), TextLines(i + 4), TextLines(i + 5), TextLines(i + 6), TextLines(i + 7), TextLines(i + 8), TextLines(i + 9), TextLines(i + 10), TextLines(i + 11), TextLines(i + 12), TextLines(i + 13), TextLines(i + 14)}
            FillStack(Stuck, st)
            Dim dataStr_ As New dataStr_
            dataStr_.dataStr_(cmd, register, Stuck)
            dataStrList.Add(dataStr_)
        Next
        Return True
    End Function
    Private Sub FillStack(ByRef Stuck As _Stuck, ByVal st() As String)
        Stuck.st1 = st(0)
        Stuck.st2 = st(1)
        Stuck.st3 = st(2)
        Stuck.st4 = st(3)
        Stuck.st5 = st(4)
        Stuck.st6 = st(5)
        Stuck.st7 = st(6)
        Stuck.st8 = st(7)
        Stuck.st9 = st(8)
        Stuck.st10 = st(9)
        Stuck.st11 = st(10)
        Stuck.st12 = st(11)
    End Sub
    Private Function FillReg(ByRef register As _register_, ByVal line As String, ByVal line1 As String) As Boolean
        Dim temp As String
        'Dim temp1(7) As String
        If (Not line.Contains("rax") Or Not line.Contains(",rbx") Or Not line.Contains(",rcx") Or Not line.Contains(",rdx") Or Not line.Contains(",rbp") Or Not line.Contains(",rsp") Or Not line.Contains(",rsi") Or Not line.Contains(",rdi")) Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        End If
        If (Not line1.Contains("r8") Or Not line1.Contains(",r9") Or Not line1.Contains(",r10") Or Not line1.Contains("r11") Or Not line1.Contains(",r12") Or Not line1.Contains(",r13") Or Not line1.Contains(",r14") Or Not line1.Contains(",r15")) Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        End If
        If ((Not line.EndsWith(",")) Or Not line1.EndsWith(",")) Then
            MsgBox(" not in same the structure not Ending with , ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        End If
        '''''''''''''''''''''''''''' RAX ----
        temp = line.Substring(0, line.IndexOf(",rbx")) 'get rax
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RAX = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rcx")) 'get rbx
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RBX = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rdx")) 'get rcx
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RCX = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rbp")) 'get rdx
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RDX = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rsp")) 'get rbp
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RBP = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rsi")) 'get rsp
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RSP = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.IndexOf(",rdi")) 'get rsi
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RSI = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line = line.Remove(0, temp.Length)
        temp = line.Substring(0, line.LastIndexOf(",")) 'get rdi
        If Not temp.Contains(":") Then
            MsgBox(line + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.RDI = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        ''''''''''''''''''''''''''''R8 ---- R15
        temp = line1.Substring(0, line1.IndexOf(",r9")) 'get r8
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R8 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r10")) 'get r9
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R9 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r11")) 'get r10
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R10 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r12")) 'get r11
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R11 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r13")) 'get r12
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R12 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r14")) 'get r13
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R13 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.IndexOf(",r15")) 'get r14
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R14 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        line1 = line1.Remove(0, temp.Length)
        temp = line1.Substring(0, line1.LastIndexOf(",")) 'get r15
        If Not temp.Contains(":") Then
            MsgBox(line1 + "<< not in same the structure not countain : ,missing register ", MsgBoxStyle.DefaultButton1, "Error")
            Return False
        Else
            register.R15 = temp.Substring(temp.IndexOf(":") + 1, temp.Length - (temp.IndexOf(":") + 1))
        End If
        Return True
    End Function

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            LoadFile(OpenFileDialog1.FileName)
        End If
        RTB_Cmd.Text = ""
        PB.Value = 0
        PB.Minimum = 0
        PB.Maximum = dataStrList.Count - 1
        For i = 0 To dataStrList.Count - 1
            RTB_Cmd.AppendText(dataStrList(i).GetCmd.addr + " " + dataStrList(i).GetCmd.cmd + Environment.NewLine)
            PB.Increment(1)
            Application.DoEvents()
        Next
        Dim indx As Integer = RTB_Cmd.GetFirstCharIndexFromLine(0)
        RTB_Cmd.SelectionStart = indx
        RTB_Cmd.ScrollToCaret()
        FillInfoFromLine()
    End Sub

    Private Sub RTB_Cmd_MouseClick(sender As Object, e As MouseEventArgs) Handles RTB_Cmd.MouseClick
        FillInfoFromLine()
    End Sub
    Sub FillInfoFromLine()
        Dim LineNum As Integer = (RTB_Cmd.GetLineFromCharIndex(RTB_Cmd.SelectionStart))
        If (RTB_Cmd.TextLength <= 0) Then
            Exit Sub
        End If
        If (RTB_Cmd.Lines(LineNum) Is Nothing) Then
            Exit Sub
        End If
        TB_LineNum.Text = LineNum
        DGV_Reg.Rows(0).Cells(1).Value = dataStrList(LineNum).GetRegister.RAX
        DGV_Reg.Rows(1).Cells(1).Value = dataStrList(LineNum).GetRegister.RBX
        DGV_Reg.Rows(2).Cells(1).Value = dataStrList(LineNum).GetRegister.RCX
        DGV_Reg.Rows(3).Cells(1).Value = dataStrList(LineNum).GetRegister.RDX
        DGV_Reg.Rows(4).Cells(1).Value = dataStrList(LineNum).GetRegister.RBP
        DGV_Reg.Rows(5).Cells(1).Value = dataStrList(LineNum).GetRegister.RSP
        DGV_Reg.Rows(6).Cells(1).Value = dataStrList(LineNum).GetRegister.RSI
        DGV_Reg.Rows(7).Cells(1).Value = dataStrList(LineNum).GetRegister.RDI
        DGV_Reg.Rows(8).Cells(1).Value = dataStrList(LineNum).GetRegister.R8
        DGV_Reg.Rows(9).Cells(1).Value = dataStrList(LineNum).GetRegister.R9
        DGV_Reg.Rows(10).Cells(1).Value = dataStrList(LineNum).GetRegister.R10
        DGV_Reg.Rows(11).Cells(1).Value = dataStrList(LineNum).GetRegister.R11
        DGV_Reg.Rows(12).Cells(1).Value = dataStrList(LineNum).GetRegister.R12
        DGV_Reg.Rows(13).Cells(1).Value = dataStrList(LineNum).GetRegister.R13
        DGV_Reg.Rows(14).Cells(1).Value = dataStrList(LineNum).GetRegister.R14
        DGV_Reg.Rows(15).Cells(1).Value = dataStrList(LineNum).GetRegister.R15

        DGV_Stack.Rows.Clear()
        Dim temp As String = String.Empty
        For i = 0 To 11
            DGV_Stack.Rows.Add()
        Next
        temp = dataStrList(LineNum).GetStuck.st1
        DGV_Stack.Rows(0).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(0).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(0).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st2
        DGV_Stack.Rows(1).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(1).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(1).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st3
        DGV_Stack.Rows(2).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(2).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(2).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st4
        DGV_Stack.Rows(3).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(3).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(3).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st5
        DGV_Stack.Rows(4).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(4).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(4).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st6
        DGV_Stack.Rows(5).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(5).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(5).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st7
        DGV_Stack.Rows(6).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(6).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(6).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st8
        DGV_Stack.Rows(7).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(7).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(7).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st9
        DGV_Stack.Rows(8).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(8).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(8).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st10
        DGV_Stack.Rows(9).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(9).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(9).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st11
        DGV_Stack.Rows(10).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(10).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(10).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
        temp = dataStrList(LineNum).GetStuck.st12
        DGV_Stack.Rows(11).Cells(0).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        DGV_Stack.Rows(11).Cells(1).Value = temp.Substring(0, temp.IndexOf(":"))
        temp = temp.Remove(0, temp.IndexOf(":") + 1)
        If (temp = "???") Then
            DGV_Stack.Rows(11).Cells(2).Value = temp.Substring(1, temp.Length - 1)
        End If
    End Sub

    Private Sub RTB_Cmd_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles RTB_Cmd.MouseDoubleClick
        FillInfoFromLine()
    End Sub

    Private Sub RTB_Cmd_KeyDown(sender As Object, e As KeyEventArgs) Handles RTB_Cmd.KeyDown
        If ((e.KeyCode = Keys.Up) Or (e.KeyCode = Keys.Down) Or (e.KeyCode = Keys.PageUp) Or (e.KeyCode = Keys.PageDown)) Then
            FillInfoFromLine()

        End If
    End Sub

    Private Sub Bu_FindCmd_Click(sender As Object, e As EventArgs) Handles Bu_FindCmd.Click
        Dim TextSerach As String = TB_FillterByAddrCmd.Text
        If (TextSerach.Trim = "") Then
            MsgBox("Pls Enter something ", MsgBoxStyle.DefaultButton1, "error")
            Exit Sub
        End If
        For i1 = 0 To SearchList.Count - 1
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(i1))
            RTB_Cmd.SelectionLength = RTB_Cmd.Lines(SearchList(i1)).Length
            RTB_Cmd.SelectionBackColor = Color.Black
        Next
        SearchList.Clear()
        For i = 0 To dataStrList.Count - 1
            If ((dataStrList(i).GetCmd.addr.Trim.ToLower = TextSerach.Trim.ToLower) Or (dataStrList(i).GetCmd.cmd.Trim.ToLower = TextSerach.Trim.ToLower)) Then
                SearchList.Add(i)
                RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(i)
                RTB_Cmd.SelectionLength = RTB_Cmd.Lines(i).Length
                RTB_Cmd.SelectionBackColor = Color.Pink
            End If
        Next
        La_ResultsCount.Text = SearchList.Count
        CurrentSearchList = 0
        If (SearchList.Any) Then
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(CurrentSearchList))
            RTB_Cmd.ScrollToCaret()
            TB_LineNum.Text = SearchList(CurrentSearchList)
        End If
    End Sub

    Private Sub Bu_back_Click(sender As Object, e As EventArgs) Handles Bu_back.Click
        Dim back As Integer = CurrentSearchList - 1
        If ((back < 0) Or (back > SearchList.Count - 1)) Then
            Exit Sub
        End If
        CurrentSearchList = CurrentSearchList - 1
        RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(CurrentSearchList))
        TB_LineNum.Text = SearchList(CurrentSearchList)
        RTB_Cmd.ScrollToCaret()
        FillInfoFromLine()
    End Sub

    Private Sub Bu_Forward_Click(sender As Object, e As EventArgs) Handles Bu_Forward.Click
        Dim back As Integer = CurrentSearchList + 1
        If ((back < 0) Or (back > SearchList.Count - 1)) Then
            Exit Sub
        End If
        CurrentSearchList = CurrentSearchList + 1
        RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(CurrentSearchList))
        TB_LineNum.Text = SearchList(CurrentSearchList)
        RTB_Cmd.ScrollToCaret()
        FillInfoFromLine()
    End Sub

    Private Sub Bu_FindRisgeter_Click(sender As Object, e As EventArgs) Handles Bu_FindRisgeter.Click
        Dim TextSearch As String = TB_RegisterValue.Text
        If ((CB_registers.Text = "") Or (TextSearch.Trim = "")) Then
            MsgBox("Pls Enter something in the search or chose register ", MsgBoxStyle.DefaultButton1, "error")
            Exit Sub
        End If

        For i1 = 0 To SearchList.Count - 1
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(i1))
            RTB_Cmd.SelectionLength = RTB_Cmd.Lines(SearchList(i1)).Length
            RTB_Cmd.SelectionBackColor = Color.Black
        Next
        SearchList.Clear()
        For i = 0 To dataStrList.Count - 1
            If (IsRegisterHaveValue(i, TextSearch.Trim.ToLower, CB_registers2Value)) Then
                SearchList.Add(i)
                RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(i)
                RTB_Cmd.SelectionLength = RTB_Cmd.Lines(i).Length
                RTB_Cmd.SelectionBackColor = Color.Pink
            End If
        Next
        La_ResultsCount.Text = SearchList.Count
        CurrentSearchList = 0
        If (SearchList.Any) Then
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(CurrentSearchList))
            RTB_Cmd.ScrollToCaret()
        End If
    End Sub
    Private Function CB_registers2Value() As RegisterInt
        Select Case CB_registers.SelectedIndex
            Case 0
                Return RegisterInt.AllReg
            Case 1
                Return RegisterInt.rax
            Case 2
                Return RegisterInt.rbx
            Case 3
                Return RegisterInt.rcx
            Case 4
                Return RegisterInt.rdx
            Case 5
                Return RegisterInt.rbp
            Case 6
                Return RegisterInt.rsp
            Case 7
                Return RegisterInt.rsi
            Case 8
                Return RegisterInt.rdi
            Case 9
                Return RegisterInt.r8
            Case 10
                Return RegisterInt.r9
            Case 11
                Return RegisterInt.r10
            Case 12
                Return RegisterInt.r11
            Case 13
                Return RegisterInt.r12
            Case 14
                Return RegisterInt.r13
            Case 15
                Return RegisterInt.r14
            Case 16
                Return RegisterInt.r15
        End Select
    End Function

    Private Function IsRegisterHaveValue(ByVal indx As Integer, ByVal value As String, ByVal Registerint_ As RegisterInt) As Boolean
        value = value.Trim.ToLower
        Select Case Registerint_
            Case RegisterInt.rax
                If (dataStrList(indx).GetRegister.RAX.Trim.ToLower = value) Then Return True
            Case RegisterInt.rbx
                If (dataStrList(indx).GetRegister.RBX.Trim.ToLower = value) Then Return True
            Case RegisterInt.rcx
                If (dataStrList(indx).GetRegister.RCX.Trim.ToLower = value) Then Return True
            Case RegisterInt.rdx
                If (dataStrList(indx).GetRegister.RDX.Trim.ToLower = value) Then Return True
            Case RegisterInt.rbp
                If (dataStrList(indx).GetRegister.RBP.Trim.ToLower = value) Then Return True
            Case RegisterInt.rsp
                If (dataStrList(indx).GetRegister.RSP.Trim.ToLower = value) Then Return True
            Case RegisterInt.rsi
                If (dataStrList(indx).GetRegister.RSI.Trim.ToLower = value) Then Return True
            Case RegisterInt.rdi
                If (dataStrList(indx).GetRegister.RDI.Trim.ToLower = value) Then Return True
            Case RegisterInt.r8
                If (dataStrList(indx).GetRegister.R8.Trim.ToLower = value) Then Return True
            Case RegisterInt.r9
                If (dataStrList(indx).GetRegister.R9.Trim.ToLower = value) Then Return True
            Case RegisterInt.r10
                If (dataStrList(indx).GetRegister.R10.Trim.ToLower = value) Then Return True
            Case RegisterInt.r11
                If (dataStrList(indx).GetRegister.R11.Trim.ToLower = value) Then Return True
            Case RegisterInt.r12
                If (dataStrList(indx).GetRegister.R12.Trim.ToLower = value) Then Return True
            Case RegisterInt.r13
                If (dataStrList(indx).GetRegister.R13.Trim.ToLower = value) Then Return True
            Case RegisterInt.r14
                If (dataStrList(indx).GetRegister.R14.Trim.ToLower = value) Then Return True
            Case RegisterInt.r15
                If (dataStrList(indx).GetRegister.R15.Trim.ToLower = value) Then Return True
            Case RegisterInt.AllReg
                If (dataStrList(indx).GetRegister.RAX.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RBX.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RCX.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RDX.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RBP.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RSP.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RSI.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.RDI.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R8.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R9.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R10.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R11.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R12.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R13.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R14.Trim.ToLower = value) Then Return True
                If (dataStrList(indx).GetRegister.R15.Trim.ToLower = value) Then Return True


        End Select


        Return False
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If (MsgBox("Do you want to add address to the coomand?", MsgBoxStyle.YesNo, "info") = MsgBoxResult.Yes) Then
            If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
                For i = 0 To dataStrList.Count - 1
                    IO.File.AppendAllText(SaveFileDialog1.FileName, dataStrList(i).GetCmd.addr + "   " + dataStrList(i).GetCmd.cmd + Environment.NewLine)
                Next
            End If
            MsgBox("Done", MsgBoxStyle.DefaultButton1, "info")
        Else
            If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
                For i = 0 To dataStrList.Count - 1
                    IO.File.AppendAllText(SaveFileDialog1.FileName, dataStrList(i).GetCmd.cmd + Environment.NewLine)
                Next
            End If
            MsgBox("Done", MsgBoxStyle.DefaultButton1, "info")
        End If
    End Sub

    Private Sub Bu_SearchAll_Click(sender As Object, e As EventArgs) Handles Bu_SearchAll.Click

    End Sub

    Private Sub Bu_Stack_Click(sender As Object, e As EventArgs) Handles Bu_Stack.Click
        Dim TextSearch As String = TB_Stack.Text
        If ((CB_registers.Text = "") Or (TextSearch.Trim = "")) Then
            MsgBox("Pls Enter something in the search", MsgBoxStyle.DefaultButton1, "error")
            Exit Sub
        End If

        For i1 = 0 To SearchList.Count - 1
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(i1))
            RTB_Cmd.SelectionLength = RTB_Cmd.Lines(SearchList(i1)).Length
            RTB_Cmd.SelectionBackColor = Color.Black
        Next
        SearchList.Clear()
        For i = 0 To dataStrList.Count - 1
            If (IsInStak(i, TextSearch.Trim.ToLower)) Then
                SearchList.Add(i)
                RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(i)
                RTB_Cmd.SelectionLength = RTB_Cmd.Lines(i).Length
                RTB_Cmd.SelectionBackColor = Color.Pink
            End If
        Next
        La_ResultsCount.Text = SearchList.Count
        CurrentSearchList = 0
        If (SearchList.Any) Then
            RTB_Cmd.SelectionStart = RTB_Cmd.GetFirstCharIndexFromLine(SearchList(CurrentSearchList))
            RTB_Cmd.ScrollToCaret()
        End If
    End Sub

    Private Function IsInStak(ByVal index As Integer, ByVal value As String)
        Dim temp(11) As String
        temp(0) = dataStrList(index).GetStuck.st1
        temp(1) = dataStrList(index).GetStuck.st2
        temp(2) = dataStrList(index).GetStuck.st3
        temp(3) = dataStrList(index).GetStuck.st4
        temp(4) = dataStrList(index).GetStuck.st5
        temp(5) = dataStrList(index).GetStuck.st6
        temp(6) = dataStrList(index).GetStuck.st7
        temp(7) = dataStrList(index).GetStuck.st8
        temp(8) = dataStrList(index).GetStuck.st9
        temp(9) = dataStrList(index).GetStuck.st10
        temp(10) = dataStrList(index).GetStuck.st11
        temp(11) = dataStrList(index).GetStuck.st12
        For i = 0 To temp.Length - 1
            Dim tem As String
            tem = temp(i).Substring(0, temp(i).IndexOf(":"))
            temp(i) = temp(i).Remove(0, temp(i).IndexOf(":") + 1)
            If (value.Trim.ToLower = tem.Trim.ToLower) Then Return True
            tem = temp(i).Substring(0, temp(i).IndexOf(":"))
            temp(i) = temp(i).Remove(0, temp(i).IndexOf(":") + 1)
            If (value.Trim.ToLower = tem.Trim.ToLower) Then Return True
            If (value.Trim.ToLower = temp(i).Trim.ToLower) Then Return True   ' the rest of string
        Next
        Return False
    End Function
End Class