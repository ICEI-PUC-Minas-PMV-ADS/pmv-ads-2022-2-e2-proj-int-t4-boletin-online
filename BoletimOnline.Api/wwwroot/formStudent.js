let buttonsaveRecord = document.getElementById("clicksave");
buttonsaveRecord.onclick = () => {
    let elements = document.getElementsByName("inputFormStudent")
    let student = {}
    
    for (const element of elements) {
        student[`${element.id}`] = element.value
    }
    
    console.log(student)
    createNewStudent(student)
}

function createNewStudent(student) {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    console.log(params)
    fetch(`v1/students/`,
        {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(student)
        })
        .then(response => response.json())
        // .then(data => _displayStudents(data))
        .then(data => console.log(data))
        .catch(error => console.error('Erro ao buscar alunos ! ', error));
    }