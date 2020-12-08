import { Router } from 'express';
import { generateId } from '../utils/id-generator';
import { Product } from '../models/product';
import { resolveProductMiddleware } from '../middleware/resolve-product.middleware';
import { store } from '../store/store';
import { validateReceivedProductMiddleware } from '../middleware/validate-product.middleware';
import { asyncWrapper } from '../utils/async-route-handler';

const router = Router({ mergeParams: true });

router.get(
    '/',
    asyncWrapper(() => store.getProductsAsync()),
);

router.get(
    '/:productId',
    resolveProductMiddleware,
    asyncWrapper((request, response) => store.getProductAsync(response.locals.product.id)),
);

router.post('/', validateReceivedProductMiddleware, (request, response) => {
    const newProduct = request.body as Product;
    newProduct.id = generateId();
    store.addProduct(newProduct);
    response.status(201).send(newProduct);
});

router.put('/:productId', validateReceivedProductMiddleware, resolveProductMiddleware, (request, response) => {
    const updatedProduct = request.body as Product;
    const existingProduct = response.locals.product as Product;
    updatedProduct.id = existingProduct.id;
    store.editProduct(updatedProduct);
    response.send(updatedProduct);
});

router.delete('/:productId', resolveProductMiddleware, (request, response) => {
    const res = store.deleteProduct(response.locals.product.id);
    response.sendStatus(res ? 204 : 400);
});

export { router };
