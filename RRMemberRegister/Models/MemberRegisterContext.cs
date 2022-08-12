using Microsoft.EntityFrameworkCore;
using System;

namespace MemberRegister.Models
{
    public class MemberRegisterContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Member> Members { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MemberRegisterContext()
        {
            this.Database.Migrate();
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="options"></param>
        public MemberRegisterContext(DbContextOptions<MemberRegisterContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime dtNow = DateTime.Now;
            string strNow = dtNow.ToShortDateString();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1,
                    Fornamn = "Fornamn 1",
                    Efternamn = "Efternamn 1",
                    Adress = "Adress 1",
                    Postnummer = "111111",
                    Postort = "Postort 1",
                    Skapatdatum = dtNow,
                    Senastuppdateraddatum = dtNow,
                    Skapatdatumasstring = strNow
                },
                new Member
                {
                    Id = 2,
                    Fornamn = "Fornamn 2",
                    Efternamn = "Efternamn 2",
                    Adress = "Adress 2",
                    Postnummer = "222222",
                    Postort = "Postort 2",
                    Skapatdatum = dtNow,
                    Senastuppdateraddatum = dtNow,
                    Skapatdatumasstring = strNow
                },
                new Member
                {
                    Id = 3,
                    Fornamn = "Fornamn 3",
                    Efternamn = "Efternamn 3",
                    Adress = "Adress 3",
                    Postnummer = "33333",
                    Postort = "Postort 3",
                    Skapatdatum = dtNow,
                    Senastuppdateraddatum = dtNow,
                    Skapatdatumasstring = strNow
                },
                new Member
                {
                    Id = 4,
                    Fornamn = "Fornamn 4",
                    Efternamn = "Efternamn 4",
                    Adress = "Adress 4",
                    Postnummer = "44444",
                    Postort = "Postort 4",
                    Skapatdatum = dtNow,
                    Senastuppdateraddatum = dtNow,
                    Skapatdatumasstring = strNow
                },
                new Member
                {
                    Id = 5,
                    Fornamn = "Fornamn 5",
                    Efternamn = "Efternamn 5",
                    Adress = "Adress 5",
                    Postnummer = "55555",
                    Postort = "Postort 5",
                    Skapatdatum = dtNow,
                    Senastuppdateraddatum = dtNow,
                    Skapatdatumasstring = strNow
                }
            );
        }
    }
}