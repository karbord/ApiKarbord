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
    public class AFI_FDocHiController : ApiController
    {
        // PUT: api/AFI_FDocHi/5
        [Route("api/AFI_FDocHi/{ace}/{sal}/{group}/")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAFI_FDocHi(string ace, string sal, string group, AFI_FDocHi aFI_FDocHi)
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
                    string sql = string.Format(@"EXEC	[dbo].[Web_Calc_AddMin_EffPrice]
		                                            @serialNumber = {0},
                                                    @forSale = {1},
                                                    @custCode = {2},
                                                    @TypeJob = {3},                                                    
                                                    @Spec1 = '{4}',
                                                    @Spec2 = '{5}',
                                                    @Spec3 = '{6}',
                                                    @Spec4 = '{7}',
                                                    @Spec5 = '{8}',
                                                    @Spec6 = '{9}',
                                                    @Spec7 = '{10}',
                                                    @Spec8 = '{11}',
                                                    @Spec9 = '{12}',
                                                    @Spec10 = '{13}',                                                    
                                                    @MP1 = {14},
                                                    @MP2 = {15},
                                                    @MP3 = {16},
		                                            @MP4 = {17},
		                                            @MP5 = {18},
		                                            @MP6 = {19},
		                                            @MP7 = {20},
		                                            @MP8 = {21},
		                                            @MP9 = {22},
		                                            @MP10 = {23} ",
                                                    aFI_FDocHi.SerialNumber,
                                                    aFI_FDocHi.ModeCode < 54 ? 1 : 0,
                                                    aFI_FDocHi.CustCode ?? "null",
                                                    0,
                                                    aFI_FDocHi.AddMinSpec1,
                                                    aFI_FDocHi.AddMinSpec2,
                                                    aFI_FDocHi.AddMinSpec3,
                                                    aFI_FDocHi.AddMinSpec4,
                                                    aFI_FDocHi.AddMinSpec5,
                                                    aFI_FDocHi.AddMinSpec6,
                                                    aFI_FDocHi.AddMinSpec7,
                                                    aFI_FDocHi.AddMinSpec8,
                                                    aFI_FDocHi.AddMinSpec9,
                                                    aFI_FDocHi.AddMinSpec10,
                                                    Math.Abs(aFI_FDocHi.AddMinPrice1 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice2 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice3 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice4 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice5 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice6 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice7 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice8 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice9 ?? 0).ToString(),
                                                    Math.Abs(aFI_FDocHi.AddMinPrice10 ?? 0).ToString());
                    var result = UnitDatabase.db.Database.SqlQuery<AddMin>(sql).Where(c => c.Name != "").ToList();



                    foreach (var item in result)
                    {
                        if (item.Code == 1) aFI_FDocHi.AddMinPrice1 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 2) aFI_FDocHi.AddMinPrice2 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 3) aFI_FDocHi.AddMinPrice3 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 4) aFI_FDocHi.AddMinPrice4 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 5) aFI_FDocHi.AddMinPrice5 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 6) aFI_FDocHi.AddMinPrice6 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 7) aFI_FDocHi.AddMinPrice7 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 8) aFI_FDocHi.AddMinPrice8 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 9) aFI_FDocHi.AddMinPrice9 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                        if (item.Code == 10) aFI_FDocHi.AddMinPrice10 = Math.Round(item.AddMinPrice ?? 0, aFI_FDocHi.deghat);
                    }

                    var sql1 = string.Format(@"DECLARE	@return_value int
                            EXEC	@return_value = [dbo].[Web_FDocB_CalcAddMin]
		                                @serialNumber = {0},
		                                @deghat = {1},
                                        @forSale = {2},
		                                @MP1 = '{3}',
		                                @MP2 = '{4}',
		                                @MP3 = '{5}',
		                                @MP4 = '{6}',
		                                @MP5 = '{7}',
		                                @MP6 = '{8}',
		                                @MP7 = '{9}',
		                                @MP8 = '{10}',
		                                @MP9 = '{11}',
		                                @MP10 = '{12}'
                            SELECT	'Return Value' = @return_value",
                            aFI_FDocHi.SerialNumber,
                            aFI_FDocHi.deghat,
                            aFI_FDocHi.ModeCode < 54 ? 1 : 0,
                            aFI_FDocHi.AddMinPrice1,
                            aFI_FDocHi.AddMinPrice2,
                            aFI_FDocHi.AddMinPrice3,
                            aFI_FDocHi.AddMinPrice4,
                            aFI_FDocHi.AddMinPrice5,
                            aFI_FDocHi.AddMinPrice6,
                            aFI_FDocHi.AddMinPrice7,
                            aFI_FDocHi.AddMinPrice8,
                            aFI_FDocHi.AddMinPrice9,
                            aFI_FDocHi.AddMinPrice10);
                    int test = UnitDatabase.db.Database.SqlQuery<int>(sql1).Single();

                    string sql2 = string.Format(
                         @"DECLARE	@return_value nvarchar(50),
		                            @DocNo_Out int
                          EXEC	@return_value = [dbo].[Web_SaveFDoc_HU]
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
		                            @VSTRCODE = {16},
		                            @VSTRPER = {17},
		                            @PAKHSHCODE = '{18}',
		                            @KALAPRICECODE = {19},
		                            @ADDMINSPEC1 = '{20}',
		                            @ADDMINSPEC2 = '{21}',
		                            @ADDMINSPEC3 = '{22}',
		                            @ADDMINSPEC4 = '{23}',
		                            @ADDMINSPEC5 = '{24}',
		                            @ADDMINSPEC6 = '{25}',
		                            @ADDMINSPEC7 = '{26}',
		                            @ADDMINSPEC8 = '{27}',
		                            @ADDMINSPEC9 = '{28}',
		                            @ADDMINSPEC10 = '{29}',
		                            @ADDMINPRICE1 = '{30}',
		                            @ADDMINPRICE2 = '{31}',
		                            @ADDMINPRICE3 = '{32}',
		                            @ADDMINPRICE4 = '{33}',
		                            @ADDMINPRICE5 = '{34}',
		                            @ADDMINPRICE6 = '{35}',
		                            @ADDMINPRICE7 = '{36}',
		                            @ADDMINPRICE8 = '{37}',
		                            @ADDMINPRICE9 = '{38}',
		                            @ADDMINPRICE10 = '{39}',
                                    @InvCode = '{40}',
                                    @Status = '{41}',
									@PaymentType = {42},
                                    @Footer = '{43}',
                                    @Taeed={44},
		                            @DOCNO_OUT = @DOCNO_OUT OUTPUT
                            SELECT	'return_value' = @return_value +'-'+  CONVERT(nvarchar, @DOCNO_OUT)",
                            aFI_FDocHi.DocNoMode,
                            aFI_FDocHi.InsertMode,
                            aFI_FDocHi.ModeCode,
                            aFI_FDocHi.DocNo,
                            aFI_FDocHi.StartNo,
                            aFI_FDocHi.EndNo,
                            aFI_FDocHi.BranchCode,
                            aFI_FDocHi.UserCode,
                            aFI_FDocHi.SerialNumber,
                            aFI_FDocHi.DocDate ?? string.Format("{ 0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)),
                            aFI_FDocHi.DocTime,
                            aFI_FDocHi.Spec,
                            aFI_FDocHi.mDocDate, // DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"), //2018-04-03 00:00:00.000
                            aFI_FDocHi.Tanzim,
                            aFI_FDocHi.TahieShode,
                            aFI_FDocHi.CustCode ?? "null",
                            aFI_FDocHi.VstrCode,
                            aFI_FDocHi.VstrPer,
                            aFI_FDocHi.PakhshCode,
                            aFI_FDocHi.KalaPriceCode ?? 0,
                            aFI_FDocHi.AddMinSpec1,
                            aFI_FDocHi.AddMinSpec2,
                            aFI_FDocHi.AddMinSpec3,
                            aFI_FDocHi.AddMinSpec4,
                            aFI_FDocHi.AddMinSpec5,
                            aFI_FDocHi.AddMinSpec6,
                            aFI_FDocHi.AddMinSpec7,
                            aFI_FDocHi.AddMinSpec8,
                            aFI_FDocHi.AddMinSpec9,
                            aFI_FDocHi.AddMinSpec10,
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice1),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice2),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice3),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice4),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice5),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice6),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice7),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice8),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice9),
                            Math.Abs((decimal)aFI_FDocHi.AddMinPrice10),
                            aFI_FDocHi.InvCode,
                            aFI_FDocHi.Status,
                            aFI_FDocHi.PaymentType,
                            UnitPublic.ConvertTextWebToWin(aFI_FDocHi.Footer),
                            aFI_FDocHi.Taeed
                            );
                    value = UnitDatabase.db.Database.SqlQuery<string>(sql2).Single();

                    await UnitDatabase.db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Ok(value);
        }

        // POST: api/AFI_FDocHi
        [Route("api/AFI_FDocHi/{ace}/{sal}/{group}")]
        [ResponseType(typeof(AFI_FDocHi))]
        public async Task<IHttpActionResult> PostAFI_FDocHi(string ace, string sal, string group, AFI_FDocHi aFI_FDocHi)
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
                          EXEC	@return_value = [dbo].[Web_SaveFDoc_HI]
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
		                            @CUSTCODE = {15},
		                            @VSTRCODE = {16},
		                            @VSTRPER = {17},
		                            @PAKHSHCODE = '{18}',
		                            @KALAPRICECODE = {19},
		                            @ADDMINSPEC1 = '{20}',
		                            @ADDMINSPEC2 = '{21}',
		                            @ADDMINSPEC3 = '{22}',
		                            @ADDMINSPEC4 = '{23}',
		                            @ADDMINSPEC5 = '{24}',
		                            @ADDMINSPEC6 = '{25}',
		                            @ADDMINSPEC7 = '{26}',
		                            @ADDMINSPEC8 = '{27}',
		                            @ADDMINSPEC9 = '{28}',
		                            @ADDMINSPEC10 = '{29}',
		                            @ADDMINPRICE1 = {30},
		                            @ADDMINPRICE2 = {31},
		                            @ADDMINPRICE3 = {32},
		                            @ADDMINPRICE4 = {33},
		                            @ADDMINPRICE5 = {34},
		                            @ADDMINPRICE6 = {35},
		                            @ADDMINPRICE7 = {36},
		                            @ADDMINPRICE8 = {37},
		                            @ADDMINPRICE9 = {38},
		                            @ADDMINPRICE10 = {39},
                                    @InvCode = '{40}',
                                    @Eghdam = '''{41}''',
		                            @DOCNO_OUT = @DOCNO_OUT OUTPUT
                            SELECT	'return_value' = @return_value +'-'+  CONVERT(nvarchar, @DOCNO_OUT)",
                            aFI_FDocHi.DocNoMode,
                            aFI_FDocHi.InsertMode,
                            aFI_FDocHi.ModeCode,
                            aFI_FDocHi.DocNo,
                            aFI_FDocHi.StartNo,
                            aFI_FDocHi.EndNo,
                            aFI_FDocHi.BranchCode,
                            aFI_FDocHi.UserCode,
                            aFI_FDocHi.SerialNumber,
                            aFI_FDocHi.DocDate ?? string.Format("{ 0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)),
                            aFI_FDocHi.DocTime,
                            aFI_FDocHi.Spec,
                            aFI_FDocHi.mDocDate, // DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"), //2018-04-03 00:00:00.000
                            aFI_FDocHi.Tanzim,
                            aFI_FDocHi.TahieShode,
                            aFI_FDocHi.CustCode ?? "null",
                            aFI_FDocHi.VstrCode,
                            aFI_FDocHi.VstrPer,
                            aFI_FDocHi.PakhshCode,
                            aFI_FDocHi.KalaPriceCode ?? 0,
                            aFI_FDocHi.AddMinSpec1,
                            aFI_FDocHi.AddMinSpec2,
                            aFI_FDocHi.AddMinSpec3,
                            aFI_FDocHi.AddMinSpec4,
                            aFI_FDocHi.AddMinSpec5,
                            aFI_FDocHi.AddMinSpec6,
                            aFI_FDocHi.AddMinSpec7,
                            aFI_FDocHi.AddMinSpec8,
                            aFI_FDocHi.AddMinSpec9,
                            aFI_FDocHi.AddMinSpec10,
                            aFI_FDocHi.AddMinPrice1,
                            aFI_FDocHi.AddMinPrice2,
                            aFI_FDocHi.AddMinPrice3,
                            aFI_FDocHi.AddMinPrice4,
                            aFI_FDocHi.AddMinPrice5,
                            aFI_FDocHi.AddMinPrice6,
                            aFI_FDocHi.AddMinPrice7,
                            aFI_FDocHi.AddMinPrice8,
                            aFI_FDocHi.AddMinPrice9,
                            aFI_FDocHi.AddMinPrice10,
                            aFI_FDocHi.InvCode,
                            aFI_FDocHi.Eghdam);
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

        // DELETE: api/AFI_FDocHi/5
        [Route("api/AFI_FDocHi/{ace}/{sal}/{group}/{SerialNumber}/{ModeCode}")]
        [ResponseType(typeof(AFI_FDocHi))]
        public async Task<IHttpActionResult> DeleteAFI_FDocHi(string ace, string sal, string group, long SerialNumber, string ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    string sql = string.Format(@"DECLARE	@return_value int
                                                 EXEC	@return_value = [dbo].[Web_SaveFDoc_Del]
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

            /*
                        string sql1 = string.Format(@" select top(100)
                                                            SerialNumber,
                                                            DocNo,
                                                            DocDate,
                                                            CustCode,
                                                            CustName,
                                                            Spec,
                                                            KalaPriceCode,
                                                            InvCode,
                                                            AddMinPrice1,
                                                            AddMinPrice2,
                                                            AddMinPrice3,
                                                            AddMinPrice4,
                                                            AddMinPrice5,
                                                            AddMinPrice6,
                                                            AddMinPrice7,
                                                            AddMinPrice8,
                                                            AddMinPrice9,
                                                            AddMinPrice10,
                                                            ModeCode,
                                                            Status,
                                                            PaymentType,
                                                            Footer,
                                                            Tanzim,
                                                            Taeed,
                                                            FinalPrice,
                                                            Eghdam
                                                          from Web_FDocH where ModeCode = {0} ",
                                                     ModeCode.ToString());
                        sql1 += " order by DocNo desc ";

                        var listFDocH = UnitDatabase.db.Database.SqlQuery<Web_FDocHMini>(sql1); */
            return Ok(1);
        }

    }
}