using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class PagoComision
    {
        public int mes { get; set; }
        public int anio { get; set; }
        public string estado { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public int total { get; set; }

        private List<PagoComision> GenerarListado(List<Backend.Datos.PAGOCOMISION> entidad)
        {
            List<PagoComision> pagoComisiones = new List<PagoComision>();

            foreach (Backend.Datos.PAGOCOMISION pc in entidad)
            {
                PagoComision p = new PagoComision();

                p.mes = int.Parse(pc.MES);
                p.anio = int.Parse(pc.ANIO);
                p.estado = pc.ESTADO;
                p.rut = pc.RUT;
                p.nombre = pc.NOMBRE;
                p.total = (int)pc.TOTAL_COMISION;

                pagoComisiones.Add(p);
                
            }

            return pagoComisiones;
        }

        public List<PagoComision> listadoPagoComisiones()
        {
            var p = AccesoModelo.Modelo.PAGOCOMISION;

            return GenerarListado(p.ToList());
        }
    }
}
