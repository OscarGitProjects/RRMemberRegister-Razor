using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RRMemberRegister.Pages.member
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Member objekt med information om sökt medlem
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Reference till Service lagret
        /// </summary>
        public IMemberRegisterService Service { get; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till Service lagret</param>
        public DetailsModel(IMemberRegisterService service)
        {
            Service = service;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {           
                Member = this.Service.GetMember(id.Value);
            }

            return Page();
        }
    }
}
