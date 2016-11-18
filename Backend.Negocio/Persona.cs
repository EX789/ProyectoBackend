using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Negocio
{
    public class Persona
    {
        public string RutPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public int  Telefono { get; set; }
        public string Correo { get; set; }
        public int id_perfil { get; set; }
        public string Pass { get; set; }


        public bool CrearPersona()
        {
            try
            {
                Backend.Datos.PERSONA p = new Datos.PERSONA();

                p.RUT = this.RutPersona;
                p.NOMBRE = this.NombrePersona;
                p.APELLIDO_PAT = this.ApellidoP;
                p.APELLIDO_MAT = this.ApellidoM;
                p.DIRECCION = this.Direccion;
                p.COMUNA = this.Comuna;
                p.TELEFONO = this.Telefono;
                p.CORREO = this.Correo;
                p.ID_PERFIL = 4;
                p.CLAVE = this.Pass;
                AccesoModelo.Modelo.AddToPERSONA(p);
                AccesoModelo.Modelo.SaveChanges();


                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        private Backend.Datos.PERSONA RecuperaPersona(string rut)
        {
            try
            {
                return AccesoModelo.Modelo.PERSONA.FirstOrDefault(pac => pac.RUT == rut);


            }
            catch (Exception)
            {

                return null;
            }
        }


       

        public bool ValidaPersona(string rut, string pass)
        {


            try
            {

                return RecuperaPersona(rut).CLAVE == pass;

                 
            }
            catch (Exception)
            {

                return false;
            }
 
        }

        public Backend.Negocio.Persona RecuperaDatos(string rut)
        {
            
                Persona p = new Persona();

                p.RutPersona = RecuperaPersona(rut).RUT;
                p.NombrePersona = RecuperaPersona(rut).NOMBRE;
                p.ApellidoP = RecuperaPersona(rut).APELLIDO_PAT;
                p.ApellidoM = RecuperaPersona(rut).APELLIDO_MAT;
                p.Direccion = RecuperaPersona(rut).DIRECCION;
                p.Comuna = RecuperaPersona(rut).COMUNA;
                p.Telefono = (int)RecuperaPersona(rut).TELEFONO;
                p.Correo = RecuperaPersona(rut).CORREO;
                p.id_perfil = (int)RecuperaPersona(rut).ID_PERFIL;
                p.Pass = RecuperaPersona(rut).CLAVE;


                return p;

         

            
        }

        public string RecuperaNombre(string rut)
        {
            try
            {
                return RecuperaPersona(rut).NOMBRE;
            }
            catch (Exception)
            {
                
                return string.Empty;
            }
        }

        public IQueryable<string> RecuperaPerfil(string rut)
        {

        
           
                var per = from persona in AccesoModelo.Modelo.PERSONA
                             join perfil in AccesoModelo.Modelo.PERFIL on persona.ID_PERFIL equals
                             perfil.ID_PERFIL
                             where persona.RUT == rut
                             select perfil.NOMBRE_PERFIL;


            

                return per;
           
        }

        
    }
}
