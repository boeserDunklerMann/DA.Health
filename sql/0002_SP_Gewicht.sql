use Health;
delimiter //

drop procedure if exists sp_GetGewichts//
CREATE PROCEDURE sp_GetGewichts(in MandantID int)
BEGIN
    select * from Gewicht where Gewicht.MandantID=MandantID;
END//

drop procedure if exists sp_GetGewicht//
CREATE PROCEDURE sp_GetGewicht(in GewichtID int)
BEGIN
    select * from Gewicht where Gewicht.ID = GewichtID;
END//

drop procedure if exists sp_InsertGewicht//
create procedure sp_InsertGewicht(datum datetime, wert decimal(5,2), bemerkung varchar(255), mid int)
BEGIN
    insert into Gewicht (Datum, Wert, Bemerkung, MandantID)
    values (datum, wert, bemerkung, mid);
    select LAST_INSERT_ID();
END//

drop procedure if exists sp_UpdateGewicht//
create procedure sp_UpdateGewicht(datum datetime, wert decimal(5,2), bemerkung varchar(255), mid int, gid int)
BEGIN
    update Gewicht
    set
        Datum=datum,
        Wert=wert,
        Bemerkung=bemerkung,
        MandantID=mid
    where ID=gid;
END//

drop procedure if exists sp_DeleteGewicht//
create procedure sp_DeleteGewicht(gid int)
BEGIN
    delete from Gewicht where ID=gid;
END//

delimiter ;
