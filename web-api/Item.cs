using System;

namespace web_api
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}