export class Frizerskisalon{

    constructor(id,imesalona,lokacija){
        this.id=id;
        this.imesalona=imesalona;
        this.lokacija=lokacija;
        this.container=null;
        this.listaradnika=new Array();
    }

    dodajradnika(rad){
        this.listaradnika.push(rad);
    }

    crtaj(host){
        if(!host)
            throw new Error("Nema hosta");

        this.container=document.createElement("div");
        this.container.className="sve";

        this.crtajformu(this.container);
        this.crtajradnike(this.container);

        host.appendChild(this.container);
    }
    crtajformu(host){

        let forma=document.createElement("div");
        forma.className="forma";

        let labime=document.createElement("label");
        labime.innerHTML=this.imesalona+ "=" +this.lokacija;
        forma.appendChild(labime);


        let div=document.createElement("div");
        div.className="div";



        let labradnici=document.createElement("label");
        labradnici.innerHTML="Izaberi radnika";
        div.appendChild(labradnici);
        
        let selradnici=document.createElement("select");
        for(let i=0;i<this.listaradnika.length;i++){
            selradnici.options.add(new Option(this.listaradnika[i].imeradnik,i));
        }
        
        div.appendChild(selradnici);
        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";
        let s;
        let slike=["https://image.shutterstock.com/image-vector/beautiful-hairdresser-working-drying-combing-260nw-287143958.jpg", "//image.freepik.com/free-vector/attractive-happy-girl-hairdresser-with-comb-hair-dryer-portrait-isolated-white-background-vector-illustration_1284-2390.jpg"]
        for(let i=0;i<slike.length;i++){
            s=document.createElement("img");
            s.src=slike[i];
            s.style.width="100px";
            div.appendChild(s);
        }
        forma.appendChild(div);


        div=document.createElement("div");
        div.className="div";
        let divrb;
        let usluge=["sisanje","feniranje","farbanje","pletenica","lokne"];
        for(let i=0;i<usluge.length;i++){
            divrb=document.createElement("div");
            
            let labrb=document.createElement("label");
            labrb.innerHTML=usluge[i];
            divrb.appendChild(labrb);

            let rb=document.createElement("input");
            rb.name="radio";
            rb.type="radio";
            rb.value=usluge[i];
            divrb.appendChild(rb);

            div.appendChild(divrb);
        }

        forma.appendChild(div);

        div=document.createElement("div");
        div.className="div";

        let labvreme=document.createElement("label");
        labvreme.innerHTML="Vreme: ";
        div.appendChild(labvreme);

        let vreme=document.createElement("input");
        vreme.type="time";
        vreme.className="vreme";
        
        div.appendChild(vreme);
        forma.appendChild(div);

        let dugme=document.createElement("button");
        dugme.innerHTML="Rezervisi";
        dugme.addEventListener("click",e=>{

            let vr=vreme.value;
            let rad=selradnici.options[selradnici.selectedIndex].value;
            
            let usl=document.querySelectorAll('input[type="radio"]:checked')[0].value;
            
            //this.listaradnika[rad].dodajvreme(vr,usl);
            
            fetch("https://localhost:5001/DodajVreme/"+rad+"/"+vr,
            {
                method:"PUT"
            }).then(p=>{
                if(p.ok){
                    this.listaradnika[rad].dodajvreme(vr,usl);
                }
            });

        })

        forma.appendChild(dugme);
        host.appendChild(forma);




    }
    crtajradnike(host)
    {
        let radnici=document.createElement("div");
        radnici.className="radnici";
        this.listaradnika.forEach(radnik=>{
            radnik.crtajradnika(radnici);
        })

        host.appendChild(radnici);
    }
}