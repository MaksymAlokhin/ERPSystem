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
            CompanyState = CompanyState.Active
        };
        public static Company Amazon = new Company
        {
            Name = "Amazon",
            CompanyState = CompanyState.Active
        };
        public static Company Apple = new Company
        {
            Name = "Apple",
            CompanyState = CompanyState.Active
        };
        public static Company FordMotor = new Company
        {
            Name = "Ford Motor",
            CompanyState = CompanyState.Active
        };
        public static Company FedEx = new Company
        {
            Name = "FedEx",
            CompanyState = CompanyState.Active
        };
        public static Company BankOfAmerica = new Company
        {
            Name = "Bank Of America",
            CompanyState = CompanyState.Active
        };
        public static Company JohnsonAndJohnson = new Company
        {
            Name = "Johnson & Johnson",
            CompanyState = CompanyState.Active
        };
        public static Company Facebook = new Company
        {
            Name = "Facebook",
            CompanyState = CompanyState.Active
        };
        public static Company Alphabet = new Company
        {
            Name = "Alphabet",
            CompanyState = CompanyState.Active
        };
        public static Company ExxonMobil = new Company
        {
            Name = "Exxon Mobil",
            CompanyState = CompanyState.Active
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
            data.Add(FedEx);
            data.Add(BankOfAmerica);
            data.Add(JohnsonAndJohnson);
            data.Add(Facebook);
            data.Add(Alphabet);
            data.Add(ExxonMobil);
        }
    }
}
