# Alterações BD Servipol


```sql
ALTER TABLE public.usuarios RENAME id  TO id_usuario;

ALTER TABLE public.veiculos RENAME id  TO id_veiculo;

ALTER TABLE public.tipo_manutencao RENAME descricao_manutencao TO descricao;

ALTER TABLE public.tipo_manutencao  RENAME TO manutencao_tipo;

ALTER TABLE public.local_manutencao  RENAME TO manutencao_local;

ALTER TABLE public.manutencao_tipo RENAME id_tipo_manutencao  TO id_manutencao_tipo;

ALTER TABLE public.manutencao_local RENAME id_local_manutencao  TO id_manutencao_local;

ALTER TABLE public.manutencao_veiculo  RENAME TO manutencao;

ALTER TABLE public.manutencao RENAME id  TO id_manutencao;

ALTER TABLE public.tipo_veiculo RENAME id  TO id_veiculo_tipo;

ALTER TABLE public.tipo_veiculo  RENAME TO veiculo_tipo;

ALTER TABLE public.veiculos RENAME tipo_veiculo  TO tipo;

ALTER TABLE public.veiculos RENAME codigo_veiculo  TO codigo;

ALTER TABLE public.veiculos RENAME descricao_veiculo  TO descricao;

ALTER TABLE public.veiculos  RENAME TO veiculo;

ALTER TABLE public.tipo_funcionario RENAME id_tipo_funcionario  TO id_funcionario_cargo;

ALTER TABLE public.tipo_funcionario RENAME descricao_tipo_funcionario  TO descricao;

ALTER TABLE public.tipo_funcionario  RENAME TO funcionario_cargo;

ALTER TABLE public.funcionarios RENAME id_tipo_funcionario  TO id_funcionario_cargo;

ALTER TABLE public.funcionarios RENAME logradouro_endereco_funcionario  TO logradouro_endereco;

ALTER TABLE public.funcionarios RENAME numero_endereco_funcionario  TO numero_endereco;

ALTER TABLE public.funcionarios RENAME bairro_endereco_funcionario  TO bairro_endereco;

ALTER TABLE public.funcionarios RENAME cidade_endereco_funcionario  TO cidade_endereco;

ALTER TABLE public.funcionarios RENAME estado_endereco_funcionario  TO uf_endereco;

ALTER TABLE public.funcionarios RENAME telefone_funcionario_1  TO telefone_1;

ALTER TABLE public.funcionarios RENAME telefone_funcionario_2  TO telefone_2;

ALTER TABLE public.funcionarios RENAME telefone_funcionario_3  TO telefone_3;

ALTER TABLE public.funcionarios RENAME observacao_funcionario  TO observacao;

ALTER TABLE public.funcionarios RENAME cep_endereco_funcionario  TO cep_endereco;

ALTER TABLE public.funcionarios RENAME telefone_funcionario_4  TO telefone_4;

ALTER TABLE public.funcionarios RENAME cargo  TO cargo_operacional_externo;

ALTER TABLE public.funcionarios RENAME TO funcionario;

ALTER TABLE public.funcionario RENAME id  TO id_funcionario;

ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_local character varying(255);

ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_cidade character varying(255);

ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_uf character varying(2);

ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_validade date;

ALTER TABLE public.funcionario  ADD COLUMN tem_curso_vigilante character(1);

ALTER TABLE public.usuarios  ADD COLUMN id_usuario_reativacao integer;

ALTER TABLE public.usuarios  ADD COLUMN data_reativacao timestamp without time zone;

ALTER TABLE public.usuarios  RENAME TO usuario;

-- Table: public.funcionario

DROP TABLE public.funcionario;

CREATE TABLE public.funcionario

(

 id_funcionario integer NOT NULL,

 id_funcionario_cargo integer,

 cod_controle character varying(50),

 tipo_sanguineo character(3),

 data_nascimento date,

 nome character varying(255),

 nome_mae character varying(255),

 nome_pai character varying(255),

 cpf character varying(20),

 rg character varying(20),

 uf_exp_rg character varying(2),

 data_exp_rg date,

 cat_cnh_a character(1),

 cat_cnh_b character(1),

 cat_cnh_c character(1),

 cat_cnh_d character(1),

 cat_cnh_e character(1),

 numero_registro_cnh character varying(50),

 data_validade_cnh date,

 observacao character varying(500),

 data_admissao date,

 pis_pasep character varying(20),

 numero_ctps character varying(20),

 serie_ctps character varying(10),

 uf_emissao_ctps character varying(2),

 logradouro_endereco character varying(300),

 numero_endereco character varying(10),

 bairro_endereco character varying(100),

 cidade_endereco character varying(100),

 uf_endereco character varying(2),

 cep_endereco character varying(15),

 email character varying(100),

 telefone_1 character varying(100),

 telefone_2 character varying(100),

 telefone_3 character varying(100),

 telefone_4 character varying(100),

 tipo_contato_1 character varying(100),

 tipo_contato_2 character varying(100),

 tipo_contato_3 character varying(100),

 tipo_contato_4 character varying(100),

 nome_contato_1 character varying(200),

 nome_contato_2 character varying(200),

 nome_contato_3 character varying(200),

 nome_contato_4 character varying(200),

 cargo_ase character varying(20),

 codigo_ase character(4),

 qra_ase character varying(50),

 tem_curso_vigilante character(1),

 curso_vigilante_local character varying(255),

 curso_vigilante_cidade character varying(255),

 curso_vigilante_uf character varying(2),

 curso_vigilante_validade date,

 id_usuario_cadastro integer,

 data_cadastro timestamp without time zone,

 id_usuario_desativacao integer,

 data_desativacao timestamp without time zone,

 id_usuario_reativacao integer,

 data_reativacao timestamp without time zone,

 ativo character(1),

 CONSTRAINT pk_funcionario PRIMARY KEY (id_funcionario)

)

WITH (

 OIDS=FALSE

);

ALTER TABLE public.funcionario

 OWNER TO postgres;

-- Index: public.idx_funcionario

DROP INDEX public.idx_funcionario;

CREATE INDEX idx_funcionario

 ON public.funcionario

 USING btree

 (id_funcionario);



CREATE SEQUENCE seq_km_diario
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    START 1
    CACHE 1;
	

CREATE SEQUENCE seq_sis_controle_versao
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_sis_sessao_login
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_km_diario
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_funcionario
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_veiculo
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_manutencao
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_manutencao_local
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_manutencao_tipo
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_abastecimento
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE SEQUENCE seq_usuario
INCREMENT 1
MINVALUE 1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

DELETE FROM sis_sessao_login;
```

