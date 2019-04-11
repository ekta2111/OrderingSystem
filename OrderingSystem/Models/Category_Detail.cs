using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystem.Models
{
    [Table("Category_Detail")]
    public class Category_Detail
    {
        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        // public List<Category_Detail> catdetail { get; set; }

    }
}