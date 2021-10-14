import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import BlogNews from 'src/app/models/blogNews.model';
import PaginatedData from 'src/app/models/pagination/paginatedData.model';
import PaginationData from 'src/app/models/pagination/paginationData.model';

@Component({
  selector: 'app-footer',
  templateUrl: './app-footer.component.html',
  styleUrls: ['./app-footer.component.css']
})
export class AppFooterComponent implements OnInit {

  constructor(private http: HttpClient) { }

  blogs: BlogNews[];

  ngOnInit(): void {

    const pagination: PaginationData = {
      page: 0,
      pagesize: 3
    };

    this.getPaginatedBlogs(pagination);
  }

  getPaginatedBlogs(pagination: PaginationData) {
    this.http.post("/api/Blog/bloglist", pagination).subscribe((res: PaginatedData) => {
      this.blogs = res.paginatedList;
    }, error => {
        console.log(error);
    });
  }

}
