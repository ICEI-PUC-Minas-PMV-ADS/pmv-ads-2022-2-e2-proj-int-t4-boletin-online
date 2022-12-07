function post(url,body){
    console.log("Body=", body)
    let request = new XMLHttpRequest()
    request.open("POST",url,true)
    request.setRequestHeader("Content-type","application/json")
    request.send(JSON.stringify(body))
    request.onload=function(){
        console.log(this.responseText)
    }
    return request.responseText
   
   
}

function LancandoNota(){
    event.preventDefault()
   let url='https://localhost:7196/api/Notas'
   let idAluno= document.createElement=('td')
   let avalX= document.createElement=('td')
   let avaY= document.createElement=('td')
   let trabalho= document.createElement=('td')
   let atividades= document.createElement=('td')
   let total= document.createElement=('td')
}