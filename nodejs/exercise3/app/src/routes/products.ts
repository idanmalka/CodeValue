import { NextFunction, Request, Response, Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Product } from '../models/product';
import { Category } from '../models/category';
import productsInitialData from '../../assets/products.json';

const products: Product[] = productsInitialData || [];
const router = Router({ mergeParams: true });

const resolveProductHandler = (req: Request, res: Response, next: NextFunction): void => {
    const productId = req.params.productId;
    if (productId.length > 36) {
        res.sendStatus(400);
    }

    const product = products.find((p) => p.id === productId);
    if (!product) {
        res.sendStatus(404);
        return;
    }
    res.locals.product = product;
    next();
};

router.get('/', (request, response) => {
    let result: Product[];
    if (response.locals.category) {
        const category = response.locals.category as Category;
        result = products.filter((product) => product.categoryId === category.id);
    } else {
        result = products;
    }
    response.send(result || []);
});

router.get('/:productId', resolveProductHandler, (request, response) => {
    response.send(response.locals.product);
});

router.post('/', (request, response) => {
    const newProduct = request.body as Product;
    if (!newProduct) {
        response.sendStatus(400);
    }
    if (newProduct.name.length < 3) {
        response.sendStatus(409);
    }

    newProduct.id = generateId();
    products.push(newProduct);
    response.status(201).send(newProduct);
});

router.put('/:productId', resolveProductHandler, (request, response) => {
    const updatedProduct = request.body as Product;
    if (updatedProduct.name.length < 3) {
        response.sendStatus(409);
    }

    let existingProduct = response.locals.product as Product;

    updatedProduct.id = existingProduct.id;
    existingProduct = { ...updatedProduct };

    response.send(existingProduct);
});

router.delete('/:productId', resolveProductHandler, (request, response) => {
    products.splice(response.locals.product, 1);
    response.sendStatus(204);
});

export { router };
