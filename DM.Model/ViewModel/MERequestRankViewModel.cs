using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
	public class PatientAppointmentDate
	{
        public Guid Id { get; set; }
        public Guid ReferralTreatmentServiceMapId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan ScheduleFromTime { get; set; }
        public TimeSpan ScheduleToTime { get; set; }
    }

	public class Provider
	{
        public Guid ReferralTreamtnServiceProviderMapId { get; set; }
        public string ProviderId { get; set; }
		public DateTime AvailabilityDateTime { get; set; }
		public double Distance { get; set; }
		public double BidPrice { get; set; }
		public DateTime SubmittedDate { get; set; }
		public int? Ranking { get; set; }
	}


	public class RequestObject
	{
		public string ReferralId { get; set; }
		public string ReferralTreatmetnServiceMapId { get; set; }
		public string ClientId { get; set; }
		public string TreatmentId { get; set; }
		public string ServiceId { get; set; }
		public List<PatientAppointmentDate> PatientAppointmentDates { get; set; }
		public List<Provider> Providers { get; set; }

	}
}
