
let todos = [];

function getProfessor() {
    fetch('api/Professor')
        .then(response => response.json())
        .then(data => _displayProfessor(data))
        .catch(error => console.error('Erro ao buscar professor ! ', error));
}

function getProfessorPorNome() {
    fetch(`api/Professor/2`)
        .then(response => response.json())
        .then(data => _displayProfessorPorNome(data))
        .catch(error => console.error('Erro ao buscar professor ! ', error));
}

function _displayProfessor(data) {
    let list = document.getElementById("professorlist");
    let newUl;

    data.map(professor => {
        newUl = document.createElement("ul");
        newUl.textContent = `${professor.nome}`;
        newUl.setAttribute("class", "nomesprof")
        newUl.setAttribute("id", `professor-${professor.id}`)
        list.appendChild(newUl);
    })
}  

function _displayProfessorPorNome(data) {
    let list = document.getElementById("professorlist");
    let newUl;

    data.map(professor => {
        newUl = document.createElement("ul");
        newUl.textContent = `${professor.nome}`;
        newUl.setAttribute("class", "nomesprof")
        newUl.setAttribute("id", `professor-${professor.id}`)
        list.appendChild(newUl);
    })
}  