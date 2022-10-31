using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactBackend.Data;
using ReactBackend.Interfaces;
using ReactBackend.Repository;

namespace ReactBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsRepository _postsRepository;

    public PostsController(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        //Här används en stored procedure.
        return await _postsRepository.GetAllPostsAsync();
        //return await _postsRepository.GetAll();
    }

    [HttpPost]
    public async Task<ActionResult<Post>> Create(Post post)
    {
        bool ok = _postsRepository.Add(post);

        if (ok == false)
        {
            return BadRequest();
        }

        return post;
    }

    [HttpDelete("{id}")]
    //[ProducesResponseType(400)]
    //[ProducesResponseType(204)]
    //[ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<Post>>> Delete(int id)
    {

        var item = _postsRepository.PostExists(id);

        if (item == null)
        {
            return BadRequest();
        }

        _postsRepository.Delete(id);

        return await _postsRepository.GetAll();
    }

}