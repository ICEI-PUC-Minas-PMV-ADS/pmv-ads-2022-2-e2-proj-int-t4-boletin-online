function getCourses() {
    fetch('v1/courses')
        .then(response => response.json())
        .then(data => _displayCourses(data))
        .catch(error => console.error('Erro ao buscar cursos ! ', error));
}

function _displayCourses(data) {
    let list = document.getElementById("courselist");
    let slice = Math.ceil(data.length  / 4)

        for (let i = 0; i < data.length; i = i + slice) {
            const newLi = data.slice(i, i + slice);
            let newUl = document.createElement("ul");
            newUl.setAttribute("class", "primeirafileira")
            newLi.map(course => {
                let li = document.createElement("button");
                newUl.setAttribute("class", "botao1-1")
                li.onclick = () => goStudentList(course.id, course.name);
                li.textContent = `${course.name}`;
                newUl.appendChild(li);
            })
            
            list.appendChild(newUl);
        }
        
}

function goStudentList(id, name) {
    window.location.href = `${window.location.origin}/studentList.html?courseId=${id}&courseName=${name}`;
}