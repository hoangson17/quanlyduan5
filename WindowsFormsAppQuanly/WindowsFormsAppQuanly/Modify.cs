using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsAppQuanly
{
    internal class Modify
    {
       public Modify() { }
       SqlCommand sqlCommand;//dùng để truy vấn câu lệnh insert, update,delete,...
        private SqlDataReader dataReader;
        SqlDataReader sqlDataReader;//dùng để đọc dữ liệu trong bảng
       public List<NHANVIEN> TaiKhoans(string query)//check tai khoan
        {
            List<NHANVIEN> TaiKhoans = new List<NHANVIEN>();
            using(SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query,sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    TaiKhoans.Add(new NHANVIEN(dataReader.GetString(7), dataReader.GetString(8)));
                }


                sqlConnection.Close();
            }
            return TaiKhoans;
        }
        public void Command(string query)//dang ky tai khoan
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand (query,sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi cau truy van
                sqlConnection.Close();
            }
        }
    }
}
