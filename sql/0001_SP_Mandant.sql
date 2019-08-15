use Health;
delimiter //

drop procedure if exists sp_GetMandants//
CREATE PROCEDURE sp_GetMandants()
BEGIN
    select * from Mandant;
END//

drop procedure if exists sp_GetMandant//
CREATE PROCEDURE sp_GetMandant(in id int)
BEGIN
    select * from Mandant where MandantID=id;
END//

drop PROCEDURE if EXISTS sp_GetChildMandants//
create PROCEDURE sp_GetChildMandants(in MandantID int)
BEGIN
    select * from Mandant where ParentMandantID=MandantID;
END//

drop PROCEDURE if EXISTS sp_DeleteMandant//
create procedure sp_DeleteMandant(MandantID int)
BEGIN
    delete from Mandant where Mandant.MandantID=MandantID;
END//

drop PROCEDURE if EXISTS sp_InsertMandant//
create procedure sp_InsertMandant(ParentMandantID int, Des varchar(50))
BEGIN
    insert into Mandant (ParentMandantID, Des, ChangeDate)
    VALUES (ParentMandantID, Des, now());
    select LAST_INSERT_ID();
END//

drop PROCEDURE IF EXISTS sp_UpdateMandant//
CREATE PROCEDURE sp_UpdateMandant(MandantID int, ParentMandantID int, Des varchar(50))
BEGIN
    update Mandant
    set
        ParentMandantID=ParentMandantID,
        Des=Des,
        ChangeDate=now()
    where Mandant.MandantID=MandantID;
end//

delimiter ;

