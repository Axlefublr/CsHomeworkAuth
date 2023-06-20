using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationService
{
	public class UserRepository : IUserRepository
	{
		public IEnumerable<User> GetAll()
		{
			List<User> users = new()
			{
				new User()
				{
					Id = Guid.NewGuid(),
					FirstName = "Alexander",
					LastName = "The II",
					Email = "best_emperor@gmail.com",
					Password = "pleasedontbetrayme",
					Login = "xXxEmperorxXx"
				},
				new User()
				{
					Id = Guid.NewGuid(),
					FirstName = "Mike",
					LastName = "Brown",
					Email = "mikebrown@gmail.com",
					Password = "yes,mikebrownalso",
					Login = "guesswhatitis"
				}
			};
			return users;
		}

		public User GetByLogin(string login)
		{
			return GetAll().FirstOrDefault(user => user.Login == login);
		}
	}
}