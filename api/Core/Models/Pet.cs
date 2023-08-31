using System;
namespace api.core.Models
{
    public class Pet
    {
        public int id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }

        public Pet(int Id, Category Category, string Name, List<String> PhotoUrls, List<Tag> Tags, string Status)
        {
            id = Id;
            category = Category;
            name = Name;
            photoUrls = PhotoUrls;
            tags = Tags;
            status = Status;

        }

    }

    public enum PetStatus
    {
       
        AVALIABLE,

        
        PENDING,

       
        SOLD

    }


    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }

        public Category(int Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }

    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }

        public Tag(int Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }
}
