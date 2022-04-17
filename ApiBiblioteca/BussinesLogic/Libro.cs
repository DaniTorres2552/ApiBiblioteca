using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiBiblioteca.Models;
using ApiBiblioteca.Models.Response;

namespace ApiBiblioteca.BussinesLogic
{
    public class Libro : ILibro
    {
        private Model1 db = new Model1();
        Respuesta vObjRespuesta = new Respuesta();

        int ILibro.vIntId { get; set; }
        string ILibro.vStrTitulo { get; set; }
        DateTime ILibro.vDtmFecha { get; set; }
        int ILibro.vIntNumPag { get; set; }
        string ILibro.vStrAutor { get; set; }

        /// <summary>
        /// Metodo para validar si el autor del libro existe
        /// </summary>
        /// <param name="pvStrnombre"></param>
        /// <returns></returns>
        public bool AutorExiste(string pvStrnombre)
        {
            return db.t02_autor.Count(e => e.f02_nombre == pvStrnombre) > 0;
        }

        /// <summary>
        /// Metodo para validar la cantidad de registros permitidos
        /// </summary>
        /// <param name="vDtmFecha"></param>
        /// <returns></returns>
        public int CantRegistros(DateTime vDtmFecha)

        {
            int vIntTotal = 0;

            try
            {
                var vLst = db.t01_libro.Select(vCampos => new { vCampos.f01_fecha })
                                        .Where(vCampos => vCampos.f01_fecha.Equals(vDtmFecha)).ToList();
                vIntTotal = vLst.Count;

            }
            catch (Exception ex)
            {
                vObjRespuesta.vStrMensaje = ex.Message;
            }
            return vIntTotal;
        }

    }
}