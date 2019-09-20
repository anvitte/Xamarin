using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEssentials_FullDemo.Models
{
    [Table("Phone_Tb")]
    public class PhoneDialerModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int DialerId { get; set; }
        public string PhoneNumber { get; set; }
        public String Name { get; set; }

    }
}
