using api.core.Models;
using api.Core.Helpers;

namespace api.Tests.Suites
{
	public class PetSuite
	{

        PetAPI petAPI = new PetAPI();


        [Test]
        public void Test01CRUDPet()
        {
            Pet pet = Helper.CreatePet();

            //create pet
            petAPI.VerifyCreatePetAPI(pet);

            //get created pet
            petAPI.VerifyGetPet(pet);

            //update created pet
            pet = Helper.UpdatePet(pet);

            petAPI.VerifyPetUpdatingAPI(pet);

            //get created pet
            petAPI.VerifyGetPet(pet);

            //deletePet
            petAPI.VerifyPetDeleteAPI(pet.id);

            //verifying that pet is not found
            petAPI.VerifyThaPetIsNotFound(pet);

        }


        [Test]
        public void Test02UploadPetImage()
        {
            Pet pet= Helper.CreatePet();

            string path = Helper.GetPhotoPath();

            //create pet
            petAPI.VerifyCreatePetAPI(pet);

            //upload pet image
            petAPI.VerifyUploadPetImage(pet.id, path);

        }

        [Test]
        public void Test03UpdatingNonExistingPet()
        {
            Pet pet = Helper.CreatePet();

            //create pet
            petAPI.VerifyCreatePetAPI(pet);

            Pet newPet = Helper.CreatePet();

            //update not created pet
            petAPI.VerifyUpdatingNonExistingPet(newPet);

        }

        [Test]
        public void Test04UpdateNameAndStatusOfPet()
        {
            Pet pet = Helper.CreatePet();

            //create pet
            petAPI.VerifyCreatePetAPI(pet);

            pet.name = "newName";
            pet.status = Helper.ReturnStringPetStatus(PetStatus.PENDING);

            //update pet name and status
            petAPI.VerifyUpdatePetNameAndStatus(pet.id, pet.name, pet.status);

            // get updated pet
            petAPI.VerifyGetPet(pet);

        }

        [Test]
        public void Test05GetPetByInvalidStatus()
        { 
            string[] statuses = new string[1];
            statuses[0] = "invalidStatus";

            petAPI.VerifyFindByInvalidStatusAPI(statuses);


        }

    }
}

