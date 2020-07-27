using SeminarStandard.ProductionCode;

namespace SeminarStandard
{
	internal class MessageFactory
	{
		public IFormatedMessage GetMessageByName(string name)
		{
			
			if (!string.IsNullOrEmpty(name))
			{
				if ((name.Contains("King") || name.Contains("Queen") || name.Contains("Prince") || name.Contains("Princess")))
					return new RoyalMessage();
				else if (name.Contains("Blessing"))
					return new BlessingMessage();
				else if (name != name.ToUpper() && !(name.Contains("King") || name.Contains("Queen") || name.Contains("Prince") || name.Contains("Princess") || name.Contains("Blessing")))
					return new SimpleMessage();
				else if (name == name.ToUpper() && !(name.Contains("King") || name.Contains("Queen") || name.Contains("Prince") || name.Contains("Princess") || name.Contains("Blessing")))
					return new ShoutingMessage();
				

				//ADD Royal Message detected by containing: "Prince or Princess, King, Queen" ( DONE )
			}
			return null;
		}
	}
}
