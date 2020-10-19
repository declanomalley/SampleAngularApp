using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Model
{
    [Table("Contact")]
    public class Contact : IContact
    {
        public Contact() { }


        private int _id;
        [Key,Required]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _familyname;

        public string FamilyName
        {
            get { return _familyname; }
            set { _familyname = value; }
        }

        private string _givennames;

        public string GivenNames
        {
            get { return _givennames; }
            set { _givennames = value; }
        }

        private DateTime _dateofbirth;

        public DateTime DateOfBirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        private string _sex;

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

    }
}
