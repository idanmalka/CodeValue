import { NextFunction, Request, Response } from 'express';
import { Category } from '../models/category';

const validateReceivedCategoryMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const newCategory = req.body as Category;
    if (newCategory.name.length < 3) {
        res.sendStatus(409);
        return;
    }
    next();
};

export { validateReceivedCategoryMiddleware };
