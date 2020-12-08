import { NextFunction, Request, Response } from 'express';
import { store } from '../store/store';

export const resolveCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const categoryId = req.params.categoryId;
    if (categoryId.length !== 36) {
        res.sendStatus(400);
    }

    const category = store.getCategory(categoryId);
    if (!category) {
        res.sendStatus(404);
        return;
    }
    res.locals.category = category;
    next();
};
