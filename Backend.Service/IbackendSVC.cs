using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Backend.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IbackendSVC
    {

        [OperationContract]
        bool ValidarPersona(string rut, string pass);

        [OperationContract]
        List<Backend.Negocio.PacienteNoPago> ListadoPacienteNoPago();

        [OperationContract]
        string RecuperaNombre(string rut);

        [OperationContract]
        IQueryable<string> RecuperaPerfil(string rut);

        [OperationContract]
        int RecuperarIdMedico(string rut);


        [OperationContract]
        bool CreaHora(DateTime fecha,string rut, int horas, int minutos, string descp);

        [OperationContract]
        bool CrearPago(int monto, string forma_pago, string rut, int agenda, string prevision, int porc_prev, int id_medico);
  

        [OperationContract]
        bool CrearPersona(string rut, string nombre, string apP, string apM, string direc, string comuna, int telefono, string correo, string pass);


        [OperationContract]
        Backend.Negocio.Persona RecuperaDatos(string rut);


        /*[OperationContract]
        List<Backend.Negocio.Paciente> listarPacientePorMedico(string rut);*/

        [OperationContract]
        List<Backend.Negocio.Paciente> ListadePacientePorMedico(String rut, int id);

        [OperationContract]
        IQueryable<string> distinto();

        [OperationContract]
        List<Backend.Negocio.Medico> listarMedicoxCentroyEsp(int[] id_centro, string especialidad);


        [OperationContract]
        bool PacienteAtendido(int id_pago);

        [OperationContract]
        List<Backend.Negocio.Medico> ListarMedico();

        [OperationContract]
        List<Backend.Negocio.CentroMedico> ListarCentro();

        [OperationContract]
        List<Backend.Negocio.Agenda_medico> ListadoDeHoras(string rut, DateTime fecha);

        [OperationContract]
        bool eliminarReserva(int id_agenda, string rut);

        [OperationContract]
        bool EliminarHora(int id);

        [OperationContract]
        bool ReservarHora(int id);

        [OperationContract]
        bool EliminarHoraPaciente(int id);

        [OperationContract]
        bool CrearReserva(int estadoReserva, string rut, int id_agenda);

        [OperationContract]
        List<Backend.Negocio.Agenda_medico> listarHoraxFechayMedico(DateTime fecha, int id_medico);


        [OperationContract]
        List<Backend.Negocio.Reserva> listarReserva(String rut);

        [OperationContract]
        bool verificarListaReserva(string rut);

        [OperationContract]
        IQueryable<string> RutMedico(int id);

        [OperationContract]
        bool RecibeListado(List<Backend.Negocio.Agenda_medico> Lista);

        [OperationContract]
        void enviarCorreo();
        // TODO: agregue aquí sus operaciones de servicio
    }


   
}
