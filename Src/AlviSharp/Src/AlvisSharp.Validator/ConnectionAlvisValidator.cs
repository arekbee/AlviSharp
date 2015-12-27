using System;
using AlviSharp.Lib;
using System.Linq;

namespace AlvisSharp.Validator
{

	public class ConnectionAlvisValidator : IAlvisValidator

	{

		public string Validate(AlvisProject alvisProject)

		{

			var connections = alvisProject.Page.Connections;

			if (!connections.Any()) return "no connections";

			if (connections.Count != connections.Select(x => new { x.Source, x.Target }).Distinct().Count())

			{

				return "Duplated connections";

			}
				
			var ports = alvisProject.Page.Agents.SelectMany(x => x.Ports, (agent, port) => new {agent.Name, port});

			if (!ports.Any()) return "No ports";

			if (ports.Count() != ports.Select(x => x.port.Id).Distinct().Count())

			{

				return "Duplicated ports";

			}

			if (connections.Count() * 2 != ports.Count())

			{

				return "Number of port should be 2 times number of connections";

			}

			foreach (var connection in connections)

			{

				var sourcePort = ports.Where(x => x.port.Id == connection.Source);

				var targetPort = ports.Where(x => x.port.Id == connection.Target);

				if (!sourcePort.Any()) return "No source for connection: " + connection;

				if (!targetPort.Any()) return "No target for connection: " + connection;

				if (sourcePort.Count() > 1) return "Find more then one source for connection: " + connection;

				if (targetPort.Count() > 1) return "Find more then one target for connection: " + connection;

				if (sourcePort.First().Name == targetPort.First().Name)

				{

					return "Connection " + connection.ToString() + " is refering to one agent";

				}

				if (targetPort.First().port.Name != sourcePort.First().port.Name)

				{

					return "Source port and target port has got diffrent names for connection " + connections;

				}

			}

			return "";

		}

	}
		
	
}
