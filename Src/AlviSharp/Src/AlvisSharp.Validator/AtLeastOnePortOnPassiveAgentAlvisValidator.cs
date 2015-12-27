using System;
using AlviSharp.Lib;
using System.Linq;


namespace AlvisSharp.Validator
{
	public class AtLeastOnePortOnPassiveAgentAlvisValidator : IAlvisValidator
	{
		#region IAlvisValidator implementation

		public string Validate (AlvisProject alvisProject)
		{
			var passiveAgents = alvisProject.Page.Agents.Where(x=>!x.Active);
			var passiveAgentsWithNoPorts = passiveAgents.Where (x => !x.Ports.Any ());
			if (passiveAgentsWithNoPorts.Any()) {
				var agent = passiveAgentsWithNoPorts.First();
				return string.Format("Passive agent {0} has no port", agent.Name);
			}

			return "";
		}

		#endregion
	}
}

