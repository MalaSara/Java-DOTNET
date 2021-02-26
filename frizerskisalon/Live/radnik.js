export class Radnik{

    constructor(id,imeradnik){
        this.id=id;
        this.imeradnik=imeradnik;
        this.container=null;
        this.vremena=new Array();

    }

    crtajradnika(host){
        
        let radnik=document.createElement("div");
        radnik.className="radnik";
        this.container=radnik;

        let terminiradnikapre=document.createElement("div");
        terminiradnikapre.className="terminiradnikapre";
        this.crtajvremepre(terminiradnikapre); 
        radnik.appendChild(terminiradnikapre);


        let labimer=document.createElement("label");
        labimer.innerHTML=this.imeradnik;
        labimer.style.textAlign="center";
       
        radnik.appendChild(labimer);
        
        let terminiradnikaposle=document.createElement("div");
        terminiradnikaposle.className="terminiradnikaposle";
        this.crtajvremeposle(terminiradnikaposle);
        radnik.appendChild(terminiradnikaposle);

        host.appendChild(radnik);


    }

    dodajvreme(vr,usl){
        this.vremena.push(vr);

        if(vr>"12:00"){
            let posle=this.container.querySelector(".terminiradnikaposle");
            console.log(posle);
            let divposle=document.createElement("div");
            divposle.className="ter "+usl;
            divposle.innerHTML=vr+"--"+usl;
            posle.appendChild(divposle);
            
        }
        else
        {
            let pre=this.container.querySelector(".terminiradnikapre");
            
            let divpre=document.createElement("div");
            divpre.innerHTML=vr +"--"+usl;
            divpre.className="ter "+usl;

            pre.appendChild(divpre);
        }
        
    }

    crtajvremeposle(host)
    {
        this.vremena.forEach(vreme=>{
        if(vreme>"12:00"){
        
            let divposles=document.createElement("div");
            divposles.className="ter "
            divposles.innerHTML=vreme;
            host.appendChild(divposles);
            
        }
        })
    }

    crtajvremepre(host){
        this.vremena.forEach(vre=>{
            if(vre<"12:00"){
            let divpres=document.createElement("div");
            divpres.className="ter "
            divpres.innerHTML=vre;
            host.appendChild(divpres);
            }
        })
    }
        

    dodajvrem(vr){
        this.vremena.push(vr);
    }

}