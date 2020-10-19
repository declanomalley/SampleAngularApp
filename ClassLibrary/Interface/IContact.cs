using System;

namespace Sample.Model
{
    public interface IContact
    {
        DateTime DateOfBirth { get; set; }
        string FamilyName { get; set; }
        string GivenNames { get; set; }
        int ID { get; set; }
        string Sex { get; set; }
    }
}