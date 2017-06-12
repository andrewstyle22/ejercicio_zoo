﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoo
{
    public class Especies
    {
        public long idEspecie { get; set; }
        public Clasificaciones clasificacion { get; set; }
        public TiposAnimal tipoAnimal { get; set; }
        public string nombre { get; set; }
        public short nPatas { get; set; }
        public bool esMascota { get; set; }
    }
}