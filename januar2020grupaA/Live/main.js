import { Fabrika } from "./fabrika.js";
import { Silos} from "./silos.js"
/*
let fabrika=new Fabrika("1","Zitopek");
fabrika.dodajSilos(new Silos("1","1500"));
fabrika.dodajSilos(new Silos("2","2000"));
fabrika.dodajSilos(new Silos("3","1000"));

fabrika.crtaj(document.body);



let fabrika1=new Fabrika("2","Zitopromet");
fabrika1.dodajSilos(new Silos("4","1600"));
fabrika1.dodajSilos(new Silos("5","2500"));
fabrika1.dodajSilos(new Silos("6","1800"));

fabrika1.crtaj(document.body);

*/
(function(){
    console.log("2");

    fetch("https://localhost:5001/PreuzmiFabrike",{
        method:"GET"

    })
    .then(r=>r.json().then(data=>{
            data.forEach(d => {
                const fabrika=new Fabrika(d["id"],d["naziv"]);
                d["silosi"].forEach(f=>{
                    const silos=new Silos(f["id"],f["trenutnakolicina"]);
                    silos.dodajkapacitet(f["kapaciteti"]);

                    fabrika.dodajSilos(silos);


                });
                //console.log(fabrika);
                fabrika.crtaj(document.body);
            });

    }));

})();