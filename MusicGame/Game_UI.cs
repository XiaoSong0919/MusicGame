using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGame
{
    public partial class Game_UI : Form
    {
        Main main = new Main();
        //创建note实例
        int k1_combo = 0;
        int k2_combo = 0;
        int k3_combo = 0;
        int k4_combo = 0;
        int k1_combo1 = 0;
        int k2_combo1 = 0;
        int k3_combo1 = 0;
        int k4_combo1 = 0;
        Stopwatch stopWatch = new Stopwatch();
        SoundPlayer sp = new SoundPlayer();
        List<string> k1_time = new List<string>();//采样点
        List<string> k2_time = new List<string>();
        List<string> k3_time = new List<string>();
        List<string> k4_time = new List<string>();
        Dictionary<string, string> k1 = new Dictionary<string, string>();//采样点对应NOTE类型
        Dictionary<string, string> k2 = new Dictionary<string, string>();
        Dictionary<string, string> k3 = new Dictionary<string, string>();
        Dictionary<string, string> k4 = new Dictionary<string, string>();
        Dictionary<string, Button> k1_button = new Dictionary<string, Button>();//对应NOTE
        Dictionary<string, Button> k2_button = new Dictionary<string, Button>();
        Dictionary<string, Button> k3_button = new Dictionary<string, Button>();
        Dictionary<string, Button> k4_button = new Dictionary<string, Button>();
        public string File_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Game/File";
        double zoom, BPM, per_beat, per_part,Total_time;//放大倍数，BPM,每拍长度，每小节长度
        double Note_speed;
        double down_time;
        int combo = 0,note_cout = 0;//连击数
        string type, hold_start_type, hold_end_type, MusicName, Level;
        /// <summary>
        /// /////////////键盘检测
        bool key1_a_up = true;
        bool key1_a_down = false;
        bool key1_b_up = true;
        bool key1_b_down = false;

        bool key2_a_up = true;
        bool key2_a_down = false;
        bool key2_b_up = true;
        bool key2_b_down = false;

        bool key3_a_up = true;
        bool key3_a_down = false;
        bool key3_b_up = true;
        bool key3_b_down = false;

        bool key4_a_up = true;
        bool key4_a_down = false;
        bool key4_b_up = true;
        bool key4_b_down = false;

        bool key5_a_up = true;
        bool key5_a_down = false;
        bool key5_b_up = true;
        bool key5_b_down = false;

        bool key6_a_up = true;
        bool key6_a_down = false;
        bool key6_b_up = true;
        bool key6_b_down = false;

        bool key7_a_up = true;
        bool key7_a_down = false;
        bool key7_b_up = true;
        bool key7_b_down = false;

        bool key8_a_up = true;
        bool key8_a_down = false;
        bool key8_b_up = true;
        bool key8_b_down = false;
        /// </summary>
        List<string> ProFile = new List<string>();//谱面
        List<double> Note_time = new List<double>();//Note击打时刻
        List<string> Note = new List<string>();

        public Game_UI(string musicname, double Main_zoom, string level, double bpm,double note_speed)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            zoom = Main_zoom;
            MusicName = musicname;
            Level = level;
            BPM = bpm;
            per_beat = (60 / BPM) * 1000;//每拍长度
            Note_speed = note_speed;
            LoadProFile();
        }
        public void LoadProFile()//加载谱面
        {
            string keyword = null, str = null;
            bool is_found = false;
            if (Level == "Basic")
            {
                keyword = "&inote_2=";
            }
            else if (Level == "Advanced")
            {
                keyword = "&inote_3=";
            }
            else if (Level == "Expert")
            {
                keyword = "&inote_4=";
            }
            else if (Level == "Master")
            {
                keyword = "&inote_5=";
            }
            else if (Level == "Re:Master")
            {
                keyword = "&inote_6=";
            }
            foreach (string line in File.ReadLines(File_Path + "/" + MusicName + "/maidata.txt"))
            {
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    str = line.Replace(keyword, "").Replace("(" + BPM.ToString() + ")", "");
                    is_found = true;
                    continue;
                }
                if (is_found == true)
                {
                    str = str + line;
                    if (line == "E")
                    {
                        break;
                    }
                }
            }
            string[] Str = str.Split(',');
            int n = 0;
            foreach (string line in Str)//导入谱面到List
            {
                ProFile.Add(line);
            }
            foreach(string line in ProFile)
            {
                if(line.IndexOf("{", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string[] str_tmp = line.Split('}');
                    per_part = (per_beat * 4) / Convert.ToDouble(str_tmp[0]);
                    if(str_tmp[1] != null)
                    {
                        Total_time = Total_time + n * per_part;
                        Note_time.Add(n * per_part);
                        Note.Add(str_tmp[1]);
                        n = 1;
                    }
                    else
                    {
                        Total_time = Total_time + n * per_part;
                        n = 1;
                    }
                    
                }
                else
                {

                }
            }
        }




        private void Game_UI_Load(object sender, EventArgs e)
        {
            MessageBox.Show(MusicName);
            Point p2 = new Point(Convert.ToInt32(632 * zoom), Convert.ToInt32(377 * zoom));
            //Graphics graphics = this.CreateGraphics();
            //double dpiX = (double)graphics.DpiX;
            //zoom = Math.Abs(dpiX / 96);
            down_time = (((518 * zoom - (8 * zoom)) / (2 * set_speed * zoom)) * 10);//计算提前出现note时机(单位:ms)
            MessageBox.Show(down_time.ToString());
            //button1.FlatAppearance.BorderSize = button2.FlatAppearance.BorderSize = button3.FlatAppearance.BorderSize = button4.FlatAppearance.BorderSize = button5.FlatAppearance.BorderSize = Convert.ToInt32(2 * zoom);
            try
            {
                //MessageBox.Show(zoom.ToString());
                sp.SoundLocation = main.File_Path + "/music.wav";
                sp.Play();
                Button newButton = new Button();//创建一个名为newButton的新按钮
                Point p = new Point(600, 1200);
                newButton.Width = Convert.ToInt32(80 * zoom);
                newButton.Height = Convert.ToInt32(8 * zoom);
                newButton.Text = "";
                newButton.BackColor = break1.BackColor;
                newButton.Location = p;
                newButton.FlatStyle = 0;
                newButton.FlatAppearance.BorderSize = 2;
                newButton.BringToFront();
                Controls.Add(newButton);
                Thread th1 = new Thread(() => Button_Animation(newButton, "1"));
                th1.Start();
                stopWatch.Start();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("找不到音乐文件\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//窗体加载
        /// ////////////////////////////////函数实现
        public void Game_Load()
        {

            //Thread th1 = new Thread(loadtxt);
            //th1.IsBackground = true;
            //th1.Start();
        }
        public void Note_Void(PictureBox start, PictureBox main, PictureBox end, string note_type, int note_id,int key_id)
        {//start：控制的控件；main：Hold主体；end：Hold尾部；note_type：Note类型；note_id：Note序数，从1开始；key_id：对应轨道
            bool is_holding = false;
            while (true)
            {
                double sw_time = stopWatch.ElapsedMilliseconds;
                if (combo == note_id - 1)
                {
                    if(key_id == 1)
                    {
                        if(key1_a_down == true || key1_b_down == true)
                        {
                            if(note_type == "tap" || note_type == "break")
                            {
                                judge_system(sw_time);
                                Controls.Remove(start);
                                break;
                            }
                            else if(note_type == "hold" || note_type == "break_hold")//Hold 头判
                            {
                                if (is_holding == false)
                                {
                                    is_holding = true;
                                    judge_system(sw_time);
                                }
                            }
                        }
                        if(key1_a_down == false && key1_b_down == false)//Hold FAST判
                        {
                            if (note_type == "hold" || note_type == "break_hold")
                            {
                                is_holding = false;
                                hold
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
        public Button new_note(string note_type)
        {
            Button newButton = new Button();//创建一个名为newButton的新按钮
            Point p = new Point(600, 1200);
            newButton.Width = Convert.ToInt32(80 * zoom);
            newButton.Height = Convert.ToInt32(8 * zoom);
            newButton.Text = "";
            if (note_type == "tap")
            {
                newButton.BackColor = tap1.BackColor;
            }
            else if (note_type == "break" || note_type == "break_hold")
            {
                newButton.BackColor = break1.BackColor;
            }
            else if (note_type == "hold")
            {
                newButton.BackColor = hold1.BackColor;
            }
            newButton.Location = p;
            newButton.FlatStyle = 0;
            newButton.FlatAppearance.BorderSize = 2;
            newButton.BringToFront();
            Controls.Add(newButton);
            return newButton;
        }//新建NOTE实例
        private void break1_Click(object sender, EventArgs e)
        {
            //Button newButton = new Button();//创建一个名为newButton的新按钮
            //Point p = new Point(600,1200);
            //newButton.Width = 80;
            //newButton.Height = 8;
            //newButton.Text = "";
            //newButton.BackColor = break1.BackColor;
            //newButton.Location = p;
            //newButton.FlatStyle = 0;
            //newButton.FlatAppearance.BorderSize = 2;
            //newButton.BringToFront();
            //Controls.Add(newButton);
            //Thread th1 = new Thread(() => Button_Animation(newButton, "1"));
            //th1.IsBackground = true;
            //th1.Start();



        }
        public void Button_Animation(Button b1, string key)
        {
            b1.BringToFront();
            int x = 0;
            int y = 0;
            //double y2 = 0;
            if (key == "1")
            {
                x = Convert.ToInt32(28 * zoom);
            }
            else if (key == "2")
            {
                x = Convert.ToInt32(108 * zoom);
            }
            else if (key == "3")
            {
                x = Convert.ToInt32(188 * zoom);
            }
            else if (key == "4")
            {
                x = Convert.ToInt32(268 * zoom);
            }
            while (true)
            {
                if (y >= (510 * zoom))
                {
                    stopWatch.Stop();
                    b1.Visible = false;
                    break;
                }
                Point p = new Point(x, y);
                b1.Location = p;
                y += Convert.ToInt32((2 * set_speed * zoom));
                Thread.Sleep(10);
            }
        }//NOTE动画

        public string judge_system(double sw_time)//判定系统
        {
            return null;
        }

        public string hold_judge_system(double sw_time)//尾判系统
        {
            return null;
        }


        //监听键盘
        private void Game_UI_KeyDown(object sender, KeyEventArgs e)
        {
            //############################主键
            if (e.KeyCode == Keys.A)
            {
                key1_a_up = false;
                key1_a_down = true;
            }
            if (e.KeyCode == Keys.S)
            {
                key2_a_up = false;
                key2_a_down = true;
            }
            if (e.KeyCode == Keys.D)
            {
                key3_a_up = false;
                key3_a_down = true;
            }
            if (e.KeyCode == Keys.F)
            {
                key4_a_up = false;
                key4_a_down = true;
            }
            //#######################辅助键
            if (e.KeyCode == Keys.Q)
            {
                key1_b_up = false;
                key1_b_down = true;
            }
            if (e.KeyCode == Keys.W)
            {
                key2_b_up = false;
                key2_b_down = true;
            }
            if (e.KeyCode == Keys.E)
            {
                key3_b_up = false;
                key3_b_down = true;
            }
            if (e.KeyCode == Keys.R)
            {
                key4_b_up = false;
                key4_b_down = true;
            }
        }
        private void Game_UI_KeyUp(object sender, KeyEventArgs e)
        {
            //############################主键
            if (e.KeyCode == Keys.A)
            {
                key1_a_up = true;
                key1_a_down = false;
            }
            if (e.KeyCode == Keys.S)
            {
                key2_a_up = true;
                key2_a_down = false;
            }
            if (e.KeyCode == Keys.D)
            {
                key3_a_up = true;
                key3_a_down = false;
            }
            if (e.KeyCode == Keys.F)
            {
                key4_a_up = true;
                key4_a_down = false;
            }
            //#######################辅助键
            if (e.KeyCode == Keys.Q)
            {
                key1_b_up = true;
                key1_b_down = false;
            }
            if (e.KeyCode == Keys.W)
            {
                key2_b_up = true;
                key2_b_down = false;
            }
            if (e.KeyCode == Keys.E)
            {
                key3_b_up = true;
                key3_b_down = false;
            }
            if (e.KeyCode == Keys.R)
            {
                key4_b_up = true;
                key4_b_down = false;
            }
        }
        //监听键盘end
    }
}