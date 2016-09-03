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
    public partial class DAASort : Form
    {
        public DAASort()
        {
            InitializeComponent();
        }

        private void btnSelectionSort_Click(object sender, EventArgs e)
        {
            var selection_sort = new SelectionSort();
            selection_sort.Show();
            Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var insertion_sort = new InsertionSort();
            insertion_sort.Show();
            Hide();
        }
    }
}
