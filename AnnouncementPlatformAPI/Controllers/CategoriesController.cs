﻿using AnnouncementPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        public static List<Category> categories = new List<Category>
        {
             new Category { Id = 1, Name="General"},
             new Category { Id = 2, Name="Labs"},
             new Category { Id = 3, Name="Courses"},
        };

        /// <summary>
        /// Gets all categories.
        /// </summary>
        [HttpGet]
        public IActionResult GetCategories()
        {
            if (categories != null)
                return Ok(categories);
            return NotFound();
        }

        /// <summary>
        /// Gets category by it's id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
                return Ok(category);
            return NotFound();
        }

        /// <summary>
        /// Deletes category by id.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null) 
            { 
                categories.Remove(category);
                return Ok(category);
            }
            return NotFound();
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("Invalid data");
            }

            int newId = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;

            category.Id = newId;
            categories.Add(category);

            return Ok(category);
        }
    }
}
