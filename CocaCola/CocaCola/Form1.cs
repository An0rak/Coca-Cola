using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CocaCola
{
    public partial class Form1 : Form
    {

        string[,] choices = new string[10, 4] { { "UŽIVAM U SVAKOM TRENUTKU I TRUDIM SE DA ŽIVIM LAK ŽIVOT, BEZ STRESA", "ŽIVIM BRZO I PAŽLJIVO PLANIRAM SVOJE KAKO BIH POSTIGAO/POSTIGLA SVE ŠTO JE POTREBNO", "POSVEĆEN/A SAM PORODICI I NAJVIŠE VREMENA PROVODIM SA NJIMA", "KAO NEOGRANIČENO VREME KOJE MOGU DA PROVEDEM SA PRIJATELJIMA" }, 
                                                { "PROVODIM VREME SA PRIJATELJIMA UZ LAGANU VEČERU", "GLEDAM SVOJ OMILJENI FILM SA PARTNEROM", "POSVETIM SE U POTPUNOSTI SVOJOJ PORODICI I ZAJEDNIČKIM AKTIVNOSTIMA", "IZAĐEM U NOĆNI KLUB I PROVODIM SE DO KASNO U NOĆ" }, 
                                                { "ODLAZAK NA SKIJANJE ILI ODMOR SA PRIJATELJIMA", "PAR DANA U NEKOM OD EVROPSKIH GRADOVA, SAMO JA I PARTNER", "PORODIČNO LETOVANJE U MESTU SA PRELEPIM PEŠČANIM PLAŽAMA", "RANAC NA LEĐA I GDE ME PUT ODNESE" }, 
                                                { "NAJBOLJA ITALIJANSKA PICA, SPREMLJENA PO MOM UKUSU", "MIX SPECIJALITETA U OTMENOM RESTORANU", "DOMAĆA SRPSKA HRANA SPREMLJENA KOD KUĆE", "ROŠTILJ NA PIKNIKU ILI IZLET U PRIRODI" }, 
                                                { "SPREMOM OMILJENU HRANU I VEČERU ZA SVOJE UKUĆANE", "IZNENADIM SVOG DRAGOG/DRAGU I ULEPŠAM MU/JOJ DAN", "TOKOM NOVOGODIŠNJIH PRAZNIKA KADA SE SVI OKUPIMO I DELIMO POKLONE", "KADA SE SREDIM I IZGLEDAM KAO MILLION DOLARA" }, 
                                                { "TOKOM PRAZNIKA I TADA SMO SVI NA OKUPU", "RETKO MI DOLAZE GOSTI, UGLAVNOM SMO PORODICA I JA", "ŽIVIM SA PARTNEROM I VIŠE VOLIMO DA IZAĐEMO DO GRADA", "KADA SLAVIM ROĐENDAN PROVODIMO SE UZ MUZIKU I PIĆE" }, 
                                                { "KADA ODMARAM U SLATKIM TRENUCIMA KOJE IMAM SAMO ZA SEBE", "TOKOM LETA UZ 3 KOCKE LEDA, MOJE SAVRŠENO OSVEŽENJE", "UZ DOBAR OBROK ILI NAKON OBROKA", "UŽIVAM U SVAKOM GUTLJAJU, COCA-COLA JE MOJE OMILJENO PIĆE" }, 
                                                { "SVAKOG DANA", "2-3 PUTA NEDELJNO", "PAR PUTA ILI JEDNOM MESEČNO", "KONZUMIRAM KADA SAM SA DRUŠTVOM" }, 
                                                { "DA SAM ODGOVORNA/AN PORODIČNA ŽENA/ČOVEK", "DA IMAM MALO VREMENA I DA SAM VEOMA ODAN/A POSLU", "DA SAM VELIKI PRIJATELJ I PRAVIM DOBRA OKUPLJANJA I ŽURKE", "DA IMAM NAJBOLJEG PARTNERA AN SVETU I  DA SMO ODLIČAN PAR" }, 
                                                { "U NAJBLIŽOJ RADNJI", "KAD OBAVLJAM NEDELJNE KUPOVINE", "U KAFIĆU ILI RESTORANU", "U MOJOJ KUĆI UVEK IMA COCA-COLE, KUPUJEM JE U SVAKOJ PRILICI" } };
        int[] myanswers = new int[10];

        Panel panel = new Panel();
        RadioButton choice1 = new RadioButton();
        RadioButton choice2 = new RadioButton();
        RadioButton choice3 = new RadioButton();
        RadioButton choice4 = new RadioButton();
        Button next = new Button();
        Button back = new Button();
        Button start = new Button();
        TextBox mail_TextBox = new TextBox();
        Button send = new Button();
        Image start_Image = Image.FromFile("../../Images/Start/Back.jpg");
        Image startBF = Image.FromFile("../../Images/Start/StartF.png");
        Image startBL = Image.FromFile("../../Images/Start/StartL.png");
        Image[] question_Images = new Image[10];
        string mail = "";
        

        Image Solution1 = Image.FromFile("../../Images/One.jpg");
        Image Solution2 = Image.FromFile("../../Images/Onehalf.jpg");
        Image Solution3 = Image.FromFile("../../Images/Multipack.jpg");
        Image Solution4 = Image.FromFile("../../Images/Two.jpg");

        int one = 0;
        int onehalf = 0;
        int multipack = 0;
        int two = 0;

        int k = -1;

        int Max()
        {
            int a = Math.Max(one, onehalf);
            int b = Math.Max(multipack, two);
            return Math.Max(a, b);
        }

        public Form1()
        {
            InitializeComponent();
            next.Click += next_Click;
            back.Click += back_Click;
            start.Click += start_Click;
            send.Click += send_Click;
            choice1.Click += choice1_Click;
            choice2.Click += choice2_Click;
            choice3.Click += choice3_Click;
            choice4.Click += choice4_Click;
            mail_TextBox.Click += mail_TextBox_Click;
            for (int i = 0; i < 10; i++)
            {
                question_Images[i] = Image.FromFile("../../Images/Question" + (i+1).ToString() + "/Back.jpg");
            }
        }

        void NextorPreviousQuestion(bool t)
        {
            if (t)
            {
                k++;
            }
            else
            {
                k--;
            }

            Controls.Clear();

            next.Location = new Point(1920 - 150, 1080 - 150);
            next.Size = new Size(100, 100);
            next.BackColor = Color.Transparent;
            next.FlatStyle = FlatStyle.Flat;
            next.FlatAppearance.BorderSize = 0;
            next.BackgroundImage = Image.FromFile("../../Images/Next.png");
            if (k != 0)
            {
                back.Location = new Point(1920 - 950, 1080 - 150);
                back.Size = new Size(100, 100);
                back.BackColor = Color.Transparent;
                back.BackgroundImage = Image.FromFile("../../Images//Back.png");
                back.FlatStyle = FlatStyle.Flat;
                back.FlatAppearance.BorderSize = 0;
                Controls.Add(back);
            }


            panel.Location = new Point(1100, 400);
            panel.Size = new Size(510, 500);
            panel.BackColor = Color.Transparent;

            //Choice1
            choice1.Location = new Point(5, 10);
            choice1.Size = new Size(500, 100);
            choice1.Appearance = Appearance.Button;
            choice1.BackColor = Color.Transparent;
            choice1.Checked = false;
            choice1.BackColor = Color.Transparent;
            choice1.FlatStyle = FlatStyle.Flat;
            choice1.FlatAppearance.BorderSize = 0;
            choice1.ForeColor = Color.Red;
            choice1.Font = new Font(choice1.Font.FontFamily, 18);
            choice1.Text = "1) " + choices[k, 0];
            //Choice2
            choice2.Location = new Point(5, 120);
            choice2.Size = new Size(500, 100);
            choice2.Appearance = Appearance.Button;
            choice2.BackColor = Color.Transparent;
            choice2.Checked = false;
            choice2.BackColor = Color.Transparent;
            choice2.FlatStyle = FlatStyle.Flat;
            choice2.FlatAppearance.BorderSize = 0;
            choice2.ForeColor = Color.Red;
            choice2.Font = new Font(choice2.Font.FontFamily, 18);
            choice2.Text = "2) " + choices[k, 1];
            //Choice3
            choice3.Location = new Point(5, 230);
            choice3.Size = new Size(500, 100);
            choice3.Appearance = Appearance.Button;
            choice3.BackColor = Color.Transparent;
            choice3.Checked = false;
            choice3.BackColor = Color.Transparent;
            choice3.FlatStyle = FlatStyle.Flat;
            choice3.FlatAppearance.BorderSize = 0;
            choice3.ForeColor = Color.Red;
            choice3.Font = new Font(choice3.Font.FontFamily, 18);
            choice3.Text = "3) " + choices[k, 2];
            //Choice4
            choice4.Location = new Point(5, 340);
            choice4.Size = new Size(500, 100);
            choice4.Appearance = Appearance.Button;
            choice4.BackColor = Color.Transparent;
            choice4.Checked = false;
            choice4.BackColor = Color.Transparent;
            choice4.FlatStyle = FlatStyle.Flat;
            choice4.FlatAppearance.BorderSize = 0;
            choice4.ForeColor = Color.Red;
            choice4.Font = new Font(choice4.Font.FontFamily, 18);
            choice4.Text = "4) " + choices[k, 3];

            panel.Controls.Add(choice1);
            panel.Controls.Add(choice2);
            panel.Controls.Add(choice3);
            panel.Controls.Add(choice4);

            Controls.Add(next);
            Controls.Add(panel);

                       
            BackgroundImage = question_Images[k];

        }

        void Start()
        {
            one = 0;
            onehalf = 0;
            multipack = 0;
            two = 0;
            mail = "";
            k = -1;

            Controls.Clear();
            BackgroundImage = start_Image;
            start.Size = new Size(520, 100);
            start.Location = new Point(700, 920);
            start.FlatStyle = FlatStyle.Flat;
            start.BackColor = Color.Transparent;
            start.BackgroundImage = startBF;
            start.FlatAppearance.BorderSize = 0;

            Controls.Add(start);
        }
         
        void Mail()
        {
            Controls.Clear();
            mail_TextBox.Size = new Size(600, 200);
            mail_TextBox.Location = new Point(0, 0);
            send.Location = new Point(660, 390);
            send.Size = new Size(600, 100);
            send.BackColor = Color.Transparent;
            send.FlatStyle = FlatStyle.Popup;
            send.Text = "NA POCETAK";
            Controls.Add(mail_TextBox);
            Controls.Add(send);
            int max = Max();
            if(max == one)
            {
                BackgroundImage = Solution1;
            }
            if (max == onehalf)
            {
                BackgroundImage = Solution2;
            }
            if (max == multipack)
            {
                BackgroundImage = Solution3;
            }
            if (max == two)
            {
                BackgroundImage = Solution4;
            }
            mail = mail_TextBox.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            Start();
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.BackgroundImage = startBL;
            NextorPreviousQuestion(true);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (!choice1.Checked && !choice2.Checked && !choice3.Checked && !choice4.Checked)
            {
                
            }
            else
            {
                if (choice1.Checked)
                {
                    myanswers[k] = 1;
                }
                if (choice2.Checked)
                {
                    myanswers[k] = 2;
                }
                if (choice3.Checked)
                {
                    myanswers[k] = 3;
                }
                if (choice4.Checked)
                {
                    myanswers[k] = 4;
                }
                if (k >= 9)
                {
                    Update1(); Update2(); Update3(); Update4(); Update5(); Update6(); Update7(); Update8(); Update9(); Update10();
                    Mail();
                }
                else
                {
                    NextorPreviousQuestion(true);
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            NextorPreviousQuestion(false);
        }

        private void send_Click(object sender, EventArgs e)
        {
            Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
            foreach (Process onscreenProcess in oskProcessArray)
            {
                onscreenProcess.Kill();
            }
            Start();
        }

        private void mail_TextBox_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");
            Process onScreenKeyboardProc = System.Diagnostics.Process.Start(onScreenKeyboardPath);
        }

        private void choice1_Click(object sender, EventArgs e)
        {
            choice1.Checked = true;
            choice2.Checked = false;
            choice3.Checked = false;
            choice4.Checked = false;
            choice1.BackColor = Color.Red;
            choice1.ForeColor = Color.White;
            choice2.BackColor = Color.Transparent;
            choice2.ForeColor = Color.Red;
            choice3.BackColor = Color.Transparent;
            choice3.ForeColor = Color.Red;
            choice4.BackColor = Color.Transparent;
            choice4.ForeColor = Color.Red;
        }
        private void choice2_Click(object sender, EventArgs e)
        {
            choice1.Checked = false;
            choice2.Checked = true;
            choice3.Checked = false;
            choice4.Checked = false;
            choice1.BackColor = Color.Transparent;
            choice1.ForeColor = Color.Red;
            choice2.BackColor = Color.Red;
            choice2.ForeColor = Color.White;
            choice3.BackColor = Color.Transparent;
            choice3.ForeColor = Color.Red;
            choice4.BackColor = Color.Transparent;
            choice4.ForeColor = Color.Red;
        }
        private void choice3_Click(object sender, EventArgs e)
        {
            choice1.Checked = false;
            choice2.Checked = false;
            choice3.Checked = true;
            choice4.Checked = false;
            choice1.BackColor = Color.Transparent;
            choice1.ForeColor = Color.Red;
            choice2.BackColor = Color.Transparent;
            choice2.ForeColor = Color.Red;
            choice3.BackColor = Color.Red;
            choice3.ForeColor = Color.White;
            choice4.BackColor = Color.Transparent;
            choice4.ForeColor = Color.Red;
        }
        private void choice4_Click(object sender, EventArgs e)
        {
            choice1.Checked = false;
            choice2.Checked = false;
            choice3.Checked = false;
            choice4.Checked = true;
            choice1.BackColor = Color.Transparent;
            choice1.ForeColor = Color.Red;
            choice2.BackColor = Color.Transparent;
            choice2.ForeColor = Color.Red;
            choice3.BackColor = Color.Transparent;
            choice3.ForeColor = Color.Red;
            choice4.BackColor = Color.Red;
            choice4.ForeColor = Color.White;
        }


        void Update1()
        {
            if (myanswers[0] == 1)
            {
                one++;
            }
            if (myanswers[0] == 2)
            {
                multipack++;
            }
            if (myanswers[0] == 3)
            {
                onehalf++;
            }
            if (myanswers[0] == 4)
            {
                two++;
            }
        }
        void Update2()
        {
            if (myanswers[1] == 1)
            {
                two++;
            }
            if (myanswers[1] == 2)
            {
                one++;
            }
            if (myanswers[1] == 3)
            {
                onehalf++;
            }
            if (myanswers[1] == 4)
            {
                multipack++;
            }
        }
        void Update3()
        {
            if (myanswers[2] == 1)
            {
                two++;
            }
            if (myanswers[2] == 2)
            {
                one++;
            }
            if (myanswers[2] == 3)
            {
                onehalf++;
            }
            if (myanswers[2] == 4)
            {
                multipack++;
            }
        }
        void Update4()
        {
            if (myanswers[3] == 1)
            {
                one++;
            }
            if (myanswers[3] == 2)
            {
                multipack++;
            }
            if (myanswers[3] == 3)
            {
                onehalf++;
            }
            if (myanswers[3] == 4)
            {
                two++;
            }
        }
        void Update5()
        {
            if (myanswers[4] == 1)
            {
                onehalf++;
            }
            if (myanswers[4] == 2)
            {
                one++;
            }
            if (myanswers[4] == 3)
            {
                two++;
            }
            if (myanswers[4] == 4)
            {
                multipack++;
            }
        }
        void Update6()
        {
            if (myanswers[5] == 1)
            {
                two++;
            }
            if (myanswers[5] == 2)
            {
                onehalf++;
            }
            if (myanswers[5] == 3)
            {
                one++;
            }
            if (myanswers[5] == 4)
            {
                multipack++;
            }
        }
        void Update7()
        {
            if (myanswers[6] == 1)
            {
                multipack++;
            }
            if (myanswers[6] == 2)
            {
                one++;
            }
            if (myanswers[6] == 3)
            {
                two++;
            }
            if (myanswers[6] == 4)
            {
                onehalf++;
            }
        }
        void Update8()
        {
            if (myanswers[7] == 1)
            {
                onehalf++;
            }
            if (myanswers[7] == 2)
            {
                one++;
            }
            if (myanswers[7] == 3)
            {
                multipack++;
            }
            if (myanswers[7] == 4)
            {
                two++;
            }
        }
        void Update9()
        {
            if (myanswers[8] == 1)
            {
                onehalf++;
            }
            if (myanswers[8] == 2)
            {
                multipack++;
            }
            if (myanswers[8] == 3)
            {
                two++;
            }
            if (myanswers[8] == 4)
            {
                one++;
            }
        }
        void Update10()
        {
            if (myanswers[9] == 1)
            {
                onehalf++;
            }
            if (myanswers[9] == 2)
            {
                one++;
            }
            if (myanswers[9] == 3)
            {
                multipack++;
            }
            if (myanswers[9] == 4)
            {
                two++;
            }
        }

    }
}
