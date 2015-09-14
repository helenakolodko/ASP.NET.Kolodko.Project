using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Mappers;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.Entities;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CommentService: IServiceWithRaiting<CommentEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalComment> commentRepository;
        private readonly IVoteRepository<DalCommentVote> voteRepository;

        public CommentService(IUnitOfWork unitOfWork, IRepository<DalComment> repository, IVoteRepository<DalCommentVote> voteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.commentRepository = repository;
            this.voteRepository = voteRepository;
        }

        public IEnumerable<CommentEntity> GetAllEntities()
        {
            return commentRepository.GetAll().Select(comment => comment.ToBllComment()); 
        }

        public CommentEntity GetEntity(int id)
        {
            return commentRepository.GetById(id).ToBllComment();
        }

        public IEnumerable<CommentEntity> GetByPredicate(Expression<Func<CommentEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Create(CommentEntity entity)
        {
            int id = commentRepository.Add(entity.ToDalComment());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(CommentEntity entity)
        {
            commentRepository.Delete(entity.ToDalComment());
            unitOfWork.Commit();
        }

        public void Update(CommentEntity entity)
        {
            commentRepository.Update(entity.ToDalComment());
            unitOfWork.Commit();
        }

        public int GetRaiting(CommentEntity comment)
        {
            var votes = voteRepository.GetAllOfTopic(comment.Id);
            return votes.Count() - votes.Where(vote => vote.Up).Count();
        }

        public void AddVote(CommentEntity comment, UserEntity user, bool up)
        {
            voteRepository.Add(new DalCommentVote() { CommentId = comment.Id, UserId = comment.Id, Up = up });   
        }

        public void RemoveVote(CommentEntity topicId, UserEntity userId)
        {
            throw new NotImplementedException();
        }

    }
}
