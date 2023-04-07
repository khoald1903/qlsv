using _102210014_LeDucKhoa_bt06.BLL;
using _102210014_LeDucKhoa_bt06.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _102210014_LeDucKhoa_bt06
{
    public partial class Form2 : Form
    {
        bool flag = false;
        private string mssv;
        public delegate void MyDel(int ID, string Name);
        public MyDel d
        {
            get; set;
        }
        public Form2(string m = null)
        {
            InitializeComponent();
            if(m == null) flag= true;   
            mssv = m;
            SetCBB();
            setGUI();
        }
        public void SetCBB()
        {
            using (QLSVDB dB = new QLSVDB())
            {
                foreach (var item in dB.LSHes)
                {
                    comboBox1.Items.Add(new CBBItem { value = item.IDLop, text = item.NameLop });
                }
            }
        }
        private void setGUI()
        {
            SV s = QLSV_BLL.Instance.GetSVByMssv(mssv);
            if (s != null)
            {
                textBox1.Text = s.MSSV.ToString();
                textBox2.Text = s.Name.ToString();
                foreach (CBBItem item in comboBox1.Items)
                {
                    if (s.LSH.IDLop == item.value)
                        comboBox1.Text = item.text;
                }
                dateTimePicker1.Text = s.NS.ToString();
                textBox3.Text = s.DTB.ToString();
                radioButton1.Checked = s.Gender;
                radioButton2.Checked = !s.Gender;
                checkBox1.Checked = s.Anh;
                checkBox2.Checked = s.HocBa;
                checkBox3.Checked = s.CCCD;
                textBox1.ReadOnly= true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SV s = new SV
            {
                MSSV = textBox1.Text.ToString(),
                Name = textBox2.Text.ToString(),
                ID_Lop = ((CBBItem)comboBox1.SelectedItem).value,
                DTB = Convert.ToDouble(textBox3.Text),
                Gender = radioButton1.Checked,
                NS = Convert.ToDateTime(dateTimePicker1.Text.ToString()),
                Anh = checkBox1.Checked,
                HocBa = checkBox2.Checked,
                CCCD = checkBox3.Checked
            };
            QLSV_BLL.Instance.ExcuteDB(s, flag);
            d(0, null);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
