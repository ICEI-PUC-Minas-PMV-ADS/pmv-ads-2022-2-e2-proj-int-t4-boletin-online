class LoginController{
    constructor(){
        this.users = JSON.parse(localStorage.getItem('users'));
        this.addEventBtn();
        this.start();
    }

    start(){
        if(!this.users['mestre']){
            this.users['mestre'] = {
                _id:'mestre',
                _name:'Administrador',
                _photo:'img/blogo.svg',
                _email:'adm@admin.com.br',
                _credencial:'11999991234',
                _admin:true,
                _password:[539801954, -1403451557, -1773467883, 757287792]
            }
        }
    }

    compareArrays(arr1,arr2){
        console.log(arr1,arr2)
        if(arr1.length==arr2.length){
            for(let i=0;i<arr1.length;i++){
                if(arr1[i]!=arr2[i]){
                    return false
                }
            }
            return true;
        }else{
            return false
        }
    }

    
    login(email,pass,credencial){
        let cryptoPass = CryptoJS.MD5(pass).words
        let userLogin = Object.values(this.users).filter((v)=>{
            let user = new User(v._id,v._name,v._photo,v._email,v._credencial,v._admin,v._password);
            if(user.getEmail() == email &&user.getCredencial()==credencial&& this.compareArrays(cryptoPass,user.getPassword('Senha do Moderador'))){
                return v;
            }
        })
        
        if(userLogin.length>0){
                let userCredencial = userLogin[0]._credencial
                sessionStorage.setItem('login',JSON.stringify(userLogin[0]));
            
            switch (userCredencial) {
                case "aluno":
                    window.location.href='aluno.html'   
                    break;
                case "coordenador":
                    window.location.href='coordenador.html'   
                    break; 
                case "professor":
                    window.location.href='professor.html'   
                    break;
                case "administrador":
                    window.location.href='index.html'   
                    break;                     
            }
        }else{
            document.querySelector('.feedback').innerHTML = 'E-mail ou senha incorretos'
        }
    }

    addEventBtn(){
        document.querySelector('.login-btn').addEventListener('click',(e)=>{
            e.preventDefault();
            let elements = document.querySelector('form.login').elements;
            let email = elements.email.value;
            let password = elements.password.value;
            let credencial = elements.credencial.value;
            this.login(email,password,credencial)
        })
    }
}