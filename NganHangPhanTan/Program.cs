using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data;
using System.Data.SqlClient;
using NganHangPhanTan.Util;
using System.Text.RegularExpressions;
using NganHangPhanTan.DTO;

namespace NganHangPhanTan
{
    public static class Program
    {
        
        public static SqlConnection conn = new SqlConnection();
        public static String ConnectionStr; 
        //public static SqlDataReader myReader;
        public static String serverName = "";
        public static String MACNHT;
        //public static String currentServer = "";
        //public static String username = "";
        //public static String mlogin = "";
        //public static String password = "";

        //public static int brand = 0;//mChiNhanh

        public static string DISTRIBUTOR_NAME = "MINHHOANG";
        public static string REMOTE_LOGIN = "HTKN";
        public static string REMOTE_PASS = "123";
        public static string CONNECTION_STR_TEMPLATE = "Data Source={0};Initial Catalog=NGANHANG;{1}";
        public static String connstrPublisher = "Data Source=MINHHOANG;Initial Catalog=NGANHANG;Integrated Security=true";


        public static BindingSource bindingSource = new BindingSource();

        public static fMain frmChinh;
        public static fLogin frmLogin;

        public static User Login(string loginName)
        {
            SqlDataReader dataReader = Program.ExecuteSqlDataReader($"EXEC sp_LayThongTinNV '{loginName}'");
            if (dataReader == null)
                return null;

            if (!dataReader.Read())
            {
                MessageUtil.ShowInfoMsgDialog("Login bạn nhập không có quyền truy cập dữ liệu.\nVui lòng nhập lại mã nhân viên.");
                return null;
            }
            User user = new User(dataReader);
            dataReader.Close();
            return user;
        }

        public static void SetServerToRemote(string subcriber)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, $"User ID={REMOTE_LOGIN};password={REMOTE_PASS}");
        }

        public static void SetServerToSubcriber(string subcriber, string loginName, string pass)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, $"User ID={loginName};password={pass}");
        }

        public static void SetServerToDistributor(string subcriber)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, "Integrated Security=True");
        }

        public static bool CheckConnection()
        {
            
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {    
                Program.conn.ConnectionString = ConnectionStr;
                Program.conn.Open();
                return true ;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nXem lại tài khoản và mật khẩu.\n " + e.Message, "", MessageBoxButtons.OK);
                //Console.WriteLine(e.Message);
                return false;
            }

        }

        public static string LayChiNhanhHT()
        {
           // string query = "SELECT dbo.udf_LayChiNhanhHienTai()";
           // return (string)Program.ExecuteScalar(query);

            SqlDataReader dataReader = Program.ExecuteSqlDataReader("EXEC usp_LayChiNhanhHienTai");
            dataReader.Read();
            return dataReader.GetValue(0).ToString();

        }

        public static int kiemTraKhachHangTonTai(string KhachHangId)
        {
            return (int)Program.ExecSqlCheck("usp_KIEMTRAKHACHHANG", KhachHangId);
        
        }

        public static int kiemTraNhanVienTonTai(string NhanVienID)
        {
            return (int)Program.ExecSqlCheck("usp_KiemTraNhanVien", NhanVienID);

        }

        public static SqlDataReader ExecuteSqlDataReader(string query)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = new SqlConnection(ConnectionStr),
                CommandText = query,
                CommandType = CommandType.Text
            };

            SqlDataReader sqlDataReader;
            try
            {
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi kết nối cơ sở dữ liệu.\nKiểm tra lại tên đăng nhập và mật khẩu.\nChi tiết lỗi: {ex.Message}");
                return null;
            }
        }

        public static int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandTimeout = 600, // 10 mins
                };

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    rowsAffected = -2;
                }
            }

            return rowsAffected;
        }

        public static int ExecSqlCheck(String tenSP, String a)
        {
            String sql = $"DECLARE @return_value int EXEC @return_value = [dbo].[{tenSP}] @a SELECT 'Return Value' = @return_value";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            sqlCommand.Parameters.AddWithValue("@a", a);
            SqlDataReader dataReader = null;
            try
            {
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                conn.Close();
                return result_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return -1;
            }
        }

        public static int ExecuteNonQuery2(string query, object[] parameters = null)
        {
          

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandTimeout = 600, // 10 mins
                };

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                   command.ExecuteNonQuery();
                    return 0;
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    
                }
            }

            return -1;
        }

        public static DataTable ExecSqlDataTable(String cmd, bool isPub)
        {
            if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            if (isPub)
            {
                conn = new SqlConnection(ConnectionStr);
            }
            else
            {
                conn = new SqlConnection(ConnectionStr);
            }
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }



        public static object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                    data = command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    return null;
                }
            }

            return data;
        }


        public static DataTable ExecuteDataTable(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                try
                {
                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    data = null;
                }
            }

            return data;
        }

        
        public static int ExecuteNonQuery(string spName, SqlParameter[] parameters)
        {
            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(spName, connection)
                {
                    CommandTimeout = 600, // 10 mins
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    rowsAffected = -2;
                }
            }

            return rowsAffected;
        }



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Program.frmChinh = new fMain();
            //Application.Run(frmChinh);
            Program.frmLogin = new fLogin();
            Application.Run(frmLogin);
        }
    }
}
