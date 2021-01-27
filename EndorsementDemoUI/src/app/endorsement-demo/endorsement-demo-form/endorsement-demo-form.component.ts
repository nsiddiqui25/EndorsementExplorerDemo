import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EndorsementDemoService } from 'src/app/shared/endorsement-demo.service';

@Component({
  selector: 'app-endorsement-demo-form',
  templateUrl: './endorsement-demo-form.component.html',
  styles: [
  ]
})
export class EndorsementDemoFormComponent implements OnInit {

  constructor(public service: EndorsementDemoService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    this.service.getUndFormVersion();
    console.log(this.service.formData);
  }
}
