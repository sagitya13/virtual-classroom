import { Component, OnInit, provideZoneChangeDetection } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'src/shared/services/message.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  UserName = '';
  MessageContent = '';
  CourseId: number;
  messages: any[] = [];
  isLoading: boolean = true;

  constructor(private ms: MessageService, private route: ActivatedRoute,private router:Router) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.CourseId = +params.get('CourseId');
      this.getMessages();
    });
  }

  onSubmit() {
    this.ms
      .sendMessage(this.UserName, this.MessageContent, this.CourseId)
      .subscribe(
        (response) => {
          console.log('Message sent successfully');
          this.resetMessages();
        },
        (error) => console.error('Failed to send message')
      );
  }
  resetMessages() {
    this.getMessages();
  }

  getMessages() {
    this.isLoading = true;
    console.log(this.CourseId);
    this.ms.getMessagesByCourseId(this.CourseId).subscribe(
      (messages) => {
        this.messages = messages;
        this.isLoading = false;
      },
      (error) => console.error('Failed to fetch messages')
    );
  }
  dashboard(){
    this.router.navigate(['dashboard']);
  }
  
}
