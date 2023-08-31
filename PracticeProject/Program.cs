using PracticeProject;
using PracticeProject.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        using (BloggingContext db = new BloggingContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Blog blog = new Blog { BlogId = 1, Url = "blog1", Posts = new List<Post>() };

            db.Blogs.Add(blog);

            Post foodPost = new Post { PostId = 1, Title = "Food", Content = "Content about food", BlogId = 1, Blog = blog };
            Post sportPost = new Post { PostId = 2, Title = "Sport", Content = "Content about sport", BlogId = 1, Blog = blog };
            Post hobbiesPost = new Post { PostId = 3, Title = "Hobbies", Content = "Content about hobbies", BlogId = 1, Blog = blog };

            db.Posts.AddRange(foodPost, sportPost, hobbiesPost);
            db.SaveChanges();

            var posts = (from post in db.Posts where post.BlogId == 1 select post).ToList();
            foreach (Post p in posts)
            {
                Console.WriteLine($"{p.PostId}.{p.Title} - {p.Content}");
            }

            Post? postToUpdate = (from post in db.Posts where post.PostId == 1 select post).FirstOrDefault();
            if (postToUpdate != null )
            {
                postToUpdate.Title = "Tasty food";
                postToUpdate.Content = "Content about tasty food";
                db.Posts.Update(postToUpdate);
                db.SaveChanges();
            }

            Post? postToDelete = (from post in db.Posts where post.PostId == 2 select post).FirstOrDefault();
            if (postToDelete != null )
            {
                db.Posts.Remove(postToDelete);
                db.SaveChanges();
            }

            Console.WriteLine("\nAfter changes");
            posts = (from post in db.Posts where post.BlogId == 1 select post).ToList();
            foreach (Post p in posts)
            {
                Console.WriteLine($"{p.PostId}.{p.Title} - {p.Content}");
            }
        }
    }
}