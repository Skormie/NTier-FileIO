using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.DataAccessLayer;
using Demo_FileIO_NTier.Starter.BusinessLogicLayer;
using Demo_FileIO_NTier.Starter.DataAccessLayer;
using Demo_FileIO_NTier.Starter.Models;
using Demo_FileIO_NTier.Starter.PresentationLayer;

namespace Demo_FileIO_NTier
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService DataService;
            CharacterBLL CharacterBLL;
            Presenter presenter;

            DataService = new CsvDataService(@"Data/Data.csv");
            CharacterBLL = new CharacterBLL(DataService);
            presenter = new Presenter(CharacterBLL);

            DataService = new XmlDataService(@"Data/Data.xml");
            CharacterBLL = new CharacterBLL(DataService);
            presenter = new Presenter(CharacterBLL);

            DataService = new JsonDataService();
            CharacterBLL = new CharacterBLL(DataService);
            presenter = new Presenter(CharacterBLL);
        }
    }
}
