# **ZkExperimentSingle**

这个项目是为了解决**某个考试**的电脑仿真实验部分**练习不便**的问题而建立的。

> ## **抱定为人民服务之心，增强为人民服务之能，付诸为人民服务之行。**

注意，源码用Visual Studio编译后运行**不可以直接正常使用**。

请下载**V4.9-Release的可执行文件压缩包**后解压，并将其中的**整个data文件夹**（包含实验程序本体）移动至编译的exe文件的**同目录下**。

## ✔️ **中考仿真实验考试软件V4.9**的重制

### 1️⃣重制版下载：

**链接**：[https://github.com/racpast/ZkExperimentSingle/releases](ZkExperimentSingle·Releases)

或

**链接**：[https://share.weiyun.com/F4DB1KnM](腾讯微云，可能失效)

**密码**：abc123

### 2️⃣原理及重制过程：

实验软件由**C#编译**并且未发现复杂混淆，

用dnSpy反编译三个科目的`Assembly-CSharp.dll`及监考端、考生端后，经观察大致原理如下：

监考端向考务平台发起含**三个参数的登录请求**（账号、密码以及通过`GetMac()`方法获取的Mac地址）并读取响应，若`status==200`则登录成功，**显示主窗体**。

此时可以下载考务试卷到监考端本地。考生端发起登录后，会**下载考务试卷**，选择对应实验开始考试的时候是通过

```csharp
ExperimentUC.StartExperiment(text,string.Concat(new string[]{a,”|”,text2,”|”,text3}))
```

语句调用了

```csharp
ProcessManager.OpenProcess(string path,string para,bool shellExecute,boll showWin)
```

传参启动Unity制作的实验程序（`Biological.exe、Physical.exe或Chemistry.exe`）。

所以在重制的过程中，需要做的只是**模拟考生端传参启动**。先通过修改考生端的`OpenProcess`方法，加入**输出启动参数**的语句后重新编译，每个实验都进行一次启动参数的捕获。

在这种情况下启动的实验程序在提交后**没有办法自动退出**，所以继续修改不同实验程序的`EndPanel`的显示方法即可。

**生物科目**：`EndPanel.Start()`方法中总成绩是`AnswerManager.Instance().answerData.allScore`；

**化学科目**：`Chemical.EndPanel.Start()`中总成绩是`KaoWuManager.Instance.answerData.allScore`；

**物理科目**：`UIFW.EndPanel.Display()`，总成绩是`KaoWuManager.Instance.answerData.allScore`，

输出成绩后都用`Application.Quit()`方法**退出**即可。

### 3️⃣值得吐槽的地方：

**所有压缩包**（包括考务试卷、学生答案信息）**的密码都是FaN^y0EAOOc309%**，被用**明文**写在代码里。

还有命名混乱，在**生物科目中有Chemical**（应该是之前想要尝试把三个科目做在一个程序里，但最后没有删掉废案，所以最早出现的生物科目程序有这样的情况）。
