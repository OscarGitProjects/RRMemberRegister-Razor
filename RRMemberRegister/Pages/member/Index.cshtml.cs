using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace RRMemberRegister.Pages.member
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Variabeln talar om det har skett ett anrop till IndexModel från en View som vill visa ett meddelande i Index view
        /// Meddelande visas om det har skapats en ny medlem, en medlems information har uppdaterats, en medlem har raderats
        /// 0 = ej satt värde, 1 = created, 2 = updated, 3 = deleted
        /// </summary>
        public int MemberAction { get; set; } = 0;

        /// <summary>
        /// List med medlemmar
        /// </summary>
        public IList<Member> Member { get; set; }

        /// <summary>
        /// Reference till Service lagret
        /// </summary>
        private IMemberRegisterService MemberRegisterService { get; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till Service lagret</param>
        public IndexModel(IMemberRegisterService service)
        {
            MemberRegisterService = service;
        }


        /// <summary>
        /// Metoden hämtar eventuellt MemberAction från TempData. Sparar värdet i variabeln MemberAction
        /// </summary>
        /// <returns>MemberAction</returns>
        private int GetMemberActionFromTempData()
        {
            // Hämta information om vilken action som har utförts från Tempdata. Sätt värdet till MemberAction
            // 0 = ej satt värde, 1 = created, 2 = updated, 3 = deleted
            if (TempData.ContainsKey("MemberAction"))
            {
                try
                {
                    Object obj = TempData["MemberAction"] as Object;
                    if (obj != null)
                    {
                        this.MemberAction = Int32.Parse(obj.ToString());
                    }
                }
                catch (Exception)
                { // Vill bara fånga undantagen
                }
            }

            return this.MemberAction;
        }


        /// <summary>
        /// Get metod som anropas från Create, Edit och Delete view.
        /// Beroende på vilken action som har utförts kommer olika meddelanden visas
        /// </summary>
        public void OnGetWithMemberAction()
        {
            GetMemberActionFromTempData();

            // Hämta alla medlemmar
            Member = MemberRegisterService.GetMembers();
        }

        public void OnGet()
        {
            // Hämta alla medlemmar
            Member = MemberRegisterService.GetMembers();
        }
    }
}
