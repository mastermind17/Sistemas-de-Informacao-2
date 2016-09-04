use Tickets
 
--
--ordem do script
--
--drops
--creates
--tables
--views
--functions
--procedures
--triggers
--SELECT @@SERVERNAME
set xact_abort on
 
--------------------------------------------------------
--drops-------------------------------------------------
--------------------------------------------------------
 
--tabelas
if(OBJECT_ID('Request') is not null)            drop table dbo.Request
if(OBJECT_ID('Ticket_Log') is not null)         drop table dbo.Ticket_Log
if(OBJECT_ID('Ticket_Action') is not null)      drop table dbo.Ticket_Action
if(OBJECT_ID('Step') is not null)               drop table dbo.Step
if(OBJECT_ID('Ticket') is not null)             drop table dbo.Ticket
if(OBJECT_ID('Ticket_Type') is not null)        drop table dbo.Ticket_Type
if(OBJECT_ID('Technician') is not null)         drop table dbo.Technician
if(OBJECT_ID('Ticket_User') is not null)        drop table dbo.Ticket_User
--procedures
if(OBJECT_ID('sp_Insert_Technician') is not null)       drop proc dbo.sp_Insert_Technician
if(OBJECT_ID('sp_Delete_Technician') is not null)       drop proc dbo.sp_Delete_Technician
if(OBJECT_ID('sp_Update_Technician') is not null)       drop proc dbo.sp_Update_Technician
if(OBJECT_ID('sp_Insert_Ticket_User') is not null)      drop proc dbo.sp_Insert_Ticket_User
if(OBJECT_ID('sp_Delete_Ticket_User') is not null)      drop proc dbo.sp_Delete_Ticket_User
if(OBJECT_ID('sp_Update_Ticket_User') is not null)      drop proc dbo.sp_Update_Ticket_User
if(OBJECT_ID('sp_Insert_Ticket') is not null)           drop proc dbo.sp_Insert_Ticket
if(object_id('sp_Delete_Ticket') is not null)           drop proc dbo.sp_Delete_Ticket
if(object_id('sp_Insert_Ticket_Action') is not null)    drop proc dbo.sp_Insert_Ticket_Action
if(object_id('sp_Update_Ticket') is not null)           drop proc dbo.sp_Update_Ticket
if(OBJECT_ID('sp_Insert_Ticket_Type') is not null)      drop proc dbo.sp_Insert_Ticket_Type
if(OBJECT_ID('sp_Insert_Step') is not null)             drop proc dbo.sp_Insert_Step
if(OBJECT_ID('sp_Prepare_Technician_Delete') is not null)   drop proc dbo.sp_Prepare_Technician_Delete
if(OBJECT_ID('sp_Assign_Technician_To_Tickets') is not null)    drop proc dbo.sp_Assign_Technician_To_Tickets
if(OBJECT_ID('sp_Close_Ticket') is not null)            drop proc dbo.sp_Close_Ticket
if(OBJECT_ID('sp_Insert_Ticket_Log') is not null)       drop proc dbo.sp_Insert_Ticket_Log
if(OBJECT_ID('sp_Assign_Type_To_Ticket') is not null)   drop proc dbo.sp_Assign_Type_To_Ticket
if(OBJECT_ID('sp_Increate_Ticket_Priority') is not null)    drop proc dbo.sp_Increate_Ticket_Priority
if(OBJECT_ID('sp_Request_Ticket_Info') is not null)     drop proc dbo.sp_Request_Ticket_Info
if(OBJECT_ID('sp_Answer_Ticket_Request') is not null)   drop proc dbo.sp_Answer_Ticket_Request
if(OBJECT_ID('sp_End_Ticket_Action') is not null)       drop proc dbo.sp_End_Ticket_Action
if(OBJECT_ID('sp_List_Tickets_By_State') is not null)       drop proc dbo.sp_List_Tickets_By_State
if(OBJECT_ID('sp_List_Tickets_By_Priority') is not null)        drop proc dbo.sp_List_Tickets_By_Priority
if(OBJECT_ID('sp_List_Tickets_By_Date') is not null)        drop proc dbo.sp_List_Tickets_By_Date
if(OBJECT_ID('sp_List_Tickets_By_Type') is not null)        drop proc dbo.sp_List_Tickets_By_Type
if(OBJECT_ID('sp_List_Ticket_Actions') is not null)         drop proc dbo.sp_List_Ticket_Actions
if(OBJECT_ID('sp_List_Ticket_Requests') is not null)        drop proc dbo.sp_List_Ticket_Requests
if(object_id('sp_Delete_Ticket_Log') is not null)       drop proc dbo.sp_Delete_Ticket_Log
if(object_id('sp_Delete_Request') is not null)          drop proc dbo.sp_Delete_Request
if(object_id('sp_Delete_Ticket_Action') is not null)    drop proc dbo.sp_Delete_Ticket_Action
if(object_id('sp_Delete_Ticket') is not null)           drop proc dbo.sp_Delete_Ticket
if(object_id('sp_Update_Ticket_Type') is not null)      drop proc dbo.sp_Update_Ticket_Type
if(object_id('sp_Update_Ticket_Priority') is not null)  drop proc dbo.sp_Update_Ticket_Priority
if(object_id('proc_Get_Ticket_Info') is not null)  drop proc dbo.proc_Get_Ticket_Info
if(object_id('proc_Get_Ticket_Steps') is not null)  drop proc dbo.proc_Get_Ticket_Steps
IF(OBJECT_ID('proc_Assign_Technician') is not null) DROP PROC dbo.proc_Assign_Technician;
IF(OBJECT_ID('proc_Remove_Ticket') is not null) DROP PROC dbo.proc_Remove_Ticket;

--views
--if(OBJECT_ID('NrTicketsAtribuidos') is not null)      drop view dbo.NrTicketsAtribuidos
if(OBJECT_ID('vi_Ticket') is not null)                  drop view dbo.vi_Ticket
if(OBJECT_ID('vi_Ticket_Log') is not null)              drop view dbo.vi_Ticket_Log
if(OBJECT_ID('vi_Request') is not null)                 drop view dbo.vi_Request
if(OBJECT_ID('vi_Ticket_Action') is not null)           drop view dbo.vi_Ticket_Action
--functions
if(OBJECT_ID('func_Select_Technician_With_Least_Tickets') is not null)  drop function dbo.func_Select_Technician_With_Least_Tickets
if(OBJECT_ID('func_Check_Priority') is not null)        drop function dbo.func_Check_Priority
if(OBJECT_ID('func_Increase_Priority') is not null)     drop function dbo.func_Increase_Priority
if(OBJECT_ID('func_Calculate_Response_Time') is not null)       drop function dbo.func_Calculate_Response_Time
if(OBJECT_ID('func_Get_Most_Priority_Tickets') is not null)     drop function dbo.func_Get_Most_Priority_Tickets
--triggers
if(OBJECT_ID('tr_Updates_On_Ticket') is not null)       drop trigger dbo.tr_Updates_On_Ticket
if(OBJECT_ID('tr_On_Ticket_Changes') is not null)       drop trigger dbo.tr_On_Ticket_Changes


--------------------------------------------------------
--tables------------------------------------------------
--------------------------------------------------------
create Table dbo.Ticket_User
(
    email varchar(100),
    name varchar(100),
	id int identity(1,1),       
    primary key(email)
)
 
create table dbo.Technician
(
    anumber int identity(1,1),
    email varchar(100) not null unique,
    name varchar(100) not null,
 
    primary key(anumber)
)
 
create table dbo.Ticket_Type
(
    id varchar(20),
    name varchar(100),
 
    primary key(id)
)
 
create Table dbo.Ticket
(
    cod varchar(20),
    ticketState varchar(20) default 'Waiting',
    ticketDescription varchar(MAX) not null,
    ticketPriority varchar(20) default null,
    creationDate datetime not null,
    closeDate datetime,
    --flag se o ticket foi "removido"
    visible bit default 'TRUE',
 
    technician int,
    foreign key(technician) references Technician(anumber),
           
    ticketType varchar(20) default null,
    foreign key(ticketType) references Ticket_Type(id),
 
    ticketUser varchar(100) not null,
    foreign key(ticketUser) references Ticket_User(email),
   
    check (
        ticketState = 'Waiting' or
        ticketState = 'In Progress' or
        ticketState = 'Closed'),
 
    check (
        ticketPriority = 'normal' or
        ticketPriority = 'prioritario' or
        ticketPriority = 'urgente'),
 
    primary key(cod)
)
 
create table dbo.Step
(
    orderNumber int,
    description varchar(100),
 
    ticketType varchar(20),
    foreign key (ticketType) references Ticket_Type(id),
 
    primary key(ticketType,orderNumber)
)
 
create table dbo.Ticket_Action
(
    orderNumber int,
    beginDate datetime,
    endDate datetime,
    note varchar(100),
 
    ticket varchar(20) not null,
    foreign key(ticket) references Ticket(cod),
   
    stepTicketType varchar(20) not null,
    stepOrderNumber int not null,
    foreign key(stepTicketType,stepOrderNumber) references Step(ticketType,orderNumber),
   
    technician int not null,
    foreign key(technician) references Technician(anumber),
 
    primary key(ticket,orderNumber)
)
 
create table dbo.Ticket_Log
(
    orderNumber int,
    sqlCommand varchar(max),
    modificationDate datetime,
   
    ticket varchar(20) not null,
    foreign key(ticket) references Ticket(cod),
 
    technician int,
    foreign key(technician) references Technician(anumber),
 
    primary key(ticket,orderNumber)
)
 
create table dbo.Request
(
    orderNumber int,
    requestDate datetime,
    responseDate datetime,
    response varchar(MAX),
   
    ticket varchar(20) not null,
    foreign key(ticket) references Ticket(cod),
   
    ticketUser varchar(100) not null,
    foreign key(ticketUser) references Ticket_User(email),
 
    technician int,
    foreign key(technician) references Technician(anumber),
   
    primary key(ticket,orderNumber)
)
 
 
-----------------------------------------------------------
--views----------------------------------------------------
-----------------------------------------------------------
 
-- as views vi_Ticket, vi_Ticket_Log, vi_Request, vi_Ticket_Action
-- servem para "esconder" o ticket
-- "não pode ser removido do sistema as informações relativas a
-- tickets e acções a eles associadas"
go
create view dbo.vi_Ticket as
select  *
from    dbo.Ticket
where   visible = 'TRUE'
 
go
create view dbo.vi_Ticket_Log as
select  *
from    dbo.Ticket_Log
where   ticket in (select cod from dbo.vi_Ticket)
 
go
create view dbo.vi_Request as
select  *
from    dbo.Request
where   ticket in (select cod from dbo.vi_Ticket)
 
go
create view dbo.vi_Ticket_Action as
select *
from    dbo.Ticket_Action
where   ticket in (select cod from dbo.vi_Ticket)
 
 
-----------------------------------------------------------
--functions------------------------------------------------
-----------------------------------------------------------
--utilizada pela alinea d
--d) Inserir informação de um ticket
go
create function dbo.func_Select_Technician_With_Least_Tickets()
returns int
begin
return
(
    select  AuxTechnician.anumber
    from
    (
            select  top 1 count(cod) as nrTicketsAtribuidos, dbo.Technician.anumber, dbo.Technician.email, dbo.Technician.name
            from    dbo.Ticket full outer join dbo.Technician on (dbo.Ticket.technician = dbo.Technician.anumber)
            group by dbo.Technician.anumber, dbo.Technician.email, dbo.Technician.name
            order by nrTicketsAtribuidos asc
    ) as AuxTechnician
)
end
go
 
-----------------------------------------------------------
-----------------------------------------------------------
-- verifica se a nova prioridade é mais alta
-- prioridades existentes: normal > prioritario > urgente
go
create function dbo.func_Check_Priority (@priority varchar(20), @newPriority varchar(20))
returns bit
as
begin
    declare @myList table (i int, p varchar(20));
    insert into @myList values (1,'normal'), (2,'prioritario'), (3,'urgente');
    -- index on myList of the current priority
    declare @currIdx int;
    select @currIdx=i from @myList where p = @priority
    -- index on MyList of the new priority
    declare @newIdx int;
    select @newIdx=i from @myList where p = @newPriority
    declare @res bit;
    if @newIdx > @currIdx
	begin
        set @res = 1
	end
    else
	begin
        set @res = 0
	end
    return @res
end;
go
 
-----------------------------------------------------------
-----------------------------------------------------------
-- função usada pela alinea g) que aumenta a prioridade de um ticket
-- retorna a nova prioridade
-- prioridades existentes: normal > prioritario > urgente
go
create function dbo.func_Increase_Priority(@ticket varchar(20))
returns varchar(20)
as
begin
    --list with the existing priorities
    declare @myList table (i int, p varchar(20));
    insert into @myList values (1,'normal'), (2,'prioritario'), (3,'urgente');
    --current priority
    declare @currPriority varchar(20);
    select @currPriority=ticketPriority from dbo.Ticket where cod = @ticket;
    --if the given ticket doesnt have a priority
    if @currPriority is null
    begin
        declare @firstPriority varchar(20);
        select @firstPriority=p from @myList where i = 1;
        return @firstPriority;
    end
    -- index on myList of the current priority
    declare @currIdx int;
    select @currIdx=i from @myList where p = @currPriority;
    --check if the current priority is already the highest one
    --if it is return the current priority
    declare @topPriorityIdx int;
    select @topPriorityIdx=max(i) from @myList;
    if @currIdx = @topPriorityIdx
        return @currPriority;
    --get new priority
    declare @newPriority varchar(20);
    select @newPriority=p from @myList where i=@currIdx+1;
    return @newPriority;
end;
go
 
-----------------------------------------------------------
-----------------------------------------------------------
-- Note que deve ser possível determinar o tempo de resposta a cada pedido de informação.
go
create function dbo.func_Calculate_Response_Time(@requestDate datetime, @ticket varchar(20))
returns varchar(10)
as
begin
    declare @responseDate datetime = (select responseDate from dbo.Request where requestDate = @requestDate and ticket = @ticket);
    declare @elapsedTime varchar(10);
    select @elapsedTime=cast(
        (cast(cast(@responseDate as float) - cast(@requestDate as float) as int) * 24) /* hours over 24 */
        + datepart(hh, @responseDate - @requestDate) /* hours */
        as varchar(10))
    + ':' + right('0' + cast(datepart(mi, @responseDate - @requestDate) as varchar(2)), 2) /* minutes */
    + ':' + right('0' + cast(datepart(ss, @responseDate - @requestDate) as varchar(2)), 2) /* seconds */
    return @elapsedTime;
end
go
 
-----------------------------------------------------------
-----------------------------------------------------------
-- m)
-- Obter os n tickets mais prioritários
--
-- n indicates the number of tickets to be listed
go
create function func_Get_Most_Priority_Tickets(@n int)
--the table to be returned is identical to the ticket table
returns @returnTable table
    (
        cod varchar(20),
        ticketState varchar(20),
        ticketDescription varchar(max),
        ticketPriority varchar(20),
        creationDate datetime,
        closeDate datetime,
        visible bit,
        technician int,
        ticketType varchar(20),
        ticketUser varchar(100)
    )
as
begin
    --list with the existing priorities
    declare @myList table (i int, p varchar(20));
    insert into @myList values (1,'normal'), (2,'prioritario'), (3,'urgente');
    --
    insert @returnTable
        select top(@n) cod, ticketState, ticketDescription, ticketPriority, creationDate,
                        closeDate, visible, technician, ticketType, ticketUser
        from dbo.vi_Ticket inner join @myList on (ticketPriority = p)
        order by i desc, creationDate asc
    return;
end
go
 
------------------------------------------------------------
--procedures------------------------------------------------
------------------------------------------------------------
--
-- procedimentos auxiliares
--
 
-- este sp é utilizado pelas alineas b e h
-- atribui técnicos aos tickets que não têm
go
create proc dbo.sp_Assign_Technician_To_Tickets
as
	begin try
		begin tran
			declare @rowsToProcess  int;
			declare @currRow        int;
			DECLARE @currTicket     varchar(20);
			--myList holds all the tickets without technician
			declare @myList table (rowID int not null primary key identity(1,1),code varchar(20));
			--populate myList
			insert into @myList select cod from dbo.vi_Ticket where technician is null;
			--
			set @rowsToProcess = @@rowcount
			set @currRow = 0
			while @currRow < @rowsToProcess
			begin
				--increment currRow
				set @currRow = @CurrRow + 1;
				--get current ticket from myList
				select @currTicket = code from @myList where rowID = @currRow
				--assign technician
				update dbo.vi_Ticket
				set technician = dbo.func_Select_Technician_With_Least_Tickets()
				where cod = @currTicket;
			end
		commit
	end try
	begin catch
		if @@trancount > 0
			rollback
	end catch

go
 
------------------------------------------------------------
------------------------------------------------------------
-- b)
-- Inserir, remover e actualizar informação de um técnico
go
create proc dbo.sp_Insert_Technician @email varchar(100), @name varchar(100)
as
	begin tran
    insert into dbo.Technician values(@email,@name);
	commit
	 
go
create proc dbo.sp_Delete_Technician @email varchar(100)
as
--    set transaction isolation level read committed
        begin tran
            --get corresponding technician anumber
            declare @i int;
            select @i=anumber from dbo.Technician where email = @email
            --prepare technician delete
            update dbo.Ticket_Log set technician = null where technician = @i
            update dbo.Request set technician = null where technician = @i
            update dbo.Ticket_Action set technician = null where technician = @i
            update dbo.Ticket set technician = null where technician = @i
            --delete technician
            delete from dbo.Technician where email = @email;
        commit
    --atribui novos técnicos aos tickets que estavam atribuidos ao técnico removido
    exec sp_Assign_Technician_To_Tickets
 
 
go
create proc dbo.sp_Update_Technician @email varchar(100), @name varchar(100), @newEmail varchar(100), @newName varchar(100)
as
	begin tran
    update dbo.Technician
    set email = @newEmail, name = @newName
    where email = @newEmail and name = @name;
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- c)
-- Inserir, remover e actualizar informação de um utilizador
go
create proc dbo.sp_Insert_Ticket_User @email varchar(100), @name varchar(100) = null
as
	begin tran
    insert into dbo.Ticket_User values(@email,@name)
	commit
	 
go
create proc dbo.sp_Delete_Ticket_User @email varchar(100)
as
--    set transaction isolation level read committed
        begin tran
            --prepare ticket_user delete
            update dbo.Ticket set technician = null where ticketUser = @email;
            update dbo.Request set technician = null where ticketUser = @email;
            --delete ticket
            delete from dbo.Ticket_User where email = @email;
        commit
 
go
create proc dbo.sp_Update_Ticket_User @email varchar(100), @name varchar(100), @newEmail varchar(100), @newName varchar(100)
as
    update dbo.Ticket_User
    set email = @newEmail, name = @newName
    where email = @email and name = @name;
go
 
------------------------------------------------------------
------------------------------------------------------------
-- d)
-- Inserir, remover e actualizar informação de um ticket
--
-- actualizar informação de um ticket é feito nas outras alineas
-- nota: h) não existe, quando o ticket é criado é-lhe logo atribuido um technician
-- afinal existe h)
--
go
create proc dbo.sp_Insert_Ticket @cod varchar(20), @ticketDescription varchar(MAX), @ticketUser varchar(100)
as
	begin try
		begin tran
		--se o ticketUser não existir insere-o
		select * from Ticket_User where email = @ticketUser;
		if(@@ROWCOUNT = 0)
			exec dbo.sp_Insert_Ticket_User @ticketUser
		--função round-robin para selecionar o technician
		declare @technician int = dbo.func_Select_Technician_With_Least_Tickets();
		--inserir ticket
		insert into dbo.Ticket(cod,ticketState,ticketDescription,ticketPriority,creationDate,closeDate,technician,ticketType,ticketUser) values(@cod,'Waiting',@ticketDescription,null,GETDATE(),null,@technician,null,@ticketUser);
		commit
	end try
    begin catch
        if @@trancount > 0
            rollback
    end catch

go
   
--tickets cant be deleted from the db, they're hidden with a flag
go
create proc dbo.sp_Delete_Ticket @cod varchar(20)
as
	begin tran
    update dbo.Ticket set visible = 0 where cod = @cod
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- e)
--  Inserir um tipo de de ticket e os passos a ele associados
go
create proc dbo.sp_Insert_Ticket_Type @id varchar(20), @name varchar(100)
as
	begin tran
    insert into Ticket_Type values(@id,@name);
	commit

go
create proc dbo.sp_Insert_Step @ticketType varchar(20), @description varchar(100)
as
	begin tran
    if not exists (select id from dbo.Ticket_Type where id = @ticketType)
    begin
        print 'erro sp_Insert_Step : Ticket_Type correspondente não existe'
		RAISERROR ('erro sp_Insert_Step',-1,-1);
        return;
    end
    --calcular próximo orderNumber do Step
    declare @on int;
    select @on = count(ticketType) from Step where ticketType = @ticketType
    set @on += 1;
    --inserir
    insert into dbo.Step(orderNumber,description,ticketType) values (@on,@description,@ticketType)
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- f)
-- Actualizar o estado de um ticket
go
create proc dbo.sp_Assign_Type_To_Ticket @ticket varchar(20), @ticketType varchar(20), @technician int
as
	begin tran
    --check if given technician is the one responsible for the ticket
    declare @responsibleTech int;
    select @responsibleTech=Technician from dbo.Ticket where cod = @ticket;
    if @technician != @responsibleTech
    begin
        print 'erro sp_Assign_Type_To_Ticket : só o técnico responsável pode atribuit um tipo ao ticket'
		RAISERROR ('sp_Assign_Type_To_Ticket',-1,-1);
        return;
    end
    --
    update dbo.Ticket set ticketType = @ticketType, ticketState = 'In Progress' where cod = @ticket;
   commit
 
------------------------------------------------------------
------------------------------------------------------------
-- g)
-- Actualizar a prioridade de um ticket
go
create proc sp_Update_Ticket_Priority @ticket varchar(20), @technician int, @newPriority varchar(20)
as
	begin try
		begin tran
			--check if the new priority is bigger
			declare @currPriority varchar(20);
			select @currPriority=ticketPriority from Ticket where cod = @ticket;
			if @currPriority is not null
			begin
				declare @check bit = dbo.func_Check_Priority(@currPriority,@newPriority);
				if @check = 0
					begin
					print 'erro sp_Update_Ticket_Priority : um ticket não pode ficar menos prioritário'
					RAISERROR ('sp_Update_Ticket_Priority',-1,-1);
					return
				end
			end    
			--technician responsable for the ticket
			declare @responsable int;
			select @responsable=technician from Ticket where cod = @ticket;
			--only the responsable technician can update the priority
			if @technician = @responsable
			begin
				update Ticket
				set ticketPriority = @newPriority
				where cod = @ticket;
			end
			else
			print 'erro sp_Update_Ticket_Priority : tem de ser o Technician responsável'
			RAISERROR ('sp_Update_Ticket_Priority',-1,-1);
		commit
    end try
    begin catch
        if @@trancount > 0
            rollback
    end catch

go
 
-- TODO job
-- Note que a cada 7 dias, o ticket sobe de prioridade, de forma automática.
-- g)
-- este sp deve ser chamado pelo job que trata de aumentar a prioridade a cada 7 dias
go
create proc dbo.sp_Increate_Ticket_Priority @ticket varchar(20)
as
	begin try
		begin tran
		declare @newPriority varchar(20) = dbo.func_Increase_Priority(@ticket);
		update dbo.Ticket set ticketPriority = @newPriority where cod = @ticket;
		commit
    end try
    begin catch
        if @@trancount > 0
            rollback
    end catch

go
 
------------------------------------------------------------
------------------------------------------------------------
-- h)
--  Atribuir um técnico responsável a todos os tickets no estado ‘Waiting’
--
-- esta alinea funciona em conjunto com a d)
-- sempre que um ticket é criado é-lhe atribuido automaticamente um technician
--
-- e o sp sp_Assign_Technician_To_Tickets definido em cima nos procedimentos auxiliares
-- trata de atribuir um técnico a todos os tickets que não tenham
 
 
------------------------------------------------------------
------------------------------------------------------------
-- i)
-- Inserir uma acção associada a um ticket
go
create proc dbo.sp_Insert_Ticket_Action @ticket varchar(20), @technician int, @stepTicketType varchar(20), @stepOrderNumber int, @note varchar(100), @orderNumber int output
as
	begin tran
    --check if the state is in progress, if not actions cant be done
    declare @currState varchar(20);
    select @currState=ticketState from Ticket where cod = @ticket;
    if @currState != 'In Progress'
    begin
        print 'erro sp_Insert_Ticket_Action : ticket não está in progress';
		RAISERROR ('sp_Insert_Ticket_Action',-1,-1);
        return;
    end
    --calcular próximo orderNumber do Ticket_Action
    declare @on int;
    select @on = count(ticket) from Ticket_Action where ticket = @ticket
    set @on += 1;
    insert into dbo.Ticket_Action(orderNumber,beginDate,note,ticket,stepTicketType,stepOrderNumber,technician) values (@on,getdate(),@note,@ticket,@stepTicketType,@stepOrderNumber,@technician);
	set @orderNumber = @on;
	commit
go
 
-- terminar uma acção de um ticket
go
create proc dbo.sp_End_Ticket_Action @orderNumber int, @ticket varchar(20)
as
    update dbo.Ticket_Action set endDate = getdate() where orderNumber = @orderNumber and ticket = @ticket;
go
 
------------------------------------------------------------
------------------------------------------------------------
-- j)
-- Fechar um ticket
go
create proc dbo.sp_Close_Ticket @ticket varchar(20), @technician int
as
	begin tran
    --cant be close if it doesnt have any ticket_action associated that has ended
    --and the ticket can only be closed by the responsible technician and if its in progress
    if  exists (select beginDate from dbo.Ticket_Action where ticket = @ticket and endDate is not null) and
            exists (select cod from dbo.Ticket where cod = @ticket and @technician = technician and ticketState = 'In progress')
        update dbo.Ticket set ticketState = 'Closed', closeDate = getdate() where cod = @ticket;
    else
	begin
        print 'erro sp_Close_Ticket : este ticket não pode ser fechado'
		RAISERROR ('sp_Close_Ticket',-1,-1);
	end
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- k)
-- Inserir de forma automática o registo de alterações efectuadas sobre os tickets
--
-- este sp apenas insere na tablela
-- em baixo está feito um trigger que detecta alterações na tabela ticket que chama este sp
go
create proc sp_Insert_Ticket_Log @ticket varchar(20), @sqlCommand varchar(max), @technician int
as
	begin tran
    --calcular próximo orderNumber do Ticket_Log
    declare @on int;
--  select @on = count(ticket) from dbo.Ticket_Log where ticket ='aaa';
    select @on = count(ticket) from dbo.Ticket_Log where ticket = @ticket;
    set @on += 1;
    --insert
    insert into dbo.Ticket_Log(orderNumber,sqlCommand,modificationDate,ticket,technician) values (@on,@sqlCommand,getdate(),@ticket,@technician);
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- l)
-- Inserir uma resposta a um pedido de informação
go
create proc dbo.sp_Request_Ticket_Info @ticketUser varchar(100), @ticket varchar(20)
as
	begin tran
    --check if the ticket belongs to the given ticketUser
    if not exists (select cod from dbo.Ticket where cod = @ticket and ticketUser = @ticketUser)
    begin
        print 'erro sp_Request_Ticket_Info : ticketuser can only ask information of his tickets'
		RAISERROR ('sp_Request_Ticket_Info',-1,-1);
        return;
    end
    --calcular próximo orderNumber do Request
    declare @on int;
    select @on = count(ticket) from dbo.Request where ticket = @ticket
    set @on += 1;
    --inserir
    insert into dbo.Request(orderNumber,requestDate,ticket,ticketUser) values(@on,getdate(),@ticket,@ticketUser);
	commit
go
 
create proc dbo.sp_Answer_Ticket_Request @orderNumber int, @ticket varchar(20), @technician int, @response varchar(max)
as
	begin tran
    --check if the given technician is responsible for the ticket
    --or was involved in any action
    if not exists (select cod from dbo.Ticket where cod = @ticket and technician = @technician) and
        not exists (select Ticket from dbo.Ticket_Action where ticket = @ticket and technician = @technician)
    begin
        print 'erro sp_Answer_Ticket_Request : only a technician involved with the ticket can answer the request';
		RAISERROR ('sp_Answer_Ticket_Request',-1,-1);
        return;
    end
    --
    update dbo.Request
    set responseDate = getdate(), response = @response, technician = @technician
    where orderNumber = @orderNumber and ticket = @ticket;
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- n)
-- Listar os tickets. Deve ser possível ordená-los considerando o estado, a prioridade,
-- a idade (em dias) e o tipo
go
create proc dbo.sp_List_Tickets_By_State
as
	begin tran
    --list with the existing states
    declare @myList table (i int, s varchar(20));
    insert into @myList values (1,'Closed'), (2,'In Progress'), (3,'Waiting');
    --show tickets
    select cod, ticketState, ticketDescription, ticketPriority, creationDate,
            closeDate, visible, technician, ticketType, ticketUser
    from dbo.vi_Ticket inner join @myList on (ticketState = s)
    order by i desc
	commit
 
go
create proc dbo.sp_List_Tickets_By_Priority
as
	begin tran
    --list with the existing priorities
    declare @myList table (i int, p varchar(20));
    insert into @myList values (1,'normal'), (2,'prioritario'), (3,'urgente');
    --show tickets
    select cod, ticketState, ticketDescription, ticketPriority, creationDate,
            closeDate, visible, technician, ticketType, ticketUser
    from dbo.vi_Ticket inner join @myList on (ticketPriority = p)
    order by i desc
	commit
 
go
create proc dbo.sp_List_Tickets_By_Date
as
	begin tran
    select * from dbo.vi_Ticket order by creationDate
	commit

go
create proc dbo.sp_List_Tickets_By_Type
as
	begin tran
    select * from dbo.vi_Ticket order by ticketType desc
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- o)
-- Obter a informação de um ticket, usando o seu identificador. Devem ser incluídas as
-- acções, os pedidos de informação e as resposta fornecidas de forma cronológica
go
create proc dbo.sp_List_Ticket_Actions @ticket varchar(20)
as
	begin tran
    select cod, ticketState, ticketDescription, ticketPriority, beginDate, stepTicketType, stepOrderNumber, note
    from dbo.vi_Ticket inner join dbo.vi_Ticket_Action on (cod = ticket)
    order by beginDate;
   commit

go
create proc dbo.sp_List_Ticket_Requests @ticket varchar(20)
as
	begin tran
    select cod, ticketState, ticketDescription, ticketPriority, requestDate, responseDate, response, dbo.vi_Request.technician
    from dbo.vi_Ticket inner join dbo.vi_Request on (cod = ticket)
    order by requestDate
	commit
go
 
------------------------------------------------------------
------------------------------------------------------------
-- p)
-- Remover um ticket
--
-- está feito na alinea d, o ticket é escondido usando a flag visible
--
 
----------------------------------------------------------
--triggers------------------------------------------------
----------------------------------------------------------
-- k)
-- Inserir de forma automática o registo de alterações efectuadas sobre os tickets
go
create trigger dbo.tr_On_Ticket_Changes
    on dbo.Ticket
    after insert, update, delete
as
begin
    --if the instruction didnt do anything stop
    if not exists (select * from deleted)
        return;
    --get the sql command that fired the trigger
    set nocount on
    declare @ExecStr varchar(50), @Qry nvarchar(255)
    create table #inputbuffer
    (
        EventType nvarchar(30),
        Parameters int,
        EventInfo varchar(max)
    )
    set @ExecStr = 'DBCC INPUTBUFFER(' + STR(@@SPID) + ')'
    insert into #inputbuffer
    exec (@ExecStr)
    --@Qry has the sql command that fired the trigger
    set @Qry = (select EventInfo from #inputbuffer)
    --
--  select @Qry as 'Query that fired the trigger',
--  system_user as LoginName,
--  user as UserName,
--  current_timestamp as CurrentTime
    --
    --get the corresponding ticket
    declare @ticket varchar(20) = (select cod from deleted)
    --get the ticket technician
    declare @technician int = (select technician from deleted) 
    --insert into ticket log
    exec dbo.sp_Insert_Ticket_Log @ticket, @Qry, @technician
end


GO
CREATE PROC dbo.proc_Get_Ticket_Info @cod varchar(20)
AS
BEGIN
	begin tran
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
	commit
END

go
create proc dbo.proc_Get_Ticket_Steps @cod varchar(20)
as
begin
	begin tran
	select orderNumber,description,technician,ticketState,Step.ticketType
	from vi_Ticket	inner join Step on vi_Ticket.ticketType = Step.ticketType
	where cod = @cod
	commit
end

GO
CREATE PROC proc_Assign_Technician
@tech_num int,
@cod varchar(20) OUTPUT
AS
BEGIN
	begin tran
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
	commit
	RETURN;
END

GO
CREATE PROC proc_Remove_Ticket
@cod varchar(20),
@res int output
AS
BEGIN
	begin tran
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
	commit
	RETURN
END

