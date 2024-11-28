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
//    public class EstadosPruebaUnitaria
//    {
//        private IEstadosRepositorio? iRepositorio = null;
//        private Estados? entidad = null;

//        public EstadosPruebaUnitaria()
//        {
//            var conexion = new Conexion();
//            conexion.StringConnection = "server=DESKTOP-BB2FKGR\\DEV;database=db_MensajeriaI;Integrated Security=True;TrustServerCertificate=true;";
//            iRepositorio = new EstadosRepositorio(conexion);
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
//            entidad = new Estados()
//            {
//                Nombre = "estado prueba"
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
//            entidad!.Nombre = "estado prueba2";
//            entidad = iRepositorio!.Modificar(entidad!);
//            Assert.IsTrue(entidad!.Nombre == "estado prueba2");
//        }

//        private void Borrar()
//        {
//            entidad = iRepositorio!.Borrar(entidad!);
//            Assert.IsTrue(entidad.Id != 0);
//        }
        
//    }
//}
