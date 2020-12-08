import { NextFunction, Request, Response, Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Category } from '../models/category';
import { router as productsRouter } from './products';
import categoriesInitialData from '../../assets/categories.json';

const router = Router();
router.use('/products', productsRouter);
const categories: Category[] = categoriesInitialData || [];

const resolveCategoryHandler = (req: Request, res: Response, next: NextFunction) => {
    const categoryId = req.params.categoryId;
    if (categoryId.length > 36) {
        res.sendStatus(400);
    }

    const category = categories.find((c) => c.id === categoryId);
    if (!category) {
        res.sendStatus(404);
        return;
    }
    res.locals.category = category;
    next();
};

router.get('/categories', (request, response) => response.send(categories));

router.get('/categories/:categoryId', resolveCategoryHandler, (request, response) => {
    response.send(response.locals.category);
});

router.use('/categories/:categoryId/products', resolveCategoryHandler, productsRouter);

router.post('/categories', (request, response) => {
    const newCategory = request.body as Category;
    newCategory.id = generateId();
    categories.push(newCategory);
    response.status(201).send(newCategory);
});

router.put('/categories/:categoryId', resolveCategoryHandler, (request, response) => {
    const newCategory = request.body as Category;
    let existingCategory = response.locals.category;

    newCategory.id = existingCategory.id;
    existingCategory = { ...newCategory };

    response.send(existingCategory);
});

router.delete('/categories/:categoryId', resolveCategoryHandler, (request, response) => {
    categories.splice(response.locals.category, 1);
    response.sendStatus(204);
});

export { router };
