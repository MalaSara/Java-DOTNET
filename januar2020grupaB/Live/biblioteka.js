export class Biblioteka{
    constructor(id,naziv){
        this.id=id;
        this.naziv=naziv;
        this.container=null;
        this.listapolica=new Array();

    }

    dodajpolicu(polica){
        this.listapolica.push(polica);
    }

    crtajformu(host){
        if(!host)
            throw new Error("NEMA HOSTA");
        
        let forma=document.createElement("div");
        forma.className="forma";
        
        let div=document.createElement("div");
        
        let labime=document.createElement("label");
        labime.innerHTML=this.naziv;

        div.appendChild(labime);
        forma.appendChild(div);

        let divredovi=document.createElement("div");
        divredovi.className="divredovi";

        for(let i=0;i<this.listapolica.length;i++){
           
            let divred=document.createElement("div");
            divred.className="divred";
            let rb=document.createElement("input");
            rb.name="rb";
            rb.type="radio"
            rb.className="rb";
            rb.value=this.listapolica[i].nazivpolice;
            
            divred.appendChild(rb);

            let imepolice=document.createElement("label");
            imepolice.innerHTML=this.listapolica[i].nazivpolice;

            divred.appendChild(imepolice);

            divredovi.appendChild(divred);

        }

        forma.appendChild(divredovi);

        let labbrojknjiga=document.createElement("brojknjiga");
        labbrojknjiga.innerHTML="Broj knjiga:";

        forma.appendChild(labbrojknjiga);

        let broj=document.createElement("input");
        broj.type="number";
        broj.className="brojknjiga";

        forma.appendChild(broj);

        let dugme=document.createElement("button");
        dugme.className="dugme";
        dugme.innerHTML="Dodaj";
        dugme.addEventListener("click",e=>{

            let imepolice;
            let rbch=document.querySelectorAll(".rb");
            //console.log(rbch);
            for(let i=0;i<rbch.length;i++){
                if(rbch[i].checked==true)
                imepolice=rbch[i].value;
            }
            //console.log(imepolice);

            let kolicina=broj.value;
            //console.log(kolicina);

            let divpolice=document.querySelectorAll(".divpolice");
            divpolice.forEach(e=>{
                e.childNodes.forEach(ee=>{
                    
                    ee.childNodes.forEach(eee=>{
                        if(imepolice==eee.innerHTML){
                           let a=ee.querySelectorAll(".sveknjige")
                          let b=a[0].value;
                          for(let i=0;i<kolicina;i++){
                              this.listapolica[b].trenutnibroj++;
                          }

                          fetch("https://localhost:5001/DodajKnjigu/"+this.listapolica[b].id+"/"+this.listapolica[b].trenutnibroj,
                          {
                            method:"post",
                            headers:{
                                "Content-Type":"text/plain"
                            }
                          }).then(p=>{
                              if(p.ok){
                                for(let i=0;i<kolicina;i++)
                                {   
                                    let knjiga=document.createElement("div");
                                    knjiga.className="knjiga";
                                    a[0].appendChild(knjiga);
                               
                                }
                                let c=ee.querySelectorAll(".trenutnoukupno");
                                c[0].innerHTML=this.listapolica[b].trenutnibroj+"/"+this.listapolica[b].maksbroj;
                             }
                            })

                          
                          
                           /*for(let i=0;i<kolicina;i++)
                            {   
                                let knjiga=document.createElement("div");
                                knjiga.className="knjiga";
                                a[0].appendChild(knjiga);
                                //this.listapolica[b].trenutnibroj++;
                                
                            }
                            //console.log(this.listapolica[b].trenutnibroj);
                        
                            let c=ee.querySelectorAll(".trenutnoukupno");
                            c[0].innerHTML=this.listapolica[b].trenutnibroj+"/"+this.listapolica[b].maksbroj;*/
                        }       
                        
                    })
                })
            })

            //console.log(divpolice);
        });

        forma.appendChild(dugme);

        host.appendChild(forma);
        
    }

    crtajpolice(host){

        let divpolice=document.createElement("div");
        divpolice.className="divpolice";


        for(let i=0;i<this.listapolica.length;i++){
            this.listapolica[i].crtajpolicu(divpolice,i);
        }

        host.appendChild(divpolice);

    }

    crtaj(host){
        if(!host)
            throw new Error("Nema hosta");
        
        this.container=document.createElement("div");
        this.container.className="container";

        this.crtajformu(this.container);
        this.crtajpolice(this.container);

        host.appendChild(this.container);
    }
}