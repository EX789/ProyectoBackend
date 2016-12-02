using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Comision
    {
        public int id_comision { get; set; }
        public int monto_comision { get; set; }
        public DateTime fecha { get; set; }
        public string estado_comision { get; set; }
        public string comprobante { get; set; }
        public int id_medico { get; set; }
        public int id_pago { get; set; }


        public bool RealizarPagoComision(int mes, int anio, string rut, string comp)
        {
            try
            {

                AccesoModelo.Modelo.ACTUALIZA_COMISION(mes, anio, rut, comp);

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
