﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tabloid.Models;
using Tabloid.Repositories;

namespace Tabloid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public PostController(IPostRepository postRepo,
            IUserProfileRepository userProfileRepository)
        {
            _postRepository = postRepo;
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult GetAllPublishedPosts()
        {
            return Ok(_postRepository.GetAllPublishedPosts());
        }

        // Fetch all posts from current logged in user
        [HttpGet("GetAllUserPosts")]
        public IActionResult GetAllUserPosts()
        {
            var user = GetCurrentUserProfile();
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var posts = _postRepository.GetAllUserPosts(user.FirebaseUserId);
                return Ok(posts);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok(_postRepository.GetPostById(id));
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            var currentUser = GetCurrentUserProfile();

            post.CreateDateTime = DateTime.Now;
            //post.PublishDateTime = DateTime.Now;
            post.UserProfileId = currentUser.Id;
            post.IsApproved = false;
            _postRepository.Add(post);
            return CreatedAtAction(nameof(GetAllUserPosts), new { id = post.Id }, post);
        }

        // Update post
        [HttpPut("{id}")]
        public IActionResult Put(int id, Post post)
        {
            var currentUser = GetCurrentUserProfile();
            if (id != post.Id)
            {
                return BadRequest();
            } else if(post.UserProfileId == currentUser.Id)
            {
                _postRepository.Update(post);
                return NoContent();
            } else
            {
                return Unauthorized();
         
            }

        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (firebaseUserId != null)
            {
                return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            }
            else
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postRepository.DeletePost(id);
            return NoContent();
        }
    };
}
