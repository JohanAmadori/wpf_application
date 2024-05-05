-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : sam. 04 mai 2024 à 13:49
-- Version du serveur : 10.4.28-MariaDB
-- Version de PHP : 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `raptest`
--

-- --------------------------------------------------------

--
-- Structure de la table `articles`
--

CREATE TABLE `articles` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `nom` varchar(15) NOT NULL,
  `note` int(11) DEFAULT NULL,
  `prix_public` decimal(9,2) NOT NULL,
  `img` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `articles`
--

INSERT INTO `articles` (`id`, `nom`, `note`, `prix_public`, `img`, `created_at`, `updated_at`) VALUES
(1, 'Booba', 95, 12.00, 'pictures/booba.png', NULL, NULL),
(2, 'Alkpote', 90, 10.00, 'pictures/alkpote.png', NULL, NULL),
(3, 'Lesram', 90, 10.00, 'pictures/lesram.png', NULL, NULL),
(4, 'Freeze Corleone', 88, 8.00, 'pictures/freeze.png', NULL, NULL),
(5, 'Zeu', 88, 8.00, 'pictures/zeu.png', NULL, NULL),
(6, 'Josman', 87, 8.00, 'pictures/josman.png', NULL, NULL),
(7, 'Laylow', 86, 8.00, 'pictures/laylow.png', NULL, NULL),
(8, 'Luv Resval', 86, 8.00, 'pictures/luv_resval.png', NULL, NULL),
(9, 'Tif', 83, 7.00, 'pictures/', NULL, NULL),
(10, 'Zamdane', 82, 7.00, 'pictures/zamdane.png', NULL, NULL),
(11, 'i300 ', 82, 7.00, 'pictures/i300.png', NULL, NULL),
(12, 'Houdi ', 82, 7.00, 'pictures/houdi.png', NULL, NULL),
(13, 'Roro La Meute ', 77, 5.00, 'pictures/roro.png', NULL, NULL),
(14, 'Zitoune', 74, 5.00, 'pictures/zitoune.png', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `comments`
--

CREATE TABLE `comments` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `parent_id` bigint(20) UNSIGNED DEFAULT NULL,
  `user_id` bigint(20) UNSIGNED DEFAULT NULL,
  `commentable_type` varchar(255) NOT NULL,
  `commentable_id` bigint(20) UNSIGNED NOT NULL,
  `content` longtext NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `failed_jobs`
--

CREATE TABLE `failed_jobs` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `uuid` varchar(255) NOT NULL,
  `connection` text NOT NULL,
  `queue` text NOT NULL,
  `payload` longtext NOT NULL,
  `exception` longtext NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_users_table', 1),
(2, '2014_10_12_100000_create_password_reset_tokens_table', 1),
(3, '2019_08_19_000000_create_failed_jobs_table', 1),
(4, '2019_12_14_000001_create_personal_access_tokens_table', 1),
(5, '2023_12_03_160450_create_table_articles', 1),
(6, '2023_12_17_211422_create_table_notation', 1),
(7, '2023_12_18_071419_create_table_rappeurs', 1),
(8, '2024_02_12_125248_create_table_quiz', 1),
(9, '2024_04_25_231029_create_paniers_table', 1),
(10, '2024_04_28_134114_create_user_responses_table', 1),
(11, 'create_comments_table', 1);

-- --------------------------------------------------------

--
-- Structure de la table `notations`
--

CREATE TABLE `notations` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `nom` varchar(15) NOT NULL,
  `note` int(11) DEFAULT NULL,
  `commentaire` varchar(500) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `paniers`
--

CREATE TABLE `paniers` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `user_id` bigint(20) UNSIGNED NOT NULL,
  `articles_id` bigint(20) UNSIGNED NOT NULL,
  `quantite` int(11) NOT NULL DEFAULT 1,
  `montant` decimal(2,2) NOT NULL DEFAULT 0.00,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `password_reset_tokens`
--

CREATE TABLE `password_reset_tokens` (
  `email` varchar(255) NOT NULL,
  `token` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `personal_access_tokens`
--

CREATE TABLE `personal_access_tokens` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `tokenable_type` varchar(255) NOT NULL,
  `tokenable_id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL,
  `token` varchar(64) NOT NULL,
  `abilities` text DEFAULT NULL,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `quizs`
--

CREATE TABLE `quizs` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `rappeur_id` bigint(20) UNSIGNED NOT NULL,
  `question` varchar(500) NOT NULL,
  `reponse1` varchar(500) NOT NULL,
  `reponse2` varchar(500) NOT NULL,
  `reponse3` varchar(500) NOT NULL,
  `reponse4` varchar(500) NOT NULL,
  `reponse` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `quizs`
--

INSERT INTO `quizs` (`id`, `rappeur_id`, `question`, `reponse1`, `reponse2`, `reponse3`, `reponse4`, `reponse`, `created_at`, `updated_at`) VALUES
(1, 5, 'De quel groupe faisait-il partie ?', '1995', 'Panama Bende', 'Scred Connexion', 'Collectif Metissé', 2, NULL, NULL),
(2, 5, 'Avec qui il n\'a jamais collaboré ?', '34 Murphy', 'Samou Skuu', 'Venom', 'PLK', 1, NULL, NULL),
(3, 5, 'A quel politicien fait-il référence dans un de ces sons ?', 'Gerald Darmanin', 'Eric Zemmour', 'Christophe Castaner', 'Nicolas Sarkozy', 3, NULL, NULL),
(4, 5, 'Quel est son Top Titre le plus ecouté sur Deezer ?', 'BVB', 'Decepticons', 'Haaland', 'Opp Block', 1, NULL, NULL),
(5, 5, 'Quel est le nom de son premier album/EP ?', 'Watergate', 'Butterfly Doors', 'Trashtalking', 'Boss Orders', 3, NULL, NULL),
(6, 4, 'De quel département est-il originaire ?', '92', '93', '94', '75', 2, NULL, NULL),
(7, 4, 'Avec qui il n\'a jamais collaboré ?', 'Alpha Wann', 'Aladin 135', 'Zeu', 'Osirus Jack', 3, NULL, NULL),
(8, 4, 'Dans quel son dit-il :\'Un mensonge, c\'est une plume, face au poids d\'la vérité\' ?', 'CNN', 'Wesh Enfoiré #5', 'Intro', 'Seum', 3, NULL, NULL),
(9, 4, 'Quel est son prénom ?', 'Marcel', 'Julien', 'Régis', 'Aboubakar', 1, NULL, NULL),
(10, 4, 'Quel est le nom de son dernier album ?', 'Du mieux que j\'ai pu', 'Wesh Enfoiré', 'G-31', 'Cri des momes', 1, NULL, NULL),
(11, 6, 'Avec quel artiste, n\'a t-il jamais featé? ', 'Dinos', 'Wit', 'Les Alchimistes', 'Kekra', 4, NULL, NULL),
(12, 6, 'Dans lequel de ses clips sortit en 2016, peut-t-on voir une voiture avec des leds?', 'Oto', 'Lime', 'Toyotarola', 'Y2', 2, NULL, NULL),
(13, 6, 'Quel est le nom de son dernier album ?', 'L\'Etrange histoire de Mr..', 'RAW-Z', 'Trinity', 'Megatron', 1, NULL, NULL),
(14, 6, 'Quel est son record de nb de ventes en premier semaine ?', '~ 18.000', '~ 24.000', '~ 30.000', '~ 35.000', 4, NULL, NULL),
(15, 6, 'Dans lequel de ces sons Laylow dit : \'Une saisie là ?, j\'me dis qu\'il saisit au moins, tenez, signez, c\'est la lettre du tribunal\' ?', '\'Plug\'', '\'Longue vie\'', 'C\'est pas Laylow qui dit ca', '\'.. DE BATARD\'', 3, NULL, NULL),
(16, 7, 'Quel est son prénom? ', 'Issa', 'Djibril', 'Lamine', 'Lorenzo', 1, NULL, NULL),
(17, 7, 'Avec quel artiste, n\'a t-il jamais featé?', 'Ashe22', 'Black Jack OBS', 'Lesram', 'La F', 3, NULL, NULL),
(18, 7, 'Quel est le nom de son premier VRAI album ?', 'ADC', 'LMF', 'PBB', 'Aucun des 3', 3, NULL, NULL),
(19, 7, 'Qui entend-on dans l\'intro du son \'Ancelotti\' ?', 'Marie-Aline Meliyi', 'Gerald Darmanin', 'Rachida Dati', 'Roselyne Bachelot', 4, NULL, NULL),
(20, 7, 'Comment s\'intitule le son enchainant théorie du complot sur théorie du complot ?', 'Lester', 'Sacrfice de Masse', 'Argent noir pt.3', 'S/o Congo pt.2', 2, NULL, NULL),
(21, 3, 'Quel influenceur celebre peut-on voir dans un de ses clips? ', 'Vargas', 'Nasdas', 'Bengous', 'Mortadon', 2, NULL, NULL),
(22, 3, 'Quel est le nom du son joué ici?', 'Benef', '7/7', 'Train de vie', 'Toute la nuit', 3, NULL, NULL),
(23, 3, 'Quel est son morceau le plus streamé sur Spotify?', 'S\'lever tot', 'Il m\'en faut plus', 'On vient d\'en bas', 'La Chienneté', 1, NULL, NULL),
(24, 3, 'Combien de featuring a t-il realisé?', '3', '2', '1', '0', 4, NULL, NULL),
(25, 3, 'Comment s\'appelle sa série de freestyle?', 'Les crocs', 'Côtépass', 'La Meute', 'Freestyle Sauvage', 3, NULL, NULL),
(26, 1, 'Dans quel clip peut-on voir 4 personnes rapper au tour d\'une table? Et combien de sons a-t-il posé? ', 'Grhunt #77 / 3', 'Nuketown / 3', 'Grhunt #77 / 4', 'Nuketown / 4', 3, NULL, NULL),
(27, 1, 'Avec quel rappeur n\'a t-il jamais featé?', 'Lesram', 'Guy2bezbar', '34murphy', 'Aucun d\'eux', 4, NULL, NULL),
(28, 1, 'Est-il deja passé dans l\'emission \'ZEN\'?', 'Non, mais il a été cité lors de l\'emission', 'Non', 'Oui et il a deja fait un feat avec Grim', 'Oui, ', 1, NULL, NULL),
(29, 1, 'Dans quel son dit-il ? :\'Le démon a pitié d\'eux, il m\'chuchote : \'laisse les vivre\' ', '7734', 'Dérapages', 'Woka', 'Pile ou face', 1, NULL, NULL),
(30, 1, 'Quel est son clip le plus réussi visuellement? Completement objectif (non, c faux)', 'Mode Hardcore', 'Belle chanson', 'Monaco', 'Sensation', 2, NULL, NULL),
(31, 2, 'De quelle ville sont-ils originaires? ', 'Nanterre', 'Levallois Peret', 'Grigny', 'Corbeil', 2, NULL, NULL),
(32, 2, 'De quel son est extrait cette phase : \'J’fume la tookah la tête qui tourne\'', 'Impliqué', 'B1', 'Amen', 'Tours', 4, NULL, NULL),
(33, 2, 'Un des 2 rappeurs porte le nom d\'un célébre dirigeant, lequel?', 'Staline', 'Berlusconi', 'Franco', 'Fidel Castro, ', 1, NULL, NULL),
(34, 2, 'Dans quel son dit-il ? :\'Le démon a pitié d\'eux, il m\'chuchote : \'laisse les vivre\' ', '7734', 'Dérapages', 'Woka', 'Pile ou face', 3, NULL, NULL),
(35, 2, 'Quel est son clip le plus réussi visuellement? Completement objectif (non, c faux)', 'Mode Hardcore', 'Belle chanson', 'Monaco', 'Sensation', 3, NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `rappeurs`
--

CREATE TABLE `rappeurs` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `nom` varchar(70) NOT NULL,
  `note_globale` int(11) DEFAULT NULL,
  `vignette` varchar(255) DEFAULT NULL,
  `picture` varchar(255) DEFAULT NULL,
  `lien` varchar(255) DEFAULT NULL,
  `musique` varchar(255) DEFAULT NULL,
  `spotify` varchar(255) DEFAULT NULL,
  `insta` varchar(255) DEFAULT NULL,
  `youtube` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `rappeurs`
--

INSERT INTO `rappeurs` (`id`, `nom`, `note_globale`, `vignette`, `picture`, `lien`, `musique`, `spotify`, `insta`, `youtube`, `created_at`, `updated_at`) VALUES
(1, 'Houdi', 82, 'houdi.jpg', 'houdi.png', 'rappeur/1', 'houdi.mp3', 'https://open.spotify.com/intl-fr/artist/0E9vzecg75Thz2ekrGIaF6', 'https://www.instagram.com/houdihood/', 'https://www.youtube.com/@HOUDIHOOD', NULL, NULL),
(2, 'i300', 80, 'i300.jpg', 'i300.png', 'rappeur/2', 'i300.mp3', 'https://open.spotify.com/intl-fr/artist/5crOTgkcDtgMTCoatASEBs', '', 'https://www.youtube.com/@i300_officiel', NULL, NULL),
(3, 'Roro La Meute', 77, 'roro.jpg', 'roro.png', 'rappeur/3', 'roro.mp3', 'https://open.spotify.com/intl-fr/artist/1cmMENrCxOfXMpiM43FRqG', 'https://www.instagram.com/rorolameute/', 'https://www.youtube.com/@rorolameute', NULL, NULL),
(4, 'Lesram', 90, 'lesram.jpg', 'lesram.png', 'rappeur/4', 'lesram.mp3', 'https://open.spotify.com/intl-fr/artist/0UeKDbiaApyP7qKfcmGN03?si=afe2ba69aed640be', 'https://www.instagram.com/lesram310/', 'https://www.youtube.com/@lesram3109', NULL, NULL),
(5, 'Zeu', 88, 'zeu.jpg', 'zeu.png', 'rappeur/5', 'zeu.mp3', 'https://open.spotify.com/intl-fr/artist/36MWnDH4kn3Sx79LLtLpjF', 'https://www.instagram.com/zeumystery/', 'https://www.youtube.com/@ZEUOFF', NULL, NULL),
(6, 'Laylow', 86, 'laylow.jpg', 'laylow.png', 'rappeur/6', 'laylow.mp3', 'https://open.spotify.com/intl-fr/artist/0LnhY2fzptb0QEs5Q5gM7S', 'https://www.instagram.com/jey.laylow/', 'https://www.youtube.com/@laylowxsirkloTV', NULL, NULL),
(7, 'Freeze Corleone', 87, 'freeze.webp', 'freeze.png', 'rappeur/7', 'freeze.mp3', 'https://open.spotify.com/intl-fr/artist/76Pl0epAMXVXJspaSuz8im', 'https://www.instagram.com/bigfreezecorleone667/', 'https://www.youtube.com/channel/UCKU0CiLJ075xJ7Pgq1N5L5g', NULL, NULL),
(8, 'Tif', 83, 'tif.jpg', '', 'rappeur/7', 'tif.mp3', 'https://open.spotify.com/intl-fr/artist/2NgTPluNpfsoYZnoeU2VsH', 'https://www.instagram.com/the.tif/', 'https://www.youtube.com/@The_tif', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `points` int(11) NOT NULL DEFAULT 0,
  `tentatives` int(11) NOT NULL DEFAULT 0,
  `remember_token` varchar(100) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `user_responses`
--

CREATE TABLE `user_responses` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `user_id` bigint(20) UNSIGNED NOT NULL,
  `quizs_id` bigint(20) UNSIGNED NOT NULL,
  `quantite` int(11) NOT NULL DEFAULT 1,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `articles`
--
ALTER TABLE `articles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `articles_nom_index` (`nom`),
  ADD KEY `articles_note_index` (`note`),
  ADD KEY `articles_prix_public_index` (`prix_public`),
  ADD KEY `articles_img_index` (`img`);

--
-- Index pour la table `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `comments_commentable_type_commentable_id_index` (`commentable_type`,`commentable_id`),
  ADD KEY `comments_parent_id_index` (`parent_id`),
  ADD KEY `comments_user_id_index` (`user_id`);

--
-- Index pour la table `failed_jobs`
--
ALTER TABLE `failed_jobs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`);

--
-- Index pour la table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `notations`
--
ALTER TABLE `notations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `notations_nom_index` (`nom`),
  ADD KEY `notations_note_index` (`note`),
  ADD KEY `notations_commentaire_index` (`commentaire`);

--
-- Index pour la table `paniers`
--
ALTER TABLE `paniers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `paniers_user_id_foreign` (`user_id`),
  ADD KEY `paniers_articles_id_foreign` (`articles_id`);

--
-- Index pour la table `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  ADD PRIMARY KEY (`email`);

--
-- Index pour la table `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  ADD KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`);

--
-- Index pour la table `quizs`
--
ALTER TABLE `quizs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `quizs_rappeur_id_index` (`rappeur_id`);

--
-- Index pour la table `rappeurs`
--
ALTER TABLE `rappeurs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rappeurs_nom_index` (`nom`),
  ADD KEY `rappeurs_note_globale_index` (`note_globale`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_email_unique` (`email`);

--
-- Index pour la table `user_responses`
--
ALTER TABLE `user_responses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_responses_user_id_foreign` (`user_id`),
  ADD KEY `user_responses_quizs_id_foreign` (`quizs_id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `articles`
--
ALTER TABLE `articles`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT pour la table `comments`
--
ALTER TABLE `comments`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `failed_jobs`
--
ALTER TABLE `failed_jobs`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pour la table `notations`
--
ALTER TABLE `notations`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `paniers`
--
ALTER TABLE `paniers`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `quizs`
--
ALTER TABLE `quizs`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT pour la table `rappeurs`
--
ALTER TABLE `rappeurs`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `user_responses`
--
ALTER TABLE `user_responses`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `paniers`
--
ALTER TABLE `paniers`
  ADD CONSTRAINT `paniers_articles_id_foreign` FOREIGN KEY (`articles_id`) REFERENCES `articles` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `paniers_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `quizs`
--
ALTER TABLE `quizs`
  ADD CONSTRAINT `quizs_rappeur_id_foreign` FOREIGN KEY (`rappeur_id`) REFERENCES `rappeurs` (`id`);

--
-- Contraintes pour la table `user_responses`
--
ALTER TABLE `user_responses`
  ADD CONSTRAINT `user_responses_quizs_id_foreign` FOREIGN KEY (`quizs_id`) REFERENCES `quizs` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `user_responses_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
