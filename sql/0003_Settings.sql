use Health;
drop table if exists Settings;
create table Settings
(
    SettingsID int not null,
    MandantID int not null,
    SettingsValue varchar(255) character set 'utf8' not null,
    ChangeDate datetime not null,
    constraint PK_Settings primary key (SettingsID, MandantID),
    constraint FK_Settings_Mandant foreign key (MandantID) references Mandant(MandantID)
);

insert into Settings values (1, 2, 'kg', now());