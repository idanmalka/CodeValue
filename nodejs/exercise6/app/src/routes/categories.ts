import { Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Category } from '../models/category';
import { store } from '../store/store';
import { validateNewCategoryMiddleware, validateExistingCategoryMiddleware } from '../middleware/validate-category.middleware';
import { createLogger } from '../utils/logger';
import { Logger } from 'winston';
import { asyncWrapper } from '../utils/async-route-handler';

const router = Router();
const logger: Logger = createLogger('Categories');

router.get(
    '/',
    asyncWrapper(() => {
        logger.info(`Requested all categories`);
        return store.getCategoriesAsync();
    }),
);

router.get(
    '/:categoryId',
    validateExistingCategoryMiddleware,
    asyncWrapper((request) => {
        const categoryId = request.params.categoryId;
        logger.info(`Requested category: ${categoryId}`);

        return store.getCategoryAsync(categoryId);
    }),
);

router.get('/:categoryId/products', validateExistingCategoryMiddleware, (request) => {
    const categoryId = request.params.categoryId;
    logger.info(`Requested all products of category: ${categoryId}`);

    return store.getProductsByCategoryId(categoryId);
});

router.post('/', validateNewCategoryMiddleware, (request, response) => {
    const newCategory = request.body as Category;
    logger.info(`Received new category: ${newCategory.name}`);

    newCategory.id = generateId();
    store.addCategory(newCategory);
    response.status(201).send(newCategory);
});

router.put('/:categoryId', validateNewCategoryMiddleware, validateExistingCategoryMiddleware, (request, response) => {
    const newCategory = request.body as Category;
    const existingCategory = store.getCategory(request.params.categoryId) as Category;
    logger.info(`Received edit requets for category: ${existingCategory.id}`);

    newCategory.id = existingCategory.id;
    store.editCategory(newCategory);

    response.send(newCategory);
});

router.delete('/:categoryId', validateExistingCategoryMiddleware, (request, response) => {
    const categoryId = request.params.categoryId;
    logger.info(`Deleting category: ${categoryId}`);

    const res = store.deleteCategory(categoryId);
    response.sendStatus(res ? 204 : 400);
});

export { router };
