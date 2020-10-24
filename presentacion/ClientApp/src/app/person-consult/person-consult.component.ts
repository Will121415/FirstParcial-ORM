import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person-consult',
  templateUrl: './person-consult.component.html',
  styleUrls: ['./person-consult.component.css']
})
export class PersonConsultComponent implements OnInit {
  
  persons: Person[];
  deliveredVale: number = 0;
  constructor(private personService: PersonService) { }

  ngOnInit() {
    
  }

  get(): void{
    this.personService.get().subscribe(result => {
     if(result != null)
     {
       this.persons =  result;
       this.supportDelivered();
     }
    
    });
  }
  supportDelivered(){
    this.personService.getSumaSupport().subscribe(s =>{
      this.deliveredVale = s;
    });
  }

}
