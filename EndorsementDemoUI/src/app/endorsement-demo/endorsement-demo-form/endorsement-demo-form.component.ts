import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import WebViewer from '@pdftron/webviewer';

@Component({
  selector: 'app-endorsement-demo-form',
  templateUrl: './endorsement-demo-form.component.html',
  styles: [
  ]
})
export class EndorsementDemoFormComponent implements OnInit {
  @ViewChild('viewer') viewerRef: ElementRef;
  // search: string;
  // isValid: true;
  previewDoc = false;
  // pdfSrc = 'C:/Users/nsiddiqui/source/repos/EndorsementDemo/EndorsementDemoUI/src/assets/Endorsement.pdf';

  constructor() { }

  ngOnInit(): void {
    if (this.viewerRef) {
      WebViewer({
        path: '../../../assets/lib',
        initialDoc: '../../../assets/Endrosement.docx'
      }, this.viewerRef.nativeElement).then(instance => {
      });
    }
  }

  showPreview(){
    this.previewDoc = true;
  }

  onSubmit(form: NgForm){
    // this.endorsementService.getUndFormVersion();
   //  console.log(this.service.formData);
  }
}
