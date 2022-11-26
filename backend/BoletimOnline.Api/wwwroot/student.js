function getStudents() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    console.log(params)
    fetch(`v1/students/course?course=${params.courseId}`)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Erro ao buscar alunos ! ', error));
}

function setCourseDescription() {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}');
    let title = document.getElementById("titlePage");
    console.log(params)
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
        newUl.addEventListener('click', () => goCreateStudentView(student))
        
        
        newUl.setAttribute("class", "nomesalunos")
        list.appendChild(newUl);
    })
}

function goCreateStudent(id, name) {
    window.location.href = `${window.location.origin}/createStudent.html?courseId=${id}&courseName=${name}`;
}

function goCreateStudentView(student) {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}');
    const qs =  new URLSearchParams(student).toString()
    window.location.href = `${window.location.origin}/createStudent.html?courseId=${params.courseId}&courseName=${params.courseName}&${qs}`;
}

    
let search = location.search.substring(1);
const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')

let buttonsearch = document.getElementById("buttonsearch");
buttonsearch.onclick = () => getStudentsByName()

    let buttoncreateStudent = document.getElementById("buttoncreateStudent");
    buttoncreateStudent.onclick = () => goCreateStudent(params.courseId, params.courseName)



