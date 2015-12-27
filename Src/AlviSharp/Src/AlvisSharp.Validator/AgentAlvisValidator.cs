using System;
using AlviSharp.Lib;
using System.Linq;

namespace AlvisSharp.Validator
{

	public class AgentAlvisValidator : IAlvisValidator

	{

		public string Validate(AlvisProject alvisProject)

		{

			if (alvisProject.Page.Agents.Any(x => x.Height <= 0 || x.Width <= 0 || x.X <= 0 || x.Y <= 0))

			{

				return "Wrong size or location for one of agents";

			}

			var agentNames = alvisProject.Page.Agents.Select(x => x.Name);

			if (agentNames.Any(x => string.IsNullOrWhiteSpace(x)))

			{

				return "One agent has empty name";

			}

			if (agentNames.Count() != agentNames.Select(x=>x.Trim().ToUpper()).Distinct().Count())

			{

				return "At least 2 agent have got same name";

			}
				

			return "";

		}

	}
		
	
}
