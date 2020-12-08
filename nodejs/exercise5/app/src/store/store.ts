import { Category } from '../models/category';
import { Product } from '../models/product';
import productsInitialData from '../assets/products.json';
import categoriesInitialData from '../assets/categories.json';

export class Store {
    private _productsMap: Map<string, Product> = new Map<string, Product>();
    private _categoriesMap: Map<string, Category> = new Map<string, Category>();

    constructor(initialProducts: Product[], initialCategories: Category[]) {
        initialProducts.forEach((product) => this._productsMap.set(product.id, product));
        initialCategories.forEach((category) => this._categoriesMap.set(category.id, category));
    }

    public addProduct(newProduct: Product): boolean {
        if (this._productsMap.has(newProduct.id)) {
            return false;
        }
        this._productsMap.set(newProduct.id, newProduct);
        return true;
    }

    public addCategory(newCategory: Category): boolean {
        if (this._categoriesMap.has(newCategory.id)) {
            return false;
        }
        this._categoriesMap.set(newCategory.id, newCategory);
        return true;
    }

    public editProduct(newProduct: Product): boolean {
        try {
            const product = this._productsMap.get(newProduct.id);
            Object.assign(product, newProduct);
            return true;
        } catch (err) {
            return false;
        }
    }

    public editCategory(newCategory: Category): boolean {
        try {
            const product = this._categoriesMap.get(newCategory.id);
            Object.assign(product, newCategory);
            return true;
        } catch (err) {
            return false;
        }
    }

    public getProducts(): Product[] {
        return this.createDeepCopy(Array.from(this._productsMap.values()));
    }

    public getProductsAsync(): Promise<Product[]> {
        return Promise.resolve(this.getProducts());
    }

    public getCategories(): Category[] {
        return this.createDeepCopy(Array.from(this._categoriesMap.values()));
    }

    public getCategoriesAsync(): Promise<Category[]> {
        return Promise.resolve(this.getCategories());
    }

    public getProduct(id: string): Product | undefined {
        const product = this._productsMap.get(id);
        return this.createDeepCopy(product);
    }

    public getProductAsync(id: string): Promise<Product | undefined> {
        return Promise.resolve(this.getProduct(id));
    }

    public getCategory(id: string): Category | undefined {
        const category = this._categoriesMap.get(id);
        return this.createDeepCopy(category);
    }

    public getCategoryAsync(id: string): Promise<Category | undefined> {
        return Promise.resolve(this.getCategory(id));
    }

    public getProductsByCategoryId(categoryId: string): Product[] {
        const filteredProducts = Array.from(this._productsMap.values()).filter((product) => product.categoryId === categoryId);
        return this.createDeepCopy(filteredProducts);
    }

    public deleteProduct(productId: string): boolean {
        return this._productsMap.delete(productId);
    }

    public deleteCategory(categoryId: string, clearProducts?: boolean): boolean {
        if (clearProducts) {
            this.getProductsByCategoryId(categoryId).forEach((product) => this.deleteProduct(product.id));
        }

        return this._categoriesMap.delete(categoryId);
    }

    private createDeepCopy<T>(object: T): T {
        return JSON.parse(JSON.stringify(object));
    }
}

const store = new Store(productsInitialData, categoriesInitialData);
export { store };
