using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ReactBackend.Data;
using ReactBackend.Interfaces;

namespace ReactBackend.Repository
{
    public class PostsRepository : IPostsRepository
    {
        private readonly DataContext _context;

        public PostsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {           
            return await _context.Posts.ToListAsync();
        }

        public bool Add(Post post)
        {
            _context.Add(post);
            return Save();
        }

        public bool PostExists(int postId)
        {
            return _context.Posts.Any(p => p.PostId == postId);
        }

        public Post GetPost(int id)
        {
            return _context.Posts.Where(p => p.PostId == id).FirstOrDefault();
        }

        public bool Delete(int postId)
        {

            Post postToDelete = GetPost(postId);

            _context.Remove(postToDelete);

            //var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(postToDelete);
            return Save();
        }

        public bool Update(Post post)
        {
            _context.Update(post);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }


        public async Task<ActionResult<IEnumerable<Post>>> GetAllPostsAsync()
        {
            List<Post> posts = new List<Post>();
            var result = await _context.Posts.FromSqlRaw(@"exec sp_GetAllPosts").ToListAsync();

            foreach (var row in result)
            {
                posts.Add(new Post
                {
                    PostId = row.PostId,
                    Title = row.Title,
                    Content = row.Content
                });
            }
            return posts;
        }

    }
}

