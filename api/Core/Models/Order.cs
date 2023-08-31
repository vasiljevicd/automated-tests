using System;
namespace api.Models
{
	public class Order
	{
		public int id { get; set; }

        public int petId { get; set; }

        public int quantity { get; set; }

        public string? shipDate { get; set; }

        public string? status { get; set; }

        public bool complete { get; set; }

        public Order(int Id, int PetId, int Quantity, string ShipDate, string Status, bool Complete)
        {
            id = Id;
            petId = PetId;
            quantity = Quantity;
            shipDate = ShipDate;
            status = Status;
            complete = complete;
        }
    }

    public enum OrderStatus
    {

        PLACED,


        APPROVED,


        DELIVERD

    }

}

