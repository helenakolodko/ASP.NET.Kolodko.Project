using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;

namespace BLL.Interface
{
    public interface IServiceWithRaiting<TEntity>: IService<TEntity>
    {
        int GetRaiting(TEntity topic);
        void AddVote(TEntity topicId, UserEntity userId, bool up);
        void RemoveVote(TEntity topicId, UserEntity userId);
    }
}
