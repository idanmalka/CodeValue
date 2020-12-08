import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';

export const resolveProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const productId = req.params.productId;
    if (productId.length !== 36) {
        res.sendStatus(400);
        return;
    }

    const product = store.getProduct(productId);
    if (!product) {
        res.sendStatus(404);
        return;
    }
    res.locals.product = product;
    next();
};
