using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinEssentials_FullDemo.Droid;
using XamarinEssentials_FullDemo.Interfaces;
using Android;
using static Android.InputMethodServices.InputMethodService;
using Android.Content;
using Android.Content.Res;
using XamarinEssentials_FullDemo.Models;
[assembly: Dependency(typeof(AssetsFilesLoaderImplementation))]
namespace XamarinEssentials_FullDemo.Droid
{

    public class AssetsFilesLoaderImplementation : IAssestFilesLoader
    {
        public List<FileSystemModel> LstAllAssets = new List<FileSystemModel>();
        public List<FileSystemModel> GetAllFilesName(string path)
        {
            try
            {
                AssetManager assets = Forms.Context.Assets;
                foreach (var item in assets.List("notes"))
                {
                    LstAllAssets.Add(new FileSystemModel() { NoteName = item });

                }
                return LstAllAssets;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}