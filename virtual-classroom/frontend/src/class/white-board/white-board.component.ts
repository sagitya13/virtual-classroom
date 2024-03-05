import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
 selector: 'app-white-board',
 templateUrl: './white-board.component.html',
 styleUrls: ['./white-board.component.scss']
})
export class WhiteBoardComponent implements OnInit {
 @ViewChild('whiteboardCanvas', { static: true }) canvas!: ElementRef<HTMLCanvasElement>;
 private ctx!: CanvasRenderingContext2D;
 private drawing = false;
 private prevX!: number;
 private prevY!: number;

 constructor() { }

 ngOnInit(): void {
    // Initialize the canvas context here
    this.ctx = this.canvas.nativeElement.getContext('2d')!;
    this.initWhiteboard();
 }

 

 initWhiteboard(): void {
    this.ctx.lineWidth = 2;
    this.ctx.lineCap = 'round';
    this.ctx.strokeStyle = '#000';
    this.canvas.nativeElement.addEventListener('mousedown', (event) => {
      this.drawing = true;
      this.prevX = event.clientX - this.canvas.nativeElement.offsetLeft;
      this.prevY = event.clientY - this.canvas.nativeElement.offsetTop;
    });
    this.canvas.nativeElement.addEventListener('mousemove', (event) => {
      if (this.drawing) {
        this.draw(event.clientX - this.canvas.nativeElement.offsetLeft, event.clientY - this.canvas.nativeElement.offsetTop);
      }
    });
    this.canvas.nativeElement.addEventListener('mouseup', () => {
      this.drawing = false;
    });
    this.canvas.nativeElement.addEventListener('mouseleave', () => {
      this.drawing = false;
    });
 }

 draw(currX: number, currY: number): void {
    this.ctx.beginPath();
    this.ctx.moveTo(this.prevX, this.prevY);
    this.ctx.lineTo(currX, currY);
    this.ctx.stroke();
    this.ctx.closePath();
    this.prevX = currX;
    this.prevY = currY;
 }
}
