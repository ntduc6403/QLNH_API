using API_QLNH.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLNH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThucDonController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ThucDonController(IConfiguration configuration)
        {
               _configuration = configuration;
        }

        //lấy từ cơ sở dữ liệu và trả về cho client. 

       [HttpGet]
        public JsonResult Get()
        {
            string query = "Select MaThucDon , TenThucDon from ThucDon";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLNH");
            SqlDataReader myReader ;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(ThucDon thucdon)
        {
            string query = @"Insert into ThucDon values
                (N'"+ thucdon.TenThucDon +"')";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLNH");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm Mới Thành Công");
        }
        [HttpPut]
        public JsonResult Put(ThucDon thucdon)
        {
            string query = @"Update ThucDon set
                TenThucDon = N' " + thucdon.TenThucDon + "'" +
                " where MaThucDon = " + thucdon.MaThucDon; 
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLNH");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Sửa  Thành Công");
        }
        [HttpDelete("{ma}")]
        public JsonResult Delete(int ma)
        {
            string query = @"Delete From ThucDon " +
            
                "where MaThucDon = " + ma;
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLNH");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Xóa Thành Công");
        }
    }
}
