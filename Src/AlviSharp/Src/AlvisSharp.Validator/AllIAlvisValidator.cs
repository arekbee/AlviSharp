using System;
using System.Collections.Generic;

namespace AlvisSharp.Validator
{
	public class AllIAlvisValidator :IAlvisValidator
	{
		private readonly List<IAlvisValidator>  Validators;

		public AllIAlvisValidator ()
		{
			Validators = new List<IAlvisValidator> {

				new AtLeastOneActiveAgentAlvisValidator (),
				new AtLeastOnePortOnPassiveAgentAlvisValidator(),

				new AgentAlvisValidator (),

				new ConnectionAlvisValidator (),

				new CodeAlvisValidator ()
			};
		}

		#region IAlvisValidator implementation

		public string Validate (AlviSharp.Lib.AlvisProject alvisProject)
		{

			bool notvalid = false;
			foreach (var validator in Validators)
			{
				string errorMessage = validator.Validate(alvisProject);
				if (!String.IsNullOrWhiteSpace(errorMessage))
				{
					return errorMessage;
				}
			}
			return "";
		}

		#endregion

	}
}

