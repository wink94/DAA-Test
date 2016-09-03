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
    public partial class InsertionSort : Form
    {
        List<string> ls = new List<string>();
        List<int> ls2 = new List<int>();


        public InsertionSort()
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
            int value, i = 1;
            while (i <= 7)
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
        async Task SwapLabels(int val1, int indx1, int val2, int indx2)
        {
            Label lbl1 = (Label)Controls[indx1.ToString()];
            Label lbl2 = (Label)Controls[indx2.ToString()];

            lbl1.BackColor = Color.Red;
            lbl2.BackColor = Color.Red;

            await Task.Delay(2000);
            lbl1.Text = val1.ToString();
            lbl2.Text = val2.ToString();


            lbl1.BackColor = Color.Green;
            lbl2.BackColor = Color.Green;
            await Task.Delay(2000);
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



        async void insertionSort(List<int> arr,string order)
        {
            int j, temp;
            string labl_i="",labl_j="";

            for(int i = 0; i < arr.Count-1; i++)
            {
                await findLine("label1");
                labl_i += i + "     \t";
                lbl_i.Text = labl_i;

                await findLine("label2");
                j = i+1; //assingn i to j
                labl_j += j + "     \t";
                lbl_j.Text = labl_j;


                await findLine("label3");
                //await matchTxtBox(j - 1, j);

                if (order == "Ascending")
                {
                    while (j > 0 && arr[j - 1] > arr[j])
                    {
                        if (j != i + 1)
                        {
                            await findLine("label3");
                            //await matchTxtBox(j - 1, j);
                        }

                        await findLine("label4");
                        await SwapLabels(arr[j], j - 1, arr[j - 1], j);
                        temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;

                        await findLine("label5");
                        j--;
                        labl_j += j + "     \t";
                        lbl_j.Text = labl_j;


                    }
                }
                else
                {

                    while (j > 0 && arr[j - 1] < arr[j])
                    {
                        if (j != i + 1)
                        {
                            await findLine("label3");
                            //await matchTxtBox(j - 1, j);
                        }

                        await findLine("label4");
                        await SwapLabels(arr[j], j - 1, arr[j - 1], j);
                        temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;

                        await findLine("label5");
                        j--;
                        labl_j += j + "     \t";
                        lbl_j.Text = labl_j;


                    }

                }


            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            if (getTextBoxVal() && cmbOrder.SelectedItem!=null)
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

                insertionSort(ls2, cmbOrder.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("select order");
            }

        }

        private void btnInsertionSortBack_Click(object sender, EventArgs e)
        {
            var main = new DAASort();
            main.Show();
            Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var i = 1;

            while (i <= ls2.Count)
            {
                TextBox txt = (TextBox)Controls[ls[i - 1]];
                txt.Clear();
                Label lbl=(Label)Controls[(i-1).ToString()];
                lbl.Dispose();
                i++;
                
            }

            cmbOrder.SelectedIndex = 0;
        }
    }
}
