-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 12 Nov 2025 pada 03.13
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `katasi`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tiket`
--

CREATE TABLE `tiket` (
  `id` int(11) NOT NULL,
  `nama_kontak` varchar(100) DEFAULT NULL,
  `tanggal_lahir` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `no_telp` varchar(100) DEFAULT NULL,
  `negara_keberangkatan` varchar(100) DEFAULT NULL,
  `negara_tujuan` varchar(100) DEFAULT NULL,
  `tanggal_waktu_keberangkatan` varchar(100) DEFAULT NULL,
  `kelas_layanan` varchar(50) DEFAULT NULL,
  `layanan_lainnya` text DEFAULT NULL,
  `hotel_pilihan` varchar(100) DEFAULT NULL,
  `penerbangan_pilihan` varchar(100) DEFAULT NULL,
  `informasi_tambahan` text DEFAULT NULL,
  `harga_tiket` int(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tiket`
--

INSERT INTO `tiket` (`id`, `nama_kontak`, `tanggal_lahir`, `email`, `no_telp`, `negara_keberangkatan`, `negara_tujuan`, `tanggal_waktu_keberangkatan`, `kelas_layanan`, `layanan_lainnya`, `hotel_pilihan`, `penerbangan_pilihan`, `informasi_tambahan`, `harga_tiket`) VALUES
(29, 'Linda', 'Tuesday, November 11, 2025', 'linda@gmail.com', '+62 – Indonesia, 85724871035', 'Indonesia', 'Japan', 'Thursday, November 13, 2025, 23:00', 'Kelas Utama (First Class) | Rp. 2.000.000', 'Tiket Maskapai Penerbangan, Rental Mobil, Akomodasi Hotel', 'ALFA HOTEL *****', 'Batik Air', 'SEKELAS IKUT', 2000000),
(32, 'Alif Alfian', 'Saturday, May 8, 2010', 'alifkolip@gmail.com', '+62 – Indonesia, 8562391928', 'Indonesia', 'Kamboja', 'Saturday, November 29, 2025, 04:00', 'Kelas Utama (First Class) | Rp. 2.000.000', ', Akomodasi Hotel', 'Alfa Hotel *****', 'Garuda Indonesia', 'makan banyak', 2000000),
(33, 'Alfa Rizqi', 'Thursday, November 13, 2025', 'alfa@gmail.com', '+62 – Indonesia, 88287264067', 'Indonesia', 'Jepang', 'Thursday, November 13, 2025, 23:00', 'Bisnis | Rp. 1.500.000', 'Tiket Maskapai Penerbangan, Rental Mobil, Akomodasi Hotel', 'Alfa Hotel *****', 'Lion Air', 'SEKELAS IKUT', 1500000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tiket_mati`
--

CREATE TABLE `tiket_mati` (
  `id` int(11) NOT NULL DEFAULT 0,
  `nama_kontak` varchar(100) DEFAULT NULL,
  `tanggal_lahir` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `no_telp` varchar(100) DEFAULT NULL,
  `negara_keberangkatan` varchar(100) DEFAULT NULL,
  `negara_tujuan` varchar(100) DEFAULT NULL,
  `tanggal_waktu_keberangkatan` varchar(100) DEFAULT NULL,
  `kelas_layanan` varchar(50) DEFAULT NULL,
  `layanan_lainnya` text DEFAULT NULL,
  `hotel_pilihan` varchar(100) DEFAULT NULL,
  `penerbangan_pilihan` varchar(100) DEFAULT NULL,
  `informasi_tambahan` text DEFAULT NULL,
  `harga_tiket` int(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tiket`
--
ALTER TABLE `tiket`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tiket`
--
ALTER TABLE `tiket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
