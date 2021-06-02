using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class LikeData : ILikeData
    {
        private readonly ForumSiteContext _context;

        public LikeData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<Like> AddLike(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<Like> GetLikeByUserId(string userId)
        {
            var findLike = await _context.Likes.FirstOrDefaultAsync(l => l.UserId == userId);
            return findLike;
        }

        public async Task<Like> DeleteLikeByUserId(string userId)
        {
            var likeToDelete = await GetLikeByUserId(userId);
            _context.Likes.Remove(likeToDelete);

            await _context.SaveChangesAsync();

            return likeToDelete;
        }
    }
}
