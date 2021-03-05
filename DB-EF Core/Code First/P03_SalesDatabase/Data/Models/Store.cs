using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }
        public int StoreId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}