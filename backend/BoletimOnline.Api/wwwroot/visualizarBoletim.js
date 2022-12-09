function getVisualizarBoletim() {
    fetch('api/Atividade/visualizarBoletim?studentId=1&courseId=2')
        .then(response => response.json())
        .then(data => displayVisualizarBoletim(data))
        .catch(error => console.error('Erro ao buscar visualizarBoletim!', error));
}

function displayVisualizarBoletim(data) {
    let table = document.getElementById("tabelaDeNotas");
    let tableBody = document.getElementById("corpoTabelaDeNotas") ;
    let newRow;
    let newCell;

    tableBody.innerHTML = "";

    let disciplinas = data.map((disciplina) => {
        let etapas = []

        etapas.push(disciplina[0].nameDisciplina)

        disciplina.map((etapa) => {
            etapas.push(etapa.note)
        })

        return etapas;
    })

    disciplinas.map(linha => {
        newRow = document.createElement("tr")
        tableBody.appendChild(newRow)

        console.log(linha)


        for (let index = 0; index < 5; index++) {
            newCell = document.createElement("td");
            newCell.textContent = linha[index];
            newRow.appendChild(newCell);
        }

    })


 
}

//{disciplina: 1, media: 7.67 }


//[
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Biologia", "nameCourse": "9° Ano", "stage": 1, "note": 7.67 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Filosofia", "nameCourse": "9° Ano", "stage": 1, "note": 9.67 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Física", "nameCourse": "9° Ano", "stage": 1, "note": 7.33 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Geografia", "nameCourse": "9° Ano", "stage": 1, "note": 7.33 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "História", "nameCourse": "9° Ano", "stage": 1, "note": 7.00 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Inglês", "nameCourse": "9° Ano", "stage": 1, "note": 6.67 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Matemática", "nameCourse": "9° Ano", "stage": 1, "note": 8.00 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Português", "nameCourse": "9° Ano", "stage": 1, "note": 8.00 },
//    { "nameStudent": "Barnabe Carlos", "nameDisciplina": "Química", "nameCourse": "9° Ano", "stage": 1, "note": 7.67 }
//]
