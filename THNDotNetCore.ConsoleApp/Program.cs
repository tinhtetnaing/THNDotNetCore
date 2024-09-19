// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THNDotNetCore.ConsoleApp;

//AdoDotNetExample adoDotNet = new AdoDotNetExample();
//adoDotNet.Read();
//adoDotNet.Create("test_title","test_author","test_content");
//adoDotNet.Edit(15);
//adoDotNet.Update(15, "Update_Title", "Update_Author", "Update_Content");
//adoDotNet.Delete(15);

//DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Create("DapperTitle", "DapperAuthor", "DapperContent");
//dapper.Edit(29);
//dapper.Update(29, "Update_dapper_title", "Update_dapper_author", "Update_dapper_content");
//dapper.Read();
//dapper.Delete(29);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("EF_blogTitle", "EF_blogÄuthor", "EF_blogContent");
eFCoreExample.Edit(30);
eFCoreExample.Update(30, "Update_EFBlog_title", "Update_EFBlog_author", "Update_EFBlog_content");
eFCoreExample.Read();
//eFCoreExample.Delete(30);

Console.ReadKey();