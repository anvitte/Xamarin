using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinEssentials_FullDemo.Interfaces;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.Services
{
   
    public  class PhoneLocalDB :ILocalPhoneDB
    {
        public string cacheDirectoryPath { get; set; }
        public string appDataDirectoryPath { get; set; }

        public string databaseName = "PhoneBook.db3";
        public string databasePath = string.Empty;
        //SQL Connection
        SQLiteAsyncConnection sqlConnectionAsync = null;
        public PhoneLocalDB() {
            cacheDirectoryPath = FileSystem.CacheDirectory;
            databasePath = Path.Combine(cacheDirectoryPath, databaseName);
            appDataDirectoryPath = FileSystem.AppDataDirectory;
            sqlConnectionAsync = new SQLiteAsyncConnection(databasePath);
            sqlConnectionAsync.CreateTableAsync<PhoneDialerModel>();
        }
        public async Task<int> InsertIntoContactTable(PhoneDialerModel objModel)
        {
            int result = 0;
           
              
                if (objModel.DialerId != 0)
                {
                    result = await sqlConnectionAsync.UpdateAsync(objModel);
                }
                else
                {
                    result = await sqlConnectionAsync.InsertAsync(objModel);
                }
               
      
            return result;
        }
        public  List<PhoneDialerModel> GetAllContactNumbers() {
           var result=   sqlConnectionAsync.QueryAsync<PhoneDialerModel>("Select * from [Phone_Tb]");
            return result.Result;

        }
        public async Task<int> DeletePhoneNumber(PhoneDialerModel objModel)
        {
            return await sqlConnectionAsync.DeleteAsync(objModel);
        }
    }
  
}
