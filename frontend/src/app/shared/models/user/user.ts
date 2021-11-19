export interface User {
    id: number;
    uid: string;
    username: string;
    firstName: string;
    lastName: string;
    email: string;
    avatarUrl: string;
    createdAt?: string;
    productListId: number;
}