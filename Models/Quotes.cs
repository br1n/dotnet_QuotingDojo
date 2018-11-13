using System;
using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models
{
    public class Quotes
    {
        public int QuoteId {get;set;}

        [Required]
        public string Name {get;set;}
        [Required]
        public string Quote {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}