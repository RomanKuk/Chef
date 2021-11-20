import { ComponentIngredient } from "../component-ingredient/component-ingredient";

export interface Component {
    id: number;
    name: string;
    ingredients: ComponentIngredient[];
}