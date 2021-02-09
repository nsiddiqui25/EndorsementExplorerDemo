import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EndorsementDemo } from 'src/app/shared/endorsement-demo.model';
import { EndorsementDemoService } from 'src/app/shared/endorsement-demo.service';
import WebViewer from '@pdftron/webviewer';

@Component({
  selector: 'app-endorsement-demo-form',
  templateUrl: './endorsement-demo-form.component.html',
  styles: [
  ]
})
export class EndorsementDemoFormComponent implements AfterViewInit {
  @ViewChild('viewer') viewerRef: ElementRef;
  // search: string;
  // isValid: true;
  selectedEndorsement: EndorsementDemo;
  previewDoc = false;
  // pdfSrc = 'C:/Users/nsiddiqui/source/repos/EndorsementDemo/EndorsementDemoUI/src/assets/Endorsement.pdf';

  constructor(private endorsementService: EndorsementDemoService) { }

  ngAfterViewInit(): void {
    if (this.viewerRef) {
      WebViewer({
        path: '../../../assets/lib',
        initialDoc: '../../../assets/Endrosement.pdf'
      }, this.viewerRef.nativeElement).then(instance => {
      });
    }
  }

  onButtonClick(formVersionId: string): void {
    console.log(formVersionId);
    this.endorsementService.getUndFormVersion(+formVersionId).subscribe(response => {
      console.log(response);
      this.selectedEndorsement = response;
    });
  }

  showPreview(){
    this.previewDoc = true;
  }

  onSubmit(form: NgForm){
    // this.endorsementService.getUndFormVersion();
   //  console.log(this.service.formData);
  }
}
