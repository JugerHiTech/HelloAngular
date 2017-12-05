using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HelloAngular.Interface;

namespace HelloAngular.Models
{
    /// <summary>
    /// NoteContext
    /// </summary>
    public class NoteContext
    {
        private readonly IMongoDatabase _database = null;

        /// <summary>
        /// NoteContext
        /// </summary>
        /// <param name="settings"></param>
        public NoteContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        /// <summary>
        /// Notes
        /// </summary>
        /// <returns></returns>
        public IMongoCollection<Note> Notes
        {
            get
            {
                return _database.GetCollection<Note>("Note");
            }
        }
    }
}
