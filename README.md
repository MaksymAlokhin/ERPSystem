[![.NET](https://github.com/gform/ERPSystem/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gform/ERPSystem/actions/workflows/dotnet.yml)
ERPSystem<br />
=========
Demo App for Avenga<br />

![ERPSystem](ERPSystem/wwwroot/images/avenga-erp-logo.png)<br /><br />

Installation<br />
----------------------

Package Manager Console:<br />
`Update-Database`<br />

.NET CLI:<br />
`dotnet ef database update`<br />

Users:<br />
`admin@avenga.com`<br />
`employee@avenga.com`<br />

Password:<br />
`aA!111`<br />

You might need to change the `DefaultConnection` string in `appsettings.json` file.<br />

Built With:<br />
--------------------
- ASP.NET Core 5
- Entity Framework Core 5
- Razor Pages
- Microsoft Identity
- xUnit.net

Entities:<br />
--------------------
- Company
- Department
- Branch
- Employee
- Project
- Position
- Assignment
- Report

Screenshots:<br />
-----------
![IdentityLogin](Screenshots/IdentityLogin.png)<br /><br />
![CompanyIndex](Screenshots/CompanyIndex.png)<br /><br />
![EmployeeIndex](Screenshots/EmployeeIndex.png)<br /><br />
![EmployeeEdit](Screenshots/EmployeeEdit.png)<br /><br />
![DepartmentDetails](Screenshots/DepartmentDetails.png)<br /><br />
![ReportIndex](Screenshots/ReportIndex.png)<br /><br />