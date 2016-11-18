using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class AccesoModelo
    {
        private static Backend.Datos.GalenosEntities _modelo;

        public static Backend.Datos.GalenosEntities Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new Datos.GalenosEntities();

                }

                return _modelo;

            }
        }

        public AccesoModelo()
        {
 
        }
    }
}
