Create database QLSV;
use QLSV;

create table SV(
	MSSV nchar(15) primary key not null,
	Name nvarchar(50) not null,
	ID_Lop int not null,
	NS datetime not null,
	DTB float not null,
	Gender bit not null,
	Anh bit not null, 
	HocBa bit not null, 
	CCCD bit not null, 
);

insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (101 , N'Nguyễn Hữu An', 1, '2003-04-18', 7.8, 1, 1, 0, 0);
insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (103 , N'Nguyễn Thị Tuyết', 2, '2003-01-18', 7.8, 1, 1, 0, 0);
insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (104 , N'Huỳnh Minh Cường', 1, '2003-09-18', 8.8, 1, 1, 1, 0);
insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (109 , N'Võ Thế Đạt', 3, '2003-04-15', 9.8, 1, 0, 1, 0);
insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (105 , N'Huỳnh Quang Đông', 2, '2003-04-12', 6.8, 1, 1, 0, 0);
insert into SV(MSSV, Name, ID_Lop, NS, DTB, Gender, Anh, HocBa, CCCD) values (106 , N'Lưu Văn Duy', 1, '2003-05-18', 7.7, 1, 0, 0, 0);

create table LSH(
	IDLop int primary key not null,
	NameLop nvarchar(MAX) not null
)

insert into LSH(IDLop, NameLop) values (1, '21T_DT');
insert into LSH(IDLop, NameLop) values (2, '21T_DT2');
insert into LSH(IDLop, NameLop) values (3, '21T_DT3');

