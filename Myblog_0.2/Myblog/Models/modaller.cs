using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Myblog.Models
{
    public class modaller
    {
        [Required(ErrorMessage = "Lütfen Adınızı Soyadınızı Yazınız.")] 
        public string name_surname { get; set; }

        [Required(ErrorMessage = "Lütfen Emailinizi Yazınız.")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Giriniz.")]
        public string email { get; set; }
     

        public DateTime date { get; set; }

        [Required(ErrorMessage = "Lütfen Mesajınızı Giriniz.")]
        [MaxLength(500, ErrorMessage = "Lütfen 500 Karakteri Geçmeyin.")]
        public string massage { get; set; }
        

        public string number { get; set; }


    }
    }
