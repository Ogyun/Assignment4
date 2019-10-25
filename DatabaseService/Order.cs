using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        //some shipped dates have null values
        public DateTime? Shipped { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
