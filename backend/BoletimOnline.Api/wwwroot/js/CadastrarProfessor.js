document.getElementById("clicksave").onclick = async () => {
    let elements = document.getElementsByName("inputFormProfessor")
    let data = {}
    for (const element of elements) data[`${element.id}`] = element.value
    await criarProfessor(data)
}

function goListarProfessor() {
    let elements = document.getElementsByName("inputFormProfessor")
    for (const element of elements) element.value = ''
    window.history.back()
}

let buttoncancel = document.getElementById("buttoncancel");
buttoncancel.onclick = () => goListarProfessor()


const criarProfessor = async (data) => {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}')

    const headers = { 'Accept': 'application/json', 'Content-Type': 'application/json' }

    const professor = {
        id: 0,
        idResponsibile: data.id,
        enrollment: 1,
        name: data.name,
        idCourse: params.courseId,
        gender: data.gender,
    }

    const professorParams = { method: 'POST', headers: headers, body: JSON.stringify(professor) }
    const newProfessor = await fetch(`v1/students/`, professorParams).then(response => response.json());

    if (newProfessor.id !== 0 && newProfessor.id !== undefined && newProfessor.id !== null) {
        let elements = document.getElementsByName("inputFormStudent")
        for (const element of elements) element.value = ''
        alert(`Professor cadastrado com sucesso!`);
    }

}
