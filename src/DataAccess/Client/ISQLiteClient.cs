using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Client
{
    public interface ISQLiteClient
    {
        Task<Note> InsertAsync(Note note);
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(int Id);
        Task<Note> UpdateAsync(Note note);
    }
}