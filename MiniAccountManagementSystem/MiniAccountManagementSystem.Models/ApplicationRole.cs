using Microsoft.AspNetCore.Identity;

namespace MiniAccountManagementSystem.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public string? Description { get; set; }

        // Default constructor ensures Id is auto-generated
        public ApplicationRole() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        // Overloaded constructor to create with name and description
        public ApplicationRole(string roleName, string description = null) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
            Description = description;
        }
    }
}
