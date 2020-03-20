namespace AnimalShop.Data.Models
{
    using AnimalShop.Data.Common.Models;

    public class ContactForm : BaseModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }
    }
}
