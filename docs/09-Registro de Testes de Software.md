# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

| **Caso de Teste** 	| **CT-01 – Inserir aluno** 	|
|:---:	|:---:	|
|	Pré-condições 	| Estar na tela cadastrar aluno logado com o perfil coordenador. |
| Procedimento  	| 1) O ator preenche todos os campos e o campo cpf com 11 dígitos. <br> 2) O ator seleciona Salvar <br> 3) O sistema verifica se os campos foram preenchidos corretamente <br> 4) O sistema exibe a mensagem "Erro no CPF"
| Resultado esperado| Mensagem de erro do sistema |
![WhatsApp Image 2022-11-27 at 22 16 51](https://user-images.githubusercontent.com/103431797/204179377-3bb7eb3c-f09a-4a9b-b661-13294a765406.jpeg)

| **Caso de Teste** 	| **CT-02 – Inserir Professor** 	|
|:---:	|:---:	|
|	Pré-condições 	| Estar na tela cadastrar professor logado com o perfil coordenador. |
| Procedimento  	| 1) O ator não preenche todos os campos solicitados. <br> 2) O ator seleciona Salvar <br> 3) O sistema verifica se os campos foram preenchidos corretamente <br> 4) O sistema exibe a mensagem "Professor não cadastrado"
| Resultado esperado| Mensagem de erro do sistema |
![WhatsApp Image 2022-11-27 at 22 15 11](https://user-images.githubusercontent.com/103431797/204179583-3bfde308-43dc-41c8-8bbf-48fd5a425d8a.jpeg)

| **Caso de Teste** 	| **CT-03 – Login** 	|
|:---:	|:---:	|
|	Pré-condições 	| Estar na tela de login. |
| Procedimento  	| 1) O ator não preenche todos os campos solicitados. <br> 2) O ator seleciona Entrar <br> 3) O sistema verifica se os campos foram preenchidos corretamente <br> 4) O sistema exibe a mensagem "Falha no login"
| Resultado esperado| Mensagem de erro do sistema |
![WhatsApp Image 2022-11-27 at 22 17 38](https://user-images.githubusercontent.com/103431797/204179587-40ea8dbf-7f15-457b-9966-71fcbcbacb8c.jpeg)




