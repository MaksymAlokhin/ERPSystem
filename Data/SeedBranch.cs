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
        public static Branch WalmartNorthAmerica = new Branch
        {
            Name = "Walmart North America",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch WalmartEurope = new Branch
        {
            Name = "Walmart Europe",
            BranchState = BranchState.Active,
            Company = Walmart
        };
        public static Branch AmazonNorthAmerica = new Branch
        {
            Name = "Amazon North America",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AmazonEurope = new Branch
        {
            Name = "Amazon Europe",
            BranchState = BranchState.Active,
            Company = Amazon
        };
        public static Branch AppleNorthAmerica = new Branch
        {
            Name = "Apple North America",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch AppleEurope = new Branch
        {
            Name = "Apple Europe",
            BranchState = BranchState.Active,
            Company = Apple
        };
        public static Branch FordMotorNorthAmerica = new Branch
        {
            Name = "Ford Motor North America",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FordMotorEurope = new Branch
        {
            Name = "Ford Motor Europe",
            BranchState = BranchState.Active,
            Company = FordMotor
        };
        public static Branch FedExNorthAmerica = new Branch
        {
            Name = "FedEx North America",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch FedExEurope = new Branch
        {
            Name = "FedEx Europe",
            BranchState = BranchState.Active,
            Company = FedEx
        };
        public static Branch BankOfAmericaNorthAmerica = new Branch
        {
            Name = "Bank of America North America",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch BankOfAmericaEurope = new Branch
        {
            Name = "Bank of America Europe",
            BranchState = BranchState.Active,
            Company = BankOfAmerica
        };
        public static Branch JohnsonAndJohnsonNorthAmerica = new Branch
        {
            Name = "Johnson & Johnson North America",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch JohnsonAndJohnsonEurope = new Branch
        {
            Name = "Johnson & Johnson Europe",
            BranchState = BranchState.Active,
            Company = JohnsonAndJohnson
        };
        public static Branch FacebookNorthAmerica = new Branch
        {
            Name = "Facebook North America",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch FacebookEurope = new Branch
        {
            Name = "Facebook Europe",
            BranchState = BranchState.Active,
            Company = Facebook
        };
        public static Branch AlphabetNorthAmerica = new Branch
        {
            Name = "Alphabet North America",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch AlphabetEurope = new Branch
        {
            Name = "Alphabet Europe",
            BranchState = BranchState.Active,
            Company = Alphabet
        };
        public static Branch ExxonMobilNorthAmerica = new Branch
        {
            Name = "ExxonMobil North America",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        public static Branch ExxonMobilEurope = new Branch
        {
            Name = "ExxonMobil Europe",
            BranchState = BranchState.Active,
            Company = ExxonMobil
        };
        #endregion
        public static List<Branch> data;
        static SeedBranch()
        {
            data = new List<Branch>();
            data.Add(WalmartNorthAmerica);
            data.Add(WalmartEurope);
            data.Add(AmazonNorthAmerica);
            data.Add(AmazonEurope);
            data.Add(AppleNorthAmerica);
            data.Add(AppleEurope);
            data.Add(FordMotorNorthAmerica);
            data.Add(FordMotorEurope);
            data.Add(FedExNorthAmerica);
            data.Add(FedExEurope);
            data.Add(BankOfAmericaNorthAmerica);
            data.Add(BankOfAmericaEurope);
            data.Add(JohnsonAndJohnsonNorthAmerica);
            data.Add(JohnsonAndJohnsonEurope);
            data.Add(FacebookNorthAmerica);
            data.Add(FacebookEurope);
            data.Add(AlphabetNorthAmerica);
            data.Add(AlphabetEurope);
            data.Add(ExxonMobilNorthAmerica);
            data.Add(ExxonMobilEurope);
        }
    }
}
