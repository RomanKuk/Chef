import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TabViewModule } from 'primeng/tabview';
import { ProductListComponent } from './product-list/product-list.component';
import { PortalRoutingModule } from './portal-routing.module';
import { HomeComponent } from './home/home.component';
import { CardModule } from 'primeng/card';
import { RecipeModule } from '../recipe/recipe.module';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { NoopAnimationPlayer } from '@angular/animations';
import { DialogModule } from 'primeng/dialog';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';


@NgModule({
  declarations: [
    DashboardComponent,
    ProductListComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    PortalRoutingModule,
    MenubarModule,
    InputTextModule,
    TabViewModule,
    ButtonModule,
    DropdownModule,
    CardModule,
    DialogModule,
    CheckboxModule,
    MultiSelectModule,
    SharedModule,
    RecipeModule,
    FormsModule
  ]
})
export class PortalModule { }
