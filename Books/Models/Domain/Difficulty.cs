﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Books.Models.Domain
{
    [Table("Difficulty")]
    public class Difficulty
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }


    }
}
