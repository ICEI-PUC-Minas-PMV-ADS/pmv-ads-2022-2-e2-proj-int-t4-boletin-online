function getProfessores()
{
    fetch('api/Professores')
        .then(response => response.json())
        .then(data => displayProfessores(data))
        .catch(error => console.error('Erro ao buscar professores!', error));
}

function displayProfessores(data)

{
    let list = document.getElementById("ListarProfessores");
    let newul;
    while (list.lastElementChild) {
        list.removeChild(list.lastElementChild);
    }
    data.map(professor => {
        newul = document.createElement("ul");
        newul.setAttribute("class", "dadosProfessor")
        newul.textContent = `${professor.id} Nome: ${professor.nome} - CPF: ${professor.cpf}`;
        newul.addEventListener('click', () => goeditarProfessor(professor));
        list.appendChild(newul);

    })
}

<<<<<<< Updated upstream
function goCriarProfessor() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}');
    console.log()
    window.location.href = `${window.location.origin}/CadastrarProfessor.html?disciplinaId=${params.disciplinaId}&disciplinaNome=${params.disciplinaId}`;
=======
function goeditarProfessor(professor) {

    const qs = new URLSearchParams(professor).toString()
    window.location.href = `${window.location.origin}/02 - CadastrarProfessor.html?${qs}`;
}

function gocriarProfessor(professor) {

    const qs = new URLSearchParams(professor).toString()
    window.location.href = `${window.location.origin}/02 - CadastrarProfessor.html?${qs}`;
>>>>>>> Stashed changes
}

let botaoCriarProfessor = document.getElementById("botaoCriarProfessor");
botaoCriarProfessor.onclick = () => goCriarProfessor()


function goeditarProfessor(professor) {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}');
    const qs = new URLSearchParams(professor).toString().split("+").join("%20");
    window.location.href = `${window.location.origin}/CadastrarProfessor.html?disciplinaId=${params.disciplinaId}&disciplinaNome=${params.disciplinaId}&${qs}`;
}
