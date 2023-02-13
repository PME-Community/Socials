namespace Socials.Models
{
    public class GameOfThrone
    {
        public class GotQuote
        {
            public string sentence { get; set; }
            public Character character { get; set; }
        }

        public class Character
        {
            public string name { get; set; }
            public string slug { get; set; }
            public House house { get; set; }
        }

        public class House
        {
            public string name { get; set; }
            public string slug { get; set; }
        }

    }
}
