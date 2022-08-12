using MemberRegister.Models;
using MemberRegister.Repository;
using System;
using System.Collections.Generic;

namespace MemberRegister.Services
{
    public class MemberRegisterService : IMemberRegisterService
    {
        private readonly IMemberRegisterRepository m_Repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MemberRegisterService(IMemberRegisterRepository repository)
        {
            this.m_Repository = repository;
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
            if(member == null)
                throw new ArgumentNullException("MemberRegisterService->CreateMember(). Referensen till member är null");
            
            Member mem = this.m_Repository.CreateMember(member);
            if (mem != null)
                mem.Skapatdatumasstring = mem.Skapatdatum.ToShortDateString();

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
                throw new ArgumentNullException("MemberRegisterService->DeleteMember(). Referensen till member är null");

            return this.m_Repository.DeleteMember(member);
        }

        /// <summary>
        /// Metoden raderar en medlem från repository
        /// </summary>
        /// <param name="id">Id för den medlem som skall raderas</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        public int DeleteMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberRegisterService->DeleteMember(). Ogiltigt id. Id <= 0");

            return this.m_Repository.DeleteMember(id);
        }

        /// <summary>
        /// Metoden returnerar medlem med id
        /// </summary>
        /// <param name="id">Id för sökt medlem</param>
        /// <returns>Sökt medlem</returns>
        /// <exception cref = "ArgumentException" > Om id är ogiltigt dvs id <= 0</exception>
        public Member GetMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberRegisterService->GetMember(). Ogiltigt id. Id <= 0");

            Member member = this.m_Repository.GetMember(id);
            if(member != null)
                member.Skapatdatumasstring = member.Skapatdatum.ToShortDateString();

            return member;
        }

        /// <summary>
        /// Metoden returnerar alla medlemmar som finns i repository
        /// </summary>
        /// <returns>List med alla medlemmar i repository</returns>
        public List<Member> GetMembers()
        {
            List<Member>lsMembers = this.m_Repository.GetMembers();
            if(lsMembers?.Count > 0)
            {
                foreach(Member member in lsMembers)
                {
                    member.Skapatdatumasstring = member.Skapatdatum.ToShortDateString();
                }
            }

            return lsMembers;
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
                throw new ArgumentNullException("MemberRegisterService-> UpdateMember(). Referensen till member är null");          

            return this.m_Repository.UpdateMember(member);
        }
    }
}
