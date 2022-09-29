# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

1 - Antônio Geraldo tem 35 anos, é professor e funcionário de uma escola de ensino fundamental.  Gosta de ser organizado e manter as informações que necessita para o trabalho em seu computador.  

2 - Pedro Lopes tem 16 anos, é estudante, e está no primeiro ano do ensino médio. Gosta muito de tecnologia e adora jogos de video game.

3 - Ana Maria tem 40 anos, é dona de casa e mãe de dois filhos, um de 17 anos e um de 13 anos. Gosta de acompanhar o desempenho de seus filhos na escola, e sempre os encoraja a estudarem mais.

4 - Marta dos Santos tem 38 anos, é coordenadora de uma escola de ensino fundamental e médio. Busca uma maneira de facilitar o seu trabalho e dos professores.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Antonio Geraldo  | Fazer o lançamento das notas dos alunos de uma maneira mais prática e rápida          | Para otimizar o meu trabalho e meu tempo               |
|Antonio Geraldo      | Consultar as notas dos alunos a qualquer momento de uma maneira simples e rápida                | Para conseguir as informações necessárias o mais rápido e simples possível |
|Pedro Lopes      | Consultar as minhas notas a qualquer momento e em qualquer lugar              | Para poder estudar e melhorar meu desempenho em matérias específicas |
|Ana Maria      | Consultar as notas dos meus filhos a qualquer momento e em qualquer lugar              | Para poder saber o desempenho deles na escolas |
|Marta dos Santos    | Consultar notas dos alunos de maneira prática e rápida             | Para poder tomar devidas atitudes perante os pais dos alunos  |



## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O site deve permitir ao usuário (exceto aluno) trocar a senha | MÉDIA |
|RF-002| O site deve permitir ao coordenador inserir novos alunos | ALTA |
|RF-003| O site deve permitir ao coordenador inserir novos professores nas matérias | ALTA |
|RF-004| O site deve permitir ao coordenador lançar e editar as notas dos alunos | ALTA |
|RF-005| O site deve permitir ao professor lançar e editar as notas dos alunos nas matérias em que estiver cadastrado | ALTA |
|RF-006| O site deve permitir ao aluno visualizar as notas por matéria | ALTA |
|RF-007| O site deve permitir ao responsavel visualizar as notas por matéria | ALTA |
|RF-008| Os valores de nota atribuídos em cada etapa não podem ser superiores a 10. Ao final das quatro etapas um aluno só pode obter até 40 pontos. Se possuir 28 pontos ou mais, será aprovado. Se possuir menos que 28 pontos, estará em recuperação. Na recuperação 5 pontos ou mais, aprovado, do contrário, reprovado | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O site deve ser publicado em um ambiente acessível publicamente na Internet (Repl.it, GitHub Pages, Heroku); | ALTA | 
|RNF-002|O site deverá ser responsivo permitindo a visualização em um celular de forma adequada |  ALTA | 
|RNF-003|O site deve ter bom nível de contraste entre os elementos da tela em conformidade  |  MÉDIA | 
|RNF-004|O site deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) |  ALTA | 
|RNF-005|O sistema deverá se comunicar com o banco SQL server |  ALTA | 
|RNF-006|O sistema deverá ser implementado na linguagem C#, linguagem HTML, CSS e JavaScript |  ALTA | 
|RNF-007|O sistema só pode ser acessado por professores ou  coordenadores ligados à escola. |  ALTA | 
|RNF-008|O site deve apresentar na página principal o login com seletor de usuário: coordenador, professor e aluno/responsável |  ALTA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser conduzido com os direcionamentos do professor orientador. |
|02| A equipe terá reuniões com o professor orientador às segundas-feiras às  19:30 horas.      |
|03| O projeto deverá estar em conformidade com o escopo disponibilizado pela PUC Minas. |
|04| O prazo para entrega final do projeto é 11/12/2022        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![diagrama de casos de uso](https://user-images.githubusercontent.com/103431797/193059842-c2e17fc4-5cc0-457d-9b83-ea365ad60ab2.jpeg)

