using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace THNDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {

        private readonly string _connectionString = "Data Source = DESKTOP-EPUBLLL; Initial Catalog= MyDB; User ID= sa; Password = sa@123;";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public int Create(string title, string author, string content)
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
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                Console.WriteLine("Create successful");
            }
            else
            {
                Console.WriteLine("Create fail");
            }
            return result;
        }

        public void Edit(int blogId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0 And BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId",blogId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows) 
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public void Update(int blogId, string blogTitle, string blogAuthor, string blogContent)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
         WHERE BlogId = @BlogId;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            cmd.Parameters.AddWithValue("@BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blogContent);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Update Fail");
            }
        }

        public void Delete(int blogId) 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [DeleteFlag] = 1
         WHERE BlogId = @BlogId;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                Console.WriteLine("Delete Successful");
            }
            else
            {
                Console.WriteLine("Delete Fail");
            }
        }
    }
}
