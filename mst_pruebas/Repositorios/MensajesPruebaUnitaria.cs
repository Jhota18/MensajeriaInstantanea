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
//    public class MensajesPruebaUnitaria
//    {
//        private IMensajesRepositorio? iRepositorio = null;
//        private Mensajes? entidad = null;

//        public MensajesPruebaUnitaria()
//        {
//            var conexion = new Conexion();
//            conexion.StringConnection = "server=DESKTOP-BB2FKGR\\DEV;database=db_MensajeriaI;Integrated Security=True;TrustServerCertificate=true;";
//            iRepositorio = new MensajesRepositorio(conexion);
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
//            entidad = new Mensajes()
//            {
//                Contenido = "mensaje prueba",
//                Fecha = DateTime.Now,
//                Estado = 2,
//                Borrado = false,
//                De = 3,
//                Para = 1,
//                Grupo = null

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
//            entidad!.Borrado = true;
//            entidad = iRepositorio!.Modificar(entidad!);
//            Assert.IsTrue(entidad!.Borrado == true);
//        }

//        private void Borrar()
//        {
//            entidad = iRepositorio!.Borrar(entidad!);
//            Assert.IsTrue(entidad.Id != 0);
//        }
//    }
//}
