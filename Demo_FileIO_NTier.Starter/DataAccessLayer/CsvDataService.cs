using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Demo_FileIO_NTier.Starter.DataAccessLayer;
using Demo_FileIO_NTier.Starter.Models;
using System.Reflection;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.Starter.DataAccessLayer
{
    class CsvDataService : IDataService
    {
        private string _dataFilePath;

        public CsvDataService(string dataFilePath = DataSettings.dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public IEnumerable<Character> ReadAll()
        {
            List<string> charactersStrings = new List<string>();
            List<Character> characters = new List<Character>();

            try
            {
                StreamReader sr = new StreamReader(_dataFilePath);
                using (sr)
                    while (!sr.EndOfStream)
                        charactersStrings.Add(sr.ReadLine());

                foreach (string characterString in charactersStrings)
                    characters.Add(CharacterObjectBuilder(characterString));
            }
            catch (Exception)
            {

                throw;
            }
            return characters;
        }


        public void WriteAll(IEnumerable<Character> characters)
        {
            try
            {
                StreamWriter sw = new StreamWriter(_dataFilePath);
                using (sw)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Clear();

                    foreach (Character Char in characters)
                        sb.AppendLine(CharacterStringBuilder(Char));
                    sw.Write(sb.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Character CharacterObjectBuilder(string characterString)
        {
            const char DELINEATOR = ',';
            string[] properties = characterString.Split(DELINEATOR);

            return Character.CreateFromData(properties);
        }

        private string CharacterStringBuilder(Character characterObject)
        {
            const string DELINEATOR = ",";
            string characterString;

            var propertie_values = characterObject.GetType().GetProperties().Select(x => x.GetValue(x));

            characterString = String.Join(DELINEATOR, propertie_values.ToString());

            return characterString;
        }
    }
}
