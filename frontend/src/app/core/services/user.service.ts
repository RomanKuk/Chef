import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, throwError } from 'rxjs';
import { NewUser } from 'src/app/shared/models/user/new-user';
import { User } from 'src/app/shared/models/user/user';
import { ValidateUser } from 'src/app/shared/models/user/validate-user';
import { clear } from '../utils/registration.utils';
import { CoreHttpService } from './core-http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiPrefix = '/users';

  constructor(
      private httpService: CoreHttpService
  ) { }

  getUserById(id: number): Observable<User> {
      return this.httpService.getRequest<User>(`${this.apiPrefix}/${id}`);
  }

  getUsers() {
    return this.httpService.getRequest<User[]>(`${this.apiPrefix}`);
  }

  uploadAvatar(avatar: FormData, userId: number) {
    return this.httpService.postRequest<User>(`${this.apiPrefix}/avatar/${userId}`, avatar);
  }

  updateUsersById(id: number, user: User): Observable<User> {
      return this.httpService.putRequest<User>(`${this.apiPrefix}/${id}`, user);
  }

  validateUsername(user: ValidateUser) {
    return this.httpService.postRequest<boolean>(`${this.apiPrefix}/validate-username`, user);
  }

  getUser(uid: string) {
      return this.httpService.getRequest<User>(`${this.apiPrefix}/${uid}`)
          .pipe(
              catchError((error: HttpErrorResponse) => {
                  if (error.status === 404) {
                      return of(null as User);
                  }
                  return throwError(() => new Error(error.message));
              })
          );
  }

  createUser(newUser: NewUser) {
      const user = clear(newUser);
      return this.httpService.postRequest<User>(`${this.apiPrefix}`, user);
  }

  updateUser(user: User) {
      return this.httpService.putRequest<User>(`${this.apiPrefix}`, user);
  }

  register(user: NewUser) {
    return this.httpService.postRequest<User>(`${this.apiPrefix}`, user);
  }

  login(uniqueId: string) {
    return this.httpService.getRequest<User>(`${this.apiPrefix}/login/${uniqueId}`);
  }

}
