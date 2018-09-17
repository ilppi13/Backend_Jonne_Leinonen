using System;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class NewItem
    {
        public string Name { get; set; }
        [Range(1, 99)]
        public int Level { get; set; }
        [ItemTypeValidator]
        public string Type { get; set; }
        [DateTypeValidator]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}