using System;
using System.IO;
using Microsoft.FSharp.Collections;
using System.Collections.Generic;

using System.Linq;
using AlviSharp.Lib;
using AlviSharp.Serializer;


namespace AlviSharp.Lts
{
	public interface IEdge{}
	public interface IVertex{}

	public enum AgentMode {ActiveFinished, ActiveRunning, ActiveInit, ActiveWaiting, PassiveWaiting, PassiveTakken}

	public struct AgentInstruction : IEdge
	{
		public string Command;
		public string AgentLeter;
		public override string ToString ()
		{
			return AgentLeter+": " +Command ;
		}
	}

	public class SingleAgentState 
	{

		public bool IsActive;
		public string AgentName;
		public string AgentNameLetter{get{ return AgentName [0].ToString (); }}

		public AgentMode mode;
		public long Counter { get; set;} = 0; 

		public object Context;


		public override string ToString ()
		{
			return string.Format ("{0}( {1}, {2}, {3} )", AgentNameLetter,  GetModeLeter(),  Counter, Context ?? "[]");
		}
	
		public string GetModeLeter()
		{
			if (IsActive) {
				if (mode == AgentMode.ActiveRunning)
					return "X";
			} else {
				if (mode == AgentMode.PassiveTakken)
					return "T";
			}
			return "W";
		}


		public override int GetHashCode ()
		{
			return GetModeLeter ().GetHashCode () + AgentNameLetter.GetHashCode ();
		}

	}

	public class CollectionAgentState
	{
		public IEnumerable<SingleAgentState> agentStates;

		public AlvisProject  project;



		public IDictionary<CollectionAgentState, AgentInstruction> NextSteps()
		{


			return null;

		}

	}



	public class CollectionAgentStateMove
	{
		public CollectionAgentState From;
		public CollectionAgentState To;
		public AgentInstruction On;

	}

	public static class  FSharpListExtensions
	{
		public static IEnumerable<T> ToEnumerable<T>(this  FSharpList<T> fSharpList)
		{
			foreach (var item in fSharpList) {
				yield return item;
			}
		}


	}

	public class LtsGenerator
	{

		public CollectionAgentState InitAgentsStates(List<AlvisSpec.AlvisStatement> agents,  AlvisProject  project)
		{
			List<SingleAgentState> states = new List<SingleAgentState> ();

			foreach (var item in agents) {
				foreach (var agentName in item.AgentList.ToEnumerable ()) {
					bool isActive = project.Page.Agents.First (x => x.Name == agentName).Active;



					states.Add(new SingleAgentState { AgentName = agentName, IsActive = isActive});
				}
			}
			return new CollectionAgentState{ agentStates = states, project = project};
		}


		public List<CollectionAgentStateMove> Generate(AlvisProject project)
		{
			var parsed = AlviSharp.Parser.Program.ParseAlvis(project.Code);
			var agents = parsed.ToList ();
			var initAgentStates = InitAgentsStates (agents,project);

			var moves = new List<CollectionAgentStateMove> ();

			Queue<CollectionAgentState> toAnalize = new Queue<CollectionAgentState>();
			toAnalize.Enqueue (initAgentStates);

			while (toAnalize.Peek () != null) {
				var from = toAnalize.Dequeue ();
				var tos=  from.NextSteps ();
				foreach (var t in tos.Keys) {
					var instruction = tos [t];

					if(!moves.Any (x=>x.To == t && x.On.Command == instruction.Command))
					{
						toAnalize.Enqueue (t);
						moves.Add (new CollectionAgentStateMove{ From = from, To = t, On = instruction });
					}
				}
			}
			return moves;
		}






		public static int Main (string[] args)
		{
			string filePath = "sender_buffer_receiver.alvis";
			var content = File.ReadAllText(filePath);


			AlvisSerializer serializer = new XmlAlvisSerializer ();
			var alvisProject = serializer.Deserialize (content);

			LtsGenerator lts = new LtsGenerator ();
			var moves = lts.Generate (alvisProject);


			return 0;
		}

	}
}

