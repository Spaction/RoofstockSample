import { TableField } from './table-field';
import { RawData } from './model/raw-data';

describe('TableField', () => {
  it('should create an instance', () => {
    let a: RawData = {id: 0, address:{
      address1: '',

      
      
    }};
    expect(new TableField(a)).toBeTruthy();
  });
});
