﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChoixResto.Models
{
    [Table("Restos")]
    public class Resto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [AuMoinsUnDesDeux(Parametre1 = "Telephone", Parametre2 = "Email", ErrorMessage = "Vous devez saisir au moins un moyen de contacter le restaurant")]
        public string Telephone { get; set; }
        [AuMoinsUnDesDeux(Parametre1 = "Telephone", Parametre2 = "Email", ErrorMessage = "Vous devez saisir au moins un moyen de contacter le restaurant")]
        public string Email { get; set; }
    }
}