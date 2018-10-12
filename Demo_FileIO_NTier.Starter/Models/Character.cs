using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.Starter.Models
{
    public class Character
    {
        public enum GenderType { NOTSPECIFIED, MALE, FEMALE }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public static Character CreateFromData(string[] properties)
        {
            int id, age;
            GenderType gender;

            if (properties.Length != 9)
                throw new ArgumentException("Scale of data is incorrect.");

            if(!int.TryParse(properties[0],out id))
                throw new ArgumentException("Incorrect value for id.");

            if (!int.TryParse(properties[7], out age))
                throw new ArgumentException("Incorrect value for age.");

            if(!Enum.TryParse<GenderType>(properties[8],out gender))
                throw new ArgumentException("Incorrect value for gender.");

            return new Character
            {
                Id = id,
                LastName = properties[1],
                FirstName = properties[2],
                Address = properties[3],
                City = properties[4],
                State = properties[5],
                Zip = properties[6],
                Age = age,
                Gender = gender
            };
        }
    }
}
