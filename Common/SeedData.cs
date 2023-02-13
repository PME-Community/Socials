using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Socials.Models;
using System.IO;
using Microsoft.Data.SqlClient;
using System;
using static Socials.Models.FoodClassification;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Socials.Common
{
    public static class SeedData
    {
        public static void PopulateFood(SocialsDbContext context)
        {
            if (!context.Foods.Any())
            {
                context.Database.EnsureCreated();
                var model = new Food();
                var allfood = new List<Food>();
                var filePath = @"C:\Projects\Socials\Common\FoodType.json";
                var myJsonString = File.ReadAllText(filePath);
                var myJObject = JObject.Parse(myJsonString).ToString();
                var foodList = JsonConvert.DeserializeObject<Rootobject>(myJObject);

                foreach (var item in foodList.FoodTypes)
                {
                    Console.WriteLine(item.Category);
                    var category = item.Category;

                    foreach (var food in item.Foods)
                    {
                        model.Name = food;
                        model.Category = category;
                        allfood.Add(model);

                        model = new Food();
                    }
                }

                context.Foods.AddRange(allfood);
                context.SaveChanges();
            }
        }
    }
}
