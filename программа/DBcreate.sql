use master;

if DB_ID ('taskList_Kiryshin') IS NOT NULL
drop database taskList_Kiryshin;

create database taskList_Kiryshin

use taskList_Kiryshin

create table Users
(
	user_login nvarchar(128)  primary key not null
)

create table Tasks
(
	id_task int identity primary key not null
	,name_task nvarchar(512) not null
	,deadline date
	,user_login nvarchar(128) not null
	,deleted bit not null
	,time_when_task_completed datetime
)
	

create table Tasks_Marks(
	id_task int  not null
	,id_mark int not null)
						
create table Marks(
id_mark int identity primary key not null
,name_mark nvarchar(128) not null)

alter table	Tasks	
	add	constraint FK_User_Bring_The_Task
	foreign key(user_login) 
	references Users(user_login)
	on delete cascade
	on update cascade

				
alter table	Tasks_Marks	
	add	constraint PK_Tasks_Marks primary key  (id_task,id_mark), 
	constraint FK_Tasks_Marks foreign key  (id_task)
	references Tasks(id_task)
	on delete cascade,
	constraint FK_Tasks_Marks1 foreign key  (id_mark)
	references Marks(id_mark)
	on delete cascade	