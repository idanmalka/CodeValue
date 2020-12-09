import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';
import { Product } from '../models/product';
import { existingProductSchema, newProductSchema, idSchema } from '../validation/product.validation';
import { ValidationResult } from 'joi';

const validateNewProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const newProduct = req.body as Product;
    const validationResult: ValidationResult = newProductSchema.validate(newProduct);

    if (validationResult.error) {
        res.sendStatus(400);
        next(validationResult.error);
    }
    next();
};

const validateExistingProductMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const productId = req.params.productId;
    const idValidationResult: ValidationResult = idSchema.validate(productId);
    if (idValidationResult.error) {
        res.sendStatus(400);
        next(idValidationResult.error);
    }

    if (req.method.toLowerCase() === 'post' || req.method.toLowerCase() === 'put') {
        const updatedProduct = req.body as Product;
        const updatedProductValidationResult = existingProductSchema.validate(updatedProduct);
        if (updatedProductValidationResult.error) {
            res.sendStatus(400);
            next(updatedProductValidationResult.error);
        }
    }

    const product = store.getProduct(productId);
    if (!product) {
        res.sendStatus(404);
        next(new Error('product doesnt exist'));
    }

    next();
};

export { validateNewProductMiddleware, validateExistingProductMiddleware };
