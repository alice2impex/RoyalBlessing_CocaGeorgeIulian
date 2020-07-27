using System.Linq;

namespace SeminarStandard.ProductionCode
{
	public class RoyalMessage : IFormatedMessage
	{
		const string hello = "Greetings";
		const string and = "&";
		const string separator = ", Your Majesty";

		public string[] Names { get; set; }

		public string GetStartMessage(string name)
		{
			return $"{hello}{separator} {name}";
		}

		public string GetEndMessage(string res, string name)
		{
			return $"{res} {and} {name}.";
		}

		public string GetTwoNamesMessage(string name1, string name2)
		{
			return $"{hello}{separator} {name1} {and} {name2}.";
		}

		public void SetFilteredNames(string[] names)
		{
			//Royalitycheck
			Names = names.Where(name => (name.Contains("King") || name.Contains("Queen") || name.Contains("Prince") || name.Contains("Princess"))).ToArray();
		}

		public string GetSingleNameMessage(string name)
		{
			return $"{hello}, {name}.";
		}
	}
}
