/*   Тема дипломного проекта: Разработка программных средств 
	 обеспечивающих функционирование виртуального предприятия 
	 Студент: Кирюшин А.В.
	 Специальность 230105, группа 043.
	 Руководитель проекта: доктор техн. наук,профессор кафедры ИИБМТ  Антипов В.А.
	 Средство разработки: Microsoft Visual Studio 2013 Professional,
	 Microsoft SQL server 2008
	 Назначение:
	 Дата разработки: 01.05.2015.
	 Программное обеспечение
*/

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
,idAuthor int not null
,name nvarchar(128) not null
,dataCreation datetime not null
,deadline datetime
,wastedTime int
,idExecutor int
,idProject int not null
,isTaskComplete bit
)

create table Mesage(
idMessage int identity primary key not null
,content nvarchar(1024) not null
,idDialogue int not null
,dateStart datetime not null
)

create table Subscription(
idSubscription int identity primary key not null
,idSignedEmployee int not null
,idFellowEmployee int not null
)
create table Dialogue(
idDialogue int identity primary key not null
,idDialogueEmployee int not null
)
create table DialogueEmployee(
idDialogueEmployee int identity primary key not null
,idEmployee int not null
)
create table TimeOnProject(
id int identity primary key not null
,[date] date not null
,idEmployee int not null
,idProject int not null
,countTime int not null
)
create table PostSubscription(
idPostSubscription int identity primary key not null
,[content] nvarchar(1024) not null
,dateStart datetime not null
,idSubscription int not null
)
alter table	PostSubscription	
	add	constraint FK_come
	foreign key(idSubscription) 
	references Subscription(idSubscription)

alter table	CompanyEmployee	
	add	constraint FK_IdEmployee
	foreign key(idEmployee) 
	references Employees(employeeId)
	on delete cascade
	on update cascade,
	constraint FK_idVE
    foreign key  (idVE)
	references virtualEnterprise(idVE)
	on delete cascade
	on update cascade	
			
alter table	Project	
	add	constraint FK_project_IdVE
	foreign key(idVE) 
	references virtualEnterprise(idVE)
	on delete cascade

alter table TimeOnProject
	add constraint FK_project
	foreign key(idProject) 
	references Project(idProject)
	on delete cascade
	on update cascade,	
	constraint FK_employee
	foreign key(idEmployee) 
	references Employees(employeeId)
	on delete cascade
	on update cascade
	
alter table	Tasks	
	add	constraint FK_Project_contain
	foreign key(idProject) 
	references Project(idProject)
	on delete cascade,
	constraint FK_author_task
	foreign key(idAuthor)
	references Employee(employeeId)
	on delete no action,
	constraint FK_executor_task
	foreign key(idExecutor)
	references Employee(employeeId)
	on delete cascade
	on update cascade
	
alter table	Mesage	
	add	constraint FK_Dialogue_contains
	foreign key(idDialogue) 
	references Dialogue(idDialogue)
	on delete cascade	
	
alter table	Subscription
	add	constraint FK_Employee_signed
	foreign key(idSignedEmployee) 
	references Employees(employeeId)
	on delete no action,
	constraint FK_idFellowEmployee
    foreign key  (idFellowEmployee)
	references Employees(employeeId)
	on delete cascade	
	
alter table	Dialogue
	add	constraint FK_DialogueEmployee
	foreign key(idDialogueEmployee) 
	references DialogueEmployee(idDialogueEmployee)
	on delete cascade
	
alter table	DialogueEmployee
	add	constraint FK_employee_spent
	foreign key(idEmployee) 
	references Employees(employeeId)
	on update cascade
	on delete cascade
	

 			