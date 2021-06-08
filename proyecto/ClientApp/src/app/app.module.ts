;
import { ConsultaEmpleadoComponent } from './Empleado/consulta-empleado/consulta-empleado.component';
import { RegistroEmpleadoComponent } from './Empleado/registro-empleado/registro-empleado.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ServicioComponent } from './servicio/servicio.component';
import { RegistroComponent } from './cliente/registro/registro.component';
import { ConsultaComponent } from './cliente/consulta/consulta.component';
import { RegistroMaterialesComponent } from './bodega/registro-materiales/registro-materiales.component';
import { ConsultaMaterialesComponent } from './bodega/consulta-materiales/consulta-materiales.component';
import { AgendaComponent } from './agenda/agenda.component';
import { CotizacionComponent } from './cotizacion/cotizacion.component';
import { NavMenuAdmiComponent } from './nav-menu-admi/nav-menu-admi.component';
import { InciosecionComponent } from './inciosecion/inciosecion.component';
import { ClienteService } from './services/cliente.service';
import { EmpleadoService } from './services/empleado.service';
import { CitaService } from './services/cita.service';
import { ProductoService } from './services/producto.service';
import { ServicioService } from './services/servicio.service';
import { VehiculoService } from './services/vehiculo.service';
import { HandleHttpErrorService } from './@base/handle-http-error.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ServicioComponent,
    RegistroComponent,
    ConsultaComponent,
    RegistroEmpleadoComponent,
    ConsultaEmpleadoComponent,
    RegistroMaterialesComponent,
    ConsultaMaterialesComponent,
    AgendaComponent,
    CotizacionComponent,
    NavMenuAdmiComponent,
    InciosecionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'servicio', component: ServicioComponent},
    { path: 'registroCliente', component: RegistroComponent},
    { path: 'consultaCliente', component: ConsultaComponent},
    { path: 'registroEmpleado', component: RegistroEmpleadoComponent},
    { path: 'consultaEmpleado', component: ConsultaEmpleadoComponent},
    { path: 'registroMateriales', component: RegistroMaterialesComponent},
    { path: 'consultaMateriales', component: ConsultaMaterialesComponent},
    { path: 'agenda', component: AgendaComponent},
    { path: 'cotizacion', component: CotizacionComponent},
    { path: 'navmenuadmi', component: NavMenuAdmiComponent},
    { path: 'iniciosecion' , component: InciosecionComponent}
], { relativeLinkResolution: 'legacy' })
  ],
  providers: [ CitaService ,
              ClienteService , 
              EmpleadoService , 
              ProductoService , 
              ServicioService, 
              VehiculoService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
