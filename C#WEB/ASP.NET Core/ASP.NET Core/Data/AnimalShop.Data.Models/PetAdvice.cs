namespace AnimalShop.Data.Models
{
    using AnimalShop.Data.Models.Enums;

    public class PetAdvice
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
