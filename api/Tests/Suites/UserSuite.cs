using System;
using api.Models;
using api.ModelsAPI;

namespace api.Tests.Suites
{
	public class UserSuite
	{

        UserAPI userAPI = new UserAPI();
        Random random = new Random();


        [Test]
        public void Test01CRUDUser()
        {
            int id = random.Next(50);
            User user = new User(id, "username" + id, "FirstName" + id, "LastName" + id, id + "mail@mail", "pass" + id, "12345", 1);

            //create
            userAPI.VerifyUserCreationAPI(user);
            userAPI.VerifyGetUser(user);

            //login
            userAPI.VerifyThatUserIsLoggedIn(user.username, user.password);

            //update
            user.firstName = "FirstNameUpd" + id;
            userAPI.VerifyUserUpdatingAPI(user, user.username);
            userAPI.VerifyGetUser(user);

            //logout
            userAPI.VerifyThatUserIsLoggedOut();

            //delete
            userAPI.VerifyUserDeleteAPI(user.username);
            userAPI.VerifyThatUserIsNotFound(user);

        }

        [Test]
        public void Test02CreateUsersWithArray()
        {
            int id1 = random.Next(50);
            int id2 = random.Next(50);
            User user1 = new User(id1, "username" + id1, "FirstName" + id1, "LastName" + id1, id1 + "mail@mail", "pass" + id1, "12345", 1);
            User user2= new User(id2, "username" + id2, "FirstName" + id2, "LastName" + id2, id2 + "mail@mail", "pass" + id2, "12345", 1);

            User[] usersArray = new User[2];
            usersArray[0] = user1;
            usersArray[1] = user2;

            //create
            userAPI.VerifyUserCreateWithArrayAPI(usersArray);
            
            //verify that users are created
            userAPI.VerifyGetUser(user1);
            userAPI.VerifyGetUser(user2);
        }

        [Test]
        public void Test03CreateUsersWithList()
        {
            int id1 = random.Next(50);
            int id2 = random.Next(50);
            User user1 = new User(id1, "username" + id1, "FirstName" + id1, "LastName" + id1, id1 + "mail@mail", "pass" + id1, "12345", 1);
            User user2 = new User(id2, "username" + id2, "FirstName" + id2, "LastName" + id2, id2 + "mail@mail", "pass" + id2, "12345", 1);

            List<User> usersList = new List<User>();
            usersList.Add(user1);
            usersList.Add(user2);

            //create
            userAPI.VerifyUserCreateWithListAPI(usersList);

            //verify that users are created
            userAPI.VerifyGetUser(user1);
            userAPI.VerifyGetUser(user2);
        }

        [Test]
        public void Test04LoginWithInvalidUsernameAndPassword()
        {
            int id = random.Next(50);
            User user = new User(id, "username" + id, "FirstName" + id, "LastName" + id, id + "mail@mail", "pass" + id, "12345", 1);

            //create
            userAPI.VerifyUserCreationAPI(user);

            //login with invalid username and password
            userAPI.VerifyThatUserIsNotLoggedIn(user.username,"wrongPassword");
        }
    }
}

