using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class CommentData : ICommentData
    {
        private readonly ForumSiteContext _context;

        public CommentData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
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

        public async Task<Comment[]> AllComments()
        {
            var allComments = await _context.Comments.ToArrayAsync();

            return allComments;
        }
    }
}
