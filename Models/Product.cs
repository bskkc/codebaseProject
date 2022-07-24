using System;
using System.Collections.Generic;

#nullable disable

namespace codebaseProjesi.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductNumber { get; set; }
        public int? ProductPrice { get; set; }
    }
}
