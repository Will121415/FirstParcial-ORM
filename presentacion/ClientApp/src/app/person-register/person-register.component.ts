import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Person } from '../models/person';
import { Support } from '../models/support';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person-register',
  templateUrl: './person-register.component.html',
  styleUrls: ['./person-register.component.css']
})
export class PersonRegisterComponent implements OnInit {

  person: Person; 
  support: Support;
  quantityAvailable: number = 0;
  quantityDelivered: number = 0;
 

  constructor(private personService: PersonService) { }


  ngOnInit() {
    this.person = new Person();
    this.support = new Support();
    this.supportAvailable();
  }
  
  supportAvailable()
  {
    this.personService.getSumaSupport().subscribe(s =>{
      this.quantityDelivered = s;
      this.quantityAvailable = this.personService.maxAids - this.quantityDelivered;
    });
  }
  


  isRegistered()
  {
    this.person.support = this.support;

    this.personService.getPerson(this.person).subscribe(p => {
      
      if(p.identification == this.person.identification)
      {
        alert('La persona ya se encuentra registrada..!');
      }
      else{ 
        if(this.person.support.value <= this.quantityAvailable)
        {
          console.log('Es menor!');
          this.add();
        }else
        {
          alert('La ayuda ingresada supera el monto disponible '+ this.quantityAvailable);
        }
      }   
    });
  }

  add(): void
  {
   
      console.log('entró aqui');
      this.personService.post(this.person).subscribe(p => {
        if(p != null)
        {
          alert('Persona guadada exitosamente..!');
          this.person = p;
        }
      });
  }  

}
