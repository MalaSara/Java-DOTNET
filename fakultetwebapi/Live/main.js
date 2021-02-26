
import {Student} from "./student.js"
import { Fakultet  } from "./fakultet.js";
/*
let fak=new Fakultet("1","Elektronski","Nis");
fak.dodajstudenta(new Student("1","Marko","123"));
fak.dodajstudenta(new Student("2","Mila","234"));
fak.dodajstudenta(new Student("3","Marija","345"));
fak.dodajstudenta(new Student("4","Anja","456"));
fak.crtaj(document.body);

let fak1=new Fakultet("2","Masinski","Nis");
fak1.dodajstudenta(new Student("5","Aca","1"));
fak1.dodajstudenta(new Student("6","Manja","2"));
fak1.dodajstudenta(new Student("7","Kosta","3"));
fak1.crtaj(document.body);

*/


(function(){
   

    fetch("https://localhost:5001/PreuzmiFakultet",{
        method:"GET"
        
    })
    
    .then(r=>r.json().then(data=>{

        
        data.forEach(fakul => {
            const fakultet=new Fakultet(fakul["id"],fakul["imefakulteta"],fakul["lokacija"]);

            fakul["studenti"].forEach(st=>{
                const student=new Student(st["id"],st["imestudenta"],st["indeks"]);


                student.dodajpredmet(st["predmeti"]);
                fakultet.dodajstudenta(student);
                

            });

            console.log(fakultet);
            fakultet.crtaj(document.body);
        });

    }))

})();
