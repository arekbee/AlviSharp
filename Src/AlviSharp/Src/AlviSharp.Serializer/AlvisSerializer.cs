using System;
using AlviSharp.Lib;

namespace AlviSharp.Serializer
{
	public abstract class AlvisSerializer

	{

		public static Type AlvisProjectType = typeof(AlvisProject);

		public abstract string Serialize(AlvisProject ap);

		public abstract AlvisProject Deserialize(string serializable);

	}
	
}
