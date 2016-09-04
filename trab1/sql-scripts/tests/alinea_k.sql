use Tickets

-- ALINEA K TESTE

---------------------
-- SCROLL DOWN ------
---------------------

if(OBJECT_ID('sp_DB_Inserts') is not null)		drop proc dbo.sp_DB_Inserts

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
	exec dbo.sp_Insert_Ticket 'eee','...','uEmail2222'
	--inserir um tipo de de ticket e os passos a ele associados
	exec dbo.sp_Insert_Ticket_Type 'LF1010','Login Failed'
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o nome de utilizador existe'
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o processo de registo foi completado com sucesso'
	exec dbo.sp_Insert_Step 'LF1010', 'Fazer reset das credenciais associadas à conta'
go

---------------------
-- BEGINS HERE-------
---------------------

--FILL THE DB
exec dbo.sp_DB_Inserts
--MAKE MULTIPLE CHANGES ON ONE TICKET
exec dbo.sp_Delete_Technician 'aEmail6'
exec dbo.sp_Delete_Ticket 'eee'
exec dbo.sp_Assign_Type_To_Ticket 'aaa', 'LF1010', 2
--LIST TICKET_LOG
select * from dbo.vi_Ticket_Log
select * from dbo.Ticket_log

---------------------
-- OK
---------------------
