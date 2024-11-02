using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using THNDotNetCore.Database.Models;
using THNDotNetCore.RestApi.ViewModels;

namespace THNDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString = "Data Source = DESKTOP-EPUBLLL; Initial Catalog= MyDB; User ID= sa; Password = sa@123;";

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogViewModel> lst = new List<BlogViewModel>();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lst.Add(new BlogViewModel
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                });
            }

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogViewModel item = new BlogViewModel();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0 And BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                item = new BlogViewModel
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                };
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[TBL_BLOG]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
		   ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Create Successful" : "Create Fail");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
         WHERE BlogId = @BlogId;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Update Successful" : "Update Fail");
        }

        [HttpPatch]
        public IActionResult PatchBlog(int id, BlogViewModel blog)
        {
            string condition = "";
            if (string.IsNullOrEmpty(blog.Title))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (string.IsNullOrEmpty(blog.Author))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (string.IsNullOrEmpty(blog.Content))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }

            if(condition.Length == 0)
            {
                return BadRequest("Invalid Parameter");
            }

            condition = condition.Substring(0, condition.Length - 2);

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[TBL_BLOG] SET {condition} WHERE BlogId = @BlogId;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blog.Id);
            if (!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            }
            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return Ok(result > 0 ? "Update Successful" : "Update Fail"); 
        }
    }
}
