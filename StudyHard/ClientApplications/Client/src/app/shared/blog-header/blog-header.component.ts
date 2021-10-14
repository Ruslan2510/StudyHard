import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import BlogNews from 'src/app/models/blogNews.model';
import { BlogTemplateComponent } from '../templates/blog/blog.template.component';

@Component({
  selector: 'blog-header',
  templateUrl: './blog-header.component.html',
  styleUrls: ['./blog-header.component.css']
})
export class BlogHeaderComponent implements OnInit {
  
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
