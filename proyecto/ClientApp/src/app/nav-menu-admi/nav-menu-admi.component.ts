import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu-admi',
  templateUrl: './nav-menu-admi.component.html',
  styleUrls: ['./nav-menu-admi.component.css']
})
export class NavMenuAdmiComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  isExpanded = false;
  collapse() {
    this.isExpanded = false;
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
