go
Drop TABLE tblPhoneBook;
DROP PROCEDURE spAddContact;
DROP PROCEDURE spUpdateContact;
DROP PROCEDURE spGetAllContacts
DROP PROCEDURE spDeleteContact;
go

go
Create table tblPhoneBook(      
    Id int IDENTITY(1,1) NOT NULL,      
    ContactName varchar(20) NOT NULL,      
    Number varchar(20) NOT NULL,
	SessionID varchar(50) NOT NULL
)
go
----------------Create



go
Create procedure spAddContact         
(        
    @ContactName VARCHAR(20),         
    @Number VARCHAR(20),
	@SessionID VARCHAR(50)
)        
as         
Begin         
    Insert into tblPhoneBook (ContactName,Number,SessionID)         
    Values (@@ContactName,@Number,@SessionID)         
End
go


go
----------------Update

Create procedure spUpdateContact        
(        
   @Id INTEGER ,      
   @ContactName VARCHAR(20),       
   @Number VARCHAR(20),
   @SessionID VARCHAR(50)    
)        
as        
begin        
   Update tblPhoneBook         
   set ContactName=@ContactName,        
   Number=@Number,
   SessionID=@SessionID
   where Id=@Id        
End
go


go
----------------Delete
Create procedure spDeleteContact       
(        
   @Id int        
)        
as         
begin        
   Delete from tblPhoneBook where Id=@Id        
End
go



----------------Read
go
Create procedure spGetAllContacts      
as      
Begin      
    select *      
    from tblPhoneBook   
    order by Id      
End
go