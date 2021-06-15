using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class CommentData : ICommentData
    {
        private readonly ForumSiteContext _context;
        private readonly IProfanityFilter _profanityFilter;


        public CommentData(ForumSiteContext context, IProfanityFilter profanityFilter)
        {
            _context = context;
            _profanityFilter = profanityFilter;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            //      comment.CommentText = await postData.ProfanityFilter(comment.CommentText);

            comment.CommentText = await _profanityFilter.Filter(comment.CommentText);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            var comment = await GetCommentById(id);
            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> EditComment(Comment comment)
        {
            _context.Comments.Update(comment);

            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByThreadId(int threadId)
        {
            var comments = await _context.Comments
                .Where(comment => comment.ThreadId == threadId)
                .ToListAsync();

            return comments;
        }

        public async Task<Comment[]> AllComments()
        {
            var allComments = await _context.Comments.ToArrayAsync();

            return allComments;
        }

        public Task<List<Comment>> GetCommentsByPostId(int postId)
        {
           return _context.Comments.Where(c => c.PostId == postId).ToListAsync();

        }
    }
}
