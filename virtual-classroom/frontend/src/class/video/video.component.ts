import { Component, OnInit } from '@angular/core';
import Peer from 'peerjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
 selector: 'app-video',
 templateUrl: './video.component.html',
 styleUrls: ['./video.component.scss'],
})
export class VideoComponent implements OnInit {
 private peer: Peer;
 peerIdShare: string;
 peerId: string;
 private lazyStream: MediaStream | null = null;
 currentPeer: RTCPeerConnection | null = null;
 private peerList: Array<string> = [];
 private isScreenSharing = false;  

 constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute
 ) {
    this.peer = new Peer();
 }

 ngOnInit(): void {
    this.getPeerId();
 }

 private getPeerId = () => {
    this.peer.on('open', (id) => {
      this.peerId = id;
    });
    this.peer.on('call', (call) => {
      navigator.mediaDevices
        .getUserMedia({
          video: true,
          audio: true,
        })
        .then((stream) => {
          if (!this.currentPeer) {
            this.lazyStream = stream;
            this.streamLocalVideo(stream);
          }
          call.answer(stream);
          call.on('stream', (remoteStream) => {
            if (!this.peerList.includes(call.peer)) {
              this.streamRemoteVideo(remoteStream);
              this.currentPeer = call.peerConnection;
              this.peerList.push(call.peer);
            }
          });
        })
        .catch((err) => {
          console.log(err + 'Unable to get media');
        });
    });
 };

 connectWithPeer(): void {
    this.callPeer(this.peerIdShare);
 }

 private callPeer(id: string): void {
    navigator.mediaDevices
      .getUserMedia({
        video: true,
        audio: true,
      })
      .then((stream) => {
        this.lazyStream = stream;
        this.streamLocalVideo(stream);
        const call = this.peer.call(id, stream);
        call.on('stream', (remoteStream) => {
          if (!this.peerList.includes(call.peer)) {
            this.streamRemoteVideo(remoteStream);
            this.currentPeer = call.peerConnection;
            this.peerList.push(call.peer);
          }
        });
      })
      .catch((err) => {
        console.log(err + 'Unable to connect');
      });
 }

 private streamLocalVideo(stream: MediaStream): void {
    const video = document.createElement('video');
    video.classList.add('video');
    video.srcObject = stream;
    video.play();
    const localVideo = document.getElementById('local-video');
    if (localVideo) {
      localVideo.append(video);
    }
 }

 private streamRemoteVideo(stream: MediaStream): void {
    const video = document.createElement('video');
    video.classList.add('video');
    if (this.isScreenSharing) {
      video.classList.add('screen-share'); 
    }
    video.srcObject = stream;
    video.play();
    const remoteVideo = document.getElementById('remote-video');
    if (remoteVideo) {
      remoteVideo.append(video);
    }
 }

 screenShare(): void {
    this.isScreenSharing = true; 
    navigator.mediaDevices
      .getDisplayMedia({
        video: {
          cursor: 'always',
        } as MediaTrackConstraints,
        audio: {
          echoCancellation: true,
          noiseSuppression: true,
        },
      })
      .then((stream) => {
        const videoTrack = stream.getVideoTracks()[0];
        videoTrack.onended = () => {
          this.stopScreenShare();
        };
        const sender = this.currentPeer
          ?.getSenders()
          .find((s: RTCRtpSender) => s.track?.kind === videoTrack.kind);
        sender?.replaceTrack(videoTrack);
      })
      .catch((err) => {
        console.log('Unable to get display media ' + err);
      });
 }

 private stopScreenShare(): void {
    const videoTrack = this.lazyStream?.getVideoTracks()[0];
    const sender = this.currentPeer
      ?.getSenders()
      .find((s: RTCRtpSender) => s.track?.kind === videoTrack.kind);
    sender?.replaceTrack(videoTrack);
    this.isScreenSharing = false; 
 }

 markAttendance(): void {
    this.snackBar.open('Attendance Marked', 'Close', {
      duration: 2000,
    });
 }

 hangUp(): void {
    this.router.navigate(['course', this.route.snapshot.paramMap.get('id')]);
 }
 
 material() {
    this.router.navigate(['material', this.route.snapshot.paramMap.get('id')]);
 }
 isChatOpen = false;

 toggleChat() {
    this.isChatOpen = !this.isChatOpen;
 }
 ismessage=false;

 toggle(){
  this.ismessage=!this.ismessage;
 }
}
