import { Subject } from 'src/app/models/tests/subject.model';

export class Package {
    id: number;
    name: string;
    isActive: boolean;
    price: number;
    description: string;
    isPurchased: boolean;
    isComingSoon: boolean;
    testSubjects: Subject[];
}