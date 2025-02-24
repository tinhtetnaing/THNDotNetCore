﻿namespace THNDotNetCore.MinimalApi.Endpoints.Blog;

public static class BlogEndpoint
{
    public static void MapBlogEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/blogs", () =>
        {
            AppDbContext db = new AppDbContext();
            var model = db.TblBlogs.AsNoTracking().ToList();
            return Results.Ok(model);
        })
        .WithName("GetBlogs")
        .WithOpenApi();

        app.MapGet("/blogs/{id}", (int id) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Results.BadRequest("No data found.");
            }
            return Results.Ok(item);
        })
        .WithName("GetBlogById")
        .WithOpenApi();

        app.MapPost("/blogs", (TblBlog blog) =>
        {
            AppDbContext db = new AppDbContext();
            db.TblBlogs.Add(blog);
            db.SaveChanges();
            return Results.Ok(blog);
        })
        .WithName("CreateBlogs")
        .WithOpenApi();

        app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Results.BadRequest("No data found.");
            }

            item.BlogId = blog.BlogId;
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

            return Results.Ok(blog);
        })
        .WithName("UpdateBlogs")
        .WithOpenApi();

        app.MapDelete("/blogs", (int id) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Results.BadRequest("No data found");
            }

            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            return Results.Ok();
        })
        .WithName("DeleteBlogs")
        .WithOpenApi();
    }
}
