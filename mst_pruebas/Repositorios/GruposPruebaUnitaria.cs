using lib_entidades.Modelos;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using lib_repositorios;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class GruposPruebaUnitaria
    {
        private IGruposRepositorio? iRepositorio = null;
        private Grupos? entidad = null;

        public GruposPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-BB2FKGR\\DEV;database=db_MensajeriaI;Integrated Security=True;TrustServerCertificate=true;";
            iRepositorio = new GruposRepositorio(conexion);
        }
        

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Guardar()
        {
            entidad = new Grupos()
            {
                Nombre = "diosdado"
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }


        private void Modificar()
        {
            entidad!.Nombre = "diosdado2.0";
            entidad = iRepositorio!.Modificar(entidad!);
            Assert.IsTrue(entidad!.Nombre == "diosdado2.0");
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);
            Assert.IsTrue(entidad.Id != 0);
        }
      
    }
}