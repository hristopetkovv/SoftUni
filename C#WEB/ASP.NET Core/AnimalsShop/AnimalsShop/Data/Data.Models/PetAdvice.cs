namespace AnimalsShop.Data.Data.Models
{
    using AnimalsShop.Data.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation;

    public class PetAdvice
    {
        public int Id { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
