import { Component, OnInit } from '@angular/core';
import { ViewEncapsulation } from '@angular/core';
import { BlogTemplateComponent } from 'src/app/shared/templates/blog/blog.template.component';
import BlogNews from 'src/app/models/blogNews.model';

@Component({
  selector: 'blog-page',
  templateUrl: './blog-page.component.html',
  styleUrls: ['./blog-page.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class BlogPageComponent implements OnInit {

  constructor(private blogTemplate: BlogTemplateComponent) {  }

  blog: BlogNews;
  isLoading: boolean = true;

  ngOnInit(): void {
      this.blogTemplate.getBlog().subscribe((res: BlogNews) => {
        this.blog = res;
        this.isLoading = false;
      });
  }
}
