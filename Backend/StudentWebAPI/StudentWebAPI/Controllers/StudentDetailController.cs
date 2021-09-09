using StudentWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentWebAPI.Controllers
{
    public class StudentDetailController : ApiController
    {
        
        private StudentDBEntities1 db = new StudentDBEntities1();

        public HttpResponseMessage Get()
        {
            //var table = db.StudentDetails; 
            string query = @"
                select * from dbo.StudentMark_View
                ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["StudentAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpGet]
        [ActionName("GetAllStudent")]
        public HttpResponseMessage GetAllStudent()
        {
            var table = db.UserDetails.ToArray(); 

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var student = db.UserDetails.Where(data => data.Id == id).First();

            return Request.CreateResponse(HttpStatusCode.OK, student);
            ////var table = db.StudentDetails.Where(data => data.Id == id);

            //string query = @"
            //    select * from dbo.StudentMark_View
            //    ";
            ////var x = false;

            //DataTable table = new DataTable();
            //using (var con = new SqlConnection(ConfigurationManager.
            //    ConnectionStrings["StudentAppDB"].ConnectionString))
            //using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    da.Fill(table);
            //}

            //DataTable newtable = new DataTable();

            //// Use the Select method to find all rows matching the filter.
            //foundRows = table.Select();

            //// Print column 0 of each returned row.
            //for (int i = 0; i < foundRows.Length; i++)
            //{
            //    //Console.WriteLine(foundRows[i][1]);
            //    if(foundRows[i][1] == id)
            //    {
            //        var x = foundRows[i];
            //        newtable.Rows.Add(x);
            //        return Request.CreateResponse(HttpStatusCode.OK, newtable);
            //    }
            //    else
            //    {
            //        var tabledata = db.StudentDetails.Where(data => data.Id == id);
            //        return Request.CreateResponse(HttpStatusCode.OK, tabledata);
            //    }
            //}
            //return null;
            ////return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpGet]
        public HttpResponseMessage GetMark(string id)
        {
            var student = db.UserDetails.Where(data => data.Id == id).First();

            int sid = student.SId;

            string query = @"
                select * from dbo.Mark 
                ";

            DataTable marks = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["StudentAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(marks);
            }
            DataTable newtable = new DataTable();
            DataRow[] foundRows = marks.Select();

            // Print column 0 of each returned row.
            for (int i = 0; i < foundRows.Length; i++)
            {
                //Console.WriteLine(foundRows[i][1]);
                if ((foundRows[i][5]).ToString() != sid.ToString())
                {
                    var x = foundRows[i];
                    marks.Rows.Remove(x);
                       // Add(x);
                    
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, marks);

            //Mark mark = new Mark();
            ////var marks = db.Marks.ToArray();

            //var marks = from m in db.Marks
            //            select m;
            //var result = marks.Where(m => m.SId == sid).ToList();
            //    //db.Marks.Where(data => data.SId == sid).ToArray();
            ////Where(data => data.SId == sid).ToList();

            //return Request.CreateResponse(HttpStatusCode.OK, marks);
            //Request.CreateResponse(HttpStatusCode.OK, marks);


        }
    }
}
