﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTJobMatch.Models
{
    public class Category
    {
        //PK
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Category Name can only contain letters and numbers.")]
        public string CategoryName { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }


    }
}
