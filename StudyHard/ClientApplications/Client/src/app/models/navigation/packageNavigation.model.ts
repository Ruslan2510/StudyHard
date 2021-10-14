import { SubjectNavigation } from 'src/app/models/navigation/subjectNavigation.model';

export class PackageNavigation {
    name: string;
    url: string;
    subjectNavigations: SubjectNavigation[];
}