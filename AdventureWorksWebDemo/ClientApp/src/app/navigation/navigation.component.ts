import { Component, OnInit } from '@angular/core';
import { MetadataService } from '../../service/metadata/metadata.service';
import { Menu } from '../../model/metadata/menu';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  panelOpenState: boolean;
  menu: Array<Menu>;

  constructor(private metadataService: MetadataService) { }

  ngOnInit(): void {
    this.metadataService.getMenu().subscribe(result => {
      this.menu = result;
    });
  }

}
