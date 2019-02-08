using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.BaseEntities
{

	public class Rule
	{

		public string ClientId { get; set; }
		public string TreatmentId { get; set; }
		public Dictionary<int, string> RankProperty { get; set; }


		public Rule(string clientId, string treatmentId, Dictionary<int, string> rankProperty)
		{
			this.ClientId = clientId;
			this.TreatmentId = treatmentId;
			this.RankProperty = rankProperty;
		}
		public static List<Rule> GetRules()
		{
			List<Rule> rules = new List<Rule>();

			rules.Add(new Rule("7C92FE0E-E51B-4C30-9210-4BE1E839C789", "B5321D3D-2BD7-4C06-BB1A-5175E848014B", new Dictionary<int, string>{
				{ 1, "AvailabilityDateTime" },
				{ 2, "Distance" },
				{ 3, "BidPrice" },
				{ 4, "SubmittedDate" },
			}));
			rules.Add(new Rule("7C92FE0E-E51B-4C30-9210-4BE1E839C789", "B5321D3D-2BD7-4C06-BB1A-5175E848014B-T", new Dictionary<int, string>{
				{ 3, "AvailabilityDateTime" },
				{ 2, "Distance" },
				{ 1, "BidPrice" },
				{ 4, "SubmittedDate" },
			}));

			return rules;
		}

	}



}
