using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Client;
using DataAccess.Infrastructure;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.IntegrationTest
{
    [TestClass]
    public class DataAccessIntegrationTest
    {
        [TestMethod]
        public async Task TestCRUD()
        {
            var config = new DataAccessConfiguration { ConnectionString = "DataSource=temp.db; Version=3;" };
            ISQLiteClient client = new SQLiteClient(config);

            await TestInsert(client);
            await TestGet(client);
            await TestGet(client, 1);
            await TestGet(client, 2);
            await TestUpdate(client);

            File.Delete("temp.db");
        }

        private async Task TestUpdate(ISQLiteClient client)
        {
            var note = new Note { Id = 1, Content = "Updated content", LastUpdated = DateTime.Now };
            await client.UpdateAsync(note);
            var result = await client.GetAsync(1);

            Assert.AreEqual(note.Content, result.Content);
        }

        private async Task TestGet(ISQLiteClient client, int id)
        {
            var result = await client.GetAsync(id);
            Assert.AreEqual(id, result.Id);
        }

        private async Task TestGet(ISQLiteClient client)
        {
            var result = await client.GetAsync();
            Assert.IsTrue(result.Count() == 2);
        }

        private async Task TestInsert(ISQLiteClient client)
        {
            var note1 = new Note { Content = "IntegrationTest1", LastUpdated = DateTime.Now };
            var note2 = new Note { Content = "IntegrationTest2", LastUpdated = DateTime.Now };

            var resultingId1 = await client.InsertAsync(note1);
            var resultingId2 = await client.InsertAsync(note2);

            Assert.AreEqual(1, resultingId1.Id);
            Assert.AreEqual(2, resultingId2.Id);
        }
    }
}
