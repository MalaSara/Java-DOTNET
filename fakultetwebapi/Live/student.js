export class Student{

    constructor(id,imestudenta,indeks){
        this.id=id;
        this.imestudenta=imestudenta;
        this.indeks=indeks;
        this.container=null;
        this.listapredmeta=new Array();
    }

    crtajstudenta(host){
        if(!host)
            throw new Error("Nema hosta za tebe");

        let student=document.createElement("div");
        student.className="student";
        this.container=student;

        let labstud=document.createElement("div");
        labstud.innerHTML=this.imestudenta +"//"+this.indeks;
        student.appendChild(labstud);

        let predmeti=document.createElement("div");
        predmeti.className="predmeti";
        this.crtajpredmete(predmeti);

        student.appendChild(predmeti);

        host.appendChild(student);
    }

    crtajpredmete(host){
        
        this.listapredmeta.forEach(predmet => {
            
            const divp=document.createElement("div");
            divp.className="predmetpostoji " +predmet;
            divp.innerHTML=predmet;

            host.appendChild(divp);
        })

    }

    dodajpredmete(predm,oc){
        
        
        this.listapredmeta.push(predm);

        let divgde=this.container.querySelector(".predmeti");

        let div=document.createElement("div");
        div.className="predmet "+predm;
        div.innerHTML=predm;
        const sirina=15*oc;

        console.log(div);
        div.style.width=sirina+"px";
        divgde.appendChild(div);

    }
    
    dodajpredmet(pr){
        this.listapredmeta.push(pr);
    }
}