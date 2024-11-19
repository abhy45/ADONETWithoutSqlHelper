using ADONETWithoutSqlHelper.BAL;
using ADONETWithoutSqlHelper.BAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONETWithoutSqlHelper
{
    public partial class Form1 : Form
    {
        SqlConnection MyConn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetsingleData();
            List<userModel> lstmodel = new List<userModel>();
            lstmodel = DataInModel();
            dataGridView1.DataSource = GetDataINDataTable();
        }

        private void GetsingleData()
        {
            ConnectDB();
            string querry = "select username from tbl_Login where LoginId=2";
            using (SqlCommand cmd = new SqlCommand(querry, MyConn))
            {
                string user = Convert.ToString( cmd.ExecuteScalar());
                textBox1.Text = user;
            }
        }


        private List<userModel> DataInModel()
        {
            DataTable dt = new DataTable();
            string querry = "select * from tbl_Login";
            List<userModel> lst = new List<userModel>();
            using (SqlCommand cmd = new SqlCommand(querry, MyConn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    userModel userModel = new userModel();
                    while (reader.Read())
                    {
                        userModel.LoginId = Convert.ToInt32(reader["LoginId"]);
                        userModel.Username = Convert.ToString(reader["username"]);
                        userModel.Password = Convert.ToString(reader["password"]);
                        userModel.CPassword = Convert.ToString(reader["CPassword"]);
                        userModel.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        lst.Add(userModel);
                    }
                }
            }
            return lst;
        }

        private DataTable GetDataINDataTable()
        {
            DataTable dt = new DataTable();
            string querry = "select * from tbl_Login";
            ConnectDB();
            using (SqlCommand cmd = new SqlCommand(querry, MyConn))
            {
                using (SqlDataAdapter adapter = new  SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
                return dt;
        }

        private void ConnectDB()
        {
            try
            {
                MyConn = new SqlConnection(MySqlHelper.ConnectionString);
                this.MyConn.Open();
            }
            catch (Exception ex) { }
        }



        private void SaveNoiseInspectionSpecification()
        {
            if (true)
            {
                //insert
                string InsertQuerry = "insert  into TsFc_NoiseInspection (MasterQr,Reclinerfwd_Revnoisedb,LumberUp_Downnoisedb," +
                    "Reclinertraveltime,LumberTravelTime,ReclinerMotorCurrent,LumberMotor,ReclinerMotorVoltage,LumberMotorVoltage)" +
                    "values ('hh',1,1,1,1,1,1,1,1,1) ";
                using (SqlCommand cmd = new SqlCommand(InsertQuerry, MyConn))
                {
                    int roweffect = cmd.ExecuteNonQuery();
                }
            }
            else
            {
                //update
                string UpdateQuerry = "update  TsFc_NoiseInspection set Reclinerfwd_Revnoisedb='fff',LumberUp_Downnoisedb='1'," +
                "Reclinertraveltime='1',LumberTravelTime='1',ReclinerMotorCurrent='1',LumberMotor='1',ReclinerMotorVoltage='1',LumberMotorVoltage='1'" +
               "where MasterQr='fff'";
                using (SqlCommand cmd = new SqlCommand(UpdateQuerry, MyConn))
                {
                    int roweffect = cmd.ExecuteNonQuery();
                }
            }

        }



    }
}
