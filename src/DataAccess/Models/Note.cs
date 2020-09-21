using System;

namespace DataAccess.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}