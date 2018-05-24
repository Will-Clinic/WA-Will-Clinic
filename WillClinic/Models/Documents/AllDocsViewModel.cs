using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.Documents
{
    public class AllDocsViewModel
    {
        //Sill section
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string County { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public bool HasChildren { get; set; }
        public List<string> Children { get; set; }
        //Personal Representetive
        public string PRPrimeFirstName { get; set; }
        public string PRPrimeLastName { get; set; }
        public string PRAltFirstName { get; set; }
        public string PRAltLastName { get; set; }
        //Inheritances
        public string PrimeBenificiary { get; set; }
        public string AltBenificiary { get; set; }
        public List<string> DisposeList { get; set; }

        //Health Care Directive section
        //Empty as of now

        //Power of Attorny section
        public string SuccessorPrime { get; set; }
        public string SuccessorAlt { get; set; }
    }
}