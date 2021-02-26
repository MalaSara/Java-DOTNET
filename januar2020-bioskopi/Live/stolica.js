export class Stolica{

    constructor(id,rezervisano){
        this.id=id;
        this.rezervisano=rezervisano;
       
    }

    crtajstolicu(host,a,b){
        let stolica=document.createElement("div");
        stolica.className="stolica";

       a++;
       b++;
        stolica.innerHTML= b+""+a;
        host.appendChild(stolica);
    }
}