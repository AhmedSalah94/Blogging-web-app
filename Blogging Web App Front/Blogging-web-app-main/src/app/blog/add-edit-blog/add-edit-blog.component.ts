import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SharedService } from "src/app/shared.service";

@Component({
  selector: 'app-add-edit-blog',
  templateUrl: './add-edit-blog.component.html',
  styleUrls: ['./add-edit-blog.component.scss']
})
export class AddEditBlogComponent implements OnInit {

  @Input() blog:any;
  @Output() btnClick = new EventEmitter
  id:number = 0;
  title: string ="";
  body: string ="";
  creationDate:string="";

  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.id = this.blog.id;
    this.title = this.blog.title;
    this.body = this.blog.body;
    this.creationDate = this.blog.creationDate;
    console.log(this.id)
  }
  addBlog(){
    var val = {
      title:this.title,
      body:this.body

    };
    console.log(val)
      this.service.addBlog(val).subscribe(res =>{
        //alert(res.toString());
        console.log(res);
        this.btnClick.emit(false);

      },error=>{
        console.log(error)
      })
  }

  updateBlog(){
    var val = {id:this.id,
      title:this.title,
      body:this.body,
      creationDate:this.creationDate};
  console.log(val)
      this.service.updateBlog(val).subscribe(res =>{
        this.btnClick.emit(false);
    },error=>{
      console.log(error)
    })
  }
}
