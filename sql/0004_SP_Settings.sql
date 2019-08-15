use Health;
delimiter //

drop procedure if exists sp_GetSettings//
create procedure sp_GetSettings(in MandantID int)
begin
    select * from Settings where Settings.MandantID=MandantID;
end //  

drop procedure if exists sp_InsertSetting//
create procedure sp_InsertSetting(sid int, mid int, val varchar(255))
begin
    insert into Settings (SettingsID, MandantID, SettingsValue, ChangeDate)
    values (sid, mid, val, now());
    select LAST_INSERT_ID();
end//

drop procedure if exists sp_UpdateSetting//
create procedure sp_UpdateSetting(sid int, mid int, val varchar(255))
begin
    update Settings
    set
        SettingsValue=val, ChangeDate=now()
    where SettingsID=sid and MandantID=mid;
end//

drop procedure if exists sp_DeleteSetting//
create procedure sp_DeleteSetting(sid int, mid int)
begin
    delete from Settings 
    where SettingsID=sid and MandantID=mid;
end//

delimiter ;
