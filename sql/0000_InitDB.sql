#drop user 'health';
#drop database Health;
create database if not exists Health;

create user 'health'@'%' identified by 'gesundheit';
grant all on Health.* to 'health'@'%' with grant option;

use Health;
create TABLE Mandant
(
    MandantID   int not null auto_increment,
    ParentMandantID int null,
    Des VARCHAR(50) character set 'utf8' null,
    SecurityToken BINARY(40) null,
    ChangeDate datetime not null,
    constraint PK_Mandant PRIMARY KEY(MandantID),
    CONSTRAINT FK_Mandant_Mandant foreign key (ParentMandantID) REFERENCES Mandant(MandantID)
) Engine=InnoDB;

insert into Mandant
(ParentMandantID, Des, SecurityToken, ChangeDate)
VALUES
(null, 'Root', null, now());
 insert into Mandant values (2, 1, 'Andre', null, now());

create table Gewicht
(
    ID int not null auto_increment,
    Datum datetime not null,
    Wert decimal(5,2) not null,
    MandantID int not null,
    Bemerkung VARCHAR(255) character set 'utf8' null,
    CONSTRAINT PK_Gewicht PRIMARY KEY(ID),
    CONSTRAINT FK_Gewicht_Mandant foreign key (MandantID) REFERENCES Mandant(MandantID)
) Engine=InnoDB;

insert into Gewicht
(Datum, Wert, MandantID)
values
('2019-07-22 20:00', 83.5, 2),
('2019-07-23 02:00', 84.5, 2),
('2019-07-23 11:00', 83.3, 2),
('2019-07-24 01:00', 84.2, 2),
('2019-07-24 09:00', 81.7, 2),
('2019-07-24 20:00', 84.2, 2),
('2019-07-24 22:00', 83.1, 2),
('2019-07-25 12:00', 80.0, 2),
('2019-07-25 22:00', 82.7, 2),
('2019-07-26 10:00', 82, 2),
('2019-07-27 01:00', 84.3, 2),
('2019-07-27 11:00', 81.5, 2),
('2019-07-27 18:00', 81.2, 2),
('2019-07-28 11:00', 81.8, 2);
