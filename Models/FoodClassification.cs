namespace Socials.Models
{
    public class FoodClassification
    {
        public class Rootobject
        {
            public Foodtype[] FoodTypes { get; set; }
        }

        public class Foodtype
        {
            public string Category { get; set; }
            public string[] Foods { get; set; }
        }

    }
}
