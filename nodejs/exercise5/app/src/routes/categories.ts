import { Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Category } from '../models/category';
import { resolveCategoryMiddleware } from '../middleware/resolve-category.middleware';
import { store } from '../store/store';
import { validateReceivedCategoryMiddleware } from '../middleware/validate-category.middleware';

const router = Router();

router.get('/', (request, response) => response.send(store.getCategories()));

router.get('/:categoryId', resolveCategoryMiddleware, (request, response) => {
    response.send(response.locals.category);
});

router.get('/:categoryId/products', resolveCategoryMiddleware, (request, response) => {
    return store.getProductsByCategoryId(response.locals.category.id);
});

router.post('/', validateReceivedCategoryMiddleware, (request, response) => {
    const newCategory = request.body as Category;
    newCategory.id = generateId();
    store.addCategory(newCategory);
    response.status(201).send(newCategory);
});

router.put('/:categoryId', validateReceivedCategoryMiddleware, resolveCategoryMiddleware, (request, response) => {
    const newCategory = request.body as Category;
    const existingCategory = response.locals.category;

    newCategory.id = existingCategory.id;
    store.editCategory(newCategory);

    response.send(newCategory);
});

router.delete('/:categoryId', resolveCategoryMiddleware, (request, response) => {
    const res = store.deleteCategory(response.locals.category.id);
    response.sendStatus(res ? 204 : 400);
});

export { router };
