// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THNDotNetCore.ConsoleApp;

AdoDotNetExample adoDotNet = new AdoDotNetExample();

adoDotNet.Read();

adoDotNet.Create("test_title","test_author","test_content");

adoDotNet.Edit(15);

adoDotNet.Update(15, "Update_Title", "Update_Author", "Update_Content");

adoDotNet.Delete(15);

Console.ReadKey();