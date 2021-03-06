import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';
import { Category } from '../models/category';

const validateNewCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const newCategory = req.body as Category;
    if (newCategory.name.length < 3) {
        res.sendStatus(409);
        return;
    }
    next();
};

const validateExistingCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const categoryId = req.params.categoryId;
    if (categoryId.length !== 36) {
        res.sendStatus(400);
        next(new Error('invalid category id'));
    }

    const category = store.getCategory(categoryId);
    if (!category) {
        res.sendStatus(404);
        next(new Error('category does not exist'));
    }

    next();
};

export { validateNewCategoryMiddleware, validateExistingCategoryMiddleware };
