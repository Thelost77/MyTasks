using Microsoft.EntityFrameworkCore;
using MyTasks.Core;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;
        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories(string userId)
        {
            return _context.Categories.Where(x => x.UserId == userId).OrderBy(x => x.Name).ToList();
        }
        public Category GetCategory(int id, string userId)
        {
            return _context.Categories.Single(x => x.Id == id && x.UserId == userId);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }
        public void Remove(int id, string userId)
        {
            var categoryToRemove = _context.Categories.Single(x => x.Id == id && x.UserId == userId);
            _context.Categories.Remove(categoryToRemove);
        }
        public void Edit(Category category)
        {
            var categoryToEdit = _context.Categories.Single(x => x.Id == category.Id && x.UserId == category.UserId);
            categoryToEdit.Name = category.Name;            
        }

    }
}
