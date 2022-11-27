
async function salvar() {
  let response = await fetch('https://localhost:7196/api/Notas', {
    method: 'POST', // *GET, POST, PUT, DELETE, etc.
    mode: 'no-cors', 
    headers: {'Content-Type': 'application/json'},
  }); 
  
  const tabelaBody =document.getElementById("tabelaNotaBody")
  const tr = document.createElement('tr')
  tr.innerHTML=`                        <td>ANA BEATRIZ SILVEIRA</td>
                        <td><input type="number"></td>
                        <td><input type="number"></td>
                        <td><input type="number"></td>
                        <td><input type="number"></td>
`
tabelaBody.append(tr)
    console.log(response)
    console.log(JSON.stringify(response.data))
 // return response.json(); 

}


async function carregaTela(){
  
  

var xhttp = new XMLHttpRequest();
xhttp.open("GET", 'https://localhost:7196/api/Notas', false);
xhttp.send();
let v = xhttp.responseText;
v =JSON.parse(v)
console.log(v);
gerandoTabela(v)
}

function gerandoTabela(v){
  const tabelaBody =document.getElementById("tabelaNotaBody")
  tabelaBody.innerHTML=''
for(let i= 0; i<v.length;i++){
  
  
  const tr = document.createElement('tr')
  tr.innerHTML=`                        <td>${v[i].id_nota}</td>
                        <td><input type="number"></td>
                        <td><input type="number"></td>
                        <td><input type="number"></td>
                        <td><input type="number" value = "${v[i].vl_nota}"></td>
`
tabelaBody.append(tr)


}
}
