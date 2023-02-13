using System.Collections.Generic;
using System.Linq;

namespace CodeLuau
{
    public class Speaker
    {
        private readonly List<string> _preferredEmployers = new List<string> { "Pluralsight", "Microsoft", "Google" };
        private readonly List<string> _ancientEmailDomains = new List<string> { "aol.com", "prodigy.com", "compuserve.com" };
        private readonly List<string> _oldTechnologies = new List<string> { "Cobol", "Punch Cards", "Commodore", "VBScript" };

        private const int YearsExperienceRequired = 11;
        private const int CertificationsRequired = 4;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? YearsExperience { get; set; }
        public bool HasBlog { get; set; }
        public string BlogUrl { get; set; }
        public WebBrowser Browser { get; set; }
        public List<string> Certifications { get; set; }
        public string Employer { get; set; }
        public int RegistrationFee { get; set; }
        public List<Session> Sessions { get; set; }

        public RegisterResponse Register(IRepository repository)
        {
            var registrationError = ValidateRegistration();
            if (registrationError != null) return new RegisterResponse(registrationError);
            RegistrationFee = GetRegistrationFee();
            int? speakerId = repository.SaveSpeaker(this);
            return new RegisterResponse((int)speakerId);
        }
        private RegisterError? ValidateRegistration()
        {
            var dataError = ValidateData();
            if (dataError != null) return dataError;

            var speakerAppearsQualified = AppearsExceptional() || !HasRedFlags();
            if (!speakerAppearsQualified)
            {
                return RegisterError.SpeakerDoesNotMeetStandards;
            }

            var atLeastOneSessionApproved = ApproveSessions();
            if (!atLeastOneSessionApproved)
            {
                return RegisterError.NoSessionsApproved;
            }

            return null;
        }

        /// <returns> True: at least one session is approved</returns>
        private bool ApproveSessions()
        {
            foreach (var session in Sessions)
            {
                session.Approved = !SessionIsAboutOldTechnologies(session);
            }
            return Sessions.Any(s => s.Approved);
        }

        private bool SessionIsAboutOldTechnologies(Session session)
        {
            return _oldTechnologies.Any(oldTechnology =>
                                                        session.Title.Contains(oldTechnology)
                                                        || session.Description.Contains(oldTechnology));
        }

        private bool HasRedFlags()
        {
            var emailDomain = Email.Split('@').Last();
            if (_ancientEmailDomains.Contains(emailDomain)) return true;
            if (Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9) return true;
            return false;

        }

        private bool AppearsExceptional()
        {
            if (YearsExperience >= YearsExperienceRequired) return true;
            if (HasBlog) return true;
            if (Certifications.Count > CertificationsRequired) return true;
            if (_preferredEmployers.Contains(Employer)) return true;
            return false;
        }

        private RegisterError? ValidateData()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return RegisterError.FirstNameRequired;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                return RegisterError.LastNameRequired;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return RegisterError.EmailRequired;
            }

            if (!Sessions.Any())
            {
                return RegisterError.NoSessionsProvided;
            }

            return null;
        }

        private int GetRegistrationFee()
        {
            if (YearsExperience <= 1)
            {
                return 500;
            }
            if (YearsExperience >= 2 && YearsExperience <= 3)
            {
                return 250;
            }
            if (YearsExperience >= 4 && YearsExperience <= 5)
            {
                return 100;
            }
            if (YearsExperience >= 6 && YearsExperience <= 9)
            {
                return 50;
            }
            return 0;
        }
    }
}