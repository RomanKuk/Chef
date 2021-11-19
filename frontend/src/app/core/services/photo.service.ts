import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Image } from '../../shared/models/image';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor(private http: HttpClient) { }

  async getImages() {
    const res = await lastValueFrom(this.http.get<any>('assets/landing/photos.json')) 
    const data = <Image[]>res.data;
    return data;
  }
}
