USE Tickets

IF(OBJECT_ID('proc_Assign_Technician') is not null) DROP PROC dbo.proc_Assign_Technician;
IF(OBJECT_ID('proc_Remove_Ticket') is not null) DROP PROC dbo.proc_Remove_Ticket;
IF(OBJECT_ID('proc_Get_Ticket_Info') is not null) DROP PROC dbo.proc_Get_Ticket_Info;

GO
CREATE PROC proc_Assign_Technician
@tech_num int,
@cod varchar(20) OUTPUT
AS
BEGIN
	DECLARE @count int;
	
	--checks if technician exists
	SET @count = (SELECT COUNT(*) from dbo.Technician WHERE anumber = @tech_num);
	IF @count=0
	BEGIN
		--returns cod as '.' to indicate that it doesn't
		SET @cod = '.';
		RETURN;
	END

	--checks if there are unassigned tickets
	SET @cod = (SELECT TOP 1 cod FROM dbo.vi_Ticket WHERE technician is null ORDER BY creationDate DESC);
	
	--assigns technician to ticket
	UPDATE dbo.vi_Ticket SET technician = @tech_num	WHERE cod = @cod;
	RETURN;
END

GO
CREATE PROC proc_Remove_Ticket
@cod varchar(20),
@res int output
AS
BEGIN
	DECLARE @count int;
	--checks if ticket exists and if it's visible (not previously removed)
	SET @count = (SELECT COUNT(*) from dbo.Ticket WHERE cod=@cod AND visible=1);
	IF @count=0
	BEGIN
		--returns res as 0 if it doesn't
		SET @res = 0
		RETURN;
	END
	--else executes procedure to remove ticket
	exec dbo.sp_Delete_Ticket @cod;
	--sets res at 1 to indicate sucess
	SET @res = 1;
	RETURN
END

GO
CREATE PROC dbo.proc_Get_Ticket_Info @cod varchar(20)
AS
BEGIN
	select vi_Ticket.cod,vi_Ticket.ticketState,vi_Ticket.ticketDescription,
		Technician.anumber,Technician.email as tech_email,Technician.name as tech_name,
		Ticket_Type.id as tt_id,Ticket_Type.name as tt_name,
		Ticket_User.email as owner_email,Ticket_User.name as owner_name,Ticket_User.id as owner_id,
		vi_Ticket_Action.orderNumber,vi_Ticket_Action.beginDate,vi_Ticket_Action.endDate	
	from vi_Ticket
	inner join Technician
		on vi_Ticket.technician = Technician.anumber
	inner join Ticket_Type
		on vi_Ticket.ticketType = Ticket_Type.id
	inner join Ticket_User
		on vi_Ticket.ticketUser = Ticket_User.email
	inner join vi_Ticket_Action
		on vi_Ticket_Action.ticket = vi_Ticket.cod
	where cod=@cod
END

SELECT anumber as technicianID, name, email FROM dbo.Technician where anumber=2