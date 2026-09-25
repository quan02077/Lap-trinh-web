-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th9 20, 2026 lúc 09:03 AM
-- Phiên bản máy phục vụ: 10.4.13-MariaDB
-- Phiên bản PHP: 7.4.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `qlsv`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sinhvien`
--

CREATE TABLE `sinhvien` (
  `mssv` varchar(10) NOT NULL,
  `hoten` varchar(50) DEFAULT NULL,
  `gioitinh` varchar(3) DEFAULT NULL,
  `dienthoai` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `sinhvien`
--

INSERT INTO `sinhvien` (`mssv`, `hoten`, `gioitinh`, `dienthoai`) VALUES
('SV001', 'Nguyễn Văn An', 'Nam', '0901234501'),
('SV002', 'Trần Thị Bích', 'Nữ', '0901234502'),
('SV003', 'Lê Hoàng Cường', 'Nam', '0901234503'),
('SV004', 'Phạm Thị Dung', 'Nữ', '0901234504'),
('SV005', 'Hoàng Văn Em', 'Nam', '0901234505'),
('SV006', 'Vũ Thị Phượng', 'Nữ', '0901234506'),
('SV007', 'Đặng Văn Giang', 'Nam', '0901234507'),
('SV008', 'Bùi Thị Hoa', 'Nữ', '0901234508'),
('SV009', 'Đỗ Văn Hùng', 'Nam', '0901234509'),
('SV010', 'Hồ Thị Kim', 'Nữ', '0901234510'),
('SV011', 'Ngô Văn Long', 'Nam', '0901234511'),
('SV012', 'Dương Thị Mai', 'Nữ', '0901234512'),
('SV013', 'Lý Văn Nam', 'Nam', '0901234513'),
('SV014', 'Phan Thị Nga', 'Nữ', '0901234514'),
('SV015', 'Vương Văn Phong', 'Nam', '0901234515'),
('SV016', 'Đinh Thị Quỳnh', 'Nữ', '0901234516'),
('SV017', 'Lâm Văn Sơn', 'Nam', '0901234517'),
('SV018', 'Trịnh Thị Thảo', 'Nữ', '0901234518'),
('SV019', 'Mai Văn Tùng', 'Nam', '0901234519'),
('SV020', 'Cao Thị Uyên', 'Nữ', '0901234520'),
('SV021', 'Tạ Văn Việt', 'Nam', '0901234521'),
('SV022', 'Phùng Thị Xuân', 'Nữ', '0901234522'),
('SV023', 'Chu Văn Yên', 'Nam', '0901234523'),
('SV024', 'Lương Thị Ánh', 'Nữ', '0901234524'),
('SV025', 'Tôn Thất Bình', 'Nam', '0901234525'),
('SV026', 'Hà Thị Châu', 'Nữ', '0901234526'),
('SV027', 'Mạc Văn Đại', 'Nam', '0901234527'),
('SV028', 'Kiều Thị Gấm', 'Nữ', '0901234528'),
('SV029', 'Ứng Văn Hải', 'Nam', '0901234529'),
('SV030', 'Thạch Thị Lệ', 'Nữ', '0901234530'),
('SV031', 'Ung Văn Minh', 'Nam', '0901234531'),
('SV032', 'Nghiêm Thị Ngọc', 'Nữ', '0901234532'),
('SV033', 'Vi Văn Phúc', 'Nam', '0901234533'),
('SV034', 'Âu Thị Quyên', 'Nữ', '0901234534'),
('SV035', 'Thiều Văn Sang', 'Nam', '0901234535'),
('SV036', 'Giang Thị Thu', 'Nữ', '0901234536'),
('SV037', 'Sầm Văn Trung', 'Nam', '0901234537'),
('SV038', 'Bạch Thị Vân', 'Nữ', '0901234538'),
('SV039', 'Phạm Văn Vượng', 'Nam', '0901234539'),
('SV040', 'Lại Thị Yến', 'Nữ', '0901234540'),
('SV041', 'Trương Văn Bảo', 'Nam', '0901234541'),
('SV042', 'Đào Thị Cúc', 'Nữ', '0901234542'),
('SV043', 'Lưu Văn Định', 'Nam', '0901234543'),
('SV044', 'Phùng Thị Hằng', 'Nữ', '0901234544'),
('SV045', 'Vũ Văn Khánh', 'Nam', '0901234545'),
('SV046', 'Trần Thị Linh', 'Nữ', '0901234546'),
('SV047', 'Nguyễn Văn Mạnh', 'Nam', '0901234547'),
('SV048', 'Lê Thị Nhung', 'Nữ', '0901234548'),
('SV049', 'Hoàng Văn Quân', 'Nam', '0901234549'),
('SV050', 'Phạm Thị Trâm', 'Nữ', '0901234550');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD PRIMARY KEY (`mssv`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
