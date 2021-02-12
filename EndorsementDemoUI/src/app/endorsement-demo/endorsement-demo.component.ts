import { Component, OnInit } from '@angular/core';
import { EndorsementDemoService } from '../shared/endorsement-demo.service';
import { EndorsementDemo } from 'src/app/shared/endorsement-demo.model';

@Component({
  selector: 'app-endorsement-demo',
  templateUrl: './endorsement-demo.component.html',
  styles: [
  ]
})
export class EndorsementDemoComponent implements OnInit {
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

}
