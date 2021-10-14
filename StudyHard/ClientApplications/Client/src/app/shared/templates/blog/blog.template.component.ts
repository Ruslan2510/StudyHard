import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'blog.template',
  templateUrl: './blog.template.component.html',
  styleUrls: ['./blog.template.component.css']
})
export class BlogTemplateComponent {

  constructor(private http: HttpClient, private activatedRoute: ActivatedRoute) {  }

  getBlog() {
    let blogId: string = "";
    this.activatedRoute.params.subscribe(params => {
      blogId = params['id'];
    });
    return this.http.get(`api/blog/${blogId}`);
  }
}
