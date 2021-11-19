import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { from, of } from 'rxjs';
import { filter, tap, switchMap, map, mergeMap } from 'rxjs/operators';
import firebase from 'firebase/app';
import { User } from 'src/app/shared/models/user/user';
import { NewUser } from 'src/app/shared/models/user/new-user';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private static user: User | null;
  private readonly tokenHelper: JwtHelperService;

  private token!: string | null;
  private rememberUser!: boolean;

  constructor(
    private angularFireAuth: AngularFireAuth,
    private userService: UserService,
    private router: Router
  ) {
    this.tokenHelper = new JwtHelperService();
  }

  login(route?: string[]) {
    this.rememberUser = localStorage.getItem('rememberUser') === 'true';
    return from(this.angularFireAuth.currentUser)
        .pipe(
            filter(firebaseUser => Boolean(firebaseUser)),
            switchMap(firebaseUser => from(firebaseUser!.getIdToken())),
            tap(token => {
                this.setJwToken(token);
                this.router.navigate(route!);
            })
        );
  }

  logout() {
      this.removeJwToken();
      this.removeUser();
      //Watchdog.setUserInfo({ isAnonymous: true });
      this.angularFireAuth.signOut()
          .catch(error => {
              console.warn(error);
          });
  }

  signInWithGoogle(route: string[]) {
    this.logout();
    const provider = new firebase.auth.GoogleAuthProvider();
    provider.addScope('https://www.googleapis.com/auth/userinfo.email');

    return from(this.angularFireAuth
        .signInWithPopup(provider))
        .pipe(
            switchMap(userCredential =>
                this.userService.getUser(userCredential.user!.uid)
                    .pipe(
                        switchMap(user => (user ? of(user)
                            : this.userService.createUser(this.pullNewUserFromGoogle(userCredential))))
                    )),
            tap(user => {
                localStorage.setItem('isSignByEmailAndPassword', 'false');
                return this.setUser(user);
            }),
            switchMap(() => this.login(route))
        );
  }

  pullNewUserFromGoogle(credential: firebase.auth.UserCredential) {
    const user = {
        uid: credential.user!.uid,
        email: credential.user!.email,
        firstName: (credential.additionalUserInfo!.profile as { given_name: string }).given_name,
        lastName: (credential.additionalUserInfo!.profile as { family_name: string }).family_name,
        avatarUrl: credential.user!.photoURL
    } as NewUser;

    return user;
  }

  refreshJwToken(forceRefresh = false) {
    return this.angularFireAuth.authState
        .pipe(
            filter(firebaseUser => Boolean(firebaseUser)),
            mergeMap(firebaseUser => from(firebaseUser!.getIdToken(forceRefresh))),
            tap(token => {
                localStorage.setItem('jwt', token);
                this.token = token;
            })
        );
  }

  removeJwToken() {
    this.token = null;
    localStorage.removeItem('jwt');
  }

  getJwToken() {
    if (!this.token) {
        this.token = localStorage.getItem('jwt');
    }
    if (this.token && !this.tokenHelper.isTokenExpired(this.token)) {
        return of(this.token);
    }
    return this.refreshJwToken();
  }

  setJwToken(token: string) {
      this.token = token;
      if (this.rememberUser) {
          localStorage.setItem('jwt', this.token);
      }
  }

  setUser(user: User) {
    AuthService.user = user;
    localStorage.setItem('user', JSON.stringify(AuthService.user));
  }

  removeUser() {
      AuthService.user = null;
      localStorage.removeItem('user');
  }

  getUserId(): number {
    return this.getUser()!.id;
  }

  getUser() {
    if (!AuthService.user) {
        AuthService.user = JSON.parse(localStorage.getItem('user')!);
    }
    return AuthService.user;
  }

  isAuthenticated(): boolean {
    const user = this.getUser();
    const authResult = Boolean(user) && Boolean(user!.createdAt);
    if (authResult) {
        //Watchdog.setUserInfo({ identifier: user.email, fullName: `${user.firstName} ${user.lastName}` });
    } else {
        //Watchdog.setUserInfo({ isAnonymous: true });
    }
    return authResult;
  }
}
