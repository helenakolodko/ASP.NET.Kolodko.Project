﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalEntityMappers
    {
        #region User Mappers
        public static User ToUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                UserName = dalUser.Username,
                Email = dalUser.Email,
                Password = dalUser.Password,
                DateAdded = dalUser.RegistryDate,                
            };
        }

        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RegistryDate = user.DateAdded,
            };
        }
        #endregion User Mappers

        #region UserInfo Mappers
        public static UserInfo ToUserInfo(this DalUserInfo dalUserInfo)
        {
            return new UserInfo()
            {
                UserId = dalUserInfo.Id,
                FirstName = dalUserInfo.FirstName,
                LastName = dalUserInfo.LastName,
                BirthDate = dalUserInfo.BirthDate,
                City = dalUserInfo.City,
                Country = dalUserInfo.Country,
                About = dalUserInfo.About,
                AvatarPath = dalUserInfo.AvatarPath,
            };
        }

        public static DalUserInfo ToDalUserInfo(this UserInfo userInfo)
        {
            return new DalUserInfo()
            {
                Id = userInfo.UserId,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                BirthDate = userInfo.BirthDate,
                City = userInfo.City,
                Country = userInfo.Country,
                About = userInfo.About,
                AvatarPath = userInfo.AvatarPath,
            };
        }
        #endregion UserInfo Mappers

        #region Role Mappers
        public static Role ToRole(this DalRole dalRole)
        {
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }
        #endregion Role Mappers

        #region Section Mappers
        public static Section ToSection(this DalSection dalSection)
        {
            return new Section()
            {
                Id = dalSection.Id,
                Name = dalSection.Name,
                Info = dalSection.Info,
            };
        }

        public static DalSection ToDalSection(this Section section)
        {
            return new DalSection()
            {
                Id = section.Id,
                Name = section.Name,
                Info = section.Info,
            };
        }
        #endregion Section Mappers

        #region Topic Mappers
        public static Topic ToTopic(this DalTopic dalTopic)
        {
            return new Topic()
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                Text = dalTopic.Text,
                AuthorId = dalTopic.UserId,
                SectionId = dalTopic.SectionId,
                DateAdded = dalTopic.DateAdded,
            };
        }

        public static DalTopic ToDalTopic(this Topic topic)
        {
            return new DalTopic()
            {
                Id = topic.Id,
                Name = topic.Name,
                Text = topic.Text,
                UserId = topic.AuthorId,
                SectionId = topic.SectionId,
                DateAdded = topic.DateAdded,
            };
        }
        #endregion Topic Mappers

        #region Comment Mappers
        public static Comment ToComment(this DalComment dalComment)
        {
            return new Comment()
            {
                Id = dalComment.Id,
                TopicId = dalComment.TopicId,
                AuthorId = dalComment.UserId,
                Text = dalComment.Text,
                DateAdded = dalComment.DateAdded,
            };
        }

        public static DalComment ToDalComment(this Comment comment)
        {
            return new DalComment()
            {
                Id = comment.Id,
                TopicId = comment.TopicId,
                UserId = comment.AuthorId,
                Text = comment.Text,
                DateAdded = comment.DateAdded,
            };
        }
        #endregion Comment Mappers

        #region TopicVote Mappers
        public static TopicVote ToTopicVote(this DalTopicVote dalVote)
        {
            return new TopicVote()
            {
                UserId = dalVote.UserId,
                TopicId = dalVote.TopicId,
                Up = dalVote.Up,
            };
        }

        public static DalTopicVote ToDalTopicVote(this TopicVote vote)
        {
            return new DalTopicVote()
            {
                UserId = vote.UserId,
                TopicId = vote.TopicId,
                Up = vote.Up,
            };
        }

        #endregion CommentVote Mappers

        #region CommentVote Mappers
        public static CommentVote ToCommentVote(this DalCommentVote dalCommentVote)
        {
            return new CommentVote()
            {
                UserId = dalCommentVote.UserId,
                CommentId = dalCommentVote.CommentId,
                Up = dalCommentVote.Up,
            };
        }

        public static DalCommentVote ToDalCommentVote(this CommentVote commentVote)
        {
            return new DalCommentVote()
            {
                UserId = commentVote.UserId,
                CommentId = commentVote.CommentId,
                Up = commentVote.Up,
            };
        }

        #endregion CommentVote Mappers
    }
}
