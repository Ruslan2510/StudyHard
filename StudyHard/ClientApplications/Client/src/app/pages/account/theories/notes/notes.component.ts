import { Component, Input } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { TheoryNote } from 'src/app/models/theories/theoryNote.model';
import { ContentChange } from 'ngx-quill';
declare var $

@Component({
    selector: 'notes',
    templateUrl: './notes.component.html',
    styleUrls: ['./notes.component.css']
})
export class NotesComponent {
    isLoading: boolean;
    notes: TheoryNote[];
    newNoteContent: any;
    @Input() theoryId: number;
    constructor(private http: HttpClient) {
        this.isLoading = true;
    }

    getAllNotes() {
        this.http.get(`/api/Theories/${this.theoryId}/notes`).subscribe((res: TheoryNote[]) => {
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

    contentChange(editor: ContentChange) {
        this.newNoteContent = editor.content;
    }

}