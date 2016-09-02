using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treeheap
{
    public partial class SelectionSort : Form
    {
        List<string> ls = new List<string>();
        List<int> ls2 = new List<int>();

        public SelectionSort()
        {
            InitializeComponent();

            for (int i = 1; i <= 7; i++)   //get textbox names
           {
               ls.Add("textBox" + i);
           }

        }

        
        //get textbox values to List
        bool getTextBoxVal()
        {
            int value,i=1;
            while ( i <= 7)
            {

                TextBox txt = (TextBox)Controls[ls[i - 1]];
                if (txt.Text != null && txt.Text != "")
                {
                    if (int.TryParse(txt.Text, out value))
                    {
                        ls2.Add(Convert.ToInt32(txt.Text));
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Entry only integers");
                        ls2.Clear();
                        return false;
                    }
                }
                else
                {
                    i++;
                    continue;
                }

            }
            return true;
        }

        //dynamically draw labels
        void drawLabel(Point p, int index, int content)
        {
            Label lbl = new Label();
            lbl.Name = index.ToString();
            lbl.Location = p;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.AutoSize = false;
            lbl.BackColor = Color.SeaGreen;
            lbl.Font = new Font(FontFamily.GenericSerif, 20);
            lbl.Width = 50;
            lbl.Height = 30;
            lbl.Text = Convert.ToString(content);
            Controls.Add(lbl);
        }

        //show label swapping
        void SwapLabels(int val1, int indx1, int val2, int indx2)
        {
            Label lbl1 = (Label)Controls[indx1.ToString()];
            Label lbl2 = (Label)Controls[indx2.ToString()];

            lbl1.BackColor = Color.Red;
            lbl2.BackColor = Color.Red;
            

            lbl1.Text = val1.ToString();
            lbl2.Text = val2.ToString();
            

            lbl1.BackColor = Color.Green;
            lbl2.BackColor = Color.Green;
            //await Task.Delay(5000);
        }

        //show comparing textboxes
        async Task matchTxtBox(int indx1, int indx2)
        {
            
            TextBox txt1 = (TextBox)Controls["textBox" + (indx1 + 1).ToString()];
            TextBox txt2 = (TextBox)Controls["textBox" + (indx2 + 1).ToString()];

            txt1.BackColor = Color.CadetBlue;

            txt2.BackColor = Color.CadetBlue;
            
            await Task.Delay(2000);
            txt1.BackColor = Color.White;

            txt2.BackColor = Color.White;
            
            await Task.Delay(2000);
        }

        //show excuting line
        async Task findLine(string indx)
        {

            Label txt1 = (Label)panel1.Controls[indx];
            txt1.BackColor = Color.CadetBlue;

            await Task.Delay(1000);
            txt1.BackColor = Color.Empty;

            await Task.Delay(1000);
        }

        async void selectionSort(List<int> arr)
        {
            
            int pos_min, temp;
            string labl_i = "", labl_pos_min = "", labl_j = "";

            for (int i = 0; i < arr.Count - 1; i++)
            {
                await findLine("label1");
                labl_i += i + "     \t";
                lbl_i.Text = labl_i;

                await findLine("label2");
                pos_min = i;//set pos_min to the current index of array
                labl_pos_min += pos_min + "     \t";
                lbl_pos_min.Text = labl_pos_min;

                await findLine("label3");
                for (int j = i + 1; j < arr.Count; j++)
                {
                    labl_j += j + "     \t";
                    lbl_j.Text = labl_j;

                    await findLine("label4");
                    await matchTxtBox(j,pos_min);
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        await findLine("label5");
                        pos_min = j;
                        labl_pos_min += pos_min + "     \t";
                        lbl_pos_min.Text = labl_pos_min;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                await findLine("label6");
                if (pos_min != i)
                {
                    await findLine("label7");
                    SwapLabels(arr[i], pos_min, arr[pos_min], i);
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;

                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (getTextBoxVal())
            {

                for (int i = 0; i < ls2.Count; i++)
                {
                    if (i == 0)
                        drawLabel(new Point(436, 342), i, ls2[i]);
                    else
                    {
                        Label lbl = (Label)Controls["0"];
                        drawLabel(new Point(436 + lbl.Width * i + 10 * i, 342), i, ls2[i]);
                    }
                }

                selectionSort(ls2);
            }
        }
    }
}
