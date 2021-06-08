﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Vanilla.ENTIDAD
{
    public class spMostrarManejoReservas
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Habitacion { get; set; }
        public DateTime Fechareserva { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int Dias { get; set; }
        public int Ocupantes { get; set; }
        public decimal? Pagoadelantado { get; set; }
        public string Tipodehabitación { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Total { get; set; }
    }
}