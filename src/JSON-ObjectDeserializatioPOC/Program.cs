using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DNXTest.Models;

namespace JSON_ObjectDeserializatioPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string fullobject = @"{
    'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
    'ContactName': null,
    'Prefix': null,
    'FirstName': null,
    'LastName': null,
    'Suffix': null,
    'Gender': null,
    'PositionAndCompany': null,
    'NickName': null,
    'Notes': null,
    'HistoryWithTheCenter': null,
    'FoodAllergies': null,
    'Birthdate': null,
    'LastChangeTimestamp': null,
    'Addresses': [
      
    ],
    'Dates': [
      
    ],
    'Phones': [
      
    ],
    'RelatedContacts': [
      
    ],
    'Emails': [
      
    ],
    'WebSites': [
      
    ],
    'IMs': [
      
    ],
    'InternetCallIds': [
      
    ],
    'ContactIdentification': {
      'IdOrPassport': null,
      'IdOrPassportIssueDate': '0001-01-01T00:00:00',
      'IdOrPassportExpiryDate': '0001-01-01T00:00:00',
      'FiscalId': null,
      'BornInCountry': null,
      'SpokenLanguages': null,
      'PreferredLanguage': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactDharmaExperience': {
      'FollowerOfReligionWhich': null,
      'InterestInFollowingTeachings': null,
      'DescriptionOfBuddhistBackgroundOfAnyTradition': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactEducation': {
      'DetailsOfUniversityPostGraduateOrTechnicalStudies': null,
      'OtherEducationalExperience': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactWorkPreference': {
      'Cooking': 0,
      'Maintenance': 0,
      'Gardening': 0,
      'Cleaning': 0,
      'IT': 0,
      'Office': 0,
      'ArtWorkshop': 0,
      'ExperienceOnWorkAreas': null,
      'WorkAreasExclusionAndReasons': null,
      'ReasonsToOfferVoluntaryWorkToCenter': null,
      'WhenToComeStartDate': '0001-01-01T00:00:00',
      'WhenToComeEndDate': '0001-01-01T00:00:00',
      'HopesExpectationsForStay': null,
      'SkillsAndKnowledgesToDevelopDuringStay': null,
      'HowDidContactFoundTheCenter': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactVolunteeringExperience': {
      'DetailsOfMainWorkAndVolunteerinExperience': null,
      'ContactToAskAboutExperience': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactDonorInfo': {
      'DonorReligiousSituation': null,
      'DonorType': null,
      'DonorContexts': null,
      'DonorInterests': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    },
    'ContactHealthInfo': {
      'EmergencyContact1': null,
      'EmergencyContact2': null,
      'AllergiesToMedications': null,
      'HealthInsuranceProvider': null,
      'HealthInsurancePolicyNr': null,
      'DetailsToInformEmergencyServices': null,
      'PrescribedMedicationInLast4MonthsAndReasons': null,
      'PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years': null,
      'MedicalConditionsToConsiderInEventOfEmergency': null,
      'RestrictivePhysicalProblems': null,
      'ContactBloodType': null,
      'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
      'Contact': null
    }
 }";





            string contactReduced = @"{
  'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
  'ContactName': null,
  'Prefix': null,
  'FirstName': null,
  'LastName': null,
  'Suffix': null,
  'Gender': null,
  'PositionAndCompany': null,
  'NickName': null,
  'Notes': null,
  'HistoryWithTheCenter': null,
  'FoodAllergies': null,
  'Birthdate': null,
  'LastChangeTimestamp': null,
  'Addresses': [
    
  ],
  'Dates': [
    
  ],
  'Phones': [
    
  ],
  'RelatedContacts': [
    
  ],
  'Emails': [
    
  ],
  'WebSites': [
    
  ],
  'IMs': [
    
  ],
  'InternetCallIds': [
    
  ],
  'ContactIdentification': {
    'IdOrPassport': null,
    'IdOrPassportIssueDate': '0001-01-01T00:00:00',
    'IdOrPassportExpiryDate': '0001-01-01T00:00:00',
    'FiscalId': null,
    'BornInCountry': null,
    'SpokenLanguages': null,
    'PreferredLanguage': null,
    'Id': '156fd848-7682-49d7-a6f9-9c63511bb1d6',
    'Contact': null
  },
 }";
            Contact conta = JsonConvert.DeserializeObject<Contact>(contactReduced);

            string resultado = JsonConvert.SerializeObject(conta);

            Console.WriteLine(resultado);

            //ContactEmail contactEmail = new ContactEmail();
            //contactEmail.Description = "Main E-mail";
            //contactEmail.Email = "geral@pedropalacios.net";
            //contactEmail.Id = 1;

            //ContactEmail contactEmail2 = new ContactEmail();
            //contactEmail2.Description = "Secondary E-mail ";
            //contactEmail2.Email = "test@test.com";
            //contactEmail2.Id = 2;

            ////contactEmail.Contact = new Contact();
            ////contactEmail.Contact.InitIds();


            //HashSet<ContactEmail> Emails = new HashSet<ContactEmail>();
            //Emails.Add(contactEmail);
            //Emails.Add(cont               actEmail2);



            //string contactJSON = JsonConvert.SerializeObject(Emails);

            //Console.WriteLine(contactJSON);
            //Console.WriteLine();

            //HashSet<ContactEmail> EmailsDestination = JsonConvert.DeserializeObject<HashSet<ContactEmail>>(contactJSON);
            //string contactJSON2 = JsonConvert.SerializeObject(EmailsDestination);
            //Console.WriteLine(contactJSON2);

            Console.ReadLine();
        }
    }
}
