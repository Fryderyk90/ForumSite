using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface ICommentData
    {
        Task<Comment> AddComment(Comment comment);
        Task<Comment> DeleteComment(int id);
        Task<Comment> EditComment(Comment comment);
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentsByThreadId(int threadId);
        Task<List<Comment>> GetCommentsByPostId(int postId);
        Task<Comment[]> AllComments();
    }
}
