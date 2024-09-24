-- Tabela de Equipes

CREATE TABLE Equipes (

EquipeId INT PRIMARY KEY IDENTITY(1,1),

Nome VARCHAR(100) NOT NULL

);

-- Tabela de Membros da Equipe

CREATE TABLE MembrosEquipe (

MembroId INT PRIMARY KEY IDENTITY(1,1),

Nome VARCHAR(100) NOT NULL,

Email VARCHAR(100) NOT NULL,

EquipeId INT NOT NULL,

FOREIGN KEY (EquipeId) REFERENCES Equipes(EquipeId) ON DELETE CASCADE

);

-- Tabela de Projetos

CREATE TABLE Projetos (

ProjetoId INT PRIMARY KEY IDENTITY(1,1),

Nome VARCHAR(100) NOT NULL,

Descricao TEXT NULL,

DataInicio DATE NOT NULL,

DataFim DATE NULL,

StatusProjeto VARCHAR(50) NOT NULL,

EquipeId INT NOT NULL,

FOREIGN KEY (EquipeId) REFERENCES Equipes(EquipeId) ON DELETE CASCADE

);

-- Tabela de Tarefas

CREATE TABLE Tarefas (

TarefaId INT PRIMARY KEY IDENTITY(1,1),

Nome VARCHAR(100) NOT NULL,

Descricao TEXT NULL,

DataCriacao DATE NOT NULL,

DataConclusao DATE NULL,

Prioridade VARCHAR(50) NOT NULL,

StatusTarefa VARCHAR(50) NOT NULL,

ProjetoId INT NOT NULL,

ResponsavelId INT NULL,

FOREIGN KEY (ProjetoId) REFERENCES Projetos(ProjetoId) ON DELETE CASCADE,

FOREIGN KEY (ResponsavelId) REFERENCES MembrosEquipe(MembroId)

);

--Adicionando alores nas tabelas:

--EQUIPES

INSERT INTO Equipes (Nome) VALUES ('Equipe Alpha');

INSERT INTO Equipes (Nome) VALUES ('Equipe Beta');

INSERT INTO Equipes (Nome) VALUES ('Equipe Gama');

INSERT INTO Equipes (Nome) VALUES ('Equipe Delta');

INSERT INTO Equipes (Nome) VALUES ('Equipe Epsilon');

INSERT INTO Equipes (Nome) VALUES ('Equipe Zeta');

INSERT INTO Equipes (Nome) VALUES ('Equipe Theta');

INSERT INTO Equipes (Nome) VALUES ('Equipe Sigma');

SELECT*FROM Equipes;

--MEMBROS EQUIPE

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('João Silva', 'joao.silva@email.com', 1);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Maria Souza', 'maria.souza@email.com', 2);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Carlos Lima', 'carlos.lima@email.com', 3);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Ana Paula', 'ana.paula@email.com', 4);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Felipe Andrade', 'felipe.andrade@email.com', 5);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Juliana Alves', 'juliana.alves@email.com', 6);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Pedro Ribeiro', 'pedro.ribeiro@email.com', 7);

INSERT INTO MembrosEquipe (Nome, Email, EquipeId) VALUES ('Carolina Santos', 'carolina.santos@email.com', 8);

--PROJETOS

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto A', 'Desenvolvimento de software', '2024-01-01', NULL, 'Em andamento', 1);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto B', 'Pesquisa de mercado', '2024-02-15', '2024-08-01', 'Concluído', 2);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto C', 'Plano de expansão', '2024-03-10', NULL, 'Em andamento', 3);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto D', 'Reestruturação interna', '2024-04-05', NULL, 'Em andamento', 4);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto E', 'Lançamento de novo produto', '2024-05-20', '2024-09-30', 'Concluído', 5);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto F', 'Automação de processos', '2024-06-01', NULL, 'Em andamento', 6);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto G', 'Treinamento de equipe', '2024-07-10', '2024-08-25', 'Concluído', 7);

INSERT INTO Projetos (Nome, Descricao, DataInicio, DataFim, StatusProjeto, EquipeId)

VALUES ('Projeto H', 'Campanha de marketing', '2024-08-01', NULL, 'Em andamento', 8);

--TAREFAS

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Análise de requisitos', 'Levantar requisitos do projeto', '2024-01-05', NULL, 'Alta', 'Em andamento', 1, 1);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Pesquisa de mercado inicial', 'Estudo de mercado para definir público-alvo', '2024-02-20', '2024-03-15', 'Média', 'Concluído', 2, 2);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Plano de expansão fase 1', 'Definir estratégias de expansão regional', '2024-03-15', NULL, 'Alta', 'Em andamento', 3, 3);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Reestruturação financeira', 'Revisão da estrutura de custos', '2024-04-10', NULL, 'Alta', 'Em andamento', 4, 4);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Lançamento produto fase 1', 'Preparação para lançamento do produto', '2024-06-15', '2024-09-01', 'Alta', 'Concluído', 5, 5);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Automação de processos fase 1', 'Automatizar processos internos', '2024-06-10', NULL, 'Média', 'Em andamento', 6, 6);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Treinamento básico', 'Treinamento inicial da equipe', '2024-07-12', '2024-07-25', 'Baixa', 'Concluído', 7, 7);

INSERT INTO Tarefas (Nome, Descricao, DataCriacao, DataConclusao, Prioridade, StatusTarefa, ProjetoId, ResponsavelId)

VALUES ('Campanha marketing fase 1', 'Desenvolvimento da campanha inicial', '2024-08-05', NULL, 'Alta', 'Em andamento', 8, 8);