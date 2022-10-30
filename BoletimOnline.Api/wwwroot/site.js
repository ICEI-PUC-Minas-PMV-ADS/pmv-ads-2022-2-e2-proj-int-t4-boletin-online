const uriStudent = 'v1/students';
const uriCourse = 'v1/courses';
const uriResponsibile = 'v1/responsibiles';
let todos = [];

function getStudents() {
    fetch(uriStudent)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Erro ao buscar alunos ! ', error));
}

function _displayStudents(data) {
    let list = document.getElementById("studentslist");
    let newUl;
    
    data.map(student => {
        newUl = document.createElement("ul");
        newUl.textContent = `${student.name}`;
        newUl.setAttribute("class", "nomesalunos")
        list.appendChild(newUl);
    })
}  