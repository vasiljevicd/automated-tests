using System;
using api.core.Models;
using api.Core.Helpers;
using api.Models;
using api.ModelsAPI;

namespace api.Tests.Suites
{
	public class StoreSuite
	{

        StoreAPI storeAPI = new StoreAPI();
        PetAPI petAPI = new PetAPI();
        Random random = new Random();


        [Test]
        public void Test01CRUDOrder()
        {
            int id = random.Next(10);
            int petId = random.Next(10);
            DateTime date = DateTime.Now;
            Order order = new Order(id, petId, 1, String.Format("{0:s}", date), Helper.ReturnStringOrderStatus(OrderStatus.PLACED), true);

            //create order
            storeAPI.VerifyCreateOrderAPI(order);
            //verify that order is created
            storeAPI.VerifyGetOrder(order);

            //delete order
            storeAPI.VerifyOrderDeleteAPI(order.id);
            //verify that order is deleted
            storeAPI.VerifyThatOrderIsNotFound(order);
        }

        [Test]
        public void Test02CheckInventory()
        {
            int quantity = storeAPI.GetInventoryQuantityForStatus(Helper.ReturnStringPetStatus(PetStatus.AVALIABLE));

            //create a pet with avaliable status
            Pet pet = Helper.CreatePet();

            //create pet
            petAPI.VerifyCreatePetAPI(pet);

            //verify that inventory is updated
            storeAPI.VerifyInventoryQuanitiyForStatus(Helper.ReturnStringPetStatus(PetStatus.AVALIABLE), quantity+1);

        }



    }
}

