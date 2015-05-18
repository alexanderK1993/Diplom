use master;

if DB_ID ('virtual_enterprise') IS NOT NULL
drop database virtual_enterprise;
create database virtual_enterprise
go
use virtual_enterprise

create table VirtualEnterprise
(
	idVE int identity  primary key not null
	,name nvarchar(128) not null
)

create table Employees
(
	employeeId int identity primary key not null
	,name nvarchar(32) not null
	,family nvarchar(64)
	,patronymic nvarchar(64)
	,mail nvarchar(64) not null
	,passwordEmployee nvarchar(32) not null 
)
	

create table CompanyEmployee(
	idCompanyEmployee int identity primary key not null
	,idEmployee int not null
	,idVE int not null	
	)
						
create table Project(
idProject int identity primary key not null
,name nvarchar(64) not null
,deadline datetime
,idVE int not null
)

create table Tasks(
taskId int identity primary key not null
,name nvarchar(128) not null
,deadline datetime
,percentageCompletition int
,idExecutor int
,idProject int not null
)

create table Mesage(
idMessage int identity primary key not null
,content nvarchar(1024) not null
,idDialogue int not null
)

create table Subscription(
idSubscription int identity primary key not null
,idSignedEmployee int not null
,idFellowEmployee int not null
)
create table Dialogue(
idDialogue int identity primary key not null
,idFirstEmployee int not null
,idSecondEmployee int not null
)

alter table	CompanyEmployee	
	add	constraint FK_IdEmployee
	foreign key(idEmployee) 
	references Employees(employeeId)
	on delete cascade,
	constraint FK_idVE
    foreign key  (idVE)
	references virtualEnterprise(idVE)
	on delete cascade	
			
alter table	Project	
	add	constraint FK_project_IdVE
	foreign key(idVE) 
	references virtualEnterprise(idVE)
	on delete cascade
	
alter table	Tasks	
	add	constraint FK_idProject
	foreign key(idProject) 
	references Project(idProject)
	on delete cascade
	
alter table	Mesage	
	add	constraint FK_idDialogue
	foreign key(idDialogue) 
	references Dialogue(idDialogue)
	on delete cascade	
	
alter table	Subscription
	add	constraint FK_idSignedEmployee
	foreign key(idSignedEmployee) 
	references Employees(employeeId)
	on delete no action,
	constraint FK_idFellowEmployee
    foreign key  (idFellowEmployee)
	references Employees(employeeId)
	on delete cascade	
	
alter table	Dialogue
	add	constraint FK_idFirstEmployee
	foreign key(idFirstEmployee) 
	references Employees(employeeId)
	on delete no action,
	constraint FK_idSecondEmployee
    foreign key  (idSecondEmployee)
	references Employees(employeeId)
	on delete cascade				