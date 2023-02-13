using Microsoft.EntityFrameworkCore;
using Socials.Common;
using Socials.Contracts;
using Socials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Socials.Common.Enums;

namespace Socials.Services
{
	public class FoodSchedulingService : IFoodScheduling
	{
        private readonly SocialsDbContext _context;
        private readonly IFood _food;
        public FoodSchedulingService(SocialsDbContext context, IFood food)
        {
            _context = context;
            _food = food;
        }

        public void CreateFoodSchedule(List<FoodScheduling> foods)
        {
            if(foods.Any())
            {
                _context.FoodSchedulings.AddRange(foods);
                _context.SaveChanges();
            }
        }

        public void DeleteFood(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FoodScheduling> GetFood(long id)
        {
            var model = await _context.FindAsync<FoodScheduling>(id);
            return model;
        }

        public async Task<List<FoodScheduling>> GetFoods()
        {
            var model = await _context.FoodSchedulings.ToListAsync();
            return model;
        }

        public void UpdateFood(FoodScheduling food)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<FoodSchedulingViewModel>> GetScheduledFood(int frequency, string userName)
		{
            var mealList = new List<FoodSchedulingViewModel>();
            var mealScheduleList = new List<FoodScheduling>();
            var model = new FoodScheduling();
            DateTime startDate = CommonMethods.FirstDayOfWeek(), endDate = CommonMethods.LastDayOfWeek();

            switch (frequency)
            {
                case (int)MealFrequencyEnum.Weekly:
                    startDate = CommonMethods.FirstDayOfWeek();
                    endDate = CommonMethods.LastDayOfWeek();
                    break;
                case (int)MealFrequencyEnum.Monthly:
                    startDate = CommonMethods.FirstDayOfMonth();
                    endDate = CommonMethods.LastDayOfMonth();
                    break;
            }

            var user = _context.FoodSchedulings.Where(x => x.UserName == userName && x.MealDate == startDate).FirstOrDefault();

            if (user == null) 
            {
                var generate = GenerateFoodSchedule(startDate, endDate, userName, frequency);
                CreateFoodSchedule(generate);
                mealScheduleList = GetFoods().Result.Where(x => x.UserName == userName && (x.MealDate >= startDate && x.MealDate <= endDate)).OrderBy(x => x.MealDate).ToList();
            }
            else
            {
                mealScheduleList = GetFoods().Result.Where(x => x.UserName == userName && (x.MealDate >= startDate && x.MealDate <= endDate)).OrderBy(x => x.MealDate).ToList();
            }

            mealList = mealScheduleList.Select(x => new FoodSchedulingViewModel()
            {
                Breakfast = x.Breakfast,
                Launch = x.Launch,
                Dinner = x.Dinner,
                MealDate = x.MealDate.ToShortDateString()
            }).ToList();

            return mealList;
		}

        public List<FoodScheduling> GenerateFoodSchedule(DateTime startDate, DateTime endDate, string userName, int frequency)
        {
            var list = new List<FoodScheduling>();
            var model = new FoodScheduling();
            var numberOfDays = (endDate - startDate).Days + 1;
            var mealDate = startDate;
            var foodList = _food.GetFoods().Result.Where(x => x.Category != "Soups and Stews").ToList();
            var getUserDates = GetFoods().Result.Where(x => x.UserName == userName && x.MealDate >= startDate && x.MealDate <= endDate).Select(x => x.MealDate).ToList();
            var batchNumber = CommonMethods.RandomString(6);

            for(var i=0; i<numberOfDays; i++)
            {
                bool exist = getUserDates.Any(d => d.Year == mealDate.Year && d.Month == mealDate.Month && d.Day == mealDate.Day);
                if (exist)
                {
                    mealDate = mealDate.AddDays(1);
                    continue;
                }

                var randomSelection = CommonMethods.GetRandomElements<Food>(foodList, 3);
                model.Breakfast = randomSelection[0].Name;
                model.Launch = randomSelection[1].Name;
                model.Dinner = randomSelection[2].Name;
                model.SelectedFrequency = (MealFrequencyEnum)frequency;
                model.MealDate = mealDate;
                model.UserName = userName;
                model.BatchNumber = batchNumber;
                list.Add(model);
                mealDate = mealDate.AddDays(1);
                model = new FoodScheduling();
            }

            return list;
        }


    }
}
