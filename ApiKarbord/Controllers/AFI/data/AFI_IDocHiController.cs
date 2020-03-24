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
using ApiKarbord.Controllers.Unit;
using ApiKarbord.Models;

namespace ApiKarbord.Controllers.AFI.data
{
    public class AFI_IDocHiController : ApiController
    {

        // PUT: api/AFI_IDocHi/5
        [Route("api/AFI_IDocHi/{ace}/{sal}/{group}/")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAFI_IDocHi(string ace, string sal, string group, AFI_IDocHi aFI_IDocHi)
        {
            string value = "";
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
                    string sql = string.Format(
                         @"DECLARE	@return_value nvarchar(50),
		                            @DocNo_Out int
                          EXEC	@return_value = [dbo].[Web_SaveIDoc_HU]
		                            @DOCNOMODE = {0},
		                            @INSERTMODE = {1},
		                            @MODECODE = {2} ,
		                            @DOCNO = {3},
		                            @STARTNO = {4},
		                            @ENDNO = {5},
		                            @BRANCHCODE = {6},
		                            @USERCODE = '''{7}''',
		                            @SERIALNUMBER = {8},
		                            @DOCDATE = '{9}',
		                            @DOCTIME = {10},
		                            @SPEC = '{11}',
		                            @MDOCDATE = {12},
		                            @TANZIM = {13},
		                            @TAHIESHODE = {14},
		                            @CUSTCODE = '{15}',
		                            @KALAPRICECODE = {16},
                                    @InvCode = '{17}',
                                    @Status = '{18}',
                                    @Footer = '{19}',
                                    @Taeed={20},
		                            @DOCNO_OUT = @DOCNO_OUT OUTPUT
                            SELECT	'return_value' = @return_value +'-'+  CONVERT(nvarchar, @DOCNO_OUT)",
                            aFI_IDocHi.DocNoMode,
                            aFI_IDocHi.InsertMode,
                            aFI_IDocHi.ModeCode,
                            aFI_IDocHi.DocNo,
                            aFI_IDocHi.StartNo,
                            aFI_IDocHi.EndNo,
                            aFI_IDocHi.BranchCode,
                            aFI_IDocHi.UserCode,
                            aFI_IDocHi.SerialNumber,
                            aFI_IDocHi.DocDate ?? string.Format("{ 0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)),
                            aFI_IDocHi.DocTime,
                            aFI_IDocHi.Spec,
                            aFI_IDocHi.mDocDate, // DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"), //2018-04-03 00:00:00.000
                            aFI_IDocHi.Tanzim,
                            aFI_IDocHi.TahieShode,
                            aFI_IDocHi.CustCode,
                            aFI_IDocHi.KalaPriceCode ?? 0,
                            aFI_IDocHi.InvCode,
                            aFI_IDocHi.Status,
                            //UnitPublic.ConvertTextWebToWin(aFI_IDocHi.Footer),
                            aFI_IDocHi.Footer,
                            aFI_IDocHi.Taeed
                            );
                    value = UnitDatabase.db.Database.SqlQuery<string>(sql).Single();

                    await UnitDatabase.db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Ok(value);
        }

        // POST: api/AFI_IDocHi
        [Route("api/AFI_IDocHi/{ace}/{sal}/{group}")]
        [ResponseType(typeof(AFI_IDocHi))]
        public async Task<IHttpActionResult> PostAFI_IDocHi(string ace, string sal, string group, AFI_IDocHi aFI_IDocHi)
        {
            string value = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UnitDatabase.CreateConection(ace, sal, group))
            { 
                try
                {
                    string sql = string.Format(
                         @"DECLARE	@return_value nvarchar(50),
		                            @DocNo_Out int
                          EXEC	@return_value = [dbo].[Web_SaveIDoc_HI]
		                            @DOCNOMODE = {0},
		                            @INSERTMODE = {1},
		                            @MODECODE = {2} ,
		                            @DOCNO = {3},
		                            @STARTNO = {4},
		                            @ENDNO = {5},
		                            @BRANCHCODE = {6},
		                            @USERCODE = '''{7}''',
		                            @SERIALNUMBER = {8},
		                            @DOCDATE = '{9}',
		                            @DOCTIME = {10},
		                            @SPEC = '{11}',
		                            @MDOCDATE = {12},
		                            @TANZIM = {13},
		                            @TAHIESHODE = {14},
		                            @CUSTCODE = '{15}',
		                            @KALAPRICECODE = {16},
                                    @InvCode = '{17}',
                                    @Eghdam = '''{18}''',
		                            @DOCNO_OUT = @DOCNO_OUT OUTPUT
                            SELECT	'return_value' = @return_value +'-'+  CONVERT(nvarchar, @DOCNO_OUT)",
                            aFI_IDocHi.DocNoMode,
                            aFI_IDocHi.InsertMode,
                            aFI_IDocHi.ModeCode,
                            aFI_IDocHi.DocNo,
                            aFI_IDocHi.StartNo,
                            aFI_IDocHi.EndNo,
                            aFI_IDocHi.BranchCode,
                            aFI_IDocHi.UserCode,
                            aFI_IDocHi.SerialNumber,
                            aFI_IDocHi.DocDate ?? string.Format("{ 0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)),
                            aFI_IDocHi.DocTime,
                            aFI_IDocHi.Spec,
                            aFI_IDocHi.mDocDate, // DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"), //2018-04-03 00:00:00.000
                            aFI_IDocHi.Tanzim,
                            aFI_IDocHi.TahieShode,
                            aFI_IDocHi.CustCode ?? "null",
                            aFI_IDocHi.KalaPriceCode ?? 0,
                            aFI_IDocHi.InvCode,
                            aFI_IDocHi.Eghdam);
                    value = UnitDatabase.db.Database.SqlQuery<string>(sql).Single();
                    if (!string.IsNullOrEmpty(value))
                    {
                        await UnitDatabase.db.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Ok(value);
        }

        // DELETE: api/AFI_IDocHi/5
        [Route("api/AFI_IDocHi/{ace}/{sal}/{group}/{SerialNumber}/{ModeCode}")]
        [ResponseType(typeof(AFI_IDocHi))]
        public async Task<IHttpActionResult> DeleteAFI_IDocHi(string ace, string sal, string group, long SerialNumber, string ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    string sql = string.Format(@"DECLARE	@return_value int
                                                 EXEC	@return_value = [dbo].[Web_SaveIDoc_Del]
		                                                @SerialNumber = {0}
                                                 SELECT	'Return Value' = @return_value"
                                                , SerialNumber);

                    int value = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                    if (value > 0)
                    {
                        await UnitDatabase.db.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            /*string sql1 = @"select top(100) SerialNumber,DocNo,DocDate,ThvlCode,thvlname,Spec,KalaPriceCode,InvCode,ModeCode,
                   Status,PaymentType,Footer,Tanzim,Taeed,FinalPrice,Eghdam,ModeName,InvName  
                   from Web_IDocH where ModeCode in ";
            if (ModeCode == "in")
                sql1 += " (101,102,103,106,108,110) ";
            else if (ModeCode == "out")
                sql1 += " (104,105,107,109,111)";

            sql1 += " order by DocNo desc";
            var listIDocH = UnitDatabase.db.Database.SqlQuery<Web_IDocHMini>(sql1);*/
            return Ok(1);
        }

    }
}