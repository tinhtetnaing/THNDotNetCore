using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using THNDotNetCore.ConsoleApp.Models;

namespace THNDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogDataModel> lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Create Successful" : "Create Fail");

        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (blog == null)
            {
                Console.WriteLine("No Data Found");
            }

            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            var blog = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);

            if (blog is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                blog.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                blog.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                blog.BlogContent = content;
            }
            db.Entry(blog).State = EntityState.Modified;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Update Successful" : "Update Fail");
        }

        public void Delete(int id) 
        {
            AppDbContext db = new AppDbContext();
            var blog = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);

            if (blog is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Entry(blog).State = EntityState.Deleted;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Delete Successful" : "Delete Fail");
        }
    }
}
