create database QuanLyNhanVien

go 
use QuanLyNhanVien

create table NguoiDung
(
	maNhanVien char(20) not  null,
	maPhong char(20) not null,
	taiKhoan varchar(50),
	matKhau varchar(50),
	quyenTruyCap int,
	primary key(taiKhoan)
)

create table NhanVien
(
	maNhanVien char(20) not null,
	maPhong char(20) not null,
	maChucVu char(20) not null,
	hoTen nvarchar(50),
	ngaySinh date,
	gioiTinh nvarchar(10),
	CCCD char(20),
	soDienThoai char(20),
	primary key (maNhanVien)
)

create table ChucVu
(
	maChucVu char(20) not null,
	tenChucVu nvarchar(50),
	luongCoBan float,
	primary key (maChucVu)
)

create table PhongBan
(
	maPhong char(20) not null,
	tenPhong nvarchar(50),
	maBoPhan char(20) not null,
	primary key (maPhong)
)

create table BoPhan
(
	maBoPhan char(20) not null,
	tenBoPhan nvarchar(50),
	primary key (maBoPhan)
)

create table BangCong
(
	maNhanVien char(20) not null,
	thang int,
	nam int,
	soNgayLam int,
	soGioLamThem int,
	ghiChu nvarchar(200)
)

alter table NguoiDung add constraint FK_NV_USER foreign key (maNhanVien) references NhanVien(maNhanVien)
alter table NguoiDung add constraint FK_PB_USER foreign key (maPhong) references PhongBan(maPhong)
alter table NhanVien add constraint FK_NV_PB foreign key (maPhong) references PhongBan(maPhong)
alter table NhanVien add constraint FK_CV_NV foreign key (maChucVu) references ChucVu(maChucVu)
alter table PhongBan add constraint FK_PB_BP foreign key (maBoPhan) references BoPhan(maBoPhan)
alter table BangCong add constraint FK_BC_NV foreign key (maNhanVien) references NhanVien(maNhanVien)

insert into BoPhan values('bp03', 'Bo phan 3')
insert into PhongBan values('p01', N'Phong 1', 'bp03')
insert into ChucVu values('TP', N'Truong phong', 20000000)

go
create proc sp_layDuLieuTuBang(@tenBang varchar(50))
as
	declare @query varchar(1000)
	set @query = 'select * from ' + @tenBang
	exec (@query)

go
create proc sp_themNguoiDung(@maNhanVien char(20), @maPhong char(20), @taiKhoan varchar(50), @matKhau varchar(50), @quyenTruyCap int)
as
	insert into NguoiDung values(@maNhanVien, @maPhong, @taiKhoan, @matKhau, @quyenTruyCap)

go
create proc sp_xoaNguoiDung(@maNhanVien char(20))
as
	delete from NguoiDung where maNhanVien = @maNhanVien

go
create proc sp_suaNguoiDung(@maNhanVien char(20), @maPhong char(20), @taiKhoan varchar(50), @matKhau varchar(50), @quyenTruyCap int)
as
	update NguoiDung set matKhau = @matKhau, quyenTruyCap = @quyenTruyCap where taiKhoan = @taiKhoan

go
create proc sp_kiemTraTaiKhoan(@taiKhoan varchar(50), @matKhau varchar(50))
as
	select * from NguoiDung where taiKhoan like @taiKhoan and matKhau like @matKhau

go
create proc sp_themNhanVien(@maNhanVien char(20), @maPhong char(20), @maChucVu char(20), @hoTen nvarchar(50), @ngaySinh date, @gioiTinh nvarchar(10), @CCCD char(20), @soDienThoai char(20))
as
	insert into NhanVien values(@maNhanVien, @maPhong, @maChucVu, @hoTen, @ngaySinh, @gioiTinh, @CCCD, @soDienThoai)

go
create proc sp_xoaNhanVien(@maNhanVien char(20))
as
	delete from NhanVien where maNhanVien = @maNhanVien

go
create proc sp_suaNhanVien(@maNhanVien char(20), @maPhong char(20), @maChucVu char(20), @hoTen nvarchar(50), @ngaySinh date, @gioiTinh nvarchar(10), @CCCD char(20), @soDienThoai char(20))
as
	update NhanVien set maChucVu = @maChucVu, hoTen = @hoTen, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, CCCD = @CCCD, soDienThoai = @soDienThoai where maNhanVien = @maNhanVien

go
create proc sp_timKiemNhanVienTheoTen(@hoTen nvarchar(50))
as
	select * from NhanVien where hoTen like '%' + @hoTen + '%'

go
create proc sp_timKiemNhanVienTheoChucVu(@maChucVu char(20))
as
	select * from NhanVien where maChucVu like '%' + @maChucVu + '%'

go
create proc sp_themChucVu(@maChucVu char(20), @tenChucVu nvarchar(50), @luongCoBan float)
as
	insert into ChucVu values(@maChucVu, @tenChucVu, @luongCoBan)

go
create proc sp_xoaChucVu(@maChucVu char(20))
as
	delete from ChucVu where maChucVu = @maChucVu

go
create proc sp_suaChucVu(@maChucVu char(20), @tenChucVu nvarchar(50), @luongCoBan float)
as
	update ChucVu set tenChucVu = @tenChucVu, luongCoBan = @luongCoBan where maChucVu = @maChucVu

go
create proc sp_timChucVuTheoTen(@tenChucVu nvarchar(50))
as
	select * from ChucVu where tenChucVu = @tenChucVu

go
create proc sp_themPhongBan(@maPhong char(20), @tenPhong nvarchar(50), @maBoPhan char(20))
as
	insert into PhongBan values(@maPhong, @tenPhong, @maBoPhan)

go
create proc sp_xoaPhongBan(@maPhong char(20))
as
	delete from PhongBan where maPhong = @maPhong

go
create proc sp_suaPhongBan(@maPhong char(20), @tenPhong nvarchar(50), @maBoPhan char(20))
as
	update PhongBan set tenPhong = @tenPhong, maBoPhan = @maBoPhan where maPhong = @maPhong

go
create proc sp_timKiemPhongBanTheoMaPhong(@maPhong nvarchar(50))
as
	select * from PhongBan where maPhong like '%' + @maPhong + '%'

go
create proc sp_timKiemPhongBanTheoTen(@tenPhong nvarchar(50))
as
	select * from PhongBan where tenPhong like '%' + @tenPhong + '%'

go
create proc sp_timKiemPhongBanTheoMaBoPhan(@maBoPhan nvarchar(50))
as
	select * from PhongBan where maBoPhan like '%' + @maBoPhan + '%'

go
create proc sp_themBoPhan(@maBoPhan char(20), @tenBoPhan nvarchar(50))
as
	insert into BoPhan values(@maBoPhan, @tenBoPhan)

go
create proc sp_xoaBoPhan(@maBoPhan char(20))
as
	delete from BoPhan where maBoPhan = @maBoPhan

go
create proc sp_suaBoPhan(@maBoPhan char(20), @tenBoPhan nvarchar(50))
as
	update BoPhan set tenBoPhan = @tenBoPhan where maBoPhan = @maBoPhan

go
create proc sp_themBangCong(@maNhanVien char(20), @thang int, @nam int, @soNgayLam int, @soGioLamThem int, @ghiChu nvarchar(200))
as
	insert into BangCong values(@maNhanVien, @thang, @nam, @soNgayLam, @soGioLamThem, @ghiChu)

go
create proc sp_xoaBangCong(@maNhanVien char(20),@thang int, @nam int)
as
	delete from BangCong where maNhanVien = @maNhanVien and thang = @thang and nam = @nam

go
create proc sp_suaBangCong(@maNhanVien char(20), @thang int, @nam int, @soNgayLam int, @soGioLamThem int, @ghiChu nvarchar(200))
as
	update BangCong set soNgayLam = @soNgayLam, soGioLamThem = @soGioLamThem, ghiChu = @ghiChu where maNhanVien = @maNhanVien and thang = @thang and nam = @nam

go
create proc sp_layDuLieuBangNhanVien
as
	select * from NhanVien
drop table NguoiDung
drop table NhanVien
drop table ChucVu
drop table PhongBan
drop table BoPhan
drop table BangCong