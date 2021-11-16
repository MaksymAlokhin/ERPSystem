using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedMentor;
using static ERPSystem.Data.SeedBranch;

namespace ERPSystem.Data
{
    public static class SeedEmployee
    {
        #region Create Employees
        public static Employee e001 = new Employee
        {
            FirstName = "Beverly",
            LastName = "Diaz",
            DateOfBirth = DateTime.Parse("1993-09-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m001
            }
        };
        public static Employee e002 = new Employee
        {
            FirstName = "Jescie",
            LastName = "Webb",
            DateOfBirth = DateTime.Parse("1987-09-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e003 = new Employee
        {
            FirstName = "Deacon",
            LastName = "Bass",
            DateOfBirth = DateTime.Parse("1990-11-18"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e004 = new Employee
        {
            FirstName = "Felix",
            LastName = "Chapman",
            DateOfBirth = DateTime.Parse("1995-09-11"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e005 = new Employee
        {
            FirstName = "Alma",
            LastName = "O'donnell",
            DateOfBirth = DateTime.Parse("1984-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e006 = new Employee
        {
            FirstName = "Dante",
            LastName = "Gordon",
            DateOfBirth = DateTime.Parse("1994-10-04"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e007 = new Employee
        {
            FirstName = "Clarke",
            LastName = "Conley",
            DateOfBirth = DateTime.Parse("1996-04-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e008 = new Employee
        {
            FirstName = "Myles",
            LastName = "Turner",
            DateOfBirth = DateTime.Parse("1993-04-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e009 = new Employee
        {
            FirstName = "Leroy",
            LastName = "Morrow",
            DateOfBirth = DateTime.Parse("1988-03-15"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m002
            }
        };
        public static Employee e010 = new Employee
        {
            FirstName = "Charissa",
            LastName = "Conrad",
            DateOfBirth = DateTime.Parse("1997-07-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e011 = new Employee
        {
            FirstName = "Jocelyn",
            LastName = "Whitley",
            DateOfBirth = DateTime.Parse("1980-11-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e012 = new Employee
        {
            FirstName = "Nehru",
            LastName = "Mueller",
            DateOfBirth = DateTime.Parse("1995-01-20"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e013 = new Employee
        {
            FirstName = "Beau",
            LastName = "Travis",
            DateOfBirth = DateTime.Parse("1987-07-31"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e014 = new Employee
        {
            FirstName = "Gemma",
            LastName = "Brock",
            DateOfBirth = DateTime.Parse("1982-05-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e015 = new Employee
        {
            FirstName = "Elijah",
            LastName = "Richmond",
            DateOfBirth = DateTime.Parse("1983-03-02"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e016 = new Employee
        {
            FirstName = "Roth",
            LastName = "Randolph",
            DateOfBirth = DateTime.Parse("1993-10-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e017 = new Employee
        {
            FirstName = "Dante",
            LastName = "Glenn",
            DateOfBirth = DateTime.Parse("1992-10-22"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m003
            }
        };
        public static Employee e018 = new Employee
        {
            FirstName = "Ocean",
            LastName = "Vance",
            DateOfBirth = DateTime.Parse("1984-05-05"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e019 = new Employee
        {
            FirstName = "Ronan",
            LastName = "Lawrence",
            DateOfBirth = DateTime.Parse("1990-02-05"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e020 = new Employee
        {
            FirstName = "Robert",
            LastName = "Kirk",
            DateOfBirth = DateTime.Parse("1990-10-01"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e021 = new Employee
        {
            FirstName = "Marah",
            LastName = "Conner",
            DateOfBirth = DateTime.Parse("1998-12-03"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e022 = new Employee
        {
            FirstName = "Mason",
            LastName = "Sandoval",
            DateOfBirth = DateTime.Parse("1983-05-03"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e023 = new Employee
        {
            FirstName = "Stacey",
            LastName = "Lawrence",
            DateOfBirth = DateTime.Parse("1989-07-20"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e024 = new Employee
        {
            FirstName = "Orlando",
            LastName = "Miles",
            DateOfBirth = DateTime.Parse("1984-08-05"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e025 = new Employee
        {
            FirstName = "Savannah",
            LastName = "Hull",
            DateOfBirth = DateTime.Parse("1993-09-01"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m004
            }
        };
        public static Employee e026 = new Employee
        {
            FirstName = "George",
            LastName = "Bradley",
            DateOfBirth = DateTime.Parse("1995-03-29"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e027 = new Employee
        {
            FirstName = "Jerome",
            LastName = "Carlson",
            DateOfBirth = DateTime.Parse("1985-11-15"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e028 = new Employee
        {
            FirstName = "Bert",
            LastName = "Buckley",
            DateOfBirth = DateTime.Parse("1989-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e029 = new Employee
        {
            FirstName = "Wing",
            LastName = "Frank",
            DateOfBirth = DateTime.Parse("1993-06-11"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e030 = new Employee
        {
            FirstName = "Astra",
            LastName = "Chen",
            DateOfBirth = DateTime.Parse("1985-01-28"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e031 = new Employee
        {
            FirstName = "Amery",
            LastName = "Savage",
            DateOfBirth = DateTime.Parse("1982-01-19"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e032 = new Employee
        {
            FirstName = "Nicole",
            LastName = "Kelly",
            DateOfBirth = DateTime.Parse("1999-06-27"),
            EmployeeState = EmployeeState.Active,
            Branch = AmazonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e033 = new Employee
        {
            FirstName = "Maxine",
            LastName = "Cruz",
            DateOfBirth = DateTime.Parse("1981-09-05"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m005
            }
        };
        public static Employee e034 = new Employee
        {
            FirstName = "Alisa",
            LastName = "Fuller",
            DateOfBirth = DateTime.Parse("1985-11-29"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e035 = new Employee
        {
            FirstName = "Regina",
            LastName = "Estes",
            DateOfBirth = DateTime.Parse("2000-09-01"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e036 = new Employee
        {
            FirstName = "Adena",
            LastName = "Nixon",
            DateOfBirth = DateTime.Parse("1983-10-28"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e037 = new Employee
        {
            FirstName = "Bell",
            LastName = "Carson",
            DateOfBirth = DateTime.Parse("2001-05-23"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e038 = new Employee
        {
            FirstName = "Rahim",
            LastName = "Benson",
            DateOfBirth = DateTime.Parse("1984-10-16"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e039 = new Employee
        {
            FirstName = "Caesar",
            LastName = "Carpenter",
            DateOfBirth = DateTime.Parse("1990-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e040 = new Employee
        {
            FirstName = "Ezekiel",
            LastName = "Moore",
            DateOfBirth = DateTime.Parse("1983-09-08"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e041 = new Employee
        {
            FirstName = "Yasir",
            LastName = "Aguirre",
            DateOfBirth = DateTime.Parse("1997-05-20"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m006
            }
        };
        public static Employee e042 = new Employee
        {
            FirstName = "Jael",
            LastName = "Barrera",
            DateOfBirth = DateTime.Parse("1987-04-14"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e043 = new Employee
        {
            FirstName = "Garth",
            LastName = "Mueller",
            DateOfBirth = DateTime.Parse("1986-01-10"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e044 = new Employee
        {
            FirstName = "Solomon",
            LastName = "Malone",
            DateOfBirth = DateTime.Parse("2000-07-29"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e045 = new Employee
        {
            FirstName = "Hilary",
            LastName = "Mooney",
            DateOfBirth = DateTime.Parse("1997-08-26"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e046 = new Employee
        {
            FirstName = "Bert",
            LastName = "Boyd",
            DateOfBirth = DateTime.Parse("1984-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e047 = new Employee
        {
            FirstName = "Gregory",
            LastName = "Harrington",
            DateOfBirth = DateTime.Parse("1991-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e048 = new Employee
        {
            FirstName = "Odessa",
            LastName = "Good",
            DateOfBirth = DateTime.Parse("1998-10-13"),
            EmployeeState = EmployeeState.Active,
            Branch = AppleEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e049 = new Employee
        {
            FirstName = "September",
            LastName = "Adams",
            DateOfBirth = DateTime.Parse("1997-03-26"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m007
            }
        };
        public static Employee e050 = new Employee
        {
            FirstName = "Todd",
            LastName = "Dillon",
            DateOfBirth = DateTime.Parse("1989-08-04"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e051 = new Employee
        {
            FirstName = "Gemma",
            LastName = "Sanders",
            DateOfBirth = DateTime.Parse("1995-05-26"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e052 = new Employee
        {
            FirstName = "Echo",
            LastName = "Smith",
            DateOfBirth = DateTime.Parse("1999-05-10"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e053 = new Employee
        {
            FirstName = "Basia",
            LastName = "Lara",
            DateOfBirth = DateTime.Parse("1982-08-31"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e054 = new Employee
        {
            FirstName = "Petra",
            LastName = "Tate",
            DateOfBirth = DateTime.Parse("1990-05-25"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e055 = new Employee
        {
            FirstName = "Latifah",
            LastName = "Trevino",
            DateOfBirth = DateTime.Parse("1986-04-16"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e056 = new Employee
        {
            FirstName = "Nolan",
            LastName = "Padilla",
            DateOfBirth = DateTime.Parse("1996-07-21"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e057 = new Employee
        {
            FirstName = "Dennis",
            LastName = "Castro",
            DateOfBirth = DateTime.Parse("1983-10-21"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m008
            }
        };
        public static Employee e058 = new Employee
        {
            FirstName = "Coby",
            LastName = "Keith",
            DateOfBirth = DateTime.Parse("1994-08-13"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e059 = new Employee
        {
            FirstName = "Rhona",
            LastName = "Le",
            DateOfBirth = DateTime.Parse("1991-04-24"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e060 = new Employee
        {
            FirstName = "Colleen",
            LastName = "Key",
            DateOfBirth = DateTime.Parse("1982-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e061 = new Employee
        {
            FirstName = "Brennan",
            LastName = "Scott",
            DateOfBirth = DateTime.Parse("1994-12-11"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e062 = new Employee
        {
            FirstName = "Reese",
            LastName = "Britt",
            DateOfBirth = DateTime.Parse("1998-05-24"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e063 = new Employee
        {
            FirstName = "Gavin",
            LastName = "Richardson",
            DateOfBirth = DateTime.Parse("1993-03-07"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e064 = new Employee
        {
            FirstName = "Lucius",
            LastName = "Stewart",
            DateOfBirth = DateTime.Parse("1995-10-26"),
            EmployeeState = EmployeeState.Active,
            Branch = FordMotorEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e065 = new Employee
        {
            FirstName = "Cheryl",
            LastName = "Atkinson",
            DateOfBirth = DateTime.Parse("1984-12-30"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m009
            }
        };
        public static Employee e066 = new Employee
        {
            FirstName = "Teagan",
            LastName = "Mccormick",
            DateOfBirth = DateTime.Parse("1991-04-10"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e067 = new Employee
        {
            FirstName = "Palmer",
            LastName = "Mayer",
            DateOfBirth = DateTime.Parse("1994-11-21"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e068 = new Employee
        {
            FirstName = "Nash",
            LastName = "Lang",
            DateOfBirth = DateTime.Parse("1996-02-14"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e069 = new Employee
        {
            FirstName = "April",
            LastName = "Quinn",
            DateOfBirth = DateTime.Parse("2001-08-18"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e070 = new Employee
        {
            FirstName = "Addison",
            LastName = "Donovan",
            DateOfBirth = DateTime.Parse("1990-01-16"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e071 = new Employee
        {
            FirstName = "Jescie",
            LastName = "Crane",
            DateOfBirth = DateTime.Parse("1986-09-14"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e072 = new Employee
        {
            FirstName = "Darius",
            LastName = "Price",
            DateOfBirth = DateTime.Parse("1998-01-23"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e073 = new Employee
        {
            FirstName = "Savannah",
            LastName = "Kirby",
            DateOfBirth = DateTime.Parse("1986-11-11"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m010
            }
        };
        public static Employee e074 = new Employee
        {
            FirstName = "Malachi",
            LastName = "Riddle",
            DateOfBirth = DateTime.Parse("1985-07-08"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e075 = new Employee
        {
            FirstName = "Cassandra",
            LastName = "Harrell",
            DateOfBirth = DateTime.Parse("1990-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e076 = new Employee
        {
            FirstName = "Whilemina",
            LastName = "Cantrell",
            DateOfBirth = DateTime.Parse("1986-06-27"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e077 = new Employee
        {
            FirstName = "Alec",
            LastName = "Larsen",
            DateOfBirth = DateTime.Parse("1999-09-22"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e078 = new Employee
        {
            FirstName = "Marvin",
            LastName = "Bell",
            DateOfBirth = DateTime.Parse("1987-01-21"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e079 = new Employee
        {
            FirstName = "Jared",
            LastName = "Atkins",
            DateOfBirth = DateTime.Parse("1997-02-21"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e080 = new Employee
        {
            FirstName = "Olympia",
            LastName = "Cameron",
            DateOfBirth = DateTime.Parse("1997-12-22"),
            EmployeeState = EmployeeState.Active,
            Branch = FedExEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e081 = new Employee
        {
            FirstName = "Ramona",
            LastName = "Hurley",
            DateOfBirth = DateTime.Parse("1997-04-13"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m011
            }
        };
        public static Employee e082 = new Employee
        {
            FirstName = "Driscoll",
            LastName = "Houston",
            DateOfBirth = DateTime.Parse("1981-04-17"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e083 = new Employee
        {
            FirstName = "Hope",
            LastName = "Patrick",
            DateOfBirth = DateTime.Parse("1993-02-28"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e084 = new Employee
        {
            FirstName = "Cameron",
            LastName = "Mendez",
            DateOfBirth = DateTime.Parse("1982-05-16"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e085 = new Employee
        {
            FirstName = "Oleg",
            LastName = "Kidd",
            DateOfBirth = DateTime.Parse("1981-03-06"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e086 = new Employee
        {
            FirstName = "Candice",
            LastName = "Burnett",
            DateOfBirth = DateTime.Parse("1999-02-17"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e087 = new Employee
        {
            FirstName = "Abra",
            LastName = "Berger",
            DateOfBirth = DateTime.Parse("1989-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e088 = new Employee
        {
            FirstName = "Simon",
            LastName = "Griffin",
            DateOfBirth = DateTime.Parse("1995-04-29"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e089 = new Employee
        {
            FirstName = "Hollee",
            LastName = "Mckinney",
            DateOfBirth = DateTime.Parse("1987-09-03"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m012
            }
        };
        public static Employee e090 = new Employee
        {
            FirstName = "Yoshi",
            LastName = "Burt",
            DateOfBirth = DateTime.Parse("1999-10-18"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e091 = new Employee
        {
            FirstName = "Dieter",
            LastName = "Stevenson",
            DateOfBirth = DateTime.Parse("2001-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e092 = new Employee
        {
            FirstName = "Brenden",
            LastName = "Gibbs",
            DateOfBirth = DateTime.Parse("1984-05-09"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e093 = new Employee
        {
            FirstName = "Deanna",
            LastName = "Hancock",
            DateOfBirth = DateTime.Parse("2001-10-03"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e094 = new Employee
        {
            FirstName = "Burton",
            LastName = "Boyd",
            DateOfBirth = DateTime.Parse("2001-09-08"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e095 = new Employee
        {
            FirstName = "Caryn",
            LastName = "Merritt",
            DateOfBirth = DateTime.Parse("1988-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e096 = new Employee
        {
            FirstName = "Madison",
            LastName = "Finley",
            DateOfBirth = DateTime.Parse("1985-03-14"),
            EmployeeState = EmployeeState.Active,
            Branch = BankOfAmericaEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e097 = new Employee
        {
            FirstName = "Karly",
            LastName = "Chang",
            DateOfBirth = DateTime.Parse("1993-04-08"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m013
            }
        };
        public static Employee e098 = new Employee
        {
            FirstName = "Magee",
            LastName = "Dotson",
            DateOfBirth = DateTime.Parse("1986-08-26"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e099 = new Employee
        {
            FirstName = "Liberty",
            LastName = "Woodward",
            DateOfBirth = DateTime.Parse("1990-02-21"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e100 = new Employee
        {
            FirstName = "Phelan",
            LastName = "Douglas",
            DateOfBirth = DateTime.Parse("1984-09-29"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e101 = new Employee
        {
            FirstName = "Alec",
            LastName = "Sampson",
            DateOfBirth = DateTime.Parse("2000-07-27"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e102 = new Employee
        {
            FirstName = "Brennan",
            LastName = "Gutierrez",
            DateOfBirth = DateTime.Parse("1984-01-30"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e103 = new Employee
        {
            FirstName = "Oleg",
            LastName = "Atkinson",
            DateOfBirth = DateTime.Parse("1986-11-25"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e104 = new Employee
        {
            FirstName = "Hanna",
            LastName = "Delgado",
            DateOfBirth = DateTime.Parse("1987-01-20"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e105 = new Employee
        {
            FirstName = "Kibo",
            LastName = "Rose",
            DateOfBirth = DateTime.Parse("1994-07-22"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m014
            }
        };
        public static Employee e106 = new Employee
        {
            FirstName = "Felicia",
            LastName = "Snow",
            DateOfBirth = DateTime.Parse("1984-06-21"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e107 = new Employee
        {
            FirstName = "Brock",
            LastName = "Thornton",
            DateOfBirth = DateTime.Parse("1990-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e108 = new Employee
        {
            FirstName = "Lester",
            LastName = "Gray",
            DateOfBirth = DateTime.Parse("1981-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e109 = new Employee
        {
            FirstName = "Allegra",
            LastName = "Orr",
            DateOfBirth = DateTime.Parse("1985-01-24"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e110 = new Employee
        {
            FirstName = "Kyla",
            LastName = "Stark",
            DateOfBirth = DateTime.Parse("1983-01-28"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e111 = new Employee
        {
            FirstName = "Lyle",
            LastName = "Mcintyre",
            DateOfBirth = DateTime.Parse("1999-10-21"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e112 = new Employee
        {
            FirstName = "Anika",
            LastName = "Lamb",
            DateOfBirth = DateTime.Parse("2001-09-09"),
            EmployeeState = EmployeeState.Active,
            Branch = JohnsonAndJohnsonEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e113 = new Employee
        {
            FirstName = "Dara",
            LastName = "Garrison",
            DateOfBirth = DateTime.Parse("1984-04-06"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m015
            }
        };
        public static Employee e114 = new Employee
        {
            FirstName = "Preston",
            LastName = "Wolfe",
            DateOfBirth = DateTime.Parse("1982-12-04"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e115 = new Employee
        {
            FirstName = "Kenyon",
            LastName = "Baxter",
            DateOfBirth = DateTime.Parse("1983-08-31"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e116 = new Employee
        {
            FirstName = "Ivan",
            LastName = "Fischer",
            DateOfBirth = DateTime.Parse("2001-05-09"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e117 = new Employee
        {
            FirstName = "Armand",
            LastName = "Mcintosh",
            DateOfBirth = DateTime.Parse("1980-12-04"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e118 = new Employee
        {
            FirstName = "Knox",
            LastName = "Rutledge",
            DateOfBirth = DateTime.Parse("2001-01-02"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e119 = new Employee
        {
            FirstName = "Quin",
            LastName = "Robbins",
            DateOfBirth = DateTime.Parse("1996-07-02"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e120 = new Employee
        {
            FirstName = "John",
            LastName = "Talley",
            DateOfBirth = DateTime.Parse("1985-05-23"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e121 = new Employee
        {
            FirstName = "Orlando",
            LastName = "Odom",
            DateOfBirth = DateTime.Parse("1995-02-20"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m016
            }
        };
        public static Employee e122 = new Employee
        {
            FirstName = "Renee",
            LastName = "Harper",
            DateOfBirth = DateTime.Parse("1998-04-14"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e123 = new Employee
        {
            FirstName = "Dominic",
            LastName = "Powers",
            DateOfBirth = DateTime.Parse("1996-09-07"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e124 = new Employee
        {
            FirstName = "Petra",
            LastName = "Kinney",
            DateOfBirth = DateTime.Parse("1987-08-15"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e125 = new Employee
        {
            FirstName = "Ramona",
            LastName = "Cannon",
            DateOfBirth = DateTime.Parse("1990-12-01"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e126 = new Employee
        {
            FirstName = "Naida",
            LastName = "Vance",
            DateOfBirth = DateTime.Parse("1984-01-27"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e127 = new Employee
        {
            FirstName = "Jin",
            LastName = "Garrett",
            DateOfBirth = DateTime.Parse("1982-08-23"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e128 = new Employee
        {
            FirstName = "Brenden",
            LastName = "Emerson",
            DateOfBirth = DateTime.Parse("1984-10-03"),
            EmployeeState = EmployeeState.Active,
            Branch = FacebookEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e129 = new Employee
        {
            FirstName = "Walter",
            LastName = "Ashley",
            DateOfBirth = DateTime.Parse("1995-11-30"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m017
            }
        };
        public static Employee e130 = new Employee
        {
            FirstName = "Vanna",
            LastName = "Stafford",
            DateOfBirth = DateTime.Parse("1984-08-04"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e131 = new Employee
        {
            FirstName = "Yen",
            LastName = "Jennings",
            DateOfBirth = DateTime.Parse("1993-02-07"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e132 = new Employee
        {
            FirstName = "Elliott",
            LastName = "Moran",
            DateOfBirth = DateTime.Parse("1998-12-03"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e133 = new Employee
        {
            FirstName = "Hannah",
            LastName = "Garza",
            DateOfBirth = DateTime.Parse("1986-09-15"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e134 = new Employee
        {
            FirstName = "Bree",
            LastName = "Coleman",
            DateOfBirth = DateTime.Parse("1990-05-17"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e135 = new Employee
        {
            FirstName = "Dalton",
            LastName = "Christensen",
            DateOfBirth = DateTime.Parse("1994-03-10"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e136 = new Employee
        {
            FirstName = "Dieter",
            LastName = "Grant",
            DateOfBirth = DateTime.Parse("1997-05-01"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e137 = new Employee
        {
            FirstName = "Rahim",
            LastName = "Butler",
            DateOfBirth = DateTime.Parse("1990-10-20"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m018
            }
        };
        public static Employee e138 = new Employee
        {
            FirstName = "Dorothy",
            LastName = "Burt",
            DateOfBirth = DateTime.Parse("2000-04-29"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e139 = new Employee
        {
            FirstName = "Daquan",
            LastName = "Mack",
            DateOfBirth = DateTime.Parse("1981-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e140 = new Employee
        {
            FirstName = "Giselle",
            LastName = "Knight",
            DateOfBirth = DateTime.Parse("1984-05-29"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e141 = new Employee
        {
            FirstName = "Winter",
            LastName = "Guy",
            DateOfBirth = DateTime.Parse("1989-03-25"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e142 = new Employee
        {
            FirstName = "Ocean",
            LastName = "Malone",
            DateOfBirth = DateTime.Parse("2001-06-20"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e143 = new Employee
        {
            FirstName = "Lavinia",
            LastName = "Hubbard",
            DateOfBirth = DateTime.Parse("1981-02-06"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e144 = new Employee
        {
            FirstName = "Anastasia",
            LastName = "Gibbs",
            DateOfBirth = DateTime.Parse("1997-10-09"),
            EmployeeState = EmployeeState.Active,
            Branch = AlphabetEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e145 = new Employee
        {
            FirstName = "Laith",
            LastName = "Vargas",
            DateOfBirth = DateTime.Parse("1994-08-24"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m019
            }
        };
        public static Employee e146 = new Employee
        {
            FirstName = "Dylan",
            LastName = "Mcbride",
            DateOfBirth = DateTime.Parse("1981-05-16"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e147 = new Employee
        {
            FirstName = "Hadley",
            LastName = "Fisher",
            DateOfBirth = DateTime.Parse("1987-08-19"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e148 = new Employee
        {
            FirstName = "Lynn",
            LastName = "Huffman",
            DateOfBirth = DateTime.Parse("1991-09-18"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e149 = new Employee
        {
            FirstName = "Jordan",
            LastName = "Tate",
            DateOfBirth = DateTime.Parse("1987-09-26"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e150 = new Employee
        {
            FirstName = "Jeanette",
            LastName = "Estes",
            DateOfBirth = DateTime.Parse("1996-03-18"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e151 = new Employee
        {
            FirstName = "Montana",
            LastName = "Battle",
            DateOfBirth = DateTime.Parse("1992-12-25"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e152 = new Employee
        {
            FirstName = "Otto",
            LastName = "Clements",
            DateOfBirth = DateTime.Parse("1997-09-04"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilNorthAmerica,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e153 = new Employee
        {
            FirstName = "Karyn",
            LastName = "Montoya",
            DateOfBirth = DateTime.Parse("1996-12-27"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee,
            Mentors = new List<Employee>
            {
                m020
            }
        };
        public static Employee e154 = new Employee
        {
            FirstName = "Amber",
            LastName = "Albert",
            DateOfBirth = DateTime.Parse("1981-04-26"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e155 = new Employee
        {
            FirstName = "Harlan",
            LastName = "Suarez",
            DateOfBirth = DateTime.Parse("1991-01-09"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e156 = new Employee
        {
            FirstName = "Rigel",
            LastName = "Walls",
            DateOfBirth = DateTime.Parse("1992-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e157 = new Employee
        {
            FirstName = "Lydia",
            LastName = "Vincent",
            DateOfBirth = DateTime.Parse("1989-10-17"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e158 = new Employee
        {
            FirstName = "Florence",
            LastName = "Hutchinson",
            DateOfBirth = DateTime.Parse("1985-07-07"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e159 = new Employee
        {
            FirstName = "Hayden",
            LastName = "Walton",
            DateOfBirth = DateTime.Parse("2000-10-15"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        public static Employee e160 = new Employee
        {
            FirstName = "Orson",
            LastName = "Morton",
            DateOfBirth = DateTime.Parse("1997-11-30"),
            EmployeeState = EmployeeState.Active,
            Branch = ExxonMobilEurope,
            EmployeeRole = EmployeeRole.Employee
        };
        #endregion
        public static List<Employee> data;
        static SeedEmployee()
        {
            data = new List<Employee>();
            data.Add(e001);
            data.Add(e002);
            data.Add(e003);
            data.Add(e004);
            data.Add(e005);
            data.Add(e006);
            data.Add(e007);
            data.Add(e008);
            data.Add(e009);
            data.Add(e010);
            data.Add(e011);
            data.Add(e012);
            data.Add(e013);
            data.Add(e014);
            data.Add(e015);
            data.Add(e016);
            data.Add(e017);
            data.Add(e018);
            data.Add(e019);
            data.Add(e020);
            data.Add(e021);
            data.Add(e022);
            data.Add(e023);
            data.Add(e024);
            data.Add(e025);
            data.Add(e026);
            data.Add(e027);
            data.Add(e028);
            data.Add(e029);
            data.Add(e030);
            data.Add(e031);
            data.Add(e032);
            data.Add(e033);
            data.Add(e034);
            data.Add(e035);
            data.Add(e036);
            data.Add(e037);
            data.Add(e038);
            data.Add(e039);
            data.Add(e040);
            data.Add(e041);
            data.Add(e042);
            data.Add(e043);
            data.Add(e044);
            data.Add(e045);
            data.Add(e046);
            data.Add(e047);
            data.Add(e048);
            data.Add(e049);
            data.Add(e050);
            data.Add(e051);
            data.Add(e052);
            data.Add(e053);
            data.Add(e054);
            data.Add(e055);
            data.Add(e056);
            data.Add(e057);
            data.Add(e058);
            data.Add(e059);
            data.Add(e060);
            data.Add(e061);
            data.Add(e062);
            data.Add(e063);
            data.Add(e064);
            data.Add(e065);
            data.Add(e066);
            data.Add(e067);
            data.Add(e068);
            data.Add(e069);
            data.Add(e070);
            data.Add(e071);
            data.Add(e072);
            data.Add(e073);
            data.Add(e074);
            data.Add(e075);
            data.Add(e076);
            data.Add(e077);
            data.Add(e078);
            data.Add(e079);
            data.Add(e080);
            data.Add(e081);
            data.Add(e082);
            data.Add(e083);
            data.Add(e084);
            data.Add(e085);
            data.Add(e086);
            data.Add(e087);
            data.Add(e088);
            data.Add(e089);
            data.Add(e090);
            data.Add(e091);
            data.Add(e092);
            data.Add(e093);
            data.Add(e094);
            data.Add(e095);
            data.Add(e096);
            data.Add(e097);
            data.Add(e098);
            data.Add(e099);
            data.Add(e100);
            data.Add(e101);
            data.Add(e102);
            data.Add(e103);
            data.Add(e104);
            data.Add(e105);
            data.Add(e106);
            data.Add(e107);
            data.Add(e108);
            data.Add(e109);
            data.Add(e110);
            data.Add(e111);
            data.Add(e112);
            data.Add(e113);
            data.Add(e114);
            data.Add(e115);
            data.Add(e116);
            data.Add(e117);
            data.Add(e118);
            data.Add(e119);
            data.Add(e120);
            data.Add(e121);
            data.Add(e122);
            data.Add(e123);
            data.Add(e124);
            data.Add(e125);
            data.Add(e126);
            data.Add(e127);
            data.Add(e128);
            data.Add(e129);
            data.Add(e130);
            data.Add(e131);
            data.Add(e132);
            data.Add(e133);
            data.Add(e134);
            data.Add(e135);
            data.Add(e136);
            data.Add(e137);
            data.Add(e138);
            data.Add(e139);
            data.Add(e140);
            data.Add(e141);
            data.Add(e142);
            data.Add(e143);
            data.Add(e144);
            data.Add(e145);
            data.Add(e146);
            data.Add(e147);
            data.Add(e148);
            data.Add(e149);
            data.Add(e150);
            data.Add(e151);
            data.Add(e152);
            data.Add(e153);
            data.Add(e154);
            data.Add(e155);
            data.Add(e156);
            data.Add(e157);
            data.Add(e158);
            data.Add(e159);
            data.Add(e160);
        }
    }
}
