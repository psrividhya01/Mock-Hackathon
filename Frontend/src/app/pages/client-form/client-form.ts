import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Navbar } from '../../components/navbar/navbar';

@Component({
  selector: 'app-client-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, Navbar],
  templateUrl: './client-form.html',
  styleUrls: ['./client-form.css']
})
export class ClientForm {
  private fb = inject(FormBuilder);

  submitted = false;

  clientForm = this.fb.group({
    clientName: ['', [Validators.required, Validators.minLength(3)]],
    email:      ['', [Validators.required, Validators.email]],
    hourlyRate: [null as number | null, [Validators.required, Validators.min(1)]]
  });

  get f() { return this.clientForm.controls; }

  onSubmit(): void {
    this.submitted = true;
    if (this.clientForm.valid) {
      console.log('Client:', this.clientForm.value);
    }
  }

  onReset(): void {
    this.submitted = false;
    this.clientForm.reset();
  }
}