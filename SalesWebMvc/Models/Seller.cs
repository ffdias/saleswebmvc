using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between 3 and 60")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "$ {0:F2}")]
        [Range(100.0, 500000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalery { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalery, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalery = baseSalery;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
