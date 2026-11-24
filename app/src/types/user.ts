export interface UserResponse {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  username: string;
}

export interface CreateUserRequest {
  firstName: string;
  lastName: string;
  email: string;
  username: string;
  password: string;
}

export interface LoginUserRequest {
  email: string;
  password: string;
}
