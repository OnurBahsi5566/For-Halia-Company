import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private router: Router) {}

  logout(){
    const confirmation = confirm('Do you want to logout?');
    if(confirmation){
      localStorage.removeItem('access_token');
      sessionStorage.removeItem('id');
      this.router.navigate(['login']);
    }
  }

newCase(){    
      this.router.navigate(['mycase']);
}
  
casesList(){    
    this.router.navigate(['mycaselist']);
}

assigneCase(){    
  this.router.navigate(['newAssignedCase']);
}

myCases(){    
  this.router.navigate(['myAssignedList']);
}
}
