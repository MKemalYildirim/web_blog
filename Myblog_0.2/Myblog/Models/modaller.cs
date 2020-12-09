using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Myblog.Models
{
    public class modaller
    {
        [Required(ErrorMessage = "AdıSoyadı gereklidir!!!")] 
        public string name_surname { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [EmailAddress(ErrorMessage = "Email Geçersiz")]
        public string email { get; set; }
     

        public DateTime date { get; set; }

        [Required(ErrorMessage = "Boş Olmaz!!!")]
        [MaxLength(500, ErrorMessage = "500 karateri geçmeyin")]

        public string massage { get; set; }
        

        public string number { get; set; }


    }
    }
