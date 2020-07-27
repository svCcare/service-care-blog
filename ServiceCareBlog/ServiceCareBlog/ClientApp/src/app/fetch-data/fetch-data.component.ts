import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public posts: Post[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Post[]>(baseUrl + 'api/blogpost').subscribe(result => {
      this.posts = result;
    }, error => console.error(error));
  }
}

interface Post {
  title: string;
  content: string;
}
