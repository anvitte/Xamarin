using System;
using System.Collections.Generic;
using System.Text;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.Interfaces
{
    public interface IAssestFilesLoader
    {
        List<FileSystemModel> GetAllFilesName(string path);
    }
}
