﻿namespace AspNetApp.Models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List<Spate> Spates { set; get; }
    }
}