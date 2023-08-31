using System;
using api.Models;
using RestSharp;

namespace api.ModelsAPI
{
	public class UserAPI : BaseAPI
	{
		public UserAPI()
		{
            contentType = "application/json";
        }

        public RestResponse CreateUserWithArray(User[] usersArray)
        {

            method = RestSharp.Method.Post;
            resource = "user/createWithArray";

            return client.Execute(CreateRequest(usersArray)); ;
        }

        public RestResponse CreateUserWithList(List<User> usersList)
        {

            method = RestSharp.Method.Post;
            resource = "user/createWithList";

            return client.Execute(CreateRequest(usersList)); ;
        }

        public RestResponse CreateUser(User user)
        {
            
            method = RestSharp.Method.Post;
            resource = "user";

            return client.Execute(CreateRequest(user)); ;
        }

        public RestResponse<User> GetUser(string username)
        {
            method = RestSharp.Method.Get;
            resource = $"user/{username}";

            return client.Execute<User>(CreateRequest()); ;
        }

        public RestResponse UpdateUser(User updatedUser, string username)
        {
            method = RestSharp.Method.Put;
            resource = $"user/{username}";

            return client.Execute(CreateRequest(updatedUser)); ;
        }

        public RestResponse DeleteUser(string username)
        {
            method = RestSharp.Method.Delete;
            resource = $"user/{username}";

            return client.Execute(CreateRequest());
        }

        public RestResponse LoginUser(string username, string password)
        {
            method = RestSharp.Method.Get;
            resource = "user/login";

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("username", username);
            queryParams.Add("password", password);

            return client.Execute(CreateRequest(queryParams));
        }

        public RestResponse LogoutUser()
        {
            method = RestSharp.Method.Get;
            resource = "user/logout";

            return client.Execute(CreateRequest());
        }

        public void VerifyUserUpdatingAPI(User updatedUser, string username)
        {
            var response = UpdateUser(updatedUser, username);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyUserCreationAPI(User user)
        {
            var response = CreateUser(user);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }

        public void VerifyUserCreateWithArrayAPI(User[] usersArray)
        {
            var response = CreateUserWithArray(usersArray);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }

        public void VerifyUserCreateWithListAPI(List<User> usersList)
        {
            var response = CreateUserWithList(usersList);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }

        public void VerifyUserDeleteAPI(string username)
        {
            var response = DeleteUser(username);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyGetUser(User user)
        {
            var response = GetUser(user.username);

            Assert.That(response.Data.id, Is.EqualTo(user.id));
            Assert.That(response.Data.username, Is.EqualTo(user.username));
            Assert.That(response.Data.firstName, Is.EqualTo(user.firstName));
            Assert.That(response.Data.lastName, Is.EqualTo(user.lastName));
            Assert.That(response.Data.email, Is.EqualTo(user.email));
            Assert.That(response.Data.password, Is.EqualTo(user.password));
            Assert.That(response.Data.phone, Is.EqualTo(user.phone));
            Assert.That(response.Data.userStatus, Is.EqualTo(user.userStatus));
        }

        public void VerifyThatUserIsNotFound(User user)
        {
            var response = GetUser(user.username);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
         
        }

        public void VerifyThatUserIsLoggedIn(string username, string password)
        {
            var response = LoginUser(username, password);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyThatUserIsNotLoggedIn(string username, string password)
        {
            var response = LoginUser(username, password);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
        }

        public void VerifyThatUserIsLoggedOut()
        {
            var response = LogoutUser();

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

    }
}

