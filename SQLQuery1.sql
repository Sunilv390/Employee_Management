go
create procedure dbAddEmployee
(
@Id int,
@name nchar(10),
@email nchar(10),
@salary decimal(18,2),
@designation nchar(10),
@experience nchar(10),
@contact int,
@department nchar(10)
)
as 
begin
insert into EmployeePersonalDetails(Id,name,email,salary,designation,experience,contact,department)
values(@Id,@name,@email,@salary,@designation,@experience,@contact,@department)
end

go
create procedure dbRemoveEmployee
(
@Id int
)
as 
begin
delete from EmployeePersonalDetails where Id=@Id
end

go
create procedure dbUpdateEmployee
(
@Id int,
@name nchar(10),
@email nchar(10),
@salary decimal(18,2),
@designation nchar(10),
@experience nchar(10),
@contact int,
@department nchar(10)
)
as 
begin
update EmployeePersonalDetails
set Name=@name,
Email=@email,
Salary=@salary,
Designation=@designation,
Experience=@experience,
Contact=@contact,
Department=@department
where Id=@Id
end 


go
create procedure dbShowAllEmployee
as 
begin
select* from EmployeePersonalDetails
end

go
create procedure dbShowEmployeeById
(
@Id int
)
as
begin
select* from EmployeePersonalDetails where Id=@Id
end