import { NextFunction, Request, Response } from 'express';
import { Product } from '../models/product';

const validateReceivedProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
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

export { validateReceivedProductMiddleware };
