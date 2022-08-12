using MemberRegister.Models;
using System.Collections.Generic;

namespace MemberRegister.Services
{
    public interface IMemberRegisterService
    {
        /// <summary>
        /// Metoden returnerar medlem med id
        /// </summary>
        /// <param name="id">Id för sökt medlem</param>
        /// <returns>Sökt medlem</returns>
        Member GetMember(int id);

        /// <summary>
        /// Metoden returnerar alla medlemmar som finns i repository
        /// </summary>
        /// <returns>List med alla medlemmar i repository</returns>
        List<Member> GetMembers();

        /// <summary>
        /// Metoden skapar en medlem i repository
        /// </summary>
        /// <param name="member">Objekt med infomation om den nya medlemen</param>
        /// <returns>Objekt med medlemmens information uppdaterad med det id som medlemen fick i repository</returns>
        Member CreateMember(Member member);

        /// <summary>
        /// Metoden uppdaterar information om en medlem i repository
        /// </summary>
        /// <param name="member">Objekt med information om medlemen</param>
        /// <returns>Om uppdateringen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        int UpdateMember(Member member);

        /// <summary>
        /// Metoden raderar en medlem från repository
        /// </summary>
        /// <param name="member">Objekt med information om en medlem</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        int DeleteMember(Member member);

        /// <summary>
        /// Metoden raderar en medlem från repository
        /// </summary>
        /// <param name="id">Id för den medlem som skall raderas</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        int DeleteMember(int id);

        /// <summary>
        /// Metoden returnerar alla medlemar i registret
        /// </summary>
        /// <returns>Om raderingen gick bra returneras ett positivt tal. Annars returneras ett negativt tal</returns>
        int DeleteAllMembers();
    }
}
