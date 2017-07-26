using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using MySql.Data.MySqlClient;
using System.Data;

namespace Modelos
{
    public class LibroDAO
    {
        //Metodo para registrar a la base de datos
        public bool Registrar(Libro objLibro)
        {
            
            bool respuesta = false;

            try
            {         
                {
                    MySqlCommand sql = new MySqlCommand("LibroAgregar", Conection.conn);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@pNom", objLibro.Nombre);
                    sql.Parameters.AddWithValue("@PDes", objLibro.Descripcion);
                    sql.Parameters.AddWithValue("@pIdAutor", objLibro.IdAutor);
                    sql.Parameters.AddWithValue("@pIdCat", objLibro.IdCategoria);
                    sql.Parameters.AddWithValue("@pAnioP", objLibro.AnioPublicacion);
                    sql.Parameters.AddWithValue("@pIdTip", objLibro.IdTipoLibro);
                    sql.Parameters.AddWithValue("@pCant", objLibro.CantidadPaginas);
                    Conection.conn.Open();
                    sql.ExecuteNonQuery();                
                    respuesta = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            Conection.conn.Close();

            return respuesta;
        }

        public bool Actualizar(Libro objLibro)
        {
            bool respuesta = false;

            try
            {
                {
                    MySqlCommand sql = new MySqlCommand("LibroActualizar", Conection.conn);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@pNom", objLibro.Nombre);
                    sql.Parameters.AddWithValue("@PDes", objLibro.Descripcion);
                    sql.Parameters.AddWithValue("@pIdAutor", objLibro.IdAutor);
                    sql.Parameters.AddWithValue("@pIdCat", objLibro.IdCategoria);
                    sql.Parameters.AddWithValue("@pAnioP", objLibro.AnioPublicacion);
                    sql.Parameters.AddWithValue("@pIdTip", objLibro.IdTipoLibro);
                    sql.Parameters.AddWithValue("@pCant", objLibro.CantidadPaginas);
                    sql.Parameters.AddWithValue("pId",objLibro.Id);
                    Conection.conn.Open();
                    sql.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            Conection.conn.Close();

            return respuesta;
        }

        public List<Libro> TraerListaLibros()
        {
            

            List<Libro> ListaLibros = new List<Libro>();
            MySqlCommand com = new MySqlCommand("ListaLibros", Conection.conn);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();

            Conection.conn.Open();
            da.Fill(dt);
            Conection.conn.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                ListaLibros.Add(
                    new Libro
                    {

                        Id = Convert.ToInt32(dr["id"]),
                        Nombre = Convert.ToString(dr["nombre"]),
                        Descripcion = Convert.ToString(dr["descripcion"]),
                        IdAutor = Convert.ToInt32(dr["id_autor"]),
                        IdCategoria=Convert.ToInt32(dr["id_categoria"]),
                       // AnioPublicacion = Convert.ToDateTime(dr["anio_publicacion"]),
                        IdTipoLibro = Convert.ToInt32(dr["id_tipo_libro"]),
                        CantidadPaginas = Convert.ToInt32(dr["cantidad_paginas"])
                    }
                    );
            }
            return ListaLibros;  
        }

        public Libro ObtenerLibro(int id)
        {
            Libro objLibro = new Libro();
            try
            {
                
                MySqlCommand com = new MySqlCommand("ObtenerLibro", Conection.conn);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@pId", id);
                Conection.conn.Open();
                var dr = com.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    objLibro.Id = Convert.ToInt32(dr["id"]);
                    objLibro.Nombre = Convert.ToString(dr["nombre"]);
                    objLibro.Descripcion = Convert.ToString(dr["descripcion"]);
                    objLibro.IdAutor = Convert.ToInt32(dr["id_autor"]);
                    objLibro.IdCategoria = Convert.ToInt32(dr["id_categoria"]);
                    // AnioPublicacion = Convert.ToDateTime(dr["anio_publicacion"]);
                    objLibro.IdTipoLibro = Convert.ToInt32(dr["id_tipo_libro"]);
                    objLibro.CantidadPaginas = Convert.ToInt32(dr["cantidad_paginas"]);
                }
                Conection.conn.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return objLibro;
        }

        public bool Eliminar(int pId)
        {
            bool resultado = false;
            try
            {
                MySqlCommand sql = new MySqlCommand("LibroEliminar", Conection.conn);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@pId", pId);
                Conection.conn.Open();
                sql.ExecuteNonQuery();
                resultado = true;
                
            }
            catch (MySqlException ex)
            {
                throw;
            }
            Conection.conn.Close();
            return resultado;
        }
    }
}
