using Socials.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socials.Contracts
{
	public interface IFoodScheduling
	{
		Task<List<FoodSchedulingViewModel>> GetScheduledFood(int frequency, string userName);
        Task<List<FoodScheduling>> GetFoods();
        List<FoodScheduling> GenerateFoodSchedule(DateTime startDate, DateTime EndDate, string UserName, int frequency);
        Task<FoodScheduling> GetFood(long id);
        void DeleteFood(long id);
        void UpdateFood(FoodScheduling food);
        void CreateFoodSchedule(List<FoodScheduling> foods);
    }
}
