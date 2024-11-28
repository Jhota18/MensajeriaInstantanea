//using lib_entidades.Modelos;
//using lib_repositorios.Implementaciones;
//using lib_repositorios.Interfaces;
//using lib_repositorios;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace mst_pruebas.Repositorios
//{
//    [TestClass]
//    public class DetallesPruebaUnitaria
//    {
//        private IDetallesRepositorio? iRepositorio = null;
//        private Detalles? entidad = null;

//        public DetallesPruebaUnitaria()
//        {
//            var conexion = new Conexion();
//            conexion.StringConnection = "server=DESKTOP-BB2FKGR\\DEV;database=db_MensajeriaI;Integrated Security=True;TrustServerCertificate=true;";
//            iRepositorio = new DetallesRepositorio(conexion);
//        }


//        [TestMethod]
//        public void Ejecutar()
//        {
//            Guardar();
//            Listar();
//            Buscar();
//            Modificar();
//            Borrar();
//        }

//        private void Guardar()
//        {
//            entidad = new Detalles()
//            {
//                Mensaje = 1,
//                Para = 2,
//                Estado = 2
//            }; 
//            entidad = iRepositorio!.Guardar(entidad);
//            Assert.IsTrue(entidad.Id != 0);
//        }

//        private void Listar()
//        {
//            var lista = iRepositorio!.Listar();
//            Assert.IsTrue(lista.Count > 0);
//        }

//        public void Buscar()
//        {
//            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
//            Assert.IsTrue(lista.Count > 0);
//        }


//        private void Modificar()
//        {
//            entidad!.Estado = 1;
//            entidad = iRepositorio!.Modificar(entidad!);
//            Assert.IsTrue(entidad!.Estado == 1);
//        }

//        private void Borrar()
//        {
//            entidad = iRepositorio!.Borrar(entidad!);
//            Assert.IsTrue(entidad.Id != 0);
//        }
//    }
//}
