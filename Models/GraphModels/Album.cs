using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.GraphModels
{
    [Table("Album")]
    public class Album : Node
    {
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}