using System;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using api.core.Models;
using api.Models;
using Dynamitey.DynamicObjects;
using Newtonsoft.Json;
using RestSharp;

namespace api
{
	public class PetAPI : BaseAPI
	{
		public PetAPI()
		{
		}

        public RestResponse UploadPetImage(int petId, string pathToFile)
        {
            method = RestSharp.Method.Post;
            contentType = "multipart/form-data";
            resource = $"pet/{petId}/uploadImage";


            return client.Execute<Pet>(CreateRequestUploadFile(pathToFile)); ;
        }

        public RestResponse<Pet> CreatePet(Pet pet)
        {
            method = RestSharp.Method.Post;
            contentType = "application/json";
            resource = "pet";

            return client.Execute<Pet>(CreateRequest(pet)); ;
        }

        public RestResponse<Pet> UpdatePet(Pet updatedPet)
        {
            method = RestSharp.Method.Put;
            contentType = "application/json";
            resource = "pet";

            return client.Execute<Pet>(CreateRequest(updatedPet)); ;
        }

        public RestResponse<List<Pet>> FindPetByStatus(string[] statuses)
        {
            method = RestSharp.Method.Get;
            contentType = "";
            resource = "pet/findByStatus";

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            foreach (string status in statuses)
            {
                queryParams.Add("status", status);
            }

            return client.Execute<List<Pet>>(CreateRequestWithQueryParams(queryParams)); ;
        }

        public RestResponse<Pet> GetPet(int petId)
        {
            method = RestSharp.Method.Get;
            contentType = "application/json";
            resource = $"pet/{petId}";

            return client.Execute<Pet>(CreateRequest()); ;
        }


        public RestResponse UpdatePetNameAndStatus(int petId, string name, string status)
        {
            method = RestSharp.Method.Post;
            contentType = "application/x-www-form-urlencoded";
            resource = $"pet/{petId}";

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("name", name);
            queryParams.Add("status", status);

            return client.Execute(CreateRequestWithQueryParams(queryParams)); ;
        }

        public RestResponse DeletePet(int petId)
        {
            method = RestSharp.Method.Delete;
            contentType = "application/json";
            resource = $"pet/{petId}";

            return client.Execute(CreateRequest());
        }

        public void VerifyCreatePetAPI(Pet pet)
        {

            var response = CreatePet(pet);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Data.id, Is.EqualTo(pet.id));
            Assert.That(response.Data.category.id, Is.EqualTo(pet.category.id));
            Assert.That(response.Data.category.name, Is.EqualTo(pet.category.name));
            Assert.That(response.Data.name, Is.EqualTo(pet.name));
            Assert.That(response.Data.photoUrls, Is.EqualTo(pet.photoUrls));
            Assert.That(response.Data.status, Is.EqualTo(pet.status));
        }


        public void VerifyPetUpdatingAPI(Pet updatedPet)
        {
            var response = UpdatePet(updatedPet);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Data.id, Is.EqualTo(updatedPet.id));
            Assert.That(response.Data.category.id, Is.EqualTo(updatedPet.category.id));
            Assert.That(response.Data.category.name, Is.EqualTo(updatedPet.category.name));
            Assert.That(response.Data.name, Is.EqualTo(updatedPet.name));
            Assert.That(response.Data.photoUrls, Is.EqualTo(updatedPet.photoUrls));
            Assert.That(response.Data.status, Is.EqualTo(updatedPet.status));
        }

        public void VerifyUpdatingNonExistingPet(Pet pet)
        {
            var response = UpdatePet(pet);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }


        public void VerifyUpdatePetNameAndStatus(int petId, string newName, string newStatus)
        {
            var response = UpdatePetNameAndStatus(petId, newName, newStatus);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyFindByStatusAPI(string[] statuses, Pet myPet)
        {
            var response = FindPetByStatus(statuses);
            List<Pet> pets = response.Data;

            Pet pet = pets.Find(p => p.id == myPet.id);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            //Assert.That(pet.id, Is.EqualTo(myPet.id));
            //Assert.That(pet.category.id, Is.EqualTo(myPet.category.id));
            //Assert.That(pet.category.name, Is.EqualTo(myPet.category.name));
            //Assert.That(pet.name, Is.EqualTo(myPet.name));
            //Assert.That(pet.photoUrls, Is.EqualTo(updatedPet.photoUrls));
            //Assert.That(pet.status, Is.EqualTo(myPet.status));
        }

        public void VerifyFindByInvalidStatusAPI(string[] statuses)
        {
            var response = FindPetByStatus(statuses);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));

        }

        public void VerifyGetPet(Pet pet)
        {

            var response = GetPet(pet.id);

            Assert.That(response.Data.id, Is.EqualTo(pet.id));
            Assert.That(response.Data.category.id, Is.EqualTo(pet.category.id));
            Assert.That(response.Data.category.name, Is.EqualTo(pet.category.name));
            Assert.That(response.Data.name, Is.EqualTo(pet.name));
            Assert.That(response.Data.photoUrls, Is.EqualTo(pet.photoUrls));
            Assert.That(response.Data.status, Is.EqualTo(pet.status));
        }

        public void VerifyPetDeleteAPI(int petId)
        {
            var response = DeletePet(petId);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyThaPetIsNotFound(Pet pet)
        {
            var response = GetPet(pet.id);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));

        }

        public void VerifyUploadPetImage(int petId, string pathToFile)
        {
            var response = UploadPetImage(petId, pathToFile);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
           
        }

        public void VerifyFindPetByStatusAPI(string[] statuses)
        {
            var response = FindPetByStatus(statuses);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            
        }
    }
}

