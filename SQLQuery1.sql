GO
create procedure dpAddEmployee
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
values(@Id, @name, @email, @salary, @designation, @experience, @contact, @department)
end