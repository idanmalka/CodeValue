import { Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Product } from '../models/product';
import { store } from '../store/store';
import { validateNewProductMiddleware, validateExistingProductMiddleware } from '../middleware/validate-product.middleware';
import { asyncWrapper } from '../utils/async-route-handler';
import { Logger } from 'winston';
import { createLogger } from '../utils/logger';

const router = Router({ mergeParams: true });
const logger: Logger = createLogger('Products');

router.get(
    '/',
    asyncWrapper(() => {
        logger.info(`Requested all products`);
        return store.getProductsAsync();
    }),
);

router.get(
    '/:productId',
    validateExistingProductMiddleware,
    asyncWrapper((request) => {
        const productId = request.params.productId;
        logger.info(`Requested product: ${productId}`);

        return store.getProductAsync(productId);
    }),
);

router.post('/', validateNewProductMiddleware, (request, response) => {
    const newProduct = request.body as Product;
    logger.info(`Received new product: ${newProduct.name}`);

    newProduct.id = generateId();
    store.addProduct(newProduct);
    response.status(201).send(newProduct);
});

router.put('/:productId', validateNewProductMiddleware, validateExistingProductMiddleware, (request, response) => {
    const updatedProduct = request.body as Product;
    const existingProduct = store.getProduct(request.params.productId) as Product;
    logger.info(`Received edit requets for product: ${existingProduct.id}`);

    updatedProduct.id = existingProduct.id;
    store.editProduct(updatedProduct);
    response.send(updatedProduct);
});

router.delete('/:productId', validateExistingProductMiddleware, (request, response) => {
    const productId = request.params.productId;
    logger.info(`Deleting product: ${productId}`);

    const res = store.deleteProduct(productId);
    response.sendStatus(res ? 204 : 400);
});

export { router };
