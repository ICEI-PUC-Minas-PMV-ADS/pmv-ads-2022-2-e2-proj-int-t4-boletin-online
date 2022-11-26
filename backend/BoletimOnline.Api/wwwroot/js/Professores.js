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

function goeditarProfessor(professor) {

    const qs = new URLSearchParams(professor).toString()
    window.location.href = `${window.location.origin}/CadastrarProfessor.html?${qs}`;
}

function gocriarProfessor(professor) {

    const qs = new URLSearchParams(professor).toString()
    window.location.href = `${window.location.origin}/CadastrarProfessor.html?${qs}`;
}

let botaoCriarProfessor = document.getElementById("botaoCriarProfessor");
botaoCriarProfessor.onclick = () => goCriarProfessor()


function goCreateStudent(id) {
    window.location.href = `${window.location.origin}/createStudent.html?courseId=200`;
}


function goCriarProfessor() {
    window.location.href = `${window.location.origin}/CadastrarProfessor.html`;
}



        