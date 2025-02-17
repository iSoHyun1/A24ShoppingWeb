using Microsoft.AspNetCore.Identity;

namespace A24Shopping.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupation {  get; set; }
    }
}
