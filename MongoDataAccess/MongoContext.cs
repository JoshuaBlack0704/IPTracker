using System;
using System.Linq;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDataAccess
{
    public class MongoContext
    {
        private MongoClient server;
        public IMongoDatabase database;

        public void SetDatabase(string databaseName)
        {
            database = server.GetDatabase(databaseName);
        }

        public string GetDatabaseName()
        {
            if (database != null)
            {
                return database.DatabaseNamespace.ToString();
            }
            else
            {
                throw new Exception("No database set");
            }
        }

        public async Task<IClientSessionHandle> GetSession()
        {
            return await server.StartSessionAsync();
        }

        public MongoContext()
        {
            server = new MongoClient("mongodb+srv://jstorm0704:J4z28k23!D@sandbox.ejbua.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        }
        public MongoContext(string connection)
        {
            server = new MongoClient(connection);
        }
    }

    public static class MongoUserManager
    {
        public static async Task<bool> AddNewUserAsync(string username, string password, MongoContext context, string pepper = null)
        {
            UserLoginModel user = new UserLoginModel() {Username = username};

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor: 4);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            var cancelToken = new CancellationTokenSource();

            context.SetDatabase("Authentication");
            var Users = context.database.GetCollection<UserLoginModel>("Users");
            var userFilter = Builders<UserLoginModel>.Filter.Eq("username", username);
            if (await Users.CountDocumentsAsync(userFilter) > 0)
            {
                Console.WriteLine("User already exists");
                return false;
            }



            //Salt entry and object id retrieval
            var Salts = context.database.GetCollection<EntryModel>("Salts");
            EntryModel saltEntry = new EntryModel() {key = salt};
            await Salts.InsertOneAsync(saltEntry);
            var saltFilter = Builders<EntryModel>.Filter.Eq("key", salt);
            var saltId = await Salts.FindAsync(saltFilter);
            user.Saltid = saltId.Single()._id;
            

            //Password entry and object id
            var Hashes = context.database.GetCollection<EntryModel>("Hashes");
            EntryModel hashEntry = new EntryModel() {key = hashedPassword};
            await Hashes.InsertOneAsync(hashEntry);
            var hashFilter = Builders<EntryModel>.Filter.Eq("key", hashedPassword);
            var hashId = await Hashes.FindAsync(hashFilter);
            user.PasswordId = hashId.Single()._id;

            //Enter User
            await Users.InsertOneAsync(user);
            //Console.WriteLine("Added new user");
            return true;

        }

        public static async Task<ObjectId> CheckCredentialsAny(MongoContext server, string username, string password)
        {
            server.SetDatabase("Authentication");
            var users = server.database.GetCollection<UserLoginModel>("Users");
            var salts = server.database.GetCollection<EntryModel>("Salts");
            var hashes = server.database.GetCollection<EntryModel>("Hashes");
            var userFilter = Builders<UserLoginModel>.Filter.Eq("username", username);
            bool isUser = await users.CountDocumentsAsync(userFilter) > 0;

            if (isUser)
            {
                var userCursor = await users.FindAsync(userFilter);
                var userList = userCursor.ToList();

                foreach (var user in userList)
                {
                    if (await CheckPassword(user))
                    {
                        return user._id;
                    }
                }
            }
            else
            {
                return ObjectId.Empty;
            }

            return ObjectId.Empty;
            //Must use only after declaring collections
            async Task<bool> CheckPassword(UserLoginModel user)
            {
                var saltId = user.Saltid;
                var hashId = user.PasswordId;

                var saltFilter = Builders<EntryModel>.Filter.Eq("_id", saltId);
                var hashFilter = Builders<EntryModel>.Filter.Eq("_id", hashId);

                var saltCursor = await salts.FindAsync(saltFilter);
                var hashCursor = await hashes.FindAsync(hashFilter);

                var salt = saltCursor.First().key;
                var hash = hashCursor.First().key;

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

                return hashedPassword == hash;
            }
        }

        
    }

    public class UserLoginModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("saltId")]
        public ObjectId Saltid { get; set; }

        [BsonElement("passwordId")]
        public ObjectId PasswordId { get; set; }
        
        public UserLoginModel(){}
        public UserLoginModel(string id, string username, string saltid, string passwordid)
        {
            _id = new ObjectId(id);
            Username = username;
            Saltid = new ObjectId(saltid);
            PasswordId = new ObjectId(passwordid);
        }
        public UserLoginModel(ObjectId id, string username, ObjectId saltid)
        {
            _id = id;
            Username = username;
            Saltid = saltid;
        }
    }

    class EntryModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }
        [BsonElement("key")]
        public string key { get; set; }
    }

}
