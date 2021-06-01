using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class PostData : IPostData
    {
        private readonly ForumSiteContext _context;


        public PostData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPostsInThreadById(int id)
        {
            
            var posts = await _context.Posts.Where(s => s.ThreadId == id).ToListAsync();

            //Where the magic happens DO NOT TOUCH
            var users = await _context.RegUsers.ToArrayAsync();
            var profilePictures = await _context.ProfilePictures.ToArrayAsync();

            return posts;
        }

        public async Task<List<Post>> GetPostsByUserId(string userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

       

        public async Task<Post> GetPostById(int postId)
        {
            var postedByUser = await _context.RegUsers.ToArrayAsync();
            return await _context.Posts.FindAsync(postId);
        }

        public async Task<Post> UpdatePost(Post updatedPost)
        {
            var post = _context.Posts.Attach(updatedPost);
            post.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedPost;
        }

        public async Task<Post> AddPost(Post newPost)
        {
            string postText = newPost.PostText; 
            newPost.PostText = await ProfanityFilter(postText);

            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }



        public async Task<string> ProfanityFilter(string input)
        {
            HttpClient client = new HttpClient();
            var apiCall = "https://www.purgomalum.com/service/plain?text=" + input;
            var apiResponse = await client.GetStringAsync(apiCall);
            client.Dispose();
            return apiResponse;
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