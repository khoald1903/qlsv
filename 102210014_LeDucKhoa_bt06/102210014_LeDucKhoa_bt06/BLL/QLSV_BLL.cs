using _102210014_LeDucKhoa_bt06.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _102210014_LeDucKhoa_bt06.BLL
{
    internal class QLSV_BLL
    {
        private static QLSV_BLL _Instance;

        public static QLSV_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSV_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        public QLSV_BLL() { }
        public List<SV> GetSV(int id, string text)
        {
            QLSVDB db = new QLSVDB();
            List<SV> list= new List<SV>();
            if (id == 0 && text == null)
            {
                list.AddRange(db.SVs.Select(p => p));
            }
            else if(id == 0 && text != null)
            {
                list.AddRange(db.SVs.Where(p => p.Name.Contains(text)).Select(p => p).ToArray());
            }
            else if(id != 0 && text == null)
            {

                list.AddRange(db.SVs.Where(p => p.ID_Lop == id).Select(p => p).ToArray());
            }
            else if (id != 0 && text != null)
            {

                list.AddRange(db.SVs.Where(p => p.Name.Contains(text) && p.ID_Lop == id).Select(p => p).ToArray());
            }
            return list;
        }
        public SV GetSVByMssv(string mssv)
        {
            if (mssv == null) return null;
            QLSVDB db = new QLSVDB();
            List<SV> list = new List<SV>();
            list.AddRange(db.SVs.Where(p => p.MSSV == mssv).Select(p => p).ToArray());
            return list[0];
        }
        public void ExcuteDB(SV s, bool flag)
        {
            QLSVDB db = new QLSVDB();
            if(flag == true)
            {
                db.SVs.Add(s);
            }
            else
            {
                db.SVs.AddOrUpdate(s);
            }
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể thêm do ID đã tồn tại!");
            }
        }
        public List<SV> Sort(int SelectedIndex)
        {
            QLSVDB dB = new QLSVDB();
            List<SV> temp = new List<SV>();
            if (SelectedIndex == 0)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.MSSV).ToList();
            }
            else if (SelectedIndex == 1)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.Name).ToList();
            }
            else if (SelectedIndex == 2)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.ID_Lop).ToList();
            }
            else if (SelectedIndex == 3)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.NS).ToList();
            }
            else if (SelectedIndex == 4)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.DTB).ToList();
            }
            else if (SelectedIndex == 5)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.Gender).ToList();
            }
            else if (SelectedIndex == 6)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.Anh).ToList();
            }
            else if (SelectedIndex == 7)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.HocBa).ToList();
            }
            else if (SelectedIndex == 8)
            {
                temp = dB.SVs.Select(p => p).OrderBy(p => p.CCCD).ToList();
            }
            return temp;
        }
    }
}
