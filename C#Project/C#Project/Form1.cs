using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Project
{

    public partial class Form1 : Form
    {
        int back_w = 302;
        int back_h = 302;
        int[,] map;
        int trys = 0;
        bool win = false;
        private Point mouse_offset;
        
        private Form f2;
       


        public Form1()
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
                            if(i>99 && i < 150) map[i, j] = 0;
                            else map[i, j] = 1;
                        else map[i, j] = 0;
                    }
                }
            }
            

            //pic1
            pictureBox1.Width = 50;
            pictureBox1.Height = 150;
            pictureBox1.Location = new Point(background.Location.X + 100, background.Location.Y + 150);
            for (int i = 150; i < 300; i++)
            {
                for (int j = 50; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }
            
            ver1.Width = 50;
            ver1.Height = 100;
            ver1.Location = new Point(background.Location.X, background.Location.Y);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver2.Width = 50;
            ver2.Height = 100;
            ver2.Location = new Point(background.Location.X, background.Location.Y+100);
            for (int i = 100; i < 200; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver3.Width = 50;
            ver3.Height = 100;
            ver3.Location = new Point(background.Location.X+150, background.Location.Y+50);
            for (int i = 50; i < 150; i++)
            {
                for (int j = 150; j < 200; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver4.Width = 50;
            ver4.Height = 100;
            ver4.Location = new Point(background.Location.X+200, background.Location.Y + 50);
            for (int i = 50; i < 150; i++)
            {
                for (int j = 200; j < 250; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver5.Width = 50;
            ver5.Height = 100;
            ver5.Location = new Point(background.Location.X+250, background.Location.Y+50);
            for (int i = 50; i < 150; i++)
            {
                for (int j = 250; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver6.Width = 50;
            ver6.Height = 100;
            ver6.Location = new Point(background.Location.X + 150, background.Location.Y + 150);
            for (int i = 150; i < 250; i++)
            {
                for (int j = 150; j < 200; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver7.Width = 50;
            ver7.Height = 100;
            ver7.Location = new Point(background.Location.X + 200, background.Location.Y + 150);
            for (int i = 150; i < 250; i++)
            {
                for (int j = 200; j < 250; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            ver8.Width = 50;
            ver8.Height = 100;
            ver8.Location = new Point(background.Location.X + 250, background.Location.Y + 150);
            for (int i = 150; i < 250; i++)
            {
                for (int j = 250; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //goal
            goal.Width = 100;
            goal.Height = 50;
            goal.Location = new Point(background.Location.X + 50, background.Location.Y + 100);
            for (int i = 100; i < 150; i++)
            {
                for (int j = 50; j < 150; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }
            
            hor1.Width = 100;
            hor1.Height = 50;
            hor1.Location = new Point(background.Location.X, background.Location.Y + 200);
            for (int i = 200; i < 250; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //hor2
            hor2.Width = 100;
            hor2.Height = 50;
            hor2.Location = new Point(background.Location.X, background.Location.Y + 250);
            for (int i = 250; i < 300; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }
           

            hor3.Width = 100;
            hor3.Height = 50;
            hor3.Location = new Point(background.Location.X + 200, background.Location.Y );
            for (int i = 0; i < 50; i++)
            {
                for (int j = 200; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            //hor4
            hor4.Width = 100;
            hor4.Height = 50;
            hor4.Location = new Point(background.Location.X + 200, background.Location.Y + 250);
            for (int i = 250; i < 300; i++)
            {
                for (int j = 200; j < 300; j++)
                {
                    map[i + 1, j + 1] = 1;
                }
            }

            label1.Text = "移動次數:\n"+trys.ToString();
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
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
                ver1.Enabled = false;
                ver2.Enabled = false;
                ver3.Enabled = false;
                ver4.Enabled = false;
                ver5.Enabled = false;
                ver6.Enabled = false;
                ver7.Enabled = false;
                ver8.Enabled = false;
                hor1.Enabled = false;
                hor2.Enabled = false;
                hor3.Enabled = false;
                hor4.Enabled = false;
                MessageBox.Show("恭喜你成功了！\n移動次數:" + trys.ToString());
                button1.Visible = true;
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandlePictureBoxMove((PictureBox)sender, e, false);
        }
            /*
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = (PictureBox)sender;
                Point mousePos = PointToClient(Control.MousePosition);
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                /*
                for (int i = pic.Location.Y - background.Location.Y; i < pic.Location.Y - background.Location.Y + pic.Height; i++)
                {
                    for (int j = pic.Location.X - background.Location.X; j < pic.Location.X - background.Location.X + pic.Width; j++)
                    {
                        map[i + 1, j + 1] = 0;
                    }
                }

                mousePos.X = pic.Location.X;
                if (mousePos.Y < background.Location.Y) mousePos.Y = background.Location.Y;
                if (mousePos.Y + pic.Height > background.Location.Y + background.Height) mousePos.Y = background.Location.Y + background.Height - pic.Height;

                int firstt = 0, firstb = back_h - 1;
                for (int i = pic.Location.Y - background.Location.Y; i > 0; i--)
                    if (map[i, pic.Location.X-background.Location.X+1] == 1 || map[i, pic.Location.X - background.Location.X + 1 + pic.Width] == 1)
                    {
                        firstt = i;
                        break;
                    }

                for (int i = pic.Location.Y - background.Location.Y + pic.Height; i < back_h - 1; i++)
                    if (map[i, pic.Location.X - background.Location.X + 1] == 1 || map[i, pic.Location.X - background.Location.X + 1+pic.Width] == 1)
                    {
                        firstb = i;
                        break;
                    }

                if (mousePos.Y - background.Location.Y < firstt) mousePos.Y = firstt + background.Location.Y;
                if ((mousePos.Y + pic.Height - background.Location.Y) + 1 > firstb) mousePos.Y = firstb +background.Location.Y-pic.Height;   
                label1.Text = "   " + (mousePos.Y - background.Location.Y).ToString() + "\n" + (mousePos.Y+pic.Height - background.Location.Y).ToString();
                label2.Text = "   " + (pic.Location.Y - background.Location.Y).ToString() + "\n   " + (pic.Location.Y - background.Location.Y + pic.Height).ToString();
                pic.Location = mousePos;
            }*/
        

        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandlePictureBoxMove((PictureBox)sender, e,true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        bool CanMoveTo(Rectangle newPos, bool hor)
        {
            for (int y = newPos.Top; y < newPos.Bottom; y++)
            {
                for (int x = newPos.Left; x < newPos.Right; x++)
                {
                    if (newPos.Right > 301)
                    {
                        win = true;
                        return true;
                    }
                    else if (map[y + 1, x + 1] == 1) return false;
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
                mousePos.Y = pic.Location.Y;
                if (mousePos.X < background.Location.X) mousePos.X = background.Location.X;
                if (mousePos.Y != background.Location.Y + 100)
                {
                    if (mousePos.X + pic.Width > background.Location.X + background.Width) mousePos.X = background.Location.X + background.Width - pic.Width;
                }
            }
            else
            {
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

        /*
        mousePos.Y = pic.Location.Y;
        if (mousePos.X < background.Location.X) mousePos.X = background.Location.X;
        if (mousePos.X + pic.Width > background.Location.X + background.Width) mousePos.X = background.Location.X + background.Width - pic.Width;

        int top = pic.Location.Y - background.Location.Y ;
        int bottom = pic.Location.Y - background.Location.Y + pic.Height;
        int left = pic.Location.X - background.Location.X ;
        int right = pic.Location.X - background.Location.X + pic.Width ;

        int firstl = 0, firstr = back_w - 1;
        for (int i = left-1; i > 0; i--)
            if (map[top+1, i] == 1 || map[bottom+ 1, i+1] == 1)
            {
                firstl = i;
                break;
            }

        for (int i = right+1; i < 301; i++)
            if (map[top+1,i] == 1 || map[bottom+1, i+1] == 1)
            {
                firstr = i;
                break;
            }


        //if (mousePos.X - background.Location.X < firstl-1) mousePos.X = firstl + background.Location.X;
        //if ((mousePos.X + pic.Width - background.Location.X) + 1 > firstr-1) mousePos.X = firstr + background.Location.X - pic.Width;

        //label1.Text = "   " + (mousePos.X - background.Location.X).ToString() + "\n" + (mousePos.X + pic.Width - background.Location.X).ToString();
        //label2.Text = "   " + (pic.Location.X - background.Location.X).ToString() + "\n   " + (pic.Location.X - background.Location.X + pic.Width).ToString();
        label1.Text =  firstl.ToString() + "   " + firstr.ToString();
        label2.Text = "   " + top.ToString() + "\n" + left.ToString() + "   " + right.ToString() + "\n   " + bottom.ToString();

        //label2.Text = "   " + (mousePos.Y-background.Location.Y).ToString() + "\n" + (mousePos.X - background.Location.X).ToString() + "   " + (mousePos.X+pic.Width - background.Location.X).ToString() + "\n   " + (mousePos.Y+pic.Height - background.Location.Y).ToString();
        pic.Location = mousePos;
     }
     }*/
    }
}





        /*if (mousePos.X < background.Location.X) mousePos.X = background.Location.X;
                if (mousePos.X + pic.Width > background.Location.X + background.Width) mousePos.X = background.Location.X + background.Width-pic.Width;
                if (mousePos.Y < background.Location.Y) mousePos.Y = background.Location.Y;
                if (mousePos.Y + pic.Height > background.Location.Y + background.Height) mousePos.Y = background.Location.Y + background.Height-pic.Height;

                int mleft = (mousePos.X - background.Location.X);
                int mright = (mousePos.X + pic.Width - background.Location.X)+1;
                int mtop = (mousePos.Y - background.Location.Y );
                int mbottom = (mousePos.Y + pic.Height - background.Location.Y)+1;
                int firstl=0, firstr=back_w-1, firstt=0, firstb=back_h-1 ;
               
                for (int i = pictureBox1.Location.X-background.Location.X; i > 0; i--) 
                    if (map[mtop + 1, i] == 1){
                        firstl = i;
                        break;
                    }
                for (int i = pictureBox1.Location.X - background.Location.X+pic.Width; i < back_w-1; i++)  
                    if (map[mtop + 1, i] == 1){
                        firstr = i;
                        break;
                    }
                              
                for (int i = pictureBox1.Location.Y - background.Location.Y; i > 0 ; i--) 
                    if (map[i,mleft+1] == 1){
                        firstt = i;
                        break;
                    }
                
                for (int i = pictureBox1.Location.Y - background.Location.Y + pic.Height; i < back_h-1 ; i++) 
                    if (map[i,mleft+1] == 1) {
                        firstb = i;
                        break;
                    }
                if (mleft<firstl) mousePos.X += firstl - mleft;
                if (mright > firstr) mousePos.X -= mright-firstr;
                if (mtop < firstt) mousePos.Y += firstt - mtop;
                if (mbottom > firstb) mousePos.Y -= mbottom - firstb;
        */
               