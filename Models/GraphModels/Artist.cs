using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.GraphModels
{
    [Table("Artist")]
    public class Artist : Node
    {
        public DateTime DateOfBirth { get; set; }
    }
}