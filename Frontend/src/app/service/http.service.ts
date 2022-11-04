import { Injectable } from '@angular/core';
import axios from "axios";


export const customAxios = axios.create({
  baseURL: 'https://localhost:7087',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
});

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }


  async getBoxes() {
    const httpResponse = await customAxios.get<any>('BoxFactory');
    return httpResponse.data;

  }

  async createBox(dto: { boxName: string; heigth: number; length: number; width: number; imageUrl: string; description: string }) {
    const httpResult = await customAxios.post<any>('BoxFactory', dto)
    return httpResult.data;
  }

  async getBoxById(id: number){
    const httpResponse = await customAxios.get<any>('BoxFactory/'+id);
    return httpResponse.data;
  }


  async updateBox(id: any, dto: {boxName: string; heigth: number; length: number; width: number; imageUrl: string; description: string; }) {
    const httpResult = await customAxios.put('BoxFactory/Edit/'+id, dto);
    return httpResult.data;
  }

  async deleteBox(id: any) {
    const httpResult = await customAxios.delete('BoxFactory/'+id);
    return httpResult.data;
  }

  async login(dto: any) {
    const httpResult = await customAxios.post("auth/login", dto);
    return httpResult.data;
  }
}
