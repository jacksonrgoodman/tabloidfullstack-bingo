﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabloid.Models;

namespace Tabloid.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
        Category GetById(int id);
    }
}
