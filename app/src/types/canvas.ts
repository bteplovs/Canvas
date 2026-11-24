export interface CanvasResponse {
  id: number;
  userId: number;
}

export interface CreateCanvasRequest {
  name: string;
  Data: string;
}

export interface UpdateCanvasRequest {
  name: string | null;
  Data: string | null;
}
