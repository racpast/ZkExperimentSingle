﻿using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace 中考仿真实验重制版4._9
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileSystemWatcher FSWatcher = new FileSystemWatcher();
        private string PhysicalRoot = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Physical";
        private string ChemistryRoot = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Chemistry";
        private string BiologicalRoot = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Biological";
        private string BiologicalExePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\Biological\\Biological.exe";
        private string ChemistryExePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\Chemistry\\Chemistry.exe";
        private string PhysicalExePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\Physical\\Physical.exe";
        private string swsyn_2 = "\",\"controll\":true,\"formQuestion\":false}}|{\"stuId\":\"";
        private string swsyn_3 = "\",\"stuName\":\"";
        private string swsyn_4 = "\",\"examTime\":\"40\",\"subject\":\"生物\",\"u3dProgressCallBack\":\"http://127.0.0.1:17075/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://127.0.0.1:17075/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://127.0.0.1:17075/test/examCmdBroadcast\"}|";
        private string wlsyn_2 = "\"}}|{\"stuId\":\"";
        private string wlsyn_3 = "\",\"stuName\":\"";
        private string wlsyn_4 = "\",\"examTime\":\"40\",\"subject\":\"物理\",\"u3dProgressCallBack\":\"http://127.0.0.1:17075/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://127.0.0.1:17075/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://127.0.0.1:17075/test/examCmdBroadcast\"}|";
        private string hxsyn_2 = "\"}}|{\"stuId\":\"";
        private string hxsyn_3 = "\",\"stuName\":\"";
        private string hxsyn_4 = "\",\"examTime\":\"30\",\"subject\":\"化学\",\"u3dProgressCallBack\":\"http://127.0.0.1:17075/test/u3dProgressCallBack\",\"stuAnswerCallback\":\"http://127.0.0.1:17075/test/stuAnswerCallback\",\"examCmdBroadcast\":\"http://127.0.0.1:17075/test/examCmdBroadcast\"}|";
        private string swsy1_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"绿叶在光下制造有机物\",\"examId\":\"SW012\",\"attributes\":\"biological\",\"examContent\":\"1、取材/2、实验/3、观察/4、整理仪器\"},\"action\":[{\"Order\":2,\"score\":5,\"count\":1,\"id\":\"SW012_01\",\"Operation\":\"Correct\",\"Info\":\"用黑色塑料袋套住天竺葵\"},{\"Order\":11,\"score\":5,\"count\":1,\"id\":\"SW012_02\",\"Operation\":\"Correct\",\"Info\":\"放在黑暗处24小时以上\"},{\"Order\":13,\"score\":5,\"count\":1,\"id\":\"SW012_03\",\"Operation\":\"Correct\",\"Info\":\"选1片叶片，用回形针将黑色纸片固定在叶片的上下两面\"},{\"Order\":7,\"score\":5,\"count\":1,\"id\":\"SW012_04\",\"Operation\":\"Correct\",\"Info\":\"把天竺葵移到阳光下照射2~3小时\"},{\"Order\":9,\"score\":6,\"count\":1,\"id\":\"SW012_05\",\"Operation\":\"Correct\",\"Info\":\"把叶片放入盛有酒精的小烧杯中\"},{\"Order\":18,\"score\":6,\"count\":1,\"id\":\"SW012_06\",\"Operation\":\"Correct\",\"Info\":\"将小烧杯置于装有清水的大烧杯中\"},{\"Order\":20,\"score\":6,\"count\":1,\"id\":\"SW012_07\",\"Operation\":\"Correct\",\"Info\":\"用酒精灯水浴加热\"},{\"Order\":15,\"score\":3,\"count\":1,\"id\":\"SW012_08\",\"Operation\":\"Correct\",\"Info\":\"5分钟叶片变成黄白色\"},{\"Order\":16,\"score\":6,\"count\":1,\"id\":\"SW012_09\",\"Operation\":\"Correct\",\"Info\":\"用镊子取出叶片用清水漂洗\"},{\"Order\":5,\"score\":6,\"count\":1,\"id\":\"SW012_10\",\"Operation\":\"Correct\",\"Info\":\"将叶片平铺在培养皿中\"},{\"Order\":0,\"score\":6,\"count\":1,\"id\":\"SW012_11\",\"Operation\":\"Correct\",\"Info\":\"加入几滴稀碘液\"},{\"Order\":1,\"score\":6,\"count\":1,\"id\":\"SW012_12\",\"Operation\":\"Correct\",\"Info\":\"稍等片刻用清水洗净稀碘液\"},{\"Order\":10,\"score\":20,\"count\":1,\"id\":\"SW012_13\",\"Operation\":\"Correct\",\"Info\":\"观察叶片变化并点击【回答问题】进行正确做答\"},{\"Order\":12,\"score\":5,\"count\":1,\"id\":\"SW012_14\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液缸废渣缸，包括叶片残渣、各个烧杯中的液体、培养皿染色的碘液、清洗器材的液体\"},{\"Order\":6,\"score\":5,\"count\":1,\"id\":\"SW012_15\",\"Operation\":\"Correct\",\"Info\":\"清洗仪器，清洗培养皿和烧杯\"},{\"Order\":8,\"score\":5,\"count\":1,\"id\":\"SW012_16\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":17,\"score\":0,\"count\":1,\"id\":\"SW012_17\",\"Operation\":\"Wrong\",\"Info\":\"暗处理时间不够，叶片中淀粉没转运殆尽，影响实验结果\"},{\"Order\":19,\"score\":0,\"count\":1,\"id\":\"SW012_18\",\"Operation\":\"Wrong\",\"Info\":\"太阳照射时间不够，绿叶没充分进行光合作用\"},{\"Order\":14,\"score\":0,\"count\":1,\"id\":\"SW012_19\",\"Operation\":\"Wrong\",\"Info\":\"不隔水加热，发生爆炸\"},{\"Order\":3,\"score\":0,\"count\":1,\"id\":\"SW012_20\",\"Operation\":\"Wrong\",\"Info\":\"不垫石棉网，烧杯破裂\"},{\"Order\":4,\"score\":0,\"count\":1,\"id\":\"SW012_21\",\"Operation\":\"Wrong\",\"Info\":\"加热后不熄灭酒精灯\"}],\"edition\":{\"edition\":\"4.9\"},\"setting\":{\"showrule\":\"";
        private string swsy2_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"观察种子的结构\",\"examId\":\"SW006\",\"attributes\":\"biological\",\"examContent\":\"1、取材/2、实验/3、观察/4、整理仪器/5、实验附加题作答\"},\"action\":[{\"Order\":7,\"score\":11,\"count\":1,\"id\":\"SW006_01\",\"Operation\":\"Correct\",\"Info\":\"取一粒浸软的菜豆种子放在白瓷盘里，观察它的外形\"},{\"Order\":8,\"score\":11,\"count\":1,\"id\":\"SW006_02\",\"Operation\":\"Correct\",\"Info\":\"用镊子剥开菜豆种子种皮,分开菜豆种子子叶\"},{\"Order\":5,\"score\":4,\"count\":1,\"id\":\"SW006_04\",\"Operation\":\"Correct\",\"Info\":\"用放大镜观察菜豆种子结构的形状、位置，\"},{\"Order\":3,\"score\":11,\"count\":1,\"id\":\"SW006_05\",\"Operation\":\"Correct\",\"Info\":\"取一粒浸软的玉米种子放在白瓷盘里，观察它的外形\"},{\"Order\":4,\"score\":11,\"count\":1,\"id\":\"SW006_06\",\"Operation\":\"Correct\",\"Info\":\"用刀片将玉米种子从中央纵向剖开\"},{\"Order\":1,\"score\":11,\"count\":1,\"id\":\"SW006_07\",\"Operation\":\"Correct\",\"Info\":\"在玉米的一个剖面滴一滴稀碘液\"},{\"Order\":2,\"score\":4,\"count\":1,\"id\":\"SW006_08\",\"Operation\":\"Correct\",\"Info\":\"用放大镜观察染成蓝色和未被染色的剖面结构的形状、位置\"},{\"Order\":0,\"score\":4,\"count\":1,\"id\":\"SW006_09\",\"Operation\":\"Correct\",\"Info\":\"实验残渣放入废液缸废渣缸，包括玉米种子、菜豆种子及菜豆种皮\"},{\"Order\":9,\"score\":4,\"count\":1,\"id\":\"SW006_10\",\"Operation\":\"Correct\",\"Info\":\"清洗仪器，清洗培养皿和白瓷盘\"},{\"Order\":10,\"score\":4,\"count\":1,\"id\":\"SW006_11\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":6,\"score\":25,\"count\":1,\"id\":\"SW006_12\",\"Operation\":\"Correct\",\"Info\":\"点击【回答问题】进行正确作答\"}],\"edition\":{\"edition\":\"4.9\"},\"setting\":{\"showrule\":\"";
        private string swsy3_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"观察小鱼尾鳍内血液的流动\",\"examId\":\"SW007\",\"attributes\":\"biological\",\"examContent\":\"1、制作装片/2、组装调试显微镜/3、观察/4、整理仪器\"},\"action\":[{\"Order\":5,\"score\":7,\"count\":1,\"id\":\"SW007_01\",\"Operation\":\"Correct\",\"Info\":\"从鱼缸里捞出一条小鱼，放在培养皿中\"},{\"Order\":3,\"score\":7,\"count\":1,\"id\":\"SW007_02\",\"Operation\":\"Correct\",\"Info\":\"用湿纱布将小鱼头部的鳃盖和躯干部包裹起来，露出尾部\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"SW007_03\",\"Operation\":\"Correct\",\"Info\":\"把包裹好的小鱼平放在培养皿中，展开尾鳍，使尾鳍贴合在培养皿上\"},{\"Order\":15,\"score\":9,\"count\":1,\"id\":\"SW007_04\",\"Operation\":\"Correct\",\"Info\":\"将载玻片盖在与培养皿贴合的小鱼尾鳍上\"},{\"Order\":13,\"score\":3,\"count\":1,\"id\":\"SW007_05\",\"Operation\":\"Correct\",\"Info\":\"将显微镜放于距离桌面5-7cm处，防止跌落桌面\"},{\"Order\":12,\"score\":6,\"count\":1,\"id\":\"SW007_06\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋，将镜筒升高到一定高度\"},{\"Order\":11,\"score\":7,\"count\":1,\"id\":\"SW007_07\",\"Operation\":\"Correct\",\"Info\":\"转动转换器，使低倍镜对准通光孔\"},{\"Order\":10,\"score\":0,\"count\":1,\"id\":\"SW007_08\",\"Operation\":\"Correct\",\"Info\":\"转动遮光器，调大光圈对准通光孔（系统已默认）\"},{\"Order\":9,\"score\":8,\"count\":1,\"id\":\"SW007_09\",\"Operation\":\"Correct\",\"Info\":\"纱布浸湿，置于培养皿中\"},{\"Order\":20,\"score\":6,\"count\":1,\"id\":\"SW007_10\",\"Operation\":\"Correct\",\"Info\":\"注视目镜，转动反光镜直到整个视野明亮\"},{\"Order\":19,\"score\":3,\"count\":1,\"id\":\"SW007_11\",\"Operation\":\"Correct\",\"Info\":\"待小鱼不再频繁跳动，将包裹好小鱼的培养皿放置在载物台上\"},{\"Order\":18,\"score\":3,\"count\":1,\"id\":\"SW007_12\",\"Operation\":\"Correct\",\"Info\":\"使盖有玻片的尾鳍正对通光孔中心\"},{\"Order\":17,\"score\":7,\"count\":1,\"id\":\"SW007_13\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋使物镜接近装片标本\"},{\"Order\":16,\"score\":7,\"count\":1,\"id\":\"SW007_14\",\"Operation\":\"Correct\",\"Info\":\"轻转粗准焦螺旋，使镜筒缓缓上升，寻找物像。转动细准焦螺旋使物像更加清晰\"},{\"Order\":25,\"score\":3,\"count\":1,\"id\":\"SW007_15\",\"Operation\":\"Correct\",\"Info\":\"将物像移到视野中央，选择合适的区域进行观察\"},{\"Order\":24,\"score\":10,\"count\":1,\"id\":\"SW007_16\",\"Operation\":\"Correct\",\"Info\":\"实验现象正确。视野中可观察到三种不同的血管（注：确认后点击【记录结果】）\"},{\"Order\":23,\"score\":4,\"count\":1,\"id\":\"SW007_17\",\"Operation\":\"Correct\",\"Info\":\"取下培养皿，将小鱼放回鱼缸中。将纱布置入废液缸废渣缸\"},{\"Order\":22,\"score\":3,\"count\":1,\"id\":\"SW007_18\",\"Operation\":\"Correct\",\"Info\":\"清理仪器，清洗培养皿\"},{\"Order\":21,\"score\":3,\"count\":1,\"id\":\"SW007_19\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":8,\"score\":0,\"count\":1,\"id\":\"SW007_20\",\"Operation\":\"Wrong\",\"Info\":\"未把鱼鳃盖和躯干包裹紧，小鱼乱跳\"},{\"Order\":7,\"score\":0,\"count\":1,\"id\":\"SW007_21\",\"Operation\":\"Wrong\",\"Info\":\"未保护好小鱼，导致小鱼死亡\"},{\"Order\":6,\"score\":0,\"count\":3,\"id\":\"SW007_22\",\"Operation\":\"Wrong\",\"Info\":\"未使用载玻片隔离小鱼与载物台导致污染\"},{\"Order\":4,\"score\":0,\"count\":3,\"id\":\"SW007_23\",\"Operation\":\"Wrong\",\"Info\":\"镜筒下降过低，物镜压到小鱼\"},{\"Order\":2,\"score\":0,\"count\":1,\"id\":\"SW007_24\",\"Operation\":\"Wrong\",\"Info\":\"直接在高倍镜下观察小鱼尾鳍的血管，视野较小\"},{\"Order\":0,\"score\":4,\"count\":1,\"id\":\"SW007_25\",\"Operation\":\"Correct\",\"Info\":\"点击【回答问题】进行正确作答\"},{\"Order\":14,\"score\":0,\"count\":1,\"id\":\"SW007_26\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液废渣缸\"}],\"edition\":{\"edition\":\"4.9\"},\"setting\":{\"showrule\":\"";
        private string swsy4_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"制作和观察洋葱鳞片叶内表皮细胞临时装片\",\"examId\":\"SW004\",\"attributes\":\"biological\",\"examContent\":\"1.制作装片/2.组装调试显微镜/3.观察/4.整理仪器\"},\"action\":[{\"Order\":20,\"score\":4,\"count\":1,\"id\":\"SW004_01\",\"Operation\":\"Correct\",\"Info\":\"用洁净的纱布将载玻片和盖玻片擦拭干净\"},{\"Order\":18,\"score\":3,\"count\":1,\"id\":\"SW004_02\",\"Operation\":\"Correct\",\"Info\":\"用滴管在载玻片的中央滴一滴清水\"},{\"Order\":23,\"score\":6,\"count\":1,\"id\":\"SW004_03\",\"Operation\":\"Correct\",\"Info\":\"用刀片在鳞片叶内侧划一个“井”字形，再用镊子沿一角撕取一小块透明薄膜\"},{\"Order\":21,\"score\":6,\"count\":1,\"id\":\"SW004_04\",\"Operation\":\"Correct\",\"Info\":\"用镊子将撕下来的材料置于载玻片的清水中，用镊子使其展平\"},{\"Order\":14,\"score\":8,\"count\":1,\"id\":\"SW004_05\",\"Operation\":\"Correct\",\"Info\":\"用镊子夹起盖玻片，使其一侧先接触载玻片上的水滴，然后缓缓地盖在液滴上\"},{\"Order\":13,\"score\":8,\"count\":1,\"id\":\"SW004_06\",\"Operation\":\"Correct\",\"Info\":\"用滴管把1~2 滴碘液滴在盖玻片的一侧，用吸水纸从盖玻片另一侧引流，使染液浸润标本的全部\"},{\"Order\":16,\"score\":3,\"count\":1,\"id\":\"SW004_07\",\"Operation\":\"Correct\",\"Info\":\"将显微镜放于距离桌面边缘5-7cm处，防止跌落桌面\"},{\"Order\":15,\"score\":6,\"count\":1,\"id\":\"SW004_08\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋，将镜筒升高到一定高度\"},{\"Order\":24,\"score\":6,\"count\":1,\"id\":\"SW004_09\",\"Operation\":\"Correct\",\"Info\":\"转动转换器，使低倍镜对准通光孔\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"SW004_10\",\"Operation\":\"Correct\",\"Info\":\"转动遮光器，调大光圈对准通光孔（系统已默认）\"},{\"Order\":0,\"score\":8,\"count\":1,\"id\":\"SW004_11\",\"Operation\":\"Correct\",\"Info\":\"注视目镜，转动反光镜直到整个视野明亮\"},{\"Order\":7,\"score\":4,\"count\":1,\"id\":\"SW004_12\",\"Operation\":\"Correct\",\"Info\":\"使玻片标本正对通光孔中心\"},{\"Order\":6,\"score\":0,\"count\":1,\"id\":\"SW004_13\",\"Operation\":\"Correct\",\"Info\":\"用压片夹固定住装片\"},{\"Order\":9,\"score\":6,\"count\":1,\"id\":\"SW004_14\",\"Operation\":\"Correct\",\"Info\":\"转动粗准焦螺旋使低倍物镜接近玻片标本\"},{\"Order\":8,\"score\":6,\"count\":1,\"id\":\"SW004_15\",\"Operation\":\"Correct\",\"Info\":\"轻转粗准焦螺旋，使镜筒缓缓上升，寻找物像。转动细准焦螺旋使物像更加清晰。\"},{\"Order\":3,\"score\":3,\"count\":1,\"id\":\"SW004_16\",\"Operation\":\"Correct\",\"Info\":\"物像移到视野中央，选择合适的区域进行观察\"},{\"Order\":2,\"score\":13,\"count\":1,\"id\":\"SW004_17\",\"Operation\":\"Correct\",\"Info\":\"实验现象正确。细胞核被染成黄色，视野中的细胞是单层且无过多气泡（注：确认后点击【记录结果】）\"},{\"Order\":5,\"score\":3,\"count\":1,\"id\":\"SW004_18\",\"Operation\":\"Correct\",\"Info\":\"清理仪器，清洗玻片\"},{\"Order\":4,\"score\":3,\"count\":1,\"id\":\"SW004_19\",\"Operation\":\"Correct\",\"Info\":\"仪器归位\"},{\"Order\":10,\"score\":0,\"count\":3,\"id\":\"SW004_20\",\"Operation\":\"Wrong\",\"Info\":\"没擦玻片，视野中存在杂物\"},{\"Order\":12,\"score\":0,\"count\":3,\"id\":\"SW004_21\",\"Operation\":\"Wrong\",\"Info\":\"染色不充分\"},{\"Order\":11,\"score\":0,\"count\":3,\"id\":\"SW004_22\",\"Operation\":\"Wrong\",\"Info\":\"未选用反光镜，光线不足\"},{\"Order\":19,\"score\":0,\"count\":3,\"id\":\"SW004_23\",\"Operation\":\"Wrong\",\"Info\":\"没有用压片夹固定住装片，装片移动\"},{\"Order\":17,\"score\":0,\"count\":3,\"id\":\"SW004_24\",\"Operation\":\"Wrong\",\"Info\":\"镜筒下降过低，物镜压到装片\"},{\"Order\":22,\"score\":4,\"count\":1,\"id\":\"SW004_25\",\"Operation\":\"Correct\",\"Info\":\"实验残渣倒入废液缸废渣缸，包括洋葱和吸水纸\"}],\"edition\":{\"edition\":\"4.9\"},\"setting\":{\"showrule\":\"";
        private string wlsy1_1 = "{\"fixedEquip\":[{\"chineseName\":\"开关\",\"count\":1,\"type\":\"Switch\",\"shortName\":\"S\"},{\"chineseName\":\"线圈\",\"count\":1,\"type\":\"CoilWL024\",\"shortName\":\"C\"},{\"chineseName\":\"磁铁\",\"count\":1,\"type\":\"HorseshoeMagnet\",\"shortName\":\"H\"},{\"chineseName\":\"铁架\",\"count\":1,\"type\":\"IronSupportWL024\",\"shortName\":\"I\"},{\"chineseName\":\"灵敏电流计\",\"count\":1,\"type\":\"Microdetector\",\"shortName\":\"M\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究导体在磁场中运动时产生感应电流的条件\",\"form\":\"true\",\"examID\":\"WL024\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Electricity\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n线圈（1个）、灵敏电流计（1个）、开关（1个）、导线（若干）、铁架台（1个）、蹄形磁体（1个）\\r\\n实验步骤:\\r\\n（1）连接电路。\\r\\n（2）闭合开关，观察电流计情况。\\r\\n\"},\"action\":[{\"Order\":1,\"score\":6,\"count\":1,\"id\":\"WL024_001\",\"Operation\":\"Correct\",\"Info\":\"将蹄形磁体放置于铁架台上\"},{\"Order\":2,\"score\":6,\"count\":1,\"id\":\"WL024_002\",\"Operation\":\"Correct\",\"Info\":\"将线圈挂在铁架台上\"},{\"Order\":3,\"score\":6,\"count\":1,\"id\":\"WL024_003\",\"Operation\":\"Correct\",\"Info\":\"把灵敏电流计、开关、线圈串联\"},{\"Order\":4,\"score\":10,\"count\":1,\"id\":\"WL024_004\",\"Operation\":\"Correct\",\"Info\":\"断开开关，任意移动线圈，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":5,\"score\":10,\"count\":1,\"id\":\"WL024_005\",\"Operation\":\"Correct\",\"Info\":\"闭合开关，使线圈保持静止，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":6,\"score\":10,\"count\":1,\"id\":\"WL024_006\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中前后移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":7,\"score\":10,\"count\":1,\"id\":\"WL024_007\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中上下移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":8,\"score\":10,\"count\":1,\"id\":\"WL024_008\",\"Operation\":\"Correct\",\"Info\":\"将线圈在蹄形磁体中左右移动，观察电流计指针是否偏转并将实验现象填入表格\"},{\"Order\":9,\"score\":6,\"count\":1,\"id\":\"WL024_009\",\"Operation\":\"Correct\",\"Info\":\"断开开关\"},{\"Order\":10,\"score\":20,\"count\":1,\"id\":\"WL024_010\",\"Operation\":\"Correct\",\"Info\":\"填写实验结论\"},{\"Order\":11,\"score\":6,\"count\":1,\"id\":\"WL024_011\",\"Operation\":\"Correct\",\"Info\":\"整理仪器，结束实验\"}],\"edition\":{\"edition\":\"4.9\"},\"variableEquip\":[],\"setting\":{\"showrule\":\"";
        private string wlsy2_1 = "{\"fixedEquip\":[{\"chineseName\":\"钩码\",\"count\":5,\"type\":\"Gomar\",\"shortName\":\"G\"},{\"chineseName\":\"杠杆\",\"count\":1,\"type\":\"Lever\",\"shortName\":\"L\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究杠杆的平衡条件\",\"form\":\"true\",\"examID\":\"WL019\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Mechanics\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n铁架台和杠杆（带刻度）、钩码\\r\\n实验步骤:\\r\\n（1）调节杠杆两端的螺母,使杠杆在不挂钩码时保持水平并静止,达到平衡状态。\\r\\n（2）给杠杆两测挂上不同数量的钩码,移动钩码的位置,使杠杆重新在水平位置平衡。这时杠杆两侧受到的作用力等于各自钩码所受的重力。\\r\\n（3）设右侧钩码对杠杆施的力为动力F1,左侧钩码对杠杆施的力为阻力F2；测出杠杆平衡时的动力臂l1和阻力臂l2；把F1、F2、l1、l2的数值填入表格中。\\r\\n（4）改变动力F1和动力臂l1的大小,相应调整阻力F2和阻力臂l2,再做几次实验。\"},\"action\":[{\"Order\":1,\"score\":8,\"count\":1,\"id\":\"WL019_001\",\"Operation\":\"Correct\",\"Info\":\"得出结论\"},{\"Order\":1,\"score\":16,\"count\":1,\"id\":\"WL019_002\",\"Operation\":\"Correct\",\"Info\":\"改变动力臂、阻力臂或改变两边的钩码数量重复上述操作两次。\"},{\"Order\":2,\"score\":10,\"count\":1,\"id\":\"WL019_003\",\"Operation\":\"Correct\",\"Info\":\"实验前调节杠杆平衡\"},{\"Order\":3,\"score\":16,\"count\":1,\"id\":\"WL019_004\",\"Operation\":\"Correct\",\"Info\":\"杠杆两边挂上不同数量钩码，调节钩码的位置使杠杆平衡，记录动力、动力臂、阻力、阻力臂\"},{\"Order\":4,\"score\":16,\"count\":1,\"id\":\"WL019_005\",\"Operation\":\"Correct\",\"Info\":\"改变动力臂、阻力臂或改变两边的钩码数量重复上述操作两次。\"},{\"Order\":5,\"score\":24,\"count\":1,\"id\":\"WL019_006\",\"Operation\":\"Correct\",\"Info\":\"计算动力乘以动力臂，阻力乘以阻力臂\"},{\"Order\":6,\"score\":10,\"count\":1,\"id\":\"WL019_007\",\"Operation\":\"Correct\",\"Info\":\"整理器材\"}],\"edition\":{\"edition\":\"4.9\"},\"variableEquip\":[],\"setting\":{\"showrule\":\"";
        private string wlsy3_1 = "{\"fixedEquip\":[{\"chineseName\":\"白纸\",\"count\":1,\"type\":\"WhitePaper\",\"shortName\":\"W\"},{\"chineseName\":\"玻璃板\",\"count\":1,\"type\":\"FlatMirror\",\"shortName\":\"F\"},{\"chineseName\":\"刻度尺\",\"count\":1,\"type\":\"GraduationRuler\",\"shortName\":\"G\"},{\"chineseName\":\"量角器\",\"count\":1,\"type\":\"Protractor\",\"shortName\":\"P\"},{\"chineseName\":\"蜡烛\",\"count\":2,\"type\":\"Candle\",\"shortName\":\"C\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"探究平面镜成像的特点\",\"form\":\"true\",\"examID\":\"WL015\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Optics\",\"examTime\":\"10\",\"examContent\":\"实验目的：通过实验探究,得出平面镜成像的特点\\n实验器材：玻璃板（薄）及支架、刻度尺、量角器、白纸、相同大小的蜡烛两支\\n实验步骤：\\n（1）在水平桌面上铺上白纸,纸上竖立一块玻璃板作为平面镜,并画出玻璃板在白纸上的位置。\\n（2）点燃蜡烛A放在玻璃板的前面,可以看到它在玻璃板后面的像,在纸上记下蜡烛A的位置。\\n（3）再拿一支同样大小但不点燃的蜡烛B,竖立在玻璃板后面移动,直到看上去它跟蜡烛A的像重合,在纸上记下蜡烛B的位置,观察蜡烛B的大小和蜡烛A的像大小是否相同。\\n（4）移动蜡烛A,重做实验。\\n（5）用直线把每次实验中蜡烛A、B在纸上的位置连起来,并用刻度尺分别测量它们到玻璃板的距离,再用量角器量出连线与平面镜夹角的大小,将数据记录在下表中。\"},\"action\":[{\"Order\":2,\"score\":0,\"count\":1,\"id\":\"WL015_010\",\"Operation\":\"Correct\",\"Info\":\"选择实验器材\"},{\"Order\":3,\"score\":4,\"count\":1,\"id\":\"WL015_021\",\"Operation\":\"Correct\",\"Info\":\"在水平桌面上铺上白纸\"},{\"Order\":4,\"score\":4,\"count\":1,\"id\":\"WL015_022\",\"Operation\":\"Correct\",\"Info\":\"纸上竖立一块玻璃板作为平面镜\"},{\"Order\":5,\"score\":4,\"count\":1,\"id\":\"WL015_031\",\"Operation\":\"Correct\",\"Info\":\"点燃蜡烛A\"},{\"Order\":6,\"score\":4,\"count\":1,\"id\":\"WL015_032\",\"Operation\":\"Correct\",\"Info\":\"蜡烛A放在玻璃板的前面\"},{\"Order\":7,\"score\":4,\"count\":1,\"id\":\"WL015_041\",\"Operation\":\"Correct\",\"Info\":\"再拿一支同样大小但不点燃的蜡烛B，竖立在玻璃板后面\"},{\"Order\":8,\"score\":4,\"count\":1,\"id\":\"WL015_042\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛B，直到看上去它跟蜡烛A的像重合\"},{\"Order\":9,\"score\":4,\"count\":1,\"id\":\"WL015_043\",\"Operation\":\"Correct\",\"Info\":\"在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":10,\"score\":10,\"count\":1,\"id\":\"WL015_051\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛A，第一次重做实验并在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":11,\"score\":10,\"count\":1,\"id\":\"WL015_061\",\"Operation\":\"Correct\",\"Info\":\"移动蜡烛A，第二次重做实验并在纸上记下蜡烛A和蜡烛B的位置\"},{\"Order\":12,\"score\":18,\"count\":1,\"id\":\"WL015_081\",\"Operation\":\"Correct\",\"Info\":\"用刻度尺测量物距、相距并正确填入表中\"},{\"Order\":13,\"score\":15,\"count\":1,\"id\":\"WL015_082\",\"Operation\":\"Correct\",\"Info\":\"将观察结果正确填入表中\"},{\"Order\":14,\"score\":10,\"count\":1,\"id\":\"WL015_083\",\"Operation\":\"Correct\",\"Info\":\"填写实验结论\"},{\"Order\":15,\"score\":9,\"count\":1,\"id\":\"WL015_091\",\"Operation\":\"Correct\",\"Info\":\"整理器材\"},{\"Order\":1,\"score\":0,\"count\":1,\"id\":\"WLK20\",\"Operation\":\"Wrong\",\"Info\":\"点燃蜡烛B\"}],\"edition\":{\"edition\":\"4.9\"},\"variableEquip\":[],\"setting\":{\"showrule\":\"";
        private string wlsy4_1 = "{\"fixedEquip\":[{\"chineseName\":\"开关\",\"count\":1,\"type\":\"Switch\",\"shortName\":\"S\"},{\"chineseName\":\"电流表\",\"count\":1,\"type\":\"Ammeter\",\"shortName\":\"A\"},{\"chineseName\":\"电压表\",\"count\":1,\"type\":\"Voltmeter\",\"shortName\":\"V\"},{\"chineseName\":\"滑动变阻器\",\"count\":1,\"type\":\"SliderHostat\",\"shortName\":\"R\"}],\"questions\":{\"drawCircuit\":\"false\",\"examTitle\":\"用电流表和电压表测电阻\",\"form\":\"true\",\"examID\":\"WL006\",\"lineChart\":\"false\",\"attributes\":\"physical\",\"category\":\"Electricity\",\"examTime\":\"10\",\"examContent\":\"实验器材:\\r\\n电池（1.5V2节）、电流表、电压表、滑动变阻器、定值电阻、开关、导线（10根）\\r\\n实验步骤:\\r\\n（1）按图连接电路。\\r\\n（2）调节滑动变阻器的范围，改变电阻两端的电压，测量并记下几组电压和电流值。\\r\\n（3）根据表格数据，正确计算电阻及平均电阻。\"},\"action\":[{\"Order\":7,\"score\":4,\"count\":1,\"id\":\"WL006_002\",\"Operation\":\"Correct\",\"Info\":\"断开开关，按图正确连接电路\"},{\"Order\":6,\"score\":6,\"count\":1,\"id\":\"WL006_003\",\"Operation\":\"Correct\",\"Info\":\"把滑动变阻器调制电阻最大值\"},{\"Order\":8,\"score\":10,\"count\":1,\"id\":\"WL006_004\",\"Operation\":\"Correct\",\"Info\":\"闭合开关，测出电流和电压并填写到表格\"},{\"Order\":9,\"score\":10,\"count\":1,\"id\":\"WL006_005\",\"Operation\":\"Correct\",\"Info\":\"调节滑动变阻器，测出电流和电压并填写到表格\"},{\"Order\":10,\"score\":10,\"count\":1,\"id\":\"WL006_006\",\"Operation\":\"Correct\",\"Info\":\"再次调节滑动变阻器，测出电流和电压并填写到表格\"},{\"Order\":13,\"score\":5,\"count\":1,\"id\":\"WL006_007\",\"Operation\":\"Correct\",\"Info\":\"整理仪器\"},{\"Order\":11,\"score\":20,\"count\":1,\"id\":\"WL006_008\",\"Operation\":\"Correct\",\"Info\":\"正确计算三次电阻值，最后计算平均电阻\"},{\"Order\":1,\"score\":6,\"count\":1,\"id\":\"WL006_010\",\"Operation\":\"Correct\",\"Info\":\"电流表调零\"},{\"Order\":2,\"score\":6,\"count\":1,\"id\":\"WL006_011\",\"Operation\":\"Correct\",\"Info\":\"电压表调零\"},{\"Order\":3,\"score\":6,\"count\":1,\"id\":\"WL006_012\",\"Operation\":\"Correct\",\"Info\":\"正确将电流表串联在电路中\"},{\"Order\":4,\"score\":6,\"count\":1,\"id\":\"WL006_013\",\"Operation\":\"Correct\",\"Info\":\"正确将电压表并联在定值电阻两端\"},{\"Order\":5,\"score\":6,\"count\":1,\"id\":\"WL006_014\",\"Operation\":\"Correct\",\"Info\":\"正确连接滑动变阻器\"},{\"Order\":12,\"score\":5,\"count\":1,\"id\":\"WL006_015\",\"Operation\":\"Correct\",\"Info\":\"断开开关\"},{\"Order\":10,\"score\":0,\"count\":1,\"id\":\"WLK02\",\"Operation\":\"Wrong\",\"Info\":\"电池损坏\"},{\"Order\":13,\"score\":0,\"count\":1,\"id\":\"WLK03\",\"Operation\":\"Wrong\",\"Info\":\"电流表正负接线柱接反\"},{\"Order\":12,\"score\":0,\"count\":1,\"id\":\"WLK04\",\"Operation\":\"Wrong\",\"Info\":\"电流表损坏\"},{\"Order\":14,\"score\":0,\"count\":1,\"id\":\"WLK05\",\"Operation\":\"Wrong\",\"Info\":\"电压表正负接线柱接反\"},{\"Order\":11,\"score\":0,\"count\":1,\"id\":\"WLK08\",\"Operation\":\"Wrong\",\"Info\":\"出现短路或是短路故障，不能快速排除\"}],\"edition\":{\"edition\":\"4.9\"},\"variableEquip\":[{\"chineseName\":\"电源\",\"count\":1,\"type\":\"Battery\",\"shortName\":\"P\",\"voltage\":\"3\"},{\"chineseName\":\"定值电阻\",\"count\":1,\"constantValueRheostat\":\"5\",\"type\":\"ConstantValue\",\"shortName\":\"C\"}],\"setting\":{\"showrule\":\"";
        private string hxsy1_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"实验室制取二氧化碳\",\"examId\":\"HX0032\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"实验步骤：\\n1、清点实验所需器材\\n2、检验装置的气密性\\n3、装入药品\\n4、用向上排空气法收集1瓶气体\\n5、验满\\n6、检验二氧化碳\\n7、整理仪器\"},\"formula\":[],\"action\":[{\"score\":5,\"operationType\":\"true\",\"id\":\"CalciumHydroxide01\",\"Info\":\"打开澄清石灰水，将瓶盖倒放\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid01\",\"Info\":\"打开稀盐酸瓶盖\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid02\",\"Info\":\"将稀盐酸放置在长颈漏斗口，使稀盐酸标签朝向手心\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"DilutedHydrochloricAcid03\",\"Info\":\"盖上稀盐酸瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Erlenmeyer02\",\"Info\":\"将锥形瓶横放，用镊子将大理石放在锥形瓶内\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Erlenmeyer03\",\"Info\":\"慢慢将锥形瓶旋转至竖直，使大理石缓缓滑入锥形瓶底部\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Erlenmeyer04\",\"Info\":\"将锥形瓶平放在桌面，塞紧橡胶塞\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder07\",\"Info\":\"集气瓶瓶口朝上，将玻璃管插入接近集气瓶底\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder08\",\"Info\":\"取出集气瓶中的玻璃管，用玻璃片盖住集气瓶口\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder09\",\"Info\":\"移开玻璃片，使试剂瓶的标签朝向手心，靠在集气瓶口，倒入澄清石灰水\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder10\",\"Info\":\"集气瓶盖上玻璃片，震荡集气瓶\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder11\",\"Info\":\"观察集气瓶中的澄清石灰水是否变浑浊\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder13\",\"Info\":\"集气瓶盖上玻璃片，收集气体\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder17\",\"Info\":\"将点燃的小木条靠近集气瓶口，观察木条熄灭\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow3302\",\"Info\":\"将玻璃弯管润湿的一端插入橡胶塞的另一孔\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow9301\",\"Info\":\"将玻璃弯管与橡胶管连接，再连接另一个玻璃管\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel01\",\"Info\":\"稀盐酸瓶口紧挨长颈漏斗口，沿瓶口将盐酸倒入,使液面没过漏斗下端\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel02\",\"Info\":\"将长颈漏斗下端用水润湿，插入双孔橡胶塞的一孔处\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"LongNeckFunnel03\",\"Info\":\"将双孔橡胶塞塞入锥形瓶，调整长颈漏斗的下端与锥形瓶底部的距离，接近但不接触到锥形瓶底部\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"LongNeckFunnel04\",\"Info\":\"从长颈漏斗注水，观察液面是否下降\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Marble01\",\"Info\":\"打开大理石瓶盖\"},{\"score\":3,\"operationType\":\"true\",\"id\":\"Marble03\",\"Info\":\"盖上大理石瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"RubberStopper03\",\"Info\":\"检查气密性完好后，取下双孔橡胶塞\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"RubberTube101\",\"Info\":\"用止水夹夹住橡胶管\"}],\"edition\":{\"edition\":\"4.9\"},\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"AlcoholLamp\"},{\"quantity\":1,\"equipmentId\":\"Batten\"},{\"quantity\":1,\"equipmentId\":\"CalciumHydroxide\"},{\"quantity\":1,\"equipmentId\":\"DilutedHydrochloricAcid\"},{\"quantity\":1,\"equipmentId\":\"Erlenmeyer\"},{\"quantity\":1,\"equipmentId\":\"GasCylinder\"},{\"quantity\":1,\"equipmentId\":\"GasCylinderCap\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow330\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow930\"},{\"quantity\":1,\"equipmentId\":\"LongNeckFunnel\"},{\"quantity\":1,\"equipmentId\":\"Marble\"},{\"quantity\":1,\"equipmentId\":\"MatchesBox\"},{\"quantity\":1,\"equipmentId\":\"PlasticSink\"},{\"quantity\":1,\"equipmentId\":\"RubberStopper2\"},{\"quantity\":1,\"equipmentId\":\"RubberTube\"},{\"quantity\":1,\"equipmentId\":\"SpringClip\"},{\"quantity\":1,\"equipmentId\":\"Tweezers\"},{\"quantity\":1,\"equipmentId\":\"Water\"}],\"setting\":{\"showrule\":\"";
        private string hxsy2_1 = "{\"conclusion\":[],\"questions\":{\"examTitle\":\"高锰酸钾制取氧气\",\"examId\":\"HX002\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"实验步骤：\\n1、学习仪器连接和检验装置气密性的方法\\n2、获知高锰酸钾分解制氧气的原理和操作程序\"},\"formula\":[],\"action\":[{\"score\":5,\"operationType\":\"true\",\"id\":\"AlcoholLamp03\",\"Info\":\"用帽盖熄灭酒精灯\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"AlcoholLamp04\",\"Info\":\"把木块放铁架台上，把酒精灯放木块上\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Batten01\",\"Info\":\"用酒精灯将木条点燃\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Batten02\",\"Info\":\"将木条熄灭，形成带火星的木条\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Batten03\",\"Info\":\"把带火星的木条伸入集气瓶中，观察木条是否复燃\"},{\"score\":2,\"operationType\":\"true\",\"id\":\"CheckExperimentalSupplies\",\"Info\":\"检查实验用品及仪器\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"Cotton01\",\"Info\":\"在试管口加一团棉花（防止受热时高锰酸钾粉末进入导管造成堵塞）\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder04\",\"Info\":\"导管口有均匀气泡冒出时，将导管一端伸入集气瓶里\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder05\",\"Info\":\"待集气瓶中水排净，在水面下盖上玻璃片\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GasCylinder14\",\"Info\":\"集气瓶装满水，盖上玻璃片，倒放进水槽\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GasCylinder16\",\"Info\":\"将收集气体的集气瓶正放在实验台上\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow12002\",\"Info\":\"把120°的玻璃弯管一端用水润湿，插入带孔橡胶塞，另一端套入橡皮管（检查气密性）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow6001\",\"Info\":\"橡皮管的一端，套入用水润湿60°玻璃管（检查气密性）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"GlassElbow6002\",\"Info\":\"组装好仪器后，将导管的一端浸入水中\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"GlassElbow6003\",\"Info\":\"用热毛巾裹住试管外壁（导管口有气泡冒出）\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"GlassElbow6007\",\"Info\":\"停止加热后，将导管从水中移出\"},{\"score\":2,\"operationType\":\"true\",\"id\":\"GlassElbow6011\",\"Info\":\"将导管的一端浸入水槽的水中\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"MedicineSpoon01\",\"Info\":\"打开高锰酸钾瓶盖，用药匙舀高锰酸钾药品\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"RubberStopper01\",\"Info\":\"用橡胶塞塞住试管口（检查气密性）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"RubberStopper04\",\"Info\":\"用橡胶塞塞住试管口（高锰酸钾制取氧气装药）\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"TestTube07\",\"Info\":\"拿起试管，将试管倾斜，装入药品（1~3匙），并盖好瓶盖\"},{\"score\":4,\"operationType\":\"true\",\"id\":\"TestTube08\",\"Info\":\"将试管夹装到铁架台上，固定好试管\"},{\"score\":5,\"operationType\":\"true\",\"id\":\"TestTube15\",\"Info\":\"将酒精灯帽盖取下，用火柴点燃酒精灯，预热试管\"}],\"edition\":{\"edition\":\"4.9\"},\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"AlcoholLamp\"},{\"quantity\":1,\"equipmentId\":\"Batten\"},{\"quantity\":1,\"equipmentId\":\"Cotton\"},{\"quantity\":1,\"equipmentId\":\"FrostedGlassPiece\"},{\"quantity\":1,\"equipmentId\":\"GlassBottle_Water\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow120\"},{\"quantity\":1,\"equipmentId\":\"GlassElbow60\"},{\"quantity\":1,\"equipmentId\":\"HotTowel\"},{\"quantity\":1,\"equipmentId\":\"IronTand\"},{\"quantity\":1,\"equipmentId\":\"MatchesBox\"},{\"quantity\":1,\"equipmentId\":\"MedicineSpoon\"},{\"quantity\":1,\"equipmentId\":\"PlasticSink\"},{\"quantity\":1,\"equipmentId\":\"PtassiumPermanganate\"},{\"quantity\":1,\"equipmentId\":\"RubberStopper\"},{\"quantity\":1,\"equipmentId\":\"RubberTube\"},{\"quantity\":1,\"equipmentId\":\"TestTube\"},{\"quantity\":1,\"equipmentId\":\"TestTubeHolder_Metal\"},{\"quantity\":1,\"equipmentId\":\"Water\"},{\"quantity\":1,\"equipmentId\":\"Wood\"}],\"setting\":{\"showrule\":\"";
        private string hxsy3_1 = "{\"tableItemDatas\":[{\"line\":1,\"row\":1,\"content\":\"溶液质量/g\"},{\"line\":1,\"row\":2,\"content\":\"溶质质量分数/%\"},{\"line\":1,\"row\":3,\"content\":\"溶质质量/g\"},{\"line\":1,\"row\":4,\"content\":\"溶剂质量/g\"},{\"line\":2,\"row\":1,\"content\":\"50\"},{\"line\":2,\"row\":2,\"content\":\"6\"},{\"line\":2,\"row\":3,\"content\":\"\"},{\"line\":2,\"row\":4,\"content\":\"\"}],\"conclusion\":[],\"questions\":{\"examTitle\":\"一定溶质质量分数的氯化钠溶液的配置\",\"examId\":\"HX0071\",\"attributes\":\"chemistry\",\"examTime\":\"3600\",\"specialEquipment\":[\"\",null],\"examContent\":\"1、配制50g质量分数为6%的氯化钠溶液\"},\"formula\":[],\"action\":[{\"score\":6,\"operationType\":\"true\",\"id\":\"Beaker_50ml06\",\"Info\":\"将称量好的氯化钠倒入烧杯中\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"Beaker_50ml07\",\"Info\":\"将量筒中的蒸馏水缓缓倒入烧杯\"},{\"score\":20,\"operationType\":\"true\",\"id\":\"BiaoGe\",\"Info\":\"正确填写表格\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"ElectronicBalance01\",\"Info\":\"电子秤上垫一张称量纸\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"GlassRod02\",\"Info\":\"用玻璃棒搅拌使氯化钠充分溶解\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"GlassRod03\",\"Info\":\"将玻璃棒插入试剂瓶中\"},{\"score\":8,\"operationType\":\"true\",\"id\":\"GlassRod04\",\"Info\":\"利用玻璃棒引流，将烧杯中的氯化钠溶液装入试剂瓶中盖好瓶盖\"},{\"score\":8,\"operationType\":\"true\",\"id\":\"Glueapplicato01\",\"Info\":\"用胶头滴管滴加药液至所需刻度线\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"LabelStick01\",\"Info\":\"将标签贴在试剂瓶上(6%)\"},{\"score\":0,\"operationType\":\"true\",\"id\":\"LabelStick021\",\"Info\":\"正确计算配制50g6%氯化钠溶液所需的氯化钠及水的体积，并填写表格\"},{\"score\":6,\"operationType\":\"true\",\"id\":\"MeasuringCylinder03\",\"Info\":\"将量筒置于水平桌面上，向量筒内倾倒蒸馏水，至接近所需刻度时停止倾倒\"},{\"score\":10,\"operationType\":\"true\",\"id\":\"WeighingPaper01\",\"Info\":\"用药匙向电子秤上的白纸添加氯化钠晶体\"}],\"edition\":{\"edition\":\"4.9\"},\"specialEquipment\":[{\"quantity\":1,\"equipmentId\":\"Beaker_50mL\"},{\"quantity\":1,\"equipmentId\":\"ElectronicBalance\"},{\"quantity\":1,\"equipmentId\":\"FineMouthBottle\"},{\"quantity\":1,\"equipmentId\":\"GlassRod\"},{\"quantity\":1,\"equipmentId\":\"Glueapplicato\"},{\"quantity\":1,\"equipmentId\":\"LabelStick\"},{\"quantity\":1,\"equipmentId\":\"MeasuringCylinder\"},{\"quantity\":1,\"equipmentId\":\"MedicineSpoon\"},{\"quantity\":1,\"equipmentId\":\"SodiumChloride\"},{\"quantity\":1,\"equipmentId\":\"Water\"},{\"quantity\":1,\"equipmentId\":\"WeighingPaper\"}],\"setting\":{\"showrule\":\"";
        private string ShoworNot = "yes";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PublicContent.BackgroundToKey.Add(1, "100437984_p034.png");
            PublicContent.BackgroundToKey.Add(2, "102146973_p07.jpg");
            PublicContent.BackgroundToKey.Add(3, "102569373_p015.jpg");
            PublicContent.BackgroundToKey.Add(4, "104077877_p028.png");
            PublicContent.BackgroundToKey.Add(5, "104126716_p02.jpg");
            PublicContent.BackgroundToKey.Add(6, "105763950_p010.png");
            PublicContent.BackgroundToKey.Add(7, "105948989_p06.jpg");
            PublicContent.BackgroundToKey.Add(8, "106037496_p035.jpg");
            PublicContent.BackgroundToKey.Add(9, "106726757_p05.jpg");
            PublicContent.BackgroundToKey.Add(10, "108144034_p01.jpg");
            PublicContent.BackgroundToKey.Add(11, "108663332_p019.jpg");
            PublicContent.BackgroundToKey.Add(12, "108981223_p021.jpg");
            PublicContent.BackgroundToKey.Add(13, "109738716_p03.jpg");
            PublicContent.BackgroundToKey.Add(14, "110052281_p030.png");
            PublicContent.BackgroundToKey.Add(15, "110705994_p023.png");
            PublicContent.BackgroundToKey.Add(16, "111798789_p026.jpg");
            PublicContent.BackgroundToKey.Add(17, "111866576_p020.png");
            PublicContent.BackgroundToKey.Add(18, "112553734_p038.jpg");
            PublicContent.BackgroundToKey.Add(19, "113238933_p024.jpg");
            PublicContent.BackgroundToKey.Add(20, "113764106_p033.png");
            PublicContent.BackgroundToKey.Add(21, "113767662_p013.png");
            PublicContent.BackgroundToKey.Add(22, "114189667_p027.jpg");
            PublicContent.BackgroundToKey.Add(23, "114346517_p018.jpg");
            PublicContent.BackgroundToKey.Add(24, "115114998_p037.png");
            PublicContent.BackgroundToKey.Add(25, "115495712_p025.png");
            PublicContent.BackgroundToKey.Add(26, "115868006_p011.jpg");
            PublicContent.BackgroundToKey.Add(27, "115897971_p04.jpg");
            PublicContent.BackgroundToKey.Add(28, "115940188_p014.jpg");
            PublicContent.BackgroundToKey.Add(29, "116438743_p012.jpg");
            PublicContent.BackgroundToKey.Add(30, "116455231_p022.png");
            PublicContent.BackgroundToKey.Add(31, "116670011_p036.png");
            PublicContent.BackgroundToKey.Add(32, "117008988_p09.jpg");
            PublicContent.BackgroundToKey.Add(33, "117066665_p032.jpg");
            PublicContent.BackgroundToKey.Add(34, "117322748_p031.png");
            PublicContent.BackgroundToKey.Add(35, "117495280_p08.jpg");
            PublicContent.BackgroundToKey.Add(36, "117522201_p016.jpg");
            PublicContent.BackgroundToKey.Add(37, "93124349_p029.jpg");
            PublicContent.BackgroundToKey.Add(38, "98031612_p017.png");
            int key = new Random().Next(1, 39);
            base.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/img/" + PublicContent.BackgroundToKey[key])),
                Stretch = Stretch.UniformToFill
            };
            this.ComboSelectSubject.SelectedIndex = 0;
            this.ComboSelectExperiment.Items.Clear();
            this.ComboSelectExperiment.Items.Add("绿叶在光下制造有机物");
            this.ComboSelectExperiment.Items.Add("观察种子的结构");
            this.ComboSelectExperiment.Items.Add("观察小鱼尾鳍内血液的流动");
            this.ComboSelectExperiment.Items.Add("制作和观察洋葱鳞片叶内表皮细胞临时装片");
            this.ComboSelectExperiment.SelectedIndex = 0;
            this.FSWatcher.Path = AppDomain.CurrentDomain.BaseDirectory + "Data\\";
            this.FSWatcher.EnableRaisingEvents = true;
            this.FSWatcher.IncludeSubdirectories = false;
            this.FSWatcher.Filter = "allscore.dat";
            this.FSWatcher.Created += this.FileSystemWatcher_EventHandle;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboSelectSubject_DropDownClosed(object sender, EventArgs e)
        {
            if (this.ComboSelectSubject.SelectionBoxItem.ToString() == "生物")
            {
                this.ComboSelectExperiment.Items.Clear();
                this.ComboSelectExperiment.Items.Add("绿叶在光下制造有机物");
                this.ComboSelectExperiment.Items.Add("观察种子的结构");
                this.ComboSelectExperiment.Items.Add("观察小鱼尾鳍内血液的流动");
                this.ComboSelectExperiment.Items.Add("制作和观察洋葱鳞片叶内表皮细胞临时装片");
                this.ComboSelectExperiment.SelectedIndex = 0;
                return;
            }
            if (this.ComboSelectSubject.SelectionBoxItem.ToString() == "化学")
            {
                this.ComboSelectExperiment.Items.Clear();
                this.ComboSelectExperiment.Items.Add("实验室制取二氧化碳");
                this.ComboSelectExperiment.Items.Add("高锰酸钾制取氧气");
                this.ComboSelectExperiment.Items.Add("一定溶质质量分数的氯化钠溶液的配置");
                this.ComboSelectExperiment.SelectedIndex = 0;
                return;
            }
            if (this.ComboSelectSubject.SelectionBoxItem.ToString() == "物理")
            {
                this.ComboSelectExperiment.Items.Clear();
                this.ComboSelectExperiment.Items.Add("探究导体在磁场中运动时产生感应电流的条件");
                this.ComboSelectExperiment.Items.Add("探究杠杆的平衡条件");
                this.ComboSelectExperiment.Items.Add("探究平面镜成像的特点");
                this.ComboSelectExperiment.Items.Add("用电流表和电压表测电阻");
                this.ComboSelectExperiment.SelectedIndex = 0;
                return;
            }
            this.ComboSelectExperiment.Items.Clear();
            this.ComboSelectExperiment.Items.Add("绿叶在光下制造有机物");
            this.ComboSelectExperiment.Items.Add("观察种子的结构");
            this.ComboSelectExperiment.Items.Add("观察小鱼尾鳍内血液的流动");
            this.ComboSelectExperiment.Items.Add("制作和观察洋葱鳞片叶内表皮细胞临时装片");
            this.ComboSelectExperiment.SelectedIndex = 0;
        }

        private void StartExperiment_Click(object sender, RoutedEventArgs e)
        {
            string ScorePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\allscore.dat";
            string Name = this.TextName.Text;
            string StuID = this.TextID.Text;
            string ExperimentName = this.ComboSelectExperiment.SelectedItem.ToString();
            bool? isChecked = this.ShowSJornot.IsChecked;
            if (File.Exists(ScorePath))
            {
                File.Delete(ScorePath);
            }
            if (isChecked == true)
            {
                this.ShoworNot = "yes";
            }
            else
            {
                this.ShoworNot = "no";
            }
            if (ExperimentName != null)
            {
                if (ExperimentName == "观察种子的结构")
                {
                    PublicContent.OpenProcess(this.BiologicalExePath, string.Concat(new string[]
                    {
                    this.swsy2_1,
                    this.ShoworNot,
                    this.swsyn_2,
                    StuID,
                    this.swsyn_3,
                    Name,
                    this.swsyn_4,
                    this.BiologicalRoot
                    }), false, true);
                }
                if (ExperimentName == "高锰酸钾制取氧气")
                {
                    PublicContent.OpenProcess(this.ChemistryExePath, string.Concat(new string[]
                    {
                    this.hxsy2_1,
                    this.ShoworNot,
                    this.hxsyn_2,
                    StuID,
                    this.hxsyn_3,
                    Name,
                    this.hxsyn_4,
                    this.ChemistryRoot
                    }), false, true);
                }
                if (ExperimentName == "探究杠杆的平衡条件")
                {
                    PublicContent.OpenProcess(this.PhysicalExePath, string.Concat(new string[]
                    {
                    this.wlsy2_1,
                    this.ShoworNot,
                    this.wlsyn_2,
                    StuID,
                    this.wlsyn_3,
                    Name,
                    this.wlsyn_4,
                    this.PhysicalRoot
                    }), false, true);
                }
                if (ExperimentName == "实验室制取二氧化碳")
                {
                    PublicContent.OpenProcess(this.ChemistryExePath, string.Concat(new string[]
                    {
                    this.hxsy1_1,
                    this.ShoworNot,
                    this.hxsyn_2,
                    StuID,
                    this.hxsyn_3,
                    Name,
                    this.hxsyn_4,
                    this.ChemistryRoot
                    }), false, true);
                }
                if (ExperimentName == "绿叶在光下制造有机物")
                {
                    PublicContent.OpenProcess(this.BiologicalExePath, string.Concat(new string[]
                    {
                    this.swsy1_1,
                    this.ShoworNot,
                    this.swsyn_2,
                    StuID,
                    this.swsyn_3,
                    Name,
                    this.swsyn_4,
                    this.BiologicalRoot
                    }), false, true);
                }
                if (ExperimentName == "探究平面镜成像的特点")
                {
                    PublicContent.OpenProcess(this.PhysicalExePath, string.Concat(new string[]
                    {
                    this.wlsy3_1,
                    this.ShoworNot,
                    this.wlsyn_2,
                    StuID,
                    this.wlsyn_3,
                    Name,
                    this.wlsyn_4,
                    this.PhysicalRoot
                    }), false, true);
                }
                if (ExperimentName == "用电流表和电压表测电阻")
                {
                    PublicContent.OpenProcess(this.PhysicalExePath, string.Concat(new string[]
                    {
                    this.wlsy4_1,
                    this.ShoworNot,
                    this.wlsyn_2,
                    StuID,
                    this.wlsyn_3,
                    Name,
                    this.wlsyn_4,
                    this.PhysicalRoot
                    }), false, true);
                }
                if (ExperimentName == "观察小鱼尾鳍内血液的流动")
                {
                    PublicContent.OpenProcess(this.BiologicalExePath, string.Concat(new string[]
                    {
                    this.swsy3_1,
                    this.ShoworNot,
                    this.swsyn_2,
                    StuID,
                    this.swsyn_3,
                    Name,
                    this.swsyn_4,
                    this.BiologicalRoot
                    }), false, true);
                }
                if (ExperimentName == "一定溶质质量分数的氯化钠溶液的配置")
                {
                    PublicContent.OpenProcess(this.ChemistryExePath, string.Concat(new string[]
                    {
                    this.hxsy3_1,
                    this.ShoworNot,
                    this.hxsyn_2,
                    StuID,
                    this.hxsyn_3,
                    Name,
                    this.hxsyn_4,
                    this.ChemistryRoot
                    }), false, true);
                }
                if (ExperimentName == "制作和观察洋葱鳞片叶内表皮细胞临时装片")
                {
                    PublicContent.OpenProcess(this.BiologicalExePath, string.Concat(new string[]
                    {
                    this.swsy4_1,
                    this.ShoworNot,
                    this.swsyn_2,
                    StuID,
                    this.swsyn_3,
                    Name,
                    this.swsyn_4,
                    this.BiologicalRoot
                    }), false, true);
                }
                if (ExperimentName == "探究导体在磁场中运动时产生感应电流的条件")
                {
                    PublicContent.OpenProcess(this.PhysicalExePath, string.Concat(new string[]
                    {
                    this.wlsy1_1,
                    this.ShoworNot,
                    this.wlsyn_2,
                    StuID,
                    this.wlsyn_3,
                    Name,
                    this.wlsyn_4,
                    this.PhysicalRoot
                    }), false, true);
                }
                this.FSWatcher.EnableRaisingEvents = true;
            }
            else
            {
                HandyControl.Controls.MessageBox.Show("请先选择一个实验！", "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
            }
        }

        private void FileSystemWatcher_EventHandle(object sender, FileSystemEventArgs e)
        {
            string ScorePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\allscore.dat";
            while (!MainWindow.IsFileReady(ScorePath))
            {
                Thread.Sleep(100);
            }
            string str = File.ReadAllText(ScorePath);
            HandyControl.Controls.MessageBox.Show("您的得分为：" + str, "得分", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.None);
            if (File.Exists(ScorePath))
            {
                File.Delete(ScorePath);
            }
            this.FSWatcher.EnableRaisingEvents = false;
        }

        public static bool IsFileReady(string filename)
        {
            bool result;
            try
            {
                using (FileStream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    result = (fileStream.Length > 0L);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private void WhatisSJ_Click(object sender, RoutedEventArgs e)
        {
            Whats whats = new Whats();
            whats.Opacity = 0.9;
            whats.Show();
            whats.Focus();
            base.Hide();
        }

        private void ShowAbout_Click(object sender, RoutedEventArgs e)
        {
            about about = new about();
            about.Opacity = 0.9;
            about.Show();
            about.Focus();
            base.Hide();
        }

        private void RefreshBkimg(object sender, RoutedEventArgs e)
        {
            PublicContent.clicktimes++;
            if (PublicContent.clicktimes >= 30)
            {
                HandyControl.Controls.MessageBox.Show("别玩了，赶紧做实验去。", "别玩了", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.None);
                PublicContent.clicktimes = 0;
                return;
            }
            int key = new Random().Next(1, 39);
            base.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/img/" + PublicContent.BackgroundToKey[key])),
                Stretch = Stretch.UniformToFill
            };
        }
    }
}
