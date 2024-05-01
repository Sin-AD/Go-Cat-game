using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kurs2.Properties;

namespace Kurs2
{
    public partial class Form1 : Form
    {
        int cx;
        int cy;
        double proc;

        const int allpixels = 186560;
        int nowpixels = 0;
        const int N = 500;
        const int M = 500;
        int[,] arr = new int[M, N]; // массив, размерно с картинкой
        Image ghostImg;
        Image testimg;
        Image catimg;
        Bitmap try1;
        int currFrame = 0;
        int dx;
        int dy;
        int _key = -1;

        List<PictureBox> pb = new List<PictureBox>();
        List<int> _dx = new List<int>();
        List<int> _dy = new List<int>();

        int countpb = 1;
        public int sch = 0;

        Boolean playerismove = false;
        Bitmap[] pic = new Bitmap[10];

        public Form1()
        {
            InitializeComponent();
            ghostImg = new Bitmap(Resources.ghosts);
            catimg = new Bitmap(Resources.cat2);
            try1 = new Bitmap(Resources.tryg);
            Random rand = new Random();

            pic[0] = new Bitmap(Resources.nol);
            pic[1] = new Bitmap(Resources.hh);
            pic[2] = new Bitmap(Resources.dva); ;
            pic[3] = new Bitmap(Resources.tri);
            pic[4] = new Bitmap(Resources.chetyre);
            pic[5] = new Bitmap(Resources.bb);
            pic[6] = new Bitmap(Resources.shest);
            pic[7] = new Bitmap(Resources.sem);
            pic[8] = new Bitmap(Resources.vosem);
            pic[9] = new Bitmap(Resources.devyat);
            testimg = pic[rand.Next(0, 9)];

            pictureBox1.Image = try1;

            gradientTimer.Interval = 20;
            ghostTimer.Interval = 100;
            gradientTimer.Start();
            ghostTimer.Tick += new EventHandler(update);
            ghostTimer.Start();

            cat.Interval = 5;

            move.Interval = 5;
            move.Start();

            pictureBox1.Controls.Add(label1);
            pictureBox1.Controls.Add(catBox);

            MaximizeBox = false;
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                { arr[i, j] = 0; }

            PictureBox Enemy = new PictureBox(); //спавн нулевого врага
            Enemy.Height = 30;
            Enemy.Width = 30;
            Enemy.Left = 200 + rand.Next(50, 100);
            Enemy.Top = 200;
            Enemy.BackColor = Color.Transparent;
            Enemy.BackgroundImage = ghostImg;
            pictureBox1.Controls.Add(Enemy);
            pb.Add(Enemy);
            _dx.Add(dx);
            _dy.Add(dy);

            for (int i = 0; i < pb.Count; i++)
            {
                _dx[i] = rand.Next(0, 2) * 2 - 1;
                _dy[i] = rand.Next(0, 2) * 2 - 1;
            }

            for (int i = 0; i < 455; i++)
                for (int j = 0; j < 471; j++)
                {
                    if (i == 0 || j == 0 || i == 455 - 1 || j == 471 - 1)
                    {
                        for (int a = 0; a < 30; a++)
                            for (int b = 0; b < 30; b++)
                            {
                                arr[i + a, j + b] = 1; //рамка, стена заполняем единицами
                            }
                    }
                }
        }
        private void update(object sender, EventArgs e)
        {
            playAnimation();

            if (currFrame == 4) //спрей призрака
            {
                currFrame = 0;
            }
            currFrame++;
        }

        private void rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила игры Go! Cat заключаются в том, чтобы отобрать территорию у врагов, путём отрезания территории. Вы можете двигаться только по вертикали и горизонтали. Во время движения вы оставляете за собой уязвимый для врагов след, наступив на который, вы потеряете жизнь. Ваша задача захватить более 90% территории ");
        }

        private void start_Click(object sender, EventArgs e)
        {
            int _key = -1; //индикатор нажатой кнопки
            rules.Visible = false;
            start.Visible = false;
            label1.Visible = false;
            pictureBox2.Visible = false;
            catBox.Visible = true;
            catBox.Location = new Point(225, 1);
            pictureBox1.BackgroundImage = testimg;
        }

        float step = 0;

        Color currentColor = Color.White;
        Color targetColor = Color.LightBlue;

        private void playAnimation()
        {
            Image part = new Bitmap(30, 30);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(ghostImg, new Rectangle(0, 0, 30, 30), new Rectangle(30 * currFrame, 0, 30, 30), GraphicsUnit.Pixel); 
            foreach (PictureBox Enemy in pb)
            {
                Enemy.Image = part; //анимированные спреи призрака
            }
        }

        private void gradientTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (start.Visible == true)
            {
                //градиентный перелив кнопки старт
                if (step >= 1f)
                {

                    step = 0;

                    int R = rnd.Next(0, 255);
                    int G = rnd.Next(0, 255);
                    int B = rnd.Next(0, 255);
                    currentColor = targetColor;
                    targetColor = Color.FromArgb(R, G, B);
                }
                int mixR = (int)(currentColor.R * (1f - step) + targetColor.R * step);
                int mixG = (int)(currentColor.G * (1f - step) + targetColor.G * step);
                int mixB = (int)(currentColor.B * (1f - step) + targetColor.B * step);
                start.FlatAppearance.BorderColor = Color.FromArgb(mixR, mixG, mixB);
                step += 0.03f;

            }
        }

        private void move_Tick(object sender, EventArgs e) //перемещения призрака
        {
            for (var i = 0; i < pb.Count; i++)
            {
                if (arr[pb[i].Location.X + 15, pb[i].Location.Y + 15] == 1) 
                {
                    random();
                    pb[i].Location = new Point(pb[i].Location.X + _dx[i], pb[i].Location.Y + _dy[i]);
                }
                else pb[i].Location = new Point(pb[i].Location.X + _dx[i], pb[i].Location.Y + _dy[i]);
                if (arr[pb[i].Location.X + 15, pb[i].Location.Y + 15] == 2)
                {
                    gameisover();
                }
            }
        }

        private void gameisover() 
        {
            int _key = -1;
            catBox.Location = new Point(225, 1);
            Random rand = new Random();
            testimg = pic[rand.Next(0, 9)];
            pictureBox1.BackgroundImage = testimg;
            cx = 0;
            cy = 0;
            for (int i = 30; i < 454; i++)
                for (int j = 30; j < 470; j++)
                    arr[i, j] = 0;

            for (int i = 1; i < pb.Count; i++)
            {
                pb[i].BackgroundImage = null;
                pictureBox1.Controls.Remove(pb[i]);
                pb.RemoveAt(i);
                _dx.RemoveAt(i);
                _dy.RemoveAt(i);
            }
            Graphics.FromImage(try1).Clear(Color.Black);
        }

        public void random() //рандом для отталкивания призрака
        {
            Random rand = new Random();
            for (var i = 0; i < pb.Count; i++)
            {
                while (arr[pb[i].Location.X + _dx[i] + 15, pb[i].Location.Y + _dy[i] + 15] == 1)
                {
                    if (_dx[i] == 0 || _dy[i] == 0) //иначе слишком часто будет по краям ходить
                    {
                        _dx[i] = rand.Next(0, 2) * 2 - 1;
                        _dy[i] = rand.Next(0, 2) * 2 - 1;
                    }

                    else
                    {
                        _dx[i] = rand.Next(-1, 2);
                        _dy[i] = rand.Next(-1, 2);
                    }
                    if (_dy[i] == 0 && _dx[i] == 0) { random(); } //шоб на месте не стоял
                }
            }
        }

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var left = new Rectangle(0, 0, 30, 501);
            var up = new Rectangle(0, 0, 484, 30);
            var down = new Rectangle(0, 470, 484, 30);
            var right = new Rectangle(454, 0, 30, 501);
            e.Graphics.DrawImage(testimg, 0, 0, left, GraphicsUnit.Pixel);
            e.Graphics.DrawImage(testimg, 0, 0, up, GraphicsUnit.Pixel);
            e.Graphics.DrawImage(testimg, 0, 470, down, GraphicsUnit.Pixel);
            e.Graphics.DrawImage(testimg, 454, 0, right, GraphicsUnit.Pixel); //рамки рисуем
        }

        public void Paintit() //след за котом
        {
            if (arr[catBox.Location.X + 15, catBox.Location.Y + 15] == 0)
            {
                playerismove = true;

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        arr[catBox.Location.X + i + 13, catBox.Location.Y + j + 13] = 2;
                        try1.SetPixel(catBox.Location.X + i + 13, catBox.Location.Y + 13 + j, Color.Transparent);
                    }
            }
        }

        private void cat_Tick(object sender, EventArgs e)
        {
            if (catBox.Location.X > 0 && catBox.Location.Y > 0 && catBox.Location.X < 455 && catBox.Location.Y < 471) //перемещение кота
            {
                catBox.Location = new Point(catBox.Location.X + cx, catBox.Location.Y + cy);
                Paintit();
                if (arr[catBox.Location.X + 15, catBox.Location.Y + 15] == 1)
                {
                    fill(arr);
                }
                if ((arr[catBox.Location.X + 2, catBox.Location.Y + 15] == 2 && _key == 1) || (arr[catBox.Location.X + 15, catBox.Location.Y + 2] == 2 && _key == 2) || (arr[catBox.Location.X + 28, catBox.Location.Y + 15] == 2 && _key == 3) || (arr[catBox.Location.X + 15, catBox.Location.Y + 28] == 2 && _key == 4)) //врезание в нарисованную линию

                {
                    _key = -1;
                    gameisover();
                }

            }
            else { catBox.Location = new Point(catBox.Location.X - 2 * cx, catBox.Location.Y - 2 * cy); cx = 0; cy = 0; }
        }

        public void continutegame()
        {
            int _key = -1;
            Random rand = new Random();
            testimg = pic[rand.Next(0, 9)];
            pictureBox1.BackgroundImage = testimg;
            Graphics.FromImage(try1).Clear(Color.Black);
            cx = 0;
            cy = 0;

            catBox.Location = new Point(225, 1);
            PictureBox Enemy = new PictureBox();
            Enemy.Height = 30;
            Enemy.Width = 30;
            Enemy.Left = 200 + rand.Next(50, 100);
            Enemy.Top = 200;
            Enemy.BackColor = Color.Transparent;
            Enemy.BackgroundImage = ghostImg;
            pictureBox1.Controls.Add(Enemy);
            pb.Add(Enemy);
            _dx.Add(dx);
            _dy.Add(dy);
            _dx[countpb] = rand.Next(0, 2) * 2 - 1;
            _dy[countpb] = rand.Next(0, 2) * 2 - 1;
            countpb++;

            for (int i = 30; i < 454; i++)
                for (int j = 30; j < 470; j++)
                    arr[i, j] = 0;
        }

        private void fill(int[,] arr) 
        {
            if (playerismove == false) return;
            playerismove = false;
            var wave = -1;
            foreach (var Enemy in pb)
                arr[Enemy.Location.X + 15, Enemy.Location.Y + 15] = wave;
            while (true)
            {
                if (!fillwave(arr, ref wave))
                    break;
            }
            for (var i = 30; i < 454; i++)
                for (var j = 30; j < 470; j++)
                {
                    if (arr[i, j] == 2 || arr[i, j] == 0)
                    {
                        arr[i, j] = 1;
                        try1.SetPixel(i, j, Color.Transparent); pictureBox1.Invalidate(); //закрашивание территории
                    }
                    if (arr[i, j] < 0)
                        arr[i, j] = 0;

                    if (arr[i, j] == 1)
                    {
                        nowpixels++;
                    }

                }
            proc = (nowpixels * 100 / allpixels); //считаем процент закрашенной территории
            nowpixels = 0;
            if (proc >= 80)
            {
                continutegame();
            }

        }

        private bool fillwave(int[,] arr, ref int wave) //заполнение волной территории от врагов для будущего закрашивания занятой территории
        {
            var changed = false;
            for (var i = 30; i < 454; i++)
                for (var j = 30; j < 470; j++)
                    if (arr[i, j] == wave)
                    {
                        if (arr[i - 1, j] == 0)
                        {
                            arr[i - 1, j] = wave - 1;
                            changed = true;
                        }
                        if (i < 454 - 1 && arr[i + 1, j] == 0)
                        {
                            arr[i + 1, j] = wave - 1;
                            changed = true;
                        }
                        if (arr[i, j - 1] == 0)
                        {
                            arr[i, j - 1] = wave - 1;
                            changed = true;
                        }
                        if (j < 470 - 1 && arr[i, j + 1] == 0)
                        {
                            arr[i, j + 1] = wave - 1;
                            changed = true;
                        }
                    }
            wave--;
            return changed;
        }

        public void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cat.Enabled = true;

            if (e.KeyChar == 'a' || e.KeyChar == 'A' || e.KeyChar == 'Ф' || e.KeyChar == 'ф')
                if (catBox.Location.X > 1) { cx = -2; cy = 0; _key = 1; }

            if (e.KeyChar == 'w' || e.KeyChar == 'W' || e.KeyChar == 'Ц' || e.KeyChar == 'ц')
                if (catBox.Location.Y > 1) { cx = 0; cy = -2; _key = 2; }

            if (e.KeyChar == 'd' || e.KeyChar == 'D' || e.KeyChar == 'В' || e.KeyChar == 'в')
                if (catBox.Location.X < 464) { cx = 2; cy = 0; _key = 3; }

            if (e.KeyChar == 's' || e.KeyChar == 'S' || e.KeyChar == 'Ы' || e.KeyChar == 'ы')
                if (catBox.Location.Y < 469) { cx = 0; cy = 2; _key = 4; }
        }
    }
}