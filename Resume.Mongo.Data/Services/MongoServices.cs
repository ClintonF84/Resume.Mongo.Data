using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Resume.Mongo.Data.Services
{
    public class MongoServices
    {
        private MongoClient client;
        public MongoServices() : base()
        {

        }

        public MongoServices(string mongoConString) : this()
        {
            this.client = new MongoClient(mongoConString);
        }

        public async Task<bool> TestConnection()
        {
            var list = await this.client.ListDatabaseNamesAsync();
            return list.Any();
        }

        public async Task<List<string>> GetDatabaseNames()
        {
            List<string> dbNames = new List<string>();
            var dbs = await this.client.ListDatabaseNamesAsync();

            await dbs.ForEachAsync(item => dbNames.Add(item));

            return dbNames;
        }
    }
}
