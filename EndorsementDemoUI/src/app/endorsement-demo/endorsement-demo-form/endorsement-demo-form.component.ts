import { AfterViewInit, Component, ElementRef, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import WebViewer from '@pdftron/webviewer';
import { toArray } from 'rxjs/operators';
import { EndorsementDemo } from 'src/app/shared/endorsement-demo.model';
import { EndorsementDemoService } from '../../shared/endorsement-demo.service';

@Component({
  selector: 'app-endorsement-demo-form',
  templateUrl: './endorsement-demo-form.component.html',
  styles: [
  ]
})
export class EndorsementDemoFormComponent implements AfterViewInit, OnChanges {
  @ViewChild('viewer') viewerRef: ElementRef;
  @Input()
  selectedEndorsement: EndorsementDemo;

  get basePdfPath(): string {
    return `https://localhost:44328/api/UndFormVersions/pdf/${this.selectedEndorsement.formVersionId}`;
  }

  // search: string;
  // isValid: true;
  previewDoc = false;
  // pdfSrc = 'C:/Users/nsiddiqui/source/repos/EndorsementDemo/EndorsementDemoUI/src/assets/Endorsement.pdf';

  constructor(private endorsementService: EndorsementDemoService) { }

  ngAfterViewInit(): void {
    console.log('ngAfterViewInit - in form component', this.selectedEndorsement);
    if (this.viewerRef) {
      WebViewer({
        path: '../../../assets/lib',
        // initialDoc: '../../../assets/Endrosement.pdf'
        initialDoc: this.basePdfPath
      }, this.viewerRef.nativeElement).then(instance => {
      });
    }
  }

  ngOnChanges(){
    console.log('ngOncChanges - in form component', this.selectedEndorsement);
    if (this.viewerRef) {
      WebViewer({
        path: '../../../assets/lib',
        // initialDoc: '../../../assets/Endrosement.pdf'
        initialDoc: this.basePdfPath
      }, this.viewerRef.nativeElement).then(instance => {
      });
    }
  }

  nextHightlight(formVersionId: number, blankCount: any): void{
    const versionId = +formVersionId;
    const count: number = +blankCount;
    console.log(this.basePdfPath);
    console.log('blankCount', count);
    console.log('formVersionId', versionId);

    // const countArr = Array.from(count);

    // count.forEach(x => {
    //   this.endorsementService.getBookmarkNames(versionId).subscribe(res => {
    //     console.log(res);
    //   });
    // });

    // let c: any;
    const arrayOfCount: any = count.toString(10).replace(/\D/g, '0').split('').map(Number);
    console.log(arrayOfCount);

    for (let c = 0; c < arrayOfCount.length; c++) {
      if (c) {
        console.log(c);
      }
    }
  }
    // for (c in count) {
    //   console.log(count[c]);
    // }

    // this.endorsementService.getBookmarkNames(versionId).subscribe(response => {
    //   response.forEach(element => {
    //     this.endorsementService.highlightBookmarkNames(element).subscribe(res => {
    //       console.log(res);
    //     });
    //   });
    // });

  showPreview(){
    this.previewDoc = true;
    console.log(this.previewDoc);
  }

  onSubmit(form: NgForm){
    // this.endorsementService.getUndFormVersion();
   //  console.log(this.service.formData);
  }
}
