import { Component, OnInit } from '@angular/core';
import { EndorsementDemoService } from '../shared/endorsement-demo.service';

@Component({
  selector: 'app-endorsement-demo',
  templateUrl: './endorsement-demo.component.html',
  styles: [
  ]
})
export class EndorsementDemoComponent implements OnInit {

  constructor(public service: EndorsementDemoService) { }

  ngOnInit(): void {
  }

}
