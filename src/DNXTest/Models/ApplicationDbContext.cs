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

            modelBuilder.Entity<Contact>().Property<DateTime>("UpdatedTimestamp");

            modelBuilder.Entity<Contact>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactName);
                //;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Prefix)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.FirstName)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LastName)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Suffix)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Gender)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.PositionAndCompany)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.NickName)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Notes)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.HistoryWithTheCenter)
                ;//.IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.FoodAllergies)
                ;//.IsUnicode(false);

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



            //  ------------------------------------
            //  ContactEmail
            //  ------------------------------------
            modelBuilder.Entity<ContactEmail>()
                .Property(e => e.Email)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactEmail>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactPhone
            //  ------------------------------------
            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.CountryCode)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.Number)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactPhone>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactAddress
            //  ------------------------------------
            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Street)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.POBOX)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Neighborhood)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.City)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.Province)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .Property(e => e.PostalCode)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactAddress>()
                .HasOne(e => e.Country);//.HasRequired(e => e.Country);



            //  ------------------------------------
            //  Country for address TODO: improve later
            //  ------------------------------------
            modelBuilder.Entity<Country>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactRelationship for ContactRelated
            //  ------------------------------------
            modelBuilder.Entity<ContactRelationship>()
                    .Property(e => e.Description)
                    ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactRelated
            //  ------------------------------------
            modelBuilder.Entity<ContactRelated>()
                 .HasOne(e => e.RelatedContact);

            modelBuilder.Entity<ContactRelated>()
                .HasOne(e => e.Relationship);



            //  ------------------------------------
            //  ContactWebsite
            //  ------------------------------------
            modelBuilder.Entity<ContactWebsite>()
                .Property(e => e.WebSite)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWebsite>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactInstantMessaging
            //  ------------------------------------
            modelBuilder.Entity<ContactInstantMessaging>()
                .Property(e => e.InstantMessaging)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactInstantMessaging>()
                .Property(e => e.IMContact)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactInternetCall
            //  ------------------------------------
            modelBuilder.Entity<ContactInternetCall>()
                .Property(e => e.InternetCallId)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactInternetCall>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  SpokenLanguage for ContactIdentification
            //  ------------------------------------
            modelBuilder.Entity<SpokenLanguage>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactIdentification
            //  ------------------------------------
            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassport)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassportIssueDate);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.IdOrPassportExpiryDate);

            modelBuilder.Entity<ContactIdentification>()
                .Property(e => e.FiscalId)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactIdentification>()
                .HasOne(e => e.BornInCountry);//.HasRequired(e => e.BornInCountry);

            modelBuilder.Entity<ContactIdentification>()
                .HasMany(e => e.SpokenLanguages);

            modelBuilder.Entity<ContactIdentification>()
                .HasOne(e => e.PreferredLanguage);



            //  ------------------------------------
            //  ContactDharmaExperience
            //  ------------------------------------
            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.FollowerOfReligionWhich)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.InterestInFollowingTeachings)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactDharmaExperience>()
                .Property(e => e.DescriptionOfBuddhistBackgroundOfAnyTradition)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactEducation
            //  ------------------------------------
            modelBuilder.Entity<ContactEducation>()
                .Property(e => e.DetailsOfUniversityPostGraduateOrTechnicalStudies)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactEducation>()
                .Property(e => e.OtherEducationalExperience)
                ;//.IsUnicode(true);



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
                .Property(e => e.ExperienceOnWorkAreas)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WorkAreasExclusionAndReasons)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.ReasonsToOfferVoluntaryWorkToCenter)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WhenToComeStartDate);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.WhenToComeEndDate);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.HopesExpectationsForStay)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.SkillsAndKnowledgesToDevelopDuringStay)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactWorkPreference>()
                .Property(e => e.HowDidContactFoundTheCenter)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactVolunteeringExperience
            //  ------------------------------------
            modelBuilder.Entity<ContactVolunteeringExperience>()
                .Property(e => e.DetailsOfMainWorkAndVolunteerinExperience)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactVolunteeringExperience>()
                .HasOne(e => e.ContactToAskAboutExperience);//.HasRequired(e => e.ContactToAskAboutExperience);



            //  ------------------------------------
            //  DonorContext for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorContext>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  DonorInterest for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorInterest>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  DonorReligiousSituation for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorReligiousSituation>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  DonorType for ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<DonorType>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactDonorInfo
            //  ------------------------------------
            modelBuilder.Entity<ContactDonorInfo>()
                .HasOne(e => e.DonorReligiousSituation);// HasRequired(e => e.DonorReligiousSituation);

            modelBuilder.Entity<ContactDonorInfo>()
                .HasOne(e => e.DonorType);//.HasRequired(e => e.DonorType);

            modelBuilder.Entity<ContactDonorInfo>()
                .HasMany(e => e.DonorContexts);

            modelBuilder.Entity<ContactDonorInfo>()
                .HasMany(e => e.DonorInterests);



            //  ------------------------------------
            //  ContactBloodType for ContactHealthInfo
            //  ------------------------------------
            modelBuilder.Entity<ContactBloodType>()
                .Property(e => e.Description)
                ;//.IsUnicode(true);



            //  ------------------------------------
            //  ContactHealthInfo
            //  ------------------------------------
            modelBuilder.Entity<ContactHealthInfo>()
                .HasOne(e => e.EmergencyContact1);//.HasRequired(e => e.EmergencyContact1);

            modelBuilder.Entity<ContactHealthInfo>()
                .HasOne(e => e.EmergencyContact2);
            //.HasRequired(e => e.EmergencyContact2);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.AllergiesToMedications)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.HealthInsuranceProvider)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.HealthInsurancePolicyNr)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.DetailsToInformEmergencyServices)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.PrescribedMedicationInLast4MonthsAndReasons)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.MedicalConditionsToConsiderInEventOfEmergency)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .Property(e => e.RestrictivePhysicalProblems)
                ;//.IsUnicode(true);

            modelBuilder.Entity<ContactHealthInfo>()
                .HasOne(e => e.ContactBloodType);//.HasOptional(e => e.ContactBloodType);
           
        }

        public DbSet<Contact>                   Contact                 { get; set; }
        public DbSet<ContactIdentification>     ContactIdentification   { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            updateUpdatedProperty<Contact>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
