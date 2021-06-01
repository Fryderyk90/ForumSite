using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class PostModel : PageModel
    {
        private readonly IPostData _postRepository;
        private readonly ICommentData _commentData;

        public List<Post> Posts { get; set; }
        public List<PostWithProfilePictures> NewPosts { get; set; }

        public class PostWithProfilePictures
        {
            public int PostId { get; set; }
            public string UserName { get; set; }
            public string UserId { get; set; }
            public DateTime DatePosted { get; set; }
            public string PostText { get; set; }
            public string ProfilePicture { get; set; }
            public List<Comment> Comments { get; set; }
        }

        public UserManager<User> PostedBy { get; }
        public Comment[] Comments { get; set; }
        [BindProperty]
        public NewPost InputPost { get; set; }



        public class NewPost
        {
            public string InputText { get; set; }

        }

        public PostModel(IPostData postRepository, UserManager<User> postedBy, ICommentData commentData)
        {
            _postRepository = postRepository;

            PostedBy = postedBy;
            _commentData = commentData;
        }

        public async Task OnGet(int id)
        {
            var getPosts = await _postRepository.GetPostsInThreadById(id);
            var newnewPosts = new List<PostWithProfilePictures>();
            var comments = await _commentData.AllComments();
            
           


                foreach (var post in getPosts)
                {
                   
                    
                    var postPost = new PostWithProfilePictures
                    {
                        UserId = post.User.Id,
                        UserName = post.User.UserName,
                        DatePosted = post.DatePosted,
                        PostId = post.Id,
                        PostText = post.PostText,
                        ProfilePicture = $"data:{"image/jpeg"};base64,{Convert.ToBase64String(post.User.ProfilePicture)}",
                        Comments = comments.Where(c => c.PostId == post.Id).ToList()




                    };

                    newnewPosts.Add(postPost);

                }
            
            Comments = comments;
            NewPosts = newnewPosts;

        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var inputUser = await PostedBy.GetUserAsync(User);
                var newPost = new Post
                {
                    ThreadId = id,
                    UserId = inputUser.Id,
                    DatePosted = DateTime.Now,
                    PostText = InputPost.InputText,
                    IsReported = false,
                };
                await _postRepository.AddPost(newPost);
                Posts = await _postRepository.GetPostsInThreadById(id);
            }


            var getPosts = await _postRepository.GetPostsInThreadById(id);
            var newnewPosts = new List<PostWithProfilePictures>();
            foreach (var post in getPosts)
            {
                var postPost = new PostWithProfilePictures
                {
                    UserId = post.User.Id,
                    UserName = post.User.UserName,
                    DatePosted = post.DatePosted,
                    PostId = post.Id,
                    PostText = post.PostText,
                    ProfilePicture = $"data:{"image/jpeg"};base64,{Convert.ToBase64String(post.User.ProfilePicture)}"
                };
                newnewPosts.Add(postPost);

            }

            NewPosts = newnewPosts;
            return Page();
        }
    }
}