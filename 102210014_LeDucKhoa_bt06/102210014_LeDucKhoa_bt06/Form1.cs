using _102210014_LeDucKhoa_bt06.BLL;
using _102210014_LeDucKhoa_bt06.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _102210014_LeDucKhoa_bt06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            comboBox1.Items.Add(new CBBItem { value = 0, text = "All" });
            using(QLSVDB dB = new QLSVDB())
            {
               foreach(var item in dB.LSHes) 
               {
                    comboBox1.Items.Add(new CBBItem { value = item.IDLop, text = item.NameLop });
               }
                var prop = dB.SVs.Select(p => p);
                DbPropertyValues values = dB.Entry(prop.First()).CurrentValues;
                foreach (var name in values.PropertyNames)
                {
                    comboBox2.Items.Add(name);
                }
            }

        }
        public void ShowDGV(int id, string s)
        {
            dataGridView1.DataSource = QLSV_BLL.Instance.GetSV(id, s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDGV(((CBBItem)comboBox1.SelectedItem).value, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.d += new Form2.MyDel(ShowDGV);
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString().Replace(" ", "");
            Form2 f2 = new Form2(mssv);
            f2.d += new Form2.MyDel(ShowDGV);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sản phẩm ?", "Xóa sản phẩm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    using (QLSVDB db = new QLSVDB())
                    {
                        int i = 0;
                        foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                        {
                            string MSSV = dataGridView1.SelectedRows[i++].Cells["MSSV"].Value.ToString();
                            var s = db.SVs.Single(p => p.MSSV == MSSV);
                            db.SVs.Remove(s);
                        }
                        db.SaveChanges();
                        ShowDGV(((CBBItem)comboBox1.SelectedItem).value, textBox1.Text);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSV_BLL.Instance.Sort(comboBox2.SelectedIndex);
        }
    }
}
