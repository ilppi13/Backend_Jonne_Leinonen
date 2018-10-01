using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class NewPlayer
    {
        public string Name { get; set; }
        [Range(1, 99)]
        public int Level { get; set; }
        public string tag { get; set; }
    }
}