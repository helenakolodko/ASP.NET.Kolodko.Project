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
            if (userEntity == null)
                return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
                RegistryDate = userEntity.RegistrationDate,                
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null)
                return null;
            return new UserEntity()
            {
                Id = dalUser.Id,
                Username = dalUser.Username,
                Email = dalUser.Email,
                Password = dalUser.Password,
                RegistrationDate = dalUser.RegistryDate,
            };
        }
        #endregion User Mappers

        #region UserInfo Mappers
        public static DalUserInfo ToDalUserInfo(this UserInfoEntity userInfoEntity)
        {
            if (userInfoEntity == null)
                return null;
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
            if (dalUserInfo == null)
                return null;
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
            if (roleEntity == null)
                return null;
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null)
                return null;
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
            if (sectionEntity == null)
                return null;
            return new DalSection()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
                Info = sectionEntity.Info,
            };
        }

        public static SectionEntity ToBllSection(this DalSection dalSection)
        {
            if (dalSection == null)
                return null;
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
            if (topicEntity == null)
                return null;
            return new DalTopic()
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                Text = topicEntity.Text,
                UserId = topicEntity.UserId,
                SectionId = topicEntity.SectionId,
                DateAdded = topicEntity.DateAdded,
            };
        }

        public static TopicEntity ToBllTopic(this DalTopic dalTopic)
        {
            if (dalTopic == null)
                return null;
            return new TopicEntity()
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                Text = dalTopic.Text,
                UserId = dalTopic.UserId,
                SectionId = dalTopic.SectionId,
                DateAdded = dalTopic.DateAdded,
            };
        }
        #endregion Topic Mappers

        #region Comment Mappers
        public static DalComment ToDalComment(this CommentEntity commentEntity)
        {
            if (commentEntity == null)
                return null;
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
            if (dalCommnet == null)
                return null;
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

        #region LogMessage Mappers
        public static DalLogMessage ToDalLogMessage(this LogMessageEntity logMessageEntity)
        {
            if (logMessageEntity == null)
                return null;
            return new DalLogMessage()
            {
                Id = logMessageEntity.Id,
                TimeOccured = logMessageEntity.TimeOccured,
                Level = logMessageEntity.Level,
                Message = logMessageEntity.Message,
            };
        }

        public static LogMessageEntity ToBllLogMessage(this DalLogMessage dalLogMessage)
        {
            if (dalLogMessage == null)
                return null;
            return new LogMessageEntity()
            {
                Id = dalLogMessage.Id,
                TimeOccured = dalLogMessage.TimeOccured,
                Level = dalLogMessage.Level,
                Message = dalLogMessage.Message,
            };
        }

        #endregion LogMessage Mappers
    }
}
