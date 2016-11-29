using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Backend.Negocio;

namespace Backend.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class BackendSVC : IbackendSVC
    {
        public bool ValidarPersona(string rut, string pass)
        {
            Persona per = new Persona();


            return per.ValidaPersona(rut, pass);
 
        }



        public List<Backend.Negocio.PacienteNoPago> ListadoPacienteNoPago()
        {
            PacienteNoPago p = new PacienteNoPago();

            return p.ListadoPacienteNoPago();
        }


        public bool CrearPersona(string rut, string nombre, string apP, string apM, string direc, string comuna, int telefono, string correo, string pass)
        {
            Persona per = new Persona();

            per.RutPersona = rut;
            per.NombrePersona = nombre;
            per.ApellidoP = apP;
            per.ApellidoM = apM;
            per.Direccion = direc;
            per.Comuna = comuna;
            per.Telefono = telefono;
            per.Correo = correo;
            per.Pass = pass;

            return per.CrearPersona(); 
        }

        public string RecuperaNombre(string rut)
        
        { 
            Persona per = new Persona();

            return per.RecuperaNombre(rut);
        }

        public IQueryable<string> RecuperaPerfil(string rut)
        {
            Persona per = new Persona();

           return per.RecuperaPerfil(rut);
        }


        public bool PacienteAtendido(int id_pago)
        {
            Paciente pa = new Paciente();
            return pa.PacienteAtendido(id_pago);
        }


      
        public bool CrearPago(int monto, string forma_pago, string rut, int agenda, string prevision, int porc_prev, int id_medico)
        {
            Pago p = new Pago();

            return p.CrearPago(monto, forma_pago, rut, agenda, prevision, porc_prev, id_medico);
 
        }

        /*public List<Backend.Negocio.Paciente> listarPacientePorMedico(string rut)
        {
            Paciente pac = new Paciente();

            return pac.ListarPacientePorMedico(rut);
        }*/

        public List<Backend.Negocio.Paciente> ListadePacientePorMedico(String rut, int id)
        {
            Paciente p = new Paciente();

            return p.ListadePacientePorMedico(rut, id);
        }

        public int RecuperarIdMedico(string rut)
        {
            Medico med = new Medico();

            return med.RecuperarIdMedico(rut);
        }

        public IQueryable<string> distinto()
        {
            Medico med = new Medico();

            return med.distinto();
        }

        public List<Backend.Negocio.Medico> listarMedicoxCentroyEsp(int[] id_centro, string especialidad)
        {
            Medico med = new Medico();

            return med.listarMedicoxCentroyEsp(id_centro, especialidad);
        }

        public bool eliminarReserva(int id_agenda, string rut)
        {
            Reserva rev = new Reserva();

            return rev.eliminarReserva(id_agenda, rut);
        }

        public List<Backend.Negocio.Agenda_medico> listarHoraxFechayMedico(DateTime fecha, int id_medico)
        {
            Agenda_medico ag = new Agenda_medico();

            return ag.listarHoraxFechayMedico(fecha, id_medico);

        }

        public IQueryable<string> RutMedico(int id)
        {
            Medico med = new Medico();
 
            return med.RutMedico(id);
        
        }

        public bool verificarListaReserva(string rut)
        {
            Reserva res = new Reserva();
            return res.verificarReservas(rut);
        }

        public List<Backend.Negocio.Reserva> listarReserva(string rut)
        {
            Reserva res = new Reserva();

            return res.retornarListaReservaPorRut(rut);
        }

    

        public bool CreaHora(DateTime fecha,string rut, int horas, int minutos, string descp)
        {
            Medico med = new Medico();
            Agenda_medico ag = new Agenda_medico();

            ag.Fecha = fecha;
            ag.Id_medico = med.RecuperarIdMedico(rut);
            ag.Horas = horas;
            ag.Minutos = minutos;
            ag.Descripcion = descp;

            return ag.CrearHora();
 
        }

        public List<Backend.Negocio.Medico> ListarMedico()
        {
            Medico med = new Medico();

            return med.ListadoMedico();
        }

        public List<Backend.Negocio.CentroMedico> ListarCentro()
        {
            CentroMedico centro = new CentroMedico();

            return centro.ListadoCentroMedico();
        }

        public List<Backend.Negocio.Agenda_medico> ListadoDeHoras(string rut,DateTime fecha)
        {
            Agenda_medico ag = new Agenda_medico();

            return ag.ListadoHorasPorMedico(rut,fecha);
        }

        public bool ReservarHora(int id)
        {
            Agenda_medico ag = new Agenda_medico();

            return ag.ReservarHora(id);
        }

        public bool CrearReserva(int estadoReserva, string rut, int id_agenda)
        {
            Reserva r = new Reserva();

            r.estado_reserva = estadoReserva;
            r.rut_persona = rut;
            r.id_agen_med = id_agenda;

            return r.CrearReserva();
        }

        public bool EliminarHora(int id)
        {
            Agenda_medico ag = new Agenda_medico();

            return ag.EliminaHora(id);
        }

        public bool EliminarHoraPaciente(int id)
        {
            Agenda_medico ag = new Agenda_medico();

            return ag.EliminarHoraPaciente(id);
 
        }
      


        public bool RecibeListado(List<Backend.Negocio.Agenda_medico> Lista)
        {

            Agenda_medico ag = new Agenda_medico();


            return ag.RecibirArreglo(Lista);
        }




        public Backend.Negocio.Persona RecuperaDatos(string rut)
        {
            Persona p = new Persona();

            return p.RecuperaDatos(rut);
        }







        public void enviarCorreo()
        {
            Agenda_medico ag = new Agenda_medico();
            ag.EnviarCorreo();
        }



        public List<Backend.Negocio.Recaudacion> listadoRecaaudacionXFechas(DateTime fechaini, DateTime fechafinal)
        {
            Recaudacion rec = new Recaudacion();

            return rec.listadoRecaaudacionXFechas(fechaini, fechafinal);
        }

        public List<Backend.Negocio.Recaudacion> listadoRecaaudacionXFechasyMedico(string rut, DateTime fechaini, DateTime fechafinal)
        {
            Recaudacion rec = new Recaudacion();

            return rec.listadoRecaaudacionXFechasyMedico(rut, fechaini, fechafinal);
        }
        
    }
}
