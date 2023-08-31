using System;
namespace api.Models
{
	public class User
	{
        public int id { get; set; }
        public string? username { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phone { get; set; }
        public int userStatus { get; set; }

        public User(int Id, string Username, string FirstName, string LastName, string Email, string Password, string Phone, int UserStatus)
        {
            id = Id;
            username = Username;
            firstName = FirstName;
            lastName = LastName;
            email = Email;
            password = Password;
            phone = Phone;
            userStatus = UserStatus;
        }
    }

    
}

