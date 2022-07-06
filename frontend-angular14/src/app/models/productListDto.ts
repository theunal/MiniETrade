import { Product } from "./product";


export interface ProductListDto extends Product {
    totalCount: number
}