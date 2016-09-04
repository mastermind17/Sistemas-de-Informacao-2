use Tickets

-- ALINEA N TESTE

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
	--atribuir tipo a 4 tickets
	exec dbo.sp_Assign_Type_To_Ticket 'aaa', 'LF1010', 2
	exec dbo.sp_Assign_Type_To_Ticket 'bbb', 'LF1010', 1
	exec dbo.sp_Assign_Type_To_Ticket 'ccc', 'LF1010', 3
	exec dbo.sp_Assign_Type_To_Ticket 'ddd', 'LF1010', 4
	--atribuir prioridade 4 todos os tickets
	exec dbo.sp_Update_Ticket_Priority 'aaa', 2, 'normal'
	exec dbo.sp_Update_Ticket_Priority 'bbb', 1, 'normal'
	exec dbo.sp_Update_Ticket_Priority 'ccc', 3, 'urgente'
	exec dbo.sp_Update_Ticket_Priority 'ddd', 4, 'prioritario'
	--inserir acção de um ticket
	exec dbo.sp_Insert_Ticket_Action 'aaa', 1, 'LF1010', 1, 'teste ola ola 123'
	declare @auxDate datetime = (select beginDate from dbo.Ticket_Action where ticket = 'aaa' and technician = 1 and
								stepTicketType = 'LF1010' and stepOrderNumber = 1 and note = 'teste ola ola 123')
	exec dbo.sp_End_Ticket_Action @auxDate, 'aaa'
	--e fechá-lo
	exec dbo.sp_Close_Ticket 'aaa', 2
go

---------------------
-- BEGINS HERE-------
---------------------

--FILL THE DB
exec dbo.sp_DB_Inserts
--LIST TICKETS BY STATE
exec dbo.sp_List_Tickets_By_State
--LIST TICKETS BY PRIORITY
exec dbo.sp_List_Tickets_By_Priority
--LIST TICKETS BY DATE
exec dbo.sp_List_Tickets_By_Date
--LIST TICKETS BY TYPE
exec dbo.sp_List_Tickets_By_Type

---------------------
-- OK
---------------------


