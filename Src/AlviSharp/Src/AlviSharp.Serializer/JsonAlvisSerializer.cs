using System;
using AlviSharp.Lib;
using Newtonsoft.Json;


namespace AlviSharp.Serializer
{

	public class JsonAlvisSerializer : AlvisSerializer

	{

		public override string Serialize(AlvisProject ap)

		{

			return JsonConvert.SerializeObject(ap);

		}

		public override AlvisProject Deserialize(string serializable)

		{

			return JsonConvert.DeserializeObject<AlvisProject>(serializable);

		}

	}
}

