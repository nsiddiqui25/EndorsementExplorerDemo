import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EndorsementDemo } from 'src/app/shared/endorsement-demo.model';
import { EndorsementDemoService } from 'src/app/shared/endorsement-demo.service';

@Component({
  selector: 'app-endorsement-demo-form',
  templateUrl: './endorsement-demo-form.component.html',
  styles: [
  ]
})
export class EndorsementDemoFormComponent implements OnInit {

  // search: string;

  isValid: boolean = true;

  selectedEndorsement: EndorsementDemo;

  constructor(private endorsementService: EndorsementDemoService) { }

  ngOnInit(): void {
  }

  onButtonClick(formVersionId: string): void {
    console.log(formVersionId);
    this.endorsementService.getUndFormVersion(+formVersionId).subscribe(response => {
      console.log(response);
      this.selectedEndorsement = response;
    });
  }

  onSubmit(form: NgForm){
    // this.endorsementService.getUndFormVersion();
   //  console.log(this.service.formData);
  }
}
