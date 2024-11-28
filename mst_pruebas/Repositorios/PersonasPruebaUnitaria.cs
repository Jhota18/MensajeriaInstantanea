//using lib_entidades.Modelos;
//using lib_repositorios;
//using lib_repositorios.Implementaciones;
//using lib_repositorios.Interfaces;


//namespace mst_pruebas.Repositorios
//{
//    [TestClass]
//    public class PersonasPruebaUnitaria
//    {
//        private IPersonasRepositorio? iRepositoriop = null;
//        private Personas? entidad = null;

//        public PersonasPruebaUnitaria()
//        {
//            var conexion = new Conexion();
//            conexion.StringConnection = "server=DESKTOP-SH03HU4\\SQLEXPRESS;database=db_MensajeriaI;Integrated Security=True;TrustServerCertificate=true;";
//            iRepositorio = new PersonasRepositorio(conexion);
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
//            entidad = new Personas()
//            {
//                Cedula="2016",
//                Nombre="diosdado"
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
//            var lista = iRepositorio!.Buscar(x => x.Id ==entidad!.Id);
//            Assert.IsTrue(lista.Count > 0);
//        }


//        private void Modificar()
//        {
//            entidad!.Cedula = "2017";
//            entidad = iRepositorio!.Modificar(entidad!);
//            Assert.IsTrue(entidad!.Cedula == "2017");
//        }

//        private void Borrar()
//        {
//            entidad = iRepositorio!.Borrar(entidad!);
//            Assert.IsTrue(entidad.Id != 0);
//        }
//    }
//}
