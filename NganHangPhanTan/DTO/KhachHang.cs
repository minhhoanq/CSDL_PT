using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class KhachHang
    {
        public static readonly string CMND_HEADER = "CMND";
        public static readonly string HO_HEADER = "HO";
        public static readonly string TEN_HEADER = "TEN";
        public static readonly string DIACHI_HEADER = "DIACHI";
        public static readonly string PHAI_HEADER = "PHAI";
        public static readonly string NGAYCAPKHACH_HEADER = "NGAYCAP";
        public static readonly string SODT_HEADER = "SODT";

        private string CMND;
        private string HO;
        private string TEN;
        private string DIACHI;
        private string PHAI;
        private DateTime NGAYCAPKHACH;
        private string SODT;

        public KhachHang(string CMND, string HO, string TEN, string DIACHI, string PHAI, DateTime NGAYCAPKHACH, string SODT)
        {
            this.CMND = CMND;
            this.HO = HO;
            this.TEN = TEN;
            this.DIACHI = DIACHI;
            this.PHAI = PHAI;
            this.NGAYCAPKHACH = NGAYCAPKHACH;
            this.SODT = SODT;
        }

        public KhachHang(DataRowView row)
        {
            this.CMND = (string)row["CMND"];
            this.HO = (string)row["HO"];
            this.TEN = (string)row["TEN"];
            this.DIACHI = (string)row["DIACHI"];
            this.PHAI = (string)row["PHAI"];
            this.NGAYCAPKHACH = (DateTime)row["NGAYCAP"];
            this.SODT = (string)row["SODT"];
        }

        public string Cmnd { get => CMND; set => CMND = value; }
        public string Ho { get => HO; set => HO = value; }
        public string Ten { get => TEN; set => TEN = value; }
        public string DiaChi { get => DIACHI; set => DIACHI = value; }
        public string Phai { get => PHAI; set => PHAI = value; }
        public DateTime NgayCapKhach { get => NGAYCAPKHACH; set => NGAYCAPKHACH = value; }
        public string SoDT { get => SODT; set => SODT = value; }
    }
}
