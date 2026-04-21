import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './task-form.html',
  styleUrls: ['./task-form.css']
})
export class TaskForm {
  private fb = inject(FormBuilder);

  submitted = false;

  taskForm = this.fb.group({
    hoursWorked: [null as number | null, [Validators.required, Validators.min(0.5), Validators.max(24)]],
    description: ['', [Validators.required, Validators.minLength(10)]]
  });

  get f() { return this.taskForm.controls; }

  onSubmit(): void {
    this.submitted = true;
    if (this.taskForm.valid) {
      console.log('Task:', this.taskForm.value);
    }
  }

  onReset(): void {
    this.submitted = false;
    this.taskForm.reset();
  }
}