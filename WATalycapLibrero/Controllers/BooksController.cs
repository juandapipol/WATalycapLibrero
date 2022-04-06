using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DA;

namespace WATalycapLibrero.Controllers
{
    public class BooksController : ApiController
    {
        private DBTALYCAPEntities dbContext = new DBTALYCAPEntities();

        //Muestra todos los libros
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            using (DBTALYCAPEntities dbEntities = new DBTALYCAPEntities())
            {
                return dbEntities.Books.ToList();
            }
        }

        //Obtiene un libro por id
        [HttpGet]
        public Book Get(int id)
        {
            using (DBTALYCAPEntities dbEntities = new DBTALYCAPEntities())
            {
                return dbEntities.Books.FirstOrDefault(m => m.id == id);
            }
        }

        //Agrega un libro
        [HttpPost]
        public IHttpActionResult AddBook([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return Ok(book);
            }
            else
            {
                return BadRequest();
            }
        }

        //Actualiza un libro
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                var bookExists = dbContext.Books.Count(c => c.id == id) > 0;

                if (bookExists)
                {
                    dbContext.Entry(book).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //Elimina un libro por id
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = dbContext.Books.Find(id);

            if (book != null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();

                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
