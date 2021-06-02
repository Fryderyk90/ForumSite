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
        public List<PostInput> NewPosts { get; set; }

        public class PostInput
        {
            public int PostId { get; set; }
            public string UserName { get; set; }
            public string UserId { get; set; }
            public DateTime DatePosted { get; set; }
            public string PostText { get; set; }
            public string ProfilePicture { get; set; }
            public int ThreadId { get; set; }
            public List<Comment> Comments { get; set; }
        }

        public UserManager<User> PostedBy { get; }
        public Comment[] Comments { get; set; }
        [BindProperty]
        public NewPost InputPost { get; set; }
        [BindProperty]
        public newComment CommentInput { get; set; }
        public class newComment
        {
            public string CommentText { get; set; }
            public int ThreadId { get; set; }
            public int  PostId { get; set; }
        }

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
            var newnewPosts = new List<PostInput>();
            var comments = await _commentData.GetCommentsByThreadId(id);
            
           


                foreach (var post in getPosts)
                {
                   
                    
                    var postPost = new PostInput
                    {
                        UserId = post.User.Id,
                        UserName = post.User.UserName,
                        DatePosted = post.DatePosted,
                        PostId = post.Id,
                        PostText = post.PostText,
                        ProfilePicture = $"data:{"image/jpeg"};base64,{Convert.ToBase64String(post.User.ProfilePicture)}",
                        Comments = comments.Where(c => c.PostId == post.Id).ToList(),
                        ThreadId = id




                    };

                    newnewPosts.Add(postPost);

                }
            
            Comments = comments.ToArray();
            NewPosts = newnewPosts;

        }
        
        public async Task<IActionResult> OnPostReply(int threadId, int postId)
        {

            var newComment = new Comment
            {
                CommentText = CommentInput.CommentText,
                ThreadId = threadId,
                PostId = postId,
                DateReplied = DateTime.Now,
                UserId = PostedBy.GetUserId(User)
                
            };
            await _commentData.AddComment(newComment);
            
            var getPosts = await _postRepository.GetPostsInThreadById(threadId);
            var newnewPosts = new List<PostInput>();
            var comments = await _commentData.GetCommentsByThreadId(threadId);




            foreach (var post in getPosts)
            {


                var postPost = new PostInput
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

            Comments = comments.ToArray();
            NewPosts = newnewPosts;


            var commentText = CommentInput.CommentText;
            return Page();
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
            var newnewPosts = new List<PostInput>();
            foreach (var post in getPosts)
            {
                var postPost = new PostInput
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