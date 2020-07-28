import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  title:string;
  content:string;

  constructor(private http:HttpClient) { }

  ngOnInit() {
  }

  public createPost(){
    let url = "https://localhost:44335/api/BlogPost";
    
    this.http.post(url, {
      title:this.title,
      content:this.content
    }).toPromise().then((data) => {
      console.log(data);
    })


  }

}
