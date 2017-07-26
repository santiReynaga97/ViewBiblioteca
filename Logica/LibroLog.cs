using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LibroLog
    {
        private Modelos.LibroDAO LibroDAO = new Modelos.LibroDAO();

        public bool Registrar(Entidad.Libro parLibro)
        {
            bool f = false;
            
                if (parLibro.IdCategoria > 2)
                {
                    return LibroDAO.Registrar(parLibro);
                }
                else
                    return f;
        }

        public bool Actualizar(Entidad.Libro parLibro)
        {
            return LibroDAO.Actualizar(parLibro);

        }

        public List<Entidad.Libro> ListaLibros()
        {

            return LibroDAO.TraerListaLibros();

        }

        public Entidad.Libro TrarLibro(int id)
        {

            return LibroDAO.ObtenerLibro(id);

        }

        public bool Eliminar(int id)
        {

            return LibroDAO.Eliminar(id);
        }
    }
}
