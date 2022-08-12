using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace RRMemberRegister.Pages.member
{
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Styr vilket meddelande som visas överst i index filen
        /// 1 = created, 2 = updated, 3 = deleted
        /// </summary>
        [TempData]
        public int MemberAction { get; set; } = 0;

        /// <summary>
        /// Reference till Service lagret
        /// </summary>
        public IMemberRegisterService Service { get; }

        /// <summary>
        /// Member objekt med information om medlem som skall skapas
        /// </summary>
        [BindProperty]
        public Member Member { get; set; }

        /// <summary>
        /// Variabel som sätt till true om det inte gick att skapa en ny medlem
        /// När denna variabel är true visas ett felmeddelande i view
        /// </summary>
        public bool CreateError { get; set; } = false;


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till Service lagret</param>
        public CreateModel(IMemberRegisterService service)
        {
            Service = service;
        }


        public IActionResult OnGet()
        {
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Member newMember = this.Service.CreateMember(this.Member);

                    if(newMember != null)
                    {
                        this.MemberAction = 1;

                        //return RedirectToPage("./Index");
                        return new RedirectToPageResult("./Index", "WithMemberAction");
                    }
                    else
                    {
                        CreateError = true;
                    }                    
                }
                catch (Exception)
                {
                    CreateError = true;
                }
            }

            return Page();
        }
    }
}
