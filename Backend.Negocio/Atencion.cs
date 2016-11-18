using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Atencion
    {
        public int id_atencion { get; set; }
        public int id_centro { get; set; }
        public int id_pago { get; set; }
        public string descripcion { get; set; }


        private List<Atencion> GenerarListado(List<Backend.Datos.ATENCION> entidadAtencion)
        {

            List<Atencion> atenciones = new List<Atencion>();

            foreach (Backend.Datos.ATENCION a in entidadAtencion)
            {
                
                Atencion atencion = new Atencion();

                atencion.id_atencion = (int)a.ID_ATENCION;
                atencion.id_centro = (int)a.ID_CENTRO;
                atencion.id_pago = (int)a.ID_PAGO;
                atencion.descripcion = a.DESCRIPCION_ATENCION;

                atenciones.Add(atencion);

            }

            return atenciones;
        }

       
    }
}
