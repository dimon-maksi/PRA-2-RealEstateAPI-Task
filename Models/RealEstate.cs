using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace RealEstateAPI.Models
{
    public class RealEstate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Type { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public double SquareFootage { get; set; }
        [BsonElement("Photos")]
        [JsonPropertyName("Photos")]
        public string PathToPhotos { get; set; } = null!;
    }
}

/* "Title": "First apartment", 
 * "Description": "First added apartment", 
 * "Price": 0.5, 
 * "Type": "apartment", 
 * "Location": "Some address", 
 * "NumberOfBedrooms": 2, 
 * "NumberOfBathrooms": 1,
 * "Photos": "path to photos,
 * "SquareFootage": 30.3"*/
