using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class ProviderRankingViewModel
    {
        public Guid ReferralId { get; set; }
        public Guid ReferralTreatmetnServiceMapId { get; set; }
        public Guid ClientId { get; set; }
        public Guid TreatmentId { get; set; }
        public Guid ServiceId { get; set; }
        public Address PatientAddress { get; set; }
        public List<AppointmentViewModel> PatientAppointments { get; set; }
        public List<ProviderViewModel> Providers { get; set; }
    }
    public class ProviderViewModel
    {
        public Guid ReferralTreamtnServiceProviderMapId { get; set; }
        public Guid ProviderId { get; set; }
        public DateTime? AvailabilityDateTime { get; set; }
        public Decimal? BidPrice { get; set; }
        public DateTime SubmittedDate { get; set; }
        public decimal? Distance { get; set; }
        public int? Ranking { get; set; }

    }
    public class ProviderRanking
    {
        public Guid ReferralTreamtnServiceProviderMapId { get; set; }
        public int Ranking { get; set; }
    }
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public Guid StateId { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string ZipCodeExtension { get; set; }
        public Guid AddressTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public Guid ReferralTreatmentServiceMapId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan ScheduleFromTime { get; set; }
        public TimeSpan ScheduleToTime { get; set; }


    }
}
