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
            Name = "Production",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartPurchasing = new Department
        {
            Name = "Purchasing",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartMarketing = new Department
        {
            Name = "Marketing",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonProduction = new Department
        {
            Name = "Production",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonPurchasing = new Department
        {
            Name = "Purchasing",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonMarketing = new Department
        {
            Name = "Marketing",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleProduction = new Department
        {
            Name = "Production",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department ApplePurchasing = new Department
        {
            Name = "Purchasing",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleMarketing = new Department
        {
            Name = "Marketing",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorProduction = new Department
        {
            Name = "Production",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorPurchasing = new Department
        {
            Name = "Purchasing",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorMarketing = new Department
        {
            Name = "Marketing",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExProduction = new Department
        {
            Name = "Production",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExPurchasing = new Department
        {
            Name = "Purchasing",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExMarketing = new Department
        {
            Name = "Marketing",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaProduction = new Department
        {
            Name = "Production",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaPurchasing = new Department
        {
            Name = "Purchasing",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaMarketing = new Department
        {
            Name = "Marketing",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonProduction = new Department
        {
            Name = "Production",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonPurchasing = new Department
        {
            Name = "Purchasing",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonMarketing = new Department
        {
            Name = "Marketing",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookProduction = new Department
        {
            Name = "Production",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookPurchasing = new Department
        {
            Name = "Purchasing",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookMarketing = new Department
        {
            Name = "Marketing",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetProduction = new Department
        {
            Name = "Production",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetPurchasing = new Department
        {
            Name = "Purchasing",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetMarketing = new Department
        {
            Name = "Marketing",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilProduction = new Department
        {
            Name = "Production",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilResearchAndDevelopment = new Department
        {
            Name = "Research and Development",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilPurchasing = new Department
        {
            Name = "Purchasing",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilMarketing = new Department
        {
            Name = "Marketing",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
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
