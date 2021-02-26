import { Stolica } from "./stolica.js";

export class Bioskop{

    constructor(id,naziv,red,brojmesta,rezervisanih){
        this.id=id;
        this.naziv=naziv;
        this.container=null;
        this.red=red;
        this.brojmesta=brojmesta;
        this.rezervisanih=rezervisanih;
        this.matricastolica=[];
        for(let i=0;i<red;i++){
            this.matricastolica[i]=new Array(brojmesta);
        }
        for(let i=0;i<red;i++)
            for(let j=0;j<brojmesta;j++)
            this.matricastolica[i][j]=new Stolica();
    }

   

    crtajime(host){
        let div=document.createElement("div");
        div.className="divime";
        
        let lab=document.createElement("label");
        lab.innerHTML=this.naziv;
        div.appendChild(lab);
        
        this.rezervisanih=0;
        let situacija=document.createElement("label");
        situacija.innerHTML="Trenutno rezervisano:"+rezervisanih+" od:" +this.red*this.brojmesta;

    }
    crtjformu(host){
        if(!host)
            throw new Error("Nema hosta");

        let forma=document.createElement("div");
        forma.className="forma";
        
        

        let divredovi=document.createElement("div");
        divredovi.className="divredovi";

        let m=1;
        for(let i=0;i<this.red;i++){
            
            let divrad=document.createElement("div");
            divrad.className="divrad";
            
            let radiob=document.createElement("input");
            radiob.type="radio";
            radiob.name="radio";
            radiob.value=i+1;
            radiob.className="radiored";
            divrad.appendChild(radiob);

            let imered=document.createElement("label");
            imered.innerHTML="Red"+m;
            divrad.appendChild(imered);

            divredovi.appendChild(divrad);
            m++;
        }
        
        forma.appendChild(divredovi);

        let labmesto=document.createElement("label");
        labmesto.innerHTML="Broj mesta:"
        forma.appendChild(labmesto);

        let mestaselect=document.createElement("select");

        for(let i=0;i<this.brojmesta;i++){
            mestaselect.options.add(new Option(i+1,i+1));
        }
        forma.appendChild(mestaselect);

        let dugme=document.createElement("button");
        dugme.className="dugme";
        dugme.innerHTML="Rezervisi";
        dugme.addEventListener("click",e=>{
            let red=0;

            let rb=document.querySelectorAll("input");
            for(let a=0;a<rb.length;a++){
                if(rb[a].checked==true){
                    red=rb[a].value;   
                }
            }

            //console.log(red);

            let b=mestaselect.options[mestaselect.selectedIndex].value;
            
            //console.log(b);

            let stolica=document.querySelectorAll(".divstolice");

            fetch("https://localhost:5001/DodajStolicu" +this.id +"/",
            {
                method:"post",
                header:{
                    "Content-Type":"text/plain"
                }

            }).then(p=>{
                if(p.ok){
                    stolica.forEach(e=>{
                        e.childNodes.forEach(ee=>{
                            ee.childNodes.forEach(eee=> {
                                if(b+red ===eee.innerHTML ){
                                    console.log(eee.innerHTML);
                                    eee.style.backgroundColor="red";
                                    this.rezervisanih++;
                                }
                            });
                        }); 
                    });     

                }

            })


           /* stolica.forEach(e=>{
                e.childNodes.forEach(ee=>{
                    ee.childNodes.forEach(eee=> {
                        if(b+red ===eee.innerHTML ){
                            console.log(eee.innerHTML);
                            eee.style.backgroundColor="red";
                            this.rezervisanih++;
                        }
                    });
                });   
            })*/
            
            
            //console.log(stolica);

        });
        forma.appendChild(dugme);

        host.appendChild(forma);

    }
    crtajstolice(host){

        let divstolice=document.createElement("div");
        divstolice.className="divstolice";
        for(let i=0;i<this.red;i++){
            let divjedanred=document.createElement("div");
            divjedanred.value=i;
            divjedanred.className="divjedanred "+i;
            for(let j=0;j<this.brojmesta;j++){
                
                this.matricastolica[i][j].crtajstolicu(divjedanred,i,j);
                
            }
            divstolice.appendChild(divjedanred);
            //let br=document.createElement("br");

        }

        host.appendChild(divstolice);

    }

    crtaj(host){

        if(!host)
            throw new Error("Nema hosta");
         
        this.container=document.createElement("div");
        this.container.className="sve";
        this.crtjformu(this.container);
        this.crtajstolice(this.container);

        host.appendChild(this.container);
            
    }
}