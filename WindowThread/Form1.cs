using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(t != null && t.IsAlive == true )
            {
                return;
            }
            A a = new A();
            a.a = this.button1;
            a.b = button2;
            a.c = button3;
            a.d = button4;
            t = new Thread(new ParameterizedThreadStart(ChangeButton));
            t.Start(a);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            t.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void ChangeButton(object b)
        {
            while (true)
            {
                A a = (A)b;
                var positionButton = a.a.Location;
                a.a.Location = a.b.Location;
                a.b.Location = a.c.Location;
                a.c.Location = a.d.Location;
                a.d.Location = positionButton;
                Thread.Sleep(200);
            }
        }
        private Thread t;
    }
    public class A
    {
        public Button a;
        public Button b;
        public Button c;
        public Button d;
    }
}
