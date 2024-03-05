

import { Component, OnInit } from '@angular/core';
import Peer from 'peerjs';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
 selector: 'app-video',
 templateUrl: './video.component.html',
 styleUrls: ['./video.component.scss']
})
 export class VideoComponent implements OnInit {


 private peer: Peer;
 peerIdShare: any;
 peerId: any;
 private lazyStream: any;
 currentPeer: any;
 private peerList: Array<any> = [];
 constructor(private snackBar: MatSnackBar) {
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
     navigator.mediaDevices.getUserMedia({
       video: true,
       audio: true
     }).then((stream) => {
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
     }).catch(err => {
       console.log(err + 'Unable to get media');
     });
   });
 }
 connectWithPeer(): void {
   this.callPeer(this.peerIdShare);
 }
 private callPeer(id: string): void {
   navigator.mediaDevices.getUserMedia({
     video: true,
     audio: true
   }).then((stream) => {
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
   }).catch(err => {
     console.log(err + 'Unable to connect');
   });
 }
 private streamLocalVideo(stream: any) {
   const video = document.createElement('video');
   video.classList.add('video');
   video.srcObject = stream;
   video.play();
   const localVideo = document.getElementById('local-video');
   if (localVideo) {
     localVideo.append(video);
   }
 }
 private streamRemoteVideo(stream: any) {
   const video = document.createElement('video');
   video.classList.add('video');
   video.srcObject = stream;
   video.play();
   const remoteVideo = document.getElementById('remote-video');
   if (remoteVideo) {
     remoteVideo.append(video);
   }
 }
 screenShare(): void {
   navigator.mediaDevices.getDisplayMedia({
     video: {
       cursor: "always"
     } as MediaTrackConstraints,
     audio: {
       echoCancellation: true,
       noiseSuppression: true
     }
   }).then(stream => {
     const videoTrack = stream.getVideoTracks()[0];
     videoTrack.onended = () => {
       this.stopScreenShare();
     };
     const sender = this.currentPeer.getSenders().find((s: RTCRtpSender) => s.track?.kind === videoTrack.kind);
     sender.replaceTrack(videoTrack);
   }).catch(err => {
     console.log('Unable to get display media ' + err);
   });
 }
 private stopScreenShare() {
   const videoTrack = this.lazyStream.getVideoTracks()[0];
   const sender = this.currentPeer.getSenders().find((s: RTCRtpSender) => s.track?.kind === videoTrack.kind);
   sender.replaceTrack(videoTrack);
 }
 markAttendance(): void {
   // Logic to mark attendance
   // Display pop-up notification upon successful attendance marking
   this.snackBar.open('Attendance Marked', 'Close', {
     duration: 2000,
   });
 }
 hangUp(): void {
    }
}