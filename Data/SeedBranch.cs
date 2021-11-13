using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedCompany;

namespace ERPSystem.Data
{
    public static class SeedBranch
    {
        #region Create Branches
        public static Branch WalmartAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch AmazonAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AppleAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch AppleAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AppleNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch AppleSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch AppleEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch AppleAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch FordMotorAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FedExAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch BankOfAmericaAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch JohnsonAndJohnsonAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch FacebookAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch AlphabetAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch ExxonMobilAsia = new Branch
        {
            Name = "Asia",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilAfrica = new Branch
        {
            Name = "Africa",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilNorthAmerica = new Branch
        {
            Name = "North America",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilSouthAmerica = new Branch
        {
            Name = "South America",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilEurope = new Branch
        {
            Name = "Europe",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilAustralia = new Branch
        {
            Name = "Australia",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        #endregion
        public static List<Branch> data;
        static SeedBranch()
        {
            data = new List<Branch>();
            data.Add(WalmartAsia);
            data.Add(WalmartAfrica);
            data.Add(WalmartNorthAmerica);
            data.Add(WalmartSouthAmerica);
            data.Add(WalmartEurope);
            data.Add(WalmartAustralia);
            data.Add(AmazonAsia);
            data.Add(AmazonAfrica);
            data.Add(AmazonNorthAmerica);
            data.Add(AmazonSouthAmerica);
            data.Add(AmazonEurope);
            data.Add(AmazonAustralia);
            data.Add(AppleAsia);
            data.Add(AppleAfrica);
            data.Add(AppleNorthAmerica);
            data.Add(AppleSouthAmerica);
            data.Add(AppleEurope);
            data.Add(AppleAustralia);
            data.Add(FordMotorAsia);
            data.Add(FordMotorAfrica);
            data.Add(FordMotorNorthAmerica);
            data.Add(FordMotorSouthAmerica);
            data.Add(FordMotorEurope);
            data.Add(FordMotorAustralia);
            data.Add(FedExAsia);
            data.Add(FedExAfrica);
            data.Add(FedExNorthAmerica);
            data.Add(FedExSouthAmerica);
            data.Add(FedExEurope);
            data.Add(FedExAustralia);
            data.Add(BankOfAmericaAsia);
            data.Add(BankOfAmericaAfrica);
            data.Add(BankOfAmericaNorthAmerica);
            data.Add(BankOfAmericaSouthAmerica);
            data.Add(BankOfAmericaEurope);
            data.Add(BankOfAmericaAustralia);
            data.Add(JohnsonAndJohnsonAsia);
            data.Add(JohnsonAndJohnsonAfrica);
            data.Add(JohnsonAndJohnsonNorthAmerica);
            data.Add(JohnsonAndJohnsonSouthAmerica);
            data.Add(JohnsonAndJohnsonEurope);
            data.Add(JohnsonAndJohnsonAustralia);
            data.Add(FacebookAsia);
            data.Add(FacebookAfrica);
            data.Add(FacebookNorthAmerica);
            data.Add(FacebookSouthAmerica);
            data.Add(FacebookEurope);
            data.Add(FacebookAustralia);
            data.Add(AlphabetAsia);
            data.Add(AlphabetAfrica);
            data.Add(AlphabetNorthAmerica);
            data.Add(AlphabetSouthAmerica);
            data.Add(AlphabetEurope);
            data.Add(AlphabetAustralia);
            data.Add(ExxonMobilAsia);
            data.Add(ExxonMobilAfrica);
            data.Add(ExxonMobilNorthAmerica);
            data.Add(ExxonMobilSouthAmerica);
            data.Add(ExxonMobilEurope);
            data.Add(ExxonMobilAustralia);
        }
    }
}
