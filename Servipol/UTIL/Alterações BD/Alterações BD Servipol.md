# Alterações BD Servipol



######  ALTER TABLE public.usuarios RENAME id  TO id_usuario;

######  ALTER TABLE public.veiculos RENAME id  TO id_veiculo;

######  ALTER TABLE public.tipo_manutencao RENAME descricao_manutencao TO descricao;

###### ALTER TABLE public.tipo_manutencao  RENAME TO manutencao_tipo;

###### ALTER TABLE public.local_manutencao  RENAME TO manutencao_local;

###### ALTER TABLE public.manutencao_tipo RENAME id_tipo_manutencao  TO id_manutencao_tipo;

###### ALTER TABLE public.manutencao_local RENAME id_local_manutencao  TO id_manutencao_local;

###### ALTER TABLE public.manutencao_veiculo  RENAME TO manutencao;

###### ALTER TABLE public.manutencao RENAME id  TO id_manutencao;

###### ALTER TABLE public.tipo_veiculo RENAME id  TO id_veiculo_tipo;

###### ALTER TABLE public.tipo_veiculo  RENAME TO veiculo_tipo;

###### ALTER TABLE public.veiculos RENAME tipo_veiculo  TO tipo;

###### ALTER TABLE public.veiculos RENAME codigo_veiculo  TO codigo;

###### ALTER TABLE public.veiculos RENAME descricao_veiculo  TO descricao;

###### ALTER TABLE public.veiculos  RENAME TO veiculo;

###### ALTER TABLE public.tipo_funcionario RENAME id_tipo_funcionario  TO id_funcionario_cargo;

###### ALTER TABLE public.tipo_funcionario RENAME descricao_tipo_funcionario  TO descricao;

###### ALTER TABLE public.tipo_funcionario  RENAME TO funcionario_cargo;

###### ALTER TABLE public.funcionarios RENAME id_tipo_funcionario  TO id_funcionario_cargo;

###### ALTER TABLE public.funcionarios RENAME logradouro_endereco_funcionario  TO logradouro_endereco;

###### ALTER TABLE public.funcionarios RENAME numero_endereco_funcionario  TO numero_endereco;

###### ALTER TABLE public.funcionarios RENAME bairro_endereco_funcionario  TO bairro_endereco;

###### ALTER TABLE public.funcionarios RENAME cidade_endereco_funcionario  TO cidade_endereco;

###### ALTER TABLE public.funcionarios RENAME estado_endereco_funcionario  TO uf_endereco;

###### ALTER TABLE public.funcionarios RENAME telefone_funcionario_1  TO telefone_1;

###### ALTER TABLE public.funcionarios RENAME telefone_funcionario_2  TO telefone_2;

###### ALTER TABLE public.funcionarios RENAME telefone_funcionario_3  TO telefone_3;

###### ALTER TABLE public.funcionarios RENAME observacao_funcionario  TO observacao;

###### ALTER TABLE public.funcionarios RENAME cep_endereco_funcionario  TO cep_endereco;

###### ALTER TABLE public.funcionarios RENAME telefone_funcionario_4  TO telefone_4;

###### ALTER TABLE public.funcionarios RENAME cargo  TO cargo_operacional_externo;

###### ALTER TABLE public.funcionarios RENAME TO funcionario;

###### ALTER TABLE public.funcionario RENAME id  TO id_funcionario;

###### ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_local character varying(255);

###### ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_cidade character varying(255);

###### ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_uf character varying(2);

###### ALTER TABLE public.funcionario  ADD COLUMN curso_vigilante_validade date;
