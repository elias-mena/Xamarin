using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TareaInt.Model
{
    [Table("dato")]

    public class Dato
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public String Description { get; set; }
        [MaxLength(100)]
        public int Importancia { get; set; }
        

    }
}
