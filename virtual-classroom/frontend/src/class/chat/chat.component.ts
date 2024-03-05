// import { Component, OnInit, provideZoneChangeDetection } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { SchoolService } from 'src/shared/services/school.service';

// @Component({
//   selector: 'app-chat',
//   templateUrl: './chat.component.html',
//   styleUrls: ['./chat.component.scss']
// })
// export class ChatComponent implements OnInit {
//   UserName = '';
//   MessageContent = '';
  
//   CourseId: number;
//   messages: any[] = [];
  

//   constructor(private school: SchoolService,private route:ActivatedRoute) {}

//   ngOnInit() {
//     this.route.paramMap.subscribe(params=>{
//       this.CourseId=+params.get('CourseId');
//       this.getMessages();
//     });
    
//   }


//   onSubmit() {
//     this.school.sendMessage(this.UserName, this.MessageContent,this.CourseId).subscribe(
//       response => console.log('Message sent successfully'),
//       error => console.error('Failed to send message')
//     );
  
// }

// getMessages() {
//   console.log (this.CourseId);
//   this.school.getMessagesByCourseId(this.CourseId).subscribe(
//     messages => {
//       this.messages = messages;
//       // this.changeDetectorRef.detectChanges();/
//     },
//     error => console.error('Failed to fetch messages')
//   );
// }
// }


import { Component, OnInit, provideZoneChangeDetection } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SchoolService } from 'src/shared/services/school.service';
 
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  UserName = '';
  MessageContent = '';
  CourseId: number;
  messages: any[] = [];
  isLoading:boolean=true
 
  constructor(private school: SchoolService,private route:ActivatedRoute) {}
 
  ngOnInit() {
    this.route.paramMap.subscribe(params=>{
      this.CourseId=+params.get('CourseId');
      this.getMessages();
    });
  }
 
 
  onSubmit() {
    this.school.sendMessage(this.UserName, this.MessageContent,this.CourseId).subscribe(
      response => {console.log('Message sent successfully');
      this.resetMessages();
    },
      error => console.error('Failed to send message')
    );
}
resetMessages() {
  this.getMessages();
}
 
getMessages() {
	this.isLoading=true
  console.log (this.CourseId);
  this.school.getMessagesByCourseId(this.CourseId).subscribe(
    messages => {
     
      
      this.messages = messages;
      console.log(this.messages);
	this.isLoading=false
      // this.changeDetectorRef.detectChanges();/
    },
    error => console.error('Failed to fetch messages')
  );
}
}