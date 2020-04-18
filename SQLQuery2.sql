alter table EmployeePersonalDetails
add department nvarchar(50)

go
create procedure spAddEmployee
(
@name nvarchar(50),
@email nvarchar(50),
@salary decimal(18,2),
@designation nchar(10),
@experience nvarchar(5),
@contact int,
@department nvarchar(50)
)
as 
begin
insert into EmployeePersonalDetails(name,email,salary,designation,experience,contact,department)
values(@name,@email,@salary,@designation,@experience,@contact,@department)
end

go
create procedure spRemoveEmployee
(
@id int
)
as 
begin
delete from EmployeePersonalDetails where id=@id
end

go
create procedure spUpdateEmployee
(
@id int,
@name nvarchar(50),
@email nvarchar(50),
@salary decimal(18,2),
@designation nchar(10),
@experience nvarchar(5),
@contact int,
@department nvarchar(50)
)
as 
begin
update EmployeePersonalDetails
set name=@name,
email=@email,
salary=@salary,
designation=@designation,
experience=@experience,
contact=@contact,
department=@department
where id=@id
end 

go
create procedure spShowAllEmployee
as 
begin
select* from EmployeePersonalDetails
end

go
create procedure spShowEmployeeById
(
@id int
)
as
begin
select* from EmployeePersonalDetails where id=@id
end