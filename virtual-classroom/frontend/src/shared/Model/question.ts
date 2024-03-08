export interface Question {
  id: number;
  question: string;
  opt1: string;
  opt2: string;
  opt3: string;
  opt4: string;
  answer: string;
}
export interface Option{
  correct:boolean;
}