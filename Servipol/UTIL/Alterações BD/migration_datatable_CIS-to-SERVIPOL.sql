-------------------------- ********************** INICIO DA CRIAÇÃO DE TABELAS TEMPORARIAS ********************** --------------------------

-- Table: public.temp_manutencao_local

CREATE TABLE public.temp_manutencao_local
(
  id_manutencao_local integer NOT NULL,
  descricao character varying(255),
  id_usuario_cadastro integer,
  data_cadastro timestamp without time zone,
  id_usuario_desativacao integer,
  data_desativacao timestamp without time zone,
  id_usuario_alteracao integer,
  data_alteracao timestamp without time zone,
  ativo character(1),
  posto_combustivel character(1),
  CONSTRAINT pk_manutencao_local PRIMARY KEY (id_manutencao_local)
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_manutencao_local
  OWNER TO postgres;

-- Index: public.idx_local_manutencao

CREATE INDEX idx_manutencao_local
  ON public.temp_manutencao_local
  USING btree
  (id_manutencao_local);


-- Table: public.temp_manutencao_tipo

CREATE TABLE public.temp_manutencao_tipo
(
  id_manutencao_tipo integer NOT NULL,
  descricao character varying(255),
  ordem integer,
  aplicacao_carro character(1),
  aplicacao_moto character(1),
  id_usuario_cadastro integer,
  data_cadastro timestamp without time zone,
  id_usuario_desativacao integer,
  data_desativacao timestamp without time zone,
  id_usuario_alteracao integer,
  data_alteracao timestamp without time zone,
  ativo character(1),
  exige_km_validade_oleo character(1),
  CONSTRAINT pk_manutencao_tipo PRIMARY KEY (id_manutencao_tipo)
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_manutencao_tipo
  OWNER TO postgres;

-- Index: public.idx_tipo_manutencao

CREATE INDEX idx_manutencao_tipo
  ON public.temp_manutencao_tipo
  USING btree
  (id_manutencao_tipo);


-- Table: public.temp_veiculo

CREATE TABLE public.temp_veiculo
(
  id_veiculo integer NOT NULL,
  id_veiculo_tipo integer,
  codigo integer,
  descricao character varying(255),
  placa character varying(10),
  combustivel character varying(20),
  registra_km_diario character(1),
  id_usuario_cadastro integer,
  data_cadastro timestamp without time zone,
  id_usuario_desativacao integer,
  data_desativacao timestamp without time zone,
  id_usuario_reativacao integer,
  data_reativacao timestamp without time zone,
  id_usuario_alteracao integer,
  data_alteracao timestamp without time zone,
  km_validade_oleo numeric(13,0),
  ativo character(1),
  CONSTRAINT pk_veiculo PRIMARY KEY (id_veiculo)
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_veiculo
  OWNER TO postgres;
  


-- Table: public.temp_usuario

CREATE TABLE public.temp_usuario
(
  id_usuario integer NOT NULL,
  nome character varying(255),
  login character varying(100),
  senha character varying(32),
  altera_senha_prox_login character(1),
  ativo character(1),
  id_usuario_cadastro integer,
  data_cadastro timestamp without time zone,
  id_usuario_alteracao integer,
  data_alteracao timestamp without time zone,
  id_usuario_exclusao integer,
  data_exclusao timestamp without time zone,
  CONSTRAINT pk_usuario PRIMARY KEY (id_usuario)
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_usuario
  OWNER TO postgres;

-- Index: public.idx_usuario

CREATE INDEX idx_usuario
  ON public.temp_usuario
  USING btree
  (id_usuario);



-- Table: public.temp_funcionario

CREATE TABLE public.temp_funcionario
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
  id_usuario_alteracao integer,
  data_alteracao timestamp without time zone,
  ativo character(1),
  CONSTRAINT pk_funcionario PRIMARY KEY (id_funcionario)
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_funcionario
  OWNER TO postgres;

-- Index: public.idx_funcionario

CREATE INDEX idx_funcionario
  ON public.temp_funcionario
  USING btree
  (id_funcionario);
  


CREATE TABLE public.temp_manutencao
(
  id_manutencao integer NOT NULL,
  data_manutencao date,
  observacao character varying(2000),
  km_validade_oleo numeric(13,0),
  id_veiculo integer,
  id_manutencao_tipo integer,
  id_manutencao_local integer,
  id_funcionario integer,
  id_usuario_cadastro integer,
  data_cadastro timestamp without time zone,
  motivo_exclusao character varying(500),
  id_usuario_exclusao integer,
  data_exclusao timestamp without time zone,
  km_anterior numeric(13,0),
  km_veiculo numeric(13,0),
  valor_peca numeric(13,2),
  valor_servico numeric(13,2),
  valor_desconto numeric(13,2),
  valor_acrescimo numeric(13,2),
  valor_total numeric(13,2),
  registro_excluido character(1) DEFAULT 'N'::bpchar,
  confirmada character varying(255),
  CONSTRAINT pk_manutencao PRIMARY KEY (id_manutencao),
  CONSTRAINT fk_manutencao_local FOREIGN KEY (id_manutencao_local)
      REFERENCES public.manutencao_local (id_manutencao_local) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT fk_manutencao_tipo FOREIGN KEY (id_manutencao_tipo)
      REFERENCES public.manutencao_tipo (id_manutencao_tipo) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT fk_veiculo FOREIGN KEY (id_veiculo)
      REFERENCES public.veiculo (id_veiculo) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE RESTRICT
)
WITH (
  OIDS=FALSE,
  autovacuum_enabled=true
);
ALTER TABLE public.temp_manutencao
  OWNER TO postgres;


CREATE INDEX idx_manutencao
  ON public.temp_manutencao
  USING btree
  (id_manutencao);





-------------------------- ********************** FIM DA CRIAÇÃO DE TABELAS TEMPORARIAS ********************** --------------------------




-------------------------- ********************** INICIO DAS IMPORTAÇÕES ********************** --------------------------

INSERT INTO public."temp_usuario"(
            id_usuario, nome, login, senha, altera_senha_prox_login, ativo, 
            id_usuario_cadastro, data_cadastro, id_usuario_alteracao, data_alteracao, 
            id_usuario_exclusao, data_exclusao) 
            (SELECT id, nome, login, senha, 'N', ativo, id_usuario_cadastro, data_cadastro, 
            null, null, id_usuario_desativacao, data_desativacao FROM public.usuarios);
			
			
INSERT INTO public."temp_veiculo"(
            id_veiculo, id_veiculo_tipo, codigo, descricao, placa, combustivel, 
            registra_km_diario, id_usuario_cadastro, data_cadastro, id_usuario_desativacao, 
            data_desativacao, id_usuario_reativacao, data_reativacao, id_usuario_alteracao, 
            data_alteracao, km_validade_oleo, ativo) 
            (SELECT id, tipo_veiculo, codigo_veiculo, descricao_veiculo, placa, combustivel, 
            registra_km_diario, id_usuario_cadastro, data_cadastro, id_usuario_desativacao, data_desativacao, 
            id_usuario_reativacao, data_reativacao, null, null, 2000, ativo FROM public.veiculos);
			
			
INSERT INTO public."temp_manutencao_tipo"(
            id_manutencao_tipo, descricao, ordem, aplicacao_carro, aplicacao_moto, 
            id_usuario_cadastro, data_cadastro, id_usuario_desativacao, data_desativacao, 
            id_usuario_alteracao, data_alteracao, ativo, exige_km_validade_oleo) 
            (SELECT id_tipo_manutencao, descricao_manutencao, ordem, aplicacao_carro, aplicacao_moto, 
            id_usuario_cadastro, data_cadastro, id_usuario_desativacao, data_desativacao, null, null, 
            ativo, 'N' FROM public.tipo_manutencao);
			
			
INSERT INTO public."temp_manutencao_local"(
            id_manutencao_local, descricao, id_usuario_cadastro, data_cadastro, 
            id_usuario_desativacao, data_desativacao, id_usuario_alteracao, 
            data_alteracao, ativo, posto_combustivel) 
            (SELECT id_local_manutencao, descricao, id_usuario_cadastro, data_cadastro, 
            id_usuario_desativacao, data_desativacao, null, null, ativo, posto_combustivel FROM public.local_manutencao);
			
			
INSERT INTO public."temp_funcionario"(
            id_funcionario, id_funcionario_cargo, cod_controle, tipo_sanguineo, 
            data_nascimento, nome, nome_mae, nome_pai, cpf, rg, uf_exp_rg, 
            data_exp_rg, cat_cnh_a, cat_cnh_b, cat_cnh_c, cat_cnh_d, cat_cnh_e, 
            numero_registro_cnh, data_validade_cnh, observacao, data_admissao, 
            pis_pasep, numero_ctps, serie_ctps, uf_emissao_ctps, logradouro_endereco, 
            numero_endereco, bairro_endereco, cidade_endereco, uf_endereco, 
            cep_endereco, email, telefone_1, telefone_2, telefone_3, telefone_4, 
            tipo_contato_1, tipo_contato_2, tipo_contato_3, tipo_contato_4, 
            nome_contato_1, nome_contato_2, nome_contato_3, nome_contato_4, 
            cargo_ase, codigo_ase, qra_ase, tem_curso_vigilante, curso_vigilante_local, 
            curso_vigilante_cidade, curso_vigilante_uf, curso_vigilante_validade, 
            id_usuario_cadastro, data_cadastro, id_usuario_desativacao, data_desativacao, 
            id_usuario_reativacao, data_reativacao, id_usuario_alteracao, 
            data_alteracao, ativo) 
            (SELECT id, id_tipo_funcionario, cod_controle, null, data_nascimento, nome, nome_mae, nome_pai, 
            cpf, rg, uf_exp_rg, data_exp_rg, cat_cnh_a, cat_cnh_b, cat_cnh_c, cat_cnh_d, cat_cnh_e, 
            numero_registro_cnh, data_validade_cnh, observacao_funcionario, data_admissao, pis_pasep, numero_ctps, serie_ctps, uf_emissao_ctps, 
            logradouro_endereco_funcionario, numero_endereco_funcionario, bairro_endereco_funcionario, cidade_endereco_funcionario, 
            estado_endereco_funcionario, cep_endereco_funcionario, email, telefone_funcionario_1, telefone_funcionario_2, 
            telefone_funcionario_3, telefone_funcionario_4, tipo_contato_1, tipo_contato_2, tipo_contato_3, tipo_contato_4, 
            nome_contato_1, nome_contato_2, nome_contato_3, nome_contato_4, cargo, codigo, qra, 'N', null, null, null, null, 
            id_usuario_cadastro, data_cadastro, id_usuario_desativacao, data_desativacao, id_usuario_reativacao, data_reativacao, null, null, 
            ativo FROM public.funcionarios);


INSERT INTO public.temp_manutencao(
            id_manutencao, data_manutencao, observacao, km_validade_oleo, 
            id_veiculo, id_manutencao_tipo, id_manutencao_local, id_funcionario, 
            id_usuario_cadastro, data_cadastro, motivo_exclusao, id_usuario_exclusao, 
            data_exclusao, km_anterior, km_veiculo, valor_peca, valor_servico, 
            valor_desconto, valor_acrescimo, valor_total, registro_excluido, 
            confirmada) 
            (SELECT id, data_manutencao, obs_manutencao, km_validade_oleo, id_veiculo, id_tipo_manutencao, 
            local_manutencao, id_funcionario, id_usuario_cadastro, data_cadastro, motivo_exclusao, id_usuario_exclusao, data_exclusao, 
            km_anterior, km_veiculo, valor_peca, valor_servico, valor_desconto, valor_acrescimo, valor_total_manutencao, 
            registro_excluido, confirmada FROM public.temp_manutencao_veiculo);





-------------------------- ********************** FIM DAS IMPORTAÇÕES ********************** --------------------------