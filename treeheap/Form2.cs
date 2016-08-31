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
    public delegate void Form2_swaping1( object sender,getEvent e);
    public partial class Form2 : Form
    {
        List<string> ls = new List<string>();
        List<int> ls2 = new List<int>();
        Panel pnl = new Panel();
        //private int count = 0;
        int[] arr = new int[10];
        
        public event Form2_swaping1 swaping;

        public Form2()
        {
            InitializeComponent();

            for (int i = 1; i <= 10; i++)
            {
                ls.Add("textBox" + i);

            }

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

                TextBox txt = (TextBox)groupBox1.Controls[ls[i - 1]];
                if (txt.Text != null && txt.Text != "")
                {
                    
                    ls2.Add( Convert.ToInt32(txt.Text));
                }
            }
        }

        public async Task Swap(int val1, int indx1, int val2, int indx2)
        {
            Label lbl1 = (Label)pnl.Controls[indx1.ToString()];
            Label lbl2 = (Label)pnl.Controls[indx2.ToString()];

            lbl1.BackColor = Color.Red;
            lbl2.BackColor = Color.Red;
            await Task.Delay(5000);

            lbl1.Text = val1.ToString();
            lbl2.Text = val2.ToString();
            await Task.Delay(5000);

            lbl1.BackColor = Color.Green;
            lbl2.BackColor = Color.Green;
            await Task.Delay(5000);
        }

        async Task SwapLabels2(int val1, int indx1, int val2, int indx2)
        {
            Label lbl1 = (Label)pnl.Controls[indx1.ToString()];
            Label lbl2 = (Label)pnl.Controls[indx2.ToString()];

            lbl1.BackColor = Color.Red;
            lbl2.BackColor = Color.Red;
            await Task.Delay(5000);

            lbl1.Text = val1.ToString();
            lbl2.Text = val2.ToString();
            await Task.Delay(5000);

            lbl1.BackColor = Color.Green;
            lbl2.BackColor = Color.Green;
            await Task.Delay(5000);
        }

        async Task matchTxtBox( int indx1, int indx2)
        {
            //timer1.Start();
            TextBox txt1 = (TextBox)groupBox1.Controls["textBox" + (indx1 ).ToString()];
            TextBox txt2 = (TextBox)groupBox1.Controls["textBox" + (indx1 ).ToString()];

            txt1.BackColor = Color.CadetBlue;
            
            txt2.BackColor = Color.CadetBlue;
            await Task.Delay(3000);
            txt1.BackColor = Color.White;
            
            txt2.BackColor = Color.White;
            //Task.Delay(3000);
            await Task.Delay(3000);
        }

         void selectionSort(List<int> arr)
        {
            //timer1.Start();
            int pos_min, temp;

            for (int i = 0; i < arr.Count -1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Count; j++)
                {
                    //timer1.Tick += (sender,e)=>Timer1_Tick(sender,e,j,pos_min);
                    //swaping += (sender, e, ind1,  ind2) =>Form2_swaping(sender,e, j, pos_min);
                    //Task t = matchTxtBox(j, pos_min);
                    getEvent g = new getEvent();
                    g.i = j;
                    g.posMin = pos_min;
                    var s=swaping;
                    s(this, g);
                    swaping += (object sender, getEvent e)=> { Task t = matchTxtBox(e.i, e.posMin); };
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    //Task t = Swap(arr[i], pos_min, arr[pos_min], i);
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                    
                }
            }
        }

        

       

        

        private void Timer1_Tick(object sender, EventArgs e,int ind1,int ind2)
        {
            //throw new NotImplementedException();
            //Task t = matchTxtBox(sender, e, ind1, ind2);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            getTextBoxVal();
            if (ls2.Count > 0)
            {
                
                pnl.Width = 900;
                pnl.Height = 400;
                pnl.BackColor = Color.Aqua;
                pnl.Location = new Point(0, groupBox1.Location.Y + groupBox1.Height);
                //pnl.Show();
                Controls.Add(pnl);


                for (int i = 0; i < ls2.Count; i++)
                {
                    if (i == 0)
                        drawLabel(new Point(pnl.Width/4, pnl.Height / 3), i, ls2[i]);
                    else
                    {
                        Label lbl = (Label)pnl.Controls["0"];
                        drawLabel(new Point(pnl.Width / 4 + lbl.Width * i + 10*i, pnl.Height / 3), i, ls2[i]);
                    }
                }
                selectionSort(ls2);

            }
            
        }

        
    }

    public class getEvent:EventArgs
    {
        public int i { get; set; }
        public int posMin { set; get; }
    }


}
