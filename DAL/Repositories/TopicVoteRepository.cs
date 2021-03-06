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
    public class TopicVoteRepository : IVoteRepository<DalTopicVote>
    {
        private readonly DbContext context;

        public TopicVoteRepository(DbContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<DalTopicVote> GetAll()
        {
            return context.Set<TopicVote>()
                .Select(vote => new DalTopicVote()
                {
                    TopicId = vote.TopicId,
                    UserId = vote.UserId,
                    Up = vote.Up,
                });
        }

        public DalTopicVote GetById(int postId, int userId)
        {
            var ormVote = context.Set<TopicVote>().FirstOrDefault(vote => vote.TopicId == postId && vote.UserId == userId);
            return ormVote.ToDalTopicVote();
        }

        public IEnumerable<DalTopicVote> GetByPredicate(System.Linq.Expressions.Expression<Func<DalTopicVote, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<TopicVote, DalTopicVote>.Tranform(predicate);
            return context.Set<TopicVote>().Where(expression)
                .Select(vote => new DalTopicVote() 
                { 
                    TopicId = vote.TopicId,
                    UserId = vote.UserId,
                    Up = vote.Up,
                });
        }

        public void Add(DalTopicVote entity)
        {
            context.Set<TopicVote>().Add(entity.ToTopicVote());
        }

        public void Delete(DalTopicVote entity)
        {
            context.Set<TopicVote>().Remove(entity.ToTopicVote());
        }

        public void Update(DalTopicVote entity)
        {
            context.Entry(entity.ToTopicVote()).State = EntityState.Modified;
        }


        public IEnumerable<DalTopicVote> GetAllOfTopic(int id)
        {
            return context.Set<TopicVote>().Where(vote => vote.TopicId == id)
                                           .Select(vote => vote.ToDalTopicVote());
        }

        public IEnumerable<DalTopicVote> GetAllOfUser(int id)
        {
            return context.Set<TopicVote>().Where(vote => vote.UserId == id)
                                           .Select(vote => vote.ToDalTopicVote());
        }
    }
}

