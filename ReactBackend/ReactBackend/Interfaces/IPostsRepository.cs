using System;
using Microsoft.AspNetCore.Mvc;
using ReactBackend.Data;

namespace ReactBackend.Interfaces
{
    public interface IPostsRepository
    {
        Task<ActionResult<IEnumerable<Post>>> GetAll();

        bool Add(Post post);

        bool Delete(int id);

        bool PostExists(int id);

        Post GetPost(int id);

        Task<ActionResult<IEnumerable<Post>>> GetAllPostsAsync();
    }
}

