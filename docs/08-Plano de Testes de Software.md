# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Estes são os cenários de testes utilizados na realização dos testes da nossa aplicação, que demonstram os requisitos sendo satisfeitos:

 
| **Caso de Teste** 	| **CT-01 – Redefinir Senha** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O site deve permitir ao usuário (exceto aluno) trocar a senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue redefinir a senha. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Clicar em "Esqueci senha" <br> - Confirmar envio de mensagem para a coordenadoria <br> - Aguardar a confirmação sobre a mudança de senha. <br> - Depois de confirmada, a senha será resetada para o cpf do responsável. |
|Critério de Êxito | - A senha foi alterada com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Inserir alunos** 	|
|	Requisito Associado 	| RF-002 - O site deve permitir ao coordenador inserir novos alunos. |
| Objetivo do Teste 	| Verificar se o coordenador consegue inserir novos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão cadastro de alunos <br> - Selecionar a série e a turma que o aluno vai ser cadastrado <br> - Preencher os campos solicitados com os dados do aluno <br> - Clicar em incluir |
|Critério de Êxito | - Aluno adicionado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Inserir professores** 	|
|	Requisito Associado 	| RF-003 - O site deve permitir ao coordenador inserir novos professores nas matérias. |
| Objetivo do Teste 	| Verificar se o coordenador consegue inserir novos professores. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão cadastro de professores <br> - Selecionar a série e a turma que o professor vai ser cadastrado <br> - Preencher os campos solicitados com os dados do professor <br> - Clicar em incluir |
|Critério de Êxito | - Professor adicionado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Lançar e editar notas** 	|
|	Requisito Associado 	| RF-004 - O site deve permitir ao **coordenador** lançar e editar as notas dos alunos. |
| Objetivo do Teste 	| Verificar se o coordenador consegue lançar e editar as notas dos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como coordenador <br> - Clicar no botão lançar notas de alunos <br> - Selecionar o ano e a turma <br> - Selecionar a matéria e a etapa (bimestre) <br> - Selecionar o aluno <br> - Selecionar a avaliação e lançar ou editar a nota <br> - Salvar |
|Critério de Êxito | - Nota incluída com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Lançar e editar notas** 	|
|	Requisito Associado 	| RF-005 - O site deve permitir ao **professor** lançar e editar as notas dos alunos nas matérias em que estiver cadastrado. |
| Objetivo do Teste 	| Verificar se o professor consegue lançar e editar as notas dos alunos. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como professor <br> - Clicar no botão lançar notas de alunos <br> - Selecionar o ano e a turma <br> - Selecionar a matéria e a etapa (bimestre) <br> - Selecionar o aluno <br> - Selecionar a avaliação e lançar ou editar a nota <br> - Salvar |
|Critério de Êxito | - Nota incluída com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Visualizar notas** 	|
|	Requisito Associado 	| RF-006 - O site deve permitir ao **aluno** visualizar as notas por matéria. |
| Objetivo do Teste 	| Verificar se o aluno consegue visualizar as notas por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como aluno <br> - Entrar na página principal <br> - Visualizar as notas |
|Critério de Êxito | - Visualização realizada com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Visualizar notas** 	|
|	Requisito Associado 	| RF-007 - O site deve permitir ao **responsável** visualizar as notas por matéria. |
| Objetivo do Teste 	| Verificar se o responsável consegue visualizar as notas por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como responsável <br> - Entrar na página principal <br> - Visualizar as notas |
|Critério de Êxito | - Visualização realizada com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Visualizar situação final do aluno** 	|
|	Requisito Associado 	| RF-008 - Os valores de nota atribuídos em cada etapa não podem ser superiores a 10. Ao final das quatro etapas um aluno só pode obter até 40 pontos. Se possuir 28 pontos ou mais, será aprovado. Se possuir menos que 28 pontos, estará em recuperação. Na recuperação 5 pontos ou mais, aprovado, do contrário, reprovado. |
| Objetivo do Teste 	| Verificar se o **aluno** consegue visualizar a situação final (Aprovado, Recuperação ou Reprovado) por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como aluno <br> - Entrar na página principal <br> - Visualizar situação final nas matérias |
|Critério de Êxito | - Visualização realizada com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Visualizar situação final do aluno** 	|
|	Requisito Associado 	| RF-008 - Os valores de nota atribuídos em cada etapa não podem ser superiores a 10. Ao final das quatro etapas um aluno só pode obter até 40 pontos. Se possuir 28 pontos ou mais, será aprovado. Se possuir menos que 28 pontos, estará em recuperação. Na recuperação 5 pontos ou mais, aprovado, do contrário, reprovado. |
| Objetivo do Teste 	| Verificar se o **responsável** consegue visualizar a situação final do aluno (Aprovado, Recuperação ou Reprovado) por matéria. |
| Passos 	| - Acessar o site https://botetim-escolar-exemplo.com/src/index.html <br> - Realizar o login como responsável <br> - Entrar na página principal <br> - Visualizar situação final nas matérias |
|Critério de Êxito | - Visualização realizada com sucesso. |
|  	|  	|



 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
