CREATE DATABASE StudentFormDB;
CREATE TABLE FormData (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(15),
    Gender NVARCHAR(10),
    Rollno NVARCHAR(20),
    Course NVARCHAR(50),
    PermanentCountry NVARCHAR(50),
    PermanentProvince NVARCHAR(50),
    PermanentDistrict NVARCHAR(50),
	Permanentlocal NVARCHAR(50),
    PermanentWado NVARCHAR(50),
    PermanentTole NVARCHAR(100),
    TemporaryCountry NVARCHAR(50),
    TemporaryProvince NVARCHAR(50),
    TemporaryDistrict NVARCHAR(50),
	Temporarylocal NVARCHAR(50),
    TemporaryWado NVARCHAR(50),
    TemporaryTole NVARCHAR(100),
    FatherName NVARCHAR(100),
    FatherPhone NVARCHAR(15),
    MotherName NVARCHAR(100),
    MotherPhone NVARCHAR(15),
    GuardianName NVARCHAR(100),
    GuardianPhone NVARCHAR(15)
);
drop table if exists formdata