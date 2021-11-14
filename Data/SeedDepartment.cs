using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedCompany;

namespace ERPSystem.Data
{
    public static class SeedDepartment
    {
        #region Create Departments
        public static Department WalmartProduction = new Department
        {
            Name = "Walmart Production",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartResearchAndDevelopment = new Department
        {
            Name = "Walmart Research and Development",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartPurchasing = new Department
        {
            Name = "Walmart Purchasing",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartMarketing = new Department
        {
            Name = "Walmart Marketing",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartHumanResourceManagement = new Department
        {
            Name = "Walmart Human Resource Management",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartAccountingandFinance = new Department
        {
            Name = "Walmart Accounting and Finance",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonProduction = new Department
        {
            Name = "Amazon Production",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonResearchAndDevelopment = new Department
        {
            Name = "Amazon Research and Development",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonPurchasing = new Department
        {
            Name = "Amazon Purchasing",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonMarketing = new Department
        {
            Name = "Amazon Marketing",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonHumanResourceManagement = new Department
        {
            Name = "Amazon Human Resource Management",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonAccountingandFinance = new Department
        {
            Name = "Amazon Accounting and Finance",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleProduction = new Department
        {
            Name = "Apple Production",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleResearchAndDevelopment = new Department
        {
            Name = "Apple Research and Development",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department ApplePurchasing = new Department
        {
            Name = "Apple Purchasing",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleMarketing = new Department
        {
            Name = "Apple Marketing",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleHumanResourceManagement = new Department
        {
            Name = "Apple Human Resource Management",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleAccountingandFinance = new Department
        {
            Name = "Apple Accounting and Finance",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorProduction = new Department
        {
            Name = "Ford Motor Production",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorResearchAndDevelopment = new Department
        {
            Name = "Ford Motor Research and Development",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorPurchasing = new Department
        {
            Name = "Ford Motor Purchasing",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorMarketing = new Department
        {
            Name = "Ford Motor Marketing",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorHumanResourceManagement = new Department
        {
            Name = "Ford Motor Human Resource Management",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorAccountingandFinance = new Department
        {
            Name = "Ford Motor Accounting and Finance",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExProduction = new Department
        {
            Name = "FedExProduction",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExResearchAndDevelopment = new Department
        {
            Name = "FedExResearch and Development",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExPurchasing = new Department
        {
            Name = "FedExPurchasing",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExMarketing = new Department
        {
            Name = "FedExMarketing",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExHumanResourceManagement = new Department
        {
            Name = "FedExHuman Resource Management",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExAccountingandFinance = new Department
        {
            Name = "FedExAccounting and Finance",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaProduction = new Department
        {
            Name = "Bank of America Production",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaResearchAndDevelopment = new Department
        {
            Name = "Bank of America Research and Development",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaPurchasing = new Department
        {
            Name = "Bank of America Purchasing",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaMarketing = new Department
        {
            Name = "Bank of America Marketing",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaHumanResourceManagement = new Department
        {
            Name = "Bank of America Human Resource Management",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaAccountingandFinance = new Department
        {
            Name = "Bank of America Accounting and Finance",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonProduction = new Department
        {
            Name = "Johnson & Johnson Production",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonResearchAndDevelopment = new Department
        {
            Name = "Johnson & Johnson Research and Development",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonPurchasing = new Department
        {
            Name = "Johnson & Johnson Purchasing",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonMarketing = new Department
        {
            Name = "Johnson & Johnson Marketing",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonHumanResourceManagement = new Department
        {
            Name = "Johnson & Johnson Human Resource Management",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonAccountingandFinance = new Department
        {
            Name = "Johnson & Johnson Accounting and Finance",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookProduction = new Department
        {
            Name = "Facebook Production",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookResearchAndDevelopment = new Department
        {
            Name = "Facebook Research and Development",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookPurchasing = new Department
        {
            Name = "Facebook Purchasing",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookMarketing = new Department
        {
            Name = "Facebook Marketing",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookHumanResourceManagement = new Department
        {
            Name = "Facebook Human Resource Management",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookAccountingandFinance = new Department
        {
            Name = "Facebook Accounting and Finance",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetProduction = new Department
        {
            Name = "Alphabet Production",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetResearchAndDevelopment = new Department
        {
            Name = "Alphabet Research and Development",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetPurchasing = new Department
        {
            Name = "Alphabet Purchasing",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetMarketing = new Department
        {
            Name = "Alphabet Marketing",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetHumanResourceManagement = new Department
        {
            Name = "Alphabet Human Resource Management",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetAccountingandFinance = new Department
        {
            Name = "Alphabet Accounting and Finance",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilProduction = new Department
        {
            Name = "ExxonMobil Production",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilResearchAndDevelopment = new Department
        {
            Name = "ExxonMobil Research and Development",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilPurchasing = new Department
        {
            Name = "ExxonMobil Purchasing",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilMarketing = new Department
        {
            Name = "ExxonMobil Marketing",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilHumanResourceManagement = new Department
        {
            Name = "ExxonMobil Human Resource Management",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilAccountingandFinance = new Department
        {
            Name = "ExxonMobil Accounting and Finance",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        #endregion
        public static List<Department> data;
        static SeedDepartment()
        {
            data = new List<Department>();
            data.Add(WalmartProduction);
            data.Add(WalmartResearchAndDevelopment);
            data.Add(WalmartPurchasing);
            data.Add(WalmartMarketing);
            data.Add(WalmartHumanResourceManagement);
            data.Add(WalmartAccountingandFinance);
            data.Add(AmazonProduction);
            data.Add(AmazonResearchAndDevelopment);
            data.Add(AmazonPurchasing);
            data.Add(AmazonMarketing);
            data.Add(AmazonHumanResourceManagement);
            data.Add(AmazonAccountingandFinance);
            data.Add(AppleProduction);
            data.Add(AppleResearchAndDevelopment);
            data.Add(ApplePurchasing);
            data.Add(AppleMarketing);
            data.Add(AppleHumanResourceManagement);
            data.Add(AppleAccountingandFinance);
            data.Add(FordMotorProduction);
            data.Add(FordMotorResearchAndDevelopment);
            data.Add(FordMotorPurchasing);
            data.Add(FordMotorMarketing);
            data.Add(FordMotorHumanResourceManagement);
            data.Add(FordMotorAccountingandFinance);
            data.Add(FedExProduction);
            data.Add(FedExResearchAndDevelopment);
            data.Add(FedExPurchasing);
            data.Add(FedExMarketing);
            data.Add(FedExHumanResourceManagement);
            data.Add(FedExAccountingandFinance);
            data.Add(BankOfAmericaProduction);
            data.Add(BankOfAmericaResearchAndDevelopment);
            data.Add(BankOfAmericaPurchasing);
            data.Add(BankOfAmericaMarketing);
            data.Add(BankOfAmericaHumanResourceManagement);
            data.Add(BankOfAmericaAccountingandFinance);
            data.Add(JohnsonAndJohnsonProduction);
            data.Add(JohnsonAndJohnsonResearchAndDevelopment);
            data.Add(JohnsonAndJohnsonPurchasing);
            data.Add(JohnsonAndJohnsonMarketing);
            data.Add(JohnsonAndJohnsonHumanResourceManagement);
            data.Add(JohnsonAndJohnsonAccountingandFinance);
            data.Add(FacebookProduction);
            data.Add(FacebookResearchAndDevelopment);
            data.Add(FacebookPurchasing);
            data.Add(FacebookMarketing);
            data.Add(FacebookHumanResourceManagement);
            data.Add(FacebookAccountingandFinance);
            data.Add(AlphabetProduction);
            data.Add(AlphabetResearchAndDevelopment);
            data.Add(AlphabetPurchasing);
            data.Add(AlphabetMarketing);
            data.Add(AlphabetHumanResourceManagement);
            data.Add(AlphabetAccountingandFinance);
            data.Add(ExxonMobilProduction);
            data.Add(ExxonMobilResearchAndDevelopment);
            data.Add(ExxonMobilPurchasing);
            data.Add(ExxonMobilMarketing);
            data.Add(ExxonMobilHumanResourceManagement);
            data.Add(ExxonMobilAccountingandFinance);
        }
        }
    }
