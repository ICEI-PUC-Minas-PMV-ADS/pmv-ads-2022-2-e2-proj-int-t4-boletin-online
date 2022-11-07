# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Estes são os cenários de testes utilizados na realização dos testes da nossa aplicação, que demonstram os requisitos sendo satisfeitos:

 

| **Caso de Teste** 	| **CT-01 – Inserir alunos** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O site deve permitir ao coordenador inserir novos alunos. |
| Objetivo do Teste 	| Verificar se o coordenador consegue inserir novos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão cadastro de alunos <br> - Selecionar a série e a turma que o aluno vai ser cadastrado <br> - Preencher os campos solicitados com os dados do aluno <br> - Clicar em incluir |
|Critério de Êxito | - Aluno adicionado com sucesso. |
|Dados de Entrada | - Login de coordenador: admin; senha: admin. <br> - Selecionar a turma: 5º ano B. <br> - Dados para cadastro do aluno: Nome = João da Silva; CPF = 00100000111; Data de Nascimento = 01/01/2012; Número Matrícula = 001; Sexo = Masculino; Curso = Fundamental; Nome Responsável = José da Silva; CPF = 11100010110; Email = josedasilva@gmail.com; Login = 887562; Senha = 00100000111.|
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Inserir professores** 	|
|	Requisito Associado 	| RF-002 - O site deve permitir ao coordenador inserir novos professores nas matérias. |
| Objetivo do Teste 	| Verificar se o coordenador consegue inserir novos professores. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão cadastro de professores <br> - Selecionar a série e a turma que o professor vai ser cadastrado <br> - Preencher os campos solicitados com os dados do professor <br> - Clicar em incluir |
|Critério de Êxito | - Professor adicionado com sucesso. |
|Dados de Entrada | - Login de coordenador: admin; senha: admin. <br> - Selecionar a turma: 5º ano B. <br> - Dados para cadastro do professor: Nome = Juliana Souza; CPF = 10100123422; Data de Nascimento = 05/02/1994; Disciplinas = Matemática; Turmas = 5º ano A e 5º ano B; Sexo = Feminino; Email = julianasouza0@gmail.com; Login = 96752219; Senha = 10100123422. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Lançar e editar notas** 	|
|	Requisito Associado 	| RF-003 - O site deve permitir ao **coordenador** lançar e editar as notas dos alunos. |
| Objetivo do Teste 	| Verificar se o coordenador consegue lançar e editar as notas dos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão lançar notas de alunos <br> - Selecionar o ano e a turma <br> - Selecionar a matéria e a etapa (bimestre) <br> - Selecionar o aluno <br> - Selecionar a avaliação e lançar ou editar a nota <br> - Salvar |
|Critério de Êxito | - Nota incluída com sucesso. |
|Dados de Entrada | - Login de coordenador: admin; senha: admin. <br> - Selecionar a turma: 5º ano B.<br> - Selecionar a matéria Matemática e a 1º Etapa; <br> - Selecionar o Aluno: João da Silva. <br> - Adicionar nota 7 no Trabalho. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Lançar e editar notas** 	|
|	Requisito Associado 	| RF-004 - O site deve permitir ao **professor** lançar e editar as notas dos alunos nas matérias em que estiver cadastrado. |
| Objetivo do Teste 	| Verificar se o professor consegue lançar e editar as notas dos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como professor <br> - Clicar no botão lançar notas de alunos <br> - Selecionar o ano e a turma <br> - Selecionar a matéria e a etapa (bimestre) <br> - Selecionar o aluno <br> - Selecionar a avaliação e lançar ou editar a nota <br> - Salvar |
|Critério de Êxito | - Nota incluída com sucesso. |
|Dados de Entrada | - Login de professor: 96752219; Senha: 10100123422. <br> - Selecionar a turma: 5º ano B. <br> - Selecionar a matéria Matemática e a 1º Etapa; <br> - Selecionar o Aluno: João da Silva. <br> - Adicionar nota 5 nas Atividades. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Visualizar notas** 	|
|	Requisito Associado 	| RF-005 - O site deve permitir ao aluno e responsável visualizar as notas por matéria. |
| Objetivo do Teste 	| Verificar se o aluno e responsável consegue visualizar as notas por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como aluno/responsavel <br> - Entrar na página principal <br> - Visualizar as notas |
|Critério de Êxito | - Visualização realizada com sucesso. |
|Dados de Entrada | - Login de aluno/responsável: 887562; Senha = 00100000111. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Visualizar situação final do aluno** 	|
|	Requisito Associado 	| RF-006 - Os valores de nota atribuídos em cada etapa não podem ser superiores a 10. Ao final das quatro etapas um aluno só pode obter até 40 pontos. Se possuir 28 pontos ou mais, será aprovado. Se possuir menos que 28 pontos, estará em recuperação. Na recuperação 5 pontos ou mais, aprovado, do contrário, reprovado. |
| Objetivo do Teste 	| Verificar se o aluno e o responsável consegue visualizar a situação final (Aprovado, Recuperação ou Reprovado) por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como aluno/responsável <br> - Entrar na página principal <br> - Visualizar situação final nas matérias |
|Critério de Êxito | - Visualização realizada com sucesso. |
|Dados de Entrada | - Login de aluno/responsável: 887562; Senha = 00100000111.|
|  	|  	|


