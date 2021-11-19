using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FundamentalsMVC.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="Your string is too long!")]
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}