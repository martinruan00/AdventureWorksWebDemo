using AdventureWorksWebDemo.Attributes;
using System;

namespace AdventureWorksWebDemo.Models.HumanResources
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [ColumnMetadata("Id number")]
        public string NationalIdnumber { get; set; }

        [ColumnMetadata("Title")]
        public string Title { get; set; }

        [ColumnMetadata("FirstName")]
        public string FirstName { get; set; }

        [ColumnMetadata("MiddleName")]
        public string MiddleName { get; set; }

        [ColumnMetadata("LastName")]
        public string LastName { get; set; }

        public string Suffix { get; set; }

        [ColumnMetadata("JobTitle")]
        public string JobTitle { get; set; }

        [ColumnMetadata("BirthDate")]
        public DateTime BirthDate { get; set; }

        [ColumnMetadata("MaritalStatus")]
        public string MaritalStatus { get; set; }

        [ColumnMetadata("Gender")]
        public string Gender { get; set; }

        [ColumnMetadata("HireDate")]
        public DateTime HireDate { get; set; }

        [ColumnMetadata("VacationHours")]
        public short VacationHours { get; set; }

        [ColumnMetadata("SickLeaveHours")]
        public short SickLeaveHours { get; set; }

        [ColumnMetadata("AdditionalContactInfo")]
        public string AdditionalContactInfo { get; set; }
    }
}
