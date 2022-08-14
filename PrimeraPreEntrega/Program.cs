using PrimeraPreEntrega.Models;
using PrimeraPreEntrega.Repository;
using PrimeraPreEntrega.Services;
using System;

namespace PrimeraPreEntrega
{
    class Program
    {
        static void Main(string[] args)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            //List<Usuario> usuariosLista = usuarioRepository.GetUsuarios();

            //foreach (var item in usuariosLista)
            //{
            //    Console.WriteLine(item.NombreUsuario);
            //}

            UsuarioService usuarioService = new UsuarioService();
            Console.WriteLine(usuarioService.ValidateSession("tcasazza", "SoyTobiasCasazza"));


            //ProductoRepository usuarioRepository = new ProductoRepository();
            //List<Producto> usuariosLista = usuarioRepository.GetProductos();

            //foreach (var item in usuariosLista)
            //{
            //    Console.WriteLine(item.Descripciones);
            //}



            //ProductoVendidoRepository usuarioRepository = new ProductoVendidoRepository();
            //List<ProductoVendido> usuariosLista = usuarioRepository.GetProductosVendidos();

            //foreach (var item in usuariosLista)
            //{
            //    Console.WriteLine(item.IdProducto);
            //}

            //VentaRepository ventaRepository = new VentaRepository();
            //List<Venta> ventas = ventaRepository.GetVentas();

            //foreach (var item in ventas)
            //{
            //    Console.WriteLine(item.Id);
            //}
        }
    }

}