import { Inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('access_token');
  const sessionId = sessionStorage.getItem('id');
  const router = Inject(Router);
  console.log('access_token',token);
  console.log('id',sessionId);
  if (token) {
    return true;
  } else {
    router.navigate(['login']);
    return false;
  }
};
