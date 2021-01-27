import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { EndorsementDemoComponent } from './endorsement-demo/endorsement-demo.component';
import { EndorsementDemoFormComponent } from './endorsement-demo/endorsement-demo-form/endorsement-demo-form.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    EndorsementDemoComponent,
    EndorsementDemoFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
