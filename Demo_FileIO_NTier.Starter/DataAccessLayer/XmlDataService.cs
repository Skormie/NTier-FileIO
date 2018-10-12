using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Demo_FileIO_NTier.Starter.Models;
using Demo_FileIO_NTier.Starter.DataAccessLayer;

namespace Demo_FileIO_NTier.DataAccessLayer

{
    public class XmlDataService : IDataService
    {
        private string _dataFilePath;

        public XmlDataService(string dataFilePath = DataSettings.dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        // Read the xml file and load a list of character objects
        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                    characters = serializer.Deserialize(reader) as List<Character>;
            }
            catch (Exception)
            {
                throw; // all exceptions are handled in the ListForm class
            }

            return characters;
        }

        // Write the current list of characters to the xml data file
        public void WriteAll(IEnumerable<Character> characters)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                    serializer.Serialize(writer, characters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
