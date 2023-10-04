import { Component, OnInit } from '@angular/core';
import {  } from 'ngx-bootstrap/tabs';

import { CountryDto, DictionaryClient, PersonalInfoClient, ProvinceDto, RegisterPersonalInfoCommand } from '../web-api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  
})
export class HomeComponent implements OnInit {
  countries:CountryDto[];
  provinces:ProvinceDto[];
  
  constructor(
    private dictionaryClient: DictionaryClient,
    private personalInfoClient: PersonalInfoClient,
  ){};

  ngOnInit(): void {
    this.dictionaryClient.getCountries().subscribe(r => {
      this.countries = r;
    }, console.error);
  }
  
  handleCountryChange(e){
    this.dictionaryClient.getProvinces(this.formValues.countryId).subscribe(r => {
      this.provinces = r;
    }, console.error);
  }
  
  formValues: any = {};
  handleSubmit(): void {
    console.log("values", this.formValues);
    this.personalInfoClient.create(RegisterPersonalInfoCommand.fromJS(this.formValues))
    .subscribe(()=>{
      this.formValues = {};
    })

  }

  handleCancel(): void {
    this.formValues = {};
  }

}
