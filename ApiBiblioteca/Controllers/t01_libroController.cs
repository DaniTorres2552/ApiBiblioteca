using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiBiblioteca.Models;
using ApiBiblioteca.Models.Response;
using ApiBiblioteca.BussinesLogic;

namespace ApiBiblioteca.Controllers
{
    public class t01_libroController : ApiController
    {
        private Model1 db = new Model1();
        Respuesta vObjRespuesta = new Respuesta();
        Libro vObjLibro = new Libro();


        // GET: api/t01_libro
        public IQueryable<t01_libro> Gett01_libro()
        {
            return db.t01_libro;            
        }

        /// <summary>
        /// Devuelve un libro por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/t01_libro/5
        [ResponseType(typeof(t01_libro))]
        public IHttpActionResult Gett01_libro(int id)
        {
            t01_libro t01_libro = db.t01_libro.Find(id);
            if (t01_libro == null)
            {
                return NotFound();
            }

            return Ok(t01_libro);
        }

        public IHttpActionResult GetlibroXId(int pvRowid)
        {
            vObjRespuesta.vBoolRespuesta = false;

            try
            {
                var vLst = db.t01_libro.Select(vCampos => new { vCampos.f01_rowid,
                                                                vCampos.f01_titulo,
                                                                vCampos.f01_fecha,
                                                                vCampos.f01_genero, 
                                                                vCampos.f01_num_paginas, 
                                                                vCampos.f01_autor})
                                        .Where(vCampos => vCampos.f01_rowid.Equals(pvRowid)).ToList();
                vObjRespuesta.vBoolRespuesta = true;
                vObjRespuesta.vStrMensaje = "Se encontro el registro con exito";
                vObjRespuesta.vObjData = vLst;

            }
            catch (Exception ex)
            {
                vObjRespuesta.vBoolRespuesta = false;
                vObjRespuesta.vStrMensaje = "Se encontro un problema en la busqueda: " + ex.Message;
            }
            return Ok(vObjRespuesta);
        }

        // PUT: api/t01_libro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt01_libro(int id, t01_libro t01_libro)
        {

            //if (!AutorExiste(t01_libro.f01_autor))
            if (!vObjLibro.AutorExiste(t01_libro.f01_autor))
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != t01_libro.f01_rowid)
            {
                return BadRequest();
            }


            db.Entry(t01_libro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t01_libroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/t01_libro
        [ResponseType(typeof(t01_libro))]
        public IHttpActionResult Postt01_libro(t01_libro t01_libro)
        {
            vObjRespuesta.vBoolRespuesta = false;

            try
            {
                // Se valida el maximo de registros permitidos
                if (vObjLibro.CantRegistros(t01_libro.f01_fecha) >= 2)
                {
                    vObjRespuesta.vStrMensaje = "No es posible registrar el libro, se alcanzó el máximo permitido.";
                    vObjRespuesta.vBoolRespuesta = false;
                    return Ok(vObjRespuesta);
                }

                if (vObjLibro.AutorExiste(t01_libro.f01_autor))
                {
                    /*
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    */

                    db.t01_libro.Add(t01_libro);

                    try
                    {
                        db.SaveChanges();
                        vObjRespuesta.vBoolRespuesta = true;
                        vObjRespuesta.vStrMensaje = "Libro registrado con exito";
                        vObjRespuesta.vObjData = t01_libro;
                    }
                    catch (DbUpdateException)
                    {
                        if (t01_libroExists(t01_libro.f01_rowid))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    //return CreatedAtRoute("DefaultApi", new { id = t01_libro.f01_titulo }, t01_libro);
                    return Ok(vObjRespuesta);
                }
                else
                {
                    vObjRespuesta.vBoolRespuesta = false;
                    vObjRespuesta.vStrMensaje = "El autor del libro no está registrado";
                    vObjRespuesta.vObjData = t01_libro;
                }
            }
            catch (Exception Ex)
            {
                vObjRespuesta.vStrMensaje = "Error al crear registro: " + Ex.Message;
                vObjRespuesta.vBoolRespuesta = false;
            }
            return Ok(vObjRespuesta);
        }
        /*
        
        // POST: api/PostLibroFiltro
        public IHttpActionResult PostLibroFiltro(t01_libro t01_libro)
        {
            vObjRespuesta.vBoolRespuesta = false;

            try
            {
                var vVarLista = db.t01_libro.Where(x => x.f01_titulo.Contains(pvTitulo))
                                            .Select(x => new {x.f01_rowid,
                                                              x.f01_titulo,
                                                              x.f01_fecha,
                                                              x.f01_genero,
                                                              x.f01_num_paginas,
                                                              x.f01_autor}).ToList();
                vObjRespuesta.vBoolRespuesta = true;
                vObjRespuesta.vStrMensaje = "Registro encontrado con exito";
                vObjRespuesta.vObjData = vVarLista;


            }
            catch (Exception Ex)
            {
                vObjRespuesta.vStrMensaje = "Error al crear registro: " + Ex.Message;
                vObjRespuesta.vBoolRespuesta = false;
            }

            return Ok(vObjRespuesta);

        }
        */
        

        // DELETE: api/t01_libro/5
        [ResponseType(typeof(t01_libro))]
        public IHttpActionResult Deletet01_libro(string id)
        {
            t01_libro t01_libro = db.t01_libro.Find(id);
            if (t01_libro == null)
            {
                return NotFound();
            }

            db.t01_libro.Remove(t01_libro);
            db.SaveChanges();

            return Ok(t01_libro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t01_libroExists(int id)
        {
            return db.t01_libro.Count(e => e.f01_rowid == id) > 0;
        }        


    }
}