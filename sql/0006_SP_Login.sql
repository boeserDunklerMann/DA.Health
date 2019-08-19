use Health;
delimiter //

drop procedure if exists sp_GetLogin//
create procedure sp_GetLogin(username varchar(255), password binary(255))
begin
    select * from Login where Login.Username=username and Login.Password=password;
end//

drop procedure if exists sp_DeleteLogin//
create procedure sp_DeleteLogin(lid int)
begin
    delete from Login where LoginID=lid;
end//

drop procedure if exists sp_InsertLogin//
create procedure sp_InsertLogin(username varchar(255),
password binary(255),
mid int)
begin
    INSERT INTO Login (Username, Password, MandantID, Changedate)
    VALUES (username, password, mid, NOW());
    SELECT LAST_INSERT_ID();
end//

drop procedure if exists sp_UpdateLogin//
create procedure sp_UpdateLogin(lid int,
username varchar(255),
password binary(255),
mid int)
begin
    UPDATE Login
    SET Username=username, Password=password, MandantID=mid, ChangeDate=NOW() WHERE LoginID=lid;
end//

delimiter ;
