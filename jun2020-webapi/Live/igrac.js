export class Igrac{

    constructor(id,ime,godine,atprang){
        this.id=id;
        this.ime=ime;
        this.godine=godine;
        this.atprang=atprang;
        this.poeni=new Array();
        this.container=null;
    }

    crtajigrac(host){
        
        let infoig=document.createElement("div");
        infoig.className="infoig";

        let labime=document.createElement("label");
        labime.innerHTML= "Ime: "+ this.ime;
        infoig.appendChild(labime);

        let labgodine=document.createElement("label");
        labgodine.innerHTML="Godine: "+ this.godine;
        infoig.appendChild(labgodine);

        let labatp=document.createElement("label");
        labatp.innerHTML="ATP rang: " +this.atprang;
        infoig.appendChild(labatp);

        host.appendChild(infoig);
    }

    
}