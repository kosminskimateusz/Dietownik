using MongoDB.Bson;  
using MongoDB.Driver;  
using MongoDB.Driver.Builders;  
using MongoDB.Driver.GridFS;  
using MongoDB.Driver.Linq; 
namespace Dietownik
{
    class DataBase
    {
        public DataBase()
        {
            string conncetionString = @"mongodb+srv://kosminskimateusz:matiko1@cluster0.lbufw.mongodb.net/Dietownik?retryWrites=true&w=majority";
            MongoClient client = new MongoClient(conncetionString);
            MongoServer server = client.GetServer();
            var database = client.GetDatabase("test");
        }
    }
}