import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { User } from "../_models/user";

@Component({
  selector: "app-tile",
  templateUrl: "./tile.component.html",
  styleUrls: ["./tile.component.css"],
})
export class TileComponent implements OnInit {
  @Input() public user: User;

  constructor() {}
  ngOnInit(): void {}

  @Output() public deleteUser: EventEmitter<string> = new EventEmitter<string>();
  public onClick = (id : string) =>
  {
    event.stopPropagation();
    return this.deleteUser.emit(id);
  }

}
