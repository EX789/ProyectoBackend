using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Backend.Negocio
{
    public class Recaudacion
    {
        public DateTime fecha { get; set; }
        public int paciente { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apePat { get; set; }
        public string apeMat { get; set; }
        public int monto { get; set; }


        private List<Recaudacion> GenerarListado(List<Backend.Datos.RECAUDACION> entidad)
        {
            List<Recaudacion> listasRecaudacion = new List<Recaudacion>();

            foreach (Backend.Datos.RECAUDACION r in entidad)
            {
                Recaudacion rec = new Recaudacion();

                rec.fecha = r.FECHA;
                rec.paciente = (int)r.PACIENTE_ATENDIDOS;
                rec.rut = r.RUT_MEDICO;
                rec.nombre = r.NOMBRE;
                rec.apePat = r.APELLIDO_PAT;
                rec.apeMat = r.APELLIDO_MAT;
                rec.monto = (int)r.MONTO;

                listasRecaudacion.Add(rec);
            }

            return listasRecaudacion;
        }


        public List<Recaudacion> listadoRecaaudacionXFechas(DateTime fechaini, DateTime fechafinal)
        {
            var listadoRecaudacion = AccesoModelo.Modelo.RECAUDACION.Where(rec => EntityFunctions.TruncateTime(rec.FECHA) >= fechaini.Date && EntityFunctions.TruncateTime(rec.FECHA) <= fechafinal.Date);
            return GenerarListado(listadoRecaudacion.ToList());
        }


        public List<Recaudacion> listadoRecaaudacionXFechasyMedico(string rut, DateTime fechaini, DateTime fechafinal)
        {
            var listadoRecaudacion = AccesoModelo.Modelo.RECAUDACION.Where(rec => rec.RUT_MEDICO == rut && EntityFunctions.TruncateTime(rec.FECHA) >= fechaini.Date && EntityFunctions.TruncateTime(rec.FECHA) <= fechafinal.Date);
            return GenerarListado(listadoRecaudacion.ToList());

        }
    }
}
