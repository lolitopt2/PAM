use casacompras;
CREATE TABLE ListasCompras (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NomeLista VARCHAR(100) NOT NULL,
    DataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE ListaItens (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    ListaId INT,
    ItemId INT,
    Quantidade INT NOT NULL,
    FOREIGN KEY (ListaId) REFERENCES ListasCompras(Id),
    FOREIGN KEY (ItemId) REFERENCES Itens(Id)
);

INSERT INTO Itens (Nome) VALUES ('Arroz');
INSERT INTO Itens (Nome) VALUES ('Feijão');
INSERT INTO Itens (Nome) VALUES ('Macarrão');

INSERT INTO ListasCompras (NomeLista) VALUES ('Compras da Semana');

INSERT INTO ListaItens (ListaId, ItemId, Quantidade) VALUES (1, 1, 2); -- 2 pacotes de Arroz
INSERT INTO ListaItens (ListaId, ItemId, Quantidade) VALUES (1, 2, 1); -- 1 pacote de Feijão
INSERT INTO ListaItens (ListaId, ItemId, Quantidade) VALUES (1, 3, 3); -- 3 pacotes de Macarrãoitens

select * from listascompras;
select * from listaitens;