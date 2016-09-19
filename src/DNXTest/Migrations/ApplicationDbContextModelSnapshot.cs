using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DNXTest.Models;

namespace DNXTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("DNXTest.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("DNXTest.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthdate");

                    b.Property<string>("ContactName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FoodAllergies")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Gender")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("HistoryWithTheCenter");

                    b.Property<DateTime?>("LastChangeTimestamp");

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("NickName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Notes");

                    b.Property<string>("PositionAndCompany")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Prefix")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Suffix")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("ContactName");
                });

            modelBuilder.Entity("DNXTest.Models.ContactAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("ContactId");

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Neighborhood")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("POBOX")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Province")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("SortOrder");

                    b.Property<string>("Street")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactBloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDharmaExperience", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("DescriptionOfBuddhistBackgroundOfAnyTradition");

                    b.Property<string>("FollowerOfReligionWhich");

                    b.Property<string>("InterestInFollowingTeachings");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDonorInfo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("DonorContexts");

                    b.Property<string>("DonorInterests");

                    b.Property<string>("DonorReligiousSituationId");

                    b.Property<string>("DonorTypeId");

                    b.Property<DateTime?>("LastDonationDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactEducation", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("DetailsOfUniversityPostGraduateOrTechnicalStudies");

                    b.Property<string>("OtherEducationalExperience");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactHealthInfo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("AllergiesToMedications")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("ContactBloodType");

                    b.Property<string>("DetailsToInformEmergencyServices");

                    b.Property<Guid?>("EmergencyContact1Id");

                    b.Property<string>("EmergencyContact1Name");

                    b.Property<int?>("EmergencyContact1RelationshipId");

                    b.Property<Guid?>("EmergencyContact2Id");

                    b.Property<string>("EmergencyContact2Name");

                    b.Property<int?>("EmergencyContact2RelationshipId");

                    b.Property<string>("HealthInsurancePolicyNr")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("HealthInsuranceProvider")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("MedicalConditionsToConsiderInEventOfEmergency");

                    b.Property<string>("PrescribedMedicationInLast4MonthsAndReasons");

                    b.Property<string>("PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years");

                    b.Property<string>("RestrictivePhysicalProblems");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactIdentification", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("BornInCountry");

                    b.Property<string>("FiscalId")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("IdOrPassport")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime>("IdOrPassportExpiryDate");

                    b.Property<DateTime>("IdOrPassportIssueDate");

                    b.Property<string>("PreferredLanguage");

                    b.Property<string>("SpokenLanguages");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactInstantMessaging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<string>("IMContact")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("InstantMessaging")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactInternetCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("InternetCallId")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<string>("CountryCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Number")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactRelated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContacRelatedtName");

                    b.Property<Guid>("ContactId");

                    b.Property<Guid>("IdContactRelated");

                    b.Property<int?>("RelationshipId");

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactVolunteeringExperience", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid?>("ContactToAskAboutExperienceId");

                    b.Property<string>("DetailsOfMainWorkAndVolunteerinExperience");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactWebsite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("SortOrder");

                    b.Property<string>("WebSite")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("ContactId", "SortOrder");
                });

            modelBuilder.Entity("DNXTest.Models.ContactWorkPreference", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("ArtWorkshop");

                    b.Property<int>("Cleaning");

                    b.Property<int>("Cooking");

                    b.Property<string>("ExperienceOnWorkAreas");

                    b.Property<int>("Gardening");

                    b.Property<string>("HopesExpectationsForStay");

                    b.Property<string>("HowDidContactFoundTheCenter");

                    b.Property<int>("IT");

                    b.Property<int>("Maintenance");

                    b.Property<int>("Office");

                    b.Property<string>("ReasonsToOfferVoluntaryWorkToCenter");

                    b.Property<string>("SkillsAndKnowledgesToDevelopDuringStay");

                    b.Property<DateTime>("WhenToComeEndDate");

                    b.Property<DateTime>("WhenToComeStartDate");

                    b.Property<string>("WorkAreasExclusionAndReasons");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.DonorContext", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.DonorInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.DonorReligiousSituation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.DonorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.ExceptionLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ControllerName");

                    b.Property<string>("EmailUser");

                    b.Property<string>("ExceptionMessage");

                    b.Property<string>("ExceptionStackTrace");

                    b.Property<DateTime>("LogTime");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DNXTest.Models.SpokenLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("DNXTest.Models.ContactAddress", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDate", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDharmaExperience", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactDharmaExperience", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactDonorInfo", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactDonorInfo", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactEducation", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactEducation", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactEmail", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactHealthInfo", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactHealthInfo", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactIdentification", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactIdentification", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactInstantMessaging", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactInternetCall", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactPhone", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactRelated", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("DNXTest.Models.ContactRelationship")
                        .WithMany()
                        .HasForeignKey("RelationshipId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactVolunteeringExperience", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactToAskAboutExperienceId");

                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactVolunteeringExperience", "Id");
                });

            modelBuilder.Entity("DNXTest.Models.ContactWebsite", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DNXTest.Models.ContactWorkPreference", b =>
                {
                    b.HasOne("DNXTest.Models.Contact")
                        .WithOne()
                        .HasForeignKey("DNXTest.Models.ContactWorkPreference", "Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DNXTest.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DNXTest.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("DNXTest.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
