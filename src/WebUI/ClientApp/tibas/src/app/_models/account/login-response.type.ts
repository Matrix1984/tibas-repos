import { User } from "./user.type";

export interface LoginResponse {
  token: string;
  error: string;
  errorCode: number;
  user:User;
}
