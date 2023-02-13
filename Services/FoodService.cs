using Microsoft.EntityFrameworkCore;
using Socials.Contracts;
using Socials.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socials.Services
{
	public class FoodService : IFood
	{
        private readonly SocialsDbContext _context;
        public FoodService(SocialsDbContext context)
		{
			_context = context;
		}
		public void CreateFood(Food food)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteFood(long id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Food> GetFood(long id)
		{
			var model = await _context.FindAsync<Food>(id);
			return model;
		}

		public async Task<List<Food>> GetFoods()
		{
			var model = await _context.Foods.ToListAsync();
			return model;
		}

		public void UpdateFood(Food food)
		{
			throw new System.NotImplementedException();
		}
	}
}
