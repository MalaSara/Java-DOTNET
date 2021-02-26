import { Silos } from "./silos.js";
export class Fabrika{

    constructor(id,naziv){
        this.id=id;
        this.listasilosa=new Array();
        this.naziv=naziv;
        this.container=null;
    }

    dodajSilos(silos){
        this.listasilosa.push(silos);
    }

    crtajFormu(host){
        if(!host)
            throw new Error("Nema hosta");

        let forma=document.createElement("div");
        forma.className="forma";
        let div=document.createElement("div");
        div.className="div";

        let labela=document.createElement("label");
        labela.innerHTML="Silos:";
        labela.className="labela";
        div.appendChild(labela);

        let selectsilos=document.createElement("select");
        for(var i=0;i<this.listasilosa.length;i++){
            selectsilos.options.add(new Option(i,i));
        }
        selectsilos.className="selectsilos";
        div.appendChild(selectsilos);
        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";

        labela=document.createElement("label");
        labela.innerHTML="Kapacitet:";
        labela.className="labela";
        div.appendChild(labela);

        let kapacitet=document.createElement("input");
        kapacitet.type="number";
        kapacitet.className="kapacitet";
        div.appendChild(kapacitet);
        forma.appendChild(div);

        let dugme=document.createElement("button");
        dugme.innerHTML="Dodaj";
        dugme.className="dugmeclass";
        dugme.addEventListener("click",e=>{
            
            let a=selectsilos.options[selectsilos.selectedIndex].text;
            
            let k=kapacitet.value;
            
            //this.listasilosa[a].dadajkapacitete(k);
           // DodajKapacitet/{id:int}/{kapacitet}

           fetch("https://localhost:5001/DodajKapacitet"+this.listasilosa[a].id+"/"+k,
           {
            method:"POST",
            headers:{
                "Content-Type":"text/plain",
                "Content-Lemgth":k.length
            },
            body:k
           }).then(p=>{
               if(p.ok){
                this.listasilosa[a].dadajkapacitete(k);
               }
           })

        });


        forma.appendChild(dugme);
        host.appendChild(forma);
    }

    crtaj(host){
        if(!host)
            throw new Error("Nema hosta");

        this.container=document.createElement("div");
        this.container.className="sve";
        this.crtajFormu(this.container);
        this.crtajsilose(this.container);
        
        host.appendChild(this.container);

    }

    crtajsilose(host){
        let div=document.createElement("div");
        div.className="silosi";


        for(let i=0;i<this.listasilosa.length;i++){


            this.listasilosa[i].crtajsilos(div,i,);
        }
        host.appendChild(div);
    }
}