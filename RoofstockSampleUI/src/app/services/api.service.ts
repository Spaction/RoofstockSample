import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RawData } from '../model/raw-data';
import { TableField } from '../table-field';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

   private static rawDataURL = 'https://samplerspubcontent.blob.core.windows.net/public/properties.json';

  constructor(private http: HttpClient) { }

  public async getRawData(){
    return await this.http.get<RawData>(ApiService.rawDataURL).toPromise();
  }

  public async saveRow(property: TableField){
    let p = JSON.parse(JSON.stringify(property));;
    delete p['grossYieldPerc'];
    return await this.http.post(environment.baseDataUrl + 'api/Properties/Save', {...p} ).toPromise();
  }

}
