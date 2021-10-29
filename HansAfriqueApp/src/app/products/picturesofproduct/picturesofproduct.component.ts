import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-picturesofproduct',
  templateUrl: './picturesofproduct.component.html',
  styleUrls: ['./picturesofproduct.component.css']
})
export class PicturesofproductComponent implements OnInit {

  baseUrl = environment.apiUrl;


  fileForm = new FormGroup({
    altText: new FormControl(''),
    description: new FormControl('')
  });
  fileToUpload: any;
  id!: number;

  constructor(private http:  HttpClient,  private route: ActivatedRoute,private router: Router, private formBuilder: FormBuilder) { 

    this.fileForm = this.formBuilder.group({
      id: ['',  Validators.required],

      name: ['', Validators.required],
      partCode: ['', Validators.required],
      partNumberid: ['', Validators.required],
   
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params.id;
  }

  handleFileInput(e: any) {
    this.fileToUpload = e?.target?.files[0];
  }

  saveFileInfo()
  {
    this.router.navigateByUrl('/productoperations')
    debugger
    this.id = this.id;

    const formData: FormData = new FormData();
    formData.append('myFile', this.fileToUpload);
    formData.append('altText', this.fileForm.value.altText);
    formData.append('description', this.fileForm.value.description);
    return this.http.post(this.baseUrl + 'Photos/' + this.id, formData,
    {
      headers : new HttpHeaders()})
    .subscribe(() => alert("File uploaded"));
  }
}
