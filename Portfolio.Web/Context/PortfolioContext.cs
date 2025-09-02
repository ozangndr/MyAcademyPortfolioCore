using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Context
{
    public class PortfolioContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=GE-AGONDUR\\SQLEXPRESS;database=MyAcademyPortfolioDb;user id=sa;password=Btnsft1958;TrustServerCertificate=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
