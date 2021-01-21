# rdi.token

Solution developed in:
1 - Visual Studio 2017 Community
2 - Docker Community 2.0
3 - .Net Core 2.0

Features implemmented:
1 - DDD archtecture
2 - Swagger
3 - Sql LocalDB
4 - Abstract Validator
5 - Entity Framwwork
6 - Interface
7 - Generic
8 - Dependency Injection
9 - Repository Patter
10 - XUnit for unit test
11 - MSTest for integration test
12 - Migration
13 - AutoMapper

Just downloat it, open, select "Token.Api" and push "Run".

To use Docker, select:
  1 - "Docker compose as Default Project"
  2 - "Run".

The project is set to Windows Docker. To run in Linux:
  1 - Switch your docker desktop
  2 - Go Visual Studio, Select Docker Compose Project, Right click to Properties and write Linux on the field Target OS.


Example of JSON Request for POST method:

{
  "date": "2019-08-07T16:06:55",
  "cardNumber": 0102030405060708,
  "cvv": 123
}

Example of JSON Request for PUT method:
- Input date: "2019-08-07T16:06:55"
- Input token: "{token genereted above}" 

