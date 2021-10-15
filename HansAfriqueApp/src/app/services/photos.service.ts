import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {
  baseUrl = environment.apiUrl;

  constructor(private http : HttpClient) { }

  postFile(caption: string, fileToUpload: File) {
    //const endpoint = 'http://localhost:28101/api/UploadImage';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('ImageCaption', caption);
    return this.http
      .post(this.baseUrl, formData);
  }
}
