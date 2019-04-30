# BHHCReason
Demo project using .NET Core 2.1, MVC, Tag Helpers, EF Code First, Repository pattern, Identity, SQL Server, XUnit Tests.
Built in Visual Studio 2017.


Edit the ConnectionString in 'appsettings.json' for your environemnt.

Uncomment 'RunSeeding(host)' in 'Program.cs'.

Build the solution.

From the 'Package Manager Console' run 'Update-Database -verbose' to create the database.

Run the BHHCReason project, it will take a few minutes to seed the database.

Run the Tests.

Stop the project and comment out 'RunSeeding(host)' in 'Program.cs'.

The database is seeded with 100 users 'User1@bhhc.com through User100@bhhc.com'.
Password is 'P@$$w0rd'.

Each user is seeded with 3 Reasons.
