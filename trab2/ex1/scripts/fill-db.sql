use Tickets

go
	exec dbo.sp_Insert_Technician 'aEmail1','patri';
	exec dbo.sp_Insert_Technician 'aEmail2','pp';	
	exec dbo.sp_Insert_Technician 'aEmail3','falcao';	
	exec dbo.sp_Insert_Technician 'aEmail4','ez';	
	exec dbo.sp_Insert_Technician 'aEmail5','lara';	
	exec dbo.sp_Insert_Technician 'aEmail6','tia';
	
	exec dbo.sp_Insert_Ticket_User 'uEmail1','zarolho';
	exec dbo.sp_Insert_Ticket_User 'uEmail2','gluglu';
	exec dbo.sp_Insert_Ticket_User 'uEmail3','tyson';
	
	exec dbo.sp_Insert_Ticket 'aaa','...','uEmail1';
	exec dbo.sp_Insert_Ticket 'bbb','...','uEmail2';
	exec dbo.sp_Insert_Ticket 'ccc','...','uEmail3';	
	exec dbo.sp_Insert_Ticket 'ddd','...','uEmail1111';
	exec dbo.sp_Insert_Ticket 'eee','...','uEmail2222';

	exec dbo.sp_Insert_Ticket_Type 'LF1010','Login Failed';
	
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o nome de utilizador existe';
	exec dbo.sp_Insert_Step 'LF1010', 'Verificar se o processo de registo foi completado com sucesso';
	exec dbo.sp_Insert_Step 'LF1010', 'Fazer reset das credenciais associadas à conta';
	
go
	exec dbo.sp_Assign_Type_To_Ticket 'aaa', 'LF1010', 2;
go	
	exec dbo.sp_Assign_Type_To_Ticket 'bbb', 'LF1010', 1;
go	
	exec dbo.sp_Assign_Type_To_Ticket 'ccc', 'LF1010', 3;
go	
	exec dbo.sp_Assign_Type_To_Ticket 'ddd', 'LF1010', 4;

go		
	exec dbo.sp_Update_Ticket_Priority 'aaa', 2, 'normal';
go
	exec dbo.sp_Update_Ticket_Priority 'bbb', 1, 'normal';
go	
	exec dbo.sp_Update_Ticket_Priority 'ccc', 3, 'urgente';
go
	exec dbo.sp_Update_Ticket_Priority 'ddd', 4, 'prioritario';
go	
	declare @orderNumber int;
	exec dbo.sp_Insert_Ticket_Action 'aaa', 1, 'LF1010', 1, 'test step1', @orderNumber;

go
	declare @orderNumber int = (select orderNumber from dbo.Ticket_Action where ticket = 'aaa' and technician = 1 and
								stepTicketType = 'LF1010' and stepOrderNumber = 1 and note = 'test step1');
	exec dbo.sp_End_Ticket_Action @orderNumber, 'aaa';

go	
	declare @orderNumber int;
	exec dbo.sp_Insert_Ticket_Action 'aaa', 1, 'LF1010', 2, 'test step2', @orderNumber;

go
	declare @orderNumber int = (select orderNumber from dbo.Ticket_Action where ticket = 'aaa' and technician = 1 and
								stepTicketType = 'LF1010' and stepOrderNumber = 2 and note = 'test step2');
	exec dbo.sp_End_Ticket_Action @orderNumber, 'aaa';
	
go
	exec dbo.sp_Close_Ticket 'aaa', 2;

go
	exec dbo.sp_Delete_Ticket 'bbb';

go
	insert into dbo.Ticket(cod,ticketState,ticketDescription,ticketPriority,creationDate,closeDate,technician,ticketType,ticketUser) values('fff','Waiting','...',null,GETDATE(),null,null,null,'uEmail2');
	insert into dbo.Ticket(cod,ticketState,ticketDescription,ticketPriority,creationDate,closeDate,technician,ticketType,ticketUser) values('ggg','Waiting','...',null,GETDATE(),null,null,null,'uEmail1');

