using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedDepartment;
using static ERPSystem.Data.SeedGeneralManager;
using static ERPSystem.Data.SeedBranch;


namespace ERPSystem.Data
{
    public static class SeedCompany
    {
        #region Create Companies
        public static Company Walmart = new Company
        {
            Name = "Walmart",
            GeneralManager = gm001,
            CompanyState = CompanyState.Active,
            Departments = new List<Department> 
            {
                WalmartProduction, 
                WalmartResearchandDevelopment, 
                WalmartPurchasing, 
                WalmartMarketing, 
                WalmartHumanResourceManagement, 
                WalmartAccountingandFinance
            },
            Branches = new List<Branch>
            {
                WalmartAsia,
                WalmartAfrica,
                WalmartNorthAmerica,
                WalmartSouthAmerica,
                WalmartEurope,
                WalmartAustralia
            }
        };
        public static Company Amazon = new Company
        {
            Name = "Amazon",
            GeneralManager = gm002,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                AmazonProduction,
                AmazonResearchandDevelopment,
                AmazonPurchasing,
                AmazonMarketing,
                AmazonHumanResourceManagement,
                AmazonAccountingandFinance
            },
            Branches = new List<Branch>
            {
                AmazonAsia,
                AmazonAfrica,
                AmazonNorthAmerica,
                AmazonSouthAmerica,
                AmazonEurope,
                AmazonAustralia
            }
        };
        public static Company Apple = new Company
        {
            Name = "Apple",
            GeneralManager = gm003,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                AppleProduction,
                AppleResearchandDevelopment,
                ApplePurchasing,
                AppleMarketing,
                AppleHumanResourceManagement,
                AppleAccountingandFinance
            },
            Branches = new List<Branch>
            {
                AppleAsia,
                AppleAfrica,
                AppleNorthAmerica,
                AppleSouthAmerica,
                AppleEurope,
                AppleAustralia
            }
        };
        public static Company FordMotor = new Company
        {
            Name = "Ford Motor",
            GeneralManager = gm004,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                FordMotorProduction,
                FordMotorResearchandDevelopment,
                FordMotorPurchasing,
                FordMotorMarketing,
                FordMotorHumanResourceManagement,
                FordMotorAccountingandFinance
            },
            Branches = new List<Branch>
            {
                FordMotorAsia,
                FordMotorAfrica,
                FordMotorNorthAmerica,
                FordMotorSouthAmerica,
                FordMotorEurope,
                FordMotorAustralia
            }
        };
        public static Company Microsoft = new Company
        {
            Name = "Microsoft",
            GeneralManager = gm005,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                MicrosoftProduction,
                MicrosoftResearchandDevelopment,
                MicrosoftPurchasing,
                MicrosoftMarketing,
                MicrosoftHumanResourceManagement,
                MicrosoftAccountingandFinance
            },
            Branches = new List<Branch>
            {
                MicrosoftAsia,
                MicrosoftAfrica,
                MicrosoftNorthAmerica,
                MicrosoftSouthAmerica,
                MicrosoftEurope,
                MicrosoftAustralia
            }
        };
        public static Company BankOfAmerica = new Company
        {
            Name = "Bank Of America",
            GeneralManager = gm006,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                BankOfAmericaProduction,
                BankOfAmericaResearchandDevelopment,
                BankOfAmericaPurchasing,
                BankOfAmericaMarketing,
                BankOfAmericaHumanResourceManagement,
                BankOfAmericaAccountingandFinance
            },
            Branches = new List<Branch>
            {
                BankOfAmericaAsia,
                BankOfAmericaAfrica,
                BankOfAmericaNorthAmerica,
                BankOfAmericaSouthAmerica,
                BankOfAmericaEurope,
                BankOfAmericaAustralia
            }
        };
        public static Company JohnsonAndJohnson = new Company
        {
            Name = "Johnson & Johnson",
            GeneralManager = gm007,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                JohnsonAndJohnsonProduction,
                JohnsonAndJohnsonResearchandDevelopment,
                JohnsonAndJohnsonPurchasing,
                JohnsonAndJohnsonMarketing,
                JohnsonAndJohnsonHumanResourceManagement,
                JohnsonAndJohnsonAccountingandFinance
            },
            Branches = new List<Branch>
            {
                JohnsonAndJohnsonAsia,
                JohnsonAndJohnsonAfrica,
                JohnsonAndJohnsonNorthAmerica,
                JohnsonAndJohnsonSouthAmerica,
                JohnsonAndJohnsonEurope,
                JohnsonAndJohnsonAustralia
            }
        };
        public static Company Facebook = new Company
        {
            Name = "Facebook",
            GeneralManager = gm008,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                FacebookProduction,
                FacebookResearchandDevelopment,
                FacebookPurchasing,
                FacebookMarketing,
                FacebookHumanResourceManagement,
                FacebookAccountingandFinance
            },
            Branches = new List<Branch>
            {
                FacebookAsia,
                FacebookAfrica,
                FacebookNorthAmerica,
                FacebookSouthAmerica,
                FacebookEurope,
                FacebookAustralia
            }
        };
        public static Company Alphabet = new Company
        {
            Name = "Alphabet",
            GeneralManager = gm009,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                AlphabetProduction,
                AlphabetResearchandDevelopment,
                AlphabetPurchasing,
                AlphabetMarketing,
                AlphabetHumanResourceManagement,
                AlphabetAccountingandFinance
            },
            Branches = new List<Branch>
            {
                AlphabetAsia,
                AlphabetAfrica,
                AlphabetNorthAmerica,
                AlphabetSouthAmerica,
                AlphabetEurope,
                AlphabetAustralia
            }
        };
        public static Company ExxonMobil = new Company
        {
            Name = "Exxon Mobil",
            GeneralManager = gm010,
            CompanyState = CompanyState.Active,
            Departments = new List<Department>
            {
                ExxonMobilProduction,
                ExxonMobilResearchandDevelopment,
                ExxonMobilPurchasing,
                ExxonMobilMarketing,
                ExxonMobilHumanResourceManagement,
                ExxonMobilAccountingandFinance
            },
            Branches = new List<Branch>
            {
                ExxonMobilAsia,
                ExxonMobilAfrica,
                ExxonMobilNorthAmerica,
                ExxonMobilSouthAmerica,
                ExxonMobilEurope,
                ExxonMobilAustralia
            }
        };
        #endregion
        public static List<Company> data;
        static SeedCompany()
        {
            data = new List<Company>();
            data.Add(Walmart);
            data.Add(Amazon);
            data.Add(Apple);
            data.Add(FordMotor);
            data.Add(Microsoft);
            data.Add(BankOfAmerica);
            data.Add(JohnsonAndJohnson);
            data.Add(Facebook);
            data.Add(Alphabet);
            data.Add(ExxonMobil);
        }
    }
}
