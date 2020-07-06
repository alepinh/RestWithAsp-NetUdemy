CREATE TABLE IF NOT EXISTS `livros` (
  `id` varchar(127) NOT NULL,
  `Autor` longtext,
  `DataLancamento` datetime(6) NOT NULL,
  `Preco` decimal(65,2) NOT NULL,
  `Titulo` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;