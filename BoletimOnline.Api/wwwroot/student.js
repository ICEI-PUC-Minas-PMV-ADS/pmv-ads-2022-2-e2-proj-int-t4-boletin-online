function getStudents() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    fetch(`v1/students/course?course=${params.courseId}`)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Erro ao buscar alunos ! ', error));
}

function setCourseDescription() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}');
    let title = document.getElementById("titlePage");
    console.log(params.courseName)
    title.textContent = `ALUNOS ${params.courseName}`;
}

function getStudentsByName() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    let searchEl = document.getElementById('searchStudentByName');
    if(searchEl.value == "" || searchEl.value == undefined || searchEl.value == null) {
        fetch(`v1/students/course?course=${params.courseId}`)
            .then(response => response.json())
            .then(data => _displayStudents(data))
            .catch(error => console.error('Erro ao buscar alunos ! ', error));
    } else {
        fetch(`v1/students/search?name=${searchEl.value}&course=${params.courseId}`)
            .then(response => response.json())
            .then(data => _displayStudents(data))
            .catch(error => console.error('Erro ao buscar alunos ! ', error));    
    }
}

function _displayStudents(data) {
    let list = document.getElementById("studentslist");
    let newUl;
    while (list.lastElementChild) {
        list.removeChild(list.lastElementChild);
    }
    data.map(student => {
        newUl = document.createElement("ul");
        newUl.textContent = `${student.name}`;
        newUl.setAttribute("class", "nomesalunos")
        list.appendChild(newUl);
    })
}

function goCreateStudent(id) {
    window.location.href = `${window.location.origin}/createStudent.html?courseId=${id}`;
}

let search = location.search.substring(1);
const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')

let buttonsearch = document.getElementById("buttonsearch");
buttonsearch.onclick = () => getStudentsByName()

let buttoncreateStudent = document.getElementById("buttoncreateStudent");
buttoncreateStudent.onclick = () => goCreateStudent(params.courseId)

