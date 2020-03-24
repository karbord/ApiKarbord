using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiKarbord.Models;
using ApiKarbord.Controllers.Unit;

namespace ApiKarbord.Controllers.AFI.report
{
    public class MojodiKalasController : ApiController
    {

        // GET: api/MojodiKalas?ace=AFI&sal=1397&group=01
        public IQueryable<MojodiKala> GetMojodiKala(string ace , string sal , string group)
        {
            //نمایش کالا
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string FirstDate = "1390/01/01";
                string LastDate = "1399/12/29";
                string sqlQuary = String.Format(@"select [KalaCode],[KalaName],[KalaUnitName1],[InvName],
                                              [KGruName],[AAmount1]
                                              from dbo.Web_TrzIKala('{0}','{1}') where 1=1 ", FirstDate, LastDate);
                var list = (from p in UnitDatabase.db.MojodiKala.SqlQuery(sqlQuary) select p).AsQueryable();
                return list;
            }
            return UnitDatabase.db.MojodiKala;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitDatabase.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MojodiKalaExists(string id)
        {
            return UnitDatabase.db.MojodiKala.Count(e => e.Code == id) > 0;
        }
    }
}