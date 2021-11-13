using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedMentor;
using static ERPSystem.Data.SeedBranch;

namespace ERPSystem.Data
{
    public static class SeedWorker
    {
        #region Create Workers
        public static Worker w001 = new Worker
        {
            FirstName = "Beverly",
            LastName = "Diaz",
            DateOfBirth = DateTime.Parse("1993-09-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m001
            }
        };
        public static Worker w002 = new Worker
        {
            FirstName = "Jescie",
            LastName = "Webb",
            DateOfBirth = DateTime.Parse("1987-09-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m002
            }
        };
        public static Worker w003 = new Worker
        {
            FirstName = "Deacon",
            LastName = "Bass",
            DateOfBirth = DateTime.Parse("1990-11-18"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m003
            }
        };
        public static Worker w004 = new Worker
        {
            FirstName = "Felix",
            LastName = "Chapman",
            DateOfBirth = DateTime.Parse("1995-09-11"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m004
            }
        };
        public static Worker w005 = new Worker
        {
            FirstName = "Alma",
            LastName = "O'donnell",
            DateOfBirth = DateTime.Parse("1984-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m005
            }
        };
        public static Worker w006 = new Worker
        {
            FirstName = "Dante",
            LastName = "Gordon",
            DateOfBirth = DateTime.Parse("1994-10-04"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m006
            }
        };
        public static Worker w007 = new Worker
        {
            FirstName = "Clarke",
            LastName = "Conley",
            DateOfBirth = DateTime.Parse("1996-04-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m007
            }
        };
        public static Worker w008 = new Worker
        {
            FirstName = "Myles",
            LastName = "Turner",
            DateOfBirth = DateTime.Parse("1993-04-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m008
            }
        };
        public static Worker w009 = new Worker
        {
            FirstName = "Leroy",
            LastName = "Morrow",
            DateOfBirth = DateTime.Parse("1988-03-15"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m009
            }
        };
        public static Worker w010 = new Worker
        {
            FirstName = "Charissa",
            LastName = "Conrad",
            DateOfBirth = DateTime.Parse("1997-07-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
            Mentors = new List<Mentor>
            {
                m010
            }
        };
        public static Worker w011 = new Worker
        {
            FirstName = "Jocelyn",
            LastName = "Whitley",
            DateOfBirth = DateTime.Parse("1980-11-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w012 = new Worker
        {
            FirstName = "Nehru",
            LastName = "Mueller",
            DateOfBirth = DateTime.Parse("1995-01-20"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w013 = new Worker
        {
            FirstName = "Beau",
            LastName = "Travis",
            DateOfBirth = DateTime.Parse("1987-07-31"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w014 = new Worker
        {
            FirstName = "Gemma",
            LastName = "Brock",
            DateOfBirth = DateTime.Parse("1982-05-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w015 = new Worker
        {
            FirstName = "Elijah",
            LastName = "Richmond",
            DateOfBirth = DateTime.Parse("1983-03-02"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w016 = new Worker
        {
            FirstName = "Roth",
            LastName = "Randolph",
            DateOfBirth = DateTime.Parse("1993-10-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w017 = new Worker
        {
            FirstName = "Dante",
            LastName = "Glenn",
            DateOfBirth = DateTime.Parse("1992-10-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w018 = new Worker
        {
            FirstName = "Ocean",
            LastName = "Vance",
            DateOfBirth = DateTime.Parse("1984-05-05"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w019 = new Worker
        {
            FirstName = "Ronan",
            LastName = "Lawrence",
            DateOfBirth = DateTime.Parse("1990-02-05"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w020 = new Worker
        {
            FirstName = "Robert",
            LastName = "Kirk",
            DateOfBirth = DateTime.Parse("1990-10-01"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w021 = new Worker
        {
            FirstName = "Marah",
            LastName = "Conner",
            DateOfBirth = DateTime.Parse("1998-12-03"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w022 = new Worker
        {
            FirstName = "Mason",
            LastName = "Sandoval",
            DateOfBirth = DateTime.Parse("1983-05-03"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w023 = new Worker
        {
            FirstName = "Stacey",
            LastName = "Lawrence",
            DateOfBirth = DateTime.Parse("1989-07-20"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w024 = new Worker
        {
            FirstName = "Orlando",
            LastName = "Miles",
            DateOfBirth = DateTime.Parse("1984-08-05"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w025 = new Worker
        {
            FirstName = "Savannah",
            LastName = "Hull",
            DateOfBirth = DateTime.Parse("1993-09-01"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w026 = new Worker
        {
            FirstName = "George",
            LastName = "Bradley",
            DateOfBirth = DateTime.Parse("1995-03-29"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w027 = new Worker
        {
            FirstName = "Jerome",
            LastName = "Carlson",
            DateOfBirth = DateTime.Parse("1985-11-15"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w028 = new Worker
        {
            FirstName = "Bert",
            LastName = "Buckley",
            DateOfBirth = DateTime.Parse("1989-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w029 = new Worker
        {
            FirstName = "Wing",
            LastName = "Frank",
            DateOfBirth = DateTime.Parse("1993-06-11"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w030 = new Worker
        {
            FirstName = "Astra",
            LastName = "Chen",
            DateOfBirth = DateTime.Parse("1985-01-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w031 = new Worker
        {
            FirstName = "Amery",
            LastName = "Savage",
            DateOfBirth = DateTime.Parse("1982-01-19"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w032 = new Worker
        {
            FirstName = "Nicole",
            LastName = "Kelly",
            DateOfBirth = DateTime.Parse("1999-06-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w033 = new Worker
        {
            FirstName = "Maxine",
            LastName = "Cruz",
            DateOfBirth = DateTime.Parse("1981-09-05"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w034 = new Worker
        {
            FirstName = "Alisa",
            LastName = "Fuller",
            DateOfBirth = DateTime.Parse("1985-11-29"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w035 = new Worker
        {
            FirstName = "Regina",
            LastName = "Estes",
            DateOfBirth = DateTime.Parse("2000-09-01"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w036 = new Worker
        {
            FirstName = "Adena",
            LastName = "Nixon",
            DateOfBirth = DateTime.Parse("1983-10-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w037 = new Worker
        {
            FirstName = "Bell",
            LastName = "Carson",
            DateOfBirth = DateTime.Parse("2001-05-23"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w038 = new Worker
        {
            FirstName = "Rahim",
            LastName = "Benson",
            DateOfBirth = DateTime.Parse("1984-10-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w039 = new Worker
        {
            FirstName = "Caesar",
            LastName = "Carpenter",
            DateOfBirth = DateTime.Parse("1990-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w040 = new Worker
        {
            FirstName = "Ezekiel",
            LastName = "Moore",
            DateOfBirth = DateTime.Parse("1983-09-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w041 = new Worker
        {
            FirstName = "Yasir",
            LastName = "Aguirre",
            DateOfBirth = DateTime.Parse("1997-05-20"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w042 = new Worker
        {
            FirstName = "Jael",
            LastName = "Barrera",
            DateOfBirth = DateTime.Parse("1987-04-14"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w043 = new Worker
        {
            FirstName = "Garth",
            LastName = "Mueller",
            DateOfBirth = DateTime.Parse("1986-01-10"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w044 = new Worker
        {
            FirstName = "Solomon",
            LastName = "Malone",
            DateOfBirth = DateTime.Parse("2000-07-29"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w045 = new Worker
        {
            FirstName = "Hilary",
            LastName = "Mooney",
            DateOfBirth = DateTime.Parse("1997-08-26"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w046 = new Worker
        {
            FirstName = "Bert",
            LastName = "Boyd",
            DateOfBirth = DateTime.Parse("1984-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w047 = new Worker
        {
            FirstName = "Gregory",
            LastName = "Harrington",
            DateOfBirth = DateTime.Parse("1991-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w048 = new Worker
        {
            FirstName = "Odessa",
            LastName = "Good",
            DateOfBirth = DateTime.Parse("1998-10-13"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w049 = new Worker
        {
            FirstName = "September",
            LastName = "Adams",
            DateOfBirth = DateTime.Parse("1997-03-26"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w050 = new Worker
        {
            FirstName = "Todd",
            LastName = "Dillon",
            DateOfBirth = DateTime.Parse("1989-08-04"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w051 = new Worker
        {
            FirstName = "Gemma",
            LastName = "Sanders",
            DateOfBirth = DateTime.Parse("1995-05-26"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w052 = new Worker
        {
            FirstName = "Echo",
            LastName = "Smith",
            DateOfBirth = DateTime.Parse("1999-05-10"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w053 = new Worker
        {
            FirstName = "Basia",
            LastName = "Lara",
            DateOfBirth = DateTime.Parse("1982-08-31"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w054 = new Worker
        {
            FirstName = "Petra",
            LastName = "Tate",
            DateOfBirth = DateTime.Parse("1990-05-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w055 = new Worker
        {
            FirstName = "Latifah",
            LastName = "Trevino",
            DateOfBirth = DateTime.Parse("1986-04-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w056 = new Worker
        {
            FirstName = "Nolan",
            LastName = "Padilla",
            DateOfBirth = DateTime.Parse("1996-07-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w057 = new Worker
        {
            FirstName = "Dennis",
            LastName = "Castro",
            DateOfBirth = DateTime.Parse("1983-10-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w058 = new Worker
        {
            FirstName = "Coby",
            LastName = "Keith",
            DateOfBirth = DateTime.Parse("1994-08-13"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w059 = new Worker
        {
            FirstName = "Rhona",
            LastName = "Le",
            DateOfBirth = DateTime.Parse("1991-04-24"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w060 = new Worker
        {
            FirstName = "Colleen",
            LastName = "Key",
            DateOfBirth = DateTime.Parse("1982-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w061 = new Worker
        {
            FirstName = "Brennan",
            LastName = "Scott",
            DateOfBirth = DateTime.Parse("1994-12-11"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w062 = new Worker
        {
            FirstName = "Reese",
            LastName = "Britt",
            DateOfBirth = DateTime.Parse("1998-05-24"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w063 = new Worker
        {
            FirstName = "Gavin",
            LastName = "Richardson",
            DateOfBirth = DateTime.Parse("1993-03-07"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w064 = new Worker
        {
            FirstName = "Lucius",
            LastName = "Stewart",
            DateOfBirth = DateTime.Parse("1995-10-26"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w065 = new Worker
        {
            FirstName = "Cheryl",
            LastName = "Atkinson",
            DateOfBirth = DateTime.Parse("1984-12-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w066 = new Worker
        {
            FirstName = "Teagan",
            LastName = "Mccormick",
            DateOfBirth = DateTime.Parse("1991-04-10"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w067 = new Worker
        {
            FirstName = "Palmer",
            LastName = "Mayer",
            DateOfBirth = DateTime.Parse("1994-11-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w068 = new Worker
        {
            FirstName = "Nash",
            LastName = "Lang",
            DateOfBirth = DateTime.Parse("1996-02-14"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w069 = new Worker
        {
            FirstName = "April",
            LastName = "Quinn",
            DateOfBirth = DateTime.Parse("2001-08-18"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w070 = new Worker
        {
            FirstName = "Addison",
            LastName = "Donovan",
            DateOfBirth = DateTime.Parse("1990-01-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w071 = new Worker
        {
            FirstName = "Jescie",
            LastName = "Crane",
            DateOfBirth = DateTime.Parse("1986-09-14"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w072 = new Worker
        {
            FirstName = "Darius",
            LastName = "Price",
            DateOfBirth = DateTime.Parse("1998-01-23"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w073 = new Worker
        {
            FirstName = "Savannah",
            LastName = "Kirby",
            DateOfBirth = DateTime.Parse("1986-11-11"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w074 = new Worker
        {
            FirstName = "Malachi",
            LastName = "Riddle",
            DateOfBirth = DateTime.Parse("1985-07-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w075 = new Worker
        {
            FirstName = "Cassandra",
            LastName = "Harrell",
            DateOfBirth = DateTime.Parse("1990-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w076 = new Worker
        {
            FirstName = "Whilemina",
            LastName = "Cantrell",
            DateOfBirth = DateTime.Parse("1986-06-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w077 = new Worker
        {
            FirstName = "Alec",
            LastName = "Larsen",
            DateOfBirth = DateTime.Parse("1999-09-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w078 = new Worker
        {
            FirstName = "Marvin",
            LastName = "Bell",
            DateOfBirth = DateTime.Parse("1987-01-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w079 = new Worker
        {
            FirstName = "Jared",
            LastName = "Atkins",
            DateOfBirth = DateTime.Parse("1997-02-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w080 = new Worker
        {
            FirstName = "Olympia",
            LastName = "Cameron",
            DateOfBirth = DateTime.Parse("1997-12-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w081 = new Worker
        {
            FirstName = "Ramona",
            LastName = "Hurley",
            DateOfBirth = DateTime.Parse("1997-04-13"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w082 = new Worker
        {
            FirstName = "Driscoll",
            LastName = "Houston",
            DateOfBirth = DateTime.Parse("1981-04-17"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w083 = new Worker
        {
            FirstName = "Hope",
            LastName = "Patrick",
            DateOfBirth = DateTime.Parse("1993-02-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w084 = new Worker
        {
            FirstName = "Cameron",
            LastName = "Mendez",
            DateOfBirth = DateTime.Parse("1982-05-16"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w085 = new Worker
        {
            FirstName = "Oleg",
            LastName = "Kidd",
            DateOfBirth = DateTime.Parse("1981-03-06"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w086 = new Worker
        {
            FirstName = "Candice",
            LastName = "Burnett",
            DateOfBirth = DateTime.Parse("1999-02-17"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w087 = new Worker
        {
            FirstName = "Abra",
            LastName = "Berger",
            DateOfBirth = DateTime.Parse("1989-04-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w088 = new Worker
        {
            FirstName = "Simon",
            LastName = "Griffin",
            DateOfBirth = DateTime.Parse("1995-04-29"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w089 = new Worker
        {
            FirstName = "Hollee",
            LastName = "Mckinney",
            DateOfBirth = DateTime.Parse("1987-09-03"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w090 = new Worker
        {
            FirstName = "Yoshi",
            LastName = "Burt",
            DateOfBirth = DateTime.Parse("1999-10-18"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w091 = new Worker
        {
            FirstName = "Dieter",
            LastName = "Stevenson",
            DateOfBirth = DateTime.Parse("2001-07-19"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w092 = new Worker
        {
            FirstName = "Brenden",
            LastName = "Gibbs",
            DateOfBirth = DateTime.Parse("1984-05-09"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w093 = new Worker
        {
            FirstName = "Deanna",
            LastName = "Hancock",
            DateOfBirth = DateTime.Parse("2001-10-03"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w094 = new Worker
        {
            FirstName = "Burton",
            LastName = "Boyd",
            DateOfBirth = DateTime.Parse("2001-09-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w095 = new Worker
        {
            FirstName = "Caryn",
            LastName = "Merritt",
            DateOfBirth = DateTime.Parse("1988-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w096 = new Worker
        {
            FirstName = "Madison",
            LastName = "Finley",
            DateOfBirth = DateTime.Parse("1985-03-14"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w097 = new Worker
        {
            FirstName = "Karly",
            LastName = "Chang",
            DateOfBirth = DateTime.Parse("1993-04-08"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w098 = new Worker
        {
            FirstName = "Magee",
            LastName = "Dotson",
            DateOfBirth = DateTime.Parse("1986-08-26"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w099 = new Worker
        {
            FirstName = "Liberty",
            LastName = "Woodward",
            DateOfBirth = DateTime.Parse("1990-02-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w100 = new Worker
        {
            FirstName = "Phelan",
            LastName = "Douglas",
            DateOfBirth = DateTime.Parse("1984-09-29"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w101 = new Worker
        {
            FirstName = "Alec",
            LastName = "Sampson",
            DateOfBirth = DateTime.Parse("2000-07-27"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w102 = new Worker
        {
            FirstName = "Brennan",
            LastName = "Gutierrez",
            DateOfBirth = DateTime.Parse("1984-01-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w103 = new Worker
        {
            FirstName = "Oleg",
            LastName = "Atkinson",
            DateOfBirth = DateTime.Parse("1986-11-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w104 = new Worker
        {
            FirstName = "Hanna",
            LastName = "Delgado",
            DateOfBirth = DateTime.Parse("1987-01-20"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w105 = new Worker
        {
            FirstName = "Kibo",
            LastName = "Rose",
            DateOfBirth = DateTime.Parse("1994-07-22"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w106 = new Worker
        {
            FirstName = "Felicia",
            LastName = "Snow",
            DateOfBirth = DateTime.Parse("1984-06-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w107 = new Worker
        {
            FirstName = "Brock",
            LastName = "Thornton",
            DateOfBirth = DateTime.Parse("1990-04-30"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w108 = new Worker
        {
            FirstName = "Lester",
            LastName = "Gray",
            DateOfBirth = DateTime.Parse("1981-02-25"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w109 = new Worker
        {
            FirstName = "Allegra",
            LastName = "Orr",
            DateOfBirth = DateTime.Parse("1985-01-24"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w110 = new Worker
        {
            FirstName = "Kyla",
            LastName = "Stark",
            DateOfBirth = DateTime.Parse("1983-01-28"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w111 = new Worker
        {
            FirstName = "Lyle",
            LastName = "Mcintyre",
            DateOfBirth = DateTime.Parse("1999-10-21"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w112 = new Worker
        {
            FirstName = "Anika",
            LastName = "Lamb",
            DateOfBirth = DateTime.Parse("2001-09-09"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w113 = new Worker
        {
            FirstName = "Dara",
            LastName = "Garrison",
            DateOfBirth = DateTime.Parse("1984-04-06"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w114 = new Worker
        {
            FirstName = "Preston",
            LastName = "Wolfe",
            DateOfBirth = DateTime.Parse("1982-12-04"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w115 = new Worker
        {
            FirstName = "Kenyon",
            LastName = "Baxter",
            DateOfBirth = DateTime.Parse("1983-08-31"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w116 = new Worker
        {
            FirstName = "Ivan",
            LastName = "Fischer",
            DateOfBirth = DateTime.Parse("2001-05-09"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w117 = new Worker
        {
            FirstName = "Armand",
            LastName = "Mcintosh",
            DateOfBirth = DateTime.Parse("1980-12-04"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w118 = new Worker
        {
            FirstName = "Knox",
            LastName = "Rutledge",
            DateOfBirth = DateTime.Parse("2001-01-02"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w119 = new Worker
        {
            FirstName = "Quin",
            LastName = "Robbins",
            DateOfBirth = DateTime.Parse("1996-07-02"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        public static Worker w120 = new Worker
        {
            FirstName = "John",
            LastName = "Talley",
            DateOfBirth = DateTime.Parse("1985-05-23"),
            EmployeeState = EmployeeState.Active,
            Branch = WalmartNorthAmerica,
        };
        #endregion
        public static List<Employee> data;
        static SeedWorker()
        {
            data = new List<Employee>();
            data.Add(w001);
            data.Add(w002);
            data.Add(w003);
            data.Add(w004);
            data.Add(w005);
            data.Add(w006);
            data.Add(w007);
            data.Add(w008);
            data.Add(w009);
            data.Add(w010);
            data.Add(w011);
            data.Add(w012);
            data.Add(w013);
            data.Add(w014);
            data.Add(w015);
            data.Add(w016);
            data.Add(w017);
            data.Add(w018);
            data.Add(w019);
            data.Add(w020);
            data.Add(w021);
            data.Add(w022);
            data.Add(w023);
            data.Add(w024);
            data.Add(w025);
            data.Add(w026);
            data.Add(w027);
            data.Add(w028);
            data.Add(w029);
            data.Add(w030);
            data.Add(w031);
            data.Add(w032);
            data.Add(w033);
            data.Add(w034);
            data.Add(w035);
            data.Add(w036);
            data.Add(w037);
            data.Add(w038);
            data.Add(w039);
            data.Add(w040);
            data.Add(w041);
            data.Add(w042);
            data.Add(w043);
            data.Add(w044);
            data.Add(w045);
            data.Add(w046);
            data.Add(w047);
            data.Add(w048);
            data.Add(w049);
            data.Add(w050);
            data.Add(w051);
            data.Add(w052);
            data.Add(w053);
            data.Add(w054);
            data.Add(w055);
            data.Add(w056);
            data.Add(w057);
            data.Add(w058);
            data.Add(w059);
            data.Add(w060);
            data.Add(w061);
            data.Add(w062);
            data.Add(w063);
            data.Add(w064);
            data.Add(w065);
            data.Add(w066);
            data.Add(w067);
            data.Add(w068);
            data.Add(w069);
            data.Add(w070);
            data.Add(w071);
            data.Add(w072);
            data.Add(w073);
            data.Add(w074);
            data.Add(w075);
            data.Add(w076);
            data.Add(w077);
            data.Add(w078);
            data.Add(w079);
            data.Add(w080);
            data.Add(w081);
            data.Add(w082);
            data.Add(w083);
            data.Add(w084);
            data.Add(w085);
            data.Add(w086);
            data.Add(w087);
            data.Add(w088);
            data.Add(w089);
            data.Add(w090);
            data.Add(w091);
            data.Add(w092);
            data.Add(w093);
            data.Add(w094);
            data.Add(w095);
            data.Add(w096);
            data.Add(w097);
            data.Add(w098);
            data.Add(w099);
            data.Add(w100);
            data.Add(w101);
            data.Add(w102);
            data.Add(w103);
            data.Add(w104);
            data.Add(w105);
            data.Add(w106);
            data.Add(w107);
            data.Add(w108);
            data.Add(w109);
            data.Add(w110);
            data.Add(w111);
            data.Add(w112);
            data.Add(w113);
            data.Add(w114);
            data.Add(w115);
            data.Add(w116);
            data.Add(w117);
            data.Add(w118);
            data.Add(w119);
            data.Add(w120);
        }
    }
}
