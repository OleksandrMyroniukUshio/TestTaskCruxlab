import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface PasswordValidationResponse {
  validPasswordCount: number;
}

@Component({
  selector: 'app-password-page',
  templateUrl: './password-page.component.html',
  styleUrls: ['./password-page.component.css']
})
export class PasswordPageComponent {
    private apiURL = "http://localhost:7202/PasswordValidate/upload";
    private fileContent!: string;
    validPasswordCount: number = 0;

    constructor(private http: HttpClient) { }

    onFileSelected(event: Event) {
        const input = event.target as HTMLInputElement;
        const file = input.files ? input.files[0] : null;

        if (file) {
            const reader = new FileReader();
            reader.onload = (e: any) => {
                this.fileContent = e.target.result;
            };
            reader.readAsText(file);
        }
    }

    uploadFile() {
        if (this.fileContent) {
          this.http.post<PasswordValidationResponse>(this.apiURL, { content: this.fileContent })
              .subscribe({
                  next: (response) => {
                      this.validPasswordCount = response.validPasswordCount;
                  },
                  error: (err) => {
                      console.error('Error occured:', err);
                  }
              });
        } else {
            console.error('No file content available to send.');
        }
    }
}
