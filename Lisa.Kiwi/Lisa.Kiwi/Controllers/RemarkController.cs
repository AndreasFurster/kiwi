﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Lisa.Kiwi.Data.Models;

namespace Lisa.Kiwi.WebApi.Controllers
{
    public class RemarkController : ODataController
    {
        private KiwiContext db = new KiwiContext();

        // GET odata/Remark
        [Queryable]
        public IQueryable<Remark> GetRemark()
        {
            return db.Remark;
        }

        // GET odata/Remark(5)
        [Queryable]
        public SingleResult<Remark> GetRemark([FromODataUri] int key)
        {
            return SingleResult.Create(db.Remark.Where(remark => remark.Id == key));
        }

        // PUT odata/Remark(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Remark remark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != remark.Id)
            {
                return BadRequest();
            }

            db.Entry(remark).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemarkExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(remark);
        }

        // POST odata/Remark
        public async Task<IHttpActionResult> Post(Remark remark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Remark.Add(remark);
            await db.SaveChangesAsync();

            return Created(remark);
        }

        // PATCH odata/Remark(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Remark> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Remark remark = await db.Remark.FindAsync(key);
            if (remark == null)
            {
                return NotFound();
            }

            patch.Patch(remark);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemarkExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(remark);
        }

        // DELETE odata/Remark(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Remark remark = await db.Remark.FindAsync(key);
            if (remark == null)
            {
                return NotFound();
            }

            db.Remark.Remove(remark);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Remark(5)/Report
        [Queryable]
        public SingleResult<Report> GetReport([FromODataUri] int key)
        {
            return SingleResult.Create(db.Remark.Where(m => m.Id == key).Select(m => m.Report));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RemarkExists(int key)
        {
            return db.Remark.Count(e => e.Id == key) > 0;
        }
    }
}
