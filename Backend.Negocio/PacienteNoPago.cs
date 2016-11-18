using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class PacienteNoPago
    {
        public string Nombre { set; get; }
        public string Rut_paciente { set; get; }
        public DateTime fecha_reserva { set; get; }
        public string Descripcion { set; get; }
        public int id_agenda { set; get; }
        public int id_medico { set; get; }


        private List<PacienteNoPago> GenerarListado(List<Backend.Datos.PACIENTESNOPAGO> entidadPaicienteNoPago)
        {
            List<PacienteNoPago> pacientesNoPago = new List<PacienteNoPago>();

            foreach (Backend.Datos.PACIENTESNOPAGO PnoP in entidadPaicienteNoPago)
            {
                PacienteNoPago Pno = new PacienteNoPago();

                Pno.Nombre = PnoP.NOMBRE;
                Pno.Rut_paciente = PnoP.PERSONA_RUT;
                Pno.fecha_reserva = PnoP.FECHA_RESERVA;
                Pno.Descripcion = PnoP.DESCRIPCION;
                Pno.id_agenda = (int)PnoP.ID_AGEN_MED;
                Pno.id_medico = (int)PnoP.ID_MEDICO;

                pacientesNoPago.Add(Pno);

            }

            return pacientesNoPago;
        }

        public List<PacienteNoPago> ListadoPacienteNoPago()
        {
            var listado = AccesoModelo.Modelo.PACIENTESNOPAGO;

            return GenerarListado(listado.ToList());
        }

            
    }
}
