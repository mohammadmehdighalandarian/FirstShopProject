﻿namespace FirstProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
