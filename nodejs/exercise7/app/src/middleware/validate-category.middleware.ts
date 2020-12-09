import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';
import { Category } from '../models/category';
import { idSchema, existingCategorySchema, newCategorySchema } from '../validation/category.validation';
import { ValidationResult } from 'joi';

const validateNewCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const newCategory = req.body as Category;
    const validationResult = newCategorySchema.validate(newCategory);

    if (validationResult.error) {
        res.sendStatus(409);
        next(validationResult.error);
    }
    next();
};

const validateExistingCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const categoryId = req.params.categoryId;
    const idValidationResult: ValidationResult = idSchema.validate(categoryId);
    if (idValidationResult.error) {
        res.sendStatus(400);
        next(idValidationResult.error);
    }

    if (req.method.toLowerCase() === 'post' || req.method.toLowerCase() === 'put') {
        const updatedCategory = req.body as Category;
        const updatedCategoryValidationResult = existingCategorySchema.validate(updatedCategory);
        if (updatedCategoryValidationResult.error) {
            res.sendStatus(400);
            next(updatedCategoryValidationResult.error);
        }
    }

    const category = store.getCategory(categoryId);
    if (!category) {
        res.sendStatus(404);
        next(new Error('category does not exist'));
    }

    next();
};

export { validateNewCategoryMiddleware, validateExistingCategoryMiddleware };
