document.getElementById("clicksave").onclick = async () => {
    let elements = document.getElementsByName("inputFormStudent")
    let data = {}
    for (const element of elements) data[`${element.id}`] = element.value
    await createStudentAndResponsibile(data)
}

 const createStudentAndResponsibile = async (data) => {
     let search = location.search.substring(1);
     const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    
     const headers = {'Accept': 'application/json', 'Content-Type': 'application/json'}

    const responsibile = {
        id: 0,
        name: data.responsibile,
        cpf: data.cpfresponsavel,
        email: data.email
    }

    const responsibileParams = { method: 'POST', headers: headers, body: JSON.stringify(responsibile) }
    const newresponsibile = await fetch('v1/responsibiles/', responsibileParams).then(response => response.json())


    const student = {
        id: 0,
        idResponsibile: newresponsibile.id,
        enrollment: 1,
        name: data.name,
        idCourse: params.courseId,
    }
    
    const studentParams = { method: 'POST', headers: headers, body: JSON.stringify(student) }
    const newStudent = await fetch(`v1/students/`, studentParams).then(response => response.json());
     alert(`Aluno cadastrado com sucesso! Matrícula: ${newStudent.id}`);
}