﻿using System;
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

        public async Task<bool> LikeOnPostIsUnique(string userId, int postId, int threadId)
        {
            var isUniqe =  await _context.Likes.FirstOrDefaultAsync
               (
               l =>
               l.UserId == userId &&
               l.PostId == postId &&
               l.ThreadId == threadId
               );
            if (isUniqe == null)
            {
                return true;
            }
            else
                return false;
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

        public async Task<List<Like>> GeLikesInThread(int threadId)
        {
            var likesInThread = await _context.Likes.Where(like => like.ThreadId == threadId).ToListAsync();





            return likesInThread;
        }

        public List<Like> GetLikesOnPost(List<Like> likesInThread, int postId)
        {
            var likesOnPost = likesInThread.Where(like => like.PostId == postId).ToList();
            return likesOnPost;
        }

        public List<Like> GetLikesOnComment(int commentId, List<Like> likesOnPost)
        {
            var likesOnComment = likesOnPost.Where(like => like.CommentId == commentId).ToList();

            return likesOnComment;

        }

        public async Task<Like> AddLikeToComment(Like like)
        {

           
                await _context.Likes.AddAsync(like);
                await _context.SaveChangesAsync();
                return like;

          

        }

        public async Task<bool> LikeOnCommentIsUnique(string userId, int commentId, int threadId, int postId)
        {
            var isUniqe = await _context.Likes.FirstOrDefaultAsync
                (
                l =>
                l.UserId == userId &&
                l.CommentId == commentId &&
                l.ThreadId == threadId &&
                l.PostId == postId
                );
            if (isUniqe == null)
            {
                return true;
            }
            else
                return false;

        }
    }
}
