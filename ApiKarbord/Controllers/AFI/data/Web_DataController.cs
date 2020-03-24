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
using System.Web.Http.Results;
using ApiKarbord.Controllers.Unit;
using ApiKarbord.Models;
using Newtonsoft.Json;

namespace ApiKarbord.Controllers.AFI.data
{
    public class Web_DataController : ApiController
    {

        // GET: api/Web_Data/Cust لیست حسابها
        [Route("api/Web_Data/Cust/{ace}/{sal}/{group}/{forSale}")]
        public IQueryable<Web_Cust> GetWeb_Cust(string ace, string sal, string group, bool forSale)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                if (forSale)
                {

                    return UnitDatabase.db.Web_Cust.Where(c => c.CustMode == 0 || c.CustMode == 1);
                }
                else
                {
                    return UnitDatabase.db.Web_Cust.Where(c => c.CustMode == 0 || c.CustMode == 2);
                }
            }
            return null;
        }


        // GET: api/Web_Data/KalaPrice لیست گروه قیمت خرید و فروش
        [Route("api/Web_Data/KalaPrice/{ace}/{sal}/{group}/{insert}")]
        public IQueryable<Web_KalaPrice> GetWeb_KalaPrice(string ace, string sal, string group, bool insert)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                if (insert)
                    return UnitDatabase.db.Web_KalaPrice.Where(c => c.Cancel == false);
                else
                    return UnitDatabase.db.Web_KalaPrice;
            }
            return null;
        }


        // GET: api/Web_Data/KalaPriceB  لیست قیمت کالا بر اساس قیمت گروه
        [Route("api/Web_Data/KalaPriceB/{ace}/{sal}/{group}/{code}/{kalacode}")]
        public IQueryable<Web_KalaPriceB> GetWeb_KalaPriceB(string ace, string sal, string group, int code, string kalacode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {

                var list = UnitDatabase.db.Web_KalaPriceB.Where(c => c.Code == code && c.KalaCode == kalacode);
                return list;
            }
            return null;
        }


        // GET: api/Web_Data/Unit لیست واحد کالا
        [Route("api/Web_Data/Unit/{ace}/{sal}/{group}/{codekala}")]
        public IQueryable<Web_Unit> GetWeb_Unit(string ace, string sal, string group, string codeKala)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                var a = from p in UnitDatabase.db.Web_Unit where p.KalaCode == codeKala && p.Name != "" select p;
                return a;
            }
            return null;
        }

        // GET: api/Web_Data/Kala لیست کالا ها
        [Route("api/Web_Data/Kala/{ace}/{sal}/{group}")]
        public IQueryable<Web_Kala> GetWeb_Kala(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Kala;
            }
            return null;
        }

        // GET: api/Web_Data/Inv لیست انبار ها
        [Route("api/Web_Data/Inv/{ace}/{sal}/{group}")]
        public IQueryable<Web_Inv> GetWeb_Inv(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Inv;
            }
            return null;
        }

        // GET: api/Web_Data/Param لیست پارامتر ها  
        [Route("api/Web_Data/Param/{ace}/{sal}/{group}")]
        public IQueryable<Web_Param> GetWeb_Param(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Param;
            }
            return null;
        }

        // GET: api/Web_Data/Payment لیست نحوه پرداخت  
        [Route("api/Web_Data/Payment/{ace}/{sal}/{group}")]
        public IQueryable<Web_Payment> GetWeb_Payment(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Payment.OrderBy(c => c.OrderFld);
            }
            return null;
        }

        // GET: api/Web_Data/Status لیست وضعیت پرداخت  
        [Route("api/Web_Data/Status/{ace}/{sal}/{group}")]
        public IQueryable<Web_Status> GetWeb_Status(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                return UnitDatabase.db.Web_Status.OrderBy(c => c.OrderFld);
            }
            return null;
        }


        public class CalcAddmin
        {
            public bool forSale { get; set; }

            public long serialNumber { get; set; }

            public string custCode { get; set; }

            public byte typeJob { get; set; }
            public string spec1 { get; set; }
            public string spec2 { get; set; }
            public string spec3 { get; set; }
            public string spec4 { get; set; }
            public string spec5 { get; set; }
            public string spec6 { get; set; }
            public string spec7 { get; set; }
            public string spec8 { get; set; }
            public string spec9 { get; set; }
            public string spec10 { get; set; }

            public double? MP1 { get; set; }
            public double? MP2 { get; set; }
            public double? MP3 { get; set; }
            public double? MP4 { get; set; }
            public double? MP5 { get; set; }
            public double? MP6 { get; set; }
            public double? MP7 { get; set; }
            public double? MP8 { get; set; }
            public double? MP9 { get; set; }
            public double? MP10 { get; set; }
        }

        // Post: api/Web_Data/AddMin لیست کسورات و افزایشات   
        // [Route("api/Web_Data/AddMin/{ace}/{sal}/{group}/{forSale}/{serialNumber}/{custCode}/{TypeJob}/{Spec1}/{Spec2}/{Spec3}/{Spec4}/{Spec5}/{Spec6}/{Spec7}/{Spec8}/{Spec9}/{Spec10}/{MP1}/{MP2}/{MP3}/{MP4}/{MP5}/{MP6}/{MP7}/{MP8}/{MP9}/{MP10}/")]
        [ResponseType(typeof(CalcAddmin))]
        [Route("api/Web_Data/AddMin/{ace}/{sal}/{group}")]

        public async Task<IHttpActionResult> PostGetAddMin(string ace, string sal, string group, CalcAddmin calcAddmin)

        //
        //string spec1, string spec2, string spec3, string spec4, string spec5, string spec6, string spec7, string spec8, string spec9, string spec10,
        //string MP1, string MP2, string MP3, string MP4, string MP5, string MP6, string MP7, string MP8, string MP9, string MP10)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))

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
		                                            @MP10 = {23}
                                                    ",
                                                    calcAddmin.serialNumber,
                                                    calcAddmin.forSale,
                                                    calcAddmin.custCode ?? "null",
                                                    calcAddmin.typeJob,
                                                    calcAddmin.spec1,
                                                    calcAddmin.spec2,
                                                    calcAddmin.spec3,
                                                    calcAddmin.spec4,
                                                    calcAddmin.spec5,
                                                    calcAddmin.spec6,
                                                    calcAddmin.spec7,
                                                    calcAddmin.spec8,
                                                    calcAddmin.spec9,
                                                    calcAddmin.spec10,
                                                    calcAddmin.MP1 ?? 0,
                                                    calcAddmin.MP2 ?? 0,
                                                    calcAddmin.MP3 ?? 0,
                                                    calcAddmin.MP4 ?? 0,
                                                    calcAddmin.MP5 ?? 0,
                                                    calcAddmin.MP6 ?? 0,
                                                    calcAddmin.MP7 ?? 0,
                                                    calcAddmin.MP8 ?? 0,
                                                    calcAddmin.MP9 ?? 0,
                                                    calcAddmin.MP10 ?? 0);
                var result = UnitDatabase.db.Database.SqlQuery<AddMin>(sql).Where(c => c.Name != "").ToList();
                var jsonResult = JsonConvert.SerializeObject(result);
                return Ok(jsonResult);
            }
            return null;
        }

        // GET: api/Web_Data/FDocH اطلاعات تکمیلی فاکتور    
        [Route("api/Web_Data/FDocH/{ace}/{sal}/{group}/{serialNumber}/{ModeCode}")]
        public async Task<IQueryable<Web_FDocH>> GetWeb_FDocH(string ace, string sal, string group, long serialNumber, int ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                var a = UnitDatabase.db.Web_FDocH.Where(c => c.SerialNumber == serialNumber && c.ModeCode == ModeCode);
                return a;
            }
            return null;
        }


        // GET: api/Web_Data/FDocH لیست فاکتور    
        [Route("api/Web_Data/FDocH/{ace}/{sal}/{group}/{ModeCode}/top{select}/{userName}/{AccessSanad}")]
        public async Task<IHttpActionResult> GetAllWeb_FDocHMin(string ace, string sal, string group, int ModeCode, int select, string userName, bool accessSanad)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {

                string sql = "select ";
                if (select == 0)
                    sql += " top(100) ";
                sql += string.Format(@"         SerialNumber,                                   
                                                DocNo,
                                                SortDocNo,
                                                DocDate,
                                                CustCode,
                                                CustName,
                                                Spec,
                                                KalaPriceCode,
                                                InvCode,
                                                AddMinSpec1,
                                                AddMinSpec2,
                                                AddMinSpec3,
                                                AddMinSpec4,
                                                AddMinSpec5,
                                                AddMinSpec6,
                                                AddMinSpec7,
                                                AddMinSpec8,
                                                AddMinSpec9,
                                                AddMinSpec10,
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
                if (accessSanad == false)
                    sql += " and Eghdam = '" + userName + "' ";
                sql += " order by SortDocNo desc ";
                var listFDocH = UnitDatabase.db.Database.SqlQuery<Web_FDocHMini>(sql);
                return Ok(listFDocH);
            }
            return null;
        }

        // GET: api/Web_Data/FDocH تعداد رکورد ها    
        [Route("api/Web_Data/FDocH/{ace}/{sal}/{group}/{ModeCode}")]
        public async Task<IHttpActionResult> GetWeb_FDocHCount(string ace, string sal, string group, int ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"SELECT count(SerialNumber) FROM Web_FDocH WHERE ModeCode = {0}", ModeCode);
                int count = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                return Ok(count);
            }
            return null;
        }

        // GET: api/Web_Data/FDocH آخرین تاریخ فاکتور    
        [Route("api/Web_Data/FDocH/LastDate/{ace}/{sal}/{group}/{ModeCode}")]
        public async Task<IHttpActionResult> GetWeb_FDocHLastDate(string ace, string sal, string group, int ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string lastdate;
                string sql = string.Format(@"SELECT count(DocDate) FROM Web_FDocH WHERE ModeCode = {0} ", ModeCode);
                int count = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                if (count > 0)
                {
                    sql = string.Format(@"SELECT top(1) DocDate FROM Web_FDocH WHERE ModeCode = {0} order by DocDate desc", ModeCode);
                    lastdate = UnitDatabase.db.Database.SqlQuery<string>(sql).Single();
                }
                else
                    lastdate = "";
                return Ok(lastdate);
            }
            return null;
        }

        // GET: api/Web_Data/FDocB اطلاعات تکمیلی فاکتور    
        [Route("api/Web_Data/FDocB/{ace}/{sal}/{group}/{serialNumber}")]
        public async Task<IHttpActionResult> GetWeb_FDocB(string ace, string sal, string group, long serialNumber)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Discount,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_FDocB WHERE SerialNumber = {0}", serialNumber);
                var listFactor = UnitDatabase.db.Database.SqlQuery<Web_FDocB>(sql);
                return Ok(listFactor);
            }
            return null;
        }


        //انبار---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: api/Web_Data/Thvl لیست حسابها
        [Route("api/Web_Data/Thvl/{ace}/{sal}/{group}")]
        public IQueryable<Web_Thvl> GetWeb_Thvl(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                var aa = UnitDatabase.db.Web_Thvl;
                return aa;
            }
            return null;
        }

        // GET: api/Web_Data/IDocH اطلاعات تکمیلی سند انبار  
        [Route("api/Web_Data/IDocH/{ace}/{sal}/{group}/{serialNumber}/{ModeCode}")]
        public IQueryable<Web_IDocH> GetWeb_IDocH(string ace, string sal, string group, long serialNumber, int ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                try
                {
                    var aa = UnitDatabase.db.Web_IDocH.Where(c => c.SerialNumber == serialNumber && c.ModeCode == ModeCode);
                    return aa;
                }
                catch (Exception e)
                {
                    throw;
                }

            }
            return null;
        }

        // GET: api/Web_Data/IDocH تعداد رکورد ها    
        [Route("api/Web_Data/IDocH/{ace}/{sal}/{group}/{ModeCode}")]
        public async Task<IHttpActionResult> GetWeb_IDocHCount(string ace, string sal, string group, string ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = "SELECT count(SerialNumber) FROM Web_IDocH WHERE ModeCode IN ";
                if (ModeCode == "in")
                    sql += " (101,102,103,106,108,110)";
                else if (ModeCode == "out")
                    sql += " (104,105,107,109,111)";
                int count = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();
                return Ok(count);
            }
            return null;
        }
        // GET: api/Web_Data/IDocH اخرین تاریخ    
        [Route("api/Web_Data/IDocH/LastDate/{ace}/{sal}/{group}/{ModeCode}")]
        public async Task<IHttpActionResult> GetWeb_IDocHLastDate(string ace, string sal, string group, string ModeCode)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = "SELECT top(1) DocDate FROM Web_IDocH WHERE ModeCode IN ";
                if (ModeCode == "in")
                    sql += " (101,102,103,106,108,110)";
                else if (ModeCode == "out")
                    sql += " (104,105,107,109,111)";

                sql += " order by DocDate desc ";

                string lastdate = UnitDatabase.db.Database.SqlQuery<string>(sql).Single();
                return Ok(lastdate);
            }
            return null;
        }

        // GET: api/Web_Data/IDocH لیست سند انبار   
        [Route("api/Web_Data/IDocH/{ace}/{sal}/{group}/{ModeCode}/top{select}/{invSelect}/{userName}/{AccessSanad}")]
        public async Task<IHttpActionResult> GetAllWeb_IDocHMin(string ace, string sal, string group, string ModeCode, int select, long invSelect, string userName, bool accessSanad)
        {

            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = "declare @enddate nvarchar(20) ";
                if (select == 1) // اگر انتخاب برای اخرین روز بود
                    sql += " select @enddate = max(DocDate) from Web_IDocH where ModeCode IN ";
                else if (select == 2) // اگر انتخاب برای اخرین ماه بود
                    sql += " select @enddate = substring(max(DocDate), 1, 7) from Web_IDocH where ModeCode IN ";

                if (ModeCode == "in" && (select == 1 || select == 2))
                    sql += " (101,102,103,106,108,110) ";
                else if (ModeCode == "out" && (select == 1 || select == 2))
                    sql += " (104,105,107,109,111)";

                sql += "select ";
                if (select == 0)
                    sql += " top(100) ";

                sql += "SerialNumber,DocNo,SortDocNo,DocDate,ThvlCode,thvlname,Spec,KalaPriceCode,InvCode,ModeCode," +
                       "Status,PaymentType,Footer,Tanzim,Taeed,FinalPrice,Eghdam,ModeName,InvName " +
                       "from Web_IDocH where ModeCode in ";
                if (ModeCode == "in")
                    sql += " (101,102,103,106,108,110) ";
                else if (ModeCode == "out")
                    sql += " (104,105,107,109,111)";

                if (invSelect > 0)
                {
                    sql += " and InvCode = '" + invSelect.ToString() + "' ";
                }

                if (select == 1)
                    sql += " and DocDate =  @enddate ";
                else if (select == 2)
                    sql += " and DocDate like  @enddate + '%' ";

                if (accessSanad == false)
                    sql += " and Eghdam = '" + userName + "' ";


                sql += " order by SortDocNo desc";
                var listIDocH = UnitDatabase.db.Database.SqlQuery<Web_IDocHMini>(sql);
                return Ok(listIDocH);
            }
            return null;
        }

        // GET: api/Web_Data/IDocB اطلاعات تکمیلی سند انبار   
        [Route("api/Web_Data/IDocB/{ace}/{sal}/{group}/{serialNumber}")]
        public async Task<IHttpActionResult> GetWeb_IDocB(string ace, string sal, string group, long serialNumber)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"SELECT SerialNumber,BandNo,KalaCode,KalaName,MainUnit,MainUnitName,Amount1,Amount2,Amount3,UnitPrice,TotalPrice,Comm,Up_Flag,DeghatR1,DeghatR2,DeghatR3,DeghatM1,DeghatM2,DeghatM3,DeghatR
                                         FROM Web_IDocB WHERE SerialNumber = {0}", serialNumber);
                var listIDocB = UnitDatabase.db.Database.SqlQuery<Web_IDocB>(sql);
                return Ok(listIDocB);
            }
            return null;
        }

        // GET: api/Web_Data/ اطلاعات لاگین   
        [Route("api/Web_Data/Login/{user}/{pass}/{param1}/{param2}")]
        public async Task<IHttpActionResult> GetWeb_Login(string user, string pass, string param1, string param2)
        {
            if (UnitDatabase.CreateConection("Config", "", ""))
            {
                if (pass == "null")
                    pass = "";
                string sql = string.Format(@" DECLARE  @return_value int
                                              EXEC     @return_value = [dbo].[Web_Login]
                                                       @Code1 = '{0}',
		                                               @UserCode = N'{1}',
                                                       @Code2 = '{2}',
		                                               @Psw = N'{3}'
                                              SELECT   'Return Value' = @return_value",
                                              param1, user, param2, pass);
                int value = UnitDatabase.db.Database.SqlQuery<int>(sql).Single();

                if (value == 1)
                    return Ok(1);
                else
                    return Ok(0);
            }
            return null;
        }


        // دریافت اطلاعات سالهای موجود در اس کیو ال متصل به ای پی ای
        public class DatabseSal
        {
            public string Name { get; set; }
        }

        [Route("api/Web_Data/DatabseSal/{ace}/{group}")]
        public async Task<IHttpActionResult> GetWeb_DatabseSal(string ace, string group)
        {
            if (UnitDatabase.CreateConection("Config", "", ""))
            {
                if (!string.IsNullOrEmpty(ace) || !string.IsNullOrEmpty(group))
                {
                    string sql = string.Format(@" select SUBSTRING(name,11,4) as name  from sys.sysdatabases
                                          where name like 'ACE_{0}%' and SUBSTRING(name,9,2) like '%{1}' order by name"
                                              , ace, group);
                    var listDB = UnitDatabase.db.Database.SqlQuery<DatabseSal>(sql).ToList();
                    return Ok(listDB);
                }
            }
            return null;
        }


        [Route("api/Web_Data/UpdatePrice/{ace}/{sal}/{group}/{serialnumber}")]
        [ResponseType(typeof(AFI_FDocBi))]
        public async Task<IHttpActionResult> PostWeb_UpdatePrice(string ace, string sal, string group, long serialnumber)
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
                            EXEC    @return_value = [dbo].[Web_FDocB_SetKalaPrice]
		                            @SerialNumber = {0}
                            SELECT  'Return Value' = @return_value",
                          serialnumber);
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
                                          FROM Web_FDocB WHERE SerialNumber = {0}", serialnumber);
            var listFactor = UnitDatabase.db.Database.SqlQuery<Web_FDocB>(sql1);
            return Ok(listFactor);
        }

        [Route("api/Web_Data/UpdatePriceAnbar/{ace}/{sal}/{group}/{serialnumber}")]
        [ResponseType(typeof(AFI_IDocBi))]
        public async Task<IHttpActionResult> PostWeb_UpdatePriceAnbar(string ace, string sal, string group, long serialnumber)
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
                            EXEC    @return_value = [dbo].[Web_IDocB_SetKalaPrice]
		                            @SerialNumber = {0}
                            SELECT  'Return Value' = @return_value",
                          serialnumber);
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
                                         FROM Web_IDocB WHERE SerialNumber = {0}", serialnumber);
            var listIDocB = UnitDatabase.db.Database.SqlQuery<Web_IDocB>(sql1);
            return Ok(listIDocB);
        }

        // گزارشات -----------------------------------------------------------------------------------------------------------------------
        public class TrzIObject
        {
            public string azTarikh { get; set; }
            public string taTarikh { get; set; }
            public string InvCode { get; set; }
            public string KGruCode { get; set; }
            public string KalaCode { get; set; }
        }

        // Post: api/Web_Data/TrzI گزارش موجودی انبار  
        // HE_Report_TrzIKala
        [Route("api/Web_Data/TrzI/{ace}/{sal}/{group}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostWeb_TrzIKala(string ace, string sal, string group, TrzIObject TrzIObject)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(CultureInfo.InvariantCulture,
                          @"select * FROM  dbo.Web_TrzIKala('{0}', '{1}') AS TrzI where 1 = 1 ",
                          TrzIObject.azTarikh, TrzIObject.taTarikh);
                if (TrzIObject.InvCode != "0")
                    sql += string.Format(" and InvCode = '{0}' ", TrzIObject.InvCode);

                if (TrzIObject.KGruCode != "0")
                    sql += string.Format(" and KGruCode = '{0}' ", TrzIObject.KGruCode);

                if (TrzIObject.KalaCode != "0")
                    sql += string.Format("and KalaCode = '{0}' ", TrzIObject.KalaCode);

                var listTrzI = UnitDatabase.db.Database.SqlQuery<Web_TrzIKala>(sql);
                return Ok(listTrzI);
            }
            return null;
        }



        // دریافت اطلاعات سطح دسترسی کاربر
        public class AccessUser
        {
            //public string Code { get; set; }
            //public string ProgName { get; set; }
            //public int GroupNo { get; set; }
            public string TrsName { get; set; } 
        }

        [Route("api/Web_Data/AccessUser/{ace}/{group}/{username}")]
        public async Task<IHttpActionResult> GetWeb_AccessUser(string ace, string group, string username)
        {
            if (UnitDatabase.CreateConection("Config", "", ""))
            {
                if (!string.IsNullOrEmpty(ace) || !string.IsNullOrEmpty(group) || !string.IsNullOrEmpty(username))
                {
                    string sql = string.Format(@" select distinct TrsName from Web_UserTrs('{0}',{1},'{2}')"
                                              , ace, group, username);

                    var listDB = UnitDatabase.db.Database.SqlQuery<AccessUser>(sql).ToList();
                    return Ok(listDB);
                }
            }

            return null;
        }

        public class AccessUserReport
        {
            public string Code { get; set; }
            public bool Trs { get; set; }
        }

        [Route("api/Web_Data/AccessUserReport/{ace}/{group}/{username}")]
        public async Task<IHttpActionResult> GetWeb_AccessUserReport(string ace, string group, string username)
        {
            if (UnitDatabase.CreateConection("Config", "", ""))
            {
                if (!string.IsNullOrEmpty(ace) || !string.IsNullOrEmpty(group) || !string.IsNullOrEmpty(username))
                {
                    string sql = string.Format(@"declare @ace nvarchar(5), @group int , @username nvarchar(20)
                                                 set @ace = '{0}'
                                                 set @group = {1}
                                                 set @username = '{2}'
                                                 select 'TiKala'as Code , [dbo].[Web_RprtTrs](@group,@ace,@username,'TiKala') as Trs
                                                 union all
                                                 select 'TiKalaMin'as Code , [dbo].[Web_RprtTrs](@group,@ace,@username,'TiKalaMin') as Trs"
                                               , ace, group, username);
                    var listDB = UnitDatabase.db.Database.SqlQuery<AccessUserReport>(sql).ToList();
                    return Ok(listDB);
                }
            }
            return null;
        }

        public class AccessUserReportErj
        {
            public string Code { get; set; }
            public bool Trs { get; set; }
        }

        [Route("api/Web_Data/AccessUserReportErj/{ace}/{group}/{username}")]
        public async Task<IHttpActionResult> GetWeb_AccessUserReportErj(string ace, string group, string username)
        {
            if (UnitDatabase.CreateConection("Config", "", ""))
            {
                if (!string.IsNullOrEmpty(ace) || !string.IsNullOrEmpty(group) || !string.IsNullOrEmpty(username))
                {
                    string sql = string.Format(@"declare @ace nvarchar(5), @group int , @username nvarchar(20)
                                                 set @ace = '{0}'
                                                 set @group = {1}
                                                 set @username = '{2}'
                                                 select 'DocK'as Code , [dbo].[Web_RprtTrs](@group,@ace,@username,'Fdoc') as Trs
                                                 union all
                                                 select 'DocKMin'as Code , [dbo].[Web_RprtTrs](@group,@ace,@username,'FdocMin') as Trs"
                                               , ace, group, username);
                    var listDB = UnitDatabase.db.Database.SqlQuery<AccessUserReportErj>(sql).ToList();
                    return Ok(listDB);
                }
            }
            return null;
        }



        ///////Erj-----------------------------------------------------------------------------------------------------------------------------

        public partial class Web_ErjCust
        {
            public string Code { get; set; }

            public string Name { get; set; }  

            public string Spec { get; set; }  
        }


        //  GET: api/Web_Data/ErjCust لیست مشتریان ارجاعات

        [Route("api/Web_Data/ErjCust/{ace}/{sal}/{group}")] 
        public async Task<IHttpActionResult> GetWeb_ErjCust(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"Select * from Web_ErjCust");
                var listDB = UnitDatabase.db.Database.SqlQuery<Web_ErjCust>(sql).ToList();

                return Ok(listDB);
            }
            return null;
        }
        public partial class Web_Khdt
        {

            public int Code { get; set; }

            public string Name { get; set; }

            public string Spec { get; set; }
        }


        //  GET: api/Web_Data/Khdt

        [Route("api/Web_Data/Khdt/{ace}/{sal}/{group}")]
        public async Task<IHttpActionResult> GetWeb_Khdt(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"Select * from Web_Khdt");
                var listDB = UnitDatabase.db.Database.SqlQuery<Web_Khdt>(sql).ToList();

                return Ok(listDB);
            }
            return null;
        }




        public class Web_ErjStatus
        {
            public int OrderFld { get; set; }
            public string Status { get; set; } 
        }

        // GET: api/Web_Data/ErjStatus لیست وضعیت پرداخت  
        [Route("api/Web_Data/ErjStatus/{ace}/{sal}/{group}")]
        public async Task<IHttpActionResult> GetWeb_ErjStatus(string ace, string sal, string group)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(@"Select * from Web_ErjStatus");
                var listDB = UnitDatabase.db.Database.SqlQuery<Web_ErjStatus>(sql).ToList();
                return Ok(listDB);
            }
            return null;
        }



        public partial class Web_ErjDocK
        {
            public long SerialNumber { get; set; }

            public long? DocNo { get; set; }

            public string DocDate { get; set; }

            public string Spec { get; set; }

            public string Status { get; set; }

            public string CustCode { get; set; }

            public int? KhdtCode { get; set; }

            public string Eghdam { get; set; }

            public string Tanzim { get; set; }

            public string DocDesc { get; set; }

            public string FinalComm { get; set; }

            public string EghdamComm { get; set; }

            public string MhltDate { get; set; }

            public string AmalDate { get; set; }

            public string EndDate { get; set; }

            public string SpecialComm { get; set; }

            public short? Mahramaneh { get; set; }

            public string F01 { get; set; }

            public string F02 { get; set; }

            public string F03 { get; set; }

            public string F04 { get; set; }

            public string F05 { get; set; }

            public string F06 { get; set; }

            public string F07 { get; set; }

            public string F08 { get; set; }

            public string F09 { get; set; }

            public string F10 { get; set; }

            public string F11 { get; set; }

            public string F12 { get; set; }

            public string F13 { get; set; }

            public string F14 { get; set; }

            public string F15 { get; set; }

            public string F16 { get; set; }

            public string F17 { get; set; }

            public string F18 { get; set; }

            public string F19 { get; set; }

            public string F20 { get; set; }

            public string CustName { get; set; }

            public string KhdtName { get; set; }

            public int HasNewErja { get; set; }

            public string ToUserCode { get; set; }

            public string MahramanehName { get; set; }
            
            public double? RjTime { get; set; }

        }

        public class ErjDocKObject
        {
            public string azTarikh { get; set; }
            public string taTarikh { get; set; }
            public string Status { get; set; }
            public string CustCode { get; set; }
            public string KhdtCode { get; set; }
            public string SrchSt { get; set; } // جستجو برای
        }


        // Post: api/Web_Data/ErjDocK گزارش فهرست پرونده ها  
        [Route("api/Web_Data/ErjDocK/{ace}/{sal}/{group}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostWeb_ErjDocK(string ace, string sal, string group, ErjDocKObject ErjDocKObject)
        {
            if (UnitDatabase.CreateConection(ace, sal, group))
            {
                string sql = string.Format(CultureInfo.InvariantCulture,
                          @"select * FROM  Web_ErjDocK('{0}') AS ErjDocK where 1 = 1 ",
                          ErjDocKObject.SrchSt);

                if (ErjDocKObject.azTarikh != "")
                    sql += string.Format(" and DocDate >= '{0}' ", ErjDocKObject.azTarikh);

                if (ErjDocKObject.taTarikh != "")
                    sql += string.Format(" and DocDate <= '{0}' ", ErjDocKObject.taTarikh);


                if (ErjDocKObject.Status != "")
                    sql += string.Format(" and Status = '{0}' ", ErjDocKObject.Status);

                if (ErjDocKObject.CustCode != "")
                {
                    sql += " and ( ";
                    string[] CustCode = ErjDocKObject.CustCode.Split('*');
                    for (int i = 0; i < CustCode.Length; i++)
                    {
                        if (i < CustCode.Length-1)
                            sql += string.Format("  CustCode = '{0}' Or ", CustCode[i]);
                        else
                            sql += string.Format("  CustCode = '{0}' )", CustCode[i]);
                    }
                    //sql += string.Format(" and CustCode = '{0}' ", ErjDocKObject.CustCode);
                }

                if (ErjDocKObject.KhdtCode != "")
                {
                    sql += " and ( ";
                    string[] KhdtCode = ErjDocKObject.KhdtCode.Split('*');

                    for (int i = 0; i < KhdtCode.Length; i++)
                    {
                        if (i < KhdtCode.Length - 1)
                            sql += string.Format("  KhdtCode = {0} Or ", KhdtCode[i]);
                        else
                            sql += string.Format("  KhdtCode = {0} )", KhdtCode[i]);
                    }

 
                }


                var listTrzI = UnitDatabase.db.Database.SqlQuery<Web_ErjDocK>(sql);
                return Ok(listTrzI);
            }
            return null;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
    }
}