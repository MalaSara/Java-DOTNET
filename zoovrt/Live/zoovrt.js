export class Zoovrt{

    constructor(id,naziv,n,m,makskapacitet){
        this.id=id;
        this.naziv=naziv;
        this.listazivotinja=new Array();
        this.container=null;
        this.n=n;
        this.m=m;
        this.makskapacitet=makskapacitet;
    }

    dodajzivotinju(z){
        this.listazivotinja.push(z);
    }

    crtaj(host){
        if(!host)
            throw new Error("Nema hosta");

        this.container=document.createElement("div");
        this.container.className="sve";

        this.crtajformu(this.container);
        this.crtajmatricu(this.container);

        host.appendChild(this.container);
    }

    crtajformu(host){
        if(!host)
            throw new Error("Nema hosta");

        let forma=document.createElement("div");
        forma.className="forma";

        /*let div=document.createElement("div");
        div.className="div";*/

        let labimevrste=document.createElement("label");
        labimevrste.innerHTML="Ime vrste";
        forma.appendChild(labimevrste);

        let tboxvrsta=document.createElement("input");
        tboxvrsta.type="text";
        tboxvrsta.className="tboxvrsta";
        forma.appendChild(tboxvrsta);

        let labkolicina=document.createElement("label");
        labkolicina.innerHTML="Kolicina:"
        forma.appendChild(labkolicina);

        let kolicina=document.createElement("input");
        kolicina.className="kolicina";
        kolicina.max=this.makskapacitet;
        forma.appendChild(kolicina);

        let labstanoviste=document.createElement("label");
        labstanoviste.innerHTML="Tip stanovista: ";
        forma.appendChild(labstanoviste);

        let div=document.createElement("div");
        div.className="div";

        let divrb;
        let stanovista=["bara","tundra","suma","savana"];
        for(let i=0;i<stanovista.length;i++){
            divrb=document.createElement("div");

            let labsta=document.createElement("label");
            labsta.innerHTML=stanovista[i];
            divrb.appendChild(labsta);

            let rb=document.createElement("input");
            rb.type="radio";
            rb.value=stanovista[i];
            rb.name="radio";
            divrb.appendChild(rb);

            div.appendChild(divrb);
        }
        forma.appendChild(div);

        let ddiv=document.createElement("div");
        ddiv.className="ddiv";

        let xkordlab=document.createElement("label");
        xkordlab.innerHTML="X:";
        ddiv.appendChild(xkordlab);

        let xkord=document.createElement("input");
        xkord.type="number";
        xkord.className="xkord";
        xkord.max=this.n;
        ddiv.appendChild(xkord);

        let ykordlab=document.createElement("label");
        ykordlab.innerHTML="Y:";
        ddiv.appendChild(ykordlab);

        let ykord=document.createElement("input");
        ykord.type="number";
        ykord.className="ykord";
        ykord.max=this.m;
        ddiv.appendChild(ykord);

        forma.appendChild(ddiv);

        let dugme=document.createElement("button");
        dugme.innerHTML="Dodaj zivotinju na lokaciju";
        dugme.addEventListener("click",e=>{

            let a=tboxvrsta.value;
            let kol=kolicina.value;

            
                this.listazivotinja.push(a);

                console.log(this.listazivotinja);
            
            let st=document.querySelectorAll('input[type="radio"]:checked')[0].value;

            let x=xkord.value;
            let y=ykord.value;

            this.dodajzivotinjunalokaciju(a,st,kol,x,y);

        });

        forma.appendChild(dugme);
        host.appendChild(forma);

    }

    crtajmatricu(host){


        let matrica=document.createElement("div");
        matrica.className="matrica";

        let divvrsta;
        let divkolona;
        for(let i=0;i<this.n;i++){
            divvrsta=document.createElement("div");
            divvrsta.className="kolona"+i;
            divvrsta.nodeValue=i;

            for(let j=0;j<this.m;j++){
                divkolona=document.createElement("div");
                divkolona.className="element vrsta"+j;
                divkolona.innerHTML="Prazno-0"
                divvrsta.appendChild(divkolona);
            
            }
            matrica.appendChild(divvrsta);
            
        }

        host.appendChild(matrica);
    }

    dodajzivotinjunalokaciju(a,st,kol,x,y){
        let mm;
        let kolona=document.querySelector(".kolona"+x);

        console.log(kolona);

        kolona.childNodes.forEach(ch=>{
           
            if(ch.className=="element vrsta"+y){
                mm=document.createElement("div");
                mm.innerHTML=a+"-"+kol;
                mm.className=st;
                console.log(mm);
                ch.replaceWith(mm);
                

                console.log(ch);
            }
            

        })

        

    }

   
    
}