export class Mec{

    constructor(id,lokacija,vreme){
        this.listaigraca=new Array();
        this.listapoena=new Array();
        
        this.id=id;
        this.lokacija=lokacija;
        this.vreme=vreme;
        this.container=null;
    }

    dodajigraca(ig){
        this.listaigraca.push(ig);
    }

    crtajformuzarez(host){
        if(!host)
            throw new Error("Nema hosta");
        
        let forma=document.createElement("div");
        forma.className="forma";

        let lok=document.createElement("label");
        lok.innerHTML="Lokacija"+this.lokacija;
        forma.appendChild(lok);

        let vreme=document.createElement("label");
        vreme.innerHTML=this.vreme;
        forma.appendChild(vreme);

        let labrez=document.createElement("label");
        labrez.innerHTML="Rezultat:"
        forma.appendChild(labrez);
        
        let divrez=document.createElement("div");
        divrez.className="divrez";

        let rez1=document.createElement("input");
        rez1.type="number"
        rez1.className="rez1";
        
        let rez2=document.createElement("input");
        rez2.type="number"
        rez2.className="rez2";
        
        divrez.appendChild(rez1);
        divrez.appendChild(rez2);
        forma.appendChild(divrez);
        
        let divnizpoenadosad=document.createElement("div");
       
        divnizpoenadosad.className="divnizpoenadosad";
        


        forma.appendChild(divnizpoenadosad);


        let labpoeni=document.createElement("poeni")
        labpoeni.innerHTML="Poeni";
        forma.appendChild(labpoeni)

        let divpoeni=document.createElement("div");
        divpoeni.className="divpoeni";

        let poeni1=document.createElement("input");
        poeni1.type="number"
        poeni1.className="poeni1";
        
        divpoeni.appendChild(poeni1);

        let poeni2=document.createElement("input");
        poeni2.type="number"
        poeni2.className="poeni2";
        
        divpoeni.appendChild(poeni2);
        forma.appendChild(divpoeni);

        let dugme1=document.createElement("button");
        dugme1.className="dugme1 dugme";
        dugme1.innerHTML="+";
        let divic;
        let i=0;
        let a;
        dugme1.addEventListener("click",e=>{
            /*if(rez1.value<3 && rez2.value<3){

                if(poeni1.value<6){
                    if(poeni2.value<6)
                    poeni1.value++;

                }
                else{
                    divic=document.createElement("div");

                    divic.innerHTML=poeni1.value +":"+poeni2.value+",";

                    divnizpoenadosad.appendChild(divic);
                   
                    rez1.value++;
                    poeni1.value=0;
                    poeni2.value=0;
                    this.listapoena[i]=divic.innerHTML;
                    a=this.listaigraca[0];
                }
            }
            else{
                poeni2.value=0;
                poeni1.value=0;
                alert("Kraj meca");
            }  
            */

            fetch("https://localhost:5001/DodajPoene/"+this.listaigraca[0]+"/"+poeni1.value++,
            {
                method:"POST",
                headers:{
                    "Content-Type":"text/plain"
                }
            }).then(p=>{
                if(p.ok){
                    if(rez1.value<4 && rez2.value<4){

                        if(poeni1.value<6){
                            if(poeni2.value<6)
                            poeni1.value++;
        
                        }
                        else{
                            divic=document.createElement("div");
        
                            divic.innerHTML=poeni1.value +":"+poeni2.value+",";
        
                            divnizpoenadosad.appendChild(divic);
                           
                            rez1.value++;
                            poeni1.value=0;
                            poeni2.value=0;
                            this.listapoena[i]=divic.innerHTML;
                            a=this.listaigraca[0];
                        }
                    }
                    else{
                        poeni2.value=0;
                        poeni1.value=0;
                        alert("Kraj meca");
                    }  
                    
                }
            })
        });
        

        let dugme2=document.createElement("button");
        dugme2.className="dugme2 dugme";
        dugme2.innerHTML="+";
        dugme2.addEventListener("click",e=>{
           /* if(rez1.value<3 && rez2.value<3){

                if(poeni2.value<6){
                    if(poeni1.value<6)
                    poeni2.value++;

                }
                else{
                    divic=document.createElement("div");
                    divic.innerHTML=poeni1.value +":"+poeni2.value+ ",";

                    divnizpoenadosad.appendChild(divic);
                    rez2.value++;
                    poeni1.value=0;
                    poeni2.value=0;
                    this.listapoena[i]=divic.innerHTML;
                    i++;
                    a=this.listaigraca[1];
                }
            }
            else{
                poeni2.value=0;
                poeni1.value=0;
                alert("Kraj meca")
            }   */
             fetch("https://localhost:5001/DodajPoene/"+this.listaigraca[1]+"/"+poeni2.value,
            {
                method:"POST",
                headers:{
                    "Content-Type":"text/plain"
                }
            }).then(p=>{
                if(p.ok){
                    if(rez1.value<4 && rez2.value<4){

                        if(poeni2.value<6){
                            if(poeni1.value<6)
                            poeni2.value++;
        
                        }
                        else{
                            divic=document.createElement("div");
                            divic.innerHTML=poeni1.value +":"+poeni2.value+ ",";
        
                            divnizpoenadosad.appendChild(divic);
                            rez2.value++;
                            poeni1.value=0;
                            poeni2.value=0;
                            this.listapoena[i]=divic.innerHTML;
                            i++;
                            a=this.listaigraca[1];
                        }
                    }
                    else{
                        poeni2.value=0;
                        poeni1.value=0;
                        alert("Kraj meca")
                    }   
                    
                }
            })
        });

        forma.appendChild(dugme1);
        forma.appendChild(dugme2);
        host.appendChild(forma);

    }

    crtajigraca(host,i){
        if(!host)
            throw new Error("Nema hosta");
        
        let div=document.createElement("div");
        div.className="igrac"+i;
        i.crtajigrac(div);

        host.appendChild(div);
    }

    crtaj(host){
        if(!host)
            throw new Error("Nema hosta");
        
        this.container=document.createElement("div");
        this.container.className="sve";
        this.crtajigraca(this.container,this.listaigraca[0])
        this.crtajformuzarez(this.container);
        this.crtajigraca(this.container,this.listaigraca[1]);

        host.appendChild(this.container);
    }
}