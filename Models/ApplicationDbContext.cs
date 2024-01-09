using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace USBDProperty.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        //public DbSet<PropertyFor> PropertyFors { get; set; }
        public DbSet<PropertyFeatures> PropertyFeatures { get; set; }
        public DbSet<TermsCondition> TermsConditions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<SocialIcon> SocialIcons { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<DevelopersorAgent> DevelopersorAgent { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicy { get; set; }
        public DbSet<PropertyImages> PropertyImages { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<PropertyWithFeatures> PropertyWithFeatures { get; set; }
        public DbSet<ProjectsInfo> ProjectsInfo { get; set; }
        public DbSet<ProjectImageGallery> ProjectImageGallery { get; set; }
    }
}
