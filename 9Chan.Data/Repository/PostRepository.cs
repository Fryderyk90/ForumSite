using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumSiteContext _context;

        public PostRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPostsInThreadById(int id)
        {

            var posts = await _context.Posts.Where(s => s.ThreadId == id).ToListAsync();

            //Where the magic happens DO NOT TOUCH
            var users = await _context.RegUsers.ToArrayAsync();

            return posts;
        }

        public Task<List<Post>> GetPostsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostById(int postId)
        {
            var postedByUser = _context.RegUsers.ToArrayAsync();
            return await _context.Posts.FindAsync(postId);
        }

        public async Task<Post> UpdatePost(Post updatedPost)
        {
            var post = _context.Posts.Attach(updatedPost);
            post.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedPost;
        }

        public async Task<Post> AddPostToThreadById(Post newPost)
        {

            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }

        public async Task<Post> DeletePostById(int id)
        {
            var reportedPost = await GetPostById(id);
            if (reportedPost != null)
            {
                _context.Posts.Remove(reportedPost);
                await _context.SaveChangesAsync();
            }

            return reportedPost;
        }

        public async Task DeletePostsInThread(List<Post> postsToDelete)
        {
            foreach (var post in postsToDelete)
            {
                _context.Posts.Remove(post);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> ReportedPosts()
        {

            var reportedPosts = await _context.Posts.Where(p => p.IsReported == true).OrderBy(p => p.UserId).ToListAsync();
            var users = await _context.RegUsers.ToArrayAsync();

            return reportedPosts;
        }

        public async Task<Post> UnReportPost(int id)
        {
            var reportedPost = await GetPostById(id);

            reportedPost.IsReported = false;
            await _context.SaveChangesAsync();

            return reportedPost;
        }
    }
}
