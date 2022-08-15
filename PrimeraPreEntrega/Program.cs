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
            //UsuarioRepository usuarioRepository = new UsuarioRepository();
            //Usuario usuario = usuarioRepository.GetUsuariosByUserName("eperez");

            //Console.WriteLine(usuario.NombreUsuario);
            //Console.WriteLine(usuario.Id);
            //Console.WriteLine(usuario.Contraseña);
            //Console.WriteLine(usuario.Apellido);


            //ProductoRepository productoRepository = new ProductoRepository();
            //List<Producto> pro = productoRepository.GetProductosByIdUser(1);

            //foreach (var item in pro)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.PrecioVenta);
            //    Console.WriteLine(item.Descripciones);
            //}

            //ProductoVendidoRepository productoRepository = new ProductoVendidoRepository();
            //List<Producto> pro = productoRepository.GetProductosVendidosByIdUser(1);

            //foreach (var item in pro)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.PrecioVenta);
            //    Console.WriteLine(item.Descripciones);
            //}


            //VentaRepository productoRepository = new VentaRepository();
            //List<Venta> pro = productoRepository.GetVentasByIdUser(1);

            //foreach (var item in pro)
            //{
            //    Console.WriteLine(item.Id);
            //}



            UsuarioService usuarioService = new UsuarioService();

            Usuario userValido = usuarioService.ValidateSession("tcasazza", "SoyTobiasCasazza");

            Console.WriteLine(userValido.Id);



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