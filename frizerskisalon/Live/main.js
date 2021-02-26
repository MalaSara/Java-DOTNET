import {Radnik } from "./radnik.js";
import {Frizerskisalon} from "./frizerskisalon.js";


/*
let fr=new Frizerskisalon("1","Kao prosli put","Beograd");
fr.dodajradnika(new Radnik("1","Milena"));
fr.dodajradnika(new Radnik("2","Sanja"));

fr.crtaj(document.body);

*/

(function(){

    fetch("https://localhost:5001/PreuzmiSalone",{
        method:"GET"
    })
    .then(r=>r.json().then(data=>{

        data.forEach(sal=>{
            const salon=new Frizerskisalon(sal["id"],sal["imesalona"],sal["lokacija"]);
            sal["radnici"].forEach(rad=>{

                const radnik=new Radnik(rad["id"],rad["imeradnik"]);
                
                radnik.dodajvrem(rad["vreme"]);
                salon.dodajradnika(radnik);

            });

            salon.crtaj(document.body);
        });
    }));

})();

