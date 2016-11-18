using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Medico
    {
        public int Id_medico { get; set; }
        public string Especialidad { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public int id_centro {get; set;}




        private Backend.Datos.MEDICO RecuperaMedico(string rut)
        {
            try
            {
                return AccesoModelo.Modelo.MEDICO.FirstOrDefault(med => med.PERSONA_RUT == rut);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       
        public int RecuperarIdMedico(string rut)
        {
            try
            {

                return (int) RecuperaMedico(rut).ID_MEDICO;

            }
            catch (Exception)
            {

                return 0;
            }
        }


        private List<Medico> GenerarListado(List<Backend.Datos.MEDICO> entidadMedico)
        {
            
            List<Medico> medicos = new List<Medico>();

            foreach (Backend.Datos.MEDICO m in entidadMedico)
            {
                Persona p = new Persona();
                Medico medico = new Medico();

                medico.Id_medico = (int)m.ID_MEDICO;
                medico.Especialidad = m.ESPECIALIDAD;
                medico.Rut = m.PERSONA_RUT;
                medico.Nombre = p.RecuperaNombre(m.PERSONA_RUT);
                medico.id_centro = (int)m.ID_CENTRO;

                medicos.Add(medico);

            }

            return medicos;
        }


        public List<Medico> ListadoMedico()
        {
            var medicos = AccesoModelo.Modelo.MEDICO;

            return GenerarListado(medicos.ToList());
        }

        public IQueryable<string> RutMedico(int id)
        {
            var med = from medico in AccesoModelo.Modelo.MEDICO
                         where medico.ID_MEDICO == id
                         select medico.PERSONA_RUT;

            return med ;

        }


        public IQueryable<string> distinto()
        {
            var dest = (from medico in AccesoModelo.Modelo.MEDICO
                        select medico.ESPECIALIDAD).Distinct();

            return dest;
        }

        public List<Medico> listarMedicoxCentroyEsp(int[] id, string especialidad)
        {
           
            
            try
            {
                    var listaIds = id.ToList();
                    var listar = AccesoModelo.Modelo.MEDICO.Where(li => listaIds.Contains((int)li.ID_CENTRO) && li.ESPECIALIDAD == especialidad);

                    return GenerarListado(listar.ToList());
                   
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
                          
        }
       
    }
}
