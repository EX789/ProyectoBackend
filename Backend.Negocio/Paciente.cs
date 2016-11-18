using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Paciente
    {
        public string nombre { get; set; }
        public int horas { get; set; }
        public int minutos { get; set; }
        public string descripcion { get; set; }
        public string rut { get; set; }
        public int id_pago { get; set; }


        private List<Paciente> GeneraListado(List<Backend.Datos.PACIENTEESPERA> entidadPacienteEspera)
        {
            List<Paciente> pacientes = new List<Paciente>();

            foreach (Backend.Datos.PACIENTEESPERA pe in entidadPacienteEspera)
            {
                Paciente paciente = new Paciente();

                paciente.nombre = pe.NOMBRE;
                paciente.horas = (int)pe.HORAS;
                paciente.minutos = (int)pe.MINUTOS;
                paciente.descripcion = pe.DESCRIPCION_ATENCION;
                paciente.rut = pe.PERSONA_RUT;
                paciente.id_pago = (int)pe.ID_PAGO;

                pacientes.Add(paciente);

            }

            return pacientes;
        }


        /*public List<Paciente> ListarPacientePorMedico(string rut)
        {
            var listado = AccesoModelo.Modelo.PACIENTEESPERA.Where(med => med.PERSONA_RUT == rut);
            return GeneraListado(listado.ToList());
        }*/


        public bool PacienteAtendido(int id_pago)
        {
            try
            {
                Backend.Datos.ATENCION at = AccesoModelo.Modelo.ATENCION.FirstOrDefault(ate => ate.ID_PAGO == id_pago);
                at.DESCRIPCION_ATENCION = "Atendido";
                AccesoModelo.Modelo.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
           
 
        }


        public List<Paciente> ListadePacientePorMedico(String rut, int id)
        {
            if (id == 1)
            {
                var listado = AccesoModelo.Modelo.PACIENTEESPERA.Where(med => med.PERSONA_RUT == rut && med.DESCRIPCION_ATENCION == "Espera");
                return GeneraListado(listado.ToList());
            }
            else
            {
                var listado = AccesoModelo.Modelo.PACIENTEESPERA.Where(med => med.PERSONA_RUT == rut);
                return GeneraListado(listado.ToList());
            }
        }


       

    }


}
