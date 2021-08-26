using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(string userId);
        void Add(Category category);
        void Remove(int id, string userId);
        Category GetCategory(int id, string userId);
        void Edit(Category category);
    }
}
