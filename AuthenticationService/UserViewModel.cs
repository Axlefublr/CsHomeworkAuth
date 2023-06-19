using System;
using System.Net.Mail;

namespace AuthenticationService
{
	public class UserViewModel
	{
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public bool FromRussia { get; set; }

		public UserViewModel(User user)
		{
			FullName = user.FirstName + ' ' + user.LastName;
			FromRussia = CheckIfFromRussia(user.Email);
		}

		private static bool CheckIfFromRussia(string email)
		{
			MailAddress mailAddress = new(email);
			if (mailAddress.Host.Contains(".ru"))
			{
				return true;
			}
			return false;
		}
	}
}