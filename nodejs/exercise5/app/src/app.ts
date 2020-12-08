import express from 'express';
import cors from 'cors';
import { router as categoriesRouter } from './routes/categories';
import { router as productsRouter } from './routes/products';
import { clientErrorHandler, errorHandler, logErrors } from './middleware/errors';
import { logRequestsMiddleware } from './middleware/log-requests.middleware';

const app = express();

app.use(express.json());
app.use(cors());
app.use(logRequestsMiddleware);

app.use('/api/categories', categoriesRouter);
app.use('/api/products', productsRouter);

app.use(logErrors);
app.use(clientErrorHandler);
app.use(errorHandler);

export { app };
