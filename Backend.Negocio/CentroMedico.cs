using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class CentroMedico
    {
        public int id_cetro { get; set; }
        public string nombreCentro { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string region { get; set; }


        private List<CentroMedico> GenerarListadoCentro(List<Backend.Datos.CENTRO_MEDICO> entidadCentroMedico)
        {
            List<CentroMedico> centros = new List<CentroMedico>();

            foreach (Backend.Datos.CENTRO_MEDICO c in entidadCentroMedico)
            {
                CentroMedico centro = new CentroMedico();

                centro.id_cetro = (int)c.ID_CENTRO;
                centro.nombreCentro = c.NOMBRE_CENTRO;
                centro.direccion = c.DIRECCION;
                centro.comuna = c.COMUNA;
                centro.region = c.REGION;

                centros.Add(centro);


            }

            return centros;
        }


        public List<CentroMedico> ListadoCentroMedico()
        {
            var centros = AccesoModelo.Modelo.CENTRO_MEDICO;

            return GenerarListadoCentro(centros.ToList());
        }
    }


    
}
