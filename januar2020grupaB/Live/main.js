import { Biblioteka } from "./biblioteka.js";
import { Polica } from "./polica.js";

/*let bib=new Biblioteka("1","Stevan Sremac");

bib.dodajpolicu(new Polica("1","Beletristika","20","0"));
bib.dodajpolicu(new Polica("1","Epski romani","10","0"));
bib.dodajpolicu(new Polica("1","Naucna fantastika","30","0"));

bib.crtaj(document.body);*/

(function(){
    console.log("radi");

    fetch("https://localhost:5001/PreuzmiBiblioteku",{
        method:"get"
    })
    .then(r=>r.json().then(data =>{
        console.log(data);
        data.forEach(element => {
            const bib=new Biblioteka(element["id"],element["naziv"]);
            element["police"].forEach(pol=>{
                const polica=new Polica(pol["id"],pol["naziv"],pol["maksbroj"],pol["trenutnibroj"]);

                bib.dodajpolicu(polica);

            });
            console.log(bib);
            bib.crtaj(document.body);
        });    
        
        
    }))

})();
