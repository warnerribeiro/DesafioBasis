import { Author } from "./author";
import { BookValue } from "./bookvalue";
import { Subject } from "./subject";

export interface Book {
    bookId: number;
    title: string;
    publisher: string;
    edition: number;
    yearOfPublication: string;
    bookAuthor: Author[];
    bookSubject: Subject[];
    bookValue: BookValue[];
}