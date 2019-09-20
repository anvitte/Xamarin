using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.Interfaces
{
    public interface ILocalPhoneDB
    {
        Task<int> InsertIntoContactTable(PhoneDialerModel objModel);
        Task<int> DeletePhoneNumber(PhoneDialerModel objModel);
        List<PhoneDialerModel> GetAllContactNumbers();
    }
}
