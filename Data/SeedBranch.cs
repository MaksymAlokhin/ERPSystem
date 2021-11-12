using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedEmployee;

namespace ERPSystem.Data
{
    public static class SeedBranch
    {
        #region Create Branches
        public static Branch WalmartAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e001,e002,e003,e004,e005,e006,e007,e008,e009,e010,e011,e012,e013,e014,e015
            }
        };
        public static Branch WalmartAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e016,e017,e018,e019,e020,e021,e022,e023,e024,e025,e026,e027,e028,e029,e030
            }
        };
        public static Branch WalmartNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e031,e032,e033,e034,e035,e036,e037,e038,e039,e040,e041,e042,e043,e044,e045
            }
        };
        public static Branch WalmartSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e046,e047,e048,e049,e050,e051,e052,e053,e054,e055,e056,e057,e058,e059,e060
            }
        };
        public static Branch WalmartEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e061,e062,e063,e064,e065,e066,e067,e068,e069,e070,e071,e072,e073,e074,e075
            }
        };
        public static Branch WalmartAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {
                e076,e077,e078,e079,e080,e081,e082,e083,e084,e085,e086,e087,e088,e089,e090
            }
        };
        public static Branch AmazonAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AmazonAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AmazonNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AmazonSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AmazonEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AmazonAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AppleAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FordMotorAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch MicrosoftAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch BankOfAmericaAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch JohnsonAndJohnsonAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch FacebookAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch AlphabetAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        public static Branch ExxonMobilAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Employees = new List<Employee>
            {

            }
        };
        #endregion
    }
}
