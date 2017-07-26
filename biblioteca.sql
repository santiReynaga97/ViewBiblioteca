-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 11-07-2017 a las 17:14:15
-- Versión del servidor: 10.1.24-MariaDB
-- Versión de PHP: 7.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `biblioteca`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `LibroActualizar` (IN `pId` INT, IN `pNom` VARCHAR(50), IN `pDes` VARCHAR(100), IN `pIdAutor` INT, IN `pIdCat` INT, IN `pAnioP` DATE, IN `pIdTip` INT, IN `pCant` INT)  NO SQL
BEGIN 

    UPDATE libros
    SET    
          libros.nombre = pNom,
          libros.descripcion=pDes,
          libros.id_autor=pIdAutor,
          libros.id_categoria =pIdCat,
          libros.anio_publicacion=pAnioP,
          libros.id_tipo_libro=pIdTip,
          libros.cantidad_paginas=pCant
          
    WHERE libros.id = pId; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `LibroAgregar` (IN `pNom` VARCHAR(50), IN `pDes` VARCHAR(100), IN `pIdAutor` INT UNSIGNED, IN `pIdCat` INT UNSIGNED, IN `pAnioP` DATE, IN `pIdTip` INT UNSIGNED, IN `pCant` INT UNSIGNED)  NO SQL
    COMMENT 'AgregarLIBRO'
BEGIN

	INSERT INTO `Libros`( `nombre`, `descripcion`, `id_autor`, 							`id_categoria`,`anio_publicacion`,
                `id_tipo_libro`,`cantidad_paginas`) 						VALUES (pNom,pDes,pIdAutor,pIdCat,pAnioP,pIdTip,pCant);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `LibroEliminar` (IN `pId` INT)  NO SQL
BEGIN
DELETE FROM libros WHERE libros.id = pId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ListaLibros` ()  NO SQL
BEGIN 

SELECT libros.id,libros.nombre,libros.descripcion,libros.id_autor,
libros.id_categoria,libros.id_tipo_libro,libros.cantidad_paginas

FROM libros;

   
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerLibro` (IN `pId` INT)  NO SQL
BEGIN 

SELECT libros.id,libros.nombre,libros.descripcion,libros.id_autor,
libros.id_categoria,libros.id_tipo_libro,libros.cantidad_paginas

FROM libros

WHERE libros.id=pId;

   
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE `libros` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `id_autor` int(11) NOT NULL,
  `id_categoria` int(11) NOT NULL,
  `anio_publicacion` date NOT NULL,
  `id_tipo_libro` int(11) NOT NULL,
  `cantidad_paginas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`id`, `nombre`, `descripcion`, `id_autor`, `id_categoria`, `anio_publicacion`, `id_tipo_libro`, `cantidad_paginas`) VALUES
(2, 'LOS CERDITOS', 'SE LOS COMEN', 2, 3, '0000-00-00', 2, 12),
(3, 'caperrusita roja', 'se comen a caperusita', 3, 2, '0000-00-00', 1, 20),
(4, 'caperucita3', 'la niña roja q se lo come ', 2, 1, '0001-01-01', 2, 555),
(5, 'caperrusita roja', 'se comen a caperusita', 3, 2, '0000-00-00', 1, 20),
(6, 'caperrusita roja', 'se comen a caperusita', 3, 2, '0000-00-00', 1, 20),
(8, 'caperrusita roja', 'se comen a caperusita', 3, 2, '2014-06-10', 1, 20),
(9, 'Los 3 cerditos', 'cacaaaaa', 0, 0, '0001-01-01', 0, 0),
(10, 'Las mil y una noches', 'Este libro habla sobre las aventasdsadas', 1, 2, '2017-05-12', 3, 67),
(11, 'popeye el marino', 'un marino que salvaba a la gente', 3, 1, '1995-05-22', 2, 23),
(13, 'los minions', 'juguetes', 1, 2, '2017-05-12', 1, 323);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `libros`
--
ALTER TABLE `libros`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `libros`
--
ALTER TABLE `libros`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
