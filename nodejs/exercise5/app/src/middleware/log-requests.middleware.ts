import { NextFunction, Request, Response } from 'express';
import { logger } from '../utils/logger';

export const logRequestsMiddleware = (req: Request, res: Response, next: NextFunction): void => {
    const requestString = `[${req.method}] ${req.url}`;
    logger.log(`[REQ RECEIVED] ${requestString}`);
    res.on('finish', () => logger.log(`[REQ ENDED] ${requestString}`));
    next();
};
