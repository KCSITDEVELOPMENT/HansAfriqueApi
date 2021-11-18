import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-stepper-form',
  templateUrl: './stepper-form.component.html',
  styleUrls: ['./stepper-form.component.css'],
  providers: [{provide: CdkStepper, useExisting: StepperFormComponent}]
})
export class StepperFormComponent extends CdkStepper implements OnInit {
  @Input()
  linearModeSeleted!: boolean;


  ngOnInit(): void {
    this.linear = this.linearModeSeleted;
  }

  onClick(index :number){
    this.selectedIndex = index;
    console.log(this.selectedIndex);
  }
}
