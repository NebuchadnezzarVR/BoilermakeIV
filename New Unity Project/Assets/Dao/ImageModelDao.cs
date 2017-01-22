using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Assets.Dao
{
	class ImageModelDao
	{
		private MongoClient _mongoClient;

		private static ImageModelDao _instance;

		public static ImageModelDao Instnace
		{
			get { return _instance ?? (_instance = new ImageModelDao()); }
		}

		private ImageModelDao()
		{
			_mongoClient = new MongoClient("mongodb://neustedter.dlinkddns.com:8080");
		}

		public List<ImageModel> GetImageModels()
		{
			var list = new List<ImageModel>();

			var server = _mongoClient.GetServer();
			var db = server.GetDatabase("Boilermake");
			var collection = db.GetCollection(typeof(BsonDocument), "ImageData");

			var result = collection.FindAs<BsonDocument>(new QueryDocument());
			foreach (var document in result)
			{
				var model = new ImageModel();

				model.Username = document["User"]["UserName"].AsString;
				model.FullName = document["User"]["FullName"].AsString;
				model.TimeTaken = document["TakenAt"].ToUniversalTime();
				model.ImageUrl = document["Images"].AsBsonArray.First().AsString;
				model.Caption = document["Caption"]["Text"].AsString;
				model.Likes = document["Likers"].AsBsonArray.Count;
				model.Comments = int.Parse(document["CommentsCount"].AsString);
				model.TaggedUsers = document["Tags"].AsBsonArray.Select(users => users["User"]["Username"].AsString).ToList();
				model.Likers = document["Likers"].AsBsonArray.Select(likers => likers["Username"].AsString).ToList();

				list.Add(model);
			}

			return list;
		}
	}
}
