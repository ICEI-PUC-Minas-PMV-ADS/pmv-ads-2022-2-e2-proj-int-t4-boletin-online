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
        cpf: data.cpf,
        email: data.email,
        login: data.login,
        password: data.password
    }
     

    const responsibileParams = { method: 'POST', headers: headers, body: JSON.stringify(responsibile) }
    const newresponsibile = await fetch('v1/responsibiles/', responsibileParams).then(response => response.json())


    const student = {
        id: 0,
        idResponsibile: newresponsibile.id,
        enrollment: 1,
        name: data.name,
        idCourse: params.courseId,
        gender: data.gender,
    }
    
    const studentParams = { method: 'POST', headers: headers, body: JSON.stringify(student) }
    const newStudent = await fetch(`v1/students/`, studentParams).then(response => response.json());
     
     if(newStudent.id !== 0 && newStudent.id !== undefined && newStudent.id !== null) {
         let elements = document.getElementsByName("inputFormStudent")
         for (const element of elements) element.value = ''
         alert(`Aluno cadastrado com sucesso! Matrícula: ${newStudent.id}`);         
     }

    
    
}

function goStudentList() {
    let elements = document.getElementsByName("inputFormStudent")
    for (const element of elements) element.value = ''
    window.history.back()
}

    let buttoncancel = document.getElementById("buttoncancel");
    buttoncancel.onclick = () => goStudentList()


const StudentView = async () => {
    let search = location.search.substring(1);
    const params = JSON.parse('{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}')
    if(params.id !== 0 && params.id !== undefined && params.id !== null) {
        const response = await fetch(`v1/responsibiles/${params.idResponsibile}`).then(response => response.json())
        
        const responsibile = {
            idResponsibile: response.id,
            responsibile: response.name,
            cpf: response.cpf,
            email: response.email,
            login: response.login,
            password: response.password
        }

        const student = {
            enrollment: params.id,
            name: params.name,
            idCourse: params.courseId,
            course: params.courseName,
            gender: params.gender
        }

        let merge = {...responsibile, ...student};
        let elements = document.getElementsByName("inputFormStudent")
        for (const element of elements) {
            element.value = merge[element.id] || ""
            element.disabled = true
        }
            
            
    }

    let elements = document.getElementsByName("inputFormStudent")
    for (const element of elements) {
        if (element.id == "enrollment") element.disabled = true
        if (element.id == "course") {
            element.disabled = true
            element.value = params.courseName
        } 
        
    }
        
       
}

StudentView()

function editStudentEnable() {
    let elements = document.getElementsByName("inputFormStudent")
    for (const element of elements) element.disabled = false
}


let buttoneditStudent = document.getElementById("buttonedit");
buttoneditStudent.onclick = () => editStudentEnable()
