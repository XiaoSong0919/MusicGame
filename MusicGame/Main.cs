using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MusicGame
{
    public partial class Main : Form
    {
        public static double dpiX;
        public double zoom,Note_speed;
        string Game_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Game";//我的文档路径
        public string File_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Game/File";
        public Main()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            dpiX = (double)graphics.DpiX;
            zoom = Math.Abs(dpiX / 96);
            //Game_UI f1 = new Game_UI(null, zoom, null, 0, 0);
            //f1.Show();
            //MessageBox.Show(zoom.ToString());
            if (!Directory.Exists(Game_Path))//判断游戏文件夹是否存在
            {
                Directory.CreateDirectory(Game_Path);
                Directory.CreateDirectory(File_Path);
            }
            else
            {
                Thread th1 = new Thread(update_list);
                th1.Start();
            }
        }
        public void update_list()
        {
            int cout = 0;
            DirectoryInfo info = new DirectoryInfo(File_Path);
            DirectoryInfo[] sub_dir =  info.GetDirectories();
            foreach(DirectoryInfo str in sub_dir)
            {
                listBox1.Items.Add(str.ToString());
                cout++;
            }
            label1.Text="已找到"+cout.ToString()+"个谱面";
        }//更新谱面列表
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MusicName.Text = "乐曲名称：" + ReadProFile(listBox1.SelectedItem.ToString(), "&title=");
                label3.Text = "曲师：" + ReadProFile(listBox1.SelectedItem.ToString(), "&artist=");
                //谱师筛选
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_1="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_1=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_2="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_2=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_3="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_3=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_4="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_4=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_5="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_5=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_6="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_6=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_7="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_7=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_8="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_8=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_9="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_9=");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&des_10="))
                {
                    label4.Text = label4.Text + " " + ReadProFile(listBox1.SelectedItem.ToString(), "&des_10=");
                }
                //BPM筛选
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&wholebpm="))
                {
                    bpm.Text = "BPM：" + ReadProFile(listBox1.SelectedItem.ToString(), "&wholebpm=");
                }
                else
                {
                    if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_5="))
                    {
                        bpm.Text = "BPM：" + ReadProFile(listBox1.SelectedItem.ToString(), "&inote_5=").Replace("(", "").Replace(")", "");
                    }
                    else if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_6="))
                    {
                        bpm.Text = "BPM：" + ReadProFile(listBox1.SelectedItem.ToString(), "&inote_6=").Replace("(", "").Replace(")", "");
                    }
                }
                //
                comboBox1.Items.Clear();
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_2"))
                {
                    comboBox1.Items.Add("Basic");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_3"))
                {
                    comboBox1.Items.Add("Advanced");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_4"))
                {
                    comboBox1.Items.Add("Expert");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_5"))
                {
                    comboBox1.Items.Add("Master");
                }
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_6"))
                {
                    comboBox1.Items.Add("Re:Master");
                }
            }
            
        }//歌曲选择
        public string ReadProFile(string MusicName,string keyword)
        {
            foreach(string line in File.ReadLines(File_Path + "/" + MusicName + "/maidata.txt"))
            {
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return line.Replace(keyword,"");
                }
            }
            return null;
        }//读取谱面文件
        public bool ReadBoolProFile(string MusicName, string keyword)
        {
            foreach (string line in File.ReadLines(File_Path + "/" + MusicName + "/maidata.txt"))
            {
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }//搜索关键字是否存在
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//获取难度定数
        {

            if(comboBox1.SelectedItem.ToString() == "Basic")
            {
                if(ReadBoolProFile(listBox1.SelectedItem.ToString(), "&lv_2="))
                {
                    level.Text = level.Text + ReadProFile(listBox1.SelectedItem.ToString(), "&lv_2=");
                }
                else
                {
                    MessageBox.Show("读取谱面文件失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    level.Text = level.Text + "Null";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Advanced")
            {
               if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&lv_3="))
                {
                    level.Text = level.Text + ReadProFile(listBox1.SelectedItem.ToString(), "&lv_3=");
                }
                else
                {
                    MessageBox.Show("读取谱面文件失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    level.Text = level.Text + "Null";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Expert")
            {
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&lv_4="))
                {
                    level.Text = level.Text + ReadProFile(listBox1.SelectedItem.ToString(), "&lv_4=");
                }
                else
                {
                    MessageBox.Show("读取谱面文件失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    level.Text = level.Text + "Null";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Master")
            {
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&lv_5="))
                {
                    level.Text = level.Text + ReadProFile(listBox1.SelectedItem.ToString(), "&lv_5=");
                }
                else
                {
                    MessageBox.Show("读取谱面文件失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    level.Text = level.Text + "Null";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Re:Master")
            {
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&lv_6="))
                {
                    level.Text = level.Text + ReadProFile(listBox1.SelectedItem.ToString(), "&lv_6=");
                }
                else
                {
                    MessageBox.Show("读取谱面文件失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    level.Text = level.Text + "Null";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string BPM = null;
            if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&wholebpm="))
            {
                BPM = ReadProFile(listBox1.SelectedItem.ToString(), "&wholebpm=");
            }
            else
            {
                if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_5="))
                {
                    BPM = ReadProFile(listBox1.SelectedItem.ToString(), "&inote_5=").Replace("(", "").Replace(")", "");
                }
                else if (ReadBoolProFile(listBox1.SelectedItem.ToString(), "&inote_6="))
                {
                    BPM = ReadProFile(listBox1.SelectedItem.ToString(), "&inote_6=").Replace("(", "").Replace(")", "");
                }
            }
            if (listBox1.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                Game_UI f1 = new Game_UI(listBox1.SelectedItem.ToString(), zoom,comboBox1.SelectedItem.ToString(),Convert.ToDouble(BPM),Note_speed);
                f1.Show();
            }
            else if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("您还没有选择乐曲！","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("您还没有选择乐曲难度！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//拉出界面并传参
    }
}
