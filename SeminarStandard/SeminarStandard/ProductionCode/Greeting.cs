using SeminarStandard.ProductionCode;

namespace SeminarStandard
{
	internal class Greeting
	{
		const string hello = "Hello";
		const string coma = ",";
		string result = string.Empty;
		MessageFactory messageFactory = new MessageFactory();

		internal string Greet(string name)
		{
			IFormatedMessage message = messageFactory.GetMessageByName(name);

			if (message == null)
				return $"{hello}, my friend.";
			else
			{
				var names = name.Split(',');
				if (names.Length == 2)
					result = message.GetTwoNamesMessage(names[0], names[1]);
				else if (names.Length > 2)
					result = ProcessMultipleNames(names);
				else
					result = message.GetSingleNameMessage(name);
			}

			return result;
		}

		internal string ProcessMultipleNames(string[] names)
		{
			//TODO: Use string builder.
			//TODO: MAKE UNIT TESTS FOR FACTORY, FORMATED MESSAGE CLASSSES
			IFormatedMessage simpleMessage = new SimpleMessage();
			IFormatedMessage shoutingMessage = new ShoutingMessage();
			IFormatedMessage royalMessage = new RoyalMessage();
			IFormatedMessage blessingMessage = new BlessingMessage();
			
			simpleMessage.SetFilteredNames(names);
			shoutingMessage.SetFilteredNames(names);
			royalMessage.SetFilteredNames(names);
			blessingMessage.SetFilteredNames(names);

			string simpleGreetings = GetNamesGreetingMesage(simpleMessage);
			string shoutingGreetings = GetNamesGreetingMesage(shoutingMessage);
			string royalGreetings = GetNamesGreetingMesage(royalMessage);
			string blessingGreetings = GetNamesGreetingMesage(blessingMessage);

			if (simpleGreetings.Length > 0 && shoutingGreetings.Length > 0 && royalGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + shoutingGreetings + " AND " + royalGreetings + " AND " + blessingGreetings;
			}
			else if (simpleGreetings.Length > 0 && royalGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + royalGreetings + " AND " + blessingGreetings;
			}
			else if (shoutingGreetings.Length > 0 && royalGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = shoutingGreetings + " AND " + royalGreetings + " AND " +blessingGreetings;
			}
			else if (simpleGreetings.Length > 0 && shoutingGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + shoutingGreetings + " AND " +blessingGreetings;
			}
			else if (simpleGreetings.Length > 0 && shoutingGreetings.Length > 0 && royalGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + shoutingGreetings + " AND " + royalGreetings;
			}
			else if (shoutingGreetings.Length > 0 && royalGreetings.Length > 0)
			{
				result = shoutingGreetings + " AND " + royalGreetings;
			}
			else if (shoutingGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = shoutingGreetings + " AND " + blessingGreetings;
			}
			else if (simpleGreetings.Length > 0 && royalGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + royalGreetings;
			}
			else if (simpleGreetings.Length > 0 && blessingGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + blessingGreetings;
			}
			else if (royalGreetings.Length > 0)
			{
				result = royalGreetings;
			}
			else if (blessingGreetings.Length > 0)
			{
				result = blessingGreetings;
			}

			else if (simpleGreetings.Length > 0 && shoutingGreetings.Length > 0)
			{
				result = simpleGreetings + " AND " + shoutingGreetings;
			}
			else if (simpleGreetings.Length > 0)
			{
				result = simpleGreetings;
			}
			else if (shoutingGreetings.Length > 0)
			{
				result = shoutingGreetings;
			}

			return result;
		}

		private string GetNamesGreetingMesage(IFormatedMessage message)
		{
			string res = string.Empty;
			if (message.Names.Length > 0)
			{
				res = message.GetStartMessage(message.Names[0]);

				if (message.Names.Length > 2)
				{
					for (int iCount = 1; iCount < message.Names.Length; iCount++)
					{
						if (iCount != message.Names.Length - 1)
							res = res + coma + " " + message.Names[iCount];
						else
							res = message.GetEndMessage(res, message.Names[iCount]);
					}
				}
				else if (message.Names.Length == 2)
					res = message.GetTwoNamesMessage(message.Names[0], message.Names[1]);
				else
					res = message.GetSingleNameMessage(message.Names[0]);
			}
			return res;
		}
	}
}
