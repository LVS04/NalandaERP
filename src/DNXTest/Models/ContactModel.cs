using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DNXTest.Models
{
    public partial class Contact
    {

        public Contact()
        {
            this.Addresses       = new HashSet<ContactAddress>();
            this.Dates           = new HashSet<ContactDate>();
            this.Phones          = new HashSet<ContactPhone>();
            this.RelatedContacts = new HashSet<ContactRelated>();
            this.Emails          = new HashSet<ContactEmail>();
            this.WebSites        = new HashSet<ContactWebsite>();
            this.IMs             = new HashSet<ContactInstantMessaging>();
            this.InternetCallIds = new HashSet<ContactInternetCall>();

            ContactIdentification           = new ContactIdentification();
            ContactDharmaExperience         = new ContactDharmaExperience();
            ContactEducation                = new ContactEducation();
            ContactWorkPreference           = new ContactWorkPreference();
            ContactVolunteeringExperience   = new ContactVolunteeringExperience();
            ContactDonorInfo                = new ContactDonorInfo();
            ContactHealthInfo               = new ContactHealthInfo();

            this.ContactWorkPreference.WhenToComeStartDate = this.ContactWorkPreference.WhenToComeEndDate = DateTime.MinValue;
            //this.ContactIdentification.IdOrPassportIssueDate = this.ContactIdentification.IdOrPassportExpiryDate = DateTime.MinValue;

        }

        public void InitIds(Guid? id = null)
        {
            
            this.Id = id  ?? Guid.NewGuid();              

            this.ContactIdentification.Id           = this.Id;
            this.ContactDharmaExperience.Id         = this.Id;
            this.ContactEducation.Id                = this.Id;
            this.ContactWorkPreference.Id           = this.Id;
            this.ContactVolunteeringExperience.Id   = this.Id;
            this.ContactDonorInfo.Id                = this.Id;
            this.ContactHealthInfo.Id               = this.Id;

            foreach (var item in this.Addresses)        item.Contact = this;
            foreach (var item in this.Phones)           item.Contact = this;
            foreach (var item in this.RelatedContacts)  item.Contact = this;
            foreach (var item in this.Emails)           item.Contact = this;
            foreach (var item in this.WebSites)         item.Contact = this;
            foreach (var item in this.IMs)              item.Contact = this;
            foreach (var item in this.InternetCallIds)  item.Contact = this;
            
        }

        


        //[Key]
        public Guid         Id                          { get; set; }

        [StringLength(100)]
        public string       ContactName                 { get; set; } // sum of all contacts fields

        [StringLength(50)]
        public string       Prefix                      { get; set; }

        [StringLength(50)]
        public string       FirstName                   { get; set; }

        [StringLength(50)]
        public string       LastName                    { get; set; }

        [StringLength(50)]
        public string       Suffix                      { get; set; }

        [StringLength(10)]
        public string       Gender                      { get; set; } // TODO: pass to select - Male / Female

        [StringLength(50)]
        public string       PositionAndCompany          { get; set; }

        [StringLength(50)]
        public string       NickName                    { get; set; }

        public string       Notes                       { get; set; }

        public string       HistoryWithTheCenter        { get; set; }

        [StringLength(100)]
        public string       FoodAllergies               { get; set; }


        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DataType(DataType.DateTime)]
        public Nullable<DateTime>     Birthdate                   { get; set; }

        public Nullable<DateTime>     LastChangeTimestamp         { get; set; } // TODO: UPDATE at each write


        public ICollection<ContactAddress>              Addresses               { get; set; }
        public ICollection<ContactDate>                 Dates                   { get; set; }
        public ICollection<ContactPhone>                Phones                  { get; set; }
        public ICollection<ContactRelated>              RelatedContacts         { get; set; }
        public ICollection<ContactEmail>                Emails                  { get; set; }
        public ICollection<ContactWebsite>              WebSites                { get; set; }
        public ICollection<ContactInstantMessaging>     IMs                     { get; set; }
        public ICollection<ContactInternetCall>         InternetCallIds         { get; set; }

        public ContactIdentification            ContactIdentification           { get; set; }
        public ContactDharmaExperience          ContactDharmaExperience         { get; set; }
        public ContactEducation                 ContactEducation                { get; set; }
        public ContactWorkPreference            ContactWorkPreference           { get; set; }
        public ContactVolunteeringExperience    ContactVolunteeringExperience   { get; set; }
        public ContactDonorInfo                 ContactDonorInfo                { get; set; }
        public ContactHealthInfo                ContactHealthInfo               { get; set; }
  
    }

    public partial class ContactDate
    {
        //[Key]
        public int      Id                  { get; set; }

        public int      SortOrder           { get; set; }

        public DateTime Date                { get; set; }
        public string   Description         { get; set; }

        public Contact  Contact             { get; set; }

    }
    
        public partial class ContactEmail
        {
            //[Key]
            public int      Id          { get; set; }

            public int      SortOrder   { get; set; }

            [StringLength(100)]
            public string   Email       { get; set; }

            [StringLength(100)]
            public string   Description { get; set; }

            public Contact  Contact     { get; set; }
        }
    
        public partial class ContactPhone
        {
            //[Key]
            public int Id               { get; set; }

            public int SortOrder        { get; set; }

            [StringLength(10)]
            public string   CountryCode { get; set; }

            [StringLength(30)]
            public string   Number      { get; set; }

            [StringLength(100)]
            public string   Description { get; set; }

            public Contact  Contact     { get; set; }
        }

        public partial class ContactAddress
        {
            //[Key]
            public int Id                   { get; set; }

            public int SortOrder            { get; set; }

            [StringLength(100)]
            public string   Street          { get; set; }

            [StringLength(100)]
            public string   POBOX           { get; set; }

            [StringLength(100)]
            public string   Neighborhood    { get; set; }

            [StringLength(100)]
            public string   City            { get; set; }

            [StringLength(100)]
            public string   Province        { get; set; }

            [StringLength(100)]
            public string   PostalCode      { get; set; }

            [StringLength(100)]
            public string  Country          { get; set; }

            public Contact  Contact         { get; set; }
        
        }

        public partial class Country
        {
            public Country()
            {
                Description = string.Empty;
            }

            //[Key]
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class ContactRelationship
        {
            //[Key]
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class ContactRelated
        {
            //[Key]
            public int Id { get; set; }

            public int                  SortOrder           { get; set; }
            public Guid                 IdContactRelated    { get; set; }
            public string               ContacRelatedtName  { get; set; }
            public ContactRelationship  Relationship        { get; set; }

            public Contact              Contact             { get; set; }
        }   
    
        public partial class ContactWebsite
        {
            //[Key]
            public int      Id               { get; set; }
            public int      SortOrder        { get; set; }

            [StringLength(100)]
            public string   WebSite         { get; set; }

            [StringLength(100)]
            public string   Description     { get; set; }

            public Contact  Contact         { get; set; }
        }


        public partial class ContactInstantMessaging
        {
            //[Key]
            public int Id { get; set; }

            public int      SortOrder           { get; set; }
            [StringLength(100)]
            public string   InstantMessaging    { get; set; }

            [StringLength(100)]
            public string   IMContact           { get; set; }

            public Contact  Contact             { get; set; }
        }

        public partial class ContactInternetCall
        {
            //[Key]
            public int Id { get; set; }

            public int      SortOrder           { get; set; }

            [StringLength(100)]
            public string   InternetCallId      { get; set; }

            [StringLength(100)]
            public string   Description         { get; set; }

            public Contact  Contact             { get; set; }
        }

    

        //  ----------------------------------------------------------------------------------------------------------------------------
        //  Volunteer context
        //  ----------------------------------------------------------------------------------------------------------------------------
        public partial class ContactIdentification
        {

            public ContactIdentification()
            {
                this.IdOrPassportIssueDate  = this.IdOrPassportExpiryDate = DateTime.MinValue;
                this.BornInCountry          = string.Empty;
                this.SpokenLanguages = string.Empty;
            }


            [StringLength(100)]
            public          string   IdOrPassport                           { get; set; } 
            public          DateTime IdOrPassportIssueDate                  { get; set; }
            public          DateTime IdOrPassportExpiryDate                 { get; set; }

            [StringLength(100)]
            public          string   FiscalId                               { get; set; }
            public          string   BornInCountry                          { get; set; }

            public          string   SpokenLanguages                        { get; set; }
            public string   PreferredLanguage                               { get; set; }
           
            public Guid      Id                                             { get; set; }
            public virtual  Contact  Contact                                { get; set; }

        }
    
        public partial class SpokenLanguage
        {
            //[Key]
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }
    
        public partial class ContactDharmaExperience
        {
            
            public string   FollowerOfReligionWhich                         { get; set; }
            public string   InterestInFollowingTeachings                    { get; set; }
            public string   DescriptionOfBuddhistBackgroundOfAnyTradition   { get; set; }

            public Guid              Id                                     { get; set; }
            public virtual  Contact  Contact                                { get; set; }
        }



        //  ----------------------------------------------------------------------------------------------------------------------------
        //  Volunteer context
        //  ----------------------------------------------------------------------------------------------------------------------------
        public partial class ContactEducation
        {

            public string DetailsOfUniversityPostGraduateOrTechnicalStudies { get; set; }
            public string OtherEducationalExperience                        { get; set; }

            public Guid              Id                                     { get; set; }
            public virtual  Contact  Contact                                { get; set; }
            
        }

        public partial class ContactWorkPreference
        {

            public int  Cooking         { get; set; }
            public int  Maintenance     { get; set; }
            public int  Gardening       { get; set; }
            public int  Cleaning        { get; set; }
            public int  IT              { get; set; }
            public int  Office          { get; set; }
            public int  ArtWorkshop     { get; set; }

            public string ExperienceOnWorkAreas                     { get; set; }
            public string WorkAreasExclusionAndReasons              { get; set; }
            public string ReasonsToOfferVoluntaryWorkToCenter       { get; set; }

            public DateTime WhenToComeStartDate                     { get; set; }
            public DateTime WhenToComeEndDate                       { get; set; }

            public string HopesExpectationsForStay                  { get; set; }
            public string SkillsAndKnowledgesToDevelopDuringStay    { get; set; }
            public string HowDidContactFoundTheCenter               { get; set; }

            public Guid              Id                                     { get; set; }
            public virtual  Contact  Contact                                { get; set; }
        }

        public partial class ContactVolunteeringExperience
        {

            public string   DetailsOfMainWorkAndVolunteerinExperience   { get; set; }
            public Contact  ContactToAskAboutExperience                 { get; set; }

            public Guid              Id                                     { get; set; }
            public virtual  Contact  Contact                                { get; set; }
        }



        //  ----------------------------------------------------------------------------------------------------------------------------
        //  Donor context
        //  ----------------------------------------------------------------------------------------------------------------------------
        public partial class ContactDonorInfo
        {
            public ContactDonorInfo()
            {
                DonorReligiousSituationId   = string.Empty;
                DonorTypeId                 = string.Empty;
                DonorContexts               = string.Empty;           
                DonorInterests              = string.Empty;          
            }
            public string       DonorReligiousSituationId                                       { get; set; }
            public string       DonorTypeId                                                     { get; set; }
            public string       DonorContexts                                                   { get; set; }
            public string       DonorInterests                                                  { get; set; }
            public DateTime?    LastDonationDate                                                { get; set; }

            public Guid              Id                                                         { get; set; }
            public virtual  Contact  Contact                                                    { get; set; }
        }

        public partial class DonorContext //is a bp student, was a bp student, is a volunteer, was a volunteer, 
        {
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class DonorInterest //Studies, which studies, Retreats, which retreats, rituals Which rituals, workshops, which workshops, teaching events - which
        {
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class DonorReligiousSituation //laymen, ordained, different levels of ordination, disrobed etc...
        {
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class DonorType //Small, big, grand sponsor, friend of Nalanda
        {
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }



        //  ----------------------------------------------------------------------------------------------------------------------------
        //  Health context - Student, Retreatant, Volunteer
        //  ----------------------------------------------------------------------------------------------------------------------------
        public partial class ContactBloodType
        {
            public int Id { get; set; }

            [StringLength(100)]
            public string Description { get; set; }
        }

        public partial class ContactHealthInfo
        {

            public Guid?                EmergencyContact1Id                                         { get; set; }
            public string               EmergencyContact1Name                                       { get; set; }
            public int?                 EmergencyContact1RelationshipId                             { get; set; }

            public Guid?                EmergencyContact2Id                                         { get; set; }
            public string               EmergencyContact2Name                                       { get; set; }
            public int?                 EmergencyContact2RelationshipId                             { get; set; }

            [StringLength(100)]
            public string               AllergiesToMedications                                      { get; set; }

            [StringLength(100)]
            public string               HealthInsuranceProvider                                     { get; set; }

            [StringLength(100)]
            public string   HealthInsurancePolicyNr                                                 { get; set; }
            public string   DetailsToInformEmergencyServices                                        { get; set; }
            public string   PrescribedMedicationInLast4MonthsAndReasons                             { get; set; }
            public string   PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years        { get; set; }
            public string   MedicalConditionsToConsiderInEventOfEmergency                           { get; set; }
            public string   RestrictivePhysicalProblems                                             { get; set; }
            public int      ContactBloodType                                                        { get; set; } 

            public Guid              Id                                                             { get; set; }
            public Contact           Contact                                                        { get; set; }
        }
}
