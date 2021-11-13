using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedDepartment;

namespace ERPSystem.Data
{
    public static class SeedDepartmentHead
    {
        #region Create Department Heads
        public static DepartmentHead dh001 = new DepartmentHead
        {
            FirstName = "Orlando",
            LastName = "Odom",
            Department = WalmartProduction,
            DateOfBirth = DateTime.Parse("1995-02-20"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh002 = new DepartmentHead
        {
            FirstName = "Renee",
            LastName = "Harper",
            Department = WalmartResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1998-04-14"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh003 = new DepartmentHead
        {
            FirstName = "Dominic",
            LastName = "Powers",
            Department = WalmartPurchasing,
            DateOfBirth = DateTime.Parse("1996-09-07"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh004 = new DepartmentHead
        {
            FirstName = "Miranda",
            LastName = "Ward",
            Department = WalmartMarketing,
            DateOfBirth = DateTime.Parse("1983-05-05"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh005 = new DepartmentHead
        {
            FirstName = "Petra",
            LastName = "Kinney",
            Department = WalmartHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1987-08-15"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh006 = new DepartmentHead
        {
            FirstName = "Cassidy",
            LastName = "Blackwell",
            Department = WalmartAccountingandFinance,
            DateOfBirth = DateTime.Parse("1981-08-14"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh007 = new DepartmentHead
        {
            FirstName = "Ramona",
            LastName = "Cannon",
            Department = AmazonProduction,
            DateOfBirth = DateTime.Parse("1990-12-01"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh008 = new DepartmentHead
        {
            FirstName = "Naida",
            LastName = "Vance",
            Department = AmazonResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1984-01-27"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh009 = new DepartmentHead
        {
            FirstName = "Jin",
            LastName = "Garrett",
            Department = AmazonPurchasing,
            DateOfBirth = DateTime.Parse("1982-08-23"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh010 = new DepartmentHead
        {
            FirstName = "Giselle",
            LastName = "Whitaker",
            Department = AmazonMarketing,
            DateOfBirth = DateTime.Parse("1988-12-05"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh011 = new DepartmentHead
        {
            FirstName = "Brenden",
            LastName = "Emerson",
            Department = AmazonHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1984-10-03"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh012 = new DepartmentHead
        {
            FirstName = "Brody",
            LastName = "Roach",
            Department = AmazonAccountingandFinance,
            DateOfBirth = DateTime.Parse("1999-10-31"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh013 = new DepartmentHead
        {
            FirstName = "Walter",
            LastName = "Ashley",
            Department = AppleProduction,
            DateOfBirth = DateTime.Parse("1995-11-30"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh014 = new DepartmentHead
        {
            FirstName = "Vanna",
            LastName = "Stafford",
            Department = AppleResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1984-08-04"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh015 = new DepartmentHead
        {
            FirstName = "Yen",
            LastName = "Jennings",
            Department = ApplePurchasing,
            DateOfBirth = DateTime.Parse("1993-02-07"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh016 = new DepartmentHead
        {
            FirstName = "Zephr",
            LastName = "Kelley",
            Department = AppleMarketing,
            DateOfBirth = DateTime.Parse("1991-03-31"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh017 = new DepartmentHead
        {
            FirstName = "Elliott",
            LastName = "Moran",
            Department = AppleHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1998-12-03"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh018 = new DepartmentHead
        {
            FirstName = "Dale",
            LastName = "West",
            Department = AppleAccountingandFinance,
            DateOfBirth = DateTime.Parse("1990-05-09"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh019 = new DepartmentHead
        {
            FirstName = "Hannah",
            LastName = "Garza",
            Department = FordMotorProduction,
            DateOfBirth = DateTime.Parse("1986-09-15"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh020 = new DepartmentHead
        {
            FirstName = "Bree",
            LastName = "Coleman",
            Department = FordMotorResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1990-05-17"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh021 = new DepartmentHead
        {
            FirstName = "Dalton",
            LastName = "Christensen",
            Department = FordMotorPurchasing,
            DateOfBirth = DateTime.Parse("1994-03-10"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh022 = new DepartmentHead
        {
            FirstName = "Iliana",
            LastName = "Ewing",
            Department = FordMotorMarketing,
            DateOfBirth = DateTime.Parse("1988-04-21"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh023 = new DepartmentHead
        {
            FirstName = "Dieter",
            LastName = "Grant",
            Department = FordMotorHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1997-05-01"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh024 = new DepartmentHead
        {
            FirstName = "Nasim",
            LastName = "Bonner",
            Department = FordMotorAccountingandFinance,
            DateOfBirth = DateTime.Parse("1999-05-21"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh025 = new DepartmentHead
        {
            FirstName = "Rahim",
            LastName = "Butler",
            Department = FedExProduction,
            DateOfBirth = DateTime.Parse("1990-10-20"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh026 = new DepartmentHead
        {
            FirstName = "Dorothy",
            LastName = "Burt",
            Department = FedExResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("2000-04-29"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh027 = new DepartmentHead
        {
            FirstName = "Daquan",
            LastName = "Mack",
            Department = FedExPurchasing,
            DateOfBirth = DateTime.Parse("1981-07-19"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh028 = new DepartmentHead
        {
            FirstName = "Phyllis",
            LastName = "Curtis",
            Department = FedExMarketing,
            DateOfBirth = DateTime.Parse("1988-02-28"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh029 = new DepartmentHead
        {
            FirstName = "Giselle",
            LastName = "Knight",
            Department = FedExHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1984-05-29"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh030 = new DepartmentHead
        {
            FirstName = "Stacy",
            LastName = "Ramirez",
            Department = FedExAccountingandFinance,
            DateOfBirth = DateTime.Parse("1989-04-05"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh031 = new DepartmentHead
        {
            FirstName = "Winter",
            LastName = "Guy",
            Department = BankOfAmericaProduction,
            DateOfBirth = DateTime.Parse("1989-03-25"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh032 = new DepartmentHead
        {
            FirstName = "Ocean",
            LastName = "Malone",
            Department = BankOfAmericaResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("2001-06-20"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh033 = new DepartmentHead
        {
            FirstName = "Lavinia",
            LastName = "Hubbard",
            Department = BankOfAmericaPurchasing,
            DateOfBirth = DateTime.Parse("1981-02-06"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh034 = new DepartmentHead
        {
            FirstName = "Deacon",
            LastName = "Roberts",
            Department = BankOfAmericaMarketing,
            DateOfBirth = DateTime.Parse("1984-11-10"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh035 = new DepartmentHead
        {
            FirstName = "Anastasia",
            LastName = "Gibbs",
            Department = BankOfAmericaHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1997-10-09"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh036 = new DepartmentHead
        {
            FirstName = "Brynn",
            LastName = "Rivas",
            Department = BankOfAmericaAccountingandFinance,
            DateOfBirth = DateTime.Parse("1981-07-30"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh037 = new DepartmentHead
        {
            FirstName = "Laith",
            LastName = "Vargas",
            Department = JohnsonAndJohnsonProduction,
            DateOfBirth = DateTime.Parse("1994-08-24"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh038 = new DepartmentHead
        {
            FirstName = "Dylan",
            LastName = "Mcbride",
            Department = JohnsonAndJohnsonResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1981-05-16"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh039 = new DepartmentHead
        {
            FirstName = "Hadley",
            LastName = "Fisher",
            Department = JohnsonAndJohnsonPurchasing,
            DateOfBirth = DateTime.Parse("1987-08-19"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh040 = new DepartmentHead
        {
            FirstName = "Aphrodite",
            LastName = "Rich",
            Department = JohnsonAndJohnsonMarketing,
            DateOfBirth = DateTime.Parse("1996-02-06"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh041 = new DepartmentHead
        {
            FirstName = "Lynn",
            LastName = "Huffman",
            Department = JohnsonAndJohnsonHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1991-09-18"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh042 = new DepartmentHead
        {
            FirstName = "Anthony",
            LastName = "Hammond",
            Department = JohnsonAndJohnsonAccountingandFinance,
            DateOfBirth = DateTime.Parse("1997-07-16"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh043 = new DepartmentHead
        {
            FirstName = "Jordan",
            LastName = "Tate",
            Department = FacebookProduction,
            DateOfBirth = DateTime.Parse("1987-09-26"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh044 = new DepartmentHead
        {
            FirstName = "Jeanette",
            LastName = "Estes",
            Department = FacebookResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1996-03-18"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh045 = new DepartmentHead
        {
            FirstName = "Montana",
            LastName = "Battle",
            Department = FacebookPurchasing,
            DateOfBirth = DateTime.Parse("1992-12-25"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh046 = new DepartmentHead
        {
            FirstName = "Haley",
            LastName = "Daniels",
            Department = FacebookMarketing,
            DateOfBirth = DateTime.Parse("1993-05-15"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh047 = new DepartmentHead
        {
            FirstName = "Otto",
            LastName = "Clements",
            Department = FacebookHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1997-09-04"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh048 = new DepartmentHead
        {
            FirstName = "Ray",
            LastName = "Franco",
            Department = FacebookAccountingandFinance,
            DateOfBirth = DateTime.Parse("2000-07-26"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh049 = new DepartmentHead
        {
            FirstName = "Karyn",
            LastName = "Montoya",
            Department = AlphabetProduction,
            DateOfBirth = DateTime.Parse("1996-12-27"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh050 = new DepartmentHead
        {
            FirstName = "Amber",
            LastName = "Albert",
            Department = AlphabetResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1981-04-26"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh051 = new DepartmentHead
        {
            FirstName = "Harlan",
            LastName = "Suarez",
            Department = AlphabetPurchasing,
            DateOfBirth = DateTime.Parse("1991-01-09"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh052 = new DepartmentHead
        {
            FirstName = "Sigourney",
            LastName = "Knight",
            Department = AlphabetMarketing,
            DateOfBirth = DateTime.Parse("1993-03-13"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh053 = new DepartmentHead
        {
            FirstName = "Rigel",
            LastName = "Walls",
            Department = AlphabetHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1992-04-30"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh054 = new DepartmentHead
        {
            FirstName = "Martina",
            LastName = "Harvey",
            Department = AlphabetAccountingandFinance,
            DateOfBirth = DateTime.Parse("1991-05-02"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh055 = new DepartmentHead
        {
            FirstName = "Lydia",
            LastName = "Vincent",
            Department = ExxonMobilProduction,
            DateOfBirth = DateTime.Parse("1989-10-17"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh056 = new DepartmentHead
        {
            FirstName = "Florence",
            LastName = "Hutchinson",
            Department = ExxonMobilResearchAndDevelopment,
            DateOfBirth = DateTime.Parse("1985-07-07"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh057 = new DepartmentHead
        {
            FirstName = "Hayden",
            LastName = "Walton",
            Department = ExxonMobilPurchasing,
            DateOfBirth = DateTime.Parse("2000-10-15"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh058 = new DepartmentHead
        {
            FirstName = "Dane",
            LastName = "English",
            Department = ExxonMobilMarketing,
            DateOfBirth = DateTime.Parse("2001-04-07"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh059 = new DepartmentHead
        {
            FirstName = "Orson",
            LastName = "Morton",
            Department = ExxonMobilHumanResourceManagement,
            DateOfBirth = DateTime.Parse("1997-11-30"),
            EmployeeState = EmployeeState.Active
        };
        public static DepartmentHead dh060 = new DepartmentHead
        {
            FirstName = "Alfreda",
            LastName = "Cline",
            Department = ExxonMobilAccountingandFinance,
            DateOfBirth = DateTime.Parse("1999-01-07"),
            EmployeeState = EmployeeState.Active
        };
        #endregion
        public static List<DepartmentHead> data;
        static SeedDepartmentHead()
        {
            data = new List<DepartmentHead>();
            data.Add(dh001);
            data.Add(dh002);
            data.Add(dh003);
            data.Add(dh004);
            data.Add(dh005);
            data.Add(dh006);
            data.Add(dh007);
            data.Add(dh008);
            data.Add(dh009);
            data.Add(dh010);
            data.Add(dh011);
            data.Add(dh012);
            data.Add(dh013);
            data.Add(dh014);
            data.Add(dh015);
            data.Add(dh016);
            data.Add(dh017);
            data.Add(dh018);
            data.Add(dh019);
            data.Add(dh020);
            data.Add(dh021);
            data.Add(dh022);
            data.Add(dh023);
            data.Add(dh024);
            data.Add(dh025);
            data.Add(dh026);
            data.Add(dh027);
            data.Add(dh028);
            data.Add(dh029);
            data.Add(dh030);
            data.Add(dh031);
            data.Add(dh032);
            data.Add(dh033);
            data.Add(dh034);
            data.Add(dh035);
            data.Add(dh036);
            data.Add(dh037);
            data.Add(dh038);
            data.Add(dh039);
            data.Add(dh040);
            data.Add(dh041);
            data.Add(dh042);
            data.Add(dh043);
            data.Add(dh044);
            data.Add(dh045);
            data.Add(dh046);
            data.Add(dh047);
            data.Add(dh048);
            data.Add(dh049);
            data.Add(dh050);
            data.Add(dh051);
            data.Add(dh052);
            data.Add(dh053);
            data.Add(dh054);
            data.Add(dh055);
            data.Add(dh056);
            data.Add(dh057);
            data.Add(dh058);
            data.Add(dh059);
            data.Add(dh060);
        }
    }
}
