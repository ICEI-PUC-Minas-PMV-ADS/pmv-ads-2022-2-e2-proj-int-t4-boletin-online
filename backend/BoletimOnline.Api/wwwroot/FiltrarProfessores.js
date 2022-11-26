const Input_Busca = document.getElementById('PesquisarProfessor');
const Lista_Professores = document.getElementById('ListarProfesores')

Input_Busca.addEventListener('keyup', () => {
    let expressao = Input_Busca.Value.toLowerCase();
    
    let linhas = Lista_Professores.getElementsByTagName('ol');

    for (let posicao in linhas){
        if (true === isNan(posicao)) {
            continue;
        }

        let conteudoDaLinha = linhas[posicao].innerHTML.toLocaleLowerCase;
        
        if (true === conteudoDaLinha.includes(expressao)){
            linhas[posicao].style.display = '';
        } else{
            linhas[posicao].style.display = 'none';
        }
    }
});