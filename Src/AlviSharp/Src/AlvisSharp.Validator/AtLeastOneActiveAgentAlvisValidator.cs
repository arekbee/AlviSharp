using System;
using AlviSharp.Lib;
using System.Linq;

namespace AlvisSharp.Validator
{

	public class AtLeastOneActiveAgentAlvisValidator : IAlvisValidator

	{

		public string Validate(AlvisProject alvisProject)

		{

			if (!alvisProject.Page.Agents.Any(x => x.Active))

				return "No active agnet";

			return "";

		}

	}
		
}
