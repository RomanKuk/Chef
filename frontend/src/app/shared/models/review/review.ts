import { User } from "../user/user";

export interface Review {
    id: number;
    description: string;
    isAlreadyCooked: boolean;
    user: User;
}