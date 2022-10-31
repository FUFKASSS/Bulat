using Enterprise.Web3.ProjectManager.Api.Core;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest.Services
{
    /// <summary>
    /// Тесты для класса UserService
    /// </summary>
    public class UserServiceTest
    {
        /// <summary>
        /// Тест метода Get. 
        /// Пустой фильтр, возвращает всех существующих пользователей
        /// </summary>
        [Fact]
        public void Get_EmptyFilter_ReturnsEtnitiesList()
        {
            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.Get()).Returns(new List<User>
            {
                new User{ Id = 1, Name = "Имя1", PasswordHash = "Пароль1"},
                new User{ Id = 2, Name = "Имя2", PasswordHash = "Пароль2"},
                new User{ Id = 3, Name = "Имя3", PasswordHash = "Пароль3"},
                new User{ Id = 4, Name = "Имя4", PasswordHash = "Пароль4"},
            });

            var service = new UserService(repository.Object);

            var users = service.Get();

            Assert.Equal(1, users[0].Id);
            Assert.Equal("Имя1", users[0].Name);
            Assert.Equal("Имя2", users[1].Name);
            Assert.Equal("Пароль3", users[2].PasswordHash);
            Assert.Equal("Пароль4", users[3].PasswordHash);
        }

        /// <summary>
        /// Тест метода Add.
        /// Успешное добавление пользователя
        /// </summary>
        [Fact]
        public void Add_ExistingEntity_SuccessfulAddition()
        {
            var repository = new Mock<IUserRepository>();
            var user = new SaveUserRequest
            {
                Name = "Имя",
                Surname = "Фамилия",
                Login = "Логин",
                PasswordHash = "ХешПароля"
            };

            repository.Setup(x => x.Add(It.IsAny<SaveUserRequest>()))
                .Callback<SaveUserRequest>(x => user = x)
                .Returns(new SaveUserResponse { Id = 1});

            var service = new UserService(repository.Object);

            var response = service.Add(user);

            Assert.NotNull(response);
            Assert.Equal(1, response.Id);
        }

        /// <summary>
        /// Тест метода Update.
        /// Успешное обновление данных о пользователе
        /// </summary>
        [Fact]
        public void Update_ExistingEntity_SuccessfulUpdate()
        {
            var repository = new Mock<IUserRepository>();
            var userBeforeUpdate = new User
            {
                Id = 1,
                Name = "Имя до изменений",
                Surname = "Фамилия до изменений",
                Login = "Логин до изменений",
                PasswordHash = "ХешПароля до изменений"
            };

            repository.Setup(x => x.Update(It.IsAny<User>()))
                .Callback<User>(x => userBeforeUpdate = x);

            var service = new UserService(repository.Object);
            var user = new User
            {
                Id = 1,
                Name = "Имя после изменений",
                Surname = "Фамилия после изменений",
                Login = "Логин после изменений",
                PasswordHash = "ХешПароля после изменений"
            };

            service.Update(user);

            Assert.Equal(user.Id, userBeforeUpdate.Id);
            Assert.Equal(user.Name, userBeforeUpdate.Name);
            Assert.Equal(user.Surname, userBeforeUpdate.Surname);
            Assert.Equal(user.Login, userBeforeUpdate.Login);
            Assert.Equal(user.PasswordHash, userBeforeUpdate.PasswordHash);
        }

        /// <summary>
        /// Тест метода Delete.
        /// Успешное удаление пользователя
        /// </summary>
        [Fact]
        public void Delete_ExistingEntity_SuccessfulDeletion()
        {
            var repository = new Mock<IUserRepository>();
            var userBeforeDeleting = new User
            {
                Id = 1,
                Name = "Имя",
                Surname = "Фамилия",
                Login = "Логин",
                PasswordHash = "ХешПароля"
            };

            repository.Setup(x => x.Delete(It.IsAny<int>()))
                .Callback<int>(x => userBeforeDeleting = null);

            var service = new UserService(repository.Object);
            var user = new User
            {
                Id = 1
            };

            service.Delete(user.Id);

            Assert.Null(userBeforeDeleting);
        }
    }
}
