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
    public partial class Form1 : Form
    {
        private int pixX = 30 * 72 / 96;
        private int pixY = 45 * 72 / 96;
        private int HeapSize;
        private int count = 0;
        int[] arr2=new int[15]  ;
        List<string> ls = new List<string>();
        List<int> ls2 = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                ls.Add("textBox" + i);

            }
        }


        public void setLabel()
        {
            //label1.Location = new Point(20,20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //setLabel();
             int[,] arr = new int[15, 2];
             int[] a = { 10, 12,13,14,15,6,7,8,9,10,11,12,13,14,15};
             drawTree( 0, Width, 30, 100, 0, arr, arr2);
            HeapSize = count;
            //drawLabel(new Point(55,55), 5, 45);
        }

        void drawLabel(Point p,int index,int content)
        {
            Label lbl = new Label();
            lbl.Name = index.ToString();
            lbl.Location = p;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.AutoSize = false;
            lbl.BackColor = Color.Green;
            lbl.Font = new Font(FontFamily.GenericSerif, 20);
            lbl.Width = 45;
            lbl.Height = 30;
            lbl.Text = Convert.ToString(content);
            Controls.Add(lbl);
        }

       public  async Task Swap(int val1,int indx1,int val2,int indx2)
        {
            Label lbl1 = (Label)Controls[indx1.ToString()];
            Label lbl2 = (Label)Controls[indx2.ToString()];

            lbl1.BackColor = Color.Red;
            lbl2.BackColor = Color.Red;
            await Task.Delay(5000);
            lbl1.Text = val1.ToString();
            lbl2.Text = val2.ToString();
            await Task.Delay(5000);

            lbl1.BackColor = Color.Green;
            lbl2.BackColor = Color.Green;
            await Task.Delay(2000);
        }

        void getTextBoxVal()
        {
           
            
            

            for (int i = 1; i <= 15; i++)
            {
                
                TextBox txt = (TextBox)Controls[ls[i - 1]];
                if (txt.Text != null && txt.Text != "")
                {
                    count++;
                    arr2[i - 1] = Convert.ToInt32(txt.Text);
                }
            }
        }

        public void drawTree( int StartWidth, int EndWidth, int StartHeight, int Level, int n, int[,] arr, int[] A)
        {

            if (n > count-1)
                return;
            else
            {
                //g.Graphics.setFont(new Font(TOOL_TIP_TEXT_KEY, Font.BOLD, 20));
                Graphics g = CreateGraphics();
                //g.Graphics.DrawString(A[n].ToString(),new Font(FontFamily.GenericSansSerif,20), new SolidBrush(Color.Black), new Point((StartWidth + EndWidth) / 2, StartHeight));
                //n*=2;
                drawLabel(new Point((StartWidth + EndWidth) / 2, StartHeight),n, A[n]);

                arr[n,0] = (StartWidth + EndWidth) / 2;
                arr[n,1] = StartHeight;

                if (n > 0 && n < 15)
                {
                    if (n % 2 != 0)
                    {
                        g.DrawLine(new Pen(Color.Black),(StartWidth + EndWidth) / 2 + pixX/2, StartHeight+pixY, arr[(n - 1) / 2,0] + pixX / 2, arr[(n - 1) / 2,1] + pixY);
                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Black),(StartWidth + EndWidth) / 2+pixX / 2, StartHeight+pixY, arr[(n - 2) / 2,0], arr[(n - 2) / 2,1]);
                    }
                }

               

                drawTree( StartWidth, (StartWidth + EndWidth) / 2, StartHeight + Level, Level + 1, n * 2 + 1, arr, A);
                drawTree( (StartWidth + EndWidth) / 2, EndWidth, StartHeight + Level, Level + 1, 2 * n + 2, arr, A);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Cursor.Position.X + " " + Cursor.Position.X);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getTextBoxVal();
        }


        public void Heapify(int[] arr, int i)
        {
            int left, right, largest;

            left = 2 * i + 1;
            right = 2 * i + 2;

            if (left <= HeapSize - 1 && arr[left] > arr[i])
                largest = left;
            else
                largest = i;

            if (right <= HeapSize - 1 && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                Exchange(arr, largest, i);

                Heapify(arr, largest);
            }

        }

        public void Exchange(int[] arr, int index1, int index2)
        {
            int temp;
            Task t=Swap(arr[index1],index2, arr[index2], index1);
            temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        public void Build_Heap(int[] arr)
        {

            for (int i = (HeapSize) / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }

        public void HeapSort(int[] arr)
        {
            //HeapSize = arr.Length;
            Build_Heap(arr);

            for (int i = HeapSize - 1; i >= 1; i--)
            {
                Exchange(arr, 0, i);
                HeapSize--;
                Heapify(arr, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeapSort(arr2);
        }
    }
}
