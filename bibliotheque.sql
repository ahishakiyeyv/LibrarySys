-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 16, 2022 at 08:34 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bibliotheque`
--

-- --------------------------------------------------------

--
-- Table structure for table `abonnes`
--

CREATE TABLE `abonnes` (
  `id_abo` int(11) NOT NULL,
  `nom_abo` varchar(255) NOT NULL,
  `prenom_abo` varchar(255) NOT NULL,
  `sexe_abo` varchar(255) NOT NULL,
  `telephone_abo` int(11) NOT NULL,
  `etat` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `abonnes`
--

INSERT INTO `abonnes` (`id_abo`, `nom_abo`, `prenom_abo`, `sexe_abo`, `telephone_abo`, `etat`) VALUES
(1, 'Bimenyimana', 'Tony Blaise', 'Homme', 68456123, 'disponible'),
(2, 'Nishimwe', 'Alain Bruce', 'Homme', 12122121, 'occupe'),
(3, 'Ngendakumana', 'Lionnel', 'Homme', 78645123, 'disponible'),
(4, 'Linda', 'Serbe', 'Femme', 223569870, 'occupe'),
(6, 'Manirakiza', 'Francine', 'Femme', 79065198, '');

-- --------------------------------------------------------

--
-- Table structure for table `auteur`
--

CREATE TABLE `auteur` (
  `id_auteur` int(11) NOT NULL,
  `nom_auteur` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `auteur`
--

INSERT INTO `auteur` (`id_auteur`, `nom_auteur`) VALUES
(1, 'Tom Cruise'),
(2, 'Jean Jacques '),
(3, 'Jules Vernes'),
(4, 'Chirac Jacques');

-- --------------------------------------------------------

--
-- Table structure for table `bibliothecaire`
--

CREATE TABLE `bibliothecaire` (
  `id_biblio` int(11) NOT NULL,
  `nom_biblio` varchar(255) NOT NULL,
  `prenom_biblio` varchar(255) NOT NULL,
  `telephone` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bibliothecaire`
--

INSERT INTO `bibliothecaire` (`id_biblio`, `nom_biblio`, `prenom_biblio`, `telephone`) VALUES
(1, 'Ntahomvukiye', 'Gallion Jospin', '3212212'),
(3, 'Manimpa', 'Tony', '65454321'),
(4, 'Kamanzi', 'Donatien', '78654098');

-- --------------------------------------------------------

--
-- Table structure for table `emprunter`
--

CREATE TABLE `emprunter` (
  `id_emprunt` int(11) NOT NULL,
  `id_Livre` int(11) NOT NULL,
  `id_Abo` int(11) NOT NULL,
  `date_retour` varchar(255) NOT NULL,
  `statut` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `emprunter`
--

INSERT INTO `emprunter` (`id_emprunt`, `id_Livre`, `id_Abo`, `date_retour`, `statut`) VALUES
(1, 2, 2, 'Thursday, September 22, 2022', 'Non Retourné'),
(2, 2, 1, 'Friday, September 23, 2022', 'Non Retourné'),
(3, 1, 1, 'Monday, October 3, 2022', 'Retourné'),
(4, 4, 2, 'Wednesday, October 5, 2022', 'Non Retourné');

-- --------------------------------------------------------

--
-- Table structure for table `livres`
--

CREATE TABLE `livres` (
  `id_livre` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `annee` int(11) NOT NULL,
  `edition` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `quantite` int(11) NOT NULL,
  `id_Auteur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `livres`
--

INSERT INTO `livres` (`id_livre`, `title`, `annee`, `edition`, `description`, `quantite`, `id_Auteur`) VALUES
(1, 'How to win friends and influence people', 2002, 'Varsovie', 'developpement personnel', 20, 1),
(2, 'De la terre a la lune', 1889, 'Koumassi', 'science et fiction', 10, 2),
(3, 'Le Droit Maritime', 1980, '1ere Edition', 'Livre de Droit', 10, 3),
(4, 'La Chevre de Ma Mere', 2008, '1er Edition', 'Entrepreneuriat', 6, 4);

-- --------------------------------------------------------

--
-- Table structure for table `reserver`
--

CREATE TABLE `reserver` (
  `id_res` int(11) NOT NULL,
  `id_Abon` int(11) NOT NULL,
  `id_Livres` int(11) NOT NULL,
  `date_limite` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reserver`
--

INSERT INTO `reserver` (`id_res`, `id_Abon`, `id_Livres`, `date_limite`) VALUES
(1, 1, 2, 'Saturday, October 1, 2022'),
(3, 3, 3, 'Thursday, October 6, 2022'),
(4, 3, 2, 'Saturday, October 1, 2022');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id_users` int(11) NOT NULL,
  `nom_util` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id_users`, `nom_util`, `password`) VALUES
(1, 'ahishakiye', 'admin'),
(2, 'admin', '12345');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `abonnes`
--
ALTER TABLE `abonnes`
  ADD PRIMARY KEY (`id_abo`);

--
-- Indexes for table `auteur`
--
ALTER TABLE `auteur`
  ADD PRIMARY KEY (`id_auteur`);

--
-- Indexes for table `bibliothecaire`
--
ALTER TABLE `bibliothecaire`
  ADD PRIMARY KEY (`id_biblio`);

--
-- Indexes for table `emprunter`
--
ALTER TABLE `emprunter`
  ADD PRIMARY KEY (`id_emprunt`),
  ADD KEY `id_Abo` (`id_Abo`),
  ADD KEY `id_Livre` (`id_Livre`);

--
-- Indexes for table `livres`
--
ALTER TABLE `livres`
  ADD PRIMARY KEY (`id_livre`),
  ADD KEY `id_Auteur` (`id_Auteur`);

--
-- Indexes for table `reserver`
--
ALTER TABLE `reserver`
  ADD PRIMARY KEY (`id_res`),
  ADD KEY `id_Abon` (`id_Abon`),
  ADD KEY `id_Livres` (`id_Livres`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_users`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `abonnes`
--
ALTER TABLE `abonnes`
  MODIFY `id_abo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `auteur`
--
ALTER TABLE `auteur`
  MODIFY `id_auteur` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `bibliothecaire`
--
ALTER TABLE `bibliothecaire`
  MODIFY `id_biblio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `emprunter`
--
ALTER TABLE `emprunter`
  MODIFY `id_emprunt` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `livres`
--
ALTER TABLE `livres`
  MODIFY `id_livre` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `reserver`
--
ALTER TABLE `reserver`
  MODIFY `id_res` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id_users` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `emprunter`
--
ALTER TABLE `emprunter`
  ADD CONSTRAINT `emprunter_ibfk_1` FOREIGN KEY (`id_Abo`) REFERENCES `abonnes` (`id_abo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `emprunter_ibfk_2` FOREIGN KEY (`id_Livre`) REFERENCES `livres` (`id_livre`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `livres`
--
ALTER TABLE `livres`
  ADD CONSTRAINT `livres_ibfk_1` FOREIGN KEY (`id_Auteur`) REFERENCES `auteur` (`id_auteur`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `reserver`
--
ALTER TABLE `reserver`
  ADD CONSTRAINT `reserver_ibfk_1` FOREIGN KEY (`id_Abon`) REFERENCES `abonnes` (`id_abo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `reserver_ibfk_2` FOREIGN KEY (`id_Livres`) REFERENCES `livres` (`id_livre`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
