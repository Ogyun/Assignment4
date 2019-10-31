using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseService
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get => Category.Name; }
        public string ProductName { get => Name; }
        public int CategoryId { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public Category Category { get; set; }
    }
}
