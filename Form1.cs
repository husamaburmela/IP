using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;

namespace IP
{
    public partial class Form1 : Form
    {

        //Counts the pings
        private int pingsSent;
        //canbe used to notify when the operation completes
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        IPAddress test1 = IPAddress.Parse("192.168.1.1");
        IPAddress test2 = IPAddress.Loopback;
        IPAddress test3 = IPAddress.Broadcast;
        IPAddress test4 = IPAddress.Any;
        IPAddress test5 = IPAddress.None;







        public Form1()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void B4_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress test1 = IPAddress.Parse("192.168.1.1");
                IPEndPoint ie = new IPEndPoint(test1, 8000);
                TextBox9.Texts = ie.ToString();
                TextBox10.Texts = ie.AddressFamily.ToString();
                TextBox11.Texts = ie.Address.ToString();
                TextBox12.Texts = ie.Port.ToString();
                TextBox13.Texts = IPEndPoint.MinPort.ToString();
                TextBox14.Texts = IPEndPoint.MaxPort.ToString();
                ie.Port = 80;
                TextBox15.Texts = ie.ToString();
                SocketAddress sa = ie.Serialize();
                TextBox16.Texts = sa.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "information");
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry ihe = Dns.GetHostByName(Dns.GetHostName());
                IPAddress myself = ihe.AddressList[0];
                if (IPAddress.IsLoopback(test2))
                {
                    TextBox1.Texts = test2.ToString();

                }
                TextBox2.Texts = myself.ToString();
                TextBox3.Texts = test1.ToString();
                TextBox4.Texts = test3.ToString();
                TextBox5.Texts = test4.ToString();
                TextBox6.Texts = test5.ToString();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information");
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            try
            {
                string hostName = Dns.GetHostName();
                TextBox7.Texts = hostName;
                IPHostEntry myself = Dns.GetHostByName(hostName);
                foreach (IPAddress address in myself.AddressList)
                {
                    TextBox8.Texts = address.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "information");
            }
        }

        private void TextBox6__TextChanged(object sender, EventArgs e)
        {

        }

        private void B5_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ia = IPAddress.Parse("127.0.0.1");
                IPEndPoint ie = new IPEndPoint(ia, 8000);
                Socket test = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Stream, ProtocolType.Tcp);

                TextBox17.Texts = test.AddressFamily.ToString();
                TextBox18.Texts = test.SocketType.ToString();
                TextBox19.Texts = test.ProtocolType.ToString();
                TextBox20.Texts = test.Blocking.ToString();
                test.Blocking= false;
                TextBox21.Texts = test.Blocking.ToString();
                TextBox22.Texts = test.Connected.ToString();

                test.Bind(ie);
                IPEndPoint iep = (IPEndPoint)test.LocalEndPoint;
                TextBox23.Texts = iep.ToString();
                test.Close();







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "information");
            }
        }

        private void B6_Click(object sender, EventArgs e)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply PingStatus = pingSender.Send(IPAddress.Parse("208.69.34.231"), 1000);
                if (PingStatus.Status==IPStatus.Success)
                {
                    MessageBox.Show("true");
                }
                else
                {
                    MessageBox.Show("false");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "information");
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            TextBox1.Texts = null;
             TextBox2.Texts = null;
            TextBox3.Texts = null;
            TextBox4.Texts = null;
            TextBox5.Texts = null;
            TextBox6.Texts = null;
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            TextBox7.Texts = null;
            TextBox8.Texts = null;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            TextBox9.Texts =null;
            TextBox10.Texts = null;
            TextBox11.Texts = null;
            TextBox12.Texts = null;
            TextBox13.Texts = null;
            TextBox14.Texts = null;    
            TextBox15.Texts = null;
            TextBox16.Texts = null;
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            TextBox17.Texts = null;
            TextBox18.Texts = null;
            TextBox19.Texts = null;
            TextBox20.Texts = null;
           
            TextBox21.Texts = null;
            TextBox22.Texts = null;

            
            
            TextBox23.Texts = null;
        }
    }
}
