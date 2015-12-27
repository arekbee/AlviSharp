using System;
using AlviSharp.Lib;
using System.Collections.Generic;

namespace AlvisSharp.Validator
{


	public class CodeAlvisValidator : IAlvisValidator

	{

		public IEnumerable<IAlvisCodeValidator> AlvisCodeValidators = null;


		public CodeAlvisValidator(IEnumerable<IAlvisCodeValidator> codevalidators =null )

		{

			AlvisCodeValidators = codevalidators;

		}
			

		public string Validate(AlvisProject alvisProject)

		{

			if (string.IsNullOrWhiteSpace(alvisProject.Code))

			{

				return "No code in alvis specification";

			}

			if (!alvisProject.Code.ToUpper().Contains("AGENT"))

			{

				return "No agent definition in code";

			}

			if (AlvisCodeValidators != null)

			{

				foreach (var alvisCodeValidator in AlvisCodeValidators)

				{

					string errorMsg = alvisCodeValidator.Validate(alvisProject.Code);

					if (!string.IsNullOrWhiteSpace(errorMsg))

					{

						return errorMsg;

					}

				}

			}
				

			return "";

		}

	}
}

