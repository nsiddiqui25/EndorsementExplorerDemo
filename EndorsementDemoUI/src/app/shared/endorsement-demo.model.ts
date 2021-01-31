import { DemoDto } from './endorsement-demo.service';

export class EndorsementDemo {
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
  somethingNew: any;

  // constructor(source: DemoDto){
  //   if (!source)
  //   {
  //     this.formMasterId = 0;
  //     this.formVersionId = 0;
  //     this.formVersionSuf = '';
  //     this.formVersionNo = '';
  //     this.referenceNo = '';
  //     this.formDisplay = '';
  //     this.formName = '';
  //     this.formInternalName = '';
  //     this.formDesc = '';
  //     this.formDescChangeAllowed = false;
  //     this.signoffRequired = false;
  //     this.quoteSort = '';
  //     this.binderSort = '';
  //     this.revisionDate = '';
  //     this.formEffectiveDate = new Date();
  //     this.formApprovedDate = new Date();
  //     this.formApprovedId = '';
  //     this.createdById = '';
  //     this.pageCount = 0;
  //     this.blankCount = 0;
  //     this.lastChangedDate = new Date();
  //     this.lastChangedId = '';
  //     this.active = false;
  //     this.fileName = '';
  //     this.rowVersion = {};
  //   } else {
  //     this.formVersionId = source.formVersionId;
  //     this.somethingNew = 'mapped from api response';
  //   }
  // }
}
