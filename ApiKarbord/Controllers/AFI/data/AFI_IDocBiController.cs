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
    public class AFI_IDocBiController : ApiController
    {


        // PUT: api/AFI_IDocBi/5
        [Route("api/AFI_IDocBi/{ace}/{sal}/{group}/{BandNo}")]
        [ResponseType(typeof(AFI_IDocBi))]
        public async Task<IHttpActionResult> PutAFI_IDocBi(string ace, string sal, string group, long BandNo, AFI_IDocBi aFI_IDocBi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
                            EXEC	@return_value = [dbo].[Web_SaveIDoc_BU]
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
                        aFI_IDocBi.SerialNumber,
                        aFI_IDocBi.BandNo,
                        aFI_IDocBi.KalaCode,
                        aFI_IDocBi.Amount1 ?? 0,
                        aFI_IDocBi.Amount2 ?? 0,
                        aFI_IDocBi.Amount3 ?? 0,
                        aFI_IDocBi.UnitPrice ?? 0,
                        aFI_IDocBi.TotalPrice ?? 0,
                        aFI_IDocBi.Discount ?? 0,
                        aFI_IDocBi.MainUnit,
                        aFI_IDocBi.Comm,
                        aFI_IDocBi.Up_Flag);
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
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                          FROM Web_IDocB WHERE SerialNumber = {0}", aFI_IDocBi.SerialNumber);
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_IDocB>(sql1);
            return Ok(listFactor);
        }

        // POST: api/AFI_IDocBi
        [Route("api/AFI_IDocBi/{ace}/{sal}/{group}/{bandno}")]
        [ResponseType(typeof(AFI_IDocBi))]
        public async Task<IHttpActionResult> PostAFI_IDocBi(string ace, string sal, string group, long bandNo, AFI_IDocBi aFI_IDocBi)
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
                        tableName = "Afi1IDocB";
                        fieldBandNo = "BandNo";
                    }
                    else
                    {
                        tableName = "inv5docb";
                        fieldBandNo = "radif";
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
                                                           aFI_IDocBi.SerialNumber,
                                                           bandNo,
                                                           fieldBandNo);
                        int valueUpdateBand = UnitDatabase.db.Database.SqlQuery<int>(sqlUpdateBand).Single();
                    }
                    string sql = string.Format(CultureInfo.InvariantCulture,
                          @"DECLARE	@return_value int
                            EXEC	@return_value = [dbo].[Web_SaveIDoc_BI]
		                            @SerialNumber = {0},
		                            @BandNo = {1},
		                            @KalaCode = N'{2}',
		                            @Amount1 = {3},
		                            @Amount2 = {4},
		                            @Amount3 = {5},
		                            @UnitPrice = {6},
		                            @TotalPrice = {7},
		                            @MainUnit = {8},
		                            @Comm = N'{9}',
                                    @Up_Flag = {10}
                            SELECT	'Return Value' = @return_value
                            ",
                        aFI_IDocBi.SerialNumber,
                        bandNo == 0 ? aFI_IDocBi.BandNo.ToString() : bandNo.ToString(),
                        aFI_IDocBi.KalaCode,
                        aFI_IDocBi.Amount1 ?? 0,
                        aFI_IDocBi.Amount2 ?? 0,
                        aFI_IDocBi.Amount3 ?? 0,
                        aFI_IDocBi.UnitPrice ?? 0,
                        aFI_IDocBi.TotalPrice ?? 0,
                        aFI_IDocBi.MainUnit,
                        aFI_IDocBi.Comm,
                        aFI_IDocBi.Up_Flag);
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
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_IDocB WHERE SerialNumber = {0}", aFI_IDocBi.SerialNumber);
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_IDocB>(sql1);
            return Ok(listFactor);
        }

        // DELETE: api/AFI_IDocBi/5
        [Route("api/AFI_IDocBi/{ace}/{sal}/{group}/{SerialNumber}/{BandNo}")]
        [ResponseType(typeof(AFI_IDocBi))]
        public async Task<IHttpActionResult> DeleteAFI_IDocBi(string ace, string sal, string group, long SerialNumber, int BandNo)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    string sql = string.Format(@"DECLARE	@return_value int
                                                 EXEC	@return_value = [dbo].[Web_SaveIDoc_BD]
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
                                                           //ace == "Afi1" ? "Afi1IDocB" : "Inv5DocB",
                                                           "Web_IDocB",
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
            string sql1 = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_IDocB WHERE SerialNumber = {0}", SerialNumber.ToString());
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_IDocB>(sql1);
            return Ok(listFactor);
        }

    }
}