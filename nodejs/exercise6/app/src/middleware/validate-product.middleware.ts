import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';
import { Product } from '../models/product';

const validateNewProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const newProduct = req.body as Product;
    if (!newProduct) {
        res.sendStatus(400);
        next(new Error('invalid product received'));
    }
    if (newProduct.name.length < 3 || !newProduct.categoryId || isNaN(newProduct.itemsInStock)) {
        res.sendStatus(409);
        next(new Error('received product contains invalid fields'));
    }
    next();
};

const validateExistingProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const productId = req.params.productId;
    if (productId.length !== 36) {
        res.sendStatus(400);
        next(new Error('invalid product id'));
    }

    const product = store.getProduct(productId);
    if (!product) {
        res.sendStatus(404);
        next(new Error('product doesnt exist'));
    }

    next();
};

export { validateNewProductMiddleware, validateExistingProductMiddleware };
