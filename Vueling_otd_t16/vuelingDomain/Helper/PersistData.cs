using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace vuelingDomain.Helper
{
    public static class PersistData
    {
        private static string _filePath = @"Data\";
        public static void Save(DataTable datatable, string name)
        {
            
            string path = $"{_filePath}{name}.txt";
            if (File.Exists(path)) File.Delete(path);
            Directory.CreateDirectory(_filePath);
            File.WriteAllText(path, JsonConvert.SerializeObject(datatable));
        }

    }
}