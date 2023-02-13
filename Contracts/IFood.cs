using Socials.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socials.Contracts
{
	public interface IFood
	{
		Task<List<Food>> GetFoods();
		Task<Food> GetFood(long id);
		void DeleteFood(long id);
		void UpdateFood(Food food);
		void CreateFood(Food food);
	}
}
