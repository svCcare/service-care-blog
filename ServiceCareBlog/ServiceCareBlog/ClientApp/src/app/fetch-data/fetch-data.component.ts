import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public posts: Post[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Post[]>(baseUrl + 'api/blogpost').subscribe(result => {
      this.posts = result;
    }, error => console.error(error));
  }

  public deletePost(postId:number){
    const url = `https://localhost:44335/api/BlogPost/${postId}`;
    this.http.delete(url).subscribe(data => {
      console.log(data);
      this.posts = this.posts.filter(function(value, index, arr){ return value.postId != postId;});
    });
  }

}

interface Post {
  postId: number;
  title: string;
  content: string;
}
