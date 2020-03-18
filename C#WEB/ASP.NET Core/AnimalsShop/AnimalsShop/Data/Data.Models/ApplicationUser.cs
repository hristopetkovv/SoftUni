namespace AnimalsShop.Data.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();       
        }

        [MaxLength(NameMaxLength)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLength)]
        [Required]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
