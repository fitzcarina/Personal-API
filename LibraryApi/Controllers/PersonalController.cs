using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LibraryApi.Controllers
{
    //  [Route("api/[controller]")]
    //  [ApiController]
    //public class PersonalController : ControllerBase
    //{

    [Route("[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PersonalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        //http://localhost:6030/api/personal
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from tbl_personal";



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
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
        //nur aktive Mitarbeiter
        //https://localhost:44383/personal/aktiv
             [HttpGet("aktiv")]
            public JsonResult aktiv()
            {
                string query = @"select * from tbl_personal where aktiv=1";



                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
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
        //genau 1 Mitarbeiter
        //https://localhost:44383/personal/genauerMitarbeiter?pnr=628
        [HttpGet("Mitarbeiter")]
        public JsonResult genauerMitarbeiter(int pnr)
        {
            string query = @"select * from tbl_personal where pnr="+pnr;



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
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
    } 
}
//}
