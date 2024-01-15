using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using _2022_2023.Models;
namespace _2022_2023.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên 

        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }
        public StoreContext()
        {
        }

        // Câu 1: Thêm hành khách
        public void ThemHanhKhach(HanhKhach hk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var sql = "Insert into hanhkhach values(@mahk, @hoten, @diachi, @dienthoai)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mahk", hk.Mahk);
                cmd.Parameters.AddWithValue("hoten", hk.HoTen);
                cmd.Parameters.AddWithValue("diachi", hk.DiaChi);
                cmd.Parameters.AddWithValue("dienthoai", hk.DienThoai);

                cmd.ExecuteNonQuery();
            }
        }
        // Câu 2: Liệt kê chuyến bay
        public (ChuyenBay, List<object>) LietKeChuyenBay(string mach)
        {
            ChuyenBay chuyenbay = new ChuyenBay();
            List<object> danhsachhanhkhach = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var sql = "select * from chuyenbay where mach = @mach";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mach", mach);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        chuyenbay.MaCH = reader.GetString(0);
                        chuyenbay.TenCH = reader.GetString(1);
                        chuyenbay.DDi = reader.GetString(2);
                        chuyenbay.DDen = reader.GetString(3);
                        chuyenbay.Ngay = reader.GetString(4);
                        chuyenbay.GBay = reader.GetString(5);
                        chuyenbay.GDen = reader.GetString(6);
                        chuyenbay.Thuong = Convert.ToInt32(reader.GetString(7));
                        chuyenbay.VIP = Convert.ToInt32(reader.GetString(8));
                    }
                    reader.Close();
                }
                sql = "select hoten, dienthoai, loaighe, soghe, A.mahk from hanhkhach A, ct_cb B, chuyenbay C where A.mahk = B.mahk and B.mach = C.mach and C.mach = @mach";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mach", mach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var loaighe = "";
                        if (Convert.ToInt32(reader.GetString(2)) == 0)
                        {
                            loaighe = "Thường";
                        }
                        else loaighe = "Vip";
                        var hk = new
                        {
                            HoTen = reader.GetString(0),
                            DienThoai = reader.GetString(1),
                            LoaiGhe = loaighe,
                            SoGhe = reader.GetString(3),
                            MaHK = reader.GetString(4),
                        };
                        danhsachhanhkhach.Add(hk);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return (chuyenbay, danhsachhanhkhach);
        }
        // Câu 3: Thêm hành khách
        public ChuyenBay ThemHanhKhachVaoChuyenBay(string mach, string mahk, string soghe, string loaighe)
        {
            ChuyenBay chuyenbay = new ChuyenBay();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var sql = "select * from chuyenbay where mach = @mach";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mach", mach);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        chuyenbay.MaCH = reader.GetString(0);
                        chuyenbay.TenCH = reader.GetString(1);
                        chuyenbay.DDi = reader.GetString(2);
                        chuyenbay.DDen = reader.GetString(3);
                        chuyenbay.Ngay = reader.GetString(4);
                        chuyenbay.GBay = reader.GetString(5);
                        chuyenbay.GDen = reader.GetString(6);
                        chuyenbay.Thuong = Convert.ToInt32(reader.GetString(7));
                        chuyenbay.VIP = Convert.ToInt32(reader.GetString(8));
                    }
                    reader.Close();
                }
                if(mahk != null)
                {
                    sql = "insert into ct_cb values(@mach, @mahk, @soghe, @loaighe)";
                    int loai = 0;
                    cmd = new MySqlCommand(sql, conn);
                    if (loaighe == "Vip") loai = 1;
                    cmd.Parameters.AddWithValue("mach", mach);
                    cmd.Parameters.AddWithValue("mahk", mahk);
                    cmd.Parameters.AddWithValue("soghe", soghe);
                    cmd.Parameters.AddWithValue("loaighe", loai);
                    cmd.ExecuteNonQuery();

                }
            }
            return chuyenbay;
        }
        // Câu 3: Sửa hành khách
        public void SuaHanhKhach(string mach, string mahk, string soghe, string loaighe)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                int loai = 0;
                if (loaighe == "Vip") loai = 1;
                var sql = "update ct_cb set loaighe = @loaighe, soghe = @soghe where mach = @mach and mahk = @mahk";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("loaighe", loai);
                cmd.Parameters.AddWithValue("soghe", soghe);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("mahk", mahk);
                cmd.ExecuteNonQuery();

            }

        }
        // Câu 3: Xóa hành khách
        public void XoaHanhKhach(string mach, string mahk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var sql = "delete from ct_cb where mach = @mach and mahk = @mahk";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("mahk", mahk);
                cmd.ExecuteNonQuery();

            }

        }
    }
}