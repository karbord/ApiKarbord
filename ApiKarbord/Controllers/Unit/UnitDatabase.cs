using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiKarbord.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ApiKarbord.Controllers.Unit
{
    public static class UnitDatabase
    {
        public static ApiModel db;
        class testMaster
        {
            public string TABLE_SCHEMA { get; set; }
        }

        //اتصال به دیتابیس با توجه به گروه و سال 

        public static string DatabaseName(string ace, string sal, string group)
        {
            string dbName;
            if (string.IsNullOrEmpty(ace) || string.IsNullOrEmpty(sal) || string.IsNullOrEmpty(group))
            {
                if (ace == "Config")
                {
                    return "Ace_Config";
                }
                else
                    return null;
            }
            else
            {

                dbName = "ACE_" + ace;
                //dbName += ace == "AFI" ? "1" : "5";
                dbName += group + sal;
                return dbName;
            }
        }
        //ایجاد کانکشن استرینگ 
        //اگر سایت ترو باشد یعنی به اس کیو ال ای پی ای
        public static string CreateConnectionString(string dataBaseName)
        {
            try
            {
                string serverName;
                string userName;
                string password;
                // خواندن اطلاعات اتصال به اس کیو ال
                if (string.IsNullOrEmpty(dataBaseName))
                {
                    serverName = UnitPublic.MyIniServer.Read("serverName");
                    userName = UnitPublic.MyIniServer.Read("userName");
                    password = UnitPublic.MyIniServer.Read("password");
                    dataBaseName = "guouhfgr_Report";
                }
                else
                {
                    serverName = UnitPublic.MyIni.Read("serverName");
                    userName = UnitPublic.MyIni.Read("userName");
                    password = UnitPublic.MyIni.Read("password");
                }
                string connection = String.Format(
                                    //  @"data source = {0};initial catalog = {1};user id = {2}; password = {3}; MultipleActiveResultSets = True; App = EntityFramework",
                                    @"data source = {0};initial catalog = {1};persist security info = True;user id = {2}; password = {3};  multipleactiveresultsets = True; application name = EntityFramework",
                 serverName, dataBaseName, userName, password);
                return connection;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static string CreateConnectionString(bool api)
        {
            try
            {
                string serverName;
                string userName;
                string password;
                if (api)
                {
                    serverName = UnitPublic.MyIni.Read("serverName");
                    userName = UnitPublic.MyIni.Read("userName");
                    password = UnitPublic.MyIni.Read("password");
                }
                else
                {
                    serverName = UnitPublic.MyIniServer.Read("serverName");
                    userName = UnitPublic.MyIniServer.Read("userName");
                    password = UnitPublic.MyIniServer.Read("password");
                }
                string connection = String.Format(
                                    @"data source = {0};initial catalog = {1};persist security info = True;user id = {2}; password = {3}; multipleactiveresultsets = True; application name = EntityFramework",
                   serverName, "master", userName, password);
                return connection;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        //اگر سایت ترو باشد یعنی به اس کیو ال ای پی ای
        public static Boolean CreateConection(string ace, string sal, string group)
        {
            try
            {
                string conStr = CreateConnectionString(DatabaseName(ace, sal, group));
                if (string.IsNullOrEmpty(conStr))
                {
                    return false;
                }
                db = new ApiModel(conStr);
                //db.Configuration.ProxyCreationEnabled = false;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        //اگر سایت ترو باشد یعنی به اس کیو ال ای پی ای
        public static Boolean TestSqlServer(bool api)
        {
            try
            {
                string conStr = CreateConnectionString(api);
                db = new ApiModel(conStr);
                var table = db.Database.SqlQuery<testMaster>("use master SELECT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES");
                if (table.Count() == 0) //اگر جدولی در دیتابیس مستر پیدا نشد 
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
