using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiKarbord.Controllers.Unit;
using ApiKarbord.Models;

namespace ApiKarbord.Controllers.AFI.data
{
    public class AFI_FDocBiController : ApiController
    {
        // private ApiModel db = new ApiModel();

        // GET: api/AFI_FDocBi

        // PUT: api/AFI_FDocBi/5
        [Route("api/AFI_FDocBi/{ace}/{sal}/{group}/{BandNo}")]
        [ResponseType(typeof(AFI_FDocBi))]
        public async Task<IHttpActionResult> PutAFI_FDocBi(string ace, string sal, string group, long BandNo, AFI_FDocBi aFI_FDocBi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    string sql = string.Format(CultureInfo.InvariantCulture,
                          @"DECLARE	@return_value int
                            EXEC	@return_value = [dbo].[Web_SaveFDoc_BU]
		                            @SerialNumber = {0},
		                            @BandNo = {1},
		                            @KalaCode = N'{2}',
		                            @Amount1 = {3},
		                            @Amount2 = {4},
		                            @Amount3 = {5},
		                            @UnitPrice = {6},
		                            @TotalPrice = {7},
                                    @Discount = {8},
		                            @MainUnit = {9},
		                            @Comm = N'{10}',
                                    @Up_Flag = {11}
                            SELECT	'Return Value' = @return_value
                            ",
                        aFI_FDocBi.SerialNumber,
                        aFI_FDocBi.BandNo,
                        aFI_FDocBi.KalaCode,
                        aFI_FDocBi.Amount1 ?? 0,
                        aFI_FDocBi.Amount2 ?? 0,
                        aFI_FDocBi.Amount3 ?? 0,
                        aFI_FDocBi.UnitPrice ?? 0,
                        aFI_FDocBi.TotalPrice ?? 0,
                        aFI_FDocBi.Discount ?? 0,
                        aFI_FDocBi.MainUnit,
                        aFI_FDocBi.Comm,
                        aFI_FDocBi.Up_Flag);
                    int value = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                    if (value == 0)
                    {
                        await UnitDatabase.db.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Discount,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                          FROM Web_FDocB WHERE SerialNumber = {0}", aFI_FDocBi.SerialNumber);
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_FDocB>(sql1);
            return Ok(listFactor);
        }

        // POST: api/AFI_FDocBi
        [Route("api/AFI_FDocBi/{ace}/{sal}/{group}/{bandno}")]
        [ResponseType(typeof(AFI_FDocBi))]
        public async Task<IHttpActionResult> PostAFI_FDocBi(string ace, string sal, string group, long bandNo, AFI_FDocBi aFI_FDocBi)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    string fieldBandNo;
                    string tableName;
                    if (ace == "AFI1")
                    {
                        fieldBandNo = "BandNo";
                        tableName = "Afi1FDocB";
                    }
                    else
                    {
                        fieldBandNo = "Radif";
                        tableName = "fct5docb";
                    }


                    if (bandNo > 0)
                    {
                        string sqlUpdateBand = string.Format(@"DECLARE	@return_value int
                                                           EXEC	@return_value = [dbo].[Web_Doc_BShift]
	                                                            @TableName = '{0}',
                                                                @SerialNumber = {1},
                                                                @BandNo = {2},
                                                                @BandNoFld = '{3}'
                                                           SELECT	'Return Value' = @return_value",
                                                           tableName,
                                                           aFI_FDocBi.SerialNumber,
                                                           bandNo,
                                                           fieldBandNo);
                        int valueUpdateBand = UnitDatabase.db.Database.SqlQuery<int>(sqlUpdateBand).Single();
                    }
                    string sql = string.Format(CultureInfo.InvariantCulture,
                          @"DECLARE	@return_value int
                            EXEC	@return_value = [dbo].[Web_SaveFDoc_BI]
		                            @SerialNumber = {0},
		                            @BandNo = {1},
		                            @KalaCode = N'{2}',
		                            @Amount1 = {3},
		                            @Amount2 = {4},
		                            @Amount3 = {5},
		                            @UnitPrice = {6},
		                            @TotalPrice = {7},
                                    @Discount = {8},
		                            @MainUnit = {9},
		                            @Comm = N'{10}',
                                    @Up_Flag = {11}
                            SELECT	'Return Value' = @return_value
                            ",
                        aFI_FDocBi.SerialNumber,
                        bandNo == 0 ? aFI_FDocBi.BandNo.ToString() : bandNo.ToString(),
                        aFI_FDocBi.KalaCode,
                        aFI_FDocBi.Amount1 ?? 0,
                        aFI_FDocBi.Amount2 ?? 0,
                        aFI_FDocBi.Amount3 ?? 0,
                        aFI_FDocBi.UnitPrice ?? 0,
                        aFI_FDocBi.TotalPrice ?? 0,
                        aFI_FDocBi.Discount ?? 0,
                        aFI_FDocBi.MainUnit,
                        aFI_FDocBi.Comm,
                        aFI_FDocBi.Up_Flag);
                    int value = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                    if (value == 0)
                    {
                        await UnitDatabase.db.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Discount,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_FDocB WHERE SerialNumber = {0}", aFI_FDocBi.SerialNumber);
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_FDocB>(sql1);
            return Ok(listFactor);
        }

        // DELETE: api/AFI_FDocBi/5
        [Route("api/AFI_FDocBi/{ace}/{sal}/{group}/{SerialNumber}/{BandNo}")]
        [ResponseType(typeof(AFI_FDocBi))]
        public async Task<IHttpActionResult> DeleteAFI_FDocBi(string ace, string sal, string group, long SerialNumber, int BandNo)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {

                    //var list = UnitDatabase.db.AFI_FDocBi.First(c=>c.SerialNumber == SerialNumber && c.BandNo==BandNo);
                    //if (list == null)
                    //{
                    //    return NotFound();
                    //}
                    string sql = string.Format(@"DECLARE	@return_value int
                                                 EXEC	@return_value = [dbo].[Web_SaveFDoc_BD]
		                                                @SerialNumber = {0},
		                                                @BandNo = {1}
                                                 SELECT	'Return Value' = @return_value",
                                                SerialNumber,
                                                BandNo);

                    int value = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                    if (value == 0)
                    {
                        await UnitDatabase.db.SaveChangesAsync();
                    }

                    string sqlUpdateBand = string.Format(@"DECLARE	@return_value int
                                                           EXEC	@return_value = [dbo].[Web_Doc_BOrder]
	                                                            @TableName = '{0}',
                                                                @SerialNumber = {1},
                                                                @BandNoFld = '{2}'
                                                           SELECT	'Return Value' = @return_value",
                                                           "Web_FDocB",
                                                           SerialNumber,
                                                           "BandNo");
                    int valueUpdateBand = UnitDatabase.db.Database.SqlQuery<int>(sqlUpdateBand).Single();
                    //await UnitDatabase.db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Discount,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_FDocB WHERE SerialNumber = {0}", SerialNumber.ToString());
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_FDocB>(sql1);
            return Ok(listFactor);
        }



        /*  protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }

          private bool AFI_FDocBiExists(long id)
          {
              return db.AFI_FDocBi.Count(e => e.SerialNumber == id) > 0;
          }*/
    }
}