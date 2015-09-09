using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Mappers;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.Entities;

namespace BLL.Services
{
    public class TopicService: IServiceWithRaiting<TopicEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalTopic> topicRepository;
        private readonly IRepository<DalTopicVote> voteRepository;

        public TopicService(IUnitOfWork unitOfWork, IRepository<DalTopic> topicRepository, IRepository<DalTopicVote> voteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.topicRepository = topicRepository;
            this.voteRepository = voteRepository;
        }

        public int GetRaiting(TopicEntity topic)
        {
            throw new NotImplementedException();
        }

        public void AddVote(TopicEntity topicId, UserEntity userId, bool up)
        {
            voteRepository.Add(new DalTopicVote() { });   
        }

        public void RemoveVote(TopicEntity topicId, UserEntity userId)
        {
            throw new NotImplementedException();
        }

        public TopicEntity GetEntity(int id)
        {
            return topicRepository.GetById(id).ToBllTopic();
        }

        public IEnumerable<TopicEntity> GetAllEntities()
        {
            return topicRepository.GetAll().Select(topic => topic.ToBllTopic());
        }

        public int Create(TopicEntity entity)
        {
            int id = topicRepository.Add(entity.ToDalTopic());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(TopicEntity entity)
        {
            topicRepository.Delete(entity.ToDalTopic());
            unitOfWork.Commit();
        }

        public void Update(TopicEntity entity)
        {
            topicRepository.Update(entity.ToDalTopic());
            unitOfWork.Commit();
        }
    }
}
