import { Component, OnInit } from '@angular/core';
import { CitaService } from 'src/app/services/cita.service';
import { Cita } from '../models/cita';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Cliente } from '../models/Cliente';
import { vehiculosolo } from '../models/vehiculosolo';

@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styleUrls: ['./agenda.component.css']
})

export class AgendaComponent implements OnInit  {
  citas : Cita[];
  cita: Cita;
  mensaje: string;
  formGroup: FormGroup;
  cliente:Cliente;
  vehiculo:vehiculosolo;
  constructor(private citaService: CitaService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }
  private buildForm() {
    this.cita = new Cita();
    this.cita.cliente= new Cliente();
    this.cita.vehiculo= new vehiculosolo();
    this.cita.fecha = new Date();
    this.cita.cliente.identificacion = '';
    this.cita.cliente.nombre = '';
    this.cita.cliente.apellido = '';
    this.cita.cliente.edad = 0;
    this.cita.cliente.telefono = '';
    this.cita.cliente.sexo = '';
    this.cita.vehiculo.placa = '';
    this.cita.vehiculo.clienteId = this.cita.cliente.identificacion;
    this.cita.vehiculo.tipo = '';
    this.cita.vehiculo.modelo = '';
    this.cita.vehiculo.color = '';
    this.cita.vehiculo.marca = '';

    this.formGroup = this.formBuilder.group({
      fecha: [this.cita.fecha, Validators.required],
      identificacion: [this.cita.cliente.identificacion, Validators.required],
      nombre: [this.cita.cliente.nombre, Validators.required],
      apellido: [this.cita.cliente.apellido, Validators.required],
      edad: [this.cita.cliente.edad, Validators.required],
      telefono: [this.cita.cliente.telefono, Validators.required],
      sexo: [this.cita.cliente.sexo, [Validators.required, this.ValidaSexo]],
      placa: [this.cita.vehiculo.placa, Validators.required],
      tipo: [this.cita.vehiculo.tipo, Validators.required],
      modelo: [this.cita.vehiculo.modelo, Validators.required],
      color: [this.cita.vehiculo.color, Validators.required],
      marca: [this.cita.vehiculo.marca, Validators.required]
    });
  }
  private ValidaSexo(control: AbstractControl) {
    const sexo = control.value;
    if (sexo.toLocaleUpperCase() !== 'M' && sexo.toLocaleUpperCase() !== 'F') {
      return { validSexo: true, messageSexo: 'Sexo No Valido' };
    }
    return null;
  }
  get control() {
    return this.formGroup.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }
  add(){
    this.cliente= new Cliente();
    this.vehiculo= new vehiculosolo();

    this.cliente.identificacion=this.control.identificacion.value;
    this.cliente.nombre=this.control.nombre.value;
    this.cliente.apellido=this.control.apellido.value;
    this.cliente.telefono=this.control.telefono.value;
    this.cliente.edad=this.control.edad.value;
    this.cliente.sexo=this.control.sexo.value;

    this.vehiculo.placa=this.control.placa.value;
    this.vehiculo.clienteId=this.control.identificacion.value;
    this.vehiculo.tipo=this.control.tipo.value;
    this.vehiculo.marca=this.control.marca.value;
    this.vehiculo.color=this.control.color.value;
    this.vehiculo.modelo=this.control.modelo.value;

   this.cita.cliente=this.cliente;
   this.cita.vehiculo=this.vehiculo;
    this.citaService.post(this.cita).subscribe(p => {
      if (p != null) {
        this.mensaje = "Se guardaron los datos corretamente de la cita";
      }
    });
  }
  get(){
    this.citaService.get().subscribe(p=>this.citas=p);
  }
}
