using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PracaDyplomowa.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PracaDyplomowa.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podałeś nazwy!")]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nie wybrałeś kategorii!")]
        [Display(Name = "Kategoria produktu")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Nie podałeś ceny!")]
        [Display(Name = "Cena produktu")]
        public double Price { get; set; }   
        
        
        [Display(Name = "Zdjęcie produktu")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Nie podałeś opisu!")]
        [Display(Name = "Opis produktu")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Dostępność produktu")]
        public bool IsAvailable { get; set; }

    }
          
}
