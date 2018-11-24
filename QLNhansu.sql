---DROP DATABASE QLNhansu
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