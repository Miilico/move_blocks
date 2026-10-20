using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Project
{
    public partial class Form2 : Form
    {
        int back_w = 302;
        int back_h = 302;
        int[,] map;
        int trys = 0;
        bool win = false;
        private Point mouse_offset;
        
        public Form2()
        {
            InitializeComponent();
            map = new int[back_h, back_w];
            background.Height = 300;
            background.Width = 300;
            button1.Visible = false;


            //外框
            for (int i = 0; i < back_h; i++)
            {
                for (int j = 0; j < back_w; j++)
                {
                    if (i == 0 || i == back_h - 1) map[i, j] = 1;
                    else
                    {
                        if (j == 0 || j == back_w - 1)
                            if (i > 99 && i < 150) map[i, j] = 0;
                            else map[i, j] = 1;
                        else map[i, j] = 0;
                    }
                }
            }


            //pic1
            pictureBox1.Width = 50;
            pictureBox1.Height = 150;
            pictureBox1.Location = new Point(background.Location.X + 100, background.Location.Y);
            for (int i = 0; i < 150; i++)
            {
                for (int j = 100; j < 150; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //pic5
            pictureBox2.Width = 50;
            pictureBox2.Height = 150;
            pictureBox2.Location = new Point(background.Location.X + 250, background.Location.Y+150);
            for (int i = 150; i < 300; i++)
            {
                for (int j = 250; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver1.Width = 50;
            ver1.Height = 100;
            ver1.Location = new Point(background.Location.X+50, background.Location.Y);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 50; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver2.Width = 50;
            ver2.Height = 100;
            ver2.Location = new Point(background.Location.X, background.Location.Y + 150);
            for (int i = 150; i < 250; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver3.Width = 50;
            ver3.Height = 100;
            ver3.Location = new Point(background.Location.X + 150, background.Location.Y );
            for (int i = 0; i < 100; i++)
            {
                for (int j = 150; j < 200; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }


            //goal
            goal.Width = 100;
            goal.Height = 50;
            goal.Location = new Point(background.Location.X, background.Location.Y + 100);
            for (int i = 100; i < 150; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            hor1.Width = 100;
            hor1.Height = 50;
            hor1.Location = new Point(background.Location.X, background.Location.Y + 250);
            for (int i = 250; i < 300; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //hor2
            hor2.Width = 100;
            hor2.Height = 50;
            hor2.Location = new Point(background.Location.X+100, background.Location.Y + 250);
            for (int i = 250; i < 300; i++)
            {
                for (int j = 100; j < 200; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }


            hor3.Width = 100;
            hor3.Height = 50;
            hor3.Location = new Point(background.Location.X + 200, background.Location.Y+50);
            for (int i = 50; i < 100; i++)
            {
                for (int j = 200; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //hor4
            hor4.Width = 100;
            hor4.Height = 50;
            hor4.Location = new Point(background.Location.X + 200, background.Location.Y);
            for (int i = 0; i < 50; i++)
            {
                for (int j = 200; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //hor5
            hor5.Width = 150;
            hor5.Height = 50;
            hor5.Location = new Point(background.Location.X + 50, background.Location.Y+150);
            for (int i = 150; i < 200; i++)
            {
                for (int j = 50; j < 200; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            label1.Text = "移動次數:\n" + trys.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (win == false)
            {
                mouse_offset = new Point(-e.X, -e.Y);
                PictureBox pic = (PictureBox)sender;
                for (int i = pic.Location.Y - background.Location.Y; i < pic.Location.Y - background.Location.Y + pic.Height; i++)
                {
                    for (int j = pic.Location.X - background.Location.X; j < pic.Location.X - background.Location.X + pic.Width; j++)
                    {
                        map[i + 1, j + 1] = 0;
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&& win == false)
                HandlePictureBoxMove((PictureBox)sender, e, false);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (win == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PictureBox pic = (PictureBox)sender;
                    for (int i = pic.Location.Y - background.Location.Y; i < pic.Location.Y - background.Location.Y + pic.Height; i++)
                    {
                        for (int j = pic.Location.X - background.Location.X; j < pic.Location.X - background.Location.X + pic.Width; j++)
                        {
                            map[i + 1, j + 1] = 1;
                        }
                    }

                }
                trys++;
                label1.Text = "移動次數:\n" + trys.ToString();
            }
            else
            {
                trys++;
                label1.Text = "移動次數:\n" + trys.ToString();
                goal.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
                ver1.Enabled = false;
                ver2.Enabled = false;
                ver3.Enabled = false;
                hor1.Enabled = false;
                hor2.Enabled = false;
                hor3.Enabled = false;
                hor4.Enabled = false;
                hor5.Enabled = false;
                MessageBox.Show("恭喜你成功了！\n移動次數:" + trys.ToString());
                button1.Visible = true;
            }

        }

        private void goal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && win==false)
                HandlePictureBoxMove((PictureBox)sender, e, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool CanMoveTo(Rectangle newPos, bool hor)
        {
            for (int y = newPos.Top; y < newPos.Bottom; y++)
            {
                for (int x = newPos.Left; x < newPos.Right; x++)
                {
                    if (newPos.Right > 301 && hor == true)
                    {
                        win = true;
                        return true;
                    }
                    if (map[y + 1, x + 1] == 1) return false;
                }
            }
            return true;
        }

        private void HandlePictureBoxMove(PictureBox pic, MouseEventArgs e, bool hor)
        {
            Point mousePos = PointToClient(Control.MousePosition);
            mousePos.Offset(mouse_offset.X, mouse_offset.Y);
            if (hor)
            {
                //Y固定
                mousePos.Y = pic.Location.Y;
                if (mousePos.X < background.Location.X) mousePos.X = background.Location.X;
                if (mousePos.Y != background.Location.Y + 100) if (mousePos.X + pic.Width > background.Location.X + background.Width) mousePos.X = background.Location.X + background.Width - pic.Width;
            }
            else
            {
                //X固定
                mousePos.X = pic.Location.X;
                if (mousePos.Y < background.Location.Y) mousePos.Y = background.Location.Y;
                if (mousePos.Y + pic.Height > background.Location.Y + background.Height) mousePos.Y = background.Location.Y + background.Height - pic.Height;
            }

            Rectangle futureRect = new Rectangle(
                mousePos.X - background.Location.X,
                mousePos.Y - background.Location.Y,
                pic.Width,
                pic.Height);

            if (CanMoveTo(futureRect, hor))
            {
                pic.Location = mousePos;
            }
        }


    }
}
