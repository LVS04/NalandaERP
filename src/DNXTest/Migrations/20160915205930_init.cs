using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DNXTest.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    FoodAllergies = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    HistoryWithTheCenter = table.Column<string>(nullable: true),
                    LastChangeTimestamp = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PositionAndCompany = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ContactBloodType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactBloodType", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ContactRelationship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRelationship", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "DonorContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorContext", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "DonorInterest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorInterest", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "DonorReligiousSituation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorReligiousSituation", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "DonorType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorType", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ExceptionLogger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ControllerName = table.Column<string>(nullable: true),
                    EmailUser = table.Column<string>(nullable: true),
                    ExceptionMessage = table.Column<string>(nullable: true),
                    ExceptionStackTrace = table.Column<string>(nullable: true),
                    LogTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogger", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "SpokenLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguage", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    City = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    POBOX = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDate_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactDharmaExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DescriptionOfBuddhistBackgroundOfAnyTradition = table.Column<string>(nullable: true),
                    FollowerOfReligionWhich = table.Column<string>(nullable: true),
                    InterestInFollowingTeachings = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDharmaExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDharmaExperience_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactDonorInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DonorContexts = table.Column<string>(nullable: true),
                    DonorInterests = table.Column<string>(nullable: true),
                    DonorReligiousSituationId = table.Column<string>(nullable: true),
                    DonorTypeId = table.Column<string>(nullable: true),
                    LastDonationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDonorInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDonorInfo_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DetailsOfUniversityPostGraduateOrTechnicalStudies = table.Column<string>(nullable: true),
                    OtherEducationalExperience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEducation_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEmail_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactHealthInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AllergiesToMedications = table.Column<string>(nullable: true),
                    ContactBloodType = table.Column<int>(nullable: false),
                    DetailsToInformEmergencyServices = table.Column<string>(nullable: true),
                    EmergencyContact1Id = table.Column<Guid>(nullable: true),
                    EmergencyContact1Name = table.Column<string>(nullable: true),
                    EmergencyContact1RelationshipId = table.Column<int>(nullable: true),
                    EmergencyContact2Id = table.Column<Guid>(nullable: true),
                    EmergencyContact2Name = table.Column<string>(nullable: true),
                    EmergencyContact2RelationshipId = table.Column<int>(nullable: true),
                    HealthInsurancePolicyNr = table.Column<string>(nullable: true),
                    HealthInsuranceProvider = table.Column<string>(nullable: true),
                    MedicalConditionsToConsiderInEventOfEmergency = table.Column<string>(nullable: true),
                    PrescribedMedicationInLast4MonthsAndReasons = table.Column<string>(nullable: true),
                    PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years = table.Column<string>(nullable: true),
                    RestrictivePhysicalProblems = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactHealthInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactHealthInfo_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactIdentification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BornInCountry = table.Column<string>(nullable: true),
                    FiscalId = table.Column<string>(nullable: true),
                    IdOrPassport = table.Column<string>(nullable: true),
                    IdOrPassportExpiryDate = table.Column<DateTime>(nullable: false),
                    IdOrPassportIssueDate = table.Column<DateTime>(nullable: false),
                    PreferredLanguage = table.Column<string>(nullable: true),
                    SpokenLanguages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactIdentification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactIdentification_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactInstantMessaging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    IMContact = table.Column<string>(nullable: true),
                    InstantMessaging = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInstantMessaging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInstantMessaging_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactInternetCall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InternetCallId = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInternetCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInternetCall_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactPhone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhone_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactVolunteeringExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContactToAskAboutExperienceId = table.Column<Guid>(nullable: true),
                    DetailsOfMainWorkAndVolunteerinExperience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactVolunteeringExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactVolunteeringExperience_Contact_ContactToAskAboutExperienceId",
                        column: x => x.ContactToAskAboutExperienceId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactVolunteeringExperience_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactWebsite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactWebsite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactWebsite_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactWorkPreference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArtWorkshop = table.Column<int>(nullable: false),
                    Cleaning = table.Column<int>(nullable: false),
                    Cooking = table.Column<int>(nullable: false),
                    ExperienceOnWorkAreas = table.Column<string>(nullable: true),
                    Gardening = table.Column<int>(nullable: false),
                    HopesExpectationsForStay = table.Column<string>(nullable: true),
                    HowDidContactFoundTheCenter = table.Column<string>(nullable: true),
                    IT = table.Column<int>(nullable: false),
                    Maintenance = table.Column<int>(nullable: false),
                    Office = table.Column<int>(nullable: false),
                    ReasonsToOfferVoluntaryWorkToCenter = table.Column<string>(nullable: true),
                    SkillsAndKnowledgesToDevelopDuringStay = table.Column<string>(nullable: true),
                    WhenToComeEndDate = table.Column<DateTime>(nullable: false),
                    WhenToComeStartDate = table.Column<DateTime>(nullable: false),
                    WorkAreasExclusionAndReasons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactWorkPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactWorkPreference_Contact_Id",
                        column: x => x.Id,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContactRelated",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ContacRelatedtName = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    IdContactRelated = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<int>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRelated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactRelated_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactRelated_ContactRelationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "ContactRelationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactName",
                table: "Contact",
                column: "ContactName");
            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_ContactId_SortOrder",
                table: "ContactAddress",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactDate_ContactId_SortOrder",
                table: "ContactDate",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactEmail_Email",
                table: "ContactEmail",
                column: "Email",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_ContactEmail_ContactId_SortOrder",
                table: "ContactEmail",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactInstantMessaging_ContactId_SortOrder",
                table: "ContactInstantMessaging",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactInternetCall_ContactId_SortOrder",
                table: "ContactInternetCall",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactPhone_ContactId_SortOrder",
                table: "ContactPhone",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactRelated_ContactId_SortOrder",
                table: "ContactRelated",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "IX_ContactWebsite_ContactId_SortOrder",
                table: "ContactWebsite",
                columns: new[] { "ContactId", "SortOrder" });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ContactAddress");
            migrationBuilder.DropTable("ContactBloodType");
            migrationBuilder.DropTable("ContactDate");
            migrationBuilder.DropTable("ContactDharmaExperience");
            migrationBuilder.DropTable("ContactDonorInfo");
            migrationBuilder.DropTable("ContactEducation");
            migrationBuilder.DropTable("ContactEmail");
            migrationBuilder.DropTable("ContactHealthInfo");
            migrationBuilder.DropTable("ContactIdentification");
            migrationBuilder.DropTable("ContactInstantMessaging");
            migrationBuilder.DropTable("ContactInternetCall");
            migrationBuilder.DropTable("ContactPhone");
            migrationBuilder.DropTable("ContactRelated");
            migrationBuilder.DropTable("ContactVolunteeringExperience");
            migrationBuilder.DropTable("ContactWebsite");
            migrationBuilder.DropTable("ContactWorkPreference");
            migrationBuilder.DropTable("Country");
            migrationBuilder.DropTable("DonorContext");
            migrationBuilder.DropTable("DonorInterest");
            migrationBuilder.DropTable("DonorReligiousSituation");
            migrationBuilder.DropTable("DonorType");
            migrationBuilder.DropTable("ExceptionLogger");
            migrationBuilder.DropTable("SpokenLanguage");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("ContactRelationship");
            migrationBuilder.DropTable("Contact");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}
