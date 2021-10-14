var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { TheoryNote } from 'src/app/models/theories/theoryNote.model';
let NotesComponent = class NotesComponent {
    constructor(http) {
        this.http = http;
        this.isLoading = true;
    }
    getAllNotes() {
        this.http.get(`/api/Theories/${this.theoryId}/notes`).subscribe((res) => {
            this.notes = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
    ngOnInit() {
        this.getAllNotes();
    }
    addNote() {
        if (this.newNoteContent !== undefined) {
            let newNote = new TheoryNote();
            newNote.content = JSON.stringify(this.newNoteContent);
            if (newNote.content.length > 0) {
                newNote.theorySectionId = parseInt(this.theoryId.toString(), 10);
                this.notes.push(newNote);
                this.http.post(`/api/Theories/theorynote`, newNote).subscribe();
                $('.ql-editor').last().children('p').text('');
            }
        }
    }
    contentChange(editor) {
        this.newNoteContent = editor.content;
    }
};
__decorate([
    Input(),
    __metadata("design:type", Number)
], NotesComponent.prototype, "theoryId", void 0);
NotesComponent = __decorate([
    Component({
        selector: 'notes',
        templateUrl: './notes.component.html',
        styleUrls: ['./notes.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient])
], NotesComponent);
export { NotesComponent };
//# sourceMappingURL=notes.component.js.map