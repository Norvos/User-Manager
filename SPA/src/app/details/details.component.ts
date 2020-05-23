import { Component, OnInit } from "@angular/core";
import { User } from "../interfaces/user";
import { userService } from "../services/UserService";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-details",
  templateUrl: "./details.component.html",
  styleUrls: ["./details.component.css"],
})
export class DetailsComponent implements OnInit {
  public user: User;
  public dataLoaded = false;

  constructor(
    private userService: userService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((id) => {
      this.userService.getUser(parseInt(id.get("id"),10)).subscribe( data => {
        this.user = data;
        this.dataLoaded = true;
      });
    });
  }
}
