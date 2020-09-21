using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Infrastructure;
using DataAccess.Models;
using DataAccess.SQL;

namespace DataAccess.Client
{
    public class SQLiteClient : ISQLiteClient
    {
        private DataAccessConfiguration _config;

        public SQLiteClient(DataAccessConfiguration config)
        {
            _config = config;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = GetDbConnection();
            connection.Execute(NoteSQL.CreateTableIfNotExists);
        }

        private SQLiteConnection GetDbConnection()
        {
            return new SQLiteConnection(_config.ConnectionString);
        }

        public async Task<Note> InsertAsync(Note note)
        {
            using var connection = GetDbConnection();
            await connection.ExecuteAsync(NoteSQL.InsertData, note);
            return (await connection.QueryAsync<Note>(NoteSQL.QueryLastInsert)).FirstOrDefault();
        }

        public async Task<IEnumerable<Note>> GetAsync()
        {
            using var connection = GetDbConnection();
            return await connection.QueryAsync<Note>(NoteSQL.QueryAll);
        }

        public async Task<Note> GetAsync(int Id)
        {
            using var connection = GetDbConnection();
            return (await connection.QueryAsync<Note>(NoteSQL.QueryOne, new { Id = Id })).FirstOrDefault();
        }

        public async Task<Note> UpdateAsync(Note note)
        {
            using var connection = GetDbConnection();
            await connection.ExecuteAsync(NoteSQL.Update, note);

            return note;
        }
    }
}