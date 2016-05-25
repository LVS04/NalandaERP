using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace DNXTest.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactName);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Prefix);

            modelBuilder.Entity<Contact>()
                .Property(e => e.FirstName);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LastName);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Suffix);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Gender);

            modelBuilder.Entity<Contact>()
                .Property(e => e.PositionAndCompany);

            modelBuilder.Entity<Contact>()
                .Property(e => e.NickName);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Notes);

            modelBuilder.Entity<Contact>()
                .Property(e => e.HistoryWithTheCenter);

            modelBuilder.Entity<Contact>()
                .Property(e => e.FoodAllergies);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Birthdate);



            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Dates);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Emails);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Phones);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Addresses);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.RelatedContacts)
                .WithOne(k => k.Contact);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.WebSites);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.IMs);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.InternetCallIds);




            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactIdentification)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactIdentification>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactDharmaExperience)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactDharmaExperience>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactEducation)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactEducation>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactWorkPreference)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactWorkPreference>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactVolunteeringExperience)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactVolunteeringExperience>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactDonorInfo)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactDonorInfo>(k => k.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(e => e.ContactHealthInfo)
                .WithOne(k => k.Contact)
                .HasForeignKey<ContactHealthInfo>(k => k.Id);



            //  ------------------------------------
            //  ContactDate
            //  ------------------------------------
            modelBuilder.Entity<ContactDate>()
                .Property(e => e.Date);

            modelBuilder.Entity<ContactDate>()
                .Property(e => e.Description);

            modelBuilder.Entity<ContactDate>()
                .HasIndex(new string[] { "ContactId", "SortOrder"});

            //  ------------------------------------
            //  ContactEmail
            //  ------------------------------------
            /*modelBuilder.Entity<ContactEmail>()
                .Property(e => e.Email);*/
            modelBuilder.Entity<ContactEmail>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<ContactEmail>()
                .Property(e => e.Description);

            modelBuilder.Entity<ContactEmail>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  ContactPhone
            //  ------------------------------------
            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.CountryCode);

            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.Number);

            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.Description);

            modelBuilder.Entity<ContactPhone>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  ContactAddress
            //  ------------------------------------
            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Street);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.POBOX);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Neighborhood);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.City);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Province);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.PostalCode);

            /*TODO
            modelBuilder.Entity<ContactAddress>()
                .HasOne(e => e.Country);*/

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Country);

            modelBuilder.Entity<ContactAddress>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  Country for address TODO: improve later
            //  ------------------------------------
            modelBuilder.Entity<Country>()
                .Property(e => e.Description) 
                ;



            //  ------------------------------------
            //  ContactRelationship for ContactRelated
            //  ------------------------------------
            modelBuilder.Entity<ContactRelationship>()
                    .Property(e => e.Description)
                    ;



            //  ------------------------------------
            //  ContactRelated
            //  ------------------------------------
            modelBuilder.Entity<ContactRelated>()
                 .Property(e => e.IdContactRelated);

            modelBuilder.Entity<ContactRelated>()
                 .Property(e => e.ContacRelatedtName);

            modelBuilder.Entity<ContactRelated>()
                .HasOne(e => e.Relationship);

            modelBuilder.Entity<ContactRelated>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  ContactWebsite
            //  ------------------------------------
            modelBuilder.Entity<ContactWebsite>()
                .Property(e => e.WebSite);

            modelBuilder.Entity<ContactWebsite>()
                .Property(e => e.Description);

           modelBuilder.Entity<ContactWebsite>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  ContactInstantMessaging
            //  ------------------------------------
            modelBuilder.Entity<ContactInstantMessaging>()
                .Property(e => e.InstantMessaging);

            modelBuilder.Entity<ContactInstantMessaging>()
                .Property(e => e.IMContact);

            modelBuilder.Entity<ContactInstantMessaging>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  ContactInternetCall
            //  ------------------------------------
            modelBuilder.Entity<ContactInternetCall>()
                .Property(e => e.InternetCallId);

            modelBuilder.Entity<ContactInternetCall>()
                .Property(e => e.Description);

            modelBuilder.Entity<ContactInternetCall>()
                .HasIndex(new string[] { "ContactId", "SortOrder" });


            //  ------------------------------------
            //  SpokenLanguage for ContactIdentification
            //  ------------------------------------
            modelBuilder.Entity<SpokenLanguage>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  ContactIdentification
            //  ------------------------------------
            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassport);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassportIssueDate);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassportExpiryDate);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.FiscalId);

            //modelBuilder.Entity<ContactIdentification>()
            //    .HasOne(e => e.BornInCountry);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.BornInCountry);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.SpokenLanguages);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.PreferredLanguage);



            //  ------------------------------------
            //  ContactDharmaExperience
            //  ------------------------------------
            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.FollowerOfReligionWhich);

            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.InterestInFollowingTeachings);

            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.DescriptionOfBuddhistBackgroundOfAnyTradition);



            //  ------------------------------------
            //  ContactEducation
            //  ------------------------------------
            modelBuilder.Entity<ContactEducation>()
                .Property(e => e.DetailsOfUniversityPostGraduateOrTechnicalStudies);

            modelBuilder.Entity<ContactEducation>()
                .Property(e => e.OtherEducationalExperience);



            //  ------------------------------------
            //  ContactWorkPreference
            //  ------------------------------------
            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.Cooking);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.Maintenance);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.Gardening);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.Cleaning);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.IT);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.Office);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.ArtWorkshop);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.ExperienceOnWorkAreas);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WorkAreasExclusionAndReasons);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.ReasonsToOfferVoluntaryWorkToCenter);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WhenToComeStartDate);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WhenToComeEndDate);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.HopesExpectationsForStay);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.SkillsAndKnowledgesToDevelopDuringStay);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.HowDidContactFoundTheCenter);



            //  ------------------------------------
            //  ContactVolunteeringExperience
            //  ------------------------------------
            modelBuilder.Entity<ContactVolunteeringExperience>()
                .Property(e => e.DetailsOfMainWorkAndVolunteerinExperience);

            modelBuilder.Entity<ContactVolunteeringExperience>()
                .HasOne(e => e.ContactToAskAboutExperience);



            //  ------------------------------------
            //  DonorContext for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorContext>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  DonorInterest for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorInterest>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  DonorReligiousSituation for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorReligiousSituation>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  DonorType for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorType>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  ContactDonorInfo
            //  ------------------------------------
            //modelBuilder.Entity<ContactDonorInfo>()
            //    .HasOne(e => e.DonorReligiousSituation);

            //modelBuilder.Entity<ContactDonorInfo>()
            //    .HasOne(e => e.DonorType);

            //modelBuilder.Entity<ContactDonorInfo>()
            //    .HasMany(e => e.DonorContexts);

            //modelBuilder.Entity<ContactDonorInfo>()
            //    .HasMany(e => e.DonorInterests);
            modelBuilder.Entity<ContactDonorInfo>()
                .Property(e => e.DonorReligiousSituationId);

            modelBuilder.Entity<ContactDonorInfo>()
                .Property(e => e.DonorTypeId);

            modelBuilder.Entity<ContactDonorInfo>()
                .Property(e => e.DonorContexts);

            modelBuilder.Entity<ContactDonorInfo>()
                .Property(e => e.DonorInterests);



            //  ------------------------------------
            //  ContactBloodType for ContactHealthInfo
            //  ------------------------------------
            modelBuilder.Entity<ContactBloodType>()
                .Property(e => e.Description);



            //  ------------------------------------
            //  ContactHealthInfo
            //  ------------------------------------
            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact1Id);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact1Name);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact1RelationshipId);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact2Id);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact2Name);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.EmergencyContact2RelationshipId);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.AllergiesToMedications);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.HealthInsuranceProvider);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.HealthInsurancePolicyNr);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.DetailsToInformEmergencyServices);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.PrescribedMedicationInLast4MonthsAndReasons);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.MedicalConditionsToConsiderInEventOfEmergency);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.RestrictivePhysicalProblems);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.ContactBloodType);
           
        }

        public DbSet<ExceptionLogger>           ExceptionLogger             { get; set; }
        public DbSet<Contact>                   Contact                     { get; set; }

        //  Lookup sets for seed methods
        public DbSet<ContactBloodType>          ContactBloodType            { get; set; }
        public DbSet<DonorType>		            DonorType		            { get; set; }
        public DbSet<DonorReligiousSituation>   DonorReligiousSituation     { get; set; }
        public DbSet<DonorInterest>             DonorInterest               { get; set; }
        public DbSet<DonorContext>	            DonorContext	            { get; set; }
        public DbSet<ContactRelationship>       ContactRelationship         { get; set; }
        public DbSet<SpokenLanguage>            SpokenLanguage              { get; set; }
        public DbSet<Country>                   Country                     { get; set; }

        
        //public DbSet<ContactIdentification>     ContactIdentification   { get; set; }

        //public override int SaveChanges()
        //{
        //    ChangeTracker.DetectChanges();
        //    updateUpdatedProperty<Contact>();

        //    return base.SaveChanges();
        //}

        //private void updateUpdatedProperty<T>() where T : class
        //{
        //    var modifiedSourceInfo =
        //        ChangeTracker.Entries<T>()
        //            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entry in modifiedSourceInfo)
        //    {
        //        entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
        //    }
        //}
    }
}
