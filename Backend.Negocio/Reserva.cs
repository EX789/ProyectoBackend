using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Reserva
    {
        public int estado_reserva { get; set; }
        public string rut_persona { get; set; }
        public int id_agen_med { get; set; }
        public int id_medico { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }

        public bool CrearReserva()
        {
            try
            {
                Backend.Datos.RESERVA r = new Datos.RESERVA();

                r.ESTADO_RESERVA = this.estado_reserva;
                r.PERSONA_RUT = this.rut_persona;
                r.ID_AGEN_MED = this.id_agen_med;
                AccesoModelo.Modelo.AddToRESERVA(r);
                AccesoModelo.Modelo.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private List<Reserva> crearLista(dynamic listaReserva)
        {
            List<Reserva> lista = new List<Reserva>();
            foreach (var item in listaReserva)
            {
                Reserva res = new Reserva();
                res.id_agen_med = (int)item.id_agenda;
                res.rut_persona = item.rut;
                res.estado_reserva = (int)item.estado_reserva;
                res.id_medico = (int)item.id_medico;
                res.hora = (int)item.hora;
                res.minuto = (int)item.minuto;
                lista.Add(res);
            }
            return lista;
        }

        public List<Reserva> retornarListaReservaPorRut(string rut)
        {
            var lista = from reserva in AccesoModelo.Modelo.RESERVA
                        join agenda in AccesoModelo.Modelo.AGENDA_MEDICO on reserva.ID_AGEN_MED equals
                        agenda.ID_AGEN_MED
                        where reserva.PERSONA_RUT == rut
                        select new
                        {
                            rut = reserva.PERSONA_RUT,
                            id_agenda = reserva.ID_AGEN_MED,
                            estado_reserva = reserva.ESTADO_RESERVA,
                            id_medico = agenda.ID_MEDICO,
                            hora = agenda.HORAS,
                            minuto = agenda.MINUTOS,

                        };

            return crearLista(lista.ToList());
        }

        public Boolean verificarReservas(String rut)
        {
            var lista = from reserva in AccesoModelo.Modelo.RESERVA
                        join agenda in AccesoModelo.Modelo.AGENDA_MEDICO on reserva.ID_AGEN_MED equals
                        agenda.ID_AGEN_MED
                        join pago in AccesoModelo.Modelo.PAGO on agenda.ID_AGEN_MED equals pago.ID_AGEN_MED
                        join atencion in AccesoModelo.Modelo.ATENCION on pago.ID_PAGO equals atencion.ID_PAGO
                        where reserva.PERSONA_RUT == rut && atencion.DESCRIPCION_ATENCION.Equals("Espera")
                        select reserva;

            if (!lista.Any())
            {
                return true;
            }
            else
            {
                if (lista.Count() > 2)
                {
                    return true;
                }
                return false;
            }
        }

        public bool eliminarReserva(int id_agenda, string rut)
        {
            try
            {
                Backend.Datos.RESERVA r = AccesoModelo.Modelo.RESERVA.FirstOrDefault(rev => rev.ID_AGEN_MED == id_agenda && rev.PERSONA_RUT == rut);
                AccesoModelo.Modelo.DeleteObject(r);
                AccesoModelo.Modelo.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
