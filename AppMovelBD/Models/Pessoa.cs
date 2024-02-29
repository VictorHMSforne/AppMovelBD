using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovelBD.Models
{
    public class Pessoa //remover o internal
    {
        public int id { get; set; }  //esses dados aqui são um tipo de ponte com o C# e o SQL(No phpMyadmin)
        public string nome { get; set; }
        public string idade { get; set; }
        public string cidade { get; set;}
    }
}
