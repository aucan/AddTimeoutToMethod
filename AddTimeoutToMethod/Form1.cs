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

namespace AddTimeoutToMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = MethodWithTimeout("Test", 3);
            MessageBox.Show(result);
        }

        private string MethodWithTimeout(string input, int timeout)
        {
            var task = Task.Run(() => SomeMethod(input));
            if (task.Wait(TimeSpan.FromSeconds(timeout)))
                return task.Result;
            else
                return "Time out!";
        }

        private string SomeMethod(string input)
        {
            string result = input ;
            Random rnd= new Random();
            int sleep = rnd.Next(100,4000);
            MessageBox.Show("Result will send in :"+ sleep.ToString()+" ms");
            Thread.Sleep(sleep);
            return "Received : "+result;
        }
    }
}
