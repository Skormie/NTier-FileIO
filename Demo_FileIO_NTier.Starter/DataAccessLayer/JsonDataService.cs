using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Demo_FileIO_NTier.Starter.DataAccessLayer;
using Demo_FileIO_NTier.Starter.Models;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo_FileIO_NTier.Starter.DataAccessLayer
{
    class JsonDataService : IDataService
    {
        public const string dataFilePathJson = "Data\\";
        string _dataFilePath;

        public JsonDataService(string dataFilePath = DataSettings.dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public void WriteAll(IEnumerable<Character> characters)
        {
            StreamWriter sWriter;

            try
            {
                if (!Directory.Exists(dataFilePathJson))
                    Directory.CreateDirectory(dataFilePathJson);

                using (sWriter = new StreamWriter(_dataFilePath))
                    sWriter.Write(JsonConvert.SerializeObject(characters, Formatting.Indented));
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("You need more permissions to run the application. Try running it as an admin.");
                Console.WriteLine(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("You need more permissions to run the application. Try running it as an admin.");
                Console.WriteLine(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine("The path is too long.");
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters;

            try
            {
                using (StreamReader sReader = new StreamReader(_dataFilePath))
                    characters = JsonConvert.DeserializeObject<List<Character>>(sReader.ReadToEnd());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No characters found!");
                Console.WriteLine(ex);
                throw;
            }

            return characters;
        }
    }
}
