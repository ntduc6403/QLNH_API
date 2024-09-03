using API_QLNH.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_QLNH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NguoiDungController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //lấy từ cơ sở dữ liệu và trả về cho client. 

        [HttpPost]
        public JsonResult DangNhap(NguoiDung NguoiDung)
        {
            string query = "Select count(*) from nguoidung where TenDangNhap = '"+NguoiDung.TenDangNhap+ "' and MatKhau = '"+NguoiDung.MatKhau+"'";
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
            return new JsonResult(table);
        }

        //    [HttpPost]
        //    public JsonResult Post(NguoiDung NguoiDung)
        //    {
        //        string query = @"Insert into NguoiDung values
        //            (N'"+ NguoiDung.TenNguoiDung +"')";
        //        DataTable table = new DataTable();
        //        String sqlDataSource = _configuration.GetConnectionString("QLNH");
        //        SqlDataReader myReader;
        //        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //        {
        //            myCon.Open();
        //            using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //            {
        //                myReader = myCommand.ExecuteReader();
        //                table.Load(myReader);
        //                myReader.Close();
        //                myCon.Close();
        //            }
        //        }
        //        return new JsonResult("Thêm Mới Thành Công");
        //    }
        //    [HttpPut]
        //    public JsonResult Put(NguoiDung NguoiDung)
        //    {
        //        string query = @"Update NguoiDung set
        //            TenNguoiDung = N' " + NguoiDung.TenNguoiDung + "'" +
        //            " where MaNguoiDung = " + NguoiDung.MaNguoiDung; 
        //        DataTable table = new DataTable();
        //        String sqlDataSource = _configuration.GetConnectionString("QLNH");
        //        SqlDataReader myReader;
        //        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //        {
        //            myCon.Open();
        //            using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //            {
        //                myReader = myCommand.ExecuteReader();
        //                table.Load(myReader);
        //                myReader.Close();
        //                myCon.Close();
        //            }
        //        }
        //        return new JsonResult("Sửa  Thành Công");
        //    }
        //    [HttpDelete("{ma}")]
        //    public JsonResult Delete(int ma)
        //    {
        //        string query = @"Delete From NguoiDung " +

        //            "where MaNguoiDung = " + ma;
        //        DataTable table = new DataTable();
        //        String sqlDataSource = _configuration.GetConnectionString("QLNH");
        //        SqlDataReader myReader;
        //        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //        {
        //            myCon.Open();
        //            using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //            {
        //                myReader = myCommand.ExecuteReader();
        //                table.Load(myReader);
        //                myReader.Close();
        //                myCon.Close();
        //            }
        //        }
        //        return new JsonResult("Xóa Thành Công");
        //    }
        
    }
}
