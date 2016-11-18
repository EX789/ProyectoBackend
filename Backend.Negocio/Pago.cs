using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Pago
    {
        public int monto { get; set; }
        public DateTime fecha { get; set; }
        public int id_forma_pago { get; set; }
        public string rut_persona { get; set; }
        public int id_agenda_medico { get; set; }
        public int id_prevision { get; set; }


        public bool CrearPago( int monto,string forma_pago, string rut,int agenda, string prevision,int porc_prev,int id_medico)
        {
          

            try
            {
            
                 var id_forma_pago = from pago in AccesoModelo.Modelo.FORMA_PAGO
                                     where pago.DESCRIPCION == forma_pago
                                     select pago.ID_FORMA_PAGO;


                 var id_prev = from prev in AccesoModelo.Modelo.PREVISION
                               where prev.DESCRIPCION_PREVISION == prevision
                               select prev.ID_PREVISION;

                 AccesoModelo.Modelo.P_INGRESAR_PAGOS(monto, id_forma_pago.First(), rut, agenda, id_prev.First(), porc_prev, id_medico);

               
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

      
    }
}
