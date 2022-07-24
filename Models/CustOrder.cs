using System;
using System.Collections.Generic;

#nullable disable

namespace codebaseProjesi.Models
{
    public partial class CustOrder
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int? OrderNumber { get; set; }
        public int? ProductNumber { get; set; }
    }
}
