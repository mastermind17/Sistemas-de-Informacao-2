use Tickets

-- RI
-- garantir que Ticket.ticketType é igual aos Step.ticketType associados às Actions fracas do Ticket original
-- 

set xact_abort on
--set nocount on
--set nocount nas transações
go
--surpress select output
--set fmtonly on
--set fmtonly off

drop proc dbo.sp_DB_Inserts
go
create proc dbo.sp_DB_Inserts
as
	--inserir técnicos
	exec dbo.sp_Insert_Technician 'aEmail1','patri'
	exec dbo.sp_Insert_Technician 'aEmail2','pp'
	exec dbo.sp_Insert_Technician 'aEmail3','falcao'
	exec dbo.sp_Insert_Technician 'aEmail4','ez'
	exec dbo.sp_Insert_Technician 'aEmail5','lara'
	exec dbo.sp_Insert_Technician 'aEmail6','tia'
	--inserir utilizadores
	exec dbo.sp_Insert_Ticket_User 'uEmail1','zarolho'
	exec dbo.sp_Insert_Ticket_User 'uEmail2','gluglu'
	exec dbo.sp_Insert_Ticket_User 'uEmail3','tyson'
	--inserir tickets
	exec dbo.sp_Insert_Ticket 'aaa','...','uEmail1'
	exec dbo.sp_Insert_Ticket 'bbb','...','uEmail2'
	exec dbo.sp_Insert_Ticket 'ccc','...','uEmail3'
	--inserir ticket de um utilizador que não está inserido
	exec dbo.sp_Insert_Ticket 'ddd','...','uEmail1111'
	--inserir um tipo de de ticket e os passos a ele associados
	exec dbo.sp_Insert_Ticket_Type 'LF1010','Login Failed'
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o nome de utilizador existe'
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o processo de registo foi completado com sucesso'
	exec dbo.sp_Insert_Step 'LF1010', 'Fazer reset das credenciais associadas à conta'
go

--teste da view do ticket
update Ticket set visible = 0 where cod = 'aaa'
insert into dbo.Ticket_Log values (1,'nop',null,'aaa',2)
insert into dbo.Ticket_Log values (1,'nop',null,'bbb',2)

exec dbo.sp_Delete_Technician 'aEmail2'

select * from dbo.Technician
select * from dbo.Ticket_User
select * from dbo.Ticket
select * from dbo.vi_Ticket
select * from dbo.Step
select * from dbo.Ticket_Log
select * from dbo.vi_Ticket_Log
select * from dbo.Ticket_Action


exec dbo.sp_Delete_Technician 'aEmail1'
insert into Ticket_Log values (1,'111',getDate(),'aaa',1)

----------------------
--preenche a db
--
exec dbo.sp_DB_Inserts
----------------------

select * from dbo.Technician
select * from dbo.vi_Ticket

select * from dbo.vi_Ticket where ticketType is null;

update dbo.Ticket
set technician = null
where cod = 'aaa';
go
--exec sp_Assign_Technician_To_Tickets






