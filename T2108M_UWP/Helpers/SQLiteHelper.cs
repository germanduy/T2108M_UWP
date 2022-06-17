using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Windows.Storage;
using System.IO;

namespace T2108M_UWP.Helpers
{
    class SQLiteHelper
    {
        private readonly string dbName = "t2108m.db";
        private static SQLiteHelper sQLiteHelper;
        public ISQLiteConnection SQLiteConnection { get; set; }
        private SQLiteHelper()
        {
            // connect db
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            SQLiteConnection = new SQLiteConnection(path);
            // tao table Student(Id,Name,Age,Address)
            var sql_txt = @"create table if not exists Student(Id integer primary key,
                            Name varchar(255),Age integer, Address varchar(255))";
            var statement = SQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }
        public static SQLiteHelper GetInstance()
        {
            if(sQLiteHelper == null)
                sQLiteHelper = new SQLiteHelper();
            return sQLiteHelper;
        }
    }
}
