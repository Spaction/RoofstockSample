import { Component } from '@angular/core';
import { Physical } from './model/physical';
import { RawData } from './model/raw-data';
import { ApiService } from './services/api.service';
import { TableField } from './table-field';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'RoofstockSampleUI';

  tableData!: TableField[];

  constructor(private api: ApiService){
  }

  async ngOnInit() {
    this.tableData = ( await this.api.getRawData()).properties.map(y => new TableField(y) );
  }

  public async SaveRow(property: TableField){
    await this.api.saveRow(property);
  }
  
}
