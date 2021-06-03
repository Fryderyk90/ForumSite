using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface ILikeData
    {
        Task<Like> AddLike(Like like);
        Task<Like> GetLikeByUserId(string userId);
        Task<Like> DeleteLikeByUserId(string userId);
        Task<List<Like>> GeLikesInThread(int threadId);
        List<Like> GetLikesOnPost(List<Like> likesInThread, int postId);
        List<Like> GetLikesOnComment(int commentId, List<Like> likesOnPost);
    }
}
