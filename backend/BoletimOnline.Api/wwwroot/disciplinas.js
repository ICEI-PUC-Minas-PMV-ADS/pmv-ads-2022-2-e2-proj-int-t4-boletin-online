function getDisciplinas() {
    fetch('api/Disciplinas')
        .then(response => response.json())
        .then(data => displayDisciplinas(data))
        .catch(error => console.error('Erro ao buscar disciplinas ! ', error));
}

function displayDisciplinas(data) {
    let list = document.getElementById("listaDeDisciplina");
    let slice = Math.ceil(data.length  / 4)

        for (let i = 0; i < data.length; i = i + slice) {
            const newLi = data.slice(i, i + slice);
            let newUl = document.createElement("ul");
            newUl.setAttribute("class", "primeirafileira")
            newLi.map(disciplina => {
                let li = document.createElement("button");
                newUl.setAttribute("class", "botao1-1")
                li.onclick = () => goListarProfessores(disciplina.id, disciplina.nome);
                li.textContent = `${disciplina.nome}`;
                newUl.appendChild(li);
            })
            
            list.appendChild(newUl);
        }
        
}

function goListarProfessores(id, nome) {
    window.location.href = `${window.location.origin}/01a - ListarProfessores.html?disciplinaId=${id}&disciplinaNome=${nome}`;
}