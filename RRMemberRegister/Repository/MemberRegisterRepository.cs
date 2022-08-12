using MemberRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberRegister.Repository
{
    /// <summary>
    /// Repository för member register
    /// </summary>
    public class MemberRegisterRepository : IMemberRegisterRepository
    {
        private readonly MemberRegisterContext m_Context;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context">Referense till context</param>
        public MemberRegisterRepository(MemberRegisterContext context)
        {
            this.m_Context = context;
        }

        /// <summary>
        /// Metoden skapar en medlem i repository
        /// </summary>
        /// <param name="member">Objekt med infomation om den nya medlemen</param>
        /// <returns>Objekt med medlemmens information uppdaterad med det id som medlemen fick i repository.
        /// Om det inte gick att spara returneras null</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception>
        public Member CreateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberRegisterRepository->CreateMember(). Referense till member är null");

            DateTime dtNow = DateTime.Now;
            member.Skapatdatum = dtNow;
            member.Senastuppdateraddatum = dtNow;

            this.m_Context.Members.Add(member);
            if (this.m_Context.SaveChanges() <= 0)
                return null;

            return member;
        }

        /// <summary>
        /// Metoden returnerar alla medlemar i registret
        /// </summary>
        /// <returns>Om raderingen gick bra returneras ett positivt tal. Annars returneras ett negativt tal</returns>
        public int DeleteAllMembers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoden raderar en medlem från repository
        /// </summary>
        /// <param name="member">Objekt med information om en medlem</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception>
        public int DeleteMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberRegisterRepository->DeleteMember(). Referense till member är null");

            return this.DeleteMember(member.Id);
        }

        /// <summary>
        /// Metoden raderar en medlem från repository
        /// </summary>
        /// <param name="id">Id för den medlem som skall raderas</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="ArgumentException">Om id är ogiltigt dvs id <= 0</exception>
        public int DeleteMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberRegisterRepository->DeleteMember(). Ogiltigt id. Id <= 0");

            int iReturnValue = -1;

            Member member = this.m_Context.Members
                .Where(m => m.Id == id)
                .FirstOrDefault<Member>();

            if(member != null)
            {
                this.m_Context.Members.Remove(member);
                if(this.m_Context.SaveChanges() > 0)
                    iReturnValue = id;
            }

            return iReturnValue;
        }

        /// <summary>
        /// Metoden returnerar medlem med id
        /// </summary>
        /// <param name="id">Id för sökt medlem</param>
        /// <returns>Sökt medlem</returns>
        /// <exception cref="ArgumentException">Om id är ogiltigt dvs id <= 0</exception>
        public Member GetMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberRegisterRepository->GetMember(). Ogiltigt id. Id <= 0");

            Member member = this.m_Context.Members
                .Where(m => m.Id == id)
                .FirstOrDefault<Member>();

            return member;
        }

        /// <summary>
        /// Metoden returnerar alla medlemar som finns i repository
        /// </summary>
        /// <returns>List med alla medlemmar i repository</returns>
        public List<Member> GetMembers()
        {
            return m_Context.Members.ToList<Member>();
        }

        /// <summary>
        /// Metoden uppdaterar information om en medlem i repository
        /// </summary>
        /// <param name="member">Objekt med information om medlemen</param>
        /// <returns>Om uppdateringen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception>
        public int UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberRegisterRepository->UpdateMember(). Referense till member är null");

            // Fix. typescript class member innehåller ingen DataTime för när medlemen skapades. Den infon finns i en string
            // Därför hämtar jag datum när medlemen skapades från databasen
            Member oldMember = this.m_Context.Members
                .AsNoTracking()
                .Where(m => m.Id == member.Id)
                .FirstOrDefault<Member>();

            if (oldMember != null)
                member.Skapatdatum = oldMember.Skapatdatum;

            member.Senastuppdateraddatum = DateTime.Now;

            int iReturnValue = -1;

            this.m_Context.Members.Update(member);
            if(this.m_Context.SaveChanges() > 0)
                iReturnValue = member.Id;

            return iReturnValue;
        }
    }
}
