using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Comum
{
    public class RepositoryBase
    {
        private string pathFile { get; set; }

        public RepositoryBase(string path)
        {
            pathFile = Directory.GetCurrentDirectory() + path;
        }

        public bool Insert<T>(T objetos)
        {
            using FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            database.Add(objetos);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));
            return true;
        }

        public List<T> GetAll<T>()
        {
            using FileStream stream = File.OpenRead(pathFile);
            return JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
        }

        public bool Delete<T>(T objeto)
        {
            using FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            database.Remove(objeto);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));
            return true;
        }
    }
}
