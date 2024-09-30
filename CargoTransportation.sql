begin
create database CargoTransportation;
end
go

begin
use CargoTransportation;

create table Drivers(
id int identity primary key,
[Name] nvarchar(max),
Phone nvarchar(12),
Email nvarchar(max),
[Address] nvarchar(max));

create table Vehicles(
id int identity primary key,
Make nvarchar(max),
Model nvarchar(max),
RegistrationNumber nvarchar(max),
CarryingCapacity float);

create table DriverVehicles(
DriverId int references Drivers(id) on delete cascade on update cascade not null,
VehicleId int references Vehicles(id) on delete cascade on update cascade not null,
constraint PK_DriverVehicles primary key(DriverId, VehicleId));
end
go

begin
use CargoTransportation;

insert into dbo.Drivers values
('Доминик Торето','48888888888','toreto@gmail.com','Kansas Wichita 10315 West 13th St N'),
('Rob Zombie','88888888888','rob@gmail.com','Horror Mansion'),
('Unga Bunga','78888888888','bunga@gmail.com','Moscow Kremlin'),
('Гарри Потный','68888888888','harry@gmail.com','Hogwartz Legacy ps5'),
('ChatGPT','58888888888','gpt@gmail.com','Unable to load site');

insert into dbo.Vehicles values
('Agrale','Agrale Marrua','fg327868',100),
('Bremach','Bremach T-Rex','f97hjds',100),
('Changan','Changan Star Truck','di37hf',400),
('Damas/Labo','Labo','3897nefn',200),
('Ford','Ford F-150 Raptor','fi37hds',100),
('Ford','Ford F-450','-DRIFT-',150);

insert into dbo.DriverVehicles values
(1,1),
(2,1),
(2,2),
(3,1),
(3,3),
(4,1),
(4,4),
(5,1),
(5,5),
(5,6);
end