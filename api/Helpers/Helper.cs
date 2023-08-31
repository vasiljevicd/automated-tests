using System;
using api.Config;
using api.core.Models;
using api.Models;

namespace api.Core.Helpers
{
	public class Helper
	{
		public Helper()
		{
		}


        internal static string ReturnStringPetStatus(PetStatus status)
        {
            switch (status)
            {
                case PetStatus.AVALIABLE:
                    return "available";
                case PetStatus.PENDING:
                    return "pending";
                case PetStatus.SOLD:
                    return "sold";
            }

            return "";
        }

        internal static string ReturnStringOrderStatus(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.PLACED:
                    return "placed";
                case OrderStatus.APPROVED:
                    return "approved";
                case OrderStatus.DELIVERD:
                    return "delivered";
            }

            return "";
        }

        internal static string GetPhotoPath()
        {

            string osName = Environment.OSVersion.ToString();
            if (osName.Contains("Windows"))
            {
               return AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net7.0\\", Configuration.photoPathWindows);
            }
            else
            {
                return AppDomain.CurrentDomain.BaseDirectory.Replace("bin/Debug/net7.0/", Configuration.photoPath);
            }

        }


        internal static Pet CreatePet()
        {
            Random random = new Random();
            int id = random.Next(10);
            int petId = random.Next(10);
            Category category = new Category(1, "category1");
            Tag tag1 = new Tag(1, "tag1");
            Tag tag2 = new Tag(2, "tag2");
            
            List<Tag> tags = new List<Tag>();
            tags.Add(tag1);
            tags.Add(tag2);
            List<string> photoUrls = new List<string>();
            photoUrls.Add("photoUrl");

            Pet pet = new Pet(id, category, "pet" + id, photoUrls, tags, Helper.ReturnStringPetStatus(PetStatus.AVALIABLE));

            return pet;
        }

        internal static Pet UpdatePet(Pet pet)
        {
            Tag tag3 = new Tag(3, "tag3");
            pet.tags.Add(tag3);

            List<string> photoUrlsUpdated = new List<string>();
            photoUrlsUpdated.Add("photoUrlUpdated");

            pet.name = "petUpdate" + pet.id;
            pet.photoUrls = photoUrlsUpdated;
            pet.status = Helper.ReturnStringPetStatus(PetStatus.SOLD);

            return pet;
        }
    }
}

