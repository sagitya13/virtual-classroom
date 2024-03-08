export interface login {
  Name: string;
  password: string;
}

export interface signup {
  id: number;
  Name: string;
  Email: string;
  password: string;
  Role: string;
}

export interface  Response {
  success: boolean;
  message: string;
  // Add other properties as needed
 }
 