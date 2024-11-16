VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FF8080&
   BorderStyle     =   0  'None
   Caption         =   "初中生物实验操作仿真考试系统"
   ClientHeight    =   5700
   ClientLeft      =   4410
   ClientTop       =   2895
   ClientWidth     =   9330
   Icon            =   "ae000.frx":0000
   LinkTopic       =   "Form1"
   Moveable        =   0   'False
   Picture         =   "ae000.frx":1084A
   ScaleHeight     =   5700
   ScaleWidth      =   9330
   StartUpPosition =   2  '屏幕中心
   Begin VB.Timer timer1 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   840
      Top             =   1200
   End
   Begin VB.ComboBox Combo3 
      Height          =   260
      ItemData        =   "ae000.frx":29E01
      Left            =   1680
      List            =   "ae000.frx":29E08
      Locked          =   -1  'True
      TabIndex        =   9
      Text            =   "是（默认开启）"
      Top             =   4560
      Width           =   3010
   End
   Begin VB.ComboBox Combo2 
      Height          =   260
      ItemData        =   "ae000.frx":29E1C
      Left            =   1680
      List            =   "ae000.frx":29E2C
      Style           =   2  'Dropdown List
      TabIndex        =   4
      Top             =   2520
      Width           =   3010
   End
   Begin VB.ComboBox Combo1 
      Height          =   260
      ItemData        =   "ae000.frx":29E8E
      Left            =   1680
      List            =   "ae000.frx":29E98
      Style           =   2  'Dropdown List
      TabIndex        =   6
      Top             =   2040
      Width           =   3010
   End
   Begin VB.Label CheckBoxDetect 
      BackStyle       =   0  'Transparent
      Height          =   375
      Left            =   5400
      TabIndex        =   16
      Top             =   2280
      Width           =   2295
   End
   Begin VB.Line g0 
      BorderColor     =   &H00FFFF00&
      BorderWidth     =   3
      X1              =   5480
      X2              =   5640
      Y1              =   2570
      Y2              =   2350
   End
   Begin VB.Line h0 
      BorderColor     =   &H00FFFF00&
      BorderWidth     =   3
      X1              =   5400
      X2              =   5500
      Y1              =   2450
      Y2              =   2570
   End
   Begin VB.Shape ShapedCheckBox 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      Height          =   370
      Left            =   5400
      Shape           =   1  'Square
      Top             =   2280
      Width           =   250
   End
   Begin VB.Label ShapedCheckBoxTip 
      BackStyle       =   0  'Transparent
      Caption         =   "启动后隐藏窗口，直到实验结束后再显示"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5760
      TabIndex        =   15
      Top             =   2280
      Width           =   2055
   End
   Begin VB.Label k000000 
      BackStyle       =   0  'Transparent
      Caption         =   "Launcher By YaoJun (Racpast)"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   375
      Index           =   1
      Left            =   0
      TabIndex        =   14
      Top             =   5520
      Width           =   3375
   End
   Begin VB.Label l000000 
      BackStyle       =   0  'Transparent
      Caption         =   "V3.2.2"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   250
      Left            =   0
      TabIndex        =   13
      Top             =   5405
      Width           =   2530
   End
   Begin VB.Label m000000 
      BackStyle       =   0  'Transparent
      Caption         =   "(在上次更新中被移除)"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   5350
      TabIndex        =   12
      Top             =   3360
      Width           =   2895
   End
   Begin VB.Label n00000 
      BackStyle       =   0  'Transparent
      Caption         =   "注：开始测试后，提交答案即可退出实验"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   240
      TabIndex        =   11
      Top             =   5040
      Width           =   4695
   End
   Begin VB.Line o00 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   7800
      X2              =   9120
      Y1              =   5520
      Y2              =   5520
   End
   Begin VB.Line p00 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   7800
      X2              =   7800
      Y1              =   5160
      Y2              =   5520
   End
   Begin VB.Line q00 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   9120
      X2              =   9120
      Y1              =   5160
      Y2              =   5520
   End
   Begin VB.Line r00 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   7800
      X2              =   9120
      Y1              =   5160
      Y2              =   5160
   End
   Begin VB.Label s00000 
      BackStyle       =   0  'Transparent
      Caption         =   "测试模式："
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   250
      Left            =   480
      TabIndex        =   8
      Top             =   4560
      Width           =   1450
   End
   Begin VB.Label t00000 
      BackStyle       =   0  'Transparent
      Caption         =   $"ae000.frx":29EAC
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   1570
      Left            =   480
      TabIndex        =   7
      Top             =   2880
      Width           =   8410
   End
   Begin VB.Label j00000 
      BackStyle       =   0  'Transparent
      Caption         =   "实验项目："
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   250
      Index           =   0
      Left            =   480
      TabIndex        =   5
      Top             =   2520
      Width           =   1450
   End
   Begin VB.Label u00000 
      BackStyle       =   0  'Transparent
      Caption         =   "考生姓名："
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   250
      Index           =   0
      Left            =   480
      TabIndex        =   3
      Top             =   2040
      Width           =   1450
   End
   Begin VB.Label v00000 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "启动设置"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   250
      Left            =   120
      TabIndex        =   2
      Top             =   1680
      Width           =   1330
   End
   Begin VB.Line w0000 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   240
      X2              =   360
      Y1              =   1800
      Y2              =   1800
   End
   Begin VB.Line x0000 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   240
      X2              =   240
      Y1              =   4920
      Y2              =   1800
   End
   Begin VB.Line y0000 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   240
      X2              =   9120
      Y1              =   4920
      Y2              =   4920
   End
   Begin VB.Line z0000 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   9120
      X2              =   9120
      Y1              =   1800
      Y2              =   4920
   End
   Begin VB.Line aa000 
      BorderColor     =   &H00FFFFFF&
      BorderWidth     =   3
      X1              =   1200
      X2              =   9120
      Y1              =   1800
      Y2              =   1800
   End
   Begin VB.Label ab0000 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "初中生物实验操作仿真考试系统"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   36
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   1560
      Left            =   1560
      TabIndex        =   1
      Top             =   120
      Width           =   6250
   End
   Begin VB.Label ShutdownBtn 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "×"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   370
      Left            =   8880
      TabIndex        =   0
      Top             =   120
      Width           =   370
   End
   Begin VB.Label StartLabel 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "启动"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   375
      Left            =   7800
      TabIndex        =   10
      Top             =   5210
      Width           =   1335
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Function CheckApplicationIsRun(ByVal szExeFileName As String) As Boolean
On Error GoTo Err
Dim WMI
Dim Obj
Dim Objs
CheckApplicationIsRun = False
Set WMI = GetObject("WinMgmts:")
Set Objs = WMI.InstancesOf("Win32_Process")
For Each Obj In Objs
If InStr(UCase(szExeFileName), UCase(Obj.Description)) <> 0 Then
CheckApplicationIsRun = True
If Not Objs Is Nothing Then Set Objs = Nothing
If Not WMI Is Nothing Then Set WMI = Nothing
Exit Function
End If
Next
If Not Objs Is Nothing Then Set Objs = Nothing
If Not WMI Is Nothing Then Set WMI = Nothing
Exit Function
Err:
If Not Objs Is Nothing Then Set Objs = Nothing
If Not WMI Is Nothing Then Set WMI = Nothing
End Function
Private Sub CheckBoxDetect_Click()
If (h0.Visible = True) Then
h0.Visible = False
g0.Visible = False
Else
h0.Visible = True
g0.Visible = True
End If
End Sub

Private Sub CheckBoxDetect_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShapedCheckBox.BorderColor = RGB(0, 198, 198)
ShapedCheckBoxTip.ForeColor = RGB(0, 198, 198)
h0.BorderColor = RGB(0, 198, 198)
g0.BorderColor = RGB(0, 198, 198)
End Sub

Private Sub CheckBoxDetect_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShapedCheckBox.BorderColor = RGB(0, 255, 255)
ShapedCheckBoxTip.ForeColor = RGB(0, 255, 255)
h0.BorderColor = RGB(0, 255, 255)
g0.BorderColor = RGB(0, 255, 255)
End Sub

Private Sub CheckBoxDetect_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShapedCheckBox.BorderColor = RGB(0, 255, 255)
ShapedCheckBoxTip.ForeColor = RGB(0, 255, 255)
h0.BorderColor = RGB(0, 255, 255)
g0.BorderColor = RGB(0, 255, 255)
End Sub

Private Sub Form_Load()
If (Dir(App.Path & "\data\main\Biological.exe") <> "") Then
Name App.Path & "\data\main\Biological.exe" As App.Path & "\data\main\Biological"
End If
If Dir(App.Path & "\data\name_empty\Assembly-CSharp.dll") = "" Or Dir(App.Path & "\data\name_test\Assembly-CSharp.dll") = "" Or Dir(App.Path & "\data\main\Biological") = "" Then
msgback = MsgBox("必要文件缺失！请重新下载本软件", vbOKOnly + vbExclamation, "提示")
End
End If
nowtime = Format(Now, "yyyy-mm-dd")
If CInt(DateDiff("d", nowtime, "2022-07-01", 1, 1)) < 0 Then
msgback = MsgBox("原提示：" & vbCrLf & "已超出指定日期，为了避免不必要的麻烦，软件将从计算机中自动移除，请等待下次公开时间！" & vbCrLf & Space(110) & "——作者" & vbCrLf & "于2024年将同系列全部开源后，对初版生物实验操作仿真考试系统进行了重构以表示纪念，所以程序并不会按照上述提示检测到日期超过2022年7月1日后删除，而是会正常工作。点击“确定”以继续。" & vbCrLf & Space(88) & "——Racpast于2024年", vbOKOnly + vbInformation, "提示")
'shellback = Shell(App.Path & "\data\odcl.exe", 2) '此行用于运行删除程序，现已弃用
'End
End If
'下列语句用于设置三个下拉框的默认选项
Form1.Combo1.Text = Form1.Combo1.List(0)
Form1.Combo2.Text = Form1.Combo2.List(0)
Form1.Combo3.Text = Form1.Combo3.List(0)
'检测是否有某些文件，有则删除
If (Dir(App.Path & "\data\main\Biological_Data\考务命题数据.txt", 0) = "考务命题数据.txt") Then
Kill App.Path & "\data\main\Biological_Data\考务命题数据.txt"
End If
End Sub
Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShapedCheckBox.BorderColor = RGB(255, 255, 255)
ShapedCheckBoxTip.ForeColor = RGB(255, 255, 255)
ShutdownBtn.ForeColor = RGB(255, 255, 255)
r00.BorderColor = RGB(255, 255, 255)
q00.BorderColor = RGB(255, 255, 255)
p00.BorderColor = RGB(255, 255, 255)
o00.BorderColor = RGB(255, 255, 255)
StartLabel.ForeColor = RGB(255, 255, 255)
End Sub
Private Sub ShutdownBtn_Click()
If (Dir(App.Path & "\data\main\Biological.exe") <> "") Then
Name App.Path & "\data\main\Biological.exe" As App.Path & "\data\main\Biological"
End If
If (Dir(App.Path & "\data\main\iniSettingX.ini", 0) = "iniSettingX.ini") Then
Kill App.Path & "\data\main\iniSettingX.ini"
End If
End
End Sub

Private Sub ShutdownBtn_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShutdownBtn.ForeColor = RGB(139, 0, 0)
End Sub

Private Sub ShutdownBtn_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
ShutdownBtn.ForeColor = RGB(255, 0, 0)
End Sub

Private Sub StartLabel_Click()
If CheckApplicationIsRun("Biological.exe") = True Then
msgback = MsgBox("实验程序已经在运行中！", vbOKOnly + vbInformation, "提示")
Else
'复制文件以改变名字
If Combo1.Text = "（空白）" Then
FileCopy App.Path & "\data\name_empty\Assembly-CSharp.dll", App.Path & "\data\main\Biological_Data\Managed\Assembly-CSharp.dll"
Else
FileCopy App.Path & "\data\name_test\Assembly-CSharp.dll", App.Path & "\data\main\Biological_Data\Managed\Assembly-CSharp.dll"
End If
'写配置文件以改变实验
If Combo2.Text = "绿叶在光下制造有机物" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #1
Print #1, "实验是否是测试模式(False/True)*"
Print #1, "[open]=true"
Print #1, "*实验名称(SW0001/SW003/SW004)*"
Print #1, "[Name]=SW002"
Print #1, "*记录Or还原实验操作(true播放，false录制)*"
Print #1, "[Recroding]=false"
Print #1, "*log是否输出*"
Print #1, "[LogControll]=false"
Close #1
ElseIf Combo2.Text = "用显微镜观察植物细胞临时装片" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #2
Print #2, "实验是否是测试模式(False/True)*"
Print #2, "[open]=true"
Print #2, "*实验名称(SW0001/SW003/SW004)*"
Print #2, "[Name]=SW004"
Print #2, "*记录Or还原实验操作(true播放，false录制)*"
Print #2, "[Recroding]=false"
Print #2, "*log是否输出*"
Print #2, "[LogControll]=false"
Close #2
ElseIf Combo2.Text = "观察种子的结构" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #3
Print #3, "实验是否是测试模式(False/True)*"
Print #3, "[open]=true"
Print #3, "*实验名称(SW0001/SW003/SW004)*"
Print #3, "[Name]=SW006"
Print #3, "*记录Or还原实验操作(true播放，false录制)*"
Print #3, "[Recroding]=false"
Print #3, "*log是否输出*"
Print #3, "[LogControll]=false"
Close #3
Else
Open App.Path & "\data\main\iniSettingX.ini" For Output As #4
Print #4, "实验是否是测试模式(False/True)*"
Print #4, "[open]=true"
Print #4, "*实验名称(SW0001/SW003/SW004)*"
Print #4, "[Name]=SW007"
Print #4, "*记录Or还原实验操作(true播放，false录制)*"
Print #4, "[Recroding]=false"
Print #4, "*log是否输出*"
Print #4, "[LogControll]=false"
Close #4
End If
If h0.Visible = True Then
Me.Hide
End If
If (Dir(App.Path & "\data\main\Biological_Data\考务命题数据.txt", 0) = "考务命题数据.txt") Then
Kill App.Path & "\data\main\Biological_Data\考务命题数据.txt"
End If
Name App.Path & "\data\main\Biological" As App.Path & "\data\main\Biological.exe"
shellback = Shell(App.Path & "\data\main\Biological.exe", vbMaximizedFocus)
timer1.Enabled = True
End If
End Sub

Private Sub StartLabel_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
r00.BorderColor = RGB(0, 198, 198)
q00.BorderColor = RGB(0, 198, 198)
p00.BorderColor = RGB(0, 198, 198)
o00.BorderColor = RGB(0, 198, 198)
StartLabel.ForeColor = RGB(0, 198, 198)
End Sub

Private Sub StartLabel_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
r00.BorderColor = RGB(0, 255, 255)
q00.BorderColor = RGB(0, 255, 255)
p00.BorderColor = RGB(0, 255, 255)
o00.BorderColor = RGB(0, 255, 255)
StartLabel.ForeColor = RGB(0, 255, 255)
End Sub

Private Sub StartLabel_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
r00.BorderColor = RGB(0, 255, 255)
q00.BorderColor = RGB(0, 255, 255)
p00.BorderColor = RGB(0, 255, 255)
o00.BorderColor = RGB(0, 255, 255)
StartLabel.ForeColor = RGB(0, 255, 255)
End Sub

Private Sub timer1_Timer()
If CheckApplicationIsRun("Biological.exe") = False Then
timer1.Enabled = False
Me.Show
If (Dir(App.Path & "\data\main\iniSettingX.ini", 0) = "iniSettingX.ini") Then
Kill App.Path & "\data\main\iniSettingX.ini"
End If
Name App.Path & "\data\main\Biological.exe" As App.Path & "\data\main\Biological"
End If
End Sub
