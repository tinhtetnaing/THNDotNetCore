// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using THNDotNetCore.Database.Models;

Console.WriteLine("Hello, World!");

//AppDbContext db = new AppDbContext();
//var lst = db.TblBlogs.ToList();

//foreach(var item in lst)
//{
//    Console.WriteLine(item.BlogId);
//    Console.WriteLine(item.BlogTitle);
//    Console.WriteLine(item.BlogAuthor);
//    Console.WriteLine(item.BlogContent);
//}


var blog = new BlogModel
{
    Id = 1,
    Title = "Test Title",
    Author  =  "Test Author",
    Content = "Test Content"
};

//var JsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented);
var JsonStr = blog.ToJson();
Console.WriteLine(JsonStr);

var JsonStr2 = """"{"Id":1,"Title":"Test Title","Author":"Test Author","Content":"Test Content"}"""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(JsonStr2);
Console.WriteLine(blog2.Title );

public class BlogModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }  
    public string Content { get; set; }

}

public static class Extension //DevCode
{
    public static string ToJson(this object obj)
    {
        var JsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return JsonStr;
    }
}