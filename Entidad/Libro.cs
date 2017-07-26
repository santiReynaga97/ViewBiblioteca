using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Entidad
{
    public class Libro
    {
        
        private int? id;
        private string nombre;
        private string descripcion;
        private int idAutor;
        private int idCategoria;
        private DateTime anioPublicacion;
        private int idTipoLibro;
        private int cantidadPaginas;

        public int? Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdAutor { get => idAutor; set => idAutor = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public DateTime AnioPublicacion { get => anioPublicacion; set => anioPublicacion = value; }
        public int CantidadPaginas { get => cantidadPaginas; set => cantidadPaginas = value; }
        public int IdTipoLibro { get => idTipoLibro; set => idTipoLibro = value; }

        public Libro()
        {

        }

        public Libro(int? pId, string pnombre, string pdescripcion, int pidAutor, int pidCategoria, DateTime panioPublicacion, int pidTipoLibro, int pcantidadPaginas)
        {
            id = pId;
            nombre = pnombre;
            descripcion = pdescripcion;
            idAutor = pidAutor;
            idCategoria = pidCategoria;
            anioPublicacion = panioPublicacion;
            IdTipoLibro = pidTipoLibro;
            CantidadPaginas = pcantidadPaginas;
        }
        
    }
}
