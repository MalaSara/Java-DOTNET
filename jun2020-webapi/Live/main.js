import { Igrac } from "./igrac.js";
import { Mec } from "./mec.js";


let mecc=new Mec("1","Roland Garos","Pon 22 May 2021");
mecc.dodajigraca(new Igrac("1","Novak Djokovic","33","1"));
mecc.dodajigraca(new Igrac("2", "Rafael Nadal","35", "10"));

mecc.crtaj(document.body);


/*
(function(){

    console.log("ha");

    fetch("https://localhost:5001/PreuzmiMeceve",{
        method:"GET"
    })
    .then(r=>r.json().then(data=>{
        data.forEach(d => {
            
            const mec=new Mec(d["id"],d["lokacija"],d["vreme"]);
            d["igraci"].forEach(me=>{

                const ig=new Igrac(me["id"],me["ime"],me["godine"],me["atprang"]);

                mec.dodajigraca(ig);
                
            })

            console.log(mec);
            mec.crtaj(document.body);
        });


    }));

})();
*/