using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouDo.Models
{
    public class TodoCategory
    {
        [PrimaryKey, AutoIncrement]
        //primary can never be dupilcate. Unique way to identify a row. Every table needs to  have a primary key
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
