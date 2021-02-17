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
    const versionId = +formVersionId;
    console.log('formVersionId', versionId);

    this.endorsementService.getBookmarkNames(versionId).subscribe(response => {
      console.log('bookmark names', response);
    });

    this.endorsementService.getUndFormVersion(versionId).subscribe(response => {
      console.log(response);
      this.selectedEndorsement = response;
    });
  }

}
