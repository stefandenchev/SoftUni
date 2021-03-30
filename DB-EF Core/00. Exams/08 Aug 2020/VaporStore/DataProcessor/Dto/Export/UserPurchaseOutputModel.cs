using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserPurchaseOutputModel
    {
        [Required]
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray]
        public PurchaseOutputModel[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
