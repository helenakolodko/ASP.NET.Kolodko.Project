﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using HelperModule;
using ORM.Entities;

namespace DAL.Repositories
{
    public class CommentVoteRepository : IVoteRepository<DalCommentVote>
    {
        private readonly DbContext context;

        public CommentVoteRepository(DbContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<DalCommentVote> GetAll()
        {
            return context.Set<CommentVote>()
                .Select(vote => new DalCommentVote()
                {
                    CommentId = vote.CommentId,
                    UserId = vote.UserId,
                    Up = vote.Up,
                });
        }

        public DalCommentVote GetById(int postId, int userId)
        {
            var ormVote = context.Set<CommentVote>().FirstOrDefault(vote => vote.UserId == userId && vote.CommentId == postId);
            return ormVote.ToDalCommentVote();
        }

        public IEnumerable<DalCommentVote> GetByPredicate(System.Linq.Expressions.Expression<Func<DalCommentVote, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<CommentVote, DalCommentVote>.Tranform(predicate);
            return context.Set<CommentVote>().Where(expression)
                .Select(vote => new DalCommentVote() 
                {
                    CommentId = vote.CommentId,
                    UserId = vote.UserId,
                    Up = vote.Up,
                });
        }

        public void Add(DalCommentVote entity)
        {
            context.Set<CommentVote>().Add(entity.ToCommentVote());
        }

        public void Delete(DalCommentVote entity)
        {
            context.Set<CommentVote>().Remove(entity.ToCommentVote());
        }

        public void Update(DalCommentVote entity)
        {
            context.Entry(entity.ToCommentVote()).State = EntityState.Modified;
        }


        public IEnumerable<DalCommentVote> GetAllOfTopic(int id)
        {
            return context.Set<CommentVote>().Where(vote => vote.CommentId == id)
                                           .Select(vote => vote.ToDalCommentVote());
        }

        public IEnumerable<DalCommentVote> GetAllOfUser(int id)
        {
            return context.Set<CommentVote>().Where(vote => vote.UserId == id)
                                           .Select(vote => vote.ToDalCommentVote());
        }
    }
}

