using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treeheap
{
    public partial class Form3 : Form
    {
        List<string> ls = new List<string>();
        List<int> ls2 = new List<int>();
        Panel pnl = new Panel();
        //private int count = 0;
        int[] arr = new int[10];


        public Form3()
        {
            InitializeComponent();

            /*for (int i = 1; i <= 10; i++)
            {
                ls.Add("textBox" + i);

            }*/
        }

        void drawLabel(Point p, int index, int content)
        {
            Label lbl = new Label();
            lbl.Name = index.ToString();
            lbl.Location = p;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.AutoSize = false;
            lbl.BackColor = Color.Green;
            lbl.Font = new Font(FontFamily.GenericSerif, 20);
            lbl.Width = 60;
            lbl.Height = 40;
            lbl.Text = Convert.ToString(content);
            pnl.Controls.Add(lbl);
        }

        void getTextBoxVal()
        {
            for (int i = 1; i <= 10; i++)
            {

                TextBox txt = (TextBox)Controls[ls[i - 1]];
                if (txt.Text != null && txt.Text != "")
                {

                    ls2.Add(Convert.ToInt32(txt.Text));
                }
            }
        }

        async Task func()
        {
            string[] ar = { "label1", "label2", "label3" };
            for (int i = 0; i < 3; i++)
            {
                Controls[ar[i]].BackColor = Color.Red;
                Controls[ar[i + 1]].BackColor = Color.Red;
                await Task.Delay(5000);
                Controls[ar[i]].BackColor = Color.White;
                Controls[ar[i + 1]].BackColor = Color.White;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task t = func();
        }
    }
}
