using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using THNDotNetCore.ConsoleApp.Models;

namespace THNDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source = DESKTOP-EPUBLLL; Initial Catalog= MyDB; User ID= sa; Password = sa@123;";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from TBL_BLOG where DeleteFlag = 0";
                List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[TBL_BLOG]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
		   ,@BlogAuthor
           ,@BlogContent)";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Create Successful" : "Create Fail");

            }
        }

        public void Edit(int blogId)
        {
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0 And BlogId = @BlogId";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                BlogDataModel blog = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = blogId
                }).FirstOrDefault();

                if (blog == null)
                {
                    Console.WriteLine("No Data Found");
                }

                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);

            }
        }

        public void Update(int blogId, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
         WHERE BlogId = @BlogId;";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = blogId,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Update Successful" : "Update fail");
            }
        }

        public void Delete(int blogId)
        {
            string query = @"UPDATE [dbo].[TBL_BLOG]
           SET [DeleteFlag] = 1
         WHERE BlogId = @BlogId;";
            using (IDbConnection db = new SqlConnection (_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = blogId
                });
                Console.WriteLine(result == 1 ? "Delete Successful" : "Delete fail");
            }
        }
    }
}
