using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        #region User Mappers
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
                RegistryDate = userEntity.RegistryDate,                
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Username = dalUser.Username,
                Email = dalUser.Email,
                Password = dalUser.Password,
                RegistryDate = dalUser.RegistryDate,
            };
        }
        #endregion User Mappers

        #region UserInfo Mappers
        public static DalUserInfo ToDalUserInfo(this UserInfoEntity userInfoEntity)
        {
            return new DalUserInfo()
            {
                Id = userInfoEntity.Id,
                FirstName = userInfoEntity.FirstName,
                LastName = userInfoEntity.LastName,
                BirthDate = userInfoEntity.BirthDate,
                City = userInfoEntity.City,
                Country =  userInfoEntity.Country,
                About = userInfoEntity.About,
                AvatarPath = userInfoEntity.AvatarPath,
            };
        }

        public static UserInfoEntity ToBllUserInfo(this DalUserInfo dalUserInfo)
        {
            return new UserInfoEntity()
            {
                Id = dalUserInfo.Id,
                FirstName = dalUserInfo.FirstName,
                LastName = dalUserInfo.LastName,
                BirthDate = dalUserInfo.BirthDate,
                City = dalUserInfo.City,
                Country = dalUserInfo.Country,
                About = dalUserInfo.About,
                AvatarPath = dalUserInfo.AvatarPath,
            };
        }
        #endregion UserInfo Mappers

        #region Role Mappers
        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
            };
        }
        #endregion Role Mappers

        #region Section Mappers
        public static DalSection ToDalSection(this SectionEntity sectionEntity)
        {
            return new DalSection()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
                Info = sectionEntity.Info,
            };
        }

        public static SectionEntity ToBllSection(this DalSection dalSection)
        {
            return new SectionEntity()
            {
                Id = dalSection.Id,
                Name = dalSection.Name,
                Info = dalSection.Info,
            };
        }
        #endregion Section Mappers

        #region Topic Mappers
        public static DalTopic ToDalTopic(this TopicEntity topicEntity)
        {
            return new DalTopic()
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                UserId = topicEntity.UserId,
                SectionId = topicEntity.SectionId,
                DateAdded = topicEntity.DateAdded,
            };
        }

        public static TopicEntity ToBllTopic(this DalTopic dalTopic)
        {
            return new TopicEntity()
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                UserId = dalTopic.UserId,
                SectionId = dalTopic.SectionId,
                DateAdded = dalTopic.DateAdded,
            };
        }
        #endregion Topic Mappers

        #region Comment Mappers
        public static DalComment ToDalComment(this CommentEntity commentEntity)
        {
            return new DalComment()
            {
                Id = commentEntity.Id,
                TopicId = commentEntity.TopicId,
                UserId = commentEntity.UserId,
                Text = commentEntity.Text,
                DateAdded = commentEntity.DateAdded,
            };
        }

        public static CommentEntity ToBllComment(this DalComment dalCommnet)
        {
            return new CommentEntity()
            {
                Id = dalCommnet.Id,
                TopicId = dalCommnet.TopicId,
                UserId = dalCommnet.UserId,
                Text = dalCommnet.Text,
                DateAdded = dalCommnet.DateAdded,
            };
        }
        #endregion Comment Mappers

        #region Votes Mappers
        public static DalVote ToDalVote(this VoteEntity voteEntity)
        {
            return new DalVote()
            {
                Id = voteEntity.Id,
                UserId = voteEntity.UserId,
                Up = voteEntity.Up,
            };
        }

        public static VoteEntity ToBllVote(this DalVote dalVote)
        {
            return new VoteEntity()
            {
                Id = dalVote.Id,
                UserId = dalVote.UserId,
                Up = dalVote.Up,
            };
        }
        #endregion Votes Mappers
    }
}
