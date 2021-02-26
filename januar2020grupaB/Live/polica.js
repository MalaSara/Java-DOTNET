export class Polica{
    constructor(id,nazivpolice,maksbroj,trenutnibroj){
        this.id=id;
        this.nazivpolice=nazivpolice;
        this.maksbroj=maksbroj;
        this.trenutnibroj=trenutnibroj;
        
    }

    crtajpolicu(host,i){

        let polica=document.createElement("div");
        polica.className="polica";

        let ime=document.createElement("label");
        ime.innerHTML=this.nazivpolice;
        ime.className="ime";

        polica.appendChild(ime);

        let sveknjige=document.createElement("div");
        sveknjige.className="sveknjige";
        sveknjige.value=i;
        


        polica.appendChild(sveknjige);

        let trenutnoukupno=document.createElement("label");
        trenutnoukupno.className="trenutnoukupno";
        trenutnoukupno.innerHTML=this.trenutnibroj+ "/"+this.maksbroj;

        polica.appendChild(trenutnoukupno);

        host.appendChild(polica);

    }

   
}