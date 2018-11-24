----DROP DATABASE QLNhansu
CREATE DATABASE QLNhansu
GO
USE QLNhansu
GO
CREATE TABLE PhongBan (
    MaPB  INT IDENTITY(1,1)  PRIMARY KEY ,
   TenPB  NVARCHAR(30) NOT NULL
)
GO
CREATE TABLE NhanVien (
   MaNV  int IDENTITY(1,1) PRIMARY KEY ,
   Hoten  NVARCHAR(40) NOT NULL,
   Diachi nvarchar(255),
   MaPB int,
   LuongCB float,
   constraint fk_PhongBan foreign key(MaPB) references PhongBan(MaPB)
)
GO
CREATE TABLE BangChamCong(
	MaCC int IDENTITY(1,1) PRIMARY KEY,
	Nam int,
	Thang int,
	MaNV int ,
	Songay int,
	Luongthang float,
	constraint fk1_PhongBan foreign key(MaNV) references NhanVien(MaNV)
)
go
INSERT INTO PHONGBAN
VALUES ( N'Kế toán')
go
INSERT INTO PHONGBAN
VALUES ( N'Tài chính')
go
INSERT INTO PHONGBAN
VALUES ( N'Quản lý')
GO
INSERT INTO NhanVien
VALUES ( N'NGUYỄN MINH HIẾU BỐN' , N'ấp 3 Tân ÂN Cần Đước Long An' , 1 , 5000000)

GO
INSERT INTO NhanVien
VALUES ( N'NGUYỄN VĂN ANH QUỐC' , N'Tân Phú' , 2 , 6000000)
GO
INSERT INTO NhanVien
VALUES ( N'NGUYỄN HOÀI THANH' , N'Đồng Xoài' , 3 , 5000000)
GO
INSERT INTO NhanVien
VALUES ( N'TRỊNH HOÀNG HUY' , N'Tokyo JAPAN' , 1 , 7000000)

go
insert into BangChamCong
values (2016 , 1 , 1 ,20 , 4545454 )
go
insert into BangChamCong
values (2016 , 1 , 2 ,19 , 5181818 )
go
insert into BangChamCong
values (2016 , 1 , 3 ,22 , 7000000 )
go
insert into BangChamCong
values (2016 , 1 , 4 ,17 , 3863863 )