using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treeheap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DAASort());
            /*int[] arr = { 7, 5, 9 };
            Class1 c = new Class1(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }*/


        }
    }
}
