import { Bioskop } from "./bioskop.js";
import { Stolica } from "./stolica.js";

/*let bio=new Bioskop("1","Vilin Grad","3","5","0");

/*bio.dodajstolicu(new Stolica());
bio.dodajstolicu(new Stolica());
bio.dodajstolicu(new Stolica());
bio.dodajstolicu(new Stolica());


bio.crtaj(document.body);*/



(function(){
    
    console.log("radi");
    fetch("https://localhost:5001/PreuzmiBioskope",{
        method:"GET"
    })
    .then(r=>r.json().then(data=>{
        console.log(data);
        data.forEach(d => {
            
            const bioskop=new Bioskop(d["id"],d["naziv"],d["red"],d["brojmesta"],d["rezervisanih"]);
            d["stolice"].forEach(sto=>{
                const stolica=new Stolica(sto["id"]);

                //bioskop.push(stolica);
            });
            console.log(bioskop);
            bioskop.crtaj(document.body);
        });


    }))

})();