import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceGeneration } from './invoice-generation';

describe('InvoiceGeneration', () => {
  let component: InvoiceGeneration;
  let fixture: ComponentFixture<InvoiceGeneration>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvoiceGeneration],
    }).compileComponents();

    fixture = TestBed.createComponent(InvoiceGeneration);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
