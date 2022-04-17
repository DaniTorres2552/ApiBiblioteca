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
    public class t02_autorController : ApiController

    {
        private Model1 db = new Model1();
        Respuesta vObjRespuesta = new Respuesta();
        Libro vObjLibro = new Libro();

        // GET: api/t02_autor
        public IQueryable<t02_autor> Gett02_autor()
        {
            return db.t02_autor;
        }

        // GET: api/t02_autor/5
        [ResponseType(typeof(t02_autor))]
        public IHttpActionResult Gett02_autor(int id)
        {
            t02_autor t02_autor = db.t02_autor.Find(id);
            if (t02_autor == null)
            {
                return NotFound();
            }

            return Ok(t02_autor);
        }

        // PUT: api/t02_autor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt02_autor(int id, t02_autor t02_autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            if (id != t02_autor.f02_rowid)
            {
                return BadRequest();
            }
            

            db.Entry(t02_autor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t02_autorExists(id))
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

        // POST: api/t02_autor
        [ResponseType(typeof(t02_autor))]
        public IHttpActionResult Postt02_autor(t02_autor t02_autor)
        {
            try
            {
                db.t02_autor.Add(t02_autor);
                db.SaveChanges();
                vObjRespuesta.vBoolRespuesta = true;
                vObjRespuesta.vStrMensaje = "Autor agregado con exito";
                vObjRespuesta.vObjData = t02_autor;
                
                return Ok(vObjRespuesta);

            }

            catch(Exception ex)
            {
                vObjRespuesta.vStrMensaje = "Error al crear registro: " + ex.Message;
                vObjRespuesta.vBoolRespuesta = false;
            }
            return Ok(vObjRespuesta);

            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t02_autorExists(t02_autor.f02_rowid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = t02_autor.f02_nombre }, t02_autor);
        }

        // DELETE: api/t02_autor/5
        [ResponseType(typeof(t02_autor))]
        public IHttpActionResult Deletet02_autor(string id)
        {
            t02_autor t02_autor = db.t02_autor.Find(id);
            if (t02_autor == null)
            {
                return NotFound();
            }

            db.t02_autor.Remove(t02_autor);
            db.SaveChanges();

            return Ok(t02_autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t02_autorExists(int id)
        {
            return db.t02_autor.Count(e => e.f02_rowid == id) > 0;
        }
    }
}