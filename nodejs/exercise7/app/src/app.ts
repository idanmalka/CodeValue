import express from 'express';
import cors from 'cors';
import { router as categoriesRouter } from './routes/categories';
import { router as productsRouter } from './routes/products';
import { traceLogger, errorLogger } from './middleware/log-requests.middleware';

const app = express();

app.use(express.json());
app.use(cors());
app.use(traceLogger());

app.use('/api/categories', categoriesRouter);
app.use('/api/products', productsRouter);

app.use(errorLogger());

export { app };
