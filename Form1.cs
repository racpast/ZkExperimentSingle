using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using PublicHelper.Common;

namespace LRExSys
{
    public partial class Form1 : Form
    {
        //将窗口显示 
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        //切换窗体显示 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //定义待拼接的字符串等
        public string pp = Application.StartupPath + "\\data\\Physical.exe";
        public string hp = Application.StartupPath + "\\data\\Chemistry.exe";
        public string sp = Application.StartupPath + "\\data\\Biological.exe";
        public string psp = Application.StartupPath + "\\data\\Physical";
        public string hsp = Application.StartupPath + "\\data\\Chemistry";
        public string ssp = Application.StartupPath + "\\data\\Biological";
        public string en = "wl1";
        public string wl1rv = "{\"fixedEquip\":[{\"chineseName\":\"开关\",\"count\":1,\"type\":\"Switch\",\"shortName\":\"S\"},{\"chineseName\":\"线圈\",\"count\":1,\"type\":\"CoilWL024\",\"shortName\":\"C\"},{\"chineseName\":\"磁铁\",\"count\":1,\"type\":\"HorseshoeMagnet\",\"shortName\":\"H\"},{\"chineseName\":\"铁架\",\"count\":1,\"type\":\"IronSupportWL024\",\"shortName\":\"I\"},{\"chineseName\":\"灵敏电流计\",\"count\":1,\"type\":\"Microdetector\",\"shortName\":\"M\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究导体在磁场中运动时产生感应电流的条件\",\"form\":\"true\",\"examID\":\"WL024\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Electricity\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n线圈（1个）、灵敏电流计（1个）、开关（1个）、导线（若干）、铁架台（1个）、蹄形磁体（1个）\\r\\n实验步骤:\\r\\n（1）连接电路。\\r\\n（2）闭合开关，观察电流计情况。\\r\\n\"},\"action\":[{\"Order\":1,\"score\":6,\"count\":1,\"id\":\"WL024_001\",\"Operation\":\"Correct\",\"Info\":\"将蹄形磁体放置于铁架台上\"},{\"Order\":2,\"score\":6,\"count\":1,\"id\":\"WL024_002\",\"Operation\":\"Correct\",\"Info\":\"将线圈挂在铁架台上\"},{\"Order\":3,\"score\":6,\"count\":1,\"id\":\"WL024_003\",\"Operation\":\"Correct\",\"Info\":\"把灵敏电流计、开关、线圈串联\"},{\"Order\":4,\"score\":10,\"count\":1,\"id\":\"WL024_004\",\"Operation\":\"Correct\",\"Info\":\"断开开关，任意移动线圈，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":5,\"score\":10,\"count\":1,\"id\":\"WL024_005\",\"Operation\":\"Correct\",\"Info\":\"闭合开关，使线圈保持静止，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":6,\"score\":10,\"count\":1,\"id\":\"WL024_006\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中前后移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":7,\"score\":10,\"count\":1,\"id\":\"WL024_007\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中上下移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":8,\"score\":10,\"count\":1,\"id\":\"WL024_008\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中左右移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":9,\"score\":6,\"count\":1,\"id\":\"WL024_009\",\"Operation\":\"Correct\",\"Info\":\"断开开关\"},{\"Order\":10,\"score\":20,\"count\":1,\"id\":\"WL024_010\",\"Operation\":\"Correct\",\"Info\":\"填写实验结论\"},{\"Order\":11,\"score\":6,\"count\":1,\"id\":\"WL024_011\",\"Operation\":\"Correct\",\"Info\":\"整理仪器，结束实验\"}],\"variableEquip\":[],\"setting\":{\"showrule\":";
        public string wl2rv = "{\"fixedEquip\":[{\"chineseName\":\"钩码\",\"count\":5,\"type\":\"Gomar\",\"shortName\":\"G\"},{\"chineseName\":\"杠杆\",\"count\":1,\"type\":\"Lever\",\"shortName\":\"L\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究杠杆的平衡条件\",\"form\":\"true\",\"examID\":\"WL019\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Mechanics\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n铁架台和杠杆（带刻度）、钩码\\r\\n实验步骤:\\r\\n（1）调节杠杆两端的螺母,使杠杆在不挂钩码时保持水平并静止,达到平衡状态。\\r\\n（2）给杠杆两测挂上不同数量的钩码,移动钩码的位置,使杠杆重新在水平位置平衡。这时杠杆两侧受到的作用力等于各自钩码所受的重力。\\r\\n（3）设右侧钩码对杠杆施的力为动力F1,左侧钩码对杠杆施的力为阻力F2；测出杠杆平衡时的动力臂l1和阻力臂l2；把F1、F2、l1、l2的数值填入表格中。\\r\\n（4）改变动力F1和动力臂l1的大小,相应调整阻力F2和阻力臂l2,再做几次实验。\"},\"action\":[{\"Order\":1,\"score\":8,\"count\":1,\"id\":\"WL019_001\",\"Operation\":\"Correct\",\"Info\":\"得出结论\"},{\"Order\":1,\"score\":16,\"count\":1,\"id\":\"WL019_002\",\"Operation\":\"Correct\",\"Info\":\"改变动力臂、阻力臂或改变两边的钩码数量重复上述操作两次。\"},{\"Order\":2,\"score\":10,\"count\":1,\"id\":\"WL019_003\",\"Operation\":\"Correct\",\"Info\":\"实验前调节杠杆平衡\"},{\"Order\":3,\"score\":16,\"count\":1,\"id\":\"WL019_004\",\"Operation\":\"Correct\",\"Info\":\"杠杆两边挂上不同数量钩码，调节钩码的位置使杠杆平衡，记录动力、动力臂、阻力、阻力臂\"},{\"Order\":4,\"score\":16,\"count\":1,\"id\":\"WL019_005\",\"Operation\":\"Correct\",\"Info\":\"改变动力臂、阻力臂或改变两边的钩码数量重复上述操作两次。\"},{\"Order\":5,\"score\":24,\"count\":1,\"id\":\"WL019_006\",\"Operation\":\"Correct\",\"Info\":\"计算动力乘以动力臂，阻力乘以阻力臂\"},{\"Order\":6,\"score\":10,\"count\":1,\"id\":\"WL019_007\",\"Operation\":\"Correct\",\"Info\":\"整理器材\"}],\"variableEquip\":[],\"setting\":{\"showrule\":";
        public string wl3rv = "{\"fixedEquip\":[{\"chineseName\":\"白纸\",\"count\":1,\"type\":\"WhitePaper\",\"shortName\":\"W\"},{\"chineseName\":\"玻璃板\",\"count\":1,\"type\":\"FlatMirror\",\"shortName\":\"F\"},{\"chineseName\":\"刻度尺\",\"count\":1,\"type\":\"GraduationRuler\",\"shortName\":\"G\"},{\"chineseName\":\"量角器\",\"count\":1,\"type\":\"Protractor\",\"shortName\":\"P\"},{\"chineseName\":\"蜡烛\",\"count\":2,\"type\":\"Candle\",\"shortName\":\"C\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究平面镜成像的特点\",\"form\":\"true\",\"examID\":\"WL015\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Optics\",\"examTime\":\"10\",\"examContent\":\"实验目的：通过实验探究,得出平面镜成像的特点\\n实验器材：玻璃板（薄）及支架、刻度尺、量角器、白纸、相同大小的蜡烛两支\\n实验步骤：\\n（1）在水平桌面上铺上白纸,纸上竖立一块玻璃板作为平面镜,并画出玻璃板在白纸上的位置。\\n（2）点燃蜡烛A放在玻璃板的前面,可以看到它在玻璃板后面的像,在纸上记下蜡烛A的位置。\\n（3）再拿一支同样大小但不点燃的蜡烛B,竖立在玻璃板后面移动,直到看上去它跟蜡烛A的像重合,在纸上记下蜡烛B的位置,观察蜡烛B的大小和蜡烛A的像大小是否相同。\\n（4）移动蜡烛A,重做实验。\\n（5）用直线把每次实验中蜡烛A、B在纸上的位置连起来,并用刻度尺分别测量它们到玻璃板的距离,再用量角器量出连线与平面镜夹角的大小,将数据记录在下表中。\"},\"action\":[{\"Order\":2,\"score\":0,\"count\":1,\"id\":\"WL015_010\",\"Operation\":\"Correct\",\"Info\":\"选择实验器材\"},{\"Order\":3,\"score\":4,\"count\":1,\"id\":\"WL015_021\",\"Operation\":\"Correct\",\"Info\":\"在水平桌面上铺上白纸\"},{\"Order\":4,\"score\":4,\"count\":1,\"id\":\"WL015_022\",\"Operation\":\"Correct\",\"Info\":\"纸上竖立一块玻璃板作为平面镜\"},{\"Order\":5,\"score\":4,\"count\":1,\"id\":\"WL015_031\",\"Operation\":\"Correct\",\"Info\":\"点燃蜡烛A\"},{\"Order\":6,\"score\":4,\"count\":1,\"id\":\"WL015_032\",\"Operation\":\"Correct\",\"Info\":\"蜡烛A放在玻璃板的前面\"},{\"Order\":7,\"score\":4,\"count\":1,\"id\":\"WL015_041\",\"Operation\":\"Correct\",\"Info\":\"再拿一支同样大小但不点燃的蜡烛B，竖立在玻璃板后面\"},{\"Order\":8,\"score\":4,\"count\":1,\"id\":\"WL015_042\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛B，直到看上去它跟蜡烛A的像重合\"},{\"Order\":9,\"score\":4,\"count\":1,\"id\":\"WL015_043\",\"Operation\":\"Correct\",\"Info\":\"在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":10,\"score\":10,\"count\":1,\"id\":\"WL015_051\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛A，第一次重做实验并在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":11,\"score\":10,\"count\":1,\"id\":\"WL015_061\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛A，第二次重做实验并在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":12,\"score\":18,\"count\":1,\"id\":\"WL015_081\",\"Operation\":\"Correct\",\"Info\":\"用刻度尺测量物距、相距并正确填入表中\"},{\"Order\":13,\"score\":15,\"count\":1,\"id\":\"WL015_082\",\"Operation\":\"Correct\",\"Info\":\"将观察结果正确填入表中\"},{\"Order\":14,\"score\":10,\"count\":1,\"id\":\"WL015_083\",\"Operation\":\"Correct\",\"Info\":\"填写实验结论\"},{\"Order\":15,\"score\":9,\"count\":1,\"id\":\"WL015_091\",\"Operation\":\"Correct\",\"Info\":\"整理器材\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"WLK20\",\"Operation\":\"Wrong\",\"Info\":\"点燃蜡烛B\"}],\"variableEquip\":[],\"setting\":{\"showrule\":";
        public string wl4rv = "{\"fixedEquip\":[{\"chineseName\":\"开关\",\"count\":1,\"type\":\"Switch\",\"shortName\":\"S\"},{\"chineseName\":\"电流表\",\"count\":1,\"type\":\"Ammeter\",\"shortName\":\"A\"},{\"chineseName\":\"电压表\",\"count\":1,\"type\":\"Voltmeter\",\"shortName\":\"V\"},{\"chineseName\":\"滑动变阻器\",\"count\":1,\"type\":\"SliderHostat\",\"shortName\":\"R\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"用电流表和电压表测电阻\",\"form\":\"true\",\"examID\":\"WL006\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Electricity\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n电池（1.5V2节）、电流表、电压表、滑动变阻器、定值电阻、开关、导线（10根）\\r\\n实验步骤:\\r\\n（1）按图连接电路。\\r\\n（2）调节滑动变阻器的范围，改变电阻两端的电压，测量并记下几组电压和电流值。\\r\\n（3）根据表格数据，正确计算电阻及平均电阻。\"},\"action\":[{\"Order\":7,\"score\":4,\"count\":1,\"id\":\"WL006_002\",\"Operation\":\"Correct\",\"Info\":\"断开开关，按图正确连接电路\"},{\"Order\":6,\"score\":6,\"count\":1,\"id\":\"WL006_003\",\"Operation\":\"Correct\",\"Info\":\"把滑动变阻器调制电阻最大值\"},{\"Order\":8,\"score\":10,\"count\":1,\"id\":\"WL006_004\",\"Operation\":\"Correct\",\"Info\":\"闭合开关，测出电流和电压并填写到表格\"},{\"Order\":9,\"score\":10,\"count\":1,\"id\":\"WL006_005\",\"Operation\":\"Correct\",\"Info\":\"调节滑动变阻器，测出电流和电压并填写到表格\"},{\"Order\":10,\"score\":10,\"count\":1,\"id\":\"WL006_006\",\"Operation\":\"Correct\",\"Info\":\"再次调节滑动变阻器，测出电流和电压并填写到表格\"},{\"Order\":13,\"score\":5,\"count\":1,\"id\":\"WL006_007\",\"Operation\":\"Correct\",\"Info\":\"整理仪器\"},{\"Order\":11,\"score\":20,\"count\":1,\"id\":\"WL006_008\",\"Operation\":\"Correct\",\"Info\":\"正确计算三次电阻值，最后计算平均电阻\"},{\"Order\":1,\"score\":6,\"count\":1,\"id\":\"WL006_010\",\"Operation\":\"Correct\",\"Info\":\"电流表调零\"},{\"Order\":2,\"score\":6,\"count\":1,\"id\":\"WL006_011\",\"Operation\":\"Correct\",\"Info\":\"电压表调零\"},{\"Order\":3,\"score\":6,\"count\":1,\"id\":\"WL006_012\",\"Operation\":\"Correct\",\"Info\":\"正确将电流表串联在电路中\"},{\"Order\":4,\"score\":6,\"count\":1,\"id\":\"WL006_013\",\"Operation\":\"Correct\",\"Info\":\"正确将电压表并联在定值电阻两端\"},{\"Order\":5,\"score\":6,\"count\":1,\"id\":\"WL006_014\",\"Operation\":\"Correct\",\"Info\":\"正确连接滑动变阻器\"},{\"Order\":12,\"score\":5,\"count\":1,\"id\":\"WL006_015\",\"Operation\":\"Correct\",\"Info\":\"断开开关\"},{\"Order\":9,\"score\":0,\"count\":1,\"id\":\"WLK01\",\"Operation\":\"Wrong\",\"Info\":\"带电操作\"},{\"Order\":10,\"score\":0,\"count\":1,\"id\":\"WLK02\",\"Operation\":\"Wrong\",\"Info\":\"电池损坏\"},{\"Order\":13,\"score\":0,\"count\":1,\"id\":\"WLK03\",\"Operation\":\"Wrong\",\"Info\":\"电流表正负接线柱接反\"},{\"Order\":12,\"score\":0,\"count\":1,\"id\":\"WLK04\",\"Operation\":\"Wrong\",\"Info\":\"电流表损坏\"},{\"Order\":14,\"score\":0,\"count\":1,\"id\":\"WLK05\",\"Operation\":\"Wrong\",\"Info\":\"电压表正负接线柱接反\"},{\"Order\":11,\"score\":0,\"count\":1,\"id\":\"WLK08\",\"Operation\":\"Wrong\",\"Info\":\"出现短路或是短路故障，不能快速排除\"}],\"variableEquip\":[{\"chineseName\":\"电源\",\"count\":1,\"type\":\"Battery\",\"shortName\":\"P\",\"voltage\":\"3\"},{\"chineseName\":\"定值电阻\",\"count\":1,\"constantValueRheostat\":\"5\",\"type\":\"ConstantValue\",\"shortName\":\"C\"}],\"setting\":{\"showrule\":";
        public string hx1rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"用长颈漏斗制作二氧化碳\",\"examId\":\"HX0032\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"实验步骤：\\n1、清点实验所需器材\\n2、检验装置的气密性\\n3、装入药品\\n4、用向上排空气法收集1瓶气体\\n5、验满\\n6、检验二氧化碳\\n7、整理仪器\"},\"formula\":[],\"action\":[{\"score\":5,\"operationType\":\"true\",\"id\":\"CalciumHydroxide01\",\"Info\":\"打开澄清石灰水，将瓶盖倒放\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid01\",\"Info\":\"打开稀盐酸瓶盖\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid02\",\"Info\":\"将稀盐酸放置在长颈漏斗口，使稀盐酸标签朝向手心\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid03\",\"Info\":\"盖上稀盐酸瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Erlenmeyer02\",\"Info\":\"将锥形瓶横放，用镊子将大理石放在锥形瓶内\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Erlenmeyer03\",\"Info\":\"慢慢将锥形瓶旋转至竖直，使大理石缓缓滑入锥形瓶底部\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Erlenmeyer04\",\"Info\":\"将锥形瓶平放在桌面，塞紧橡胶塞\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder07\",\"Info\":\"集气瓶瓶口朝上，将玻璃管插入接近集气瓶底\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder08\",\"Info\":\"取出集气瓶中的玻璃管，用玻璃片盖住集气瓶口\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder09\",\"Info\":\"移开玻璃片，使试剂瓶的标签朝向手心，靠在集气瓶口，倒入澄清石灰水\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder10\",\"Info\":\"集气瓶盖上玻璃片，震荡集气瓶\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder11\",\"Info\":\"观察集气瓶中的澄清石灰水是否变浑浊\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder13\",\"Info\":\"集气瓶盖上玻璃片，收集气体\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder17\",\"Info\":\"将点燃的小木条靠近集气瓶口，观察木条熄灭\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow3302\",\"Info\":\"将玻璃弯管润湿的一端插入橡胶塞的另一孔\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow9301\",\"Info\":\"将玻璃弯管与橡胶管连接，再连接另一个玻璃管\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel01\",\"Info\":\"稀盐酸瓶口紧挨长颈漏斗口，沿瓶口将盐酸倒入,使液面没过漏斗下端\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel02\",\"Info\":\"将长颈漏斗下端用水润湿，插入双孔橡胶塞的一孔处\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel03\",\"Info\":\"将双孔橡胶塞塞入锥形瓶，调整长颈漏斗的下端与锥形瓶底部的距离，接近但不接触到锥形瓶底部\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"LongNeckFunnel04\",\"Info\":\"从长颈漏斗注水，观察液面是否下降\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Marble01\",\"Info\":\"打开大理石瓶盖\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Marble03\",\"Info\":\"盖上大理石瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"RubberStopper03\",\"Info\":\"检查气密性完好后，取下双孔橡胶塞\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"RubberTube101\",\"Info\":\"用止水夹夹住橡胶管\"}],\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"AlcoholLamp\"},{\"quantity\":1,\"equipmentId\":\"Batten\"},{\"quantity\":1,\"equipmentId\":\"CalciumHydroxide\"},{\"quantity\":1,\"equipmentId\":\"DilutedHydrochloricAcid\"},{\"quantity\":1,\"equipmentId\":\"Erlenmeyer\"},{\"quantity\":1,\"equipmentId\":\"GasCylinder\"},{\"quantity\":1,\"equipmentId\":\"GasCylinderCap\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow330\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow930\"},{\"quantity\":1,\"equipmentId\":\"LongNeckFunnel\"},{\"quantity\":1,\"equipmentId\":\"Marble\"},{\"quantity\":1,\"equipmentId\":\"MatchesBox\"},{\"quantity\":1,\"equipmentId\":\"PlasticSink\"},{\"quantity\":1,\"equipmentId\":\"RubberStopper2\"},{\"quantity\":1,\"equipmentId\":\"RubberTube\"},{\"quantity\":1,\"equipmentId\":\"SpringClip\"},{\"quantity\":1,\"equipmentId\":\"Tweezers\"},{\"quantity\":1,\"equipmentId\":\"Water\"}],\"setting\":{\"showrule\":";
        public string hx2rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"氧气的制取\",\"examId\":\"HX002\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"实验步骤：\\n1、学习仪器连接和检验装置气密性的方法\\n2、获知高锰酸钾分解制氧气的原理和操作程序\"},\"formula\":[],\"action\":[{\"score\":5,\"operationType\":\"true\",\"id\":\"AlcoholLamp03\",\"Info\":\"用帽盖熄灭酒精灯\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"AlcoholLamp04\",\"Info\":\"把木块放铁架台上，把酒精灯放木块上\"},{\"score\":2,\"operationType\":\"true\",\"id\":\"Batten01\",\"Info\":\"用酒精灯将木条点燃\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Batten02\",\"Info\":\"将木条熄灭，形成带火星的木条\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Batten03\",\"Info\":\"把带火星的木条伸入集气瓶中，观察木条是否复燃\"},{\"score\":2,\"operationType\":\"true\",\"id\":\"CheckExperimentalSupplies\",\"Info\":\"检查实验用品及仪器\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Cotton01\",\"Info\":\"在试管口加一团棉花（防止受热时高锰酸钾粉末进入导管造成堵塞）\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder04\",\"Info\":\"导管口有均匀气泡冒出时，将导管一端伸入集气瓶里\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder05\",\"Info\":\"待集气瓶中水排净，在水面下盖上玻璃片\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GasCylinder14\",\"Info\":\"集气瓶装满水，盖上玻璃片，倒放进水槽\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder16\",\"Info\":\"将收集气体的集气瓶正放在实验台上\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow12002\",\"Info\":\"把120°的玻璃弯管一端用水润湿，插入带孔橡胶塞，另一端套入橡皮管（检查气密性）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow6001\",\"Info\":\"橡皮管的一端，套入用水润湿60°玻璃管（检查气密性）\"},{\"score\":2,\"operationType\":\"true\",\"id\":\"GlassElbow6002\",\"Info\":\"组装好仪器后，将导管的一端浸入水中\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"GlassElbow6003\",\"Info\":\"用热毛巾裹住试管外壁（导管口有气泡冒出）\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GlassElbow6007\",\"Info\":\"停止加热后，将导管从水中移出\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GlassElbow6011\",\"Info\":\"将导管的一端浸入水槽的水中\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"MedicineSpoon01\",\"Info\":\"打开高锰酸钾瓶盖，用药匙舀高锰酸钾药品\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"RubberStopper01\",\"Info\":\"用橡胶塞塞住试管口（检查气密性）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"RubberStopper04\",\"Info\":\"用橡胶塞塞住试管口（高锰酸钾制取氧气装药）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"TestTube07\",\"Info\":\"拿起试管，将试管倾斜，装入药品（1~3匙），并盖好瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"TestTube08\",\"Info\":\"将试管夹装到铁架台上，固定好试管\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"TestTube15\",\"Info\":\"将酒精灯帽盖取下，用火柴点燃酒精灯，预热试管\"}],\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"AlcoholLamp\"},{\"quantity\":1,\"equipmentId\":\"Batten\"},{\"quantity\":1,\"equipmentId\":\"Cotton\"},{\"quantity\":1,\"equipmentId\":\"FrostedGlassPiece\"},{\"quantity\":1,\"equipmentId\":\"GlassBottle_Water\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow120\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow60\"},{\"quantity\":1,\"equipmentId\":\"HotTowel\"},{\"quantity\":1,\"equipmentId\":\"IronTand\"},{\"quantity\":1,\"equipmentId\":\"MatchesBox\"},{\"quantity\":1,\"equipmentId\":\"MedicineSpoon\"},{\"quantity\":1,\"equipmentId\":\"PlasticSink\"},{\"quantity\":1,\"equipmentId\":\"PtassiumPermanganate\"},{\"quantity\":1,\"equipmentId\":\"RubberStopper\"},{\"quantity\":1,\"equipmentId\":\"RubberTube\"},{\"quantity\":1,\"equipmentId\":\"TestTube\"},{\"quantity\":1,\"equipmentId\":\"TestTubeHolder_Metal\"},{\"quantity\":1,\"equipmentId\":\"Water\"},{\"quantity\":1,\"equipmentId\":\"Wood\"}],\"setting\":{\"showrule\":";
        public string hx3rv = "{\"tableItemDatas\":[{\"line\":1,\"row\":1,\"content\":\"溶液质量/g\"},{\"line\":1,\"row\":2,\"content\":\"溶质质量分数/%\"},{\"line\":1,\"row\":3,\"content\":\"溶质质量/g\"},{\"line\":1,\"row\":4,\"content\":\"溶剂质量/g\"},{\"line\":2,\"row\":1,\"content\":\"50\"},{\"line\":2,\"row\":2,\"content\":\"6\"},{\"line\":2,\"row\":3,\"content\":\"\"},{\"line\":2,\"row\":4,\"content\":\"\"}],\"conclusion\":[],\"questions\":{\"examTitle\":\"一定溶质质量分数的氯化钠溶液的配置\",\"examId\":\"HX0071\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"1、配制50g质量分数为6%的氯化钠溶液\"},\"formula\":[],\"action\":[{\"score\":6,\"operationType\":\"true\",\"id\":\"Beaker_50ml06\",\"Info\":\"将称量好的氯化钠倒入烧杯中\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"Beaker_50ml07\",\"Info\":\"将量筒中的蒸馏水缓缓倒入烧杯\"},{\"score\":20,\"operationType\":\"true\",\"id\":\"BiaoGe\",\"Info\":\"正确填写表格\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"ElectronicBalance01\",\"Info\":\"电子秤上垫一张称量纸\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"GlassRod02\",\"Info\":\"用玻璃棒搅拌使氯化钠充分溶解\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"GlassRod03\",\"Info\":\"将玻璃棒插入试剂瓶中\"},{\"score\":8,\"operationType\":\"true\",\"id\":\"GlassRod04\",\"Info\":\"利用玻璃棒引流，将烧杯中的氯化钠溶液装入试剂瓶中盖好瓶盖\"},{\"score\":8,\"operationType\":\"true\",\"id\":\"Glueapplicato01\",\"Info\":\"用胶头滴管滴加药液至所需刻度线\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"LabelStick01\",\"Info\":\"将标签贴在试剂瓶上(6%)\"},{\"score\":0,\"operationType\":\"true\",\"id\":\"LabelStick021\",\"Info\":\"正确计算配制50g6%氯化钠溶液所需的氯化钠及水的体积，并填写表格\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"MeasuringCylinder03\",\"Info\":\"将量筒置于水平桌面上，向量筒内倾倒蒸馏水，至接近所需刻度时停止倾倒\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"WeighingPaper01\",\"Info\":\"用药匙向电子秤上的白纸添加氯化钠晶体\"}],\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"Beaker_50mL\"},{\"quantity\":1,\"equipmentId\":\"ElectronicBalance\"},{\"quantity\":1,\"equipmentId\":\"FineMouthBottle\"},{\"quantity\":1,\"equipmentId\":\"GlassRod\"},{\"quantity\":1,\"equipmentId\":\"Glueapplicato\"},{\"quantity\":1,\"equipmentId\":\"LabelStick\"},{\"quantity\":1,\"equipmentId\":\"MeasuringCylinder\"},{\"quantity\":1,\"equipmentId\":\"MedicineSpoon\"},{\"quantity\":1,\"equipmentId\":\"SodiumChloride\"},{\"quantity\":1,\"equipmentId\":\"Water\"},{\"quantity\":1,\"equipmentId\":\"WeighingPaper\"}],\"setting\":{\"showrule\":";
        public string sw1rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"观察小鱼尾鳍内血液的流动\",\"examId\":\"SW007\",\"attributes\":\"biological\",\"examContent\":\"1、制作装片/2、组装调试显微镜/3、观察/4、整理仪器\"},\"action\":[{\"Order\":5,\"score\":7,\"count\":1,\"id\":\"SW007_01\",\"Operation\":\"Correct\",\"Info\":\"从鱼缸里捞出一条小鱼，放在培养皿中\"},{\"Order\":3,\"score\":7,\"count\":1,\"id\":\"SW007_02\",\"Operation\":\"Correct\",\"Info\":\"用湿纱布将小鱼头部的鳃盖和躯干部包裹起来，露出尾部\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"SW007_03\",\"Operation\":\"Correct\",\"Info\":\"把包裹好的小鱼平放在培养皿中，展开尾鳍，使尾鳍贴合在培养皿上\"},{\"Order\":15,\"score\":9,\"count\":1,\"id\":\"SW007_04\",\"Operation\":\"Correct\",\"Info\":\"将载玻片盖在与培养皿贴合的小鱼尾鳍上\"},{\"Order\":13,\"score\":3,\"count\":1,\"id\":\"SW007_05\",\"Operation\":\"Correct\",\"Info\":\"将显微镜放于距离桌面5-7cm处，防止跌落桌面\"},{\"Order\":12,\"score\":6,\"count\":1,\"id\":\"SW007_06\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋，将镜筒升高到一定高度\"},{\"Order\":11,\"score\":7,\"count\":1,\"id\":\"SW007_07\",\"Operation\":\"Correct\",\"Info\":\"转动转换器，使低倍镜对准通光孔\"},{\"Order\":10,\"score\":0,\"count\":1,\"id\":\"SW007_08\",\"Operation\":\"Correct\",\"Info\":\"转动遮光器，调大光圈对准通光孔（系统已默认）\"},{\"Order\":9,\"score\":8,\"count\":1,\"id\":\"SW007_09\",\"Operation\":\"Correct\",\"Info\":\"纱布浸湿，置于培养皿中\"},{\"Order\":20,\"score\":6,\"count\":1,\"id\":\"SW007_10\",\"Operation\":\"Correct\",\"Info\":\"注视目镜，转动反光镜直到整个视野明亮\"},{\"Order\":19,\"score\":3,\"count\":1,\"id\":\"SW007_11\",\"Operation\":\"Correct\",\"Info\":\"待小鱼不再频繁跳动，将包裹好小鱼的培养皿放置在载物台上\"},{\"Order\":18,\"score\":3,\"count\":1,\"id\":\"SW007_12\",\"Operation\":\"Correct\",\"Info\":\"使盖有玻片的尾鳍正对通光孔中心\"},{\"Order\":17,\"score\":7,\"count\":1,\"id\":\"SW007_13\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋使物镜接近装片标本\"},{\"Order\":16,\"score\":7,\"count\":1,\"id\":\"SW007_14\",\"Operation\":\"Correct\",\"Info\":\"轻转粗准焦螺旋，使镜筒缓缓上升，寻找物像。转动细准焦螺旋使物像更加清晰\"},{\"Order\":25,\"score\":3,\"count\":1,\"id\":\"SW007_15\",\"Operation\":\"Correct\",\"Info\":\"将物像移到视野中央，选择合适的区域进行观察\"},{\"Order\":24,\"score\":10,\"count\":1,\"id\":\"SW007_16\",\"Operation\":\"Correct\",\"Info\":\"实验现象正确。视野中可观察到三种不同的血管（注：确认后点击【记录结果】）\"},{\"Order\":23,\"score\":4,\"count\":1,\"id\":\"SW007_17\",\"Operation\":\"Correct\",\"Info\":\"取下培养皿，将小鱼放回鱼缸中。将纱布置入废液缸废渣缸\"},{\"Order\":22,\"score\":3,\"count\":1,\"id\":\"SW007_18\",\"Operation\":\"Correct\",\"Info\":\"清理仪器，清洗培养皿\"},{\"Order\":21,\"score\":3,\"count\":1,\"id\":\"SW007_19\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":8,\"score\":0,\"count\":1,\"id\":\"SW007_20\",\"Operation\":\"Wrong\",\"Info\":\"未把鱼鳃盖和躯干包裹紧，小鱼乱跳\"},{\"Order\":7,\"score\":0,\"count\":1,\"id\":\"SW007_21\",\"Operation\":\"Wrong\",\"Info\":\"未保护好小鱼，导致小鱼死亡\"},{\"Order\":6,\"score\":0,\"count\":3,\"id\":\"SW007_22\",\"Operation\":\"Wrong\",\"Info\":\"未使用载玻片隔离小鱼与载物台导致污染\"},{\"Order\":4,\"score\":0,\"count\":3,\"id\":\"SW007_23\",\"Operation\":\"Wrong\",\"Info\":\"镜筒下降过低，物镜压到小鱼\"},{\"Order\":2,\"score\":0,\"count\":1,\"id\":\"SW007_24\",\"Operation\":\"Wrong\",\"Info\":\"直接在高倍镜下观察小鱼尾鳍的血管，视野较小\"},{\"Order\":0,\"score\":4,\"count\":1,\"id\":\"SW007_25\",\"Operation\":\"Correct\",\"Info\":\"点击【回答问题】进行正确作答\"},{\"Order\":14,\"score\":0,\"count\":1,\"id\":\"SW007_26\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液废渣缸\"}],\"setting\":{\"showrule\":";
        public string sw2rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"制作和观察洋葱鳞片叶内表皮细胞临时装片\",\"examId\":\"SW004\",\"attributes\":\"biological\",\"examContent\":\"1.制作装片/2.组装调试显微镜/3.观察/4.整理仪器\"},\"action\":[{\"Order\":20,\"score\":3,\"count\":1,\"id\":\"SW004_01\",\"Operation\":\"Correct\",\"Info\":\"用洁净的纱布将载玻片和盖玻片擦拭干净\"},{\"Order\":18,\"score\":3,\"count\":1,\"id\":\"SW004_02\",\"Operation\":\"Correct\",\"Info\":\"用滴管在载玻片的中央滴一滴清水\"},{\"Order\":23,\"score\":6,\"count\":1,\"id\":\"SW004_03\",\"Operation\":\"Correct\",\"Info\":\"用刀片在鳞片叶内侧划一个“井”字形，再用镊子沿一角撕取一小块透明薄膜\"},{\"Order\":21,\"score\":6,\"count\":1,\"id\":\"SW004_04\",\"Operation\":\"Correct\",\"Info\":\"用镊子将撕下来的材料置于载玻片的清水中，用镊子使其展平\"},{\"Order\":14,\"score\":8,\"count\":1,\"id\":\"SW004_05\",\"Operation\":\"Correct\",\"Info\":\"用镊子夹起盖玻片，使其一侧先接触载玻片上的水滴，然后缓缓地盖在液滴上\"},{\"Order\":13,\"score\":8,\"count\":1,\"id\":\"SW004_06\",\"Operation\":\"Correct\",\"Info\":\"用滴管把1~2 滴碘液滴在盖玻片的一侧，用吸水纸从盖玻片另一侧引流，使染液浸润标本的全部\"},{\"Order\":16,\"score\":3,\"count\":1,\"id\":\"SW004_07\",\"Operation\":\"Correct\",\"Info\":\"将显微镜放于距离桌面边缘5-7cm处，防止跌落桌面\"},{\"Order\":15,\"score\":6,\"count\":1,\"id\":\"SW004_08\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋，将镜筒升高到一定高度\"},{\"Order\":24,\"score\":6,\"count\":1,\"id\":\"SW004_09\",\"Operation\":\"Correct\",\"Info\":\"转动转换器，使低倍镜对准通光孔\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"SW004_10\",\"Operation\":\"Correct\",\"Info\":\"转动遮光器，调大光圈对准通光孔（系统已默认）\"},{\"Order\":0,\"score\":8,\"count\":1,\"id\":\"SW004_11\",\"Operation\":\"Correct\",\"Info\":\"注视目镜，转动反光镜直到整个视野明亮\"},{\"Order\":7,\"score\":3,\"count\":1,\"id\":\"SW004_12\",\"Operation\":\"Correct\",\"Info\":\"使玻片标本正对通光孔中心\"},{\"Order\":6,\"score\":3,\"count\":1,\"id\":\"SW004_13\",\"Operation\":\"Correct\",\"Info\":\"用压片夹固定住装片\"},{\"Order\":9,\"score\":6,\"count\":1,\"id\":\"SW004_14\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋使低倍物镜接近玻片标本\"},{\"Order\":8,\"score\":6,\"count\":1,\"id\":\"SW004_15\",\"Operation\":\"Correct\",\"Info\":\"轻转粗准焦螺旋，使镜筒缓缓上升，寻找物像。转动细准焦螺旋使物像更加清晰。\"},{\"Order\":3,\"score\":3,\"count\":1,\"id\":\"SW004_16\",\"Operation\":\"Correct\",\"Info\":\"物像移到视野中央，选择合适的区域进行观察\"},{\"Order\":2,\"score\":12,\"count\":1,\"id\":\"SW004_17\",\"Operation\":\"Correct\",\"Info\":\"实验现象正确。细胞核被染成黄色，视野中的细胞是单层且无过多气泡（注：确认后点击【记录结果】）\"},{\"Order\":5,\"score\":3,\"count\":1,\"id\":\"SW004_18\",\"Operation\":\"Correct\",\"Info\":\"清理仪器，清洗玻片\"},{\"Order\":4,\"score\":3,\"count\":1,\"id\":\"SW004_19\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":10,\"score\":0,\"count\":3,\"id\":\"SW004_20\",\"Operation\":\"Wrong\",\"Info\":\"没擦玻片，视野中存在杂物\"},{\"Order\":12,\"score\":0,\"count\":3,\"id\":\"SW004_21\",\"Operation\":\"Wrong\",\"Info\":\"染色不充分\"},{\"Order\":11,\"score\":0,\"count\":3,\"id\":\"SW004_22\",\"Operation\":\"Wrong\",\"Info\":\"未选用反光镜，光线不足\"},{\"Order\":19,\"score\":0,\"count\":3,\"id\":\"SW004_23\",\"Operation\":\"Wrong\",\"Info\":\"没有用压片夹固定住装片，装片移动\"},{\"Order\":17,\"score\":0,\"count\":3,\"id\":\"SW004_24\",\"Operation\":\"Wrong\",\"Info\":\"镜筒下降过低，物镜压到装片\"},{\"Order\":22,\"score\":4,\"count\":1,\"id\":\"SW004_25\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液缸废渣缸，包括洋葱和吸水纸\"}],\"setting\":{\"showrule\":";
        public string sw3rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"观察种子的结构\",\"examId\":\"SW006\",\"attributes\":\"biological\",\"examContent\":\"1、取材/2、实验/3、观察/4、整理仪器/5、实验附加题作答\"},\"action\":[{\"Order\":7,\"score\":11,\"count\":1,\"id\":\"SW006_01\",\"Operation\":\"Correct\",\"Info\":\"取一粒浸软的菜豆种子放在白瓷盘里，观察它的外形\"},{\"Order\":8,\"score\":11,\"count\":1,\"id\":\"SW006_02\",\"Operation\":\"Correct\",\"Info\":\"用镊子剥开菜豆种子种皮,分开菜豆种子子叶\"},{\"Order\":5,\"score\":4,\"count\":1,\"id\":\"SW006_04\",\"Operation\":\"Correct\",\"Info\":\"用放大镜观察菜豆种子结构的形状、位置，\"},{\"Order\":3,\"score\":11,\"count\":1,\"id\":\"SW006_05\",\"Operation\":\"Correct\",\"Info\":\"取一粒浸软的玉米种子放在白瓷盘里，观察它的外形\"},{\"Order\":4,\"score\":11,\"count\":1,\"id\":\"SW006_06\",\"Operation\":\"Correct\",\"Info\":\"用刀片将玉米种子从中央纵向剖开\"},{\"Order\":1,\"score\":11,\"count\":1,\"id\":\"SW006_07\",\"Operation\":\"Correct\",\"Info\":\"在玉米的一个剖面滴一滴稀碘液\"},{\"Order\":2,\"score\":4,\"count\":1,\"id\":\"SW006_08\",\"Operation\":\"Correct\",\"Info\":\"用放大镜观察染成蓝色和未被染色的剖面结构的形状、位置\"},{\"Order\":0,\"score\":4,\"count\":1,\"id\":\"SW006_09\",\"Operation\":\"Correct\",\"Info\":\"实验残渣放入废液缸废渣缸，包括玉米种子、菜豆种子及菜豆种皮\"},{\"Order\":9,\"score\":4,\"count\":1,\"id\":\"SW006_10\",\"Operation\":\"Correct\",\"Info\":\"清洗仪器，清洗培养皿和白瓷盘\"},{\"Order\":10,\"score\":4,\"count\":1,\"id\":\"SW006_11\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":6,\"score\":25,\"count\":1,\"id\":\"SW006_12\",\"Operation\":\"Correct\",\"Info\":\"点击【回答问题】进行正确作答\"}],\"setting\":{\"showrule\":";
        public string sw4rv = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"绿叶在光下制造有机物\",\"examId\":\"SW002\",\"attributes\":\"biological\",\"examContent\":\"1、取材/2、实验/3、观察/4、整理仪器\"},\"action\":[{\"Order\":13,\"score\":5,\"count\":1,\"id\":\"SW002_01\",\"Operation\":\"Correct\",\"Info\":\"用黑色塑料袋套住天竺葵\"},{\"Order\":15,\"score\":5,\"count\":1,\"id\":\"SW002_02\",\"Operation\":\"Correct\",\"Info\":\"放在黑暗处24小时以上\"},{\"Order\":2,\"score\":5,\"count\":1,\"id\":\"SW002_03\",\"Operation\":\"Correct\",\"Info\":\"选1片叶片，用回形针将黑色纸片固定在叶片的上下两面\"},{\"Order\":4,\"score\":5,\"count\":1,\"id\":\"SW002_04\",\"Operation\":\"Correct\",\"Info\":\"把天竺葵移到阳光下照射2~3小时\"},{\"Order\":6,\"score\":6,\"count\":1,\"id\":\"SW002_05\",\"Operation\":\"Correct\",\"Info\":\"把叶片放入盛有酒精的小烧杯中\"},{\"Order\":8,\"score\":6,\"count\":1,\"id\":\"SW002_06\",\"Operation\":\"Correct\",\"Info\":\"将小烧杯置于装有清水的大烧杯中\"},{\"Order\":17,\"score\":6,\"count\":1,\"id\":\"SW002_07\",\"Operation\":\"Correct\",\"Info\":\"用酒精灯水浴加热\"},{\"Order\":19,\"score\":3,\"count\":1,\"id\":\"SW002_08\",\"Operation\":\"Correct\",\"Info\":\"5分钟叶片变成黄白色\"},{\"Order\":20,\"score\":6,\"count\":1,\"id\":\"SW002_09\",\"Operation\":\"Correct\",\"Info\":\"用镊子取出叶片用清水漂洗\"},{\"Order\":10,\"score\":6,\"count\":1,\"id\":\"SW002_10\",\"Operation\":\"Correct\",\"Info\":\"将叶片平铺在培养皿中\"},{\"Order\":11,\"score\":6,\"count\":1,\"id\":\"SW002_11\",\"Operation\":\"Correct\",\"Info\":\"加入几滴稀碘液\"},{\"Order\":12,\"score\":6,\"count\":1,\"id\":\"SW002_12\",\"Operation\":\"Correct\",\"Info\":\"稍等片刻用清水洗净稀碘液\"},{\"Order\":14,\"score\":20,\"count\":1,\"id\":\"SW002_13\",\"Operation\":\"Correct\",\"Info\":\"观察叶片变化并点击【回答问题】进行正确做答\"},{\"Order\":1,\"score\":5,\"count\":1,\"id\":\"SW002_14\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液缸废渣缸，包括叶片残渣、各个烧杯中的液体、培养皿染色的碘液、清洗器材的液体\"},{\"Order\":3,\"score\":5,\"count\":1,\"id\":\"SW002_15\",\"Operation\":\"Correct\",\"Info\":\"清洗仪器，清洗培养皿和烧杯\"},{\"Order\":5,\"score\":5,\"count\":1,\"id\":\"SW002_16\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":7,\"score\":0,\"count\":1,\"id\":\"SW002_17\",\"Operation\":\"Wrong\",\"Info\":\"暗处理时间不够，叶片中淀粉没转运殆尽，影响实验结果\"},{\"Order\":16,\"score\":0,\"count\":1,\"id\":\"SW002_18\",\"Operation\":\"Wrong\",\"Info\":\"太阳照射时间不够，绿叶没充分进行光合作用\"},{\"Order\":18,\"score\":0,\"count\":1,\"id\":\"SW002_19\",\"Operation\":\"Wrong\",\"Info\":\"不隔水加热，发生爆炸\"},{\"Order\":0,\"score\":0,\"count\":1,\"id\":\"SW002_20\",\"Operation\":\"Wrong\",\"Info\":\"不垫石棉网，烧杯破裂\"},{\"Order\":9,\"score\":0,\"count\":1,\"id\":\"SW002_21\",\"Operation\":\"Wrong\",\"Info\":\"加热后不熄灭酒精灯\"}],\"setting\":{\"showrule\":";

        public Form1()
        {
            InitializeComponent();
        }

        //清除结果文件
        public void CleanAnswer()
        {
            string[] AnswerPaths =
{
                psp + "\\Answer\\物理\\物理_114514_WL024.spks",
                psp + "\\Answer\\物理\\物理_114514_WL019.spks",
                psp + "\\Answer\\物理\\物理_114514_WL015.spks",
                psp + "\\Answer\\物理\\物理_114514_WL006.spks",
                hsp + "\\Answer\\chemistry\\chemistry_114514_HX0032.spks",
                hsp + "\\Answer\\chemistry\\chemistry_114514_HX002.spks",
                hsp + "\\Answer\\chemistry\\chemistry_114514_HX0071.spks",
                ssp + "\\Answer\\生物\\生物_114514_SW007.spks",
                ssp + "\\Answer\\生物\\生物_114514_SW004.spks",
                ssp + "\\Answer\\生物\\生物_114514_SW006.spks",
                ssp + "\\Answer\\生物\\生物_114514_SW002.spks"
            };
            //逐个检查是否存在，如果存在就删除
            foreach (var filePath in AnswerPaths)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

        }

        //设置可见属性与父容器
        public void SetVisibilityAndParent(Control control)
        {
            control.Visible = true;
            button1.Parent = control;
            button2.Parent = control;
            button3.Parent = control;
            hx1r.Parent = control;
            hx2r.Parent = control;
            hx3r.Parent = control;
            wl1r.Parent = control;
            wl2r.Parent = control;
            wl3r.Parent = control;
            wl4r.Parent = control;
            sw1r.Parent = control;
            sw2r.Parent = control;
            sw3r.Parent = control;
            sw4r.Parent = control;
            zb.Parent = control;
            pictureBox2.Parent = control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //背景图全部不可见
            PictureBox[] bkgs =
            {
                bk1,bk2,bk3,bk4,bk5,bk6
            };
            foreach(var bkpic in bkgs)
            {
                bkpic.Visible = false;
            }
            //产生一个1~7（含）随机数
            Random r=new Random();
            int bkh = r.Next(1, 7);
            //对应产生的随机数决定显示哪张背景图
            switch (bkh)
            {
                case 1:
                    SetVisibilityAndParent(bk1);
                    break;
                case 2:
                    SetVisibilityAndParent(bk2);
                    break;
                case 3:
                    SetVisibilityAndParent(bk3);
                    break;
                case 4:
                    SetVisibilityAndParent(bk4);
                    break;
                case 5:
                    SetVisibilityAndParent(bk5);
                    break;
                case 6:
                    SetVisibilityAndParent(bk6);
                    break;
            }
            //选中一个初始实验
            wl1r.Select();
            //设置透明色
            this.TransparencyKey = this.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //清除结果文件
            CleanAnswer();
            string pshowr = "true}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"40\",\"subject\":\"物理\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + psp;
            string pnoshowr = "false}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"40\",\"subject\":\"物理\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + psp;
            string hshowr = "true}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"30\",\"subject\":\"化学\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + hsp;
            string hnoshowr = "false}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"30\",\"subject\":\"化学\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + hsp;
            string swshowr = "true,\"controll\":true,\"formQuestion\":false}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"40\",\"subject\":\"生物\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + ssp;
            string swnoshowr = "false,\"controll\":true,\"formQuestion\":false}}|{\"stuId\":\"114514\",\"stuName\":\"蔡徐坤\",\"examTime\":\"40\",\"subject\":\"生物\",\"u3dProgressCallBack\":\"http://120.79.15.123:7074/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://120.79.15.123:7074/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://120.79.15.123:7074/test/examCmdBroadcast\"}|" + ssp;
            try
            {
                //显示得分判定器的情况
                if (zb.Checked)
                {
                    if (wl1r.Checked)
                    {
                        en = "wl1";
                        ProcessManager.OpenProcess(pp, wl1rv + pshowr, false);
                    }
                    else if (wl2r.Checked)
                    {
                        en = "wl2";
                        ProcessManager.OpenProcess(pp, wl2rv + pshowr, false);
                    }
                    else if (wl3r.Checked)
                    {
                        en = "wl3";
                        ProcessManager.OpenProcess(pp, wl3rv + pshowr, false);
                    }
                    else if (wl4r.Checked)
                    {
                        en = "wl4";
                        ProcessManager.OpenProcess(pp, wl4rv + pshowr, false);
                    }
                    else if (hx1r.Checked)
                    {
                        en = "hx1";
                        ProcessManager.OpenProcess(hp, hx1rv + hshowr, false);
                    }
                    else if (hx2r.Checked)
                    {
                        en = "hx2";
                        ProcessManager.OpenProcess(hp, hx2rv + hshowr, false);
                    }
                    else if (hx3r.Checked)
                    {
                        en = "hx3";
                        ProcessManager.OpenProcess(hp, hx3rv + hshowr, false);
                    }
                    else if (sw1r.Checked)
                    {
                        en = "sw1";
                        ProcessManager.OpenProcess(sp, sw1rv + swshowr, false);
                    }
                    else if (sw2r.Checked)
                    {
                        en = "sw2";
                        ProcessManager.OpenProcess(sp, sw2rv + swshowr, false);
                    }
                    else if (sw3r.Checked)
                    {
                        en = "sw3";
                        ProcessManager.OpenProcess(sp, sw3rv + swshowr, false);
                    }
                    else if (sw4r.Checked)
                    {
                        en = "sw4";
                        ProcessManager.OpenProcess(sp, sw4rv + swshowr, false);
                    }
                }
                //不显示得分判定器的情况
                else
                {
                    if (wl1r.Checked)
                    {
                        en = "wl1";
                        ProcessManager.OpenProcess(pp, wl1rv + pnoshowr, false);
                    }
                    else if (wl2r.Checked)
                    {
                        en = "wl2";
                        ProcessManager.OpenProcess(pp, wl2rv + pnoshowr, false);
                    }
                    else if (wl3r.Checked)
                    {
                        en = "wl3";
                        ProcessManager.OpenProcess(pp, wl3rv + pnoshowr, false);
                    }
                    else if (wl4r.Checked)
                    {
                        en = "wl4";
                        ProcessManager.OpenProcess(pp, wl4rv + pnoshowr, false);
                    }
                    else if (hx1r.Checked)
                    {
                        en = "hx1";
                        ProcessManager.OpenProcess(hp, hx1rv + hnoshowr, false);
                    }
                    else if (hx2r.Checked)
                    {
                        en = "hx2";
                        ProcessManager.OpenProcess(hp, hx2rv + hnoshowr, false);
                    }
                    else if (hx3r.Checked)
                    {
                        en = "hx3";
                        ProcessManager.OpenProcess(hp, hx3rv + hnoshowr, false);
                    }
                    else if (sw1r.Checked)
                    {
                        en = "sw1";
                        ProcessManager.OpenProcess(sp, sw1rv + swnoshowr, false);
                    }
                    else if (sw2r.Checked)
                    {
                        en = "sw2";
                        ProcessManager.OpenProcess(sp, sw2rv + swnoshowr, false);
                    }
                    else if (sw3r.Checked)
                    {
                        en = "sw3";
                        ProcessManager.OpenProcess(sp, sw3rv + swnoshowr, false);
                    }
                    else if (sw4r.Checked)
                    {
                        en = "sw4";
                        ProcessManager.OpenProcess(sp, sw4rv + swnoshowr, false);
                    }
                }
                ts.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "发生预料外的错误");
            }
        }

        //从Json中取得总分
        public string GetAllScore (String json)
        {
            JObject jobj=JObject.Parse(json);
            string alls = jobj["allScore"].ToString();
            return alls;
        }

        private void ts_Tick(object sender, EventArgs e)
        {
            //定义答案文件路径和退出脚本路径
            string wl1sf = psp + "\\Answer\\物理\\物理_114514_WL024.spks";
            string wl2sf = psp + "\\Answer\\物理\\物理_114514_WL019.spks";
            string wl3sf = psp + "\\Answer\\物理\\物理_114514_WL015.spks";
            string wl4sf = psp + "\\Answer\\物理\\物理_114514_WL006.spks";
            string hx1sf = hsp + "\\Answer\\chemistry\\chemistry_114514_HX0032.spks";
            string hx2sf = hsp + "\\Answer\\chemistry\\chemistry_114514_HX002.spks";
            string hx3sf = hsp + "\\Answer\\chemistry\\chemistry_114514_HX0071.spks";
            string sw1sf = ssp + "\\Answer\\生物\\生物_114514_SW007.spks";
            string sw2sf = ssp + "\\Answer\\生物\\生物_114514_SW004.spks";
            string sw3sf = ssp + "\\Answer\\生物\\生物_114514_SW006.spks";
            string sw4sf = ssp + "\\Answer\\生物\\生物_114514_SW002.spks";
            string exitbat = Application.StartupPath + "\\data\\exit.bat";
            //退出并输出成绩
            Dictionary<string, Tuple<string, string>> experiments = new Dictionary<string, Tuple<string, string>>
            {
                { "wl1", Tuple.Create("探究导体在磁场中运动时产生感应电流的条件", wl1sf) },
                { "wl2", Tuple.Create("探究杠杆的平衡条件", wl2sf) },
                { "wl3", Tuple.Create("探究平面镜成像的特点", wl3sf) },
                { "wl4", Tuple.Create("用电流表和电压表测电阻", wl4sf) },
                { "hx1", Tuple.Create("用长颈漏斗制作二氧化碳", hx1sf) },
                { "hx2", Tuple.Create("氧气的制取", hx2sf) },
                { "hx3", Tuple.Create("一定溶质质量分数的氯化钠溶液的配置", hx3sf) },
                { "sw1", Tuple.Create("观察小鱼尾鳍内血液的流动", sw1sf) },
                { "sw2", Tuple.Create("制作和观察洋葱鳞片叶内表皮细胞临时装片", sw2sf) },
                { "sw3", Tuple.Create("观察种子的结构", sw3sf) },
                { "sw4", Tuple.Create("绿叶在光下制造有机物", sw4sf) }
            };
            foreach (var kvp in experiments)
            {
                if (en == kvp.Key && File.Exists(kvp.Value.Item2))
                {
                    Process.Start(exitbat);
                    ts.Enabled = false;
                    string experimentText = File.ReadAllText(kvp.Value.Item2);
                    MessageBox.Show("您的得分最终为：" + GetAllScore(experimentText), kvp.Value.Item1, MessageBoxButtons.OK);
                    File.Delete(kvp.Value.Item2);
                    Process[] processCurrent = Process.GetProcesses();//得到系统中存在的进程 
                    for (int i = 0; i < processCurrent.Length; i++)
                    {
                        if (processCurrent[i].ProcessName == Process.GetCurrentProcess().ProcessName)
                        {
                            //置顶这个窗口
                            ShowWindow(processCurrent[i].MainWindowHandle, 1);
                            SetForegroundWindow(processCurrent[i].MainWindowHandle);
                            return;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //显示关于信息
            MessageBox.Show("Repack & Modify By Racpast","关于...");
        }
    }
}
