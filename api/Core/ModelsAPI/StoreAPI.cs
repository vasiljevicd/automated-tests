using System;
using api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace api
{
	public class StoreAPI : BaseAPI
	{
		public StoreAPI()
		{
            contentType = "application/json";
        }

		public RestResponse GetInventory()
		{
			method = RestSharp.Method.Get;
			resource = "store/inventory";

            return client.Execute(CreateRequest());
        }

        public RestResponse<Order> CreateOrder(Order order)
        {
            method = RestSharp.Method.Post;
            resource = "store/order";
           
            return client.Execute<Order>(CreateRequest(order)); ;
        }

        public RestResponse<Order> GetOrder(int orderId)
        {
            method = RestSharp.Method.Get;
            resource = $"store/order/{orderId}";

            return client.Execute<Order>(CreateRequest()); ;
        }

        public RestResponse DeleteOrder(int orderId)
        {
            method = RestSharp.Method.Delete;
            resource = $"store/order/{orderId}";

            return client.Execute(CreateRequest());
        }

        public void VerifyCreateOrderAPI(Order order )
        {

            var response = CreateOrder(order);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Data.id, Is.EqualTo(order.id));
            Assert.That(response.Data.petId, Is.EqualTo(order.petId));
            Assert.That(response.Data.quantity, Is.EqualTo(order.quantity));
            Assert.That(response.Data.shipDate, Is.EqualTo(order.shipDate+ ".000+0000"));
            Assert.That(response.Data.status, Is.EqualTo(order.status));
            Assert.That(response.Data.complete, Is.EqualTo(order.complete));
        }

        public void VerifyGetOrder(Order order)
        {

            var response = GetOrder(order.id);

            Assert.That(response.Data.id, Is.EqualTo(order.id));
            Assert.That(response.Data.petId, Is.EqualTo(order.petId));
            Assert.That(response.Data.quantity, Is.EqualTo(order.quantity));
            Assert.That(response.Data.shipDate, Is.EqualTo(order.shipDate + ".000+0000"));
            Assert.That(response.Data.status, Is.EqualTo(order.status));
            Assert.That(response.Data.complete, Is.EqualTo(order.complete));
        }

        public void VerifyOrderDeleteAPI(int orderId)
        {
            var response = DeleteOrder(orderId);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        public void VerifyThatOrderIsNotFound(Order order)
        {
            var response = GetOrder(order.id);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));

        }

        public int GetInventoryQuantityForStatus(string status)
        {
            var response = GetInventory();
            var content = response.Content;

            JObject jsonObject = JObject.Parse(content);
            int quantity = (int)jsonObject[status];

            return quantity;
        }

        public void VerifyInventoryQuanitiyForStatus(string status, int quantity)
        {
            int quantityFromResponse = GetInventoryQuantityForStatus(status);
            Assert.That(quantityFromResponse, Is.EqualTo(quantity));
        }
    }
}

