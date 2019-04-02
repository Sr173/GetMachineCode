using SufeiUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace getMachineCode {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public string GetCpuInfo() {
            string cpuInfo = "";
            try {
                using (ManagementClass cimobject = new ManagementClass("Win32_Processor")) {
                    ManagementObjectCollection moc = cimobject.GetInstances();

                    foreach (ManagementObject mo in moc) {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                        mo.Dispose();
                    }
                }
            } catch (Exception) {
                throw;
            }
            return cpuInfo.ToString();
        }

        string GetRandStr(int num) {
            Random r = new Random(500 % 10086);

            string s = "";

            for (int i = 0; i < num; i++) {
                s += (char)r.Next(0x41, 0x5A); ;
            }
            return s;
        }

        private void Form1_Load(object sender, EventArgs e) {

            textBox1.Text = FingerPrint.GetHash( FingerPrint.biosId() + FingerPrint.macId() /*+ FingerPrint.cpuId()*/);


            //12345678912345678912345678912345
        }
    }
}
