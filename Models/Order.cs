using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PracaDyplomowa.Models
{
    public class Order
    {

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Nie podałeś swojego imienia!")] 
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nie podałeś swojego nazwiska!")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Nie podałeś numeru telefonu!")]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Nie podałeś emailu!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nie podałeś miasta!")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Nie podałeś ulicy!")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Nie podałeś numeru bloku!")]
        [Display(Name = "Numer bloku")]
        public int BlockNumber { get; set; }

        [Required(ErrorMessage = "Nie podałeś numeru mieszkania!")]
        [Display(Name = "Numer mieszkania")]
        public int ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Nie podałeś daty zamówienia!")]
        [Display(Name = "Data zamówienia")]
        public DateTime OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }


    }
}
