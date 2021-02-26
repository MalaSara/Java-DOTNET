export class Fakultet{

    constructor(id,imefakulteta,lokacija){
        this.id=id;
        this.imefakulteta=imefakulteta;
        this.lokacija=lokacija;
        this.container=null;
        this.listastudenta=new Array();
    }

    dodajstudenta(st){
        this.listastudenta.push(st);
    }

    crtajformu(host){
        if(!host)
            throw new Error("Nema hosta");

        let forma=document.createElement("div");
        forma.className="forma";

        let div=document.createElement("div");
        div.className="div";

        let labime=document.createElement("label");
        labime.innerHTML=this.imefakulteta+"//"+this.lokacija;
        div.appendChild(labime);
        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";

        let selstudenti=document.createElement("select");
        selstudenti.className="selstudenti";
        for(let i=0;i<this.listastudenta.length;i++)
        {
            selstudenti.options.add(new Option(this.listastudenta[i].imestudenta,i));
        }
        div.appendChild(selstudenti);

        let labelast=document.createElement("label");
        labelast.innerHTML="Izaberi studenta";
        div.appendChild(labelast);
        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";

        let divrb;
        const predmeti=["elektronika","web","mreze","miks"];
        for(let i=0;i<predmeti.length;i++){
            divrb=document.createElement("div");

            let rb=document.createElement("input");
            rb.type="radio";
            rb.name="radio";
            rb.value=predmeti[i];
            divrb.appendChild(rb);

            let labelrb=document.createElement("label");
            labelrb.innerHTML=predmeti[i];
            divrb.appendChild(labelrb);
            
            div.appendChild(divrb);
        }
        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";

        let ocena=document.createElement("input");
        ocena.type="number";
        ocena.className="broj";
        ocena.min="6";
        ocena.max="10";
        div.appendChild(ocena);

        let labocena=document.createElement("label");
        labocena.innerHTML="Ocena";
        div.appendChild(labocena);
        forma.appendChild(div);
        
        let dugme=document.createElement("button");
        dugme.className="dugme";
        dugme.innerHTML="Dodaj predmet sa ocenom";
        dugme.addEventListener("click",e=>{


            let stud=selstudenti.options[selstudenti.selectedIndex].value;
           

            let predm=document.querySelectorAll('input[type="radio"]:checked')[0].value;

            let oc=ocena.value;

            fetch("https://localhost:5001/DodajPredmet/"+ stud+"/"+predm,{
                method:"PUT"
            }).then(p=>{
                if(p.ok){
                    
                    this.listastudenta[stud].dodajpredmete(predm,oc);

                }

            });

            //this.listastudenta[stud].dodajpredmete(predm,oc);
        
        });

        forma.appendChild(dugme);
        host.appendChild(forma);
    }


    crtajstudente(host){

        let div=document.createElement("div");
        div.className="studenti";
        for(let i=0;i<this.listastudenta.length;i++){
            this.listastudenta[i].crtajstudenta(div);
            
        }

        host.appendChild(div);

    }

    
    crtaj(host){
        if(!host)
            throw new Error("Greska, host ne postoji");

        this.container=document.createElement("div");
        this.container.className="sve";

        this.crtajstudente(this.container);
        this.crtajformu(this.container);
        
        host.appendChild(this.container);

    }
}