namespace AnimalShop.Data.Models
{
    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    public class PetAdvice : BaseModel<int>
    {
        public string Description { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
