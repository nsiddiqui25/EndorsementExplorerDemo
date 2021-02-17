import { Injectable } from '@angular/core';
import { EndorsementDemo } from './endorsement-demo.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EndorsementDemoService {
  constructor(
    private http: HttpClient
    ) { }

  // formData: EndorsementDemo = new EndorsementDemo();
  private readonly baseURL = 'https://localhost:44328/api/UndFormVersions/';
  private list: EndorsementDemo[];

  getUndFormVersion(formVersionId: number): Observable<EndorsementDemo> {
    return this.http.get<EndorsementDemo>(this.baseURL + formVersionId);
    // return this.http.get<EndorsementDemo>(`${this.baseURL}pdf/${formVersionId}`);

    // .pipe(
    //   map(response => {
    //     console.log(response);
    //     return response;
    //   }),
    //   filter(response => response.formVersionId != 0),
    //   map(response => new EndorsementDemo(response))
    // );
  }

  getBookmarkNames(formVersionId: number): Observable<string[]> {
    return this.http.get<string[]>(`${this.baseURL}bookmarks/${formVersionId}`);
  }

  highlightBookmarkNames(blankCount: string): Observable<EndorsementDemo> {
    return this.http.get<EndorsementDemo>(`${this.baseURL}highlight/${blankCount}`);
  }
}

export interface DemoDto {
  formMasterId: number;
  formVersionId: number;
  formVersionSuf: string;
  formVersionNo: string;
  referenceNo: string;
  formDisplay: string;
  formName: string;
  formInternalName: string;
  formDesc: string;
  formDescChangeAllowed: boolean;
  signoffRequired: boolean;
  quoteSort: string;
  binderSort: string;
  revisionDate: string;
  formEffectiveDate?: Date;
  formApprovedDate?: Date;
  formApprovedId: string;
  createdById: string;
  pageCount?: number;
  blankCount?: number;
  lastChangedDate: Date;
  lastChangedId: string;
  active?: boolean;
  fileName: string;
  rowVersion?: any;
}

// export
