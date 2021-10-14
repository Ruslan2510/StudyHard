import { Answer } from 'src/app/models/tests/answer.model';

export class Question {
    id: number;
    categoryName: string;
    questionText: string;
    testCategoryId: number;
    simpleTestAnswers: Answer[];
    testDescription: string;
}

export class SimpleQuestion {
    question: string;
    answers: SimpleAnswer[];
}
export class SimpleAnswer {
    answer: string;
    IsCorrect: boolean;
} 