import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class CoreHttpService extends HttpInternalService {
  constructor(protected override http: HttpClient) {
      super(http, environment.apiUrl);
  }
}
