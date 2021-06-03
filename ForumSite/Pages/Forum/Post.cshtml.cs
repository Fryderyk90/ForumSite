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
        private readonly ILikeData _likeData;

        //    public List<Post> Posts { get; set; }
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
            public int LikesOnPosts { get; set; }
            public List<NewComment> Comments { get; set; }
        }

        public UserManager<User> PostedBy { get; }
        public Comment[] Comments { get; set; }
        [BindProperty]
        public NewPost InputPost { get; set; }
        [BindProperty]
        public NewComment CommentsWithLikes { get; set; }
        public class NewComment
        {
            public int Id { get; set; }
            public string CommentText { get; set; }
            public int ThreadId { get; set; }
            public int PostId { get; set; }
            public DateTime DateReplied { get; set; }
            public int LikesOnComment { get; set; }
            public User User { get; set; }
            public string UserId { get; set; }
        }

        public class NewPost
        {
            public string InputText { get; set; }

        }

        public PostModel(IPostData postRepository, UserManager<User> postedBy, ICommentData commentData, ILikeData likeData)
        {
            _postRepository = postRepository;

            PostedBy = postedBy;
            _commentData = commentData;
            _likeData = likeData;
        }

        public async Task OnGet(int id)
        {
            await UpdatePage(id);
        }

        private async Task UpdatePage(int id)
        {
            var getPosts = await _postRepository.GetPostsInThreadById(id);
            var newPosts = new List<PostInput>();
            var comments = await _commentData.GetCommentsByThreadId(id);
            var likesInThread = await _likeData.GeLikesInThread(id);
            var likesOnPost = likesInThread.ToLookup(l => l.PostId, l => l.PostId);
            var likesOnComment = likesInThread.ToLookup(l => l.CommentId, l => l.CommentId);
            var commentWithLikesList = new List<NewComment>();

            foreach (var post in getPosts)
            {
                var commentss = comments.Where(c => c.PostId == post.Id).ToList();
                foreach (var comment in commentss)
                {
                    var commentWithLike = new NewComment()
                    {
                        Id = comment.Id,
                        PostId = comment.PostId,
                        CommentText = comment.CommentText,
                        DateReplied = comment.DateReplied,
                        LikesOnComment = likesOnComment[comment.Id].Count(),
                        User = comment.User,
                        UserId = comment.UserId
                    };


                    commentWithLikesList.Add(commentWithLike);
                }

                var postPost = new PostInput
                {
                    UserId = post.User.Id,
                    UserName = post.User.UserName,
                    DatePosted = post.DatePosted,
                    PostId = post.Id,
                    PostText = post.PostText,
                    ProfilePicture = $"data:{"image/jpeg"};base64,{Convert.ToBase64String(post.User.ProfilePicture)}",
                    Comments = commentWithLikesList, //comments.Where(c => c.PostId == post.Id).ToList(),
                    ThreadId = id,
                    LikesOnPosts = likesOnPost[post.Id].Count()
                    
                };
                newPosts.Add(postPost);
              //  }
            }

            NewPosts = newPosts;
        }

        public async Task<IActionResult> OnPostReply(int threadId, int postId)
        {

            var newComment = new Comment
            {
                CommentText = InputPost.InputText,
                ThreadId = threadId,
                PostId = postId,
                DateReplied = DateTime.Now,
                UserId = PostedBy.GetUserId(User)

            };
            await _commentData.AddComment(newComment);

            await UpdatePage(threadId);

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
            }

            await UpdatePage(id);


            return Page();
        }

        public async Task<IActionResult> OnPostAddLike(string userId, int threadId, int postId, int commentId)
        {
            var like = new Like
            {
                UserId = userId,
                ThreadId = threadId,
                PostId = postId,
                CommentId = commentId
            };

            await _likeData.AddLike(like);
            await UpdatePage(threadId);



            return Page();
        }


    }
}