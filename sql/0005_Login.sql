use Health;
use Health;
drop table if exists Login;
create table Login
(
    LoginID int auto_increment not null,
    Username varchar(255) not null,
    Password binary(255) null,
    MandantID int not null,
    ChangeDate datetime not null,
    constraint PK_Login primary key(LoginID),
    constraint FK_Login_Mandant foreign key(MandantID) references Mandant(MandantID),
    constraint UQ_Login_Username unique(Username)
);
create index IX_Login_Username_Password on Login(Username, Password);

insert into Login
values (1, 'dunkelan', null, 2, now());
