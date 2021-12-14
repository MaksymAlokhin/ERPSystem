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
        public static Department WalmartMarketing = new Department
        {
            Name = "Walmart Marketing",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartAccountingAndFinance = new Department
        {
            Name = "Walmart Accounting and Finance",
            Company = Walmart,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonMarketing = new Department
        {
            Name = "Amazon Marketing",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonAccountingAndFinance = new Department
        {
            Name = "Amazon Accounting and Finance",
            Company = Amazon,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleMarketing = new Department
        {
            Name = "Apple Marketing",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleAccountingAndFinance = new Department
        {
            Name = "Apple Accounting and Finance",
            Company = Apple,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorMarketing = new Department
        {
            Name = "Ford Motor Marketing",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorAccountingAndFinance = new Department
        {
            Name = "Ford Motor Accounting and Finance",
            Company = FordMotor,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExMarketing = new Department
        {
            Name = "FedExMarketing",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department FedExAccountingAndFinance = new Department
        {
            Name = "FedExAccounting and Finance",
            Company = FedEx,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaMarketing = new Department
        {
            Name = "Bank of America Marketing",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaAccountingAndFinance = new Department
        {
            Name = "Bank of America Accounting and Finance",
            Company = BankOfAmerica,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonMarketing = new Department
        {
            Name = "Johnson & Johnson Marketing",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonAccountingAndFinance = new Department
        {
            Name = "Johnson & Johnson Accounting and Finance",
            Company = JohnsonAndJohnson,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookMarketing = new Department
        {
            Name = "Facebook Marketing",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookAccountingAndFinance = new Department
        {
            Name = "Facebook Accounting and Finance",
            Company = Facebook,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetMarketing = new Department
        {
            Name = "Alphabet Marketing",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetAccountingAndFinance = new Department
        {
            Name = "Alphabet Accounting and Finance",
            Company = Alphabet,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilMarketing = new Department
        {
            Name = "ExxonMobil Marketing",
            Company = ExxonMobil,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilAccountingAndFinance = new Department
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
            data.Add(WalmartMarketing);
            data.Add(WalmartAccountingAndFinance);
            data.Add(AmazonMarketing);
            data.Add(AmazonAccountingAndFinance);
            data.Add(AppleMarketing);
            data.Add(AppleAccountingAndFinance);
            data.Add(FordMotorMarketing);
            data.Add(FordMotorAccountingAndFinance);
            data.Add(FedExMarketing);
            data.Add(FedExAccountingAndFinance);
            data.Add(BankOfAmericaMarketing);
            data.Add(BankOfAmericaAccountingAndFinance);
            data.Add(JohnsonAndJohnsonMarketing);
            data.Add(JohnsonAndJohnsonAccountingAndFinance);
            data.Add(FacebookMarketing);
            data.Add(FacebookAccountingAndFinance);
            data.Add(AlphabetMarketing);
            data.Add(AlphabetAccountingAndFinance);
            data.Add(ExxonMobilMarketing);
            data.Add(ExxonMobilAccountingAndFinance);
        }
    }
}
