import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public filtredEvents: Evento[] = [];

  public widthImg = 150;
  public marginImg = 5;
  public showImage = true;
  private filteredList: string = '';

  public get filterList() {
    return this.filteredList;
  }

  public set filterList(value: string) {
    this.filteredList = value;
    this.filtredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.eventos;
  }

  public filterEvents(filterEvents: string): Evento[] {
    filterEvents.toLocaleLowerCase();
    return this.eventos.filter(
      (e: { tema: string; local: string }) =>
        e.tema.toLocaleLowerCase().indexOf(filterEvents) !== -1 ||
        e.local.toLocaleLowerCase().indexOf(filterEvents) !== -1
    );
  }

  constructor(private eventoService: EventoService) {}

  public ngOnInit(): void {
    this.getEventos();
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (res: Evento[]) => {
        this.eventos = res;
        this.filtredEvents = this.eventos;
      },
      error: (err) => console.log(err),
    });
  }
}
