VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FF8080&
   BorderStyle     =   0  'None
   Caption         =   "��������ʵ��������濼��ϵͳ"
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
   StartUpPosition =   2  '��Ļ����
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
      Text            =   "�ǣ�Ĭ�Ͽ�����"
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
      Caption         =   "���������ش��ڣ�ֱ��ʵ�����������ʾ"
      BeginProperty Font 
         Name            =   "����"
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
         Name            =   "����"
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
         Name            =   "����"
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
      Caption         =   "(���ϴθ����б��Ƴ�)"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "ע����ʼ���Ժ��ύ�𰸼����˳�ʵ��"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "����ģʽ��"
      BeginProperty Font 
         Name            =   "����"
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
         Name            =   "����"
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
      Caption         =   "ʵ����Ŀ��"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "����������"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "��������"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "��������ʵ��������濼��ϵͳ"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "��"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "����"
      BeginProperty Font 
         Name            =   "����"
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
msgback = MsgBox("��Ҫ�ļ�ȱʧ�����������ر����", vbOKOnly + vbExclamation, "��ʾ")
End
End If
nowtime = Format(Now, "yyyy-mm-dd")
If CInt(DateDiff("d", nowtime, "2022-07-01", 1, 1)) < 0 Then
msgback = MsgBox("ԭ��ʾ��" & vbCrLf & "�ѳ���ָ�����ڣ�Ϊ�˱��ⲻ��Ҫ���鷳��������Ӽ�������Զ��Ƴ�����ȴ��´ι���ʱ�䣡" & vbCrLf & Space(110) & "��������" & vbCrLf & "��2024�꽫ͬϵ��ȫ����Դ�󣬶Գ�������ʵ��������濼��ϵͳ�������ع��Ա�ʾ������Գ��򲢲��ᰴ��������ʾ��⵽���ڳ���2022��7��1�պ�ɾ�������ǻ����������������ȷ�����Լ�����" & vbCrLf & Space(88) & "����Racpast��2024��", vbOKOnly + vbInformation, "��ʾ")
'shellback = Shell(App.Path & "\data\odcl.exe", 2) '������������ɾ��������������
'End
End If
'��������������������������Ĭ��ѡ��
Form1.Combo1.Text = Form1.Combo1.List(0)
Form1.Combo2.Text = Form1.Combo2.List(0)
Form1.Combo3.Text = Form1.Combo3.List(0)
'����Ƿ���ĳЩ�ļ�������ɾ��
If (Dir(App.Path & "\data\main\Biological_Data\������������.txt", 0) = "������������.txt") Then
Kill App.Path & "\data\main\Biological_Data\������������.txt"
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
msgback = MsgBox("ʵ������Ѿ��������У�", vbOKOnly + vbInformation, "��ʾ")
Else
'�����ļ��Ըı�����
If Combo1.Text = "���հף�" Then
FileCopy App.Path & "\data\name_empty\Assembly-CSharp.dll", App.Path & "\data\main\Biological_Data\Managed\Assembly-CSharp.dll"
Else
FileCopy App.Path & "\data\name_test\Assembly-CSharp.dll", App.Path & "\data\main\Biological_Data\Managed\Assembly-CSharp.dll"
End If
'д�����ļ��Ըı�ʵ��
If Combo2.Text = "��Ҷ�ڹ��������л���" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #1
Print #1, "ʵ���Ƿ��ǲ���ģʽ(False/True)*"
Print #1, "[open]=true"
Print #1, "*ʵ������(SW0001/SW003/SW004)*"
Print #1, "[Name]=SW002"
Print #1, "*��¼Or��ԭʵ�����(true���ţ�false¼��)*"
Print #1, "[Recroding]=false"
Print #1, "*log�Ƿ����*"
Print #1, "[LogControll]=false"
Close #1
ElseIf Combo2.Text = "����΢���۲�ֲ��ϸ����ʱװƬ" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #2
Print #2, "ʵ���Ƿ��ǲ���ģʽ(False/True)*"
Print #2, "[open]=true"
Print #2, "*ʵ������(SW0001/SW003/SW004)*"
Print #2, "[Name]=SW004"
Print #2, "*��¼Or��ԭʵ�����(true���ţ�false¼��)*"
Print #2, "[Recroding]=false"
Print #2, "*log�Ƿ����*"
Print #2, "[LogControll]=false"
Close #2
ElseIf Combo2.Text = "�۲����ӵĽṹ" Then
Open App.Path & "\data\main\iniSettingX.ini" For Output As #3
Print #3, "ʵ���Ƿ��ǲ���ģʽ(False/True)*"
Print #3, "[open]=true"
Print #3, "*ʵ������(SW0001/SW003/SW004)*"
Print #3, "[Name]=SW006"
Print #3, "*��¼Or��ԭʵ�����(true���ţ�false¼��)*"
Print #3, "[Recroding]=false"
Print #3, "*log�Ƿ����*"
Print #3, "[LogControll]=false"
Close #3
Else
Open App.Path & "\data\main\iniSettingX.ini" For Output As #4
Print #4, "ʵ���Ƿ��ǲ���ģʽ(False/True)*"
Print #4, "[open]=true"
Print #4, "*ʵ������(SW0001/SW003/SW004)*"
Print #4, "[Name]=SW007"
Print #4, "*��¼Or��ԭʵ�����(true���ţ�false¼��)*"
Print #4, "[Recroding]=false"
Print #4, "*log�Ƿ����*"
Print #4, "[LogControll]=false"
Close #4
End If
If h0.Visible = True Then
Me.Hide
End If
If (Dir(App.Path & "\data\main\Biological_Data\������������.txt", 0) = "������������.txt") Then
Kill App.Path & "\data\main\Biological_Data\������������.txt"
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
