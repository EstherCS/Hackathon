using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 

namespace message
{
    public partial class Form1 : Form
    {
        private bool nonNumberEntered5;  // 第一個輸入金額
        private bool nonNumberEntered7;  // 第二個輸入金額
        private bool nonNumberEntered3;  // 輸入總金額
        int y = 50;
        int i = 9;
        int l = 10;
        int people = 2;
        TextBox[] tb = new TextBox[2000];
        Label[] lb = new Label[2000];
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)  // 金額一
        {
            nonNumberEntered5 = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) // 鍵盤上數字
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) //數字盤
                {
                    if (e.KeyCode != Keys.Back)   //Backspace
                        nonNumberEntered5 = true;
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)  // 金額二
        {
            nonNumberEntered3 = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) // 鍵盤上數字
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) //數字盤
                {
                    if (e.KeyCode != Keys.Back)   //Backspace
                        nonNumberEntered3 = true;
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered7 = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) // 鍵盤上數字
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) //數字盤
                {
                    if (e.KeyCode != Keys.Back)   //Backspace
                        nonNumberEntered7 = true;
                }
            }
        }   

        private void button3_Click(object sender, EventArgs e)
        {
           if(textBox5.Text != "" && textBox7.Text != "")
           {
               double a = double.Parse(textBox5.Text);
               double b = double.Parse(textBox7.Text);
               double c = a + b;
               for (int x = 9; x < i; x++ )
               {
                   if(x % 3 == 0)
                   {
                       double n = double.Parse(tb[x].Text);
                       c += n;
                   }
               }
               textBox3.Text = c.ToString("0.00");

               double d = a / c * 100;
               textBox6.Text = d.ToString("0.00");
               double f = b / c * 100;
               textBox8.Text = f.ToString("0.00");
               double totle = d + f;
               for (int x = 9; x < i; x++)
               {
                   if(x % 3 == 1)
                   {
                       double m = double.Parse(tb[x-1].Text);
                       double k = m / c * 100;
                       tb[x].Text = k.ToString("0.00");
                       totle += k;
                   }
               }
               textBox4.Text = totle.ToString("0.00") + " % ";
           }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") && (textBox7.Text == "") && !nonNumberEntered3 && textBox3.Text != "")
            {
                double a = double.Parse(textBox3.Text) / people;
                double b = 100 / people;
                textBox6.Text = textBox8.Text = b.ToString("0.00");
                textBox4.Text = "100 %";
                textBox5.Text = textBox7.Text = a.ToString("0.00");
                for(int x = 8; x < i; x++)
                {
                   if(x % 3 == 0)
                   {
                       tb[x + 1].Text = b.ToString("0.00");
                       tb[x].Text = a.ToString("0.00");
                   }
                }
            }
            if (checkBox1.Checked == false && textBox6.Text != "")
            {
                textBox5.Text = "";
                textBox7.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                for (int a = 9; a < i; a++)
                {
                    if (tb[a].Name != a.ToString())
                        tb[a].Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            people++;
            tb[i] = new TextBox();  // 金額
            tb[i].Location = new Point(textBox7.Location.X, textBox7.Location.Y + y);
            tb[i].Name = tb[i].Text;
            tb[i].Size = textBox7.Size;
            tb[i].TabIndex = i + 1;
            this.Controls.Add(tb[i]);
            i++;
            tb[i] = new TextBox();  // 比例
            tb[i].Location = new Point(textBox8.Location.X, textBox8.Location.Y + y);
            tb[i].Name = tb[i].Text;
            tb[i].Size = textBox8.Size;
            tb[i].TabIndex = i + 1;
            tb[i].Enabled = false;
            this.Controls.Add(tb[i]);
            i++;
            tb[i] = new TextBox();  // 姓名
            tb[i].Location = new Point(textBox2.Location.X, textBox2.Location.Y + y);
            tb[i].Name = i.ToString();
            tb[i].Size = textBox2.Size;
            tb[i].TabIndex = i + 1;
            this.Controls.Add(tb[i]);
            i++;  
            lb[l] = new Label();
            lb[l].Location = new Point(label6.Location.X, label6.Location.Y + y);
            lb[l].Text = label6.Text;
            this.Controls.Add(lb[l]);
            l++;
            lb[l] = new Label();
            lb[l].Location = new Point(label4.Location.X, label4.Location.Y + y);
            lb[l].Text = label4.Text;
            this.Controls.Add(lb[l]);
            l++;
            y += 50;

            // 往下移
            checkBox1.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + 50);
            button2.Location = new Point(button2.Location.X, button2.Location.Y + 50);
            label9.Location = new Point(label9.Location.X, label9.Location.Y + 50);
            textBox3.Location = new Point(textBox3.Location.X, textBox3.Location.Y + 50);
            textBox4.Location = new Point(textBox4.Location.X, textBox4.Location.Y + 50);
            // 清空值
            textBox5.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            for (int a = 9; a < i; a++)
            {
                if (tb[a].Name != a.ToString())
                    tb[a].Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            for(int a = 9; a < i; a++)
            {
                if (tb[a].Name != a.ToString())
                    tb[a].Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            people--;
            textBox5.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            for (int a = 9; a < i; a++)
            {
                if (tb[a].Name != a.ToString())
                    tb[a].Text = "";
            }
           if(i > 9)
           {
               for (int z = 0; z < 3; z++)
               {
                   tb[--i].Dispose();
                   if (z < 2 && l > 10)
                       lb[--l].Dispose();
               }
               y -= 50;
               // 往上移
               checkBox1.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y - 50);
               button2.Location = new Point(button2.Location.X, button2.Location.Y - 50);
               label9.Location = new Point(label9.Location.X, label9.Location.Y - 50);
               textBox3.Location = new Point(textBox3.Location.X, textBox3.Location.Y - 50);
               textBox4.Location = new Point(textBox4.Location.X, textBox4.Location.Y - 50);
           }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "丁愛玲";
            //textBox1.Enabled = false;
            textBox2.Text = "陳躍文";
           // textBox2.Enabled = false;
        } 
    }
}
