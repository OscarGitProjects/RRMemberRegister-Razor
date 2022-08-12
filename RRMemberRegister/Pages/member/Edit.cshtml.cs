using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace RRMemberRegister.Pages.member
{
    public class EditModel : PageModel
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


        /// <summary>
        /// Reference till Service lagret
        /// </summary>
        public IMemberRegisterService Service { get; }


        /// <summary>
        /// Variabel som sätt till true om det inte gick att uppdatera uppgifterna om en medlem
        /// När denna variabel är true visas ett felmeddelande i view
        /// </summary>
        public bool UpdateError { get; set; } = false;



        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till Service lagret</param>
        public EditModel(IMemberRegisterService service)
        {
            Service = service;
        }


        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Member = this.Service.GetMember(id.Value);
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            int returnValue = 0;

            if (ModelState.IsValid)
            {
                try
                {
                    returnValue = this.Service.UpdateMember(this.Member);

                    if (returnValue > 0)
                    {// Uppdatering av medlemmen gick bra. redirect till listan av medlemmar
                        this.MemberAction = 2;
                        //return RedirectToPage("./Index");
                        return new RedirectToPageResult("./Index", "WithMemberAction");
                    }
                    else
                    {// Det gick inte uppdatera uppgifter om en medlem. Visa felmeddelande om detta
                        this.UpdateError = true;
                        this.OnGet(this.Member.Id);
                    }
                }
                catch(Exception)
                {
                    this.UpdateError = true;
                    this.OnGet(this.Member.Id);
                }
            }

            return Page();
        }
    }
}
