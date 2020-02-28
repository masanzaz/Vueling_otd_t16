using LoggerService;
using LoggerService.Interfaces;
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
        public static void SaveFile(DataTable datatable, string name)
        {
            try
            {
                string path = $"{_filePath}{name}";
                if (File.Exists(path)) File.Delete(path);
                Directory.CreateDirectory(_filePath);
                File.WriteAllText(path, JsonConvert.SerializeObject(datatable));
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ReadFile(string name)
        {
            try
            {
                string path = $"{_filePath}{name}";
                return File.ReadAllText(path);
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}