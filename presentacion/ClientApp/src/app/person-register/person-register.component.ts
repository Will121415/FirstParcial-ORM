import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person';
import { Support } from '../models/support';
import { PersonService } from '../services/person.service';
import { AbstractControl, FormBuilder, FormGroup, Validators} from '@angular/forms';

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
  formGroupPerson: FormGroup;
  formGroupSupport: FormGroup;

  constructor(private personService: PersonService, private formBuilder: FormBuilder) { }


  ngOnInit() {
    this.buildForm();
    this.supportAvailable();
  }

  private buildForm()
  {
    this.person = new Person();
    this.person.identification = '';
    this.person.name = '';
    this.person.surnames = '';
    this.person.age;
    this.person.sex = 'seleccionar...';
    this.person.department = '';
    this.person.city = '';
    
    
   

    this.formGroupPerson = this.formBuilder.group({
      identification: [this.person.identification, Validators.required],
      name: [this.person.name, Validators.required],
      surnames : [this.person.surnames, Validators.required],
      age : [this.person.age,Validators.required],
      sex: [this.person.sex, [Validators.required, this.validateSex]],
      department: [this.person.department, Validators.required],
      city: [this.person.city, Validators.required]
    });

    this.person.support = new Support();
    this.person.support.IdSupport = '';
    this.person.support.modality = 'seleccionar...';
    this.person.support.value;
    this.person.support.date = '';

    this.formGroupSupport = this.formBuilder.group({
      IdSupport: [this.person.support.IdSupport, Validators.required],
      modality: [this.person.support.modality, [Validators.required, this.validatModality]],
      value: [this.person.support.value, Validators.required],
      date: [this.person.support.date, Validators.required],
    });
    
  }
  get invalid()
  {
     return (this.formGroupPerson.invalid || this.formGroupSupport.invalid);
  }

  private validateSex(control: AbstractControl)
  {
    const sex = control.value;
    if(sex !== 'seleccionar...' ) return null;
    return  {validateSex: true, messageSex: 'debe seleccionar sexo'};
  }
  private validatModality(control: AbstractControl)
  {
    const modality = control.value;
    if(modality !== 'seleccionar...' ) return null;
    return  {validateSex: true, messageSex: 'debe seleccionar una modalidad'};
  }

  get controlPerson()
  {
    return this.formGroupPerson.controls;
  }

  get controlSupport()
  {
    return this.formGroupSupport.controls;
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
    
    if(this.formGroupPerson.invalid && this.formGroupSupport) return;
    
    this.support = this.formGroupSupport.value;
    this.person= this.formGroupPerson.value;
    this.person.support = this.support;
    console.log(this.person);

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
