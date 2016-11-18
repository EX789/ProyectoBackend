using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Backend.Negocio
{
    public class Agenda_medico
    {
        public int id_agenda_medico { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_medico { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public string Descripcion { get; set; }

        Backend.Datos.GalenosEntities g;
 
        public bool CrearHora()
        {
            using (g = new Datos.GalenosEntities())
            try
            {

                ObjectSet<Backend.Datos.AGENDA_MEDICO> agenda = g.AGENDA_MEDICO;
                Backend.Datos.AGENDA_MEDICO a = new Datos.AGENDA_MEDICO();
                a.FECHA = this.Fecha;
                a.ID_MEDICO = this.Id_medico;
                a.HORAS = this.Horas;
                a.MINUTOS = this.Minutos;
                a.DESCRIPCION = this.Descripcion;
                agenda.AddObject(a);
                g.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                g.SaveChanges();
                return false;
            }
        }

        private List<Agenda_medico> GenerarListadoAgenda(List<Backend.Datos.AGENDA_MEDICO> entidadAgendaMedico)
        {
            List<Agenda_medico> horas = new List<Agenda_medico>();

            foreach (Backend.Datos.AGENDA_MEDICO ag in entidadAgendaMedico)
            {
                Agenda_medico agenda = new Agenda_medico();

                agenda.id_agenda_medico = (int) ag.ID_AGEN_MED;
                agenda.Fecha = ag.FECHA;
                agenda.Id_medico = (int) ag.ID_MEDICO;
                agenda.Horas = (int) ag.HORAS;
                agenda.Minutos = (int) ag.MINUTOS;
                agenda.Descripcion = ag.DESCRIPCION;

                horas.Add(agenda);
            }

            return horas;
 
        }


        public bool RecibirArreglo(List<Backend.Negocio.Agenda_medico> lista)
        {
            using (g = new Datos.GalenosEntities())

                try
                {
                    foreach (Backend.Negocio.Agenda_medico l in lista)
                    {

                        ObjectSet<Backend.Datos.AGENDA_MEDICO> agenda = g.AGENDA_MEDICO;
                        Backend.Datos.AGENDA_MEDICO a = new Datos.AGENDA_MEDICO();

                        var maximo = AccesoModelo.Modelo.AGENDA_MEDICO.Max(m => m.ID_AGEN_MED);

                        a.ID_AGEN_MED = maximo + 1;
                        a.FECHA = l.Fecha;
                        a.ID_MEDICO = l.Id_medico;
                        a.HORAS = l.Horas;
                        a.MINUTOS = l.Minutos;
                        a.DESCRIPCION = l.Descripcion;
                        agenda.AddObject(a);
                        g.SaveChanges();


                    }

                    return true;

                }
                catch (Exception ex)
                {



                    return false;
                }

        }


        public List<Agenda_medico> ListadoHorasPorMedico(string rut, DateTime fecha)
        {
            Medico med = new Medico();

            int id = med.RecuperarIdMedico(rut);

            var ListadoHoras = AccesoModelo.Modelo.AGENDA_MEDICO.Where(agen => agen.ID_MEDICO == id && EntityFunctions.TruncateTime(agen.FECHA) == fecha.Date);
            return GenerarListadoAgenda(ListadoHoras.ToList());

        }

        public bool EliminaHora(int id_hora)
        {
            try
            {
                Backend.Datos.AGENDA_MEDICO ag = AccesoModelo.Modelo.AGENDA_MEDICO.FirstOrDefault(agen => agen.ID_AGEN_MED == id_hora);
                AccesoModelo.Modelo.DeleteObject(ag);
                AccesoModelo.Modelo.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool ReservarHora(int id_hora)
        {
            try
            {

                Backend.Datos.AGENDA_MEDICO ag = AccesoModelo.Modelo.AGENDA_MEDICO.FirstOrDefault(agen => agen.ID_AGEN_MED == id_hora);

                ag.DESCRIPCION = "reservado";

                AccesoModelo.Modelo.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarHoraPaciente(int id_hora)
        {
            try
            {

                Backend.Datos.AGENDA_MEDICO ag = AccesoModelo.Modelo.AGENDA_MEDICO.FirstOrDefault(agen => agen.ID_AGEN_MED == id_hora);

                ag.DESCRIPCION = "disponible";

                AccesoModelo.Modelo.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Agenda_medico> listarHoraxFechayMedico(DateTime fecha, int id_medico)
        {
            var listarHora = AccesoModelo.Modelo.AGENDA_MEDICO.Where(ag => EntityFunctions.TruncateTime(ag.FECHA) == fecha.Date
                                                                                   && ag.ID_MEDICO == id_medico);

            return GenerarListadoAgenda(listarHora.ToList());

        }

    }
}
