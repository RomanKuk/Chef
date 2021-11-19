import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  redirectUrl: string;

  constructor(
    private route: ActivatedRoute,
    //private firebaseSignInService: FirebaseSignInService
  ) { }

  ngOnInit() {
    //this.redirectUrl = this.route.snapshot.queryParams['redirectUrl'] ?? '/dashboard';
  }

  signInWithGithub() {
    //this.firebaseSignInService.signInWithGithub(this.redirectUrl);
  }

  signInWithGoogle() {
    //this.firebaseSignInService.signInWithGoogle(this.redirectUrl);
  }
}
