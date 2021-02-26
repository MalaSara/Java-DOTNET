export class Silos{

    constructor(id,trenutnakolicina){
        this.id=id;
        this.kapaciteti=new Array();
        this.trenutnakolicina=trenutnakolicina;
        this.container
    }

    crtajsilos(host,i)
    {

       // this.trenutnakolicina=0;
        let silos=document.createElement("div");
        silos.className="silos";
        this.container=silos;

        let ime=document.createElement("label");
        ime.innerHTML="Silos"+i;
        silos.appendChild(ime);

        let kapacitett=document.createElement("div");
        kapacitett.innerHTML=this.trenutnakolicina+"t";
        silos.appendChild(kapacitett);

        let telosilosa=document.createElement("div");
        telosilosa.className="telosilosa";
        this.crtajkapacitete(telosilosa);

        silos.appendChild(telosilosa);

        host.appendChild(silos);
    }

    crtajkapacitete(host){
        
        this.kapaciteti.forEach(kapacitet=>{
            
            let div=document.createElement("div");
            div.className="kapacitet";

            host.appendChild(div);
        })
    }

    dadajkapacitete(kap){
        
        
            //console.log(kap);
            this.kapaciteti.push(kap);
            const ka=this.container.querySelector(".telosilosa");
            console.log(ka);
            let div=document.createElement("div");
            div.className="kap"

            const height =0.25*kap;
            div.style.height=height+"px";

            div.style.width="100px";
            ka.appendChild(div);
        

    }

    dodajkapacitet(k){
        this.kapaciteti.push(k);
    }


}