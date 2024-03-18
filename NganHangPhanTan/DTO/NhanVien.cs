using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class NhanVien
    {
        public readonly static string MANV_HEADER = "MANV";
        public readonly static string HO_HEADER = "HO";
        public readonly static string TEN_HEADER = "TEN";
        public readonly static string DIACHI_HEADER = "DIACHI";
        public readonly static string PHAI_HEADER = "PHAI";
        public readonly static string SODT_HEADER = "SODT";

        private string MANV;
        private string HO;
        private string TEN;
        private string DIACHI;
        private string PHAI;
        private string SODT;

        public NhanVien() { }

        public NhanVien(string MANV, string HO, string TEN, string DIACHI, string PHAI, string SODT)
        {
            this.MANV = MANV;
            this.HO = HO;
            this.TEN = TEN;
            this.DIACHI = DIACHI;
            this.PHAI = PHAI;
            this.SODT = SODT;
        }

        public NhanVien(DataRowView row)
        {
            MANV = (string)row[MANV_HEADER];
            HO = (string)row[HO_HEADER];
            TEN = (string)row[TEN_HEADER];
            DIACHI = (string)row[DIACHI_HEADER];
            PHAI = (string)row[PHAI_HEADER];
            SODT = (string)row[SODT_HEADER];
        }

        public string MaNV { get => MANV; set => MANV = value; }
        public string Ho { get => HO; set => HO = value; }
        public string Ten { get => TEN; set => TEN = value; }
        public string DiaChi { get => DIACHI; set => DIACHI = value; }
        public string Phai { get => PHAI; set => PHAI = value; }
        public string SoDT { get => SODT; set => SODT = value; }
    }
}
