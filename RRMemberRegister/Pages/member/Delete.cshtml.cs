using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RRMemberRegister.Pages.member
{
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Styr vilket meddelande som visas överst i index filen
        /// 1 = created, 2 = updated, 3 = deleted
        /// </summary>
        [TempData]
        public int MemberAction { get; set; } = 0;

        /// <summary>
        /// Member objekt med information om sökt medlem
        /// </summary>
        [BindProperty]
        public Member Member { get; set; }


        /// Variabel som sätt till true om det inte gick att radera medlem
        /// När denna variabel är true visas ett felmeddelande i view
        public bool DeleteError { get; set; } = false;


        /// <summary>
        /// Reference till Service lagret
        /// </summary>
        public IMemberRegisterService Service { get; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till Service lagret</param>
        public DeleteModel(IMemberRegisterService service)
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

        public IActionResult OnPost(int? id)
        {
            int returnValue = 0;

            if(id.HasValue)
            {
                returnValue = this.Service.DeleteMember(id.Value);

                if(returnValue > 0)
                {// Radering av medlem gick bra. redirect till listan av medlemmar

                    MemberAction = 3;
                    //return RedirectToPage("./Index");
                    return new RedirectToPageResult("./Index", "WithMemberAction");
                }
                else
                {// Det gick inte radera medlemen. Vissa felmeddelande om detta

                    this.DeleteError = true;
                    return this.OnGet(id);
                }
            }

            return Page();
        }
    }
}