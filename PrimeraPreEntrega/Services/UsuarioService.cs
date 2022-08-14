using PrimeraPreEntrega.Models;
using PrimeraPreEntrega.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntrega.Services
{
    internal class UsuarioService
    {
        public string ValidateSession(string userName, string password)
        {
            UsuarioRepository _usuarioRepository = new UsuarioRepository();

            List<Usuario> Usuarios = _usuarioRepository.GetUsuarios();

            bool isValidUser = false;
            bool isValidPassword = false;

            isValidUser = ValidateUser(Usuarios, userName.ToUpper());

            if (isValidUser)
            {

                isValidPassword = ValidatePassword(Usuarios, password.ToUpper());

            }

            if (isValidUser && isValidPassword)
            {
                return "ingreso Exitoso";//tranquilamente podriamos retornar el usuario o cualquier otra cosa.
            }
            else
            {
                return "usuario o contraseña invalida";
            }
        }

        private bool ValidateUser(List<Usuario> Usuarios, string UpperUserName)
        {
            foreach (var item in Usuarios)
            {
                if (item.NombreUsuario.ToUpper().Equals(UpperUserName))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidatePassword(List<Usuario> Usuarios, string UpperPassword)
        {
            foreach (var item in Usuarios)
            {
                if (item.Contraseña.ToUpper().Equals(UpperPassword))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
