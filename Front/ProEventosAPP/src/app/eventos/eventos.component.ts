import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public filtredEvents: any = [];

  widthImg = 150;
  marginImg = 5;
  showImage = true;
  private _filterList: string = '';

  public get filterList() {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.filtredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.eventos;
  }

  filterEvents(filterEvents: string): any {
    filterEvents.toLocaleLowerCase();
    return this.eventos.filter(
      (e: { tema: string; local: string }) =>
        e.tema.toLocaleLowerCase().indexOf(filterEvents) !== -1 ||
        e.local.toLocaleLowerCase().indexOf(filterEvents) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  toggleImage() {
    this.showImage = !this.showImage;
  }

  public getEventos(): void {
    this.http.get('https://localhost:7134/api/eventos').subscribe(
      (res) => {
        this.eventos = res;
        this.filtredEvents = this.eventos;
      },

      (err) => console.log(err)
    );
  }
}
