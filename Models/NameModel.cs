using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NamesAndTablesApi.Models
{
	public class NameModel
	{
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement]
		public string Name { get; set; } = string.Empty;

		[BsonElement] 
		public bool IsFirstName { get; set; } = true;
		

	}
}
