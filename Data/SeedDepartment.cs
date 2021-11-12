using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedDepartmentHead;

namespace ERPSystem.Data
{
    public static class SeedDepartment
    {
        #region Create Departments
        public static Department WalmartProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh001,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh002,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh003,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh004,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh005,
            DepartmentState = DepartmentState.Active
        };
        public static Department WalmartAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh006,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh007,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh008,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh009,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh010,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh011,
            DepartmentState = DepartmentState.Active
        };
        public static Department AmazonAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh012,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh013,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh014,
            DepartmentState = DepartmentState.Active
        };
        public static Department ApplePurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh015,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh016,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh017,
            DepartmentState = DepartmentState.Active
        };
        public static Department AppleAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh018,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh019,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh020,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh021,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh022,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh023,
            DepartmentState = DepartmentState.Active
        };
        public static Department FordMotorAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh024,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh025,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh026,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh027,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh028,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh029,
            DepartmentState = DepartmentState.Active
        };
        public static Department MicrosoftAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh030,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh031,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh032,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh033,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh034,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh035,
            DepartmentState = DepartmentState.Active
        };
        public static Department BankOfAmericaAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh036,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh037,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh038,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh039,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh040,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh041,
            DepartmentState = DepartmentState.Active
        };
        public static Department JohnsonAndJohnsonAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh042,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh043,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh044,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh045,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh046,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh047,
            DepartmentState = DepartmentState.Active
        };
        public static Department FacebookAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh048,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh049,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh050,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh051,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh052,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh053,
            DepartmentState = DepartmentState.Active
        };
        public static Department AlphabetAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh054,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilProduction = new Department
        {
            Name = "Production",
            DepartmentHead = dh055,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilResearchandDevelopment = new Department
        {
            Name = "Research and Development",
            DepartmentHead = dh056,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilPurchasing = new Department
        {
            Name = "Purchasing",
            DepartmentHead = dh057,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilMarketing = new Department
        {
            Name = "Marketing",
            DepartmentHead = dh058,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilHumanResourceManagement = new Department
        {
            Name = "Human Resource Management",
            DepartmentHead = dh059,
            DepartmentState = DepartmentState.Active
        };
        public static Department ExxonMobilAccountingandFinance = new Department
        {
            Name = "Accounting and Finance",
            DepartmentHead = dh060,
            DepartmentState = DepartmentState.Active
        };
        #endregion
    }
}
