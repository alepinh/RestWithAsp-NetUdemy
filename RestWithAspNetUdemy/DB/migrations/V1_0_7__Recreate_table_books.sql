CREATE TABLE IF NOT EXISTS `livros` (
  `id` INT(10) AUTO_INCREMENT PRIMARY KEY,
  `Autor` longtext,
  `DataLancamento` datetime(6) NOT NULL,
  `Preco` decimal(65,2) NOT NULL,
  `Titulo` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;