using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THNDotNetCore.Shared;

namespace THNDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample2
    {
        private readonly string _connectionString = "Data Source = DESKTOP-EPUBLLL; Initial Catalog= MyDB; User ID= sa; Password = sa@123;";
        private readonly AdoDotNetService _adoDotNetService;

        public AdoDotNetExample2()
        {
            _adoDotNetService = new AdoDotNetService(_connectionString);
        }

        public void Read()
        {
            string query = @"SELECT [BlogId]
                ,[BlogTitle]
                ,[BlogAuthor]
                ,[BlogContent]
                ,[DeleteFlag]
            FROM [dbo].[TBL_BLOG] where DeleteFlag = 0";
            var dt = _adoDotNetService.Query(query);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public void Edit()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();
            string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
          FROM [dbo].[TBL_BLOG] where DeleteFlag = 0 And BlogId = @BlogId";

            var dt = _adoDotNetService.Query(query, new SqlParameterModel
            {
                Name = "@BlogId",
                Value = id
            });
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
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
            var result = _adoDotNetService.Execute(query, 
                new SqlParameterModel("@BlogTitle", title),
                new SqlParameterModel("@BlogAuthor", author),
                new SqlParameterModel("@BlogContent", content));
            Console.WriteLine(result > 0 ? "Create Successful" : "Create Fail");
        }
    }
}
